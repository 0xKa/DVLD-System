namespace DVLD_v1._0
{
    partial class frmDetainLicense
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
            this.lblCreatedByUsername = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.lblDetainDate = new System.Windows.Forms.Label();
            this.llShowNewLicense = new System.Windows.Forms.LinkLabel();
            this.llShowLicenseHistory = new System.Windows.Forms.LinkLabel();
            this.btnDetain = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.lblLicenseID = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lblDetainID = new System.Windows.Forms.Label();
            this.gbLicenseReplacementApplicationInfo = new System.Windows.Forms.GroupBox();
            this.txbFineFees = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.lblTitle = new System.Windows.Forms.Label();
            this.ctrlLicenseCardWithFilter1 = new DVLD_v1._0.ctrlLicenseCardWithFilter();
            this.gbLicenseReplacementApplicationInfo.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblCreatedByUsername
            // 
            this.lblCreatedByUsername.Font = new System.Drawing.Font("Consolas", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCreatedByUsername.ForeColor = System.Drawing.Color.Black;
            this.lblCreatedByUsername.Location = new System.Drawing.Point(354, 61);
            this.lblCreatedByUsername.Name = "lblCreatedByUsername";
            this.lblCreatedByUsername.Size = new System.Drawing.Size(135, 20);
            this.lblCreatedByUsername.TabIndex = 66;
            this.lblCreatedByUsername.Text = "[????]";
            // 
            // label9
            // 
            this.label9.Font = new System.Drawing.Font("Consolas", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ForeColor = System.Drawing.Color.White;
            this.label9.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.label9.Location = new System.Drawing.Point(234, 61);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(114, 20);
            this.label9.TabIndex = 67;
            this.label9.Text = "Created By:";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label11
            // 
            this.label11.Font = new System.Drawing.Font("Consolas", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.ForeColor = System.Drawing.Color.Red;
            this.label11.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.label11.Location = new System.Drawing.Point(532, 25);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(195, 23);
            this.label11.TabIndex = 65;
            this.label11.Text = "Fine Fees:";
            this.label11.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label7
            // 
            this.label7.Font = new System.Drawing.Font("Consolas", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.White;
            this.label7.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.label7.Location = new System.Drawing.Point(234, 29);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(114, 20);
            this.label7.TabIndex = 55;
            this.label7.Text = "Detain Date:";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblDetainDate
            // 
            this.lblDetainDate.Font = new System.Drawing.Font("Consolas", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDetainDate.ForeColor = System.Drawing.Color.Black;
            this.lblDetainDate.Location = new System.Drawing.Point(354, 29);
            this.lblDetainDate.Name = "lblDetainDate";
            this.lblDetainDate.Size = new System.Drawing.Size(135, 20);
            this.lblDetainDate.TabIndex = 54;
            this.lblDetainDate.Text = "[????]";
            // 
            // llShowNewLicense
            // 
            this.llShowNewLicense.AutoSize = true;
            this.llShowNewLicense.Enabled = false;
            this.llShowNewLicense.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.llShowNewLicense.Location = new System.Drawing.Point(651, 353);
            this.llShowNewLicense.Name = "llShowNewLicense";
            this.llShowNewLicense.Size = new System.Drawing.Size(162, 19);
            this.llShowNewLicense.TabIndex = 99;
            this.llShowNewLicense.TabStop = true;
            this.llShowNewLicense.Text = "Show License Info";
            this.llShowNewLicense.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.llShowNewLicense_LinkClicked);
            // 
            // llShowLicenseHistory
            // 
            this.llShowLicenseHistory.AutoSize = true;
            this.llShowLicenseHistory.Enabled = false;
            this.llShowLicenseHistory.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.llShowLicenseHistory.Location = new System.Drawing.Point(624, 323);
            this.llShowLicenseHistory.Name = "llShowLicenseHistory";
            this.llShowLicenseHistory.Size = new System.Drawing.Size(189, 19);
            this.llShowLicenseHistory.TabIndex = 98;
            this.llShowLicenseHistory.TabStop = true;
            this.llShowLicenseHistory.Text = "Show License History";
            this.llShowLicenseHistory.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.llShowLicenseHistory_LinkClicked);
            // 
            // btnDetain
            // 
            this.btnDetain.Enabled = false;
            this.btnDetain.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDetain.ImageKey = "(none)";
            this.btnDetain.Location = new System.Drawing.Point(810, 390);
            this.btnDetain.Name = "btnDetain";
            this.btnDetain.Size = new System.Drawing.Size(193, 42);
            this.btnDetain.TabIndex = 97;
            this.btnDetain.Text = "Detain";
            this.btnDetain.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnDetain.UseVisualStyleBackColor = true;
            this.btnDetain.Click += new System.EventHandler(this.btnDetain_Click);
            // 
            // btnClose
            // 
            this.btnClose.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.ImageKey = "(none)";
            this.btnClose.Location = new System.Drawing.Point(810, 440);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(193, 42);
            this.btnClose.TabIndex = 96;
            this.btnClose.Text = "Close";
            this.btnClose.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // lblLicenseID
            // 
            this.lblLicenseID.Font = new System.Drawing.Font("Consolas", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLicenseID.ForeColor = System.Drawing.Color.Black;
            this.lblLicenseID.Location = new System.Drawing.Point(127, 61);
            this.lblLicenseID.Name = "lblLicenseID";
            this.lblLicenseID.Size = new System.Drawing.Size(86, 20);
            this.lblLicenseID.TabIndex = 50;
            this.lblLicenseID.Text = "[????]";
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Consolas", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.label2.Location = new System.Drawing.Point(21, 61);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(100, 20);
            this.label2.TabIndex = 51;
            this.label2.Text = "License ID:";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblDetainID
            // 
            this.lblDetainID.Font = new System.Drawing.Font("Consolas", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDetainID.ForeColor = System.Drawing.Color.Black;
            this.lblDetainID.Location = new System.Drawing.Point(127, 29);
            this.lblDetainID.Name = "lblDetainID";
            this.lblDetainID.Size = new System.Drawing.Size(86, 20);
            this.lblDetainID.TabIndex = 48;
            this.lblDetainID.Text = "[????]";
            // 
            // gbLicenseReplacementApplicationInfo
            // 
            this.gbLicenseReplacementApplicationInfo.Controls.Add(this.txbFineFees);
            this.gbLicenseReplacementApplicationInfo.Controls.Add(this.lblCreatedByUsername);
            this.gbLicenseReplacementApplicationInfo.Controls.Add(this.label9);
            this.gbLicenseReplacementApplicationInfo.Controls.Add(this.label11);
            this.gbLicenseReplacementApplicationInfo.Controls.Add(this.label7);
            this.gbLicenseReplacementApplicationInfo.Controls.Add(this.lblDetainDate);
            this.gbLicenseReplacementApplicationInfo.Controls.Add(this.lblLicenseID);
            this.gbLicenseReplacementApplicationInfo.Controls.Add(this.label2);
            this.gbLicenseReplacementApplicationInfo.Controls.Add(this.lblDetainID);
            this.gbLicenseReplacementApplicationInfo.Controls.Add(this.label3);
            this.gbLicenseReplacementApplicationInfo.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbLicenseReplacementApplicationInfo.ForeColor = System.Drawing.Color.White;
            this.gbLicenseReplacementApplicationInfo.Location = new System.Drawing.Point(14, 384);
            this.gbLicenseReplacementApplicationInfo.Name = "gbLicenseReplacementApplicationInfo";
            this.gbLicenseReplacementApplicationInfo.Size = new System.Drawing.Size(790, 98);
            this.gbLicenseReplacementApplicationInfo.TabIndex = 94;
            this.gbLicenseReplacementApplicationInfo.TabStop = false;
            this.gbLicenseReplacementApplicationInfo.Text = "License Replacement Application Info";
            // 
            // txbFineFees
            // 
            this.txbFineFees.Enabled = false;
            this.txbFineFees.Location = new System.Drawing.Point(535, 51);
            this.txbFineFees.MaxLength = 10;
            this.txbFineFees.Name = "txbFineFees";
            this.txbFineFees.Size = new System.Drawing.Size(195, 23);
            this.txbFineFees.TabIndex = 76;
            this.txbFineFees.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txbFineFees_KeyPress);
            this.txbFineFees.Leave += new System.EventHandler(this.txbFineFees_Leave);
            // 
            // label3
            // 
            this.label3.Font = new System.Drawing.Font("Consolas", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.label3.Location = new System.Drawing.Point(22, 29);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(99, 20);
            this.label3.TabIndex = 49;
            this.label3.Text = "Detain ID:";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblTitle
            // 
            this.lblTitle.Font = new System.Drawing.Font("Copperplate Gothic Bold", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.ForeColor = System.Drawing.Color.Red;
            this.lblTitle.Location = new System.Drawing.Point(191, 7);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(628, 34);
            this.lblTitle.TabIndex = 92;
            this.lblTitle.Text = "Detain License";
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // ctrlLicenseCardWithFilter1
            // 
            this.ctrlLicenseCardWithFilter1.BackColor = System.Drawing.Color.Gray;
            this.ctrlLicenseCardWithFilter1.Location = new System.Drawing.Point(8, 30);
            this.ctrlLicenseCardWithFilter1.Name = "ctrlLicenseCardWithFilter1";
            this.ctrlLicenseCardWithFilter1.Size = new System.Drawing.Size(995, 356);
            this.ctrlLicenseCardWithFilter1.TabIndex = 93;
            // 
            // frmDetainLicense
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Gray;
            this.ClientSize = new System.Drawing.Size(1011, 493);
            this.Controls.Add(this.llShowNewLicense);
            this.Controls.Add(this.llShowLicenseHistory);
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.ctrlLicenseCardWithFilter1);
            this.Controls.Add(this.btnDetain);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.gbLicenseReplacementApplicationInfo);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmDetainLicense";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Detain License";
            this.Load += new System.EventHandler(this.frmDetainLicense_Load);
            this.gbLicenseReplacementApplicationInfo.ResumeLayout(false);
            this.gbLicenseReplacementApplicationInfo.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ctrlLicenseCardWithFilter ctrlLicenseCardWithFilter1;
        private System.Windows.Forms.Label lblCreatedByUsername;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label lblDetainDate;
        private System.Windows.Forms.LinkLabel llShowNewLicense;
        private System.Windows.Forms.LinkLabel llShowLicenseHistory;
        private System.Windows.Forms.Button btnDetain;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Label lblLicenseID;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblDetainID;
        private System.Windows.Forms.GroupBox gbLicenseReplacementApplicationInfo;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.TextBox txbFineFees;
    }
}