using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace WindowsApplication2
{
    public partial class AlertCenter : Form
    {
        public AlertCenter()
        {
            InitializeComponent();
        }

        private void MessageCenter_Load(object sender, EventArgs e)
        {
            AlertServiceClient alertService = new AlertServiceClient();


            DataContracts.Alert[] systemAlerts = alertService.GetAlerts();

            foreach (DataContracts.Alert alert in systemAlerts)
            {
                lbAlerts.Items.Add(alert);
                lbAlerts.DisplayMember = "Title";

            }


        
        }






        private void lbAlerts_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lbAlerts.SelectedIndex > -1)
            {
                DataContracts.Alert alert = (DataContracts.Alert)lbAlerts.Items[lbAlerts.SelectedIndex];
                webAlert.DocumentText = alert.AlertHTML;
                lblTitle.Text = alert.Title;


            }
        }
    }
}