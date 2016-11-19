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
using System.Xml;
namespace InformationCardActivities
{
	public partial class SaveInformationCardToFile: Activity
	{
		public SaveInformationCardToFile()
		{
			InitializeComponent();
		}

        public static DependencyProperty SignedInformationCardProperty = System.Workflow.ComponentModel.DependencyProperty.Register("SignedInformationCard", typeof(XmlElement), typeof(SaveInformationCardToFile));

        [Description("This is the signed information card to be saved to a file.")]
        [Category("Miscellaneous")]
        [Browsable(true)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public XmlElement SignedInformationCard
        {
            get
            {
                return ((XmlElement)(base.GetValue(SaveInformationCardToFile.SignedInformationCardProperty)));
            }
            set
            {
                base.SetValue(SaveInformationCardToFile.SignedInformationCardProperty, value);
            }
        }

        public static DependencyProperty InformationCardPathProperty = System.Workflow.ComponentModel.DependencyProperty.Register("InformationCardPath", typeof(string), typeof(SaveInformationCardToFile));

        [Description("This is the path where Information Cards should be stored.")]
        [Category("Miscellaneous")]
        [Browsable(true)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public string InformationCardPath
        {
            get
            {
                return ((string)(base.GetValue(SaveInformationCardToFile.InformationCardPathProperty)));
            }
            set
            {
                base.SetValue(SaveInformationCardToFile.InformationCardPathProperty, value);
            }
        }

        public static DependencyProperty InformationCardFileNameProperty = System.Workflow.ComponentModel.DependencyProperty.Register("InformationCardFileName", typeof(string), typeof(SaveInformationCardToFile));

        [Description("This is the name to be used for the CRD file.")]
        [Category("Miscellaneous")]
        [Browsable(true)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public string InformationCardFileName
        {
            get
            {
                return ((string)(base.GetValue(SaveInformationCardToFile.InformationCardFileNameProperty)));
            }
            set
            {
                base.SetValue(SaveInformationCardToFile.InformationCardFileNameProperty, value);
            }
        }
        
        
        protected override ActivityExecutionStatus Execute(ActivityExecutionContext executionContext)
        {
            if (InformationCardPath.Substring(InformationCardPath.Length - 1) != "\\")
                InformationCardPath += "\\";
            string filename = InformationCardPath + InformationCardFileName;

            ManagedCardHelper helper = new ManagedCardHelper();
            helper.SaveInformationCard(SignedInformationCard, filename); 
            
            return base.Execute(executionContext);
        }    
        
    }
}
