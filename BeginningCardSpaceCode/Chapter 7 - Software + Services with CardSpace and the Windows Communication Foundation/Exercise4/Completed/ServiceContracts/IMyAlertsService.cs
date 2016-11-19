using System;
using System.Collections.Generic;
using System.Text;
using System.ServiceModel;
using DataContracts;

namespace ServiceContracts
{
   [ServiceContract]
    public interface IMyAlertsService
    {

        [OperationContract]
        List<Alert> GetMyAlerts();
        
    }
}
