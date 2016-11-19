using System;
using System.Collections.Generic;
using System.Text;
using System.IdentityModel.Claims;
using System.ServiceModel.Description;
using System.ServiceModel;
using System.Xml;
using System.IO;
using System.Drawing;
using System.ServiceModel.Channels;
using System.Runtime.Serialization;
using System.Security.Cryptography.Xml;
using System.Security.Cryptography.X509Certificates;

namespace BeginningCardSpace
{
    public class ManagedCardHelper
    {


        
    

        public ManagedCardHelper()
        {

           
        
        
        }

        public static X509Certificate2 RetrieveCertificate(string certificateLocation)
        {
            StoreName storeName = StoreName.My;
            StoreLocation storeLocation = StoreLocation.LocalMachine;
            X509Certificate2 certificate = new X509Certificate2();
            //load from store
            string[] splitCert = certificateLocation.Split("/".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
            try
            {
                storeLocation = (StoreLocation)Enum.Parse(typeof(StoreLocation), splitCert[0], true);
            }
            catch (Exception)
            {
                throw new Exception("No Certificate Location: " + splitCert[0]);
            }
            try
            {
                storeName = (StoreName)Enum.Parse(typeof(StoreName), splitCert[1], true);
            }
            catch (Exception)
            {
                throw new Exception("No Certificate Store: " + splitCert[1] + " in " + splitCert[0]);
            }

            X509Store s = new X509Store(storeName, storeLocation);
            s.Open(OpenFlags.MaxAllowed);
            foreach (X509Certificate2 xCert in s.Certificates)
            {
                if (xCert.Subject.StartsWith("CN=" + splitCert[2]))
                {
                    certificate = xCert;
                    break;
                }


            }
            return certificate;
        
        
        }

        public static void SaveCard( InformationCard card, X509Certificate2 cert, string filename)
        {

            MemoryStream stream = new MemoryStream();
            XmlWriter writer = XmlWriter.Create( stream );

            writer.WriteStartElement( "InformationCard", "http://schemas.xmlsoap.org/ws/2005/05/identity");


            writer.WriteAttributeString("lang", "http://www.w3.org/XML/1998/namespace", "en-US");
            writer.WriteStartElement("InformationCardReference", "http://schemas.xmlsoap.org/ws/2005/05/identity");
            writer.WriteElementString("CardId", "http://schemas.xmlsoap.org/ws/2005/05/identity", card.CardReference.CardID);
            writer.WriteElementString("CardVersion", "http://schemas.xmlsoap.org/ws/2005/05/identity", card.CardReference.CardVersion.ToString());
            writer.WriteEndElement();

            if( card.CardName != null && card.CardName.Length >0 )
            {
                writer.WriteStartElement("CardName", "http://schemas.xmlsoap.org/ws/2005/05/identity");
                writer.WriteString( card.CardName );
                writer.WriteEndElement();
            }



            if( card.CardImage != null && card.CardImage.ImageName.Length > 0  )
            {
                writer.WriteStartElement("CardImage", "http://schemas.xmlsoap.org/ws/2005/05/identity");
                if( card.CardImage != null && card.CardImage.ImageMimeType != null && card.CardImage.ImageMimeType.Length >0 )
                {
                    writer.WriteAttributeString( "MimeType", card.CardImage.ImageMimeType );
                }

                FileInfo cardImage = new FileInfo(card.CardImage.ImageName);
                if (cardImage.Exists)
                {
                    byte[] cardImageBytes = new byte[cardImage.Length];
                    using (FileStream imageFS = cardImage.OpenRead())
                    {
                        imageFS.Read(cardImageBytes, 0, cardImageBytes.Length);
                    }
                
               
                string imageBase64 = Convert.ToBase64String( cardImageBytes);
                writer.WriteString(imageBase64 );
                writer.WriteEndElement();
             }
                }

       
            writer.WriteStartElement("Issuer", "http://schemas.xmlsoap.org/ws/2005/05/identity");
            writer.WriteString( card.Issuer );
            writer.WriteEndElement();

            //writer.WriteStartElement("IssuerName", "http://schemas.xmlsoap.org/ws/2005/05/identity");
            //writer.WriteString(card.IssuerName);
            //writer.WriteEndElement();

            writer.WriteStartElement("TimeIssued", "http://schemas.xmlsoap.org/ws/2005/05/identity");
            writer.WriteString( XmlConvert.ToString( card.TimeIssued, XmlDateTimeSerializationMode.Utc ) );
            writer.WriteEndElement();

         
            writer.WriteStartElement("TimeExpires", "http://schemas.xmlsoap.org/ws/2005/05/identity");
            writer.WriteString( XmlConvert.ToString( card.TimeExpires, XmlDateTimeSerializationMode.Utc ) );
            writer.WriteEndElement();

           
            writer.WriteStartElement("TokenServiceList", "http://schemas.xmlsoap.org/ws/2005/05/identity");

            
            foreach(TokenService ts in card.TokenServiceList)
            {
                    EndpointAddressBuilder endpointBuilder = new EndpointAddressBuilder();

                    endpointBuilder.Uri = new Uri(ts.EndpointReference.Address);

                    endpointBuilder.Identity = new X509CertificateEndpointIdentity(RetrieveCertificate(ts.EndpointReference.Identity));

                    if (null != ts.EndpointReference.Mex)
                    {

                        MetadataReference mexReference = new MetadataReference();
                        mexReference.Address = new EndpointAddress(ts.EndpointReference.Mex);
                        mexReference.AddressVersion = AddressingVersion.WSAddressing10;

                        MetadataSection mexSection = new MetadataSection();
                        mexSection.Metadata = mexReference;

                        MetadataSet mexSet = new MetadataSet();
                        mexSet.MetadataSections.Add(mexSection);


                        MemoryStream mexMemoryStream = new MemoryStream();

                        XmlTextWriter mexWriter = new XmlTextWriter(mexMemoryStream, System.Text.Encoding.UTF8);

                        mexSet.WriteTo(mexWriter);

                        mexWriter.Flush();

                        mexMemoryStream.Seek(0, SeekOrigin.Begin);

                        XmlDictionaryReader reader = XmlDictionaryReader.CreateTextReader(mexMemoryStream, XmlDictionaryReaderQuotas.Max);

                        endpointBuilder.SetMetadataReader(reader);


                        writer.WriteStartElement("TokenService", "http://schemas.xmlsoap.org/ws/2005/05/identity");
                        EndpointAddress endpoint = endpointBuilder.ToEndpointAddress();
                        endpoint.WriteTo(AddressingVersion.WSAddressing10, writer);

                        writer.WriteStartElement("UserCredential", "http://schemas.xmlsoap.org/ws/2005/05/identity");


                        if (ts.UserCredential.DisplayCredentialHint != null && ts.UserCredential.DisplayCredentialHint.Length > 0)
                        {
                            writer.WriteStartElement("DisplayCredentialHint", "http://schemas.xmlsoap.org/ws/2005/05/identity");
                            writer.WriteString(ts.UserCredential.DisplayCredentialHint);
                            writer.WriteEndElement();
                        }

                        switch (ts.UserCredential.UserCredentialType)
                        {
                            case CredentialType.UsernameAndPassword:
                                writer.WriteStartElement("UsernamePasswordCredential", "http://schemas.xmlsoap.org/ws/2005/05/identity");
                                if (!string.IsNullOrEmpty(ts.UserCredential.Value))
                                {
                                    writer.WriteStartElement("Username", "http://schemas.xmlsoap.org/ws/2005/05/identity");
                                    writer.WriteString(ts.UserCredential.Value);
                                    writer.WriteEndElement();
                                }
                                writer.WriteEndElement();
                                break;
                            case CredentialType.Kerberos:
                                writer.WriteStartElement("KerberosV5Credential", "http://schemas.xmlsoap.org/ws/2005/05/identity");
                                writer.WriteEndElement();
                                break;

                            case CredentialType.SmartCard:
                                writer.WriteStartElement("X509V3Credential", "http://schemas.xmlsoap.org/ws/2005/05/identity");

                                writer.WriteStartElement("X509Data", "http://www.w3.org/2000/09/xmldsig#");
                                if (!string.IsNullOrEmpty(ts.UserCredential.Value))
                                {
                                    writer.WriteStartElement("KeyIdentifier", "http://docs.oasis-open.org/wss/2004/01/oasis-200401-wss-wssecurity-secext-1.0.xsd");
                                    writer.WriteAttributeString("ValueType",
                                                     null,
                                                     "http://docs.oasis-open.org/wss/2004/xx/oasis-2004xx-wss-soap-message-security-1.1#ThumbprintSHA1");
                                    writer.WriteString(RetrieveCertificate(ts.UserCredential.Value).Thumbprint);
                                    writer.WriteEndElement();
                                }
                                else
                                {
                                    throw new InvalidDataException("No thumbprint was specified");
                                }
                                writer.WriteEndElement();
                                writer.WriteEndElement();
                                break;
                            default:
                                break;
                        }
                        writer.WriteEndElement();
                        writer.WriteEndElement();
                    }
                }
                writer.WriteEndElement(); //end of tokenservice list
            //
            // tokentypes
            //
            writer.WriteStartElement("SupportedTokenTypeList", "http://schemas.xmlsoap.org/ws/2005/05/identity");
            foreach( TokenType tokenType in card.AcceptedTokenTypes )
            {
                writer.WriteElementString( "TokenType",
                                           "http://schemas.xmlsoap.org/ws/2005/02/trust",
                                           tokenType.Uri );
            }
            writer.WriteEndElement();

            //
            // claims
            //
            writer.WriteStartElement("SupportedClaimTypeList", "http://schemas.xmlsoap.org/ws/2005/05/identity");
            foreach( CardClaim claim in card.SupportedClaimTypeList )
            {

                writer.WriteStartElement("SupportedClaimType", "http://schemas.xmlsoap.org/ws/2005/05/identity");
                writer.WriteAttributeString("Uri", claim.Uri);

                
                if( !String.IsNullOrEmpty( claim.DisplayTag ) )
                {
                    writer.WriteElementString("DisplayTag", "http://schemas.xmlsoap.org/ws/2005/05/identity",
                                                   claim.DisplayTag);
                }

                if( !String.IsNullOrEmpty( claim.Description ) )
                {
                    writer.WriteElementString("Description", "http://schemas.xmlsoap.org/ws/2005/05/identity",
                                               claim.Description);
                }
                writer.WriteEndElement();

            }
            writer.WriteEndElement();

         
            if( card.RequireRPIdentification )
            {
                writer.WriteElementString("RequireAppliesTo", "http://schemas.xmlsoap.org/ws/2005/05/identity", card.RequireRPIdentification.ToString());
            }

          
            if( !String.IsNullOrEmpty( card.PrivacyNotice ) )
            {
                writer.WriteStartElement("PrivacyNotice", "http://schemas.xmlsoap.org/ws/2005/05/identity");
                writer.WriteString(card.PrivacyNotice);
                writer.WriteEndElement();
            }
            writer.WriteEndElement();

            writer.Close();




            stream.Position = 0;

            XmlDocument doc = new XmlDocument();
            doc.PreserveWhitespace = false;
            doc.Load(stream);

            SignedXml signed = new SignedXml();
            signed.SigningKey = cert.PrivateKey;
            signed.Signature.SignedInfo.CanonicalizationMethod = SignedXml.XmlDsigExcC14NTransformUrl;

            Reference reference = new Reference();
            reference.Uri = "#_Object_InfoCard";
            reference.AddTransform(
                        new XmlDsigExcC14NTransform());
            signed.AddReference(reference);


            KeyInfo info = new KeyInfo();
            KeyInfoX509Data certData = new KeyInfoX509Data(cert, X509IncludeOption.WholeChain);
            info.AddClause(certData);

            signed.KeyInfo = info;
            DataObject cardData = new DataObject("_Object_InfoCard", null, null, doc.DocumentElement);
            signed.AddObject(cardData);

            signed.ComputeSignature();

            XmlElement e = signed.GetXml();

            XmlTextWriter fileWriter = new XmlTextWriter(filename, Encoding.UTF8);
            e.WriteTo(fileWriter);
            //doc.WriteTo(fileWriter); //Added
            fileWriter.Flush();
            fileWriter.Close();
       }



   



        public static List<CardClaim> GetStandardClaims()
        {

            List<CardClaim> StandardClaims = new List<CardClaim>();
            StandardClaims.Add(new CardClaim(ClaimTypes.GivenName, "Given Name", "Given Name"));
            StandardClaims.Add(new CardClaim(ClaimTypes.Surname, "Last Name", "Last Name"));
            StandardClaims.Add(new CardClaim(ClaimTypes.Email, "Email Address", "Email Address"));
            StandardClaims.Add(new CardClaim(ClaimTypes.StreetAddress, "Street Address", "Street Address"));
            StandardClaims.Add(new CardClaim(ClaimTypes.Locality, "Locality", "Locality"));
            StandardClaims.Add(new CardClaim(ClaimTypes.StateOrProvince, "State or Province", "State or Province"));
            StandardClaims.Add(new CardClaim(ClaimTypes.PostalCode, "Postal Code", "Postal Code"));
            StandardClaims.Add(new CardClaim(ClaimTypes.Country, "Country", "Country"));
            StandardClaims.Add(new CardClaim(ClaimTypes.HomePhone, "Home Phone", "Home Phone"));
            StandardClaims.Add(new CardClaim(ClaimTypes.OtherPhone, "Other Phone", "Other Phone"));
            StandardClaims.Add(new CardClaim(ClaimTypes.MobilePhone, "Mobile Phone", "Mobile Phone"));
            StandardClaims.Add(new CardClaim(ClaimTypes.Gender, "Gender", "Gender"));
            StandardClaims.Add(new CardClaim(ClaimTypes.DateOfBirth, "Date of Birth", "Date of Birth"));
            StandardClaims.Add(new CardClaim(ClaimTypes.PPID, "Site Specific ID", "Site Specific ID"));
            StandardClaims.Add(new CardClaim(ClaimTypes.Webpage, "Webpage", "Webpage"));
            return StandardClaims;

        }

    }
}
