using System;
using System.Collections.Generic;
using System.Text;
using ServiceContracts;
using Rss;
using System.ServiceModel;
using System.IdentityModel.Claims;
using System.IdentityModel.Policy;
namespace Services
{
   
    public class RSSService : IRSSService
    {

        #region IRSSService Members
      
        public Rss.RssFeed GetFeed()
        {
            string locality = "";
            string country = "";
            string givenname = "";
            string surname = "";
            AuthorizationContext ctx = OperationContext.Current.ServiceSecurityContext.AuthorizationContext;


            foreach (ClaimSet claimSet in ctx.ClaimSets)
            {
                foreach (Claim claim in claimSet)
                {

                    if (claim.ClaimType == ClaimTypes.Locality)
                    { locality = claim.Resource.ToString(); }
                    if (claim.ClaimType == ClaimTypes.Country)
                    { country = claim.Resource.ToString(); }
                    if (claim.ClaimType == ClaimTypes.GivenName)
                    { givenname = claim.Resource.ToString(); }
                    if (claim.ClaimType == ClaimTypes.Surname)
                    { surname = claim.Resource.ToString(); }

                }

            }
            
           

            string feedUri = "http://www.marcmercuri.com/SyndicationService.asmx/GetRss";
            Rss.RssFeed feed = new RssFeed(new Uri(feedUri));
            
            return feed;
        }

        #endregion
    }
}
