#region Using directives

using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Workflow.Runtime;
using System.Workflow.Runtime.Hosting;
using BeginningCardSpace;
#endregion

namespace ConsoleCardIssuanceWorkflow
{
    class Program
    {
        static void Main(string[] args)
        {
            using(WorkflowRuntime workflowRuntime = new WorkflowRuntime())
            {
                AutoResetEvent waitHandle = new AutoResetEvent(false);
                workflowRuntime.WorkflowCompleted += delegate(object sender, WorkflowCompletedEventArgs e) {waitHandle.Set();};
                workflowRuntime.WorkflowTerminated += delegate(object sender, WorkflowTerminatedEventArgs e)
                {
                    Console.WriteLine(e.Exception.Message);
                    waitHandle.Set();
                };

                //ManagedCardCreationRequest request = new ManagedCardCreationRequest();
                //request.EmailDeliveryAddressForCard = "mmercuri@microsoft.com";
                //request.TemplateName = "ReaderCard";
                //CardClaim claim = new CardClaim();
                
                
                //request.ClaimValues.Add("http://schemas.xmlsoap.org/ws/2005/05/identity/claims/privatepersonalidentifier",
                //                         "1234567889");
                //request.ClaimValues.Add("http://schemas.xmlsoap.org/ws/2005/05/identity/claims/postalcode",
                //                            "98011");
                //request.ClaimValues.Add("http://schemas.xmlsoap.org/ws/2005/05/identity/claims/gender",
                //                        "Male");
                //request.ClaimValues.Add("http://www.galileo.com/identity/claims/AirlinePreferences",
                //                       "AA,L86W660;DL,2199400793");
                //request.ClaimValues.Add("http://www.galileo.com/identity/claims/HotelPreferences",
                //                                       "SW,C50922860189");
                //request.ClaimValues.Add("http://www.galileo.com/identity/claims/CarPreferences",
                //                                       "");

                ManagedCardCreationRequest request = new ManagedCardCreationRequest();
                request.EmailDeliveryAddressForCard = "mmercuri@microsoft.com";
                request.TemplateName = "ReaderCard2"; 

                request.ClaimValues.Add("http://schemas.xmlsoap.org/ws/2005/05/identity/claims/privatepersonalidentifier",
                                         "1234567889");
                request.ClaimValues.Add("http://schemas.xmlsoap.org/ws/2005/05/identity/claims/postalcode",
                                            "98011");
                request.ClaimValues.Add("http://schemas.xmlsoap.org/ws/2005/05/identity/claims/givenname",
                                        "Marc");
                request.ClaimValues.Add("http://schemas.xmlsoap.org/ws/2005/05/identity/claims/surname",
                                        "Mercuri");

                request.ClaimValues.Add("http://schemas.xmlsoap.org/ws/2005/05/identity/claims/emailaddress",
                                       "mmercuri@microsoft.com");

                request.ClaimValues.Add("http://schemas.xmlsoap.org/ws/2005/05/identity/claims/streetaddress",
                                                       "1 Microsoft Way");
                request.ClaimValues.Add("http://schemas.xmlsoap.org/ws/2005/05/identity/claims/locality",
                                                       "Redmond");
                request.ClaimValues.Add("http://schemas.xmlsoap.org/ws/2005/05/identity/claims/dateofbirth",
                                                       "03/16/1972");
                request.ClaimValues.Add("http://schemas.xmlsoap.org/ws/2005/05/identity/claims/mobilephone",
                                                       "4254431479");
                request.ClaimValues.Add("http://schemas.xmlsoap.org/ws/2005/05/identity/claims/homephone",
                                                       "4257058794");
                request.ClaimValues.Add("http://schemas.xmlsoap.org/ws/2005/05/identity/claims/country",
                                                       "US");
                request.ClaimValues.Add("http://schemas.xmlsoap.org/ws/2005/05/identity/claims/stateorprovince",
                                                       "WA");

           
                List<ManagedCardCreationRequest> requests = new List<ManagedCardCreationRequest>();
                requests.Add(request);

                Dictionary<string, object> parameters = new Dictionary<string,object>();
                parameters.Add("ManagedCardCreationRequests", requests);
                

                WorkflowInstance instance = workflowRuntime.CreateWorkflow(typeof(ConsoleCardIssuanceWorkflow.CardIssuanceByEmailWorkflow),parameters);
                instance.Start();

                waitHandle.WaitOne();
            }
        }
    }
}
