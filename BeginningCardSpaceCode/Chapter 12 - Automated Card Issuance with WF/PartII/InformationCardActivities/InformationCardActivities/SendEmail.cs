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
using System.Net.Mail;
using System.Net.Security;
using System.Collections.Generic;
using System.Net;

namespace InformationCardActivities
{
	public partial class SendEmail: Activity
	{
		public SendEmail()
		{
			InitializeComponent();
            Attachments = new List<Attachment>();
		}
	
  public static DependencyProperty SubjectProperty = System.Workflow.ComponentModel.DependencyProperty.Register("Subject", typeof(string), typeof(SendEmail));
  
  [Description("This is the subject of the email message.")]
  [Category("Email")]
  [Browsable(true)]
  [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
  public string Subject
  {
	  get 
    { 
      return ((string)(base.GetValue(SendEmail.SubjectProperty))); 
    }
    set 
    { 
      base.SetValue(SendEmail.SubjectProperty, value); 
    }
  }
public static DependencyProperty FromProperty = System.Workflow.ComponentModel.DependencyProperty.Register("From", typeof(string), typeof(SendEmail));
  
  [Description("This is whom the message will be sent from.")]
  [Category("Email")]
  [Browsable(true)]
  [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
  public string From
  {
	  get 
    { 
      return ((string)(base.GetValue(SendEmail.FromProperty))); 
    }
    set 
    { 
      base.SetValue(SendEmail.FromProperty, value); 
    }
  }
public static DependencyProperty ToProperty = System.Workflow.ComponentModel.DependencyProperty.Register("To", typeof(string), typeof(SendEmail));
  
  [Description("This is who the email is being sent to.")]
  [Category("Email")]
  [Browsable(true)]
  [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
  public string To
  {
	  get 
    { 
      return ((string)(base.GetValue(SendEmail.ToProperty))); 
    }
    set 
    { 
      base.SetValue(SendEmail.ToProperty, value); 
    }
  }
 public static DependencyProperty SMTPHostProperty = System.Workflow.ComponentModel.DependencyProperty.Register("SMTPHost", typeof(string), typeof(SendEmail));
  
  [Description("This is the SMTP Host to use to send the email.")]
  [Category("Email")]
  [Browsable(true)]
  [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
  public string SMTPHost
  {
	  get 
    { 
      return ((string)(base.GetValue(SendEmail.SMTPHostProperty))); 
    }
    set 
    { 
      base.SetValue(SendEmail.SMTPHostProperty, value); 
    }
  }
public static DependencyProperty MessageBodyProperty = System.Workflow.ComponentModel.DependencyProperty.Register("MessageBody", typeof(string), typeof(SendEmail));
  
  [Description("This is the body of the message.")]
  [Category("Email")]
  [Browsable(true)]
  [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
  public string MessageBody
  {
	  get 
    { 
      return ((string)(base.GetValue(SendEmail.MessageBodyProperty))); 
    }
    set 
    { 
      base.SetValue(SendEmail.MessageBodyProperty, value); 
    }
  }
 
public static DependencyProperty AttachmentsProperty = System.Workflow.ComponentModel.DependencyProperty.Register("Attachments", typeof(List<Attachment>), typeof(SendEmail));
  
  [Description("This is a list of attachments to send with the email.")]
  [Category("Email")]
  [Browsable(true)]
  [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
  public List<Attachment> Attachments
  {
	  get 
    { 
      return ((List<Attachment>)(base.GetValue(SendEmail.AttachmentsProperty))); 
    }
    set 
    { 
      base.SetValue(SendEmail.AttachmentsProperty, value); 
    }
  }        
        
public static DependencyProperty EmailUsernameProperty = System.Workflow.ComponentModel.DependencyProperty.Register("EmailUsername", typeof(string), typeof(SendEmail));
  
  [Description("This is the username for the SMTP host.")]
  [Category("Email")]
  [Browsable(true)]
  [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
  public string EmailUsername
  {
	  get 
    { 
      return ((string)(base.GetValue(SendEmail.EmailUsernameProperty))); 
    }
    set 
    { 
      base.SetValue(SendEmail.EmailUsernameProperty, value); 
    }
  }  
  
  public static DependencyProperty EmailPasswordProperty = System.Workflow.ComponentModel.DependencyProperty.Register("EmailPassword", typeof(string), typeof(SendEmail));
  
  [Description("This is the password to use with the SMTP server.")]
  [Category("Email")]
  [Browsable(true)]
  [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
  public string EmailPassword
  {
    set 
    { 
      base.SetValue(SendEmail.EmailPasswordProperty, value); 
    }
      get
      {
          return ((string)(base.GetValue(SendEmail.EmailPasswordProperty)));
      }

  
  
  }
        protected override ActivityExecutionStatus Execute(ActivityExecutionContext executionContext)
        {
            MailAddress toAddress = new MailAddress(To);
            MailAddress fromAddress = new MailAddress(From);

            MailAddressCollection addresses = new MailAddressCollection();
            addresses.Add(toAddress);

            MailMessage msg = new MailMessage(fromAddress, toAddress);

            msg.Subject = Subject;
            msg.Body = MessageBody;
            if (Attachments != null)
            {
                foreach (Attachment a in Attachments)
                {
                    msg.Attachments.Add(a);
                };

            }            

            SmtpClient mail = new SmtpClient(SMTPHost);
            mail.Credentials = new NetworkCredential(EmailUsername, EmailPassword);
            mail.Send(msg);
            

            return base.Execute(executionContext);
        }    
        
        

    
    
    }
}
