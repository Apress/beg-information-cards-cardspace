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
    public class AlertService : IAlertService
    {
        #region IAlertService Members

        public List<Alert> GetAlerts()
        {


            List<Alert> la = new List<Alert>();

            Alert a = new Alert();
            a.Title = "Scheduled Downtime";
            a.AlertText = "Fabrikam's website will be offline tomorrow from 8am to 9am PST.";
            a.AlertHTML = "<HTML><HEAD/><BODY>";
            a.AlertHTML += a.AlertText;
            a.AlertHTML += "</BODY></HTML>";

            la.Add(a);


            return la;
        }


    }
        #endregion
        }
    
