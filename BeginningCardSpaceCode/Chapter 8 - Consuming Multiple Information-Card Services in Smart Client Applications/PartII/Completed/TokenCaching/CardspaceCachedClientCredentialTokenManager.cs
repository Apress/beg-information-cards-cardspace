using System;
using System.Collections.Generic;
using System.Text;
using System.ServiceModel;
using System.IdentityModel.Tokens;

namespace UnderstandingCardspace
{
    class CardspaceCachedClientCredentialTokenManager: ClientCredentialsSecurityTokenManager
    {

            Dictionary<CardspacePolicyInfo, SecurityToken> _cachedInformationCardTokens;

            public CardspaceCachedClientCredentialTokenManager(CachedInformationCardClientCredentials clientCredentials)
                : base(clientCredentials)
            {
                this._cachedInformationCardTokens = clientCredentials.CachedInformationCardTokens;
            }
        }

    
}

