using System;
using System.Collections.Generic;
using System.Text;
using System.ServiceModel.Configuration;
namespace UnderstandingCardspace
{

    public class CachedInformationCardClientCredentialsConfigHandler : ClientCredentialsElement
        {

            public override Type BehaviorType
            {
                get { return typeof(CachedInformationCardClientCredentials); }
            }

            protected override object CreateBehavior()
            {
                CachedInformationCardClientCredentials cachedInformationCardClientCredentials = new CachedInformationCardClientCredentials();
                base.ApplyConfiguration(cachedInformationCardClientCredentials);
                return cachedInformationCardClientCredentials;
            }
        }
    }
