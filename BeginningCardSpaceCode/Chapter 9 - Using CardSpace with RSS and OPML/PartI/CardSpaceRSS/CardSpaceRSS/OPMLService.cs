using System;
using System.Collections.Generic;
using System.Text;
using ServiceContracts;
using System.ServiceModel;
using Rss;
using System.IdentityModel.Claims;
using System.IdentityModel.Policy;
namespace Services
{
  
    public class OPMLService : IOPMLService
    {
        
  
     




        #region IOPMLService Members

        public OPML GetOPML()
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

            Rss.OPML opml = new OPML(@"C:\temp\top100withimages.opml");
            return opml;
        }

        #endregion
    }
}
