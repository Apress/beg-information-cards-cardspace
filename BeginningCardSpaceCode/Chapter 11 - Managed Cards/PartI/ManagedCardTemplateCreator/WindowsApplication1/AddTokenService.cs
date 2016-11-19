using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace BeginningCardSpace
{
    public partial class AddTokenService : Form
    {

       private TokenService ts;

        public AddTokenService()
        {
            InitializeComponent();

            cboType.Items.Add("Kerberos");
            cboType.Items.Add("Self-Issued");
            cboType.Items.Add("SmartCard");
            cboType.Items.Add("Username and Password");
        }


        public new TokenService ShowDialog()
        {
            base.ShowDialog();
            
            

            return ts;
        
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {

            ts = new TokenService();
            ts.UserCredential.DisplayCredentialHint = tbDisplayCredentialHint.Text;
            ts.UserCredential.UserCredentialType = (CredentialType)cboType.SelectedIndex;
            ts.UserCredential.Value = tbValue.Text;

            ts.EndpointReference.Address = tbAddress.Text;
            
            
            ts.EndpointReference.Identity = tbIdentity.Text;
            ts.EndpointReference.Mex = tbMex.Text;
            Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            ts = null;
            Close();
        }

        private void cboType_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (cboType.SelectedIndex)
            { 
                case 0:
                    //Kerberos - No Value Specified
                    tbValue.Visible = false;
                    lblValue.Visible = false;
                    break;
                case 1:
                    //Self-Issued - PPID
                    tbValue.Visible = true;
                    lblValue.Text = "PPID";
                    lblValue.Visible = true;
                    break;
                case 2:
                    //SmartCard/Certificate
                    tbValue.Visible = true;
                    lblValue.Text = "Cert Path(Location/Store/CN";
                    lblValue.Visible = true;
                    break;
                case 3:
                     //Username and Password
                    tbValue.Visible = true;
                    lblValue.Text = "Username";
                    lblValue.Visible = true;
                    break;
            
            }
        }
    }
}