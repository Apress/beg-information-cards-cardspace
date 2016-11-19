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

            string locality ="";
            string country ="";
            string givenname ="";
            string surname ="";
            AuthorizationContext ctx = OperationContext.Current.ServiceSecurityContext.AuthorizationContext;
      
            
            foreach (ClaimSet claimSet in ctx.ClaimSets)
                {
                    foreach (Claim claim in claimSet)
                    {

                           if (claim.ClaimType == ClaimTypes.Locality)
                                    {locality = claim.Resource.ToString();}
                            if (claim.ClaimType == ClaimTypes.Country)
                                    { country = claim.Resource.ToString(); }
                            if (claim.ClaimType == ClaimTypes.GivenName)
                                    { givenname = claim.Resource.ToString(); }
                            if (claim.ClaimType == ClaimTypes.Surname)
                                    { surname = claim.Resource.ToString(); }
                        
                        }

                    }



                

                List<Alert> la = new List<Alert>();

                Alert a = new Alert();
                a.Title = "Special Offer";
                a.AlertText = givenname + " " + surname + ", we wanted to let you know that Fabrikam has special offers for customers living in  " + locality + ". These offers are open to all " + country + " citizens.";
                a.AlertHTML = "<HTML><HEAD/><BODY>";
                a.AlertHTML += a.AlertText;
                a.AlertHTML += "</BODY></HTML>";
            
                Alert b = new Alert();
                b.Title = "Statement Available";
                b.AlertText = givenname + " " + surname + ", we wanted to let you know that your account statement for the period ending" + DateTime.Now.ToShortDateString() + " is now available.";
                b.AlertText += "Last updated:" + DateTime.Now.ToString();
                b.AlertHTML = "<HTML><HEAD/><BODY>";
                b.AlertHTML += b.AlertText;
                b.AlertHTML += "</BODY></HTML>";


                la.Add(a);
                la.Add(b);
            
                return la;
            }
    }
        #endregion
        }
    
