namespace DVLD_v1._0
{
    partial class frmManageInternationalLicenses
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmManageInternationalLicenses));
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.btnClose = new System.Windows.Forms.Button();
            this.lblNumberOfRecords = new System.Windows.Forms.Label();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.txbFilterBy = new System.Windows.Forms.TextBox();
            this.cbFilterOptions = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.lblTitle = new System.Windows.Forms.Label();
            this.dgvLicensesList = new System.Windows.Forms.DataGridView();
            this.btnClear = new System.Windows.Forms.Button();
            this.btnAddNewLicense = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.showPersonDetailsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.showLicenseToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.showPersonsLicenseHistoryToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.contextMenuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLicensesList)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
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
            this.btnClose.Location = new System.Drawing.Point(995, 535);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(119, 34);
            this.btnClose.TabIndex = 27;
            this.btnClose.Text = "Close";
            this.btnClose.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // lblNumberOfRecords
            // 
            this.lblNumberOfRecords.Font = new System.Drawing.Font("Consolas", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNumberOfRecords.ForeColor = System.Drawing.SystemColors.Control;
            this.lblNumberOfRecords.Location = new System.Drawing.Point(12, 535);
            this.lblNumberOfRecords.Name = "lblNumberOfRecords";
            this.lblNumberOfRecords.Size = new System.Drawing.Size(327, 34);
            this.lblNumberOfRecords.TabIndex = 28;
            this.lblNumberOfRecords.Text = "Number of Records: 0";
            this.lblNumberOfRecords.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.showPersonDetailsToolStripMenuItem,
            this.showLicenseToolStripMenuItem,
            this.showPersonsLicenseHistoryToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(252, 92);
            // 
            // txbFilterBy
            // 
            this.txbFilterBy.Location = new System.Drawing.Point(271, 156);
            this.txbFilterBy.Name = "txbFilterBy";
            this.txbFilterBy.Size = new System.Drawing.Size(99, 20);
            this.txbFilterBy.TabIndex = 25;
            this.txbFilterBy.Visible = false;
            this.txbFilterBy.TextChanged += new System.EventHandler(this.txbFilterBy_TextChanged);
            // 
            // cbFilterOptions
            // 
            this.cbFilterOptions.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbFilterOptions.FormattingEnabled = true;
            this.cbFilterOptions.Items.AddRange(new object[] {
            "None",
            "InternationalLicenseID",
            "ApplicationID",
            "DriverID",
            "IssuedUsingLocalLicenseID",
            "IsActive",
            "CreatedByUserID"});
            this.cbFilterOptions.Location = new System.Drawing.Point(105, 156);
            this.cbFilterOptions.Name = "cbFilterOptions";
            this.cbFilterOptions.Size = new System.Drawing.Size(160, 21);
            this.cbFilterOptions.TabIndex = 24;
            this.cbFilterOptions.SelectedIndexChanged += new System.EventHandler(this.cbFilterOptions_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Consolas", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.Control;
            this.label1.Location = new System.Drawing.Point(13, 148);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(93, 34);
            this.label1.TabIndex = 23;
            this.label1.Text = "Filter By: ";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblTitle
            // 
            this.lblTitle.Font = new System.Drawing.Font("Copperplate Gothic Bold", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.ForeColor = System.Drawing.SystemColors.Control;
            this.lblTitle.Location = new System.Drawing.Point(214, 8);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(698, 34);
            this.lblTitle.TabIndex = 21;
            this.lblTitle.Text = "Manage International Licenses";
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // dgvLicensesList
            // 
            this.dgvLicensesList.AllowUserToAddRows = false;
            this.dgvLicensesList.AllowUserToDeleteRows = false;
            this.dgvLicensesList.AllowUserToOrderColumns = true;
            this.dgvLicensesList.AllowUserToResizeRows = false;
            this.dgvLicensesList.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvLicensesList.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvLicensesList.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dgvLicensesList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvLicensesList.ContextMenuStrip = this.contextMenuStrip1;
            this.dgvLicensesList.Location = new System.Drawing.Point(12, 185);
            this.dgvLicensesList.Name = "dgvLicensesList";
            this.dgvLicensesList.ReadOnly = true;
            this.dgvLicensesList.Size = new System.Drawing.Size(1102, 346);
            this.dgvLicensesList.TabIndex = 20;
            // 
            // btnClear
            // 
            this.btnClear.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClear.Location = new System.Drawing.Point(376, 156);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(63, 21);
            this.btnClear.TabIndex = 26;
            this.btnClear.Text = "Clear";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Visible = false;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // btnAddNewLicense
            // 
            this.btnAddNewLicense.Font = new System.Drawing.Font("Consolas", 3F);
            this.btnAddNewLicense.ImageKey = "add.png";
            this.btnAddNewLicense.ImageList = this.imageList1;
            this.btnAddNewLicense.Location = new System.Drawing.Point(1028, 121);
            this.btnAddNewLicense.Name = "btnAddNewLicense";
            this.btnAddNewLicense.Size = new System.Drawing.Size(86, 59);
            this.btnAddNewLicense.TabIndex = 29;
            this.btnAddNewLicense.UseVisualStyleBackColor = true;
            this.btnAddNewLicense.Click += new System.EventHandler(this.btnAddNewLicense_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::DVLD_v1._0.Properties.Resources.international;
            this.pictureBox1.Location = new System.Drawing.Point(506, 44);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(114, 114);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 22;
            this.pictureBox1.TabStop = false;
            // 
            // showPersonDetailsToolStripMenuItem
            // 
            this.showPersonDetailsToolStripMenuItem.Image = global::DVLD_v1._0.Properties.Resources.info;
            this.showPersonDetailsToolStripMenuItem.Name = "showPersonDetailsToolStripMenuItem";
            this.showPersonDetailsToolStripMenuItem.Size = new System.Drawing.Size(251, 22);
            this.showPersonDetailsToolStripMenuItem.Text = "Show Person Details";
            // 
            // showLicenseToolStripMenuItem
            // 
            this.showLicenseToolStripMenuItem.Enabled = false;
            this.showLicenseToolStripMenuItem.Image = global::DVLD_v1._0.Properties.Resources.driving_license__1_;
            this.showLicenseToolStripMenuItem.Name = "showLicenseToolStripMenuItem";
            this.showLicenseToolStripMenuItem.Size = new System.Drawing.Size(251, 22);
            this.showLicenseToolStripMenuItem.Text = "Show License";
            // 
            // showPersonsLicenseHistoryToolStripMenuItem
            // 
            this.showPersonsLicenseHistoryToolStripMenuItem.Image = global::DVLD_v1._0.Properties.Resources.file;
            this.showPersonsLicenseHistoryToolStripMenuItem.Name = "showPersonsLicenseHistoryToolStripMenuItem";
            this.showPersonsLicenseHistoryToolStripMenuItem.Size = new System.Drawing.Size(251, 22);
            this.showPersonsLicenseHistoryToolStripMenuItem.Text = "Show Person\'s License History";
            // 
            // frmManageInternationalLicenses
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.ClientSize = new System.Drawing.Size(1126, 577);
            this.Controls.Add(this.btnAddNewLicense);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.lblNumberOfRecords);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.txbFilterBy);
            this.Controls.Add(this.cbFilterOptions);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.dgvLicensesList);
            this.Controls.Add(this.btnClear);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmManageInternationalLicenses";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "International Licenses";
            this.Load += new System.EventHandler(this.frmManageInternationalLicenses_Load);
            this.contextMenuStrip1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvLicensesList)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnAddNewLicense;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Label lblNumberOfRecords;
        private System.Windows.Forms.ToolStripMenuItem showPersonsLicenseHistoryToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem showLicenseToolStripMenuItem;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.ToolStripMenuItem showPersonDetailsToolStripMenuItem;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.TextBox txbFilterBy;
        private System.Windows.Forms.ComboBox cbFilterOptions;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.DataGridView dgvLicensesList;
        private System.Windows.Forms.Button btnClear;
    }
}