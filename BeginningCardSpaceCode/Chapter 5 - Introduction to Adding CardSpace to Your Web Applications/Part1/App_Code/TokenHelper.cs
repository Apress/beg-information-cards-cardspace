/*
 * Copyright (c) Microsoft Corporation.  All rights reserved.
 */

using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Xml;
using System.IO;
using System.ServiceModel;
using System.ServiceModel.Security;
using System.IdentityModel;
using System.IdentityModel.Tokens;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
using System.IdentityModel.Selectors;
using System.IdentityModel.Policy;
using System.IdentityModel.Claims;
using System.Runtime.Remoting;
using System.Security.Principal;
using System.Configuration;
using System.ServiceModel.Security.Tokens;
using System.Web;

namespace Microsoft.IdentityModel.Samples
{
    public class TokenHelper
    {
        private SamlSecurityToken m_token = null;
        private AuthorizationContext m_authorizationContext = null;
        private EndpointIdentity m_endpointIdentity = null;
        private ClaimSet m_identityClaims = null;

        public ClaimSet IdentityClaims
        {
            get { return m_identityClaims; }
            set { m_identityClaims = value; }
        }

        public TokenHelper(HttpRequest request, string tokenFieldName)
        {
            /*
            if (!request.IsSecureConnection)
                throw new Exception("Token must be passed via a secure connection");

            string host = request.Url.Host;
            // query IIS for certificate
            */

            throw new Exception("This constructor not supported yet.");
        }

        public TokenHelper(String xmlToken)
            : this(xmlToken, null)
        {
        }

        public TokenHelper(String xmlToken, string certificatesubject)
        {

            StoreName storeName = StoreName.My;
            StoreLocation storeLocation = StoreLocation.LocalMachine;
            X509Certificate2 cert = null;

            string rpCertificateSubject = System.Configuration.ConfigurationManager.AppSettings["CertificateSubject"];
            string rpStoreName = ConfigurationManager.AppSettings["StoreName"];
            string rpStoreLocation = ConfigurationManager.AppSettings["StoreLocation"];

            if (!string.IsNullOrEmpty(certificatesubject))
                rpCertificateSubject = certificatesubject;


            if (!string.IsNullOrEmpty(rpStoreName))
                storeName = (StoreName)Enum.Parse(typeof(StoreName), rpStoreName, true);

            if (!string.IsNullOrEmpty(rpStoreLocation))
                storeLocation = (StoreLocation)Enum.Parse(typeof(StoreLocation), rpStoreLocation, true);

            if (string.IsNullOrEmpty(rpCertificateSubject))
                throw new Exception("Relying Party Certificate Subject not specified");

            X509Store s = new X509Store(storeName, storeLocation);
            s.Open(OpenFlags.ReadOnly);

            foreach (X509Certificate2 xCert in s.Certificates)
            {
                if (xCert.Subject.StartsWith("CN=" + rpCertificateSubject, StringComparison.CurrentCultureIgnoreCase))
                {
                    if (cert == null)
                        cert = xCert;
                    else
                        throw new Exception(string.Format("There are more than one certificates matching CN={0}", rpCertificateSubject));
                }
            }

            if (cert == null)
                throw new Exception(string.Format("Relying Party Certificate ({0}) in {1}:{2} Not located", rpCertificateSubject, storeLocation.ToString(), storeName.ToString()));

            ParseToken(xmlToken, cert);

        }

        private void ParseToken(string xmlToken, X509Certificate2 cert)
        {
            int skew = 300; // default to 5 minutes
            string tokenskew = System.Configuration.ConfigurationManager.AppSettings["MaximumClockSkew"];
            if (!string.IsNullOrEmpty(tokenskew))
                skew = Int32.Parse(tokenskew);

            XmlReader tokenReader = new XmlTextReader(new StringReader(xmlToken));
            EncryptedData enc = new EncryptedData();

            enc.TokenSerializer = WSSecurityTokenSerializer.DefaultInstance;

            enc.ReadFrom(tokenReader);

            List<SecurityToken> tokens = new List<SecurityToken>();
            SecurityToken encryptingToken = new X509SecurityToken(cert);
            tokens.Add(encryptingToken);

            SecurityTokenResolver tokenResolver = SecurityTokenResolver.CreateDefaultSecurityTokenResolver(tokens.AsReadOnly(), false);
            SymmetricSecurityKey encryptingCrypto;

            // an error here usually means that you have selected the wrong key.
            encryptingCrypto = (SymmetricSecurityKey)tokenResolver.ResolveSecurityKey(enc.KeyIdentifier[0]);

            SymmetricAlgorithm algorithm = encryptingCrypto.GetSymmetricAlgorithm(enc.EncryptionMethod);

            byte[] decryptedData = enc.GetDecryptedBuffer(algorithm);

            SecurityTokenSerializer tokenSerializer = WSSecurityTokenSerializer.DefaultInstance;
            XmlReader reader = new XmlTextReader(new StreamReader(new MemoryStream(decryptedData), Encoding.UTF8));

            m_token = (SamlSecurityToken)tokenSerializer.ReadToken(reader, tokenResolver);


            SamlSecurityTokenAuthenticator authenticator = new SamlSecurityTokenAuthenticator(new List<SecurityTokenAuthenticator>(
                                                            new SecurityTokenAuthenticator[]{
                                                                new RsaSecurityTokenAuthenticator(),
                                                                new X509SecurityTokenAuthenticator() }), new TimeSpan(0, 0, skew));


            if (authenticator.CanValidateToken(m_token))
            {
                ReadOnlyCollection<IAuthorizationPolicy> policies = authenticator.ValidateToken(m_token);
                m_authorizationContext = AuthorizationContext.CreateDefaultAuthorizationContext(policies);
                m_identityClaims = FindIdentityClaims(m_authorizationContext);
            }
            else
            {
                throw new Exception("Unable to validate the token.");
            }
        }

        private EndpointIdentity CreateIdentityFromClaimSet(ClaimSet claims)
        {
            foreach (Claim claim in claims.FindClaims(null, Rights.Identity))
            {
                return EndpointIdentity.CreateIdentity(claim);
            }
            return null;
        }

        public string GetClaim(string claimUri)
        {
            foreach (Claim claim in m_identityClaims.FindClaims(claimUri, Rights.PossessProperty))
            {
                return GetResourceValue(claim);
            }
            throw new ArgumentException(String.Format("Claim {0} not found", claimUri));
        }

        public ClaimSet FindIdentityClaims(AuthorizationContext authContext)
        {
            // Pick up the claim type to use for generating the UniqueID claim
            string identificationClaimType = System.Configuration.ConfigurationManager.AppSettings["IdentityClaimType"];

            // Or, default to PPID
            if (string.IsNullOrEmpty(identificationClaimType))
                identificationClaimType = System.IdentityModel.Claims.ClaimTypes.PPID;

            ClaimSet result = null;
            m_endpointIdentity = null;

            foreach (ClaimSet claimSet in authContext.ClaimSets)
            {
                //
                // This loops through the claims looking for the configured claim type
                // that will be used as part of the generation of the unique id.
                //
                foreach (Claim claim in claimSet.FindClaims(identificationClaimType, Rights.PossessProperty))
                {
                    // found a matching claim. This is good.
                    EndpointIdentity issuerId = CreateIdentityFromClaimSet(claimSet.Issuer);
                    byte[] issuerkey;

                    // we need to get a byte array that represents the issuer's key
                    // to use as part of the hash to generate a unique id. 
                    // currently supported: (byte[]) or an RSACryptoServiceProvider,
                    // This could be expanded to support other types. The key just 
                    // needs to be extracted as a byte array.
                    issuerkey = issuerId.IdentityClaim.Resource as byte[];
                    if (null == issuerkey)
                    {
                        RSACryptoServiceProvider csp = issuerId.IdentityClaim.Resource as RSACryptoServiceProvider;
                        if (null != csp)
                            issuerkey = csp.ExportCspBlob(false);

                        // Can't use this claim to get the key.
                        if (null == issuerkey)
                            throw new Exception("Unsupported IdentityClaim resource type");
                    }

                    // It doesn't matter what encoding type we use, as long as it is consistent.
                    // this conversion is just to get a consistent set of bytes from the claim.
                    byte[] uniqueClaim = Encoding.UTF8.GetBytes(GetResourceValue(claim));

                    // copy the thumbprint data and the uniqueClaim together.
                    byte[] thumbprintData = new byte[uniqueClaim.Length + issuerkey.Length];
                    issuerkey.CopyTo(thumbprintData, 0);
                    uniqueClaim.CopyTo(thumbprintData, issuerkey.Length);

                    // generate a hash.
                    using (SHA256 sha = new SHA256Managed())
                    {
                        Claim thumbprintClaim = new Claim(ClaimTypes.Thumbprint, Convert.ToBase64String(sha.ComputeHash(thumbprintData)), Rights.Identity);
                        m_endpointIdentity = EndpointIdentity.CreateIdentity(thumbprintClaim);
                    }

                    return claimSet;
                }


                if (null == m_endpointIdentity)
                {
                    //
                    // check for identity claim, if found, hold on to it, we may need to use it :)
                    //
                    result = claimSet;
                    m_endpointIdentity = CreateIdentityFromClaimSet(claimSet);
                }
            }

            if (null != m_endpointIdentity)
            {
                return result;
            }

            //
            // we have looped all claim sets with out finding an identity claim.
            // we will return the ppidIdentity and claimset if they were found.
            //
            throw new Exception("The XML Token data provided no Identity claim.");
        }

        public string GetUniqueID()
        {
            return GetResourceValue(m_endpointIdentity.IdentityClaim);
        }


        public static string GetResourceValue(Claim claim)
        {
            IdentityReference reference = claim.Resource as IdentityReference;
            if (null != reference)
            {
                return reference.Value;
            }

            ICspAsymmetricAlgorithm rsa = claim.Resource as ICspAsymmetricAlgorithm;
            if (null != rsa)
            {
                using (SHA256 sha = new SHA256Managed())
                {
                    return Convert.ToBase64String(sha.ComputeHash(rsa.ExportCspBlob(false)));
                }
            }

            System.Net.Mail.MailAddress mail = claim.Resource as System.Net.Mail.MailAddress;
            if (null != mail)
            {
                return mail.ToString();
            }

            byte[] bufferValue = claim.Resource as byte[];
            if (null != bufferValue)
            {
                return Convert.ToBase64String(bufferValue);
            }

            return claim.Resource.ToString();
        }
    }
    /// <summary>
    /// Utility class to help encyrpt and decrypt XML.. Copied from
    /// ddsuites\src\indigo\Suites\Security\Federation\Cases
    /// </summary>
    public class EncryptedData
    {
        static class XmlEncryptionStrings
        {
            public const string Namespace = "http://www.w3.org/2001/04/xmlenc#";
            public const string Prefix = "e";
            public const string EncryptedData = "EncryptedData";
            public const string EncryptionMethod = "EncryptionMethod";
            public const string CipherData = "CipherData";
            public const string CipherValue = "CipherValue";
            public const string Encoding = "Encoding";
            public const string MimeType = "MimeType";
            public const string Type = "Type";
            public const string Id = "Id";
            public const string Algorithm = "Algorithm";
        }

        string m_id;
        string m_type;
        EncryptionMethodElement m_encryptionMethod;
        CipherData m_cipherData;
        SecurityKeyIdentifier m_keyIdentifier;
        SecurityTokenSerializer m_tokenSerializer;

        public EncryptedData()
        {
            this.m_cipherData = new CipherData();
            this.m_encryptionMethod = new EncryptionMethodElement();
        }

        public string EncryptionMethod
        {
            set
            {
                this.m_encryptionMethod.algorithm = value;
            }
            get
            {
                return this.m_encryptionMethod.algorithm;
            }
        }

        public string Id
        {
            get
            {
                return this.m_id;
            }
            set
            {
                this.m_id = value;
            }
        }

        public SecurityKeyIdentifier KeyIdentifier
        {
            set
            {
                this.m_keyIdentifier = value;
            }
            get
            {
                return this.m_keyIdentifier;
            }
        }

        public string Type
        {
            set
            {
                this.m_type = value;
            }
            get
            {
                return this.m_type;
            }
        }

        public SecurityTokenSerializer TokenSerializer
        {
            set
            {
                this.m_tokenSerializer = value;
            }
            get
            {
                return this.m_tokenSerializer;
            }
        }

        public byte[] GetDecryptedBuffer(SymmetricAlgorithm algorithm)
        {
            byte[] cipherText = this.m_cipherData.CipherValue;
            return ExtractIVAndDecrypt(algorithm, cipherText, 0, cipherText.Length);
        }

        //
        // Summary
        //   Set up the encryption
        //
        // Parameters
        //  algorithm - The symmetric algorithm to use.
        //  buffer -    Data to encrypt
        //  offset -    The offset into the byte array from which to begin using data.
        //  length -    The number of bytes in the byte array to use as data.
        //
        public void SetUpEncryption(SymmetricAlgorithm algorithm, byte[] buffer, int offset, int length)
        {
            byte[] iv;
            byte[] cipherText;
            GenerateIVAndEncrypt(algorithm, buffer, offset, length, out iv, out cipherText);
            this.m_cipherData.SetCipherValueFragments(iv, cipherText);
        }

        public void ReadFrom(XmlReader reader)
        {
            if (!reader.IsStartElement(XmlEncryptionStrings.EncryptedData, XmlEncryptionStrings.Namespace))
                throw new InvalidOperationException();

            this.m_id = reader.GetAttribute(XmlEncryptionStrings.Id, null);
            this.m_type = reader.GetAttribute(XmlEncryptionStrings.Type, null);
            reader.Read();

            if (reader.IsStartElement(XmlEncryptionStrings.EncryptionMethod, XmlEncryptionStrings.Namespace))
                this.m_encryptionMethod.ReadFrom(reader);
            if (m_tokenSerializer.CanReadKeyIdentifier(reader))
                this.m_keyIdentifier = m_tokenSerializer.ReadKeyIdentifier(reader);
            this.m_cipherData.ReadFrom(reader);
            reader.ReadEndElement(); // EncryptedData
        }

        //
        // Summary
        //   Write the encrypted data to a writer
        // 
        // Parameters
        //   writer - The XmlWriter to which the encrypted data object is written.
        //
        public void WriteTo(XmlWriter writer)
        {
            writer.WriteStartElement(XmlEncryptionStrings.Prefix, XmlEncryptionStrings.EncryptedData, XmlEncryptionStrings.Namespace);
            if (!String.IsNullOrEmpty(this.m_id))
                writer.WriteAttributeString(XmlEncryptionStrings.Id, null, this.m_id);
            if (!String.IsNullOrEmpty(this.m_type))
                writer.WriteAttributeString(XmlEncryptionStrings.Type, null, this.m_type);
            if (!String.IsNullOrEmpty(this.m_encryptionMethod.algorithm))
                this.m_encryptionMethod.WriteTo(writer);
            if (this.m_keyIdentifier != null)
                m_tokenSerializer.WriteKeyIdentifier(XmlDictionaryWriter.CreateDictionaryWriter(writer), this.m_keyIdentifier);
            this.m_cipherData.WriteTo(writer);
            writer.WriteEndElement(); // EncryptedData
        }

        byte[] ExtractIVAndDecrypt(SymmetricAlgorithm algorithm, byte[] cipherText, int offset, int count)
        {
            int ivSize = algorithm.BlockSize / 8;
            byte[] iv = new byte[ivSize];
            Buffer.BlockCopy(cipherText, offset, iv, 0, iv.Length);
            algorithm.Padding = PaddingMode.ISO10126;
            algorithm.Mode = CipherMode.CBC;
            ICryptoTransform decrTransform = algorithm.CreateDecryptor(algorithm.Key, iv);
            byte[] plainText = decrTransform.TransformFinalBlock(cipherText, offset + iv.Length, count - iv.Length);
            decrTransform.Dispose();
            return plainText;
        }

        //
        // Summary
        //   Generate the IV and encrypt the data
        //
        // Parameters
        //  algorithm - The symmetric algorithm to use.
        //  plainText -  The input for which to compute the transform.
        //  offset -    The offset into the byte array from which to begin using data.
        //  length -    The number of bytes in the byte array to use as data.
        //  iv -        The IV value returned.
        //  cipherText - The cipher text returned.
        //
        void GenerateIVAndEncrypt(SymmetricAlgorithm algorithm, byte[] plainText, int offset, int length, out byte[] iv, out byte[] cipherText)
        {
            RandomNumberGenerator random = new RNGCryptoServiceProvider();
            int ivSize = algorithm.BlockSize / 8;
            iv = new byte[ivSize];
            random.GetBytes(iv);
            algorithm.Padding = PaddingMode.PKCS7;
            algorithm.Mode = CipherMode.CBC;

            using (ICryptoTransform encrTransform = algorithm.CreateEncryptor(algorithm.Key, iv))
            {
                cipherText = encrTransform.TransformFinalBlock(plainText, offset, length);
            }
        }


        //
        // Summary
        //  Cipher data struct to be used to encrypt the token
        //
        struct CipherData
        {
            byte[] m_iv;
            byte[] m_cipherText;

            public byte[] CipherValue
            {
                get
                {
                    if (m_iv != null)
                    {
                        byte[] buffer = new byte[m_iv.Length + m_cipherText.Length];
                        Buffer.BlockCopy(m_iv, 0, buffer, 0, m_iv.Length);
                        Buffer.BlockCopy(m_cipherText, 0, buffer, m_iv.Length, m_cipherText.Length);
                        this.m_iv = null;
                    }

                    return this.m_cipherText;
                }
                set
                {
                    this.m_cipherText = value;
                }
            }

            public void ReadFrom(XmlReader reader)
            {
                reader.ReadStartElement(XmlEncryptionStrings.CipherData, XmlEncryptionStrings.Namespace);
                reader.ReadStartElement(XmlEncryptionStrings.CipherValue, XmlEncryptionStrings.Namespace);
                this.m_cipherText = Convert.FromBase64String(reader.ReadString());
                this.m_iv = null;
                reader.ReadEndElement(); // CipherValue
                reader.ReadEndElement(); // CipherData
            }

            public void SetCipherValueFragments(byte[] iv, byte[] cipherText)
            {
                this.m_iv = iv;
                this.m_cipherText = cipherText;
            }

            public void WriteTo(XmlWriter writer)
            {
                writer.WriteStartElement(XmlEncryptionStrings.Prefix, XmlEncryptionStrings.CipherData, XmlEncryptionStrings.Namespace);
                writer.WriteStartElement(XmlEncryptionStrings.Prefix, XmlEncryptionStrings.CipherValue, XmlEncryptionStrings.Namespace);

                if (this.m_iv != null)
                    writer.WriteBase64(this.m_iv, 0, this.m_iv.Length);

                writer.WriteBase64(this.m_cipherText, 0, this.m_cipherText.Length);
                writer.WriteEndElement(); // CipherValue
                writer.WriteEndElement(); // CipherData
            }
        }

        struct EncryptionMethodElement
        {
            internal string algorithm;

            public void ReadFrom(XmlReader reader)
            {
                if (!reader.IsStartElement(XmlEncryptionStrings.EncryptionMethod, XmlEncryptionStrings.Namespace))
                    throw new Exception();
                bool isEmptyElement = reader.IsEmptyElement;
                this.algorithm = reader.GetAttribute(XmlEncryptionStrings.Algorithm, null);
                reader.Read();
                if (!isEmptyElement)
                {
                    while (reader.IsStartElement())
                    {
                        reader.Skip();
                    }
                    reader.ReadEndElement();
                }
            }

            public void WriteTo(XmlWriter writer)
            {
                writer.WriteStartElement(XmlEncryptionStrings.Prefix, XmlEncryptionStrings.EncryptionMethod, XmlEncryptionStrings.Namespace);
                writer.WriteAttributeString(XmlEncryptionStrings.Algorithm, null, this.algorithm);
                writer.WriteEndElement(); // EncryptionMethod
            }
        }
    }
}
