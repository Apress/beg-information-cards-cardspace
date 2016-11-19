using System;
using System.Collections.Generic;
using System.Text;

using System.Security.Permissions;
using System.ServiceModel;
using System.ServiceModel.Description;
using System.ServiceModel.Security.Tokens;
using System.IdentityModel.Tokens;
using System.IdentityModel.Selectors;

namespace BeginningCardSpace
{
    public class CachedInformationCardClientCredentials: ClientCredentials
    {
        //-----------------------------------------
        //storage for the cached credentials
        //-----------------------------------------
        static Dictionary<CardspacePolicyInfo, SecurityToken> _cachedInformationCardTokens;
        
        
        public Dictionary<CardspacePolicyInfo, SecurityToken> CachedInformationCardTokens
        {
            get
            {
                return _cachedInformationCardTokens;
            }
            set
            {
                _cachedInformationCardTokens = value;
            }
        }
        //-----------------------------------------

        //-----------------------------------------
        // Constructors
        //-----------------------------------------
        protected override SecurityToken GetInfoCardSecurityToken(bool requiresInfoCard, System.IdentityModel.Selectors.CardSpacePolicyElement[] chain, System.IdentityModel.Selectors.SecurityTokenSerializer tokenSerializer)
        {
            
            CardspacePolicyInfo policyInfo = new CardspacePolicyInfo(chain);
            TimeZone localTimeZone = TimeZone.CurrentTimeZone;

            if (    //Does the cache contain a token with the specified policy info?
                    _cachedInformationCardTokens.ContainsKey(policyInfo) &&
                   //Is the token is still valid?
                    localTimeZone.ToLocalTime(_cachedInformationCardTokens[policyInfo].ValidFrom) < DateTime.Now &&
                    localTimeZone.ToLocalTime(_cachedInformationCardTokens[policyInfo].ValidTo) > DateTime.Now
               )
             {

                 return CachedInformationCardTokens[policyInfo];

             }
             else
             {
                 lock (CachedInformationCardTokens)
                    {
                        
                        SecurityToken newInformationCardToken =  base.GetInfoCardSecurityToken(requiresInfoCard, chain, tokenSerializer);
                        CachedInformationCardTokens.Add(policyInfo, newInformationCardToken);
                        return newInformationCardToken;
                    
                    }
              }
            

        }

        public CachedInformationCardClientCredentials()
            : base()
        {
            if (_cachedInformationCardTokens == null)
            {
                _cachedInformationCardTokens = new Dictionary<CardspacePolicyInfo, SecurityToken>();
            }
        }

        CachedInformationCardClientCredentials(CachedInformationCardClientCredentials existingCachedInformationCardClientCredentials, Dictionary<CardspacePolicyInfo, SecurityToken> cachedInformationCardTokens)
            : base(existingCachedInformationCardClientCredentials)
        {
            _cachedInformationCardTokens = cachedInformationCardTokens;
        }

        CachedInformationCardClientCredentials(CachedInformationCardClientCredentials existingCachedInformationCardClientCredentials)
            : base(existingCachedInformationCardClientCredentials)
        {
        }

        
        protected override  ClientCredentials CloneCore()
        {
            return new CachedInformationCardClientCredentials(this);
        }

        public override SecurityTokenManager CreateSecurityTokenManager()
        {
            return new CardspaceCachedClientCredentialTokenManager((CachedInformationCardClientCredentials)this.Clone());
        }

     

      
    }
}
