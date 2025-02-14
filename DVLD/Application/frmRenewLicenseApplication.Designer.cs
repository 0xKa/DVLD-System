namespace DVLD.License.Local_Licenses
{
    partial class frmRenewLicenseApplication
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
            this.lblTitle = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txbNotes = new System.Windows.Forms.TextBox();
            this.lblTotalFees = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.lblLicenseFees = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.lblCreatedByUsername = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.lblApplicationFees = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.lblIssueDate = new System.Windows.Forms.Label();
            this.lblExpirationDate = new System.Windows.Forms.Label();
            this.lblOldLicenseID = new System.Windows.Forms.Label();
            this.label20 = new System.Windows.Forms.Label();
            this.lblRenewedLicenseID = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lblRenewedLicenseApplicationID = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnRenew = new System.Windows.Forms.Button();
            this.llShowNewLicense = new System.Windows.Forms.LinkLabel();
            this.llShowLicenseHistory = new System.Windows.Forms.LinkLabel();
            this.ctrlCard = new DVLD.License.Local_Licenses.ctrlLicenseCardFinder();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblTitle
            // 
            this.lblTitle.Font = new System.Drawing.Font("Copperplate Gothic Bold", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.ForeColor = System.Drawing.Color.Red;
            this.lblTitle.Location = new System.Drawing.Point(287, -3);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(252, 34);
            this.lblTitle.TabIndex = 14;
            this.lblTitle.Text = "Select a License to Renew";
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txbNotes);
            this.groupBox1.Controls.Add(this.lblTotalFees);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.lblLicenseFees);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.lblCreatedByUsername);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.lblApplicationFees);
            this.groupBox1.Controls.Add(this.label11);
            this.groupBox1.Controls.Add(this.label13);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.lblIssueDate);
            this.groupBox1.Controls.Add(this.lblExpirationDate);
            this.groupBox1.Controls.Add(this.lblOldLicenseID);
            this.groupBox1.Controls.Add(this.label20);
            this.groupBox1.Controls.Add(this.lblRenewedLicenseID);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.lblRenewedLicenseApplicationID);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.ForeColor = System.Drawing.Color.White;
            this.groupBox1.Location = new System.Drawing.Point(821, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(334, 406);
            this.groupBox1.TabIndex = 81;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Renew License Application Info";
            // 
            // txbNotes
            // 
            this.txbNotes.Enabled = false;
            this.txbNotes.Location = new System.Drawing.Point(74, 345);
            this.txbNotes.Multiline = true;
            this.txbNotes.Name = "txbNotes";
            this.txbNotes.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txbNotes.Size = new System.Drawing.Size(254, 51);
            this.txbNotes.TabIndex = 73;
            // 
            // lblTotalFees
            // 
            this.lblTotalFees.Font = new System.Drawing.Font("Consolas", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalFees.ForeColor = System.Drawing.Color.Firebrick;
            this.lblTotalFees.Location = new System.Drawing.Point(183, 208);
            this.lblTotalFees.Name = "lblTotalFees";
            this.lblTotalFees.Size = new System.Drawing.Size(78, 20);
            this.lblTotalFees.TabIndex = 70;
            this.lblTotalFees.Text = "[????]";
            // 
            // label6
            // 
            this.label6.Font = new System.Drawing.Font("Consolas", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.Firebrick;
            this.label6.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.label6.Location = new System.Drawing.Point(71, 207);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(106, 20);
            this.label6.TabIndex = 71;
            this.label6.Text = "Total Fees:";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblLicenseFees
            // 
            this.lblLicenseFees.Font = new System.Drawing.Font("Consolas", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLicenseFees.ForeColor = System.Drawing.Color.White;
            this.lblLicenseFees.Location = new System.Drawing.Point(183, 172);
            this.lblLicenseFees.Name = "lblLicenseFees";
            this.lblLicenseFees.Size = new System.Drawing.Size(78, 20);
            this.lblLicenseFees.TabIndex = 68;
            this.lblLicenseFees.Text = "[????]";
            // 
            // label4
            // 
            this.label4.Font = new System.Drawing.Font("Consolas", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.Silver;
            this.label4.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.label4.Location = new System.Drawing.Point(71, 172);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(106, 20);
            this.label4.TabIndex = 69;
            this.label4.Text = "Licns. Fees:";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label8
            // 
            this.label8.Font = new System.Drawing.Font("Consolas", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.Color.White;
            this.label8.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.label8.Location = new System.Drawing.Point(6, 360);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(62, 20);
            this.label8.TabIndex = 72;
            this.label8.Text = "Notes:";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblCreatedByUsername
            // 
            this.lblCreatedByUsername.Font = new System.Drawing.Font("Consolas", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCreatedByUsername.ForeColor = System.Drawing.Color.White;
            this.lblCreatedByUsername.Location = new System.Drawing.Point(183, 312);
            this.lblCreatedByUsername.Name = "lblCreatedByUsername";
            this.lblCreatedByUsername.Size = new System.Drawing.Size(135, 20);
            this.lblCreatedByUsername.TabIndex = 66;
            this.lblCreatedByUsername.Text = "[????]";
            // 
            // label9
            // 
            this.label9.Font = new System.Drawing.Font("Consolas", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ForeColor = System.Drawing.Color.Silver;
            this.label9.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.label9.Location = new System.Drawing.Point(71, 312);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(106, 20);
            this.label9.TabIndex = 67;
            this.label9.Text = "Created By:";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblApplicationFees
            // 
            this.lblApplicationFees.Font = new System.Drawing.Font("Consolas", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblApplicationFees.ForeColor = System.Drawing.Color.White;
            this.lblApplicationFees.Location = new System.Drawing.Point(183, 137);
            this.lblApplicationFees.Name = "lblApplicationFees";
            this.lblApplicationFees.Size = new System.Drawing.Size(78, 20);
            this.lblApplicationFees.TabIndex = 64;
            this.lblApplicationFees.Text = "[????]";
            // 
            // label11
            // 
            this.label11.Font = new System.Drawing.Font("Consolas", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.ForeColor = System.Drawing.Color.Silver;
            this.label11.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.label11.Location = new System.Drawing.Point(71, 137);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(106, 20);
            this.label11.TabIndex = 65;
            this.label11.Text = "App. Fees:";
            this.label11.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label13
            // 
            this.label13.Font = new System.Drawing.Font("Consolas", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.ForeColor = System.Drawing.Color.Silver;
            this.label13.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.label13.Location = new System.Drawing.Point(29, 277);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(148, 20);
            this.label13.TabIndex = 61;
            this.label13.Text = "Expiration Date:";
            this.label13.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label7
            // 
            this.label7.Font = new System.Drawing.Font("Consolas", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.Silver;
            this.label7.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.label7.Location = new System.Drawing.Point(29, 242);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(148, 20);
            this.label7.TabIndex = 55;
            this.label7.Text = "Issue Date:";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblIssueDate
            // 
            this.lblIssueDate.Font = new System.Drawing.Font("Consolas", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblIssueDate.ForeColor = System.Drawing.Color.White;
            this.lblIssueDate.Location = new System.Drawing.Point(183, 242);
            this.lblIssueDate.Name = "lblIssueDate";
            this.lblIssueDate.Size = new System.Drawing.Size(135, 20);
            this.lblIssueDate.TabIndex = 54;
            this.lblIssueDate.Text = "[????]";
            // 
            // lblExpirationDate
            // 
            this.lblExpirationDate.Font = new System.Drawing.Font("Consolas", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblExpirationDate.ForeColor = System.Drawing.Color.White;
            this.lblExpirationDate.Location = new System.Drawing.Point(183, 277);
            this.lblExpirationDate.Name = "lblExpirationDate";
            this.lblExpirationDate.Size = new System.Drawing.Size(135, 20);
            this.lblExpirationDate.TabIndex = 60;
            this.lblExpirationDate.Text = "[????]";
            // 
            // lblOldLicenseID
            // 
            this.lblOldLicenseID.Font = new System.Drawing.Font("Consolas", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblOldLicenseID.ForeColor = System.Drawing.Color.White;
            this.lblOldLicenseID.Location = new System.Drawing.Point(183, 102);
            this.lblOldLicenseID.Name = "lblOldLicenseID";
            this.lblOldLicenseID.Size = new System.Drawing.Size(86, 20);
            this.lblOldLicenseID.TabIndex = 52;
            this.lblOldLicenseID.Text = "[????]";
            // 
            // label20
            // 
            this.label20.Font = new System.Drawing.Font("Consolas", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label20.ForeColor = System.Drawing.Color.Silver;
            this.label20.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.label20.Location = new System.Drawing.Point(6, 102);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(171, 20);
            this.label20.TabIndex = 53;
            this.label20.Text = "Old License ID:";
            this.label20.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblRenewedLicenseID
            // 
            this.lblRenewedLicenseID.Font = new System.Drawing.Font("Consolas", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRenewedLicenseID.ForeColor = System.Drawing.Color.Firebrick;
            this.lblRenewedLicenseID.Location = new System.Drawing.Point(183, 67);
            this.lblRenewedLicenseID.Name = "lblRenewedLicenseID";
            this.lblRenewedLicenseID.Size = new System.Drawing.Size(86, 20);
            this.lblRenewedLicenseID.TabIndex = 50;
            this.lblRenewedLicenseID.Text = "[????]";
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Consolas", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Firebrick;
            this.label2.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.label2.Location = new System.Drawing.Point(5, 67);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(172, 20);
            this.label2.TabIndex = 51;
            this.label2.Text = "Renewed License ID:";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblRenewedLicenseApplicationID
            // 
            this.lblRenewedLicenseApplicationID.Font = new System.Drawing.Font("Consolas", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRenewedLicenseApplicationID.ForeColor = System.Drawing.Color.White;
            this.lblRenewedLicenseApplicationID.Location = new System.Drawing.Point(183, 33);
            this.lblRenewedLicenseApplicationID.Name = "lblRenewedLicenseApplicationID";
            this.lblRenewedLicenseApplicationID.Size = new System.Drawing.Size(86, 20);
            this.lblRenewedLicenseApplicationID.TabIndex = 48;
            this.lblRenewedLicenseApplicationID.Text = "[????]";
            // 
            // label3
            // 
            this.label3.Font = new System.Drawing.Font("Consolas", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Silver;
            this.label3.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.label3.Location = new System.Drawing.Point(6, 32);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(171, 20);
            this.label3.TabIndex = 49;
            this.label3.Text = "R.L. Application ID:";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // btnClose
            // 
            this.btnClose.BackColor = System.Drawing.Color.LightGray;
            this.btnClose.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btnClose.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClose.Font = new System.Drawing.Font("Rockwell", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.ImageKey = "(none)";
            this.btnClose.Location = new System.Drawing.Point(837, 427);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(156, 34);
            this.btnClose.TabIndex = 82;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = false;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnRenew
            // 
            this.btnRenew.BackColor = System.Drawing.Color.LightGray;
            this.btnRenew.Enabled = false;
            this.btnRenew.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btnRenew.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnRenew.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRenew.Font = new System.Drawing.Font("Rockwell", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRenew.ImageKey = "(none)";
            this.btnRenew.Location = new System.Drawing.Point(999, 427);
            this.btnRenew.Name = "btnRenew";
            this.btnRenew.Size = new System.Drawing.Size(156, 34);
            this.btnRenew.TabIndex = 83;
            this.btnRenew.Text = "Renew";
            this.btnRenew.UseVisualStyleBackColor = false;
            this.btnRenew.Click += new System.EventHandler(this.btnRenew_Click);
            // 
            // llShowNewLicense
            // 
            this.llShowNewLicense.AutoSize = true;
            this.llShowNewLicense.Enabled = false;
            this.llShowNewLicense.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.llShowNewLicense.LinkColor = System.Drawing.Color.RoyalBlue;
            this.llShowNewLicense.Location = new System.Drawing.Point(218, 437);
            this.llShowNewLicense.Name = "llShowNewLicense";
            this.llShowNewLicense.Size = new System.Drawing.Size(198, 19);
            this.llShowNewLicense.TabIndex = 86;
            this.llShowNewLicense.TabStop = true;
            this.llShowNewLicense.Text = "Show New License Info";
            this.llShowNewLicense.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.llShowNewLicense_LinkClicked);
            // 
            // llShowLicenseHistory
            // 
            this.llShowLicenseHistory.AutoSize = true;
            this.llShowLicenseHistory.Enabled = false;
            this.llShowLicenseHistory.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.llShowLicenseHistory.LinkColor = System.Drawing.Color.RoyalBlue;
            this.llShowLicenseHistory.Location = new System.Drawing.Point(7, 437);
            this.llShowLicenseHistory.Name = "llShowLicenseHistory";
            this.llShowLicenseHistory.Size = new System.Drawing.Size(189, 19);
            this.llShowLicenseHistory.TabIndex = 85;
            this.llShowLicenseHistory.TabStop = true;
            this.llShowLicenseHistory.Text = "Show License History";
            this.llShowLicenseHistory.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.llShowLicenseHistory_LinkClicked);
            // 
            // ctrlCard
            // 
            this.ctrlCard.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.ctrlCard.Location = new System.Drawing.Point(11, 12);
            this.ctrlCard.Name = "ctrlCard";
            this.ctrlCard.Size = new System.Drawing.Size(804, 406);
            this.ctrlCard.TabIndex = 0;
            // 
            // frmRenewLicenseApplication
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.ClientSize = new System.Drawing.Size(1167, 473);
            this.Controls.Add(this.llShowNewLicense);
            this.Controls.Add(this.llShowLicenseHistory);
            this.Controls.Add(this.btnRenew);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.ctrlCard);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmRenewLicenseApplication";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Renew Driving License";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ctrlLicenseCardFinder ctrlCard;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label lblTotalFees;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label lblLicenseFees;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lblCreatedByUsername;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label lblApplicationFees;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label lblIssueDate;
        private System.Windows.Forms.Label lblExpirationDate;
        private System.Windows.Forms.Label lblOldLicenseID;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.Label lblRenewedLicenseID;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblRenewedLicenseApplicationID;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txbNotes;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnRenew;
        private System.Windows.Forms.LinkLabel llShowNewLicense;
        private System.Windows.Forms.LinkLabel llShowLicenseHistory;
    }
}