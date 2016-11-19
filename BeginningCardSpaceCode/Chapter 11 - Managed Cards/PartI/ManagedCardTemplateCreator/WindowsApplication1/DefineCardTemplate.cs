using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Security.Cryptography.X509Certificates;

namespace BeginningCardSpace
{
    public partial class DefineCardTemplate : Form
    {
        public DefineCardTemplate()
        {
            InitializeComponent();

        
        }

        private void btnCardImage_Click(object sender, EventArgs e)
        {
            DialogResult result = openFileDialog1.ShowDialog();
            if (result == DialogResult.OK)
            { 
                string filename = openFileDialog1.FileName;
                string fileExtension = filename.Substring(filename.Length - 3).ToUpper();

                if (fileExtension == "BMP" || fileExtension == "GIF" || fileExtension == "JPG" || fileExtension == "PNG" || fileExtension == "TIF")
                {
                    tbCardImage.Text = filename;
                    picCardImagePreview.ImageLocation = filename;
                    picCardImagePreviewSmall.BackgroundImage = picCardImagePreview.Image;
                }
                else
                {
                    if (fileExtension == "IFF")
                    {
                        if (filename.Substring(filename.Length - 4).ToUpper() == "TIFF")
                        {
                            tbCardImage.Text = filename;
                            picCardImagePreview.ImageLocation = filename;
                            picCardImagePreviewSmall.BackgroundImage = picCardImagePreview.Image;        
                        }
                        else
                        {
                            MessageBox.Show("The file extension for file " + filename + " is not supported. Please select another file.", "Unsupported Image Format");
                            
                        }
                    }
                    else
                    {
                        MessageBox.Show("The file extension for file " + filename + " is not supported. Please select another file.", "Unsupported Image Format");

                    }
                }
            }
        }

        private void btnAddTokenService_Click(object sender, EventArgs e)
        {
            AddTokenService dialog = new AddTokenService();
            TokenService ts = dialog.ShowDialog();
            if (ts != null)
            { 
                //Add the token service
                DataGridViewTextBoxCell address = new DataGridViewTextBoxCell();
                DataGridViewTextBoxCell mex = new DataGridViewTextBoxCell();
                DataGridViewTextBoxCell identity = new DataGridViewTextBoxCell();
                DataGridViewTextBoxCell credentialType = new DataGridViewTextBoxCell();
                DataGridViewTextBoxCell value = new DataGridViewTextBoxCell();
                DataGridViewTextBoxCell displayCredentialHint = new DataGridViewTextBoxCell();

                DataGridViewRow row = new DataGridViewRow();

                address.Value = ts.EndpointReference.Address;
                mex.Value = ts.EndpointReference.Mex;
                identity.Value = ts.EndpointReference.Identity;

                
                credentialType.Value = ts.UserCredential.UserCredentialType.ToString();
                credentialType.Tag = ts.UserCredential.UserCredentialType;
                value.Value = ts.UserCredential.Value;
                displayCredentialHint.Value = ts.UserCredential.DisplayCredentialHint;

                
                row.Cells.Add(address);
                row.Cells.Add(mex);
                row.Cells.Add(identity);
                row.Cells.Add(credentialType);
                row.Cells.Add(value);
                row.Cells.Add(displayCredentialHint);

                dgvTokenServiceList.Rows.Add(row);

            }
        }

        private void btnRemoveTokenService_Click(object sender, EventArgs e)
        {
            
            foreach (DataGridViewRow r in dgvTokenServiceList.SelectedRows)
            {
                dgvTokenServiceList.Rows.Remove(r);
            }
        }

        private void btnAddClaim_Click(object sender, EventArgs e)
        {
            AddClaim addClaim = new AddClaim();
            CardClaim cardClaim = addClaim.ShowDialog();

            DataGridViewRow row = new DataGridViewRow();

            DataGridViewTextBoxCell uri = new DataGridViewTextBoxCell();
            DataGridViewTextBoxCell displayTag = new DataGridViewTextBoxCell();
            DataGridViewTextBoxCell description = new DataGridViewTextBoxCell();
            DataGridViewTextBoxCell claimValue = new DataGridViewTextBoxCell();

            uri.Value = cardClaim.Uri;
            displayTag.Value = cardClaim.DisplayTag;
            description.Value = cardClaim.Description;
            claimValue.Value = cardClaim.Value;

            row.Cells.Add(uri);
            row.Cells.Add(displayTag);
            row.Cells.Add(description);
            row.Cells.Add(claimValue);

            dgvClaims.Rows.Add(row);

        }

        private void btnRemoveClaim_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow r in dgvClaims.SelectedRows)
            {
                dgvClaims.Rows.Remove(r);
            }
        }

        private void btnSaveTemplate_Click(object sender, EventArgs e)
        {
            //saveFileDialog1.Filter = "*.template";
            
        }
        private InformationCardTemplate PopulateCardTemplateFromUI()
        {
            InformationCard ic = new InformationCard();

            ic.CardImage.ImageName = tbCardImage.Text;
            ic.CardName = tbCardName.Text;
            ic.CardReference.CardID = tbCardID.Text;
            ic.CardReference.CardVersion = Convert.ToInt32(tbCardVersion.Text);
            ic.Issuer = tbIssuer.Text;
            ic.IssuerName = tbIssuerName.Text;
            ic.PrivacyNotice = tbPrivacyPolicy.Text;
            ic.RequireRPIdentification = cbRequireAppliesTo.Checked;
            ic.TimeExpires = dtpTimeExpires.Value;
            ic.TimeIssued = dtpTimeIssued.Value;
            
            foreach (DataGridViewRow row in dgvClaims.Rows)
            {
                CardClaim claim = new CardClaim();
                claim.Description = row.Cells["Description"].Value.ToString();
                claim.DisplayTag = row.Cells["DisplayTag"].Value.ToString();
                claim.Uri = row.Cells["Uri"].Value.ToString();
                //claim.Value = row.Cells["ClaimValue"].Value.ToString();
                ic.SupportedClaimTypeList.Add(claim);
            
            }

            if (cbSAML10.Checked)
            {    
                TokenType SAML10 = new TokenType();
                SAML10.Name = "SAML10";
                SAML10.Uri = "urn:oasis:names:tc:SAML:1.0:assertion";
                SAML10.Accepted = true;
                ic.AcceptedTokenTypes.Add(SAML10);
             }    
            if (cbSAML11.Checked)
            {
                TokenType SAML11 = new TokenType();
                SAML11.Name = "SAML11";
                SAML11.Uri = "http://docs.oasis-open.org/wss/oasis-wss-saml-token-profile-1.1#SAMLV1.1";
                ic.AcceptedTokenTypes.Add(SAML11);
            }
            
            foreach (DataGridViewRow tsRow in dgvTokenServiceList.Rows)
            {
                TokenService ts = new TokenService();
                ts.EndpointReference.Address = tsRow.Cells["Address"].Value.ToString();
                ts.EndpointReference.Identity = tsRow.Cells["Identity"].Value.ToString();
                ts.EndpointReference.Mex = tsRow.Cells["Mex"].Value.ToString();
                ts.UserCredential.DisplayCredentialHint = tsRow.Cells["DisplayCredentialHint"].Value.ToString();
                ts.UserCredential.UserCredentialType = (CredentialType) (tsRow.Cells["CredentialType"].Tag);
                ts.UserCredential.Value = tsRow.Cells["Value"].Value.ToString();
                ic.TokenServiceList.Add(ts);
            }



            InformationCardTemplate ict = new InformationCardTemplate();
            ict.InformationCardDefinition = ic;
            ict.SigningCertificateInfo.CommonName = tbCertificateCommonName.Text;
            ict.SigningCertificateInfo.Location = tbCertificateLocation.Text;
            ict.SigningCertificateInfo.Store = tbCertificateStore.Text;
            
           
            

            return ict;
        }
        private void PopulateUIFromCardTemplate(string filename)
        {
            InformationCardTemplate ict = ManagedCardHelper.LoadCardTemplate(filename);

            InformationCard ic = ict.InformationCardDefinition;
            
            tbCardImage.Text = ic.CardImage.ImageName;
            tbCardName.Text = ic.CardName;
            tbCardID.Text = ic.CardReference.CardID;
            tbCardVersion.Text = ic.CardReference.CardVersion.ToString();
            tbIssuer.Text = ic.Issuer;
            tbIssuerName.Text = ic.IssuerName;
            tbPrivacyPolicy.Text = ic.PrivacyNotice;
            cbRequireAppliesTo.Checked = ic.RequireRPIdentification;
            dtpTimeExpires.Value = ic.TimeExpires;
            dtpTimeIssued.Value = ic.TimeIssued;

            foreach (CardClaim cardClaim in ic.SupportedClaimTypeList)
            {
                DataGridViewRow row = new DataGridViewRow();

                DataGridViewTextBoxCell uri = new DataGridViewTextBoxCell();
                DataGridViewTextBoxCell displayTag = new DataGridViewTextBoxCell();
                DataGridViewTextBoxCell description = new DataGridViewTextBoxCell();
                DataGridViewTextBoxCell claimValue = new DataGridViewTextBoxCell();

                uri.Value = cardClaim.Uri;
                displayTag.Value = cardClaim.DisplayTag;
                description.Value = cardClaim.Description;
                claimValue.Value = cardClaim.Value;

                row.Cells.Add(uri);
                row.Cells.Add(displayTag);
                row.Cells.Add(description);
                row.Cells.Add(claimValue);

                dgvClaims.Rows.Add(row);
            
            }

            cbSAML10.Checked = false;
            cbSAML11.Checked = false;
            
            foreach (TokenType tokenType in ic.AcceptedTokenTypes)
            {
                if (tokenType.Name == "SAML10")
                    cbSAML10.Checked = true;

                if (tokenType.Name == "SAML11")
                    cbSAML11.Checked = true;
                    
            
            }

            foreach (TokenService ts in ic.TokenServiceList)
            {
                //Add the token service
                DataGridViewTextBoxCell address = new DataGridViewTextBoxCell();
                DataGridViewTextBoxCell mex = new DataGridViewTextBoxCell();
                DataGridViewTextBoxCell identity = new DataGridViewTextBoxCell();
                DataGridViewTextBoxCell credentialType = new DataGridViewTextBoxCell();
                DataGridViewTextBoxCell value = new DataGridViewTextBoxCell();
                DataGridViewTextBoxCell displayCredentialHint = new DataGridViewTextBoxCell();

                DataGridViewRow row = new DataGridViewRow();

                address.Value = ts.EndpointReference.Address;
                mex.Value = ts.EndpointReference.Mex;
                identity.Value = ts.EndpointReference.Identity;


                credentialType.Value = ts.UserCredential.UserCredentialType.ToString();
                credentialType.Tag = ts.UserCredential.UserCredentialType;
                value.Value = ts.UserCredential.Value;
                displayCredentialHint.Value = ts.UserCredential.DisplayCredentialHint;


                row.Cells.Add(address);
                row.Cells.Add(mex);
                row.Cells.Add(identity);
                row.Cells.Add(credentialType);
                row.Cells.Add(value);
                row.Cells.Add(displayCredentialHint);

                dgvTokenServiceList.Rows.Add(row);
            
            }
           
            cbRequireAppliesTo.Checked = ic.RequireRPIdentification;
        
        
        }
        private void dateTimePicker2_ValueChanged(object sender, EventArgs e)
        {

        }

        private void btnCreatCard_Click(object sender, EventArgs e)
        {
            InformationCardTemplate ict = PopulateCardTemplateFromUI();
            saveFileDialog1.Filter = "Managed Card (*.crd)|*.crd";
            DialogResult dr = saveFileDialog1.ShowDialog();
            
            string filename = saveFileDialog1.FileName;

            CertificateInfo certInfo = new CertificateInfo();
            certInfo.CommonName = tbCertificateCommonName.Text;
            certInfo.Location = tbCertificateLocation.Text;
            certInfo.Store = tbCertificateStore.Text;
            X509Certificate2 certificate = ManagedCardHelper.RetrieveCertificate(certInfo);

            ManagedCardHelper helper = new ManagedCardHelper();
            
            helper.SaveCard(ict.InformationCardDefinition, certificate, filename);
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            //InformationCard ic = PopulateCard();
            //ManagedCardHelper.SaveCardTemplate(ic, "C:\\MyCard.crdtemplate");
            InformationCardTemplate ic = ManagedCardHelper.LoadCardTemplate("C:\\MyCard.crdtemplate");
        }

        private void saveTemplateToolStripMenuItem_Click(object sender, EventArgs e)
        {
            InformationCardTemplate ict = PopulateCardTemplateFromUI();
            saveFileDialog1.Filter = "Card Templates|*.crdtemplate";
            DialogResult dr = saveFileDialog1.ShowDialog();

            string filename = saveFileDialog1.FileName;
            ManagedCardHelper.SaveCardTemplate(ict, filename);
            
        }

        private void loadExistingTemplateToolStripMenuItem_Click(object sender, EventArgs e)
        {
            openFileDialog1.Filter = "Card Templates|*.crdtemplate";
            DialogResult dr = openFileDialog1.ShowDialog();
            string filename = openFileDialog1.FileName;
            System.IO.FileInfo f = new System.IO.FileInfo(filename);
            if (f.Exists)
            { 
                PopulateUIFromCardTemplate(filename);
            
            }
            else
            { 
                MessageBox.Show("A file by that name does not exist.");
            }

        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void CreateICToolStripMenuItem_Click(object sender, EventArgs e)
        {
            InformationCardTemplate ict = PopulateCardTemplateFromUI();
            saveFileDialog1.Filter = "Managed Card (*.crd)|*.crd";
            DialogResult dr = saveFileDialog1.ShowDialog();

            string filename = saveFileDialog1.FileName;
            ManagedCardHelper.SaveCardTemplate(ict, filename);


             
        }
    
    
    }
}