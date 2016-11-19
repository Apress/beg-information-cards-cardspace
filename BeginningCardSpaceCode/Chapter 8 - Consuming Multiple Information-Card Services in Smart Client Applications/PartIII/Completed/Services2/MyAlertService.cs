using System;
using System.Collections.Generic;
using System.Text;
using ServiceContracts;
using DataContracts;
using System.IdentityModel.Claims;
using System.IdentityModel.Policy;
using System.ServiceModel;


namespace Services
{
   
    public class MyAlertService : IMyAlertsService
    {
        #region IMyAlertService Members

        
        public List<Alert> GetMyAlerts()
        {

            bool foundEmail = false;
            string email ="";
           
            AuthorizationContext ctx = OperationContext.Current.ServiceSecurityContext.AuthorizationContext;
      
            
            foreach (ClaimSet claimSet in ctx.ClaimSets)
                {

                     
                foreach (Claim claim in claimSet)
                    {

                           if (claim.ClaimType == ClaimTypes.Email)
                           {
                               email = claim.Resource.ToString();
                                
                           
                           }

                        
                        }

                    }

                        List<Alert> la = new List<Alert>();

                        Alert a = new Alert();
                        a.Title = "Confirm Email";
                        a.AlertText = "We have been unable to reach you at the email address you provided,<b>";
                        a.AlertText += email + ".  Please contact us and provide a valid email address.";
                        a.AlertHTML = "<HTML><HEAD/><BODY>";
                        a.AlertHTML += a.AlertText;
                        a.AlertHTML += "</BODY></HTML>";



                        la.Add(a);

                        return la;

                   

        
        }
    }
        #endregion
        }
    
