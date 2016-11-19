using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace BeginningCardSpace
{
    public partial class AddClaim : Form
    {
        private CardClaim _claim;

        public AddClaim()
        {
            InitializeComponent();
            cboStandardClaims.DisplayMember = "DisplayTag";
            List<CardClaim> standardClaims = ManagedCardHelper.GetStandardClaims();
            
            foreach (CardClaim claim in standardClaims)
            {
                
                cboStandardClaims.Items.Add(claim);
                
            }
         
        
        }

        public new CardClaim ShowDialog()
        {
            base.ShowDialog();


            return _claim;

        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            _claim = null;
            Close();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
           
            if (cboStandardClaims.SelectedIndex > -1)
            {
                _claim = (CardClaim)cboStandardClaims.SelectedItem;
                _claim.Value = tbClaimValue.Text;
            }
            else
            {
                _claim = new CardClaim();
                _claim.Description = tbDescription.Text;
                _claim.DisplayTag = tbDisplayTag.Text;
                _claim.Uri = tbUri.Text;
                _claim.Value = tbClaimValue.Text;

            }
            Close();
        }
    }
}