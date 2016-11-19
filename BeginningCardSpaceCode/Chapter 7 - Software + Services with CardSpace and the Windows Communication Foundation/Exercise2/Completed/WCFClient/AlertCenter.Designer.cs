namespace WindowsApplication2
{
    partial class AlertCenter
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.lbMyAlerts = new System.Windows.Forms.ListBox();
            this.webAlert = new System.Windows.Forms.WebBrowser();
            this.lblTitle = new System.Windows.Forms.Label();
            this.lblMyAlerts = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lbAlerts = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            // 
            // lbMyAlerts
            // 
            this.lbMyAlerts.FormattingEnabled = true;
            this.lbMyAlerts.Location = new System.Drawing.Point(8, 224);
            this.lbMyAlerts.Name = "lbMyAlerts";
            this.lbMyAlerts.Size = new System.Drawing.Size(120, 147);
            this.lbMyAlerts.TabIndex = 0;
            this.lbMyAlerts.SelectedIndexChanged += new System.EventHandler(this.lbMyAlerts_SelectedIndexChanged);
            // 
            // webAlert
            // 
            this.webAlert.Location = new System.Drawing.Point(134, 47);
            this.webAlert.MinimumSize = new System.Drawing.Size(20, 20);
            this.webAlert.Name = "webAlert";
            this.webAlert.Size = new System.Drawing.Size(266, 324);
            this.webAlert.TabIndex = 1;
            // 
            // lblTitle
            // 
            this.lblTitle.BackColor = System.Drawing.Color.LightGray;
            this.lblTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.Location = new System.Drawing.Point(134, 21);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(266, 23);
            this.lblTitle.TabIndex = 2;
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblMyAlerts
            // 
            this.lblMyAlerts.AutoSize = true;
            this.lblMyAlerts.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMyAlerts.Location = new System.Drawing.Point(4, 197);
            this.lblMyAlerts.Name = "lblMyAlerts";
            this.lblMyAlerts.Size = new System.Drawing.Size(87, 24);
            this.lblMyAlerts.TabIndex = 3;
            this.lblMyAlerts.Text = "My Alerts";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(3, 20);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(123, 24);
            this.label2.TabIndex = 7;
            this.label2.Text = "System Alerts";
            // 
            // lbAlerts
            // 
            this.lbAlerts.FormattingEnabled = true;
            this.lbAlerts.Location = new System.Drawing.Point(7, 47);
            this.lbAlerts.Name = "lbAlerts";
            this.lbAlerts.Size = new System.Drawing.Size(120, 147);
            this.lbAlerts.TabIndex = 4;
            this.lbAlerts.SelectedIndexChanged += new System.EventHandler(this.lbAlerts_SelectedIndexChanged);
            // 
            // AlertCenter
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(412, 388);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lbAlerts);
            this.Controls.Add(this.lblMyAlerts);
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.webAlert);
            this.Controls.Add(this.lbMyAlerts);
            this.Name = "AlertCenter";
            this.Text = "Message Center";
            this.Load += new System.EventHandler(this.MessageCenter_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox lbMyAlerts;
        private System.Windows.Forms.WebBrowser webAlert;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblMyAlerts;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ListBox lbAlerts;
    }
}

