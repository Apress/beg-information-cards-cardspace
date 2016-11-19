using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.Serialization;
using System.ServiceModel;
using DataContracts;


namespace ServiceContracts
{
    [ServiceContract]
    public interface IAlertService
    {

        [OperationContract]
        List<Alert> GetAlerts();
    
    }
}
