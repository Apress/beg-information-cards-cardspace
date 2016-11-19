using System;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Collections;
using System.Drawing;
using System.Workflow.ComponentModel;
using System.Workflow.ComponentModel.Design;
using System.Workflow.ComponentModel.Compiler;
using System.Workflow.ComponentModel.Serialization;
using System.Workflow.Runtime;
using System.Workflow.Activities;
using System.Workflow.Activities.Rules;
using System.Security.Cryptography.Xml;
using System.Security.Cryptography.X509Certificates;

namespace InformationCardActivities
{
	public partial class RetrieveX509CertificateFromStore: Activity
	{
		public RetrieveX509CertificateFromStore()
		{
			InitializeComponent();
		}
        public static DependencyProperty CertificateStoreLocationProperty = System.Workflow.ComponentModel.DependencyProperty.Register("CertificateStoreLocation", typeof(string), typeof(RetrieveX509CertificateFromStore));

        [Description("The certificate store location.")]
        [Category("Search Criteria")]
        [Browsable(true)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public string CertificateStoreLocation
        {
            get
            {
                return ((string)(base.GetValue(RetrieveX509CertificateFromStore.CertificateStoreLocationProperty)));
            }
            set
            {
                base.SetValue(RetrieveX509CertificateFromStore.CertificateStoreLocationProperty, value);
            }
        }

        public static DependencyProperty CertificateStoreNameProperty = System.Workflow.ComponentModel.DependencyProperty.Register("CertificateStoreName", typeof(string), typeof(RetrieveX509CertificateFromStore));

        [Description("The certificate store name.")]
        [Category("Search Criteria")]
        [Browsable(true)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public string CertificateStoreName
        {
            get
            {
                return ((string)(base.GetValue(RetrieveX509CertificateFromStore.CertificateStoreNameProperty)));
            }
            set
            {
                base.SetValue(RetrieveX509CertificateFromStore.CertificateStoreNameProperty, value);
            }
        }
        public static DependencyProperty CertificateCommonNameProperty = System.Workflow.ComponentModel.DependencyProperty.Register("CertificateCommonName", typeof(string), typeof(RetrieveX509CertificateFromStore));

        [Description("The Common Name (CN) of the Certificate")]
        [Category("Search Criteria")]
        [Browsable(true)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public string CertificateCommonName
        {
            get
            {
                return ((string)(base.GetValue(RetrieveX509CertificateFromStore.CertificateCommonNameProperty)));
            }
            set
            {
                base.SetValue(RetrieveX509CertificateFromStore.CertificateCommonNameProperty, value);
            }
        }
        public static DependencyProperty ResultProperty = System.Workflow.ComponentModel.DependencyProperty.Register("Result", typeof(X509Certificate2), typeof(RetrieveX509CertificateFromStore));

        [Description("This is the certificate requested")]
        [Category("Result")]
        [Browsable(true)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public X509Certificate2 Result
        {
            get
            {
                return ((X509Certificate2)(base.GetValue(RetrieveX509CertificateFromStore.ResultProperty)));
            }
            set
            {
                base.SetValue(RetrieveX509CertificateFromStore.ResultProperty, value);
            }
        }
        protected override ActivityExecutionStatus Execute(ActivityExecutionContext executionContext)
        {

            StoreName storeName = StoreName.My;
            StoreLocation storeLocation = StoreLocation.LocalMachine;
            X509Certificate2 certificate = new X509Certificate2();
            
            try
            {
                storeLocation = (StoreLocation)Enum.Parse(typeof(StoreLocation), CertificateStoreLocation, true);
            }
            catch (Exception)
            {
                throw new Exception("No Certificate Location: " + CertificateStoreLocation);
            }
            try
            {
                storeName = (StoreName)Enum.Parse(typeof(StoreName), CertificateStoreName, true);
            }
            catch (Exception)
            {
                throw new Exception("No Certificate Store: " + CertificateStoreName + " in " + CertificateStoreLocation);
            }

            X509Store s = new X509Store(storeName, storeLocation);
            s.Open(OpenFlags.MaxAllowed);
            foreach (X509Certificate2 xCert in s.Certificates)
            {
                if (xCert.Subject.StartsWith("CN=" + CertificateCommonName))
                {
                    certificate = xCert;
                    break;
                }


            }
            Result =  certificate;

            return base.Execute(executionContext);
        }
    
    }
}
