namespace BeginningCardSpace
{
    partial class AddClaim
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
            this.cboStandardClaims = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.tbUri = new System.Windows.Forms.TextBox();
            this.tbDisplayTag = new System.Windows.Forms.TextBox();
            this.tbDescription = new System.Windows.Forms.TextBox();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.rbCustomClaim = new System.Windows.Forms.RadioButton();
            this.rbStandardClaim = new System.Windows.Forms.RadioButton();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // cboStandardClaims
            // 
            this.cboStandardClaims.FormattingEnabled = true;
            this.cboStandardClaims.Location = new System.Drawing.Point(111, 39);
            this.cboStandardClaims.Name = "cboStandardClaims";
            this.cboStandardClaims.Size = new System.Drawing.Size(300, 21);
            this.cboStandardClaims.TabIndex = 0;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(407, 41);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(16, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "or";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(45, 119);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(20, 13);
            this.label3.TabIndex = 3;
            this.label3.Text = "Uri";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(45, 143);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(63, 13);
            this.label4.TabIndex = 4;
            this.label4.Text = "Display Tag";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.ForeColor = System.Drawing.Color.White;
            this.label5.Location = new System.Drawing.Point(45, 172);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(60, 13);
            this.label5.TabIndex = 5;
            this.label5.Text = "Description";
            // 
            // tbUri
            // 
            this.tbUri.Location = new System.Drawing.Point(111, 112);
            this.tbUri.Name = "tbUri";
            this.tbUri.Size = new System.Drawing.Size(302, 20);
            this.tbUri.TabIndex = 6;
            // 
            // tbDisplayTag
            // 
            this.tbDisplayTag.Location = new System.Drawing.Point(111, 139);
            this.tbDisplayTag.Name = "tbDisplayTag";
            this.tbDisplayTag.Size = new System.Drawing.Size(302, 20);
            this.tbDisplayTag.TabIndex = 7;
            // 
            // tbDescription
            // 
            this.tbDescription.Location = new System.Drawing.Point(111, 166);
            this.tbDescription.Name = "tbDescription";
            this.tbDescription.Size = new System.Drawing.Size(302, 20);
            this.tbDescription.TabIndex = 8;
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(276, 224);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(75, 23);
            this.btnAdd.TabIndex = 11;
            this.btnAdd.Text = "Add";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(358, 224);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 12;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ControlDark;
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.rbCustomClaim);
            this.panel1.Controls.Add(this.cboStandardClaims);
            this.panel1.Controls.Add(this.tbDescription);
            this.panel1.Controls.Add(this.rbStandardClaim);
            this.panel1.Controls.Add(this.tbDisplayTag);
            this.panel1.Controls.Add(this.tbUri);
            this.panel1.Location = new System.Drawing.Point(9, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(428, 206);
            this.panel1.TabIndex = 15;
            // 
            // rbCustomClaim
            // 
            this.rbCustomClaim.AutoSize = true;
            this.rbCustomClaim.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbCustomClaim.ForeColor = System.Drawing.Color.White;
            this.rbCustomClaim.Location = new System.Drawing.Point(9, 69);
            this.rbCustomClaim.Name = "rbCustomClaim";
            this.rbCustomClaim.Size = new System.Drawing.Size(120, 20);
            this.rbCustomClaim.TabIndex = 12;
            this.rbCustomClaim.TabStop = true;
            this.rbCustomClaim.Text = "Custom Claim";
            this.rbCustomClaim.UseVisualStyleBackColor = true;
            // 
            // rbStandardClaim
            // 
            this.rbStandardClaim.AutoSize = true;
            this.rbStandardClaim.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbStandardClaim.ForeColor = System.Drawing.Color.White;
            this.rbStandardClaim.Location = new System.Drawing.Point(9, 10);
            this.rbStandardClaim.Name = "rbStandardClaim";
            this.rbStandardClaim.Size = new System.Drawing.Size(132, 20);
            this.rbStandardClaim.TabIndex = 11;
            this.rbStandardClaim.TabStop = true;
            this.rbStandardClaim.Text = "Standard Claim";
            this.rbStandardClaim.UseVisualStyleBackColor = true;
            // 
            // AddClaim
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(445, 255);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.label2);
            this.Name = "AddClaim";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Specify the Claim to Add";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cboStandardClaims;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox tbUri;
        private System.Windows.Forms.TextBox tbDisplayTag;
        private System.Windows.Forms.TextBox tbDescription;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.RadioButton rbCustomClaim;
        private System.Windows.Forms.RadioButton rbStandardClaim;
    }
}