using System;
using System.Collections.Generic;
using System.Text;

using System.IdentityModel.Selectors;
using System.ServiceModel;
using System.Xml;
using System.IO;
namespace BeginningCardSpace
{
    public class CardspacePolicyInfo
    {
        string _identityProvider;
        string _certificate;
        string _relyingParty;

        
        List<string> _requiredClaims;

        public string IdentityProvider
        {
            get { return _identityProvider; }
            set { _identityProvider = value; }
        
        }
        public string Certificate
        {
            get { return _certificate; }
            set { _certificate = value; }
        
        }
        public string RelyingParty
        {
            get { return _relyingParty; }
            set { _relyingParty = value; }
        
        }
        public List<string> RequiredClaims
        {
            get { return _requiredClaims; }
            set { _requiredClaims = value; }
        }



        public override bool Equals(object obj)
        {
            if (obj != null)
            {
                if (obj.GetType() == this.GetType())
                {
                    CardspacePolicyInfo policyToCompare = (CardspacePolicyInfo)obj;
                    bool includesAllClaims = true;
                    foreach (string claim in policyToCompare.RequiredClaims)
                    {
                        if (!this.RequiredClaims.Contains(claim))
                        {
                            includesAllClaims = false;
                            
                        }
                    }

                    return (policyToCompare.IdentityProvider == this.IdentityProvider &&
                            policyToCompare.RelyingParty == this.RelyingParty &&
                            policyToCompare.Certificate == this.Certificate &&
                            includesAllClaims);
                
                
                }
                else
                {
                    return false;
                }

            }
            else
            {
                return false;
            
            }
        
        }
        public override int GetHashCode()
        {
            return (_identityProvider == null ? _relyingParty.GetHashCode() ^ _certificate.GetHashCode()  :
                    _relyingParty.GetHashCode() ^ _certificate.GetHashCode() ^ _identityProvider.GetHashCode() );
        }
        public CardspacePolicyInfo(CardSpacePolicyElement[] policyElements)
        {

            _requiredClaims = new List<string>();

            if (policyElements.Length > 0)
            {
                System.IO.TextReader tr = new System.IO.StringReader(policyElements[0].Target.OuterXml.ToString());
                XmlTextReader xmltr = new XmlTextReader(tr);
                XmlDictionaryReader xmldr = XmlDictionaryReader.CreateDictionaryReader(xmltr);
                EndpointAddress endpointAddress = EndpointAddress.ReadFrom(xmldr);
                _relyingParty = endpointAddress.Uri.Host;
                foreach (XmlElement xmlPolicyElement in policyElements[0].Parameters)
                {
                    if (xmlPolicyElement.Name == "t:Claims")
                    {
                        XmlNode claimsNode = xmlPolicyElement;
                        foreach (XmlNode claimNode in claimsNode.ChildNodes)
                        { 
                            _requiredClaims.Add(claimNode.Attributes["Uri"].Value);
                        
                        }
                    }
                
                }
                X509CertificateEndpointIdentity endpointIdentity = (X509CertificateEndpointIdentity)endpointAddress.Identity;
                _certificate = endpointIdentity.Certificates[0].GetCertHashString();
                

                if (policyElements[0].Issuer != null)
                {
                    tr = new System.IO.StringReader(policyElements[0].Issuer.OuterXml.ToString());
                    xmltr = new XmlTextReader(tr);
                    xmldr = XmlDictionaryReader.CreateDictionaryReader(xmltr);
                    endpointAddress = EndpointAddress.ReadFrom(xmldr);
                    _identityProvider = endpointAddress.Uri.ToString();
                }
                
                
  
            
            
            }
        
        
        
        }

    
    }
}
