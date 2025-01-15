namespace DVLD_v1._0
{
    partial class frmManageLocalDLApplications
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmManageLocalDLApplications));
            this.btnClear = new System.Windows.Forms.Button();
            this.txbFilterBy = new System.Windows.Forms.TextBox();
            this.cbFilterOptions = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.lblTitle = new System.Windows.Forms.Label();
            this.dgvApplicationsList = new System.Windows.Forms.DataGridView();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.showDetailToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.editToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.deleteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripSeparator();
            this.cancelToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.changePasswordToolStripMenuItem = new System.Windows.Forms.ToolStripSeparator();
            this.scheduleTestsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.scheduleVisionTestToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.scheduleWrittenTestToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.scheduleStreetTestToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem3 = new System.Windows.Forms.ToolStripSeparator();
            this.issueDrivingLicenseFirstTimeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem4 = new System.Windows.Forms.ToolStripSeparator();
            this.showLicenseToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem5 = new System.Windows.Forms.ToolStripSeparator();
            this.showPersonsLicenseHistoryToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.btnClose = new System.Windows.Forms.Button();
            this.lblNumberOfRecords = new System.Windows.Forms.Label();
            this.btnAddApplication = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvApplicationsList)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // btnClear
            // 
            this.btnClear.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClear.Location = new System.Drawing.Point(376, 157);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(63, 21);
            this.btnClear.TabIndex = 16;
            this.btnClear.Text = "Clear";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Visible = false;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // txbFilterBy
            // 
            this.txbFilterBy.Location = new System.Drawing.Point(231, 157);
            this.txbFilterBy.Name = "txbFilterBy";
            this.txbFilterBy.Size = new System.Drawing.Size(139, 20);
            this.txbFilterBy.TabIndex = 15;
            this.txbFilterBy.Visible = false;
            this.txbFilterBy.TextChanged += new System.EventHandler(this.txbFilterBy_TextChanged);
            // 
            // cbFilterOptions
            // 
            this.cbFilterOptions.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbFilterOptions.FormattingEnabled = true;
            this.cbFilterOptions.Items.AddRange(new object[] {
            "None",
            "ID",
            "NationalNo",
            "FullName",
            "Status"});
            this.cbFilterOptions.Location = new System.Drawing.Point(105, 157);
            this.cbFilterOptions.Name = "cbFilterOptions";
            this.cbFilterOptions.Size = new System.Drawing.Size(121, 21);
            this.cbFilterOptions.TabIndex = 14;
            this.cbFilterOptions.SelectedIndexChanged += new System.EventHandler(this.cbFilterOptions_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Consolas", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.Control;
            this.label1.Location = new System.Drawing.Point(13, 149);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(93, 34);
            this.label1.TabIndex = 13;
            this.label1.Text = "Filter By: ";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblTitle
            // 
            this.lblTitle.Font = new System.Drawing.Font("Copperplate Gothic Bold", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.ForeColor = System.Drawing.SystemColors.Control;
            this.lblTitle.Location = new System.Drawing.Point(214, 9);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(698, 34);
            this.lblTitle.TabIndex = 11;
            this.lblTitle.Text = "Manage Local Driving License Applications";
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // dgvApplicationsList
            // 
            this.dgvApplicationsList.AllowUserToAddRows = false;
            this.dgvApplicationsList.AllowUserToDeleteRows = false;
            this.dgvApplicationsList.AllowUserToOrderColumns = true;
            this.dgvApplicationsList.AllowUserToResizeRows = false;
            this.dgvApplicationsList.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvApplicationsList.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvApplicationsList.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dgvApplicationsList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvApplicationsList.ContextMenuStrip = this.contextMenuStrip1;
            this.dgvApplicationsList.Location = new System.Drawing.Point(12, 186);
            this.dgvApplicationsList.Name = "dgvApplicationsList";
            this.dgvApplicationsList.ReadOnly = true;
            this.dgvApplicationsList.Size = new System.Drawing.Size(1102, 346);
            this.dgvApplicationsList.TabIndex = 10;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.showDetailToolStripMenuItem,
            this.toolStripMenuItem1,
            this.editToolStripMenuItem,
            this.deleteToolStripMenuItem,
            this.toolStripMenuItem2,
            this.cancelToolStripMenuItem,
            this.changePasswordToolStripMenuItem,
            this.scheduleTestsToolStripMenuItem,
            this.toolStripMenuItem3,
            this.issueDrivingLicenseFirstTimeToolStripMenuItem,
            this.toolStripMenuItem4,
            this.showLicenseToolStripMenuItem,
            this.toolStripMenuItem5,
            this.showPersonsLicenseHistoryToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(265, 238);
            this.contextMenuStrip1.Opening += new System.ComponentModel.CancelEventHandler(this.contextMenuStrip1_Opening);
            // 
            // showDetailToolStripMenuItem
            // 
            this.showDetailToolStripMenuItem.Image = global::DVLD_v1._0.Properties.Resources.info;
            this.showDetailToolStripMenuItem.Name = "showDetailToolStripMenuItem";
            this.showDetailToolStripMenuItem.Size = new System.Drawing.Size(264, 22);
            this.showDetailToolStripMenuItem.Text = "Show Details";
            this.showDetailToolStripMenuItem.Click += new System.EventHandler(this.showDetailToolStripMenuItem_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(261, 6);
            // 
            // editToolStripMenuItem
            // 
            this.editToolStripMenuItem.Image = global::DVLD_v1._0.Properties.Resources.edit;
            this.editToolStripMenuItem.Name = "editToolStripMenuItem";
            this.editToolStripMenuItem.Size = new System.Drawing.Size(264, 22);
            this.editToolStripMenuItem.Text = "Edit";
            this.editToolStripMenuItem.Click += new System.EventHandler(this.editToolStripMenuItem_Click);
            // 
            // deleteToolStripMenuItem
            // 
            this.deleteToolStripMenuItem.Image = global::DVLD_v1._0.Properties.Resources.delete;
            this.deleteToolStripMenuItem.Name = "deleteToolStripMenuItem";
            this.deleteToolStripMenuItem.Size = new System.Drawing.Size(264, 22);
            this.deleteToolStripMenuItem.Text = "Delete";
            this.deleteToolStripMenuItem.Click += new System.EventHandler(this.deleteToolStripMenuItem_Click);
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(261, 6);
            // 
            // cancelToolStripMenuItem
            // 
            this.cancelToolStripMenuItem.Image = global::DVLD_v1._0.Properties.Resources.cancel;
            this.cancelToolStripMenuItem.Name = "cancelToolStripMenuItem";
            this.cancelToolStripMenuItem.Size = new System.Drawing.Size(264, 22);
            this.cancelToolStripMenuItem.Text = "Cancel Application";
            this.cancelToolStripMenuItem.Click += new System.EventHandler(this.cancelToolStripMenuItem_Click);
            // 
            // changePasswordToolStripMenuItem
            // 
            this.changePasswordToolStripMenuItem.Name = "changePasswordToolStripMenuItem";
            this.changePasswordToolStripMenuItem.Size = new System.Drawing.Size(261, 6);
            // 
            // sechduleTestsToolStripMenuItem
            // 
            this.scheduleTestsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.scheduleVisionTestToolStripMenuItem,
            this.scheduleWrittenTestToolStripMenuItem,
            this.scheduleStreetTestToolStripMenuItem});
            this.scheduleTestsToolStripMenuItem.Image = global::DVLD_v1._0.Properties.Resources.schedule;
            this.scheduleTestsToolStripMenuItem.Name = "sechduleTestsToolStripMenuItem";
            this.scheduleTestsToolStripMenuItem.Size = new System.Drawing.Size(264, 22);
            this.scheduleTestsToolStripMenuItem.Text = "Sechdule Tests";
            // 
            // sechduleVisionTestToolStripMenuItem
            // 
            this.scheduleVisionTestToolStripMenuItem.Enabled = false;
            this.scheduleVisionTestToolStripMenuItem.Image = global::DVLD_v1._0.Properties.Resources.shared_vision;
            this.scheduleVisionTestToolStripMenuItem.Name = "sechduleVisionTestToolStripMenuItem";
            this.scheduleVisionTestToolStripMenuItem.Size = new System.Drawing.Size(201, 22);
            this.scheduleVisionTestToolStripMenuItem.Text = "Sechdule Vision Test";
            this.scheduleVisionTestToolStripMenuItem.Click += new System.EventHandler(this.sechduleVisionTestToolStripMenuItem_Click);
            // 
            // sechduleWrittenTestToolStripMenuItem
            // 
            this.scheduleWrittenTestToolStripMenuItem.Enabled = false;
            this.scheduleWrittenTestToolStripMenuItem.Image = global::DVLD_v1._0.Properties.Resources.writing;
            this.scheduleWrittenTestToolStripMenuItem.Name = "sechduleWrittenTestToolStripMenuItem";
            this.scheduleWrittenTestToolStripMenuItem.Size = new System.Drawing.Size(201, 22);
            this.scheduleWrittenTestToolStripMenuItem.Text = "Sechdule Written Test";
            this.scheduleWrittenTestToolStripMenuItem.Click += new System.EventHandler(this.sechduleWrittenTestToolStripMenuItem_Click);
            // 
            // sechduleStreetTestToolStripMenuItem
            // 
            this.scheduleStreetTestToolStripMenuItem.Enabled = false;
            this.scheduleStreetTestToolStripMenuItem.Image = global::DVLD_v1._0.Properties.Resources.motorway;
            this.scheduleStreetTestToolStripMenuItem.Name = "sechduleStreetTestToolStripMenuItem";
            this.scheduleStreetTestToolStripMenuItem.Size = new System.Drawing.Size(201, 22);
            this.scheduleStreetTestToolStripMenuItem.Text = "Sechdule Street Test";
            this.scheduleStreetTestToolStripMenuItem.Click += new System.EventHandler(this.sechduleStreetTestToolStripMenuItem_Click);
            // 
            // toolStripMenuItem3
            // 
            this.toolStripMenuItem3.Name = "toolStripMenuItem3";
            this.toolStripMenuItem3.Size = new System.Drawing.Size(261, 6);
            // 
            // issueDrivingLicenseFisrtTimeToolStripMenuItem
            // 
            this.issueDrivingLicenseFirstTimeToolStripMenuItem.Enabled = false;
            this.issueDrivingLicenseFirstTimeToolStripMenuItem.Image = global::DVLD_v1._0.Properties.Resources.magic;
            this.issueDrivingLicenseFirstTimeToolStripMenuItem.Name = "issueDrivingLicenseFisrtTimeToolStripMenuItem";
            this.issueDrivingLicenseFirstTimeToolStripMenuItem.Size = new System.Drawing.Size(264, 22);
            this.issueDrivingLicenseFirstTimeToolStripMenuItem.Text = "Issue Driving License (Fisrt Time)";
            // 
            // toolStripMenuItem4
            // 
            this.toolStripMenuItem4.Name = "toolStripMenuItem4";
            this.toolStripMenuItem4.Size = new System.Drawing.Size(261, 6);
            // 
            // showLicenseToolStripMenuItem
            // 
            this.showLicenseToolStripMenuItem.Enabled = false;
            this.showLicenseToolStripMenuItem.Image = global::DVLD_v1._0.Properties.Resources.driving_license__1_;
            this.showLicenseToolStripMenuItem.Name = "showLicenseToolStripMenuItem";
            this.showLicenseToolStripMenuItem.Size = new System.Drawing.Size(264, 22);
            this.showLicenseToolStripMenuItem.Text = "Show License";
            // 
            // toolStripMenuItem5
            // 
            this.toolStripMenuItem5.Name = "toolStripMenuItem5";
            this.toolStripMenuItem5.Size = new System.Drawing.Size(261, 6);
            // 
            // showPersonsLicenseHistoryToolStripMenuItem
            // 
            this.showPersonsLicenseHistoryToolStripMenuItem.Image = global::DVLD_v1._0.Properties.Resources.file;
            this.showPersonsLicenseHistoryToolStripMenuItem.Name = "showPersonsLicenseHistoryToolStripMenuItem";
            this.showPersonsLicenseHistoryToolStripMenuItem.Size = new System.Drawing.Size(264, 22);
            this.showPersonsLicenseHistoryToolStripMenuItem.Text = "Show Person\'s License History";
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "close.png");
            this.imageList1.Images.SetKeyName(1, "add.png");
            // 
            // btnClose
            // 
            this.btnClose.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.ImageKey = "(none)";
            this.btnClose.Location = new System.Drawing.Point(995, 536);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(119, 34);
            this.btnClose.TabIndex = 17;
            this.btnClose.Text = "Close";
            this.btnClose.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // lblNumberOfRecords
            // 
            this.lblNumberOfRecords.Font = new System.Drawing.Font("Consolas", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNumberOfRecords.ForeColor = System.Drawing.SystemColors.Control;
            this.lblNumberOfRecords.Location = new System.Drawing.Point(12, 536);
            this.lblNumberOfRecords.Name = "lblNumberOfRecords";
            this.lblNumberOfRecords.Size = new System.Drawing.Size(327, 34);
            this.lblNumberOfRecords.TabIndex = 18;
            this.lblNumberOfRecords.Text = "Number of Records: 0";
            this.lblNumberOfRecords.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btnAddApplication
            // 
            this.btnAddApplication.Font = new System.Drawing.Font("Consolas", 3F);
            this.btnAddApplication.ImageKey = "add.png";
            this.btnAddApplication.ImageList = this.imageList1;
            this.btnAddApplication.Location = new System.Drawing.Point(1028, 122);
            this.btnAddApplication.Name = "btnAddApplication";
            this.btnAddApplication.Size = new System.Drawing.Size(86, 59);
            this.btnAddApplication.TabIndex = 19;
            this.btnAddApplication.UseVisualStyleBackColor = true;
            this.btnAddApplication.Click += new System.EventHandler(this.btnAddApplication_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::DVLD_v1._0.Properties.Resources.place;
            this.pictureBox1.Location = new System.Drawing.Point(506, 45);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(114, 114);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 12;
            this.pictureBox1.TabStop = false;
            // 
            // frmManageLocalDLApplications
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.ClientSize = new System.Drawing.Size(1126, 577);
            this.Controls.Add(this.btnAddApplication);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.lblNumberOfRecords);
            this.Controls.Add(this.btnClear);
            this.Controls.Add(this.txbFilterBy);
            this.Controls.Add(this.cbFilterOptions);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.dgvApplicationsList);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmManageLocalDLApplications";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Manage Local Driving License Applications";
            this.Load += new System.EventHandler(this.frmManageLocalDLApplications_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvApplicationsList)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.TextBox txbFilterBy;
        private System.Windows.Forms.ComboBox cbFilterOptions;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.DataGridView dgvApplicationsList;
        private System.Windows.Forms.Button btnAddApplication;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Label lblNumberOfRecords;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem showDetailToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem editToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem deleteToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem cancelToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator changePasswordToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem scheduleTestsToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem3;
        private System.Windows.Forms.ToolStripMenuItem issueDrivingLicenseFirstTimeToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem4;
        private System.Windows.Forms.ToolStripMenuItem showLicenseToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem5;
        private System.Windows.Forms.ToolStripMenuItem showPersonsLicenseHistoryToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem scheduleVisionTestToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem scheduleWrittenTestToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem scheduleStreetTestToolStripMenuItem;
    }
}