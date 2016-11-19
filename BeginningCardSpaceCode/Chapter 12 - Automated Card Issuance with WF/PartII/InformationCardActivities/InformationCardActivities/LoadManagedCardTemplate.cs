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

namespace InformationCardActivities
{
	public partial class LoadManagedCardTemplate: Activity
	{
		public LoadManagedCardTemplate()
		{
			InitializeComponent();
		}


        public static DependencyProperty TemplateDirectoryProperty = System.Workflow.ComponentModel.DependencyProperty.Register("TemplateDirectory", typeof(string), typeof(LoadManagedCardTemplate));

        [Description("This is the directory where templates are stored")]
        [Category("Miscellaneous")]
        [Browsable(true)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public string TemplateDirectory
        {
            get
            {
                return ((string)(base.GetValue(LoadManagedCardTemplate.TemplateDirectoryProperty)));
            }
            set
            {
                base.SetValue(LoadManagedCardTemplate.TemplateDirectoryProperty, value);
            }
        }

        public static DependencyProperty TemplateNameProperty = System.Workflow.ComponentModel.DependencyProperty.Register("TemplateName", typeof(string), typeof(LoadManagedCardTemplate));

        [Description("The name of the template")]
        [Category("Miscellaneous")]
        [Browsable(true)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public string TemplateName
        {
            get
            {
                return ((string)(base.GetValue(LoadManagedCardTemplate.TemplateNameProperty)));
            }
            set
            {
                base.SetValue(LoadManagedCardTemplate.TemplateNameProperty, value);
            }
        }

        public static DependencyProperty ResultProperty = System.Workflow.ComponentModel.DependencyProperty.Register("Result", typeof(InformationCardTemplate), typeof(LoadManagedCardTemplate));

        [Description("The template for an Information Card")]
        [Category("Result")]
        [Browsable(true)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public InformationCardTemplate Result
        {
            get
            {
                return ((InformationCardTemplate)(base.GetValue(LoadManagedCardTemplate.ResultProperty)));
            }
            set
            {
                base.SetValue(LoadManagedCardTemplate.ResultProperty, value);
            }
        }

        protected override ActivityExecutionStatus Execute(ActivityExecutionContext executionContext)
        {

            
            if (TemplateDirectory.Substring(TemplateDirectory.Length-1) != "/" || TemplateDirectory.Substring(TemplateDirectory.Length-1) != "\\") 
                TemplateDirectory += "\\";
            string fileName = TemplateDirectory + TemplateName + ".template";
            InformationCardTemplate ict = ManagedCardHelper.LoadCardTemplate(fileName);

            Result = ict;
            return base.Execute(executionContext);
        }
    
    }
}
