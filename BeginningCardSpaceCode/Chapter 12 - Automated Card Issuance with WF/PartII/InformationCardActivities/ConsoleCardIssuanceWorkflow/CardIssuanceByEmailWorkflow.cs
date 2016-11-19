using System;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Collections;
using System.Drawing;
using System.Workflow.ComponentModel.Compiler;
using System.Workflow.ComponentModel.Serialization;
using System.Workflow.ComponentModel;
using System.Workflow.ComponentModel.Design;
using System.Workflow.Runtime;
using System.Workflow.Activities;
using System.Workflow.Activities.Rules;
using System.Collections.Generic;
using BeginningCardSpace;
using System.IO;

namespace ConsoleCardIssuanceWorkflow
{
    public sealed partial class CardIssuanceByEmailWorkflow : SequentialWorkflowActivity
    {
        private List<ManagedCardCreationRequest> _managedCardCreationRequests;

        public List<ManagedCardCreationRequest> ManagedCardCreationRequests
        {
            get { return _managedCardCreationRequests; }
            set { _managedCardCreationRequests = value; }

        }
        public CardIssuanceByEmailWorkflow()
        {
            InitializeComponent();
            ManagedCardCreationRequests = new List<ManagedCardCreationRequest>();
        }

 
  
        private void codeDetermineTemplateName_ExecuteCode(object sender, EventArgs e)
        {
            this.loadManagedCardTemplate1.TemplateName = ManagedCardCreationRequests[0].TemplateName;
        }

        private void populateTemplateWithClaimValues_Execute(object sender, EventArgs e)
        {
            foreach (CardClaim cardClaim in this.loadManagedCardTemplate1.Result.InformationCardDefinition.SupportedClaimTypeList)
            {
                cardClaim.Value = ManagedCardCreationRequests[0].ClaimValues[cardClaim.Uri];
            }
            this.saveInformationCardToFile1.InformationCardFileName = this.loadManagedCardTemplate1.Result.InformationCardDefinition.CardName + "_" + Guid.NewGuid().ToString() + ".CRD";


        }

        private void codeAddInformationCardAsAttachment_Execute(object sender, EventArgs e)
        {
            sendEmail1.To = ManagedCardCreationRequests[0].EmailDeliveryAddressForCard;

            if (saveInformationCardToFile1.InformationCardPath.Substring(saveInformationCardToFile1.InformationCardPath.Length - 1) != "\\")
                saveInformationCardToFile1.InformationCardPath += "\\";
            string filename = saveInformationCardToFile1.InformationCardPath + saveInformationCardToFile1.InformationCardFileName;
            if (sendEmail1.Attachments == null)
                sendEmail1.Attachments = new List<System.Net.Mail.Attachment>();
            sendEmail1.Attachments.Add(new System.Net.Mail.Attachment(filename));
        }

     
    }
}

