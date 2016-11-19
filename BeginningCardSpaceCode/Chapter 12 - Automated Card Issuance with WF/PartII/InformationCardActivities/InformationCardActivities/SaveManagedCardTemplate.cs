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
	public partial class SaveManagedCardTemplate: Activity
	{
		public SaveManagedCardTemplate()
		{
			InitializeComponent();
		}

        public static DependencyProperty TemplateDirectoryProperty = System.Workflow.ComponentModel.DependencyProperty.Register("TemplateDirectory", typeof(string), typeof(SaveManagedCardTemplate));

        [Description("This is the directory where templates are stored")]
        [Category("Miscellaneous")]
        [Browsable(true)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public string TemplateDirectory
        {
            get
            {
                return ((string)(base.GetValue(SaveManagedCardTemplate.TemplateDirectoryProperty)));
            }
            set
            {
                base.SetValue(SaveManagedCardTemplate.TemplateDirectoryProperty, value);
            }
        }

        public static DependencyProperty TemplateNameProperty = System.Workflow.ComponentModel.DependencyProperty.Register("TemplateName", typeof(string), typeof(SaveManagedCardTemplate));

        [Description("The name of the template")]
        [Category("Miscellaneous")]
        [Browsable(true)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public string TemplateName
        {
            get
            {
                return ((string)(base.GetValue(SaveManagedCardTemplate.TemplateNameProperty)));
            }
            set
            {
                base.SetValue(SaveManagedCardTemplate.TemplateNameProperty, value);
            }
        }

        public static DependencyProperty TemplateProperty = System.Workflow.ComponentModel.DependencyProperty.Register("Template", typeof(InformationCardTemplate), typeof(SaveManagedCardTemplate));

        [Description("This is the Information Card Template to Save")]
        [Category("Miscellaneous")]
        [Browsable(true)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public InformationCardTemplate Template
        {
            get
            {
                return ((InformationCardTemplate)(base.GetValue(SaveManagedCardTemplate.TemplateProperty)));
            }
            set
            {
                base.SetValue(SaveManagedCardTemplate.TemplateProperty, value);
            }
        }

        protected override ActivityExecutionStatus Execute(ActivityExecutionContext executionContext)
        {
            if (TemplateDirectory.Substring(TemplateDirectory.Length - 1) == "/" || TemplateDirectory.Substring(TemplateDirectory.Length - 1) == "\\")
                TemplateDirectory += "\\";
            string fileName = TemplateDirectory + TemplateName;
            ManagedCardHelper.SaveCardTemplate(Template, fileName);


            return base.Execute(executionContext);
        }
    
    
    
    }
}
