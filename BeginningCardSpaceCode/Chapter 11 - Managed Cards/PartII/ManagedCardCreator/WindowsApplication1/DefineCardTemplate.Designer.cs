namespace BeginningCardSpace
{
    partial class DefineCardTemplate
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.tbCardName = new System.Windows.Forms.TextBox();
            this.tbCardID = new System.Windows.Forms.TextBox();
            this.tbCardVersion = new System.Windows.Forms.TextBox();
            this.tbCardImage = new System.Windows.Forms.TextBox();
            this.tbIssuer = new System.Windows.Forms.TextBox();
            this.tbIssuerName = new System.Windows.Forms.TextBox();
            this.dtpTimeIssued = new System.Windows.Forms.DateTimePicker();
            this.dtpTimeExpires = new System.Windows.Forms.DateTimePicker();
            this.dgvTokenServiceList = new System.Windows.Forms.DataGridView();
            this.Address = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Mex = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Identity = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CredentialType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Value = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DisplayCredentialHint = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.picCardImagePreview = new System.Windows.Forms.PictureBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.dgvClaims = new System.Windows.Forms.DataGridView();
            this.Uri = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DisplayTag = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Description = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ClaimValue = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tbPrivacyPolicy = new System.Windows.Forms.TextBox();
            this.btnCardImage = new System.Windows.Forms.Button();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.picCardImagePreviewSmall = new System.Windows.Forms.PictureBox();
            this.label13 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.btnAddTokenService = new System.Windows.Forms.Button();
            this.btnRemoveTokenService = new System.Windows.Forms.Button();
            this.btnAddClaim = new System.Windows.Forms.Button();
            this.btnRemoveClaim = new System.Windows.Forms.Button();
            this.cbRequireAppliesTo = new System.Windows.Forms.CheckBox();
            this.label15 = new System.Windows.Forms.Label();
            this.btnCreatCard = new System.Windows.Forms.Button();
            this.btnSaveTemplate = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.cblSAML10 = new System.Windows.Forms.CheckBox();
            this.cbSAML11 = new System.Windows.Forms.CheckBox();
            this.label16 = new System.Windows.Forms.Label();
            this.tbCertificatePath = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTokenServiceList)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picCardImagePreview)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvClaims)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picCardImagePreviewSmall)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(18, 52);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(43, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Card ID";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(18, 26);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(60, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Card Name";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(19, 101);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(61, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Card Image";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(19, 78);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(67, 13);
            this.label4.TabIndex = 3;
            this.label4.Text = "Card Version";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(18, 126);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(35, 13);
            this.label5.TabIndex = 4;
            this.label5.Text = "Issuer";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(18, 155);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(66, 13);
            this.label6.TabIndex = 5;
            this.label6.Text = "Issuer Name";
            this.label6.Visible = false;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(18, 182);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(64, 13);
            this.label7.TabIndex = 6;
            this.label7.Text = "Time Issued";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(19, 208);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(67, 13);
            this.label8.TabIndex = 7;
            this.label8.Text = "Time Expires";
            // 
            // tbCardName
            // 
            this.tbCardName.Location = new System.Drawing.Point(102, 19);
            this.tbCardName.Name = "tbCardName";
            this.tbCardName.Size = new System.Drawing.Size(262, 20);
            this.tbCardName.TabIndex = 8;
            this.tbCardName.Text = "ReaderCard (Username and Password)";
            // 
            // tbCardID
            // 
            this.tbCardID.Location = new System.Drawing.Point(102, 45);
            this.tbCardID.Name = "tbCardID";
            this.tbCardID.Size = new System.Drawing.Size(262, 20);
            this.tbCardID.TabIndex = 9;
            this.tbCardID.Text = "http://www.fabrikam.com/readercard/";
            // 
            // tbCardVersion
            // 
            this.tbCardVersion.Location = new System.Drawing.Point(102, 71);
            this.tbCardVersion.Name = "tbCardVersion";
            this.tbCardVersion.Size = new System.Drawing.Size(262, 20);
            this.tbCardVersion.TabIndex = 10;
            this.tbCardVersion.Text = "1";
            // 
            // tbCardImage
            // 
            this.tbCardImage.Location = new System.Drawing.Point(102, 94);
            this.tbCardImage.Name = "tbCardImage";
            this.tbCardImage.Size = new System.Drawing.Size(224, 20);
            this.tbCardImage.TabIndex = 11;
            // 
            // tbIssuer
            // 
            this.tbIssuer.Location = new System.Drawing.Point(102, 119);
            this.tbIssuer.Name = "tbIssuer";
            this.tbIssuer.Size = new System.Drawing.Size(262, 20);
            this.tbIssuer.TabIndex = 12;
            this.tbIssuer.Text = "http://www.fabrikam.com:6700/unap/sts";
            // 
            // tbIssuerName
            // 
            this.tbIssuerName.Location = new System.Drawing.Point(102, 148);
            this.tbIssuerName.Name = "tbIssuerName";
            this.tbIssuerName.Size = new System.Drawing.Size(262, 20);
            this.tbIssuerName.TabIndex = 13;
            this.tbIssuerName.Text = "Fabrikam";
            this.tbIssuerName.Visible = false;
            // 
            // dtpTimeIssued
            // 
            this.dtpTimeIssued.Location = new System.Drawing.Point(102, 175);
            this.dtpTimeIssued.Name = "dtpTimeIssued";
            this.dtpTimeIssued.Size = new System.Drawing.Size(262, 20);
            this.dtpTimeIssued.TabIndex = 14;
            // 
            // dtpTimeExpires
            // 
            this.dtpTimeExpires.Location = new System.Drawing.Point(102, 201);
            this.dtpTimeExpires.Name = "dtpTimeExpires";
            this.dtpTimeExpires.Size = new System.Drawing.Size(262, 20);
            this.dtpTimeExpires.TabIndex = 15;
            this.dtpTimeExpires.Value = new System.DateTime(2009, 1, 23, 20, 53, 0, 0);
            // 
            // dgvTokenServiceList
            // 
            this.dgvTokenServiceList.AllowUserToAddRows = false;
            this.dgvTokenServiceList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvTokenServiceList.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Address,
            this.Mex,
            this.Identity,
            this.CredentialType,
            this.Value,
            this.DisplayCredentialHint});
            this.dgvTokenServiceList.Location = new System.Drawing.Point(102, 282);
            this.dgvTokenServiceList.Name = "dgvTokenServiceList";
            this.dgvTokenServiceList.RowHeadersVisible = false;
            this.dgvTokenServiceList.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvTokenServiceList.Size = new System.Drawing.Size(603, 91);
            this.dgvTokenServiceList.TabIndex = 16;
            // 
            // Address
            // 
            this.Address.HeaderText = "Address";
            this.Address.Name = "Address";
            // 
            // Mex
            // 
            this.Mex.HeaderText = "Mex";
            this.Mex.Name = "Mex";
            // 
            // Identity
            // 
            this.Identity.HeaderText = "Identity";
            this.Identity.Name = "Identity";
            // 
            // CredentialType
            // 
            this.CredentialType.HeaderText = "Credential Type";
            this.CredentialType.Name = "CredentialType";
            // 
            // Value
            // 
            this.Value.HeaderText = "Value";
            this.Value.Name = "Value";
            // 
            // DisplayCredentialHint
            // 
            this.DisplayCredentialHint.HeaderText = "Display Credential Hint";
            this.DisplayCredentialHint.Name = "DisplayCredentialHint";
            // 
            // picCardImagePreview
            // 
            this.picCardImagePreview.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.picCardImagePreview.Location = new System.Drawing.Point(441, 37);
            this.picCardImagePreview.Name = "picCardImagePreview";
            this.picCardImagePreview.Size = new System.Drawing.Size(120, 80);
            this.picCardImagePreview.TabIndex = 17;
            this.picCardImagePreview.TabStop = false;
            this.picCardImagePreview.WaitOnLoad = true;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(525, 9);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(102, 13);
            this.label9.TabIndex = 18;
            this.label9.Text = "Card Image Preview";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(19, 234);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(73, 13);
            this.label10.TabIndex = 19;
            this.label10.Text = "Privacy Policy";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(19, 260);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(96, 13);
            this.label11.TabIndex = 20;
            this.label11.Text = "Token Service List";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(12, 487);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(37, 13);
            this.label12.TabIndex = 21;
            this.label12.Text = "Claims";
            // 
            // dgvClaims
            // 
            this.dgvClaims.AllowUserToAddRows = false;
            this.dgvClaims.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvClaims.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Uri,
            this.DisplayTag,
            this.Description,
            this.ClaimValue});
            this.dgvClaims.Location = new System.Drawing.Point(102, 500);
            this.dgvClaims.Name = "dgvClaims";
            this.dgvClaims.RowHeadersVisible = false;
            this.dgvClaims.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvClaims.Size = new System.Drawing.Size(410, 106);
            this.dgvClaims.TabIndex = 22;
            // 
            // Uri
            // 
            this.Uri.HeaderText = "Uri";
            this.Uri.Name = "Uri";
            // 
            // DisplayTag
            // 
            this.DisplayTag.HeaderText = "Display Tag";
            this.DisplayTag.Name = "DisplayTag";
            // 
            // Description
            // 
            this.Description.HeaderText = "Description";
            this.Description.Name = "Description";
            // 
            // ClaimValue
            // 
            this.ClaimValue.HeaderText = "Value";
            this.ClaimValue.Name = "ClaimValue";
            // 
            // tbPrivacyPolicy
            // 
            this.tbPrivacyPolicy.Location = new System.Drawing.Point(102, 227);
            this.tbPrivacyPolicy.Name = "tbPrivacyPolicy";
            this.tbPrivacyPolicy.Size = new System.Drawing.Size(262, 20);
            this.tbPrivacyPolicy.TabIndex = 23;
            this.tbPrivacyPolicy.Text = "http://www.fabrikam.com/privacy/PrivacyPolicy.xml";
            // 
            // btnCardImage
            // 
            this.btnCardImage.Location = new System.Drawing.Point(328, 94);
            this.btnCardImage.Name = "btnCardImage";
            this.btnCardImage.Size = new System.Drawing.Size(32, 23);
            this.btnCardImage.TabIndex = 24;
            this.btnCardImage.Text = "...";
            this.btnCardImage.UseVisualStyleBackColor = true;
            this.btnCardImage.Click += new System.EventHandler(this.btnCardImage_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // picCardImagePreviewSmall
            // 
            this.picCardImagePreviewSmall.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.picCardImagePreviewSmall.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.picCardImagePreviewSmall.Location = new System.Drawing.Point(591, 37);
            this.picCardImagePreviewSmall.Name = "picCardImagePreviewSmall";
            this.picCardImagePreviewSmall.Size = new System.Drawing.Size(90, 60);
            this.picCardImagePreviewSmall.TabIndex = 25;
            this.picCardImagePreviewSmall.TabStop = false;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(476, 120);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(42, 13);
            this.label13.TabIndex = 26;
            this.label13.Text = "120x80";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(615, 104);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(36, 13);
            this.label14.TabIndex = 27;
            this.label14.Text = "90x60";
            // 
            // btnAddTokenService
            // 
            this.btnAddTokenService.Location = new System.Drawing.Point(711, 280);
            this.btnAddTokenService.Name = "btnAddTokenService";
            this.btnAddTokenService.Size = new System.Drawing.Size(29, 23);
            this.btnAddTokenService.TabIndex = 28;
            this.btnAddTokenService.Text = "+";
            this.btnAddTokenService.UseVisualStyleBackColor = true;
            this.btnAddTokenService.Click += new System.EventHandler(this.btnAddTokenService_Click);
            // 
            // btnRemoveTokenService
            // 
            this.btnRemoveTokenService.Location = new System.Drawing.Point(711, 311);
            this.btnRemoveTokenService.Name = "btnRemoveTokenService";
            this.btnRemoveTokenService.Size = new System.Drawing.Size(29, 23);
            this.btnRemoveTokenService.TabIndex = 29;
            this.btnRemoveTokenService.Text = "-";
            this.btnRemoveTokenService.UseVisualStyleBackColor = true;
            this.btnRemoveTokenService.Click += new System.EventHandler(this.btnRemoveTokenService_Click);
            // 
            // btnAddClaim
            // 
            this.btnAddClaim.Location = new System.Drawing.Point(518, 499);
            this.btnAddClaim.Name = "btnAddClaim";
            this.btnAddClaim.Size = new System.Drawing.Size(29, 23);
            this.btnAddClaim.TabIndex = 30;
            this.btnAddClaim.Text = "+";
            this.btnAddClaim.UseVisualStyleBackColor = true;
            this.btnAddClaim.Click += new System.EventHandler(this.btnAddClaim_Click);
            // 
            // btnRemoveClaim
            // 
            this.btnRemoveClaim.Location = new System.Drawing.Point(518, 528);
            this.btnRemoveClaim.Name = "btnRemoveClaim";
            this.btnRemoveClaim.Size = new System.Drawing.Size(29, 23);
            this.btnRemoveClaim.TabIndex = 31;
            this.btnRemoveClaim.Text = "-";
            this.btnRemoveClaim.UseVisualStyleBackColor = true;
            this.btnRemoveClaim.Click += new System.EventHandler(this.btnRemoveClaim_Click);
            // 
            // cbRequireAppliesTo
            // 
            this.cbRequireAppliesTo.AutoSize = true;
            this.cbRequireAppliesTo.Location = new System.Drawing.Point(14, 621);
            this.cbRequireAppliesTo.Name = "cbRequireAppliesTo";
            this.cbRequireAppliesTo.Size = new System.Drawing.Size(350, 17);
            this.cbRequireAppliesTo.TabIndex = 32;
            this.cbRequireAppliesTo.Text = "The identity provider may require relying parties to identify themselves";
            this.cbRequireAppliesTo.UseVisualStyleBackColor = true;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(18, 401);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(122, 13);
            this.label15.TabIndex = 33;
            this.label15.Text = "Supported Token Types";
            // 
            // btnCreatCard
            // 
            this.btnCreatCard.Location = new System.Drawing.Point(540, 699);
            this.btnCreatCard.Name = "btnCreatCard";
            this.btnCreatCard.Size = new System.Drawing.Size(93, 23);
            this.btnCreatCard.TabIndex = 35;
            this.btnCreatCard.Text = "Create Card";
            this.btnCreatCard.UseVisualStyleBackColor = true;
            this.btnCreatCard.Visible = false;
            this.btnCreatCard.Click += new System.EventHandler(this.btnCreatCard_Click);
            // 
            // btnSaveTemplate
            // 
            this.btnSaveTemplate.Location = new System.Drawing.Point(441, 699);
            this.btnSaveTemplate.Name = "btnSaveTemplate";
            this.btnSaveTemplate.Size = new System.Drawing.Size(93, 23);
            this.btnSaveTemplate.TabIndex = 36;
            this.btnSaveTemplate.Text = "Save Template";
            this.btnSaveTemplate.UseVisualStyleBackColor = true;
            this.btnSaveTemplate.Visible = false;
            this.btnSaveTemplate.Click += new System.EventHandler(this.btnSaveTemplate_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(639, 699);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(93, 23);
            this.btnCancel.TabIndex = 37;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Visible = false;
            // 
            // cblSAML10
            // 
            this.cblSAML10.AutoSize = true;
            this.cblSAML10.Checked = true;
            this.cblSAML10.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cblSAML10.Location = new System.Drawing.Point(102, 434);
            this.cblSAML10.Name = "cblSAML10";
            this.cblSAML10.Size = new System.Drawing.Size(73, 17);
            this.cblSAML10.TabIndex = 38;
            this.cblSAML10.Text = "SAML 1.0";
            this.cblSAML10.UseVisualStyleBackColor = true;
            // 
            // cbSAML11
            // 
            this.cbSAML11.AutoSize = true;
            this.cbSAML11.Location = new System.Drawing.Point(102, 457);
            this.cbSAML11.Name = "cbSAML11";
            this.cbSAML11.Size = new System.Drawing.Size(73, 17);
            this.cbSAML11.TabIndex = 39;
            this.cbSAML11.Text = "SAML 1.1";
            this.cbSAML11.UseVisualStyleBackColor = true;
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(12, 656);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(79, 13);
            this.label16.TabIndex = 40;
            this.label16.Text = "Certificate Path";
            // 
            // tbCertificatePath
            // 
            this.tbCertificatePath.Location = new System.Drawing.Point(102, 653);
            this.tbCertificatePath.Name = "tbCertificatePath";
            this.tbCertificatePath.Size = new System.Drawing.Size(262, 20);
            this.tbCertificatePath.TabIndex = 41;
            this.tbCertificatePath.Text = "LOCALMACHINE/MY/www.fabrikam.com";
            // 
            // DefineCardTemplate
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(756, 734);
            this.Controls.Add(this.tbCertificatePath);
            this.Controls.Add(this.label16);
            this.Controls.Add(this.cbSAML11);
            this.Controls.Add(this.cblSAML10);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnSaveTemplate);
            this.Controls.Add(this.btnCreatCard);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.cbRequireAppliesTo);
            this.Controls.Add(this.btnRemoveClaim);
            this.Controls.Add(this.btnAddClaim);
            this.Controls.Add(this.btnRemoveTokenService);
            this.Controls.Add(this.btnAddTokenService);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.picCardImagePreviewSmall);
            this.Controls.Add(this.btnCardImage);
            this.Controls.Add(this.tbPrivacyPolicy);
            this.Controls.Add(this.dgvClaims);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.picCardImagePreview);
            this.Controls.Add(this.dgvTokenServiceList);
            this.Controls.Add(this.dtpTimeExpires);
            this.Controls.Add(this.dtpTimeIssued);
            this.Controls.Add(this.tbIssuerName);
            this.Controls.Add(this.tbIssuer);
            this.Controls.Add(this.tbCardImage);
            this.Controls.Add(this.tbCardVersion);
            this.Controls.Add(this.tbCardID);
            this.Controls.Add(this.tbCardName);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "DefineCardTemplate";
            this.Text = "Managed Card Creator";
            ((System.ComponentModel.ISupportInitialize)(this.dgvTokenServiceList)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picCardImagePreview)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvClaims)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picCardImagePreviewSmall)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox tbCardName;
        private System.Windows.Forms.TextBox tbCardID;
        private System.Windows.Forms.TextBox tbCardVersion;
        private System.Windows.Forms.TextBox tbCardImage;
        private System.Windows.Forms.TextBox tbIssuer;
        private System.Windows.Forms.TextBox tbIssuerName;
        private System.Windows.Forms.DateTimePicker dtpTimeIssued;
        private System.Windows.Forms.DateTimePicker dtpTimeExpires;
        private System.Windows.Forms.DataGridView dgvTokenServiceList;
        private System.Windows.Forms.PictureBox picCardImagePreview;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.DataGridView dgvClaims;
        private System.Windows.Forms.TextBox tbPrivacyPolicy;
        private System.Windows.Forms.Button btnCardImage;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.PictureBox picCardImagePreviewSmall;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Button btnAddTokenService;
        private System.Windows.Forms.Button btnRemoveTokenService;
        private System.Windows.Forms.Button btnAddClaim;
        private System.Windows.Forms.Button btnRemoveClaim;
        private System.Windows.Forms.DataGridViewTextBoxColumn Address;
        private System.Windows.Forms.DataGridViewTextBoxColumn Mex;
        private System.Windows.Forms.DataGridViewTextBoxColumn Identity;
        private System.Windows.Forms.DataGridViewTextBoxColumn CredentialType;
        private System.Windows.Forms.DataGridViewTextBoxColumn Value;
        private System.Windows.Forms.DataGridViewTextBoxColumn DisplayCredentialHint;
        private System.Windows.Forms.DataGridViewTextBoxColumn Uri;
        private System.Windows.Forms.DataGridViewTextBoxColumn DisplayTag;
        private System.Windows.Forms.DataGridViewTextBoxColumn Description;
        private System.Windows.Forms.DataGridViewTextBoxColumn ClaimValue;
        private System.Windows.Forms.CheckBox cbRequireAppliesTo;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Button btnCreatCard;
        private System.Windows.Forms.Button btnSaveTemplate;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.CheckBox cblSAML10;
        private System.Windows.Forms.CheckBox cbSAML11;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.TextBox tbCertificatePath;
    }
}

