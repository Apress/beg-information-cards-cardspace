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

namespace SimpleWorkflow
{

    public partial class TimeAwareHelloWorld: Activity
	{

      
        public static DependencyProperty PersonToGreetProperty = System.Workflow.ComponentModel.DependencyProperty.Register("PersonToGreet", typeof(string), typeof(TimeAwareHelloWorld));

        [Description("This is the name of the person to say hello to.")]
        [Category("Input Parameters")]
        [Browsable(true)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public string PersonToGreet
        {
            get
            {
                return ((string)(base.GetValue(TimeAwareHelloWorld.PersonToGreetProperty)));
            }
            set
            {
                base.SetValue(TimeAwareHelloWorld.PersonToGreetProperty, value);
            }
        }

        
        public static DependencyProperty InvokeEvent = DependencyProperty.Register("Invoke", typeof(EventHandler), typeof(TimeAwareHelloWorld));

        [Description("This is the event fired when the activity is invoked.")]
        [Category("PreExecution")]
        [Browsable(true)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public event EventHandler Invoke
        {
            add
            {
                base.AddHandler(TimeAwareHelloWorld.InvokeEvent, value);
            }
            remove
            {
                base.RemoveHandler(TimeAwareHelloWorld.InvokeEvent, value);
            }
        }
      

        
        public TimeAwareHelloWorld()
		{
			InitializeComponent();
		}



        protected override ActivityExecutionStatus Execute(ActivityExecutionContext executionContext)
        {

            
            base.RaiseEvent(TimeAwareHelloWorld.InvokeEvent, this, EventArgs.Empty);

            string greeting = "";
            if (System.DateTime.Now.Hour < 12)
            { greeting += "Good morning, "; }
            else
            { greeting += "Good afternoon, "; }

            greeting += PersonToGreet + ". The current time is " + System.DateTime.Now.ToLongTimeString();
            
            Console.WriteLine(greeting);
            
            return ActivityExecutionStatus.Closed;
        }
    }
}
