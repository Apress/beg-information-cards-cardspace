namespace RSSClient
{
    partial class frmMain
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.btnRetrieveFeed = new System.Windows.Forms.Button();
            this.btnGetOPML = new System.Windows.Forms.Button();
            this.webBrowser1 = new System.Windows.Forms.WebBrowser();
            this.lblItemTitle = new System.Windows.Forms.Label();
            this.lblChannelTitle = new System.Windows.Forms.Label();
            this.dgvOPML = new System.Windows.Forms.DataGridView();
            this.Check = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.text = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.description = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.xmlUrl = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.type = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.version = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.categories = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.datagridItems = new System.Windows.Forms.DataGridView();
            this.Date = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Title = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Duration = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Rating = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lblChannelSummary = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvOPML)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.datagridItems)).BeginInit();
            this.SuspendLayout();
            // 
            // btnRetrieveFeed
            // 
            this.btnRetrieveFeed.Location = new System.Drawing.Point(96, 520);
            this.btnRetrieveFeed.Name = "btnRetrieveFeed";
            this.btnRetrieveFeed.Size = new System.Drawing.Size(75, 23);
            this.btnRetrieveFeed.TabIndex = 0;
            this.btnRetrieveFeed.Text = "Get Feed";
            this.btnRetrieveFeed.UseVisualStyleBackColor = true;
            this.btnRetrieveFeed.Click += new System.EventHandler(this.btnRetrieveFeed_Click);
            // 
            // btnGetOPML
            // 
            this.btnGetOPML.Location = new System.Drawing.Point(8, 520);
            this.btnGetOPML.Name = "btnGetOPML";
            this.btnGetOPML.Size = new System.Drawing.Size(75, 23);
            this.btnGetOPML.TabIndex = 1;
            this.btnGetOPML.Text = "Get OPML";
            this.btnGetOPML.UseVisualStyleBackColor = true;
            this.btnGetOPML.Click += new System.EventHandler(this.btnGetOPML_Click);
            // 
            // webBrowser1
            // 
            this.webBrowser1.Location = new System.Drawing.Point(177, 281);
            this.webBrowser1.MinimumSize = new System.Drawing.Size(20, 20);
            this.webBrowser1.Name = "webBrowser1";
            this.webBrowser1.Size = new System.Drawing.Size(726, 277);
            this.webBrowser1.TabIndex = 3;
            // 
            // lblItemTitle
            // 
            this.lblItemTitle.AutoSize = true;
            this.lblItemTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblItemTitle.Location = new System.Drawing.Point(177, 254);
            this.lblItemTitle.Name = "lblItemTitle";
            this.lblItemTitle.Size = new System.Drawing.Size(85, 24);
            this.lblItemTitle.TabIndex = 5;
            this.lblItemTitle.Text = "Item Title";
            // 
            // lblChannelTitle
            // 
            this.lblChannelTitle.AutoSize = true;
            this.lblChannelTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblChannelTitle.Location = new System.Drawing.Point(177, 9);
            this.lblChannelTitle.Name = "lblChannelTitle";
            this.lblChannelTitle.Size = new System.Drawing.Size(121, 24);
            this.lblChannelTitle.TabIndex = 7;
            this.lblChannelTitle.Text = "Channel Title";
            // 
            // dgvOPML
            // 
            this.dgvOPML.AllowUserToAddRows = false;
            this.dgvOPML.AllowUserToDeleteRows = false;
            this.dgvOPML.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.Transparent;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvOPML.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvOPML.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvOPML.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Check,
            this.text,
            this.description,
            this.xmlUrl,
            this.type,
            this.version,
            this.categories});
            this.dgvOPML.GridColor = System.Drawing.SystemColors.Control;
            this.dgvOPML.Location = new System.Drawing.Point(8, 8);
            this.dgvOPML.Name = "dgvOPML";
            this.dgvOPML.ReadOnly = true;
            this.dgvOPML.RowHeadersVisible = false;
            this.dgvOPML.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.dgvOPML.Size = new System.Drawing.Size(163, 506);
            this.dgvOPML.TabIndex = 8;
            this.dgvOPML.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvOPML_CellContentClick);
            // 
            // Check
            // 
            this.Check.HeaderText = "";
            this.Check.Name = "Check";
            this.Check.ReadOnly = true;
            this.Check.Visible = false;
            // 
            // text
            // 
            this.text.HeaderText = "Title";
            this.text.Name = "text";
            this.text.ReadOnly = true;
            this.text.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.text.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // description
            // 
            this.description.HeaderText = "description";
            this.description.Name = "description";
            this.description.ReadOnly = true;
            this.description.Visible = false;
            // 
            // xmlUrl
            // 
            this.xmlUrl.HeaderText = "xmlUrl";
            this.xmlUrl.Name = "xmlUrl";
            this.xmlUrl.ReadOnly = true;
            this.xmlUrl.Visible = false;
            // 
            // type
            // 
            this.type.HeaderText = "type";
            this.type.Name = "type";
            this.type.ReadOnly = true;
            this.type.Visible = false;
            // 
            // version
            // 
            this.version.HeaderText = "version";
            this.version.Name = "version";
            this.version.ReadOnly = true;
            this.version.Visible = false;
            // 
            // categories
            // 
            this.categories.HeaderText = "categories";
            this.categories.Name = "categories";
            this.categories.ReadOnly = true;
            this.categories.Visible = false;
            // 
            // datagridItems
            // 
            this.datagridItems.AllowUserToAddRows = false;
            this.datagridItems.AllowUserToDeleteRows = false;
            this.datagridItems.AllowUserToResizeRows = false;
            this.datagridItems.BackgroundColor = System.Drawing.Color.CornflowerBlue;
            this.datagridItems.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.datagridItems.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Sunken;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.LightSteelBlue;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.datagridItems.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.datagridItems.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.datagridItems.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Date,
            this.Title,
            this.dataGridViewTextBoxColumn1,
            this.Duration,
            this.Rating});
            this.datagridItems.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.datagridItems.GridColor = System.Drawing.Color.CornflowerBlue;
            this.datagridItems.Location = new System.Drawing.Point(177, 62);
            this.datagridItems.MultiSelect = false;
            this.datagridItems.Name = "datagridItems";
            this.datagridItems.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Sunken;
            this.datagridItems.RowHeadersVisible = false;
            this.datagridItems.RowTemplate.DefaultCellStyle.BackColor = System.Drawing.Color.Silver;
            this.datagridItems.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.datagridItems.Size = new System.Drawing.Size(729, 180);
            this.datagridItems.TabIndex = 53;
            this.datagridItems.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.datagridItems_CellContentClick);
            // 
            // Date
            // 
            this.Date.HeaderText = "Date";
            this.Date.Name = "Date";
            this.Date.Width = 75;
            // 
            // Title
            // 
            this.Title.HeaderText = "Title";
            this.Title.Name = "Title";
            this.Title.Width = 200;
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.HeaderText = "Description";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.Width = 300;
            // 
            // Duration
            // 
            this.Duration.HeaderText = "Duration";
            this.Duration.Name = "Duration";
            this.Duration.Width = 75;
            // 
            // Rating
            // 
            this.Rating.HeaderText = "Rating";
            this.Rating.Name = "Rating";
            this.Rating.Width = 75;
            // 
            // lblChannelSummary
            // 
            this.lblChannelSummary.AutoSize = true;
            this.lblChannelSummary.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblChannelSummary.Location = new System.Drawing.Point(179, 42);
            this.lblChannelSummary.Name = "lblChannelSummary";
            this.lblChannelSummary.Size = new System.Drawing.Size(123, 17);
            this.lblChannelSummary.TabIndex = 54;
            this.lblChannelSummary.Text = "Channel Sumamry";
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(915, 570);
            this.Controls.Add(this.lblChannelSummary);
            this.Controls.Add(this.datagridItems);
            this.Controls.Add(this.dgvOPML);
            this.Controls.Add(this.lblChannelTitle);
            this.Controls.Add(this.lblItemTitle);
            this.Controls.Add(this.webBrowser1);
            this.Controls.Add(this.btnGetOPML);
            this.Controls.Add(this.btnRetrieveFeed);
            this.Name = "frmMain";
            this.Text = "CardSpaceRSS";
            ((System.ComponentModel.ISupportInitialize)(this.dgvOPML)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.datagridItems)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnRetrieveFeed;
        private System.Windows.Forms.Button btnGetOPML;
        private System.Windows.Forms.WebBrowser webBrowser1;
        private System.Windows.Forms.Label lblItemTitle;
        private System.Windows.Forms.Label lblChannelTitle;
        private System.Windows.Forms.DataGridView dgvOPML;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Check;
        private System.Windows.Forms.DataGridViewTextBoxColumn text;
        private System.Windows.Forms.DataGridViewTextBoxColumn description;
        private System.Windows.Forms.DataGridViewTextBoxColumn xmlUrl;
        private System.Windows.Forms.DataGridViewTextBoxColumn type;
        private System.Windows.Forms.DataGridViewTextBoxColumn version;
        private System.Windows.Forms.DataGridViewTextBoxColumn categories;
        private System.Windows.Forms.DataGridView datagridItems;
        private System.Windows.Forms.DataGridViewTextBoxColumn Date;
        private System.Windows.Forms.DataGridViewTextBoxColumn Title;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Duration;
        private System.Windows.Forms.DataGridViewTextBoxColumn Rating;
        private System.Windows.Forms.Label lblChannelSummary;
    }
}

