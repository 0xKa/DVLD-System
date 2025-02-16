﻿namespace DVLD.Detain_Release_License
{
    partial class frmManageDetainedLicenses
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmManageDetainedLicenses));
            this.btnClose = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.dgvDetainedLicensesList = new System.Windows.Forms.DataGridView();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.showDetailsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.editToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.deleteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripSeparator();
            this.cancelApplicationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.scheduleTestsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.visionTestToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.theoryTestToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.practicalTestToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.issueDrivingLicenseToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.showLicenseToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.showLicenseHistoryToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.lblTitle = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.txbSearchBy = new System.Windows.Forms.TextBox();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.btnClearSearch = new System.Windows.Forms.Button();
            this.cbSearchOptions = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnDetainLicense = new System.Windows.Forms.Button();
            this.lblNumberOfRecords = new System.Windows.Forms.Label();
            this.pnlIsReleased = new System.Windows.Forms.Panel();
            this.rbDetained = new System.Windows.Forms.RadioButton();
            this.rbReleased = new System.Windows.Forms.RadioButton();
            this.btnReleaseLicense = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetainedLicensesList)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.pnlIsReleased.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnClose
            // 
            this.btnClose.BackColor = System.Drawing.Color.LightGray;
            this.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnClose.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btnClose.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClose.Font = new System.Drawing.Font("Rockwell", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.ImageKey = "(none)";
            this.btnClose.Location = new System.Drawing.Point(1060, 515);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(108, 34);
            this.btnClose.TabIndex = 32;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = false;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Consolas", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.SystemColors.Control;
            this.label2.Location = new System.Drawing.Point(12, 512);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(228, 34);
            this.label2.TabIndex = 34;
            this.label2.Text = "Number of Records: ";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // dgvDetainedLicensesList
            // 
            this.dgvDetainedLicensesList.AllowUserToAddRows = false;
            this.dgvDetainedLicensesList.AllowUserToDeleteRows = false;
            this.dgvDetainedLicensesList.AllowUserToOrderColumns = true;
            this.dgvDetainedLicensesList.AllowUserToResizeRows = false;
            this.dgvDetainedLicensesList.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvDetainedLicensesList.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvDetainedLicensesList.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dgvDetainedLicensesList.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.dgvDetainedLicensesList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDetainedLicensesList.ContextMenuStrip = this.contextMenuStrip1;
            this.dgvDetainedLicensesList.Location = new System.Drawing.Point(12, 163);
            this.dgvDetainedLicensesList.Name = "dgvDetainedLicensesList";
            this.dgvDetainedLicensesList.ReadOnly = true;
            this.dgvDetainedLicensesList.Size = new System.Drawing.Size(1156, 346);
            this.dgvDetainedLicensesList.TabIndex = 33;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.showDetailsToolStripMenuItem,
            this.toolStripMenuItem1,
            this.editToolStripMenuItem,
            this.deleteToolStripMenuItem,
            this.toolStripMenuItem2,
            this.cancelApplicationToolStripMenuItem,
            this.toolStripSeparator1,
            this.scheduleTestsToolStripMenuItem,
            this.issueDrivingLicenseToolStripMenuItem,
            this.toolStripSeparator2,
            this.showLicenseToolStripMenuItem,
            this.showLicenseHistoryToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(199, 204);
            // 
            // showDetailsToolStripMenuItem
            // 
            this.showDetailsToolStripMenuItem.Image = global::DVLD.Properties.Resources.info;
            this.showDetailsToolStripMenuItem.Name = "showDetailsToolStripMenuItem";
            this.showDetailsToolStripMenuItem.Size = new System.Drawing.Size(198, 22);
            this.showDetailsToolStripMenuItem.Text = "Show Details";
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(195, 6);
            // 
            // editToolStripMenuItem
            // 
            this.editToolStripMenuItem.Enabled = false;
            this.editToolStripMenuItem.Image = global::DVLD.Properties.Resources.edit;
            this.editToolStripMenuItem.Name = "editToolStripMenuItem";
            this.editToolStripMenuItem.Size = new System.Drawing.Size(198, 22);
            this.editToolStripMenuItem.Text = "Edit";
            // 
            // deleteToolStripMenuItem
            // 
            this.deleteToolStripMenuItem.Enabled = false;
            this.deleteToolStripMenuItem.Image = global::DVLD.Properties.Resources.delete;
            this.deleteToolStripMenuItem.Name = "deleteToolStripMenuItem";
            this.deleteToolStripMenuItem.Size = new System.Drawing.Size(198, 22);
            this.deleteToolStripMenuItem.Text = "Delete";
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(195, 6);
            // 
            // cancelApplicationToolStripMenuItem
            // 
            this.cancelApplicationToolStripMenuItem.Enabled = false;
            this.cancelApplicationToolStripMenuItem.Image = global::DVLD.Properties.Resources.cancel;
            this.cancelApplicationToolStripMenuItem.Name = "cancelApplicationToolStripMenuItem";
            this.cancelApplicationToolStripMenuItem.Size = new System.Drawing.Size(198, 22);
            this.cancelApplicationToolStripMenuItem.Text = "Cancel Application";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(195, 6);
            // 
            // scheduleTestsToolStripMenuItem
            // 
            this.scheduleTestsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.visionTestToolStripMenuItem,
            this.theoryTestToolStripMenuItem,
            this.practicalTestToolStripMenuItem});
            this.scheduleTestsToolStripMenuItem.Enabled = false;
            this.scheduleTestsToolStripMenuItem.Image = global::DVLD.Properties.Resources.schedule;
            this.scheduleTestsToolStripMenuItem.Name = "scheduleTestsToolStripMenuItem";
            this.scheduleTestsToolStripMenuItem.Size = new System.Drawing.Size(198, 22);
            this.scheduleTestsToolStripMenuItem.Text = "Schedule Tests";
            // 
            // visionTestToolStripMenuItem
            // 
            this.visionTestToolStripMenuItem.Enabled = false;
            this.visionTestToolStripMenuItem.Image = global::DVLD.Properties.Resources.vision_test;
            this.visionTestToolStripMenuItem.Name = "visionTestToolStripMenuItem";
            this.visionTestToolStripMenuItem.Size = new System.Drawing.Size(151, 22);
            this.visionTestToolStripMenuItem.Text = "Vision Test";
            // 
            // theoryTestToolStripMenuItem
            // 
            this.theoryTestToolStripMenuItem.Enabled = false;
            this.theoryTestToolStripMenuItem.Image = global::DVLD.Properties.Resources.theory_test;
            this.theoryTestToolStripMenuItem.Name = "theoryTestToolStripMenuItem";
            this.theoryTestToolStripMenuItem.Size = new System.Drawing.Size(151, 22);
            this.theoryTestToolStripMenuItem.Text = "Theory Test";
            // 
            // practicalTestToolStripMenuItem
            // 
            this.practicalTestToolStripMenuItem.Enabled = false;
            this.practicalTestToolStripMenuItem.Image = global::DVLD.Properties.Resources.practical_test;
            this.practicalTestToolStripMenuItem.Name = "practicalTestToolStripMenuItem";
            this.practicalTestToolStripMenuItem.Size = new System.Drawing.Size(151, 22);
            this.practicalTestToolStripMenuItem.Text = "Practical Test";
            // 
            // issueDrivingLicenseToolStripMenuItem
            // 
            this.issueDrivingLicenseToolStripMenuItem.Enabled = false;
            this.issueDrivingLicenseToolStripMenuItem.Image = global::DVLD.Properties.Resources.done;
            this.issueDrivingLicenseToolStripMenuItem.Name = "issueDrivingLicenseToolStripMenuItem";
            this.issueDrivingLicenseToolStripMenuItem.Size = new System.Drawing.Size(198, 22);
            this.issueDrivingLicenseToolStripMenuItem.Text = "Issue Driving License";
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(195, 6);
            // 
            // showLicenseToolStripMenuItem
            // 
            this.showLicenseToolStripMenuItem.Enabled = false;
            this.showLicenseToolStripMenuItem.Image = global::DVLD.Properties.Resources.driving_license2;
            this.showLicenseToolStripMenuItem.Name = "showLicenseToolStripMenuItem";
            this.showLicenseToolStripMenuItem.Size = new System.Drawing.Size(198, 22);
            this.showLicenseToolStripMenuItem.Text = "Show License";
            // 
            // showLicenseHistoryToolStripMenuItem
            // 
            this.showLicenseHistoryToolStripMenuItem.Image = global::DVLD.Properties.Resources.history;
            this.showLicenseHistoryToolStripMenuItem.Name = "showLicenseHistoryToolStripMenuItem";
            this.showLicenseHistoryToolStripMenuItem.Size = new System.Drawing.Size(198, 22);
            this.showLicenseHistoryToolStripMenuItem.Text = "Show License History";
            // 
            // lblTitle
            // 
            this.lblTitle.Font = new System.Drawing.Font("Copperplate Gothic Bold", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.ForeColor = System.Drawing.SystemColors.Control;
            this.lblTitle.Location = new System.Drawing.Point(357, 7);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(466, 34);
            this.lblTitle.TabIndex = 30;
            this.lblTitle.Text = "Manage Detained Licenses";
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::DVLD.Properties.Resources.manage_detained_licenses;
            this.pictureBox1.Location = new System.Drawing.Point(533, 43);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(114, 114);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 31;
            this.pictureBox1.TabStop = false;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = global::DVLD.Properties.Resources.gears;
            this.pictureBox2.Location = new System.Drawing.Point(633, 58);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(40, 40);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox2.TabIndex = 41;
            this.pictureBox2.TabStop = false;
            // 
            // txbSearchBy
            // 
            this.txbSearchBy.Location = new System.Drawing.Point(251, 134);
            this.txbSearchBy.Name = "txbSearchBy";
            this.txbSearchBy.Size = new System.Drawing.Size(139, 20);
            this.txbSearchBy.TabIndex = 38;
            this.txbSearchBy.Visible = false;
            this.txbSearchBy.TextChanged += new System.EventHandler(this.txbSearchBy_TextChanged);
            this.txbSearchBy.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txbSearchBy_KeyPress);
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "detain.png");
            this.imageList1.Images.SetKeyName(1, "release.png");
            // 
            // btnClearSearch
            // 
            this.btnClearSearch.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClearSearch.Location = new System.Drawing.Point(396, 134);
            this.btnClearSearch.Name = "btnClearSearch";
            this.btnClearSearch.Size = new System.Drawing.Size(63, 21);
            this.btnClearSearch.TabIndex = 39;
            this.btnClearSearch.Text = "Clear";
            this.btnClearSearch.UseVisualStyleBackColor = true;
            this.btnClearSearch.Visible = false;
            this.btnClearSearch.Click += new System.EventHandler(this.btnClearSearch_Click);
            // 
            // cbSearchOptions
            // 
            this.cbSearchOptions.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbSearchOptions.FormattingEnabled = true;
            this.cbSearchOptions.Items.AddRange(new object[] {
            "None",
            "ID",
            "LicenseID",
            "NationalNo",
            "FullName",
            "IsReleased",
            "ReleaseApplicationID"});
            this.cbSearchOptions.Location = new System.Drawing.Point(106, 134);
            this.cbSearchOptions.Name = "cbSearchOptions";
            this.cbSearchOptions.Size = new System.Drawing.Size(139, 21);
            this.cbSearchOptions.TabIndex = 37;
            this.cbSearchOptions.SelectedIndexChanged += new System.EventHandler(this.cbSearchOptions_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Consolas", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.Control;
            this.label1.Location = new System.Drawing.Point(13, 126);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(93, 34);
            this.label1.TabIndex = 36;
            this.label1.Text = "Search By: ";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btnDetainLicense
            // 
            this.btnDetainLicense.BackColor = System.Drawing.Color.LightGray;
            this.btnDetainLicense.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btnDetainLicense.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnDetainLicense.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDetainLicense.Font = new System.Drawing.Font("Rockwell", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDetainLicense.ImageKey = "detain.png";
            this.btnDetainLicense.ImageList = this.imageList1;
            this.btnDetainLicense.Location = new System.Drawing.Point(1095, 113);
            this.btnDetainLicense.Name = "btnDetainLicense";
            this.btnDetainLicense.Size = new System.Drawing.Size(73, 44);
            this.btnDetainLicense.TabIndex = 35;
            this.btnDetainLicense.UseVisualStyleBackColor = false;
            this.btnDetainLicense.Click += new System.EventHandler(this.btnDetainLicense_Click);
            // 
            // lblNumberOfRecords
            // 
            this.lblNumberOfRecords.Font = new System.Drawing.Font("Consolas", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNumberOfRecords.ForeColor = System.Drawing.SystemColors.Control;
            this.lblNumberOfRecords.Location = new System.Drawing.Point(246, 512);
            this.lblNumberOfRecords.Name = "lblNumberOfRecords";
            this.lblNumberOfRecords.Size = new System.Drawing.Size(123, 34);
            this.lblNumberOfRecords.TabIndex = 40;
            this.lblNumberOfRecords.Text = "0";
            this.lblNumberOfRecords.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // pnlIsReleased
            // 
            this.pnlIsReleased.Controls.Add(this.rbDetained);
            this.pnlIsReleased.Controls.Add(this.rbReleased);
            this.pnlIsReleased.Location = new System.Drawing.Point(255, 131);
            this.pnlIsReleased.Name = "pnlIsReleased";
            this.pnlIsReleased.Size = new System.Drawing.Size(171, 27);
            this.pnlIsReleased.TabIndex = 42;
            this.pnlIsReleased.Visible = false;
            // 
            // rbDetained
            // 
            this.rbDetained.AutoSize = true;
            this.rbDetained.Dock = System.Windows.Forms.DockStyle.Left;
            this.rbDetained.Font = new System.Drawing.Font("Lucida Fax", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbDetained.ForeColor = System.Drawing.Color.White;
            this.rbDetained.Location = new System.Drawing.Point(0, 0);
            this.rbDetained.Name = "rbDetained";
            this.rbDetained.Size = new System.Drawing.Size(83, 27);
            this.rbDetained.TabIndex = 15;
            this.rbDetained.TabStop = true;
            this.rbDetained.Text = "Detained";
            this.rbDetained.UseVisualStyleBackColor = true;
            this.rbDetained.CheckedChanged += new System.EventHandler(this.rbDetained_CheckedChanged);
            // 
            // rbReleased
            // 
            this.rbReleased.AutoSize = true;
            this.rbReleased.Dock = System.Windows.Forms.DockStyle.Right;
            this.rbReleased.Font = new System.Drawing.Font("Lucida Fax", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbReleased.ForeColor = System.Drawing.Color.White;
            this.rbReleased.Location = new System.Drawing.Point(89, 0);
            this.rbReleased.Name = "rbReleased";
            this.rbReleased.Size = new System.Drawing.Size(82, 27);
            this.rbReleased.TabIndex = 16;
            this.rbReleased.TabStop = true;
            this.rbReleased.Text = "Released";
            this.rbReleased.UseVisualStyleBackColor = true;
            this.rbReleased.CheckedChanged += new System.EventHandler(this.rbReleased_CheckedChanged);
            // 
            // btnReleaseLicense
            // 
            this.btnReleaseLicense.BackColor = System.Drawing.Color.LightGray;
            this.btnReleaseLicense.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btnReleaseLicense.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnReleaseLicense.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnReleaseLicense.Font = new System.Drawing.Font("Rockwell", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnReleaseLicense.ImageKey = "release.png";
            this.btnReleaseLicense.ImageList = this.imageList1;
            this.btnReleaseLicense.Location = new System.Drawing.Point(1016, 113);
            this.btnReleaseLicense.Name = "btnReleaseLicense";
            this.btnReleaseLicense.Size = new System.Drawing.Size(73, 44);
            this.btnReleaseLicense.TabIndex = 43;
            this.btnReleaseLicense.UseVisualStyleBackColor = false;
            this.btnReleaseLicense.Click += new System.EventHandler(this.btnReleaseLicense_Click);
            // 
            // frmManageDetainedLicenses
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.ClientSize = new System.Drawing.Size(1180, 557);
            this.Controls.Add(this.btnReleaseLicense);
            this.Controls.Add(this.pnlIsReleased);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.dgvDetainedLicensesList);
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.txbSearchBy);
            this.Controls.Add(this.btnClearSearch);
            this.Controls.Add(this.cbSearchOptions);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnDetainLicense);
            this.Controls.Add(this.lblNumberOfRecords);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmManageDetainedLicenses";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Manage Detained Licenses";
            this.Load += new System.EventHandler(this.frmManageDetainedLicenses_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetainedLicensesList)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.pnlIsReleased.ResumeLayout(false);
            this.pnlIsReleased.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridView dgvDetainedLicensesList;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem showDetailsToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem editToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem deleteToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem cancelApplicationToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem scheduleTestsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem visionTestToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem theoryTestToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem practicalTestToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem issueDrivingLicenseToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem showLicenseToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem showLicenseHistoryToolStripMenuItem;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.TextBox txbSearchBy;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.Button btnClearSearch;
        private System.Windows.Forms.ComboBox cbSearchOptions;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnDetainLicense;
        private System.Windows.Forms.Label lblNumberOfRecords;
        private System.Windows.Forms.Panel pnlIsReleased;
        private System.Windows.Forms.RadioButton rbDetained;
        private System.Windows.Forms.RadioButton rbReleased;
        private System.Windows.Forms.Button btnReleaseLicense;
    }
}