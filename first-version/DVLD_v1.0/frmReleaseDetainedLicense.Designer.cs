namespace DVLD_v1._0
{
    partial class frmReleaseDetainedLicense
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
            this.ctrlLicenseCardWithFilter1 = new DVLD_v1._0.ctrlLicenseCardWithFilter();
            this.btnClose = new System.Windows.Forms.Button();
            this.llShowReleasedLicense = new System.Windows.Forms.LinkLabel();
            this.llShowLicenseHistory = new System.Windows.Forms.LinkLabel();
            this.btnRelease = new System.Windows.Forms.Button();
            this.lblCreatedByUsername = new System.Windows.Forms.Label();
            this.lblReleaseDate = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.lblDetainDate = new System.Windows.Forms.Label();
            this.lblDetainID = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lblReleasedLicenseApplicationID = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.lblTitle = new System.Windows.Forms.Label();
            this.gbReleaseDetainedLicenseApplicationInfo = new System.Windows.Forms.GroupBox();
            this.lblTotalFees = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.lblApplicationFees = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.lblFineFees = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.lblLicenseID = new System.Windows.Forms.Label();
            this.label20 = new System.Windows.Forms.Label();
            this.gbReleaseDetainedLicenseApplicationInfo.SuspendLayout();
            this.SuspendLayout();
            // 
            // ctrlLicenseCardWithFilter1
            // 
            this.ctrlLicenseCardWithFilter1.BackColor = System.Drawing.Color.Gray;
            this.ctrlLicenseCardWithFilter1.Location = new System.Drawing.Point(8, 30);
            this.ctrlLicenseCardWithFilter1.Name = "ctrlLicenseCardWithFilter1";
            this.ctrlLicenseCardWithFilter1.Size = new System.Drawing.Size(995, 356);
            this.ctrlLicenseCardWithFilter1.TabIndex = 93;
            // 
            // btnClose
            // 
            this.btnClose.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.ImageKey = "(none)";
            this.btnClose.Location = new System.Drawing.Point(709, 526);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(95, 36);
            this.btnClose.TabIndex = 96;
            this.btnClose.Text = "Close";
            this.btnClose.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // llShowReleasedLicense
            // 
            this.llShowReleasedLicense.AutoSize = true;
            this.llShowReleasedLicense.Enabled = false;
            this.llShowReleasedLicense.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.llShowReleasedLicense.Location = new System.Drawing.Point(223, 534);
            this.llShowReleasedLicense.Name = "llShowReleasedLicense";
            this.llShowReleasedLicense.Size = new System.Drawing.Size(243, 19);
            this.llShowReleasedLicense.TabIndex = 99;
            this.llShowReleasedLicense.TabStop = true;
            this.llShowReleasedLicense.Text = "Show Released License Info";
            this.llShowReleasedLicense.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.llShowReleasedLicense_LinkClicked);
            // 
            // llShowLicenseHistory
            // 
            this.llShowLicenseHistory.AutoSize = true;
            this.llShowLicenseHistory.Enabled = false;
            this.llShowLicenseHistory.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.llShowLicenseHistory.Location = new System.Drawing.Point(12, 534);
            this.llShowLicenseHistory.Name = "llShowLicenseHistory";
            this.llShowLicenseHistory.Size = new System.Drawing.Size(189, 19);
            this.llShowLicenseHistory.TabIndex = 98;
            this.llShowLicenseHistory.TabStop = true;
            this.llShowLicenseHistory.Text = "Show License History";
            this.llShowLicenseHistory.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.llShowLicenseHistory_LinkClicked);
            // 
            // btnRelease
            // 
            this.btnRelease.Enabled = false;
            this.btnRelease.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRelease.ImageKey = "(none)";
            this.btnRelease.Location = new System.Drawing.Point(810, 526);
            this.btnRelease.Name = "btnRelease";
            this.btnRelease.Size = new System.Drawing.Size(193, 36);
            this.btnRelease.TabIndex = 97;
            this.btnRelease.Text = "Release";
            this.btnRelease.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnRelease.UseVisualStyleBackColor = true;
            this.btnRelease.Click += new System.EventHandler(this.btnRelease_Click);
            // 
            // lblCreatedByUsername
            // 
            this.lblCreatedByUsername.Font = new System.Drawing.Font("Consolas", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCreatedByUsername.ForeColor = System.Drawing.Color.Black;
            this.lblCreatedByUsername.Location = new System.Drawing.Point(494, 96);
            this.lblCreatedByUsername.Name = "lblCreatedByUsername";
            this.lblCreatedByUsername.Size = new System.Drawing.Size(135, 20);
            this.lblCreatedByUsername.TabIndex = 66;
            this.lblCreatedByUsername.Text = "[????]";
            // 
            // lblReleaseDate
            // 
            this.lblReleaseDate.Font = new System.Drawing.Font("Consolas", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblReleaseDate.ForeColor = System.Drawing.Color.Black;
            this.lblReleaseDate.Location = new System.Drawing.Point(494, 63);
            this.lblReleaseDate.Name = "lblReleaseDate";
            this.lblReleaseDate.Size = new System.Drawing.Size(135, 20);
            this.lblReleaseDate.TabIndex = 64;
            this.lblReleaseDate.Text = "[????]";
            // 
            // label11
            // 
            this.label11.Font = new System.Drawing.Font("Consolas", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.ForeColor = System.Drawing.Color.White;
            this.label11.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.label11.Location = new System.Drawing.Point(373, 63);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(115, 20);
            this.label11.TabIndex = 65;
            this.label11.Text = "Release Date:";
            this.label11.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label7
            // 
            this.label7.Font = new System.Drawing.Font("Consolas", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.White;
            this.label7.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.label7.Location = new System.Drawing.Point(373, 31);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(115, 20);
            this.label7.TabIndex = 55;
            this.label7.Text = "Detain Date:";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblDetainDate
            // 
            this.lblDetainDate.Font = new System.Drawing.Font("Consolas", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDetainDate.ForeColor = System.Drawing.Color.Black;
            this.lblDetainDate.Location = new System.Drawing.Point(494, 31);
            this.lblDetainDate.Name = "lblDetainDate";
            this.lblDetainDate.Size = new System.Drawing.Size(135, 20);
            this.lblDetainDate.TabIndex = 54;
            this.lblDetainDate.Text = "[????]";
            // 
            // lblDetainID
            // 
            this.lblDetainID.Font = new System.Drawing.Font("Consolas", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDetainID.ForeColor = System.Drawing.Color.Black;
            this.lblDetainID.Location = new System.Drawing.Point(213, 31);
            this.lblDetainID.Name = "lblDetainID";
            this.lblDetainID.Size = new System.Drawing.Size(86, 20);
            this.lblDetainID.TabIndex = 50;
            this.lblDetainID.Text = "[????]";
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Consolas", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.label2.Location = new System.Drawing.Point(17, 31);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(190, 20);
            this.label2.TabIndex = 51;
            this.label2.Text = "Detain ID:";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblReleasedLicenseApplicationID
            // 
            this.lblReleasedLicenseApplicationID.Font = new System.Drawing.Font("Consolas", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblReleasedLicenseApplicationID.ForeColor = System.Drawing.Color.Black;
            this.lblReleasedLicenseApplicationID.Location = new System.Drawing.Point(212, 63);
            this.lblReleasedLicenseApplicationID.Name = "lblReleasedLicenseApplicationID";
            this.lblReleasedLicenseApplicationID.Size = new System.Drawing.Size(86, 20);
            this.lblReleasedLicenseApplicationID.TabIndex = 48;
            this.lblReleasedLicenseApplicationID.Text = "[????]";
            // 
            // label3
            // 
            this.label3.Font = new System.Drawing.Font("Consolas", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.label3.Location = new System.Drawing.Point(13, 63);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(193, 20);
            this.label3.TabIndex = 49;
            this.label3.Text = "Release Application ID:";
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
            this.lblTitle.Text = "Release Detained License";
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // gbReleaseDetainedLicenseApplicationInfo
            // 
            this.gbReleaseDetainedLicenseApplicationInfo.Controls.Add(this.lblTotalFees);
            this.gbReleaseDetainedLicenseApplicationInfo.Controls.Add(this.label4);
            this.gbReleaseDetainedLicenseApplicationInfo.Controls.Add(this.lblApplicationFees);
            this.gbReleaseDetainedLicenseApplicationInfo.Controls.Add(this.label6);
            this.gbReleaseDetainedLicenseApplicationInfo.Controls.Add(this.label8);
            this.gbReleaseDetainedLicenseApplicationInfo.Controls.Add(this.lblFineFees);
            this.gbReleaseDetainedLicenseApplicationInfo.Controls.Add(this.lblCreatedByUsername);
            this.gbReleaseDetainedLicenseApplicationInfo.Controls.Add(this.label9);
            this.gbReleaseDetainedLicenseApplicationInfo.Controls.Add(this.lblReleaseDate);
            this.gbReleaseDetainedLicenseApplicationInfo.Controls.Add(this.label11);
            this.gbReleaseDetainedLicenseApplicationInfo.Controls.Add(this.label7);
            this.gbReleaseDetainedLicenseApplicationInfo.Controls.Add(this.lblDetainDate);
            this.gbReleaseDetainedLicenseApplicationInfo.Controls.Add(this.lblLicenseID);
            this.gbReleaseDetainedLicenseApplicationInfo.Controls.Add(this.label20);
            this.gbReleaseDetainedLicenseApplicationInfo.Controls.Add(this.lblDetainID);
            this.gbReleaseDetainedLicenseApplicationInfo.Controls.Add(this.label2);
            this.gbReleaseDetainedLicenseApplicationInfo.Controls.Add(this.lblReleasedLicenseApplicationID);
            this.gbReleaseDetainedLicenseApplicationInfo.Controls.Add(this.label3);
            this.gbReleaseDetainedLicenseApplicationInfo.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbReleaseDetainedLicenseApplicationInfo.ForeColor = System.Drawing.Color.White;
            this.gbReleaseDetainedLicenseApplicationInfo.Location = new System.Drawing.Point(14, 384);
            this.gbReleaseDetainedLicenseApplicationInfo.Name = "gbReleaseDetainedLicenseApplicationInfo";
            this.gbReleaseDetainedLicenseApplicationInfo.Size = new System.Drawing.Size(986, 136);
            this.gbReleaseDetainedLicenseApplicationInfo.TabIndex = 94;
            this.gbReleaseDetainedLicenseApplicationInfo.TabStop = false;
            this.gbReleaseDetainedLicenseApplicationInfo.Text = "Release Detained License Application Info";
            // 
            // lblTotalFees
            // 
            this.lblTotalFees.Font = new System.Drawing.Font("Consolas", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalFees.ForeColor = System.Drawing.Color.Black;
            this.lblTotalFees.Location = new System.Drawing.Point(791, 96);
            this.lblTotalFees.Name = "lblTotalFees";
            this.lblTotalFees.Size = new System.Drawing.Size(135, 20);
            this.lblTotalFees.TabIndex = 72;
            this.lblTotalFees.Text = "[????]";
            // 
            // label4
            // 
            this.label4.Font = new System.Drawing.Font("Consolas", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.Red;
            this.label4.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.label4.Location = new System.Drawing.Point(679, 96);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(106, 20);
            this.label4.TabIndex = 73;
            this.label4.Text = "Total Fees:";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblApplicationFees
            // 
            this.lblApplicationFees.Font = new System.Drawing.Font("Consolas", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblApplicationFees.ForeColor = System.Drawing.Color.Black;
            this.lblApplicationFees.Location = new System.Drawing.Point(791, 63);
            this.lblApplicationFees.Name = "lblApplicationFees";
            this.lblApplicationFees.Size = new System.Drawing.Size(135, 20);
            this.lblApplicationFees.TabIndex = 70;
            this.lblApplicationFees.Text = "[????]";
            // 
            // label6
            // 
            this.label6.Font = new System.Drawing.Font("Consolas", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.White;
            this.label6.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.label6.Location = new System.Drawing.Point(670, 63);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(115, 20);
            this.label6.TabIndex = 71;
            this.label6.Text = "Appl.Fees:";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label8
            // 
            this.label8.Font = new System.Drawing.Font("Consolas", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.Color.White;
            this.label8.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.label8.Location = new System.Drawing.Point(670, 31);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(115, 20);
            this.label8.TabIndex = 69;
            this.label8.Text = "Fine Fees:";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblFineFees
            // 
            this.lblFineFees.Font = new System.Drawing.Font("Consolas", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFineFees.ForeColor = System.Drawing.Color.Black;
            this.lblFineFees.Location = new System.Drawing.Point(791, 31);
            this.lblFineFees.Name = "lblFineFees";
            this.lblFineFees.Size = new System.Drawing.Size(135, 20);
            this.lblFineFees.TabIndex = 68;
            this.lblFineFees.Text = "[????]";
            // 
            // label9
            // 
            this.label9.Font = new System.Drawing.Font("Consolas", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ForeColor = System.Drawing.Color.White;
            this.label9.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.label9.Location = new System.Drawing.Point(382, 96);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(106, 20);
            this.label9.TabIndex = 67;
            this.label9.Text = "Created By:";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblLicenseID
            // 
            this.lblLicenseID.Font = new System.Drawing.Font("Consolas", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLicenseID.ForeColor = System.Drawing.Color.Black;
            this.lblLicenseID.Location = new System.Drawing.Point(213, 96);
            this.lblLicenseID.Name = "lblLicenseID";
            this.lblLicenseID.Size = new System.Drawing.Size(86, 20);
            this.lblLicenseID.TabIndex = 52;
            this.lblLicenseID.Text = "[????]";
            // 
            // label20
            // 
            this.label20.Font = new System.Drawing.Font("Consolas", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label20.ForeColor = System.Drawing.Color.White;
            this.label20.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.label20.Location = new System.Drawing.Point(18, 96);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(189, 20);
            this.label20.TabIndex = 53;
            this.label20.Text = "Selected License ID:";
            this.label20.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // frmReleaseDetainedLicense
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Gray;
            this.ClientSize = new System.Drawing.Size(1011, 569);
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.ctrlLicenseCardWithFilter1);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.llShowReleasedLicense);
            this.Controls.Add(this.llShowLicenseHistory);
            this.Controls.Add(this.btnRelease);
            this.Controls.Add(this.gbReleaseDetainedLicenseApplicationInfo);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmReleaseDetainedLicense";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Release Detained License";
            this.gbReleaseDetainedLicenseApplicationInfo.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ctrlLicenseCardWithFilter ctrlLicenseCardWithFilter1;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.LinkLabel llShowReleasedLicense;
        private System.Windows.Forms.LinkLabel llShowLicenseHistory;
        private System.Windows.Forms.Button btnRelease;
        private System.Windows.Forms.Label lblCreatedByUsername;
        private System.Windows.Forms.Label lblReleaseDate;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label lblDetainDate;
        private System.Windows.Forms.Label lblDetainID;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblReleasedLicenseApplicationID;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.GroupBox gbReleaseDetainedLicenseApplicationInfo;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label lblLicenseID;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.Label lblTotalFees;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lblApplicationFees;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label lblFineFees;
    }
}