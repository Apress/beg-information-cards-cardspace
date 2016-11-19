using System;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Collections;
using System.Drawing;
using System.Reflection;
using System.Workflow.ComponentModel.Compiler;
using System.Workflow.ComponentModel.Serialization;
using System.Workflow.ComponentModel;
using System.Workflow.ComponentModel.Design;
using System.Workflow.Runtime;
using System.Workflow.Activities;
using System.Workflow.Activities.Rules;

namespace SimpleWorkflow
{
	partial class Workflow1
	{
		#region Designer generated code
		
		/// <summary> 
		/// Required method for Designer support - do not modify 
		/// the contents of this method with the code editor.
		/// </summary>
        [System.Diagnostics.DebuggerNonUserCode]
		private void InitializeComponent()
		{
            this.CanModifyActivities = true;
            this.timeAwareHelloWorld2 = new SimpleWorkflow.TimeAwareHelloWorld();
            this.timeAwareHelloWorld1 = new SimpleWorkflow.TimeAwareHelloWorld();
            this.codeActivity1 = new System.Workflow.Activities.CodeActivity();
            // 
            // timeAwareHelloWorld2
            // 
            this.timeAwareHelloWorld2.Name = "timeAwareHelloWorld2";
            this.timeAwareHelloWorld2.PersonToGreet = null;
            this.timeAwareHelloWorld2.Invoke += new System.EventHandler(this.timeAwareHelloWorld2_Execute);
            // 
            // timeAwareHelloWorld1
            // 
            this.timeAwareHelloWorld1.Name = "timeAwareHelloWorld1";
            this.timeAwareHelloWorld1.PersonToGreet = "Marc";
            // 
            // codeActivity1
            // 
            this.codeActivity1.Name = "codeActivity1";
            this.codeActivity1.ExecuteCode += new System.EventHandler(this.codeActivity1_Execute);
            // 
            // Workflow1
            // 
            this.Activities.Add(this.codeActivity1);
            this.Activities.Add(this.timeAwareHelloWorld1);
            this.Activities.Add(this.timeAwareHelloWorld2);
            this.Name = "Workflow1";
            this.CanModifyActivities = false;

		}

		#endregion

        private TimeAwareHelloWorld timeAwareHelloWorld2;
        private TimeAwareHelloWorld timeAwareHelloWorld1;
        private CodeActivity codeActivity1;










    }
}
