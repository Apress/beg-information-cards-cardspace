using System;
using System.Collections.Generic;
using System.Text;
using System.ServiceModel;
using System.Runtime.Serialization;


namespace WCFServiceHost
{
    class Program
    {
        static void Main(string[] args)
        {

            ServiceHost shAlerts = new ServiceHost(typeof(Services.AlertService), new Uri("http://localhost:1972/Alerts"));
            shAlerts.Open();
            Console.WriteLine("Alert Service Is Now Online");
            Console.WriteLine("---------------------------------------");

            ServiceHost shMyAlerts = new ServiceHost(typeof(Services.MyAlertService), new Uri("http://localhost:1972/Alerts/My"));
            shMyAlerts.Open();

            
            Console.WriteLine("To Stop Service, Press Enter.");
            Console.ReadLine();
            shMyAlerts.Close();
            shAlerts.Close();
        }
    }
}
