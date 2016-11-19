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

namespace ConsoleCardIssuanceWorkflow
{
	partial class CardIssuanceByEmailWorkflow
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
            System.Workflow.ComponentModel.ActivityBind activitybind1 = new System.Workflow.ComponentModel.ActivityBind();
            System.Workflow.ComponentModel.ActivityBind activitybind2 = new System.Workflow.ComponentModel.ActivityBind();
            System.Workflow.ComponentModel.ActivityBind activitybind3 = new System.Workflow.ComponentModel.ActivityBind();
            System.Workflow.ComponentModel.ActivityBind activitybind4 = new System.Workflow.ComponentModel.ActivityBind();
            System.Workflow.ComponentModel.ActivityBind activitybind5 = new System.Workflow.ComponentModel.ActivityBind();
            System.Workflow.ComponentModel.ActivityBind activitybind6 = new System.Workflow.ComponentModel.ActivityBind();
            System.Workflow.ComponentModel.ActivityBind activitybind7 = new System.Workflow.ComponentModel.ActivityBind();
            System.Workflow.ComponentModel.ActivityBind activitybind8 = new System.Workflow.ComponentModel.ActivityBind();
            this.sendEmail1 = new InformationCardActivities.SendEmail();
            this.codeAddInformationCardAsAttachment = new System.Workflow.Activities.CodeActivity();
            this.saveInformationCardToFile1 = new InformationCardActivities.SaveInformationCardToFile();
            this.createAndSignInformationCard1 = new InformationCardActivities.CreateAndSignInformationCard();
            this.RetrieveCertificate1 = new InformationCardActivities.RetrieveX509CertificateFromStore();
            this.populateTemplateWithClaimValues = new System.Workflow.Activities.CodeActivity();
            this.loadManagedCardTemplate1 = new InformationCardActivities.LoadManagedCardTemplate();
            this.codeDetermineTemplateName = new System.Workflow.Activities.CodeActivity();
            // 
            // sendEmail1
            // 
            this.sendEmail1.Attachments = null;
            this.sendEmail1.EmailPassword = "yourEmailPassword";
            this.sendEmail1.EmailUsername = "yourEmailUsername";
            this.sendEmail1.From = "YourNameHere";
            this.sendEmail1.MessageBody = "This is your Information Card";
            this.sendEmail1.Name = "sendEmail1";
            this.sendEmail1.SMTPHost = "mail.yourhost.com";
            this.sendEmail1.Subject = "Understanding Cardspace - Chapter 12 - Your Information Card is Attached";
            activitybind1.Name = "CardIssuanceByEmailWorkflow";
            activitybind1.Path = "ManagedCardCreationRequests[0].EmailDeliveryAddressForCard";
            this.sendEmail1.SetBinding(InformationCardActivities.SendEmail.ToProperty, ((System.Workflow.ComponentModel.ActivityBind)(activitybind1)));
            // 
            // codeAddInformationCardAsAttachment
            // 
            this.codeAddInformationCardAsAttachment.Name = "codeAddInformationCardAsAttachment";
            this.codeAddInformationCardAsAttachment.ExecuteCode += new System.EventHandler(this.codeAddInformationCardAsAttachment_Execute);
            // 
            // saveInformationCardToFile1
            // 
            this.saveInformationCardToFile1.InformationCardFileName = "";
            this.saveInformationCardToFile1.InformationCardPath = "C:\\BeginningCardSpace\\Chapter12\\Templates";
            this.saveInformationCardToFile1.Name = "saveInformationCardToFile1";
            activitybind2.Name = "createAndSignInformationCard1";
            activitybind2.Path = "Result";
            this.saveInformationCardToFile1.SetBinding(InformationCardActivities.SaveInformationCardToFile.SignedInformationCardProperty, ((System.Workflow.ComponentModel.ActivityBind)(activitybind2)));
            // 
            // createAndSignInformationCard1
            // 
            activitybind3.Name = "loadManagedCardTemplate1";
            activitybind3.Path = "Result.InformationCardDefinition";
            this.createAndSignInformationCard1.Name = "createAndSignInformationCard1";
            this.createAndSignInformationCard1.Result = null;
            activitybind4.Name = "RetrieveCertificate1";
            activitybind4.Path = "Result";
            this.createAndSignInformationCard1.SetBinding(InformationCardActivities.CreateAndSignInformationCard.SigningCertificateProperty, ((System.Workflow.ComponentModel.ActivityBind)(activitybind4)));
            this.createAndSignInformationCard1.SetBinding(InformationCardActivities.CreateAndSignInformationCard.InformationCardProperty, ((System.Workflow.ComponentModel.ActivityBind)(activitybind3)));
            // 
            // RetrieveCertificate1
            // 
            activitybind5.Name = "loadManagedCardTemplate1";
            activitybind5.Path = "Result.SigningCertificateInfo.CommonName";
            activitybind6.Name = "loadManagedCardTemplate1";
            activitybind6.Path = "Result.SigningCertificateInfo.Location";
            activitybind7.Name = "loadManagedCardTemplate1";
            activitybind7.Path = "Result.SigningCertificateInfo.Store";
            this.RetrieveCertificate1.Name = "RetrieveCertificate1";
            this.RetrieveCertificate1.Result = null;
            this.RetrieveCertificate1.SetBinding(InformationCardActivities.RetrieveX509CertificateFromStore.CertificateCommonNameProperty, ((System.Workflow.ComponentModel.ActivityBind)(activitybind5)));
            this.RetrieveCertificate1.SetBinding(InformationCardActivities.RetrieveX509CertificateFromStore.CertificateStoreLocationProperty, ((System.Workflow.ComponentModel.ActivityBind)(activitybind6)));
            this.RetrieveCertificate1.SetBinding(InformationCardActivities.RetrieveX509CertificateFromStore.CertificateStoreNameProperty, ((System.Workflow.ComponentModel.ActivityBind)(activitybind7)));
            // 
            // populateTemplateWithClaimValues
            // 
            this.populateTemplateWithClaimValues.Name = "populateTemplateWithClaimValues";
            this.populateTemplateWithClaimValues.ExecuteCode += new System.EventHandler(this.populateTemplateWithClaimValues_Execute);
            // 
            // loadManagedCardTemplate1
            // 
            this.loadManagedCardTemplate1.Name = "loadManagedCardTemplate1";
            this.loadManagedCardTemplate1.Result = null;
            this.loadManagedCardTemplate1.TemplateDirectory = "C:\\InformationCards\\Templates";
            activitybind8.Name = "CardIssuanceByEmailWorkflow";
            activitybind8.Path = "ManagedCardCreationRequests[0].TemplateName";
            this.loadManagedCardTemplate1.SetBinding(InformationCardActivities.LoadManagedCardTemplate.TemplateNameProperty, ((System.Workflow.ComponentModel.ActivityBind)(activitybind8)));
            // 
            // codeDetermineTemplateName
            // 
            this.codeDetermineTemplateName.Name = "codeDetermineTemplateName";
            this.codeDetermineTemplateName.ExecuteCode += new System.EventHandler(this.codeDetermineTemplateName_ExecuteCode);
            // 
            // CardIssuanceByEmailWorkflow
            // 
            this.Activities.Add(this.codeDetermineTemplateName);
            this.Activities.Add(this.loadManagedCardTemplate1);
            this.Activities.Add(this.populateTemplateWithClaimValues);
            this.Activities.Add(this.RetrieveCertificate1);
            this.Activities.Add(this.createAndSignInformationCard1);
            this.Activities.Add(this.saveInformationCardToFile1);
            this.Activities.Add(this.codeAddInformationCardAsAttachment);
            this.Activities.Add(this.sendEmail1);
            this.Name = "CardIssuanceByEmailWorkflow";
            this.CanModifyActivities = false;

		}

		#endregion

        private CodeActivity codeDetermineTemplateName;
        private InformationCardActivities.LoadManagedCardTemplate loadManagedCardTemplate1;
        private InformationCardActivities.RetrieveX509CertificateFromStore RetrieveCertificate1;
        private InformationCardActivities.CreateAndSignInformationCard createAndSignInformationCard1;
        private CodeActivity populateTemplateWithClaimValues;
        private CodeActivity codeAddInformationCardAsAttachment;
        private InformationCardActivities.SaveInformationCardToFile saveInformationCardToFile1;
        private InformationCardActivities.SendEmail sendEmail1;










































    }
}
