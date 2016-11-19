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
using BeginningCardSpace;
using System.Security.Cryptography.X509Certificates;
using System.Xml;

namespace InformationCardActivities
{
	public partial class CreateAndSignInformationCard: Activity
	{
		public CreateAndSignInformationCard()
		{
			InitializeComponent();
		}


        public static DependencyProperty InformationCardProperty = System.Workflow.ComponentModel.DependencyProperty.Register("InformationCard", typeof(InformationCard), typeof(CreateAndSignInformationCard));

        [Description("This is the Information Card information that will be generated into the .CRD file")]
        [Category("Miscellaneous")]
        [Browsable(true)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public InformationCard InformationCard
        {
            get
            {
                return ((InformationCard)(base.GetValue(CreateAndSignInformationCard.InformationCardProperty)));
            }
            set
            {
                base.SetValue(CreateAndSignInformationCard.InformationCardProperty, value);
            }
        }


        public static DependencyProperty SigningCertificateProperty = System.Workflow.ComponentModel.DependencyProperty.Register("SigningCertificate", typeof(X509Certificate2), typeof(CreateAndSignInformationCard));

        [Description("This is the X509 certificate to sign the Information Card with")]
        [Category("Miscellaneous")]
        [Browsable(true)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public X509Certificate2 SigningCertificate
        {
            get
            {
                return ((X509Certificate2)(base.GetValue(CreateAndSignInformationCard.SigningCertificateProperty)));
            }
            set
            {
                base.SetValue(CreateAndSignInformationCard.SigningCertificateProperty, value);
            }
        }

        public static DependencyProperty ResultProperty = System.Workflow.ComponentModel.DependencyProperty.Register("Result", typeof(System.Xml.XmlElement), typeof(CreateAndSignInformationCard));

        [Description("This is the signed Information Card in XML form.")]
        [Category("Result")]
        [Browsable(true)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public System.Xml.XmlElement Result
        {
            get
            {
                return ((System.Xml.XmlElement)(base.GetValue(CreateAndSignInformationCard.ResultProperty)));
            }
            set
            {
                base.SetValue(CreateAndSignInformationCard.ResultProperty, value);
            }
        }
            protected override ActivityExecutionStatus Execute(ActivityExecutionContext executionContext)
        {
            ManagedCardHelper helper = new ManagedCardHelper();
            System.Xml.XmlDocument doc = helper.CreateInformationCardXML(InformationCard);
            XmlElement e = helper.SignInformationCardXML(doc, SigningCertificate);
            Result = e;

            return base.Execute(executionContext);
        }    
        
    }
}
