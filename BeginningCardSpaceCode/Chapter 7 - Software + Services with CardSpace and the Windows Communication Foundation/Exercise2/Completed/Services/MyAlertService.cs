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

            AuthorizationContext ctx = OperationContext.Current.ServiceSecurityContext.AuthorizationContext;
      
            
            foreach (ClaimSet claimSet in ctx.ClaimSets)
                {
                    foreach (Claim claim in claimSet)
                        {

                            Console.WriteLine("Claim Type:" + claim.ClaimType);
                            Console.WriteLine("Resource:" + claim.Resource.ToString());
                            Console.WriteLine("Right:" + claim.Right);
                            
                        }

                    }



                    List<Alert> la = new List<Alert>();

                    Alert a = new Alert();
                    a.Title = "Test";
                    a.AlertText = "This is a test alert.";
                    a.AlertHTML = "<HTML><HEAD/><BODY>";
                    a.AlertHTML += a.AlertText;
                    a.AlertHTML += "</BODY></HTML>";

                    la.Add(a);
            
                return la;
            }
    }
        #endregion
        }
    
