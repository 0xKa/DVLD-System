namespace DVLD.License.International_License
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
            this.lblTitle = new System.Windows.Forms.Label();
            this.txbSearch = new System.Windows.Forms.TextBox();
            this.lblNumberOfRecords = new System.Windows.Forms.Label();
            this.btnClearSearch = new System.Windows.Forms.Button();
            this.cbSearchOptions = new System.Windows.Forms.ComboBox();
            this.showLicensesHistoryToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.label1 = new System.Windows.Forms.Label();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.showPersonalInfoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.btnClose = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.dgvInternationalLicenses = new System.Windows.Forms.DataGridView();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.btnAdd = new System.Windows.Forms.Button();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pnlSelectStatus = new System.Windows.Forms.Panel();
            this.rbActive = new System.Windows.Forms.RadioButton();
            this.rbInactive = new System.Windows.Forms.RadioButton();
            this.showLicenseInfoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.contextMenuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvInternationalLicenses)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.pnlSelectStatus.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblTitle
            // 
            this.lblTitle.Font = new System.Drawing.Font("Copperplate Gothic Bold", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.ForeColor = System.Drawing.SystemColors.Control;
            this.lblTitle.Location = new System.Drawing.Point(131, 10);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(505, 34);
            this.lblTitle.TabIndex = 41;
            this.lblTitle.Text = "Manage International Licenses";
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txbSearch
            // 
            this.txbSearch.Location = new System.Drawing.Point(236, 178);
            this.txbSearch.Name = "txbSearch";
            this.txbSearch.Size = new System.Drawing.Size(139, 20);
            this.txbSearch.TabIndex = 48;
            this.txbSearch.Visible = false;
            this.txbSearch.TextChanged += new System.EventHandler(this.txbSearch_TextChanged);
            this.txbSearch.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txbSearch_KeyPress);
            // 
            // lblNumberOfRecords
            // 
            this.lblNumberOfRecords.Font = new System.Drawing.Font("Consolas", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNumberOfRecords.ForeColor = System.Drawing.SystemColors.Control;
            this.lblNumberOfRecords.Location = new System.Drawing.Point(250, 556);
            this.lblNumberOfRecords.Name = "lblNumberOfRecords";
            this.lblNumberOfRecords.Size = new System.Drawing.Size(123, 34);
            this.lblNumberOfRecords.TabIndex = 50;
            this.lblNumberOfRecords.Text = "0";
            this.lblNumberOfRecords.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btnClearSearch
            // 
            this.btnClearSearch.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClearSearch.Location = new System.Drawing.Point(381, 178);
            this.btnClearSearch.Name = "btnClearSearch";
            this.btnClearSearch.Size = new System.Drawing.Size(63, 21);
            this.btnClearSearch.TabIndex = 49;
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
            "ApplicationID",
            "DriverID",
            "LocalLicenseID",
            "Active Status"});
            this.cbSearchOptions.Location = new System.Drawing.Point(110, 178);
            this.cbSearchOptions.Name = "cbSearchOptions";
            this.cbSearchOptions.Size = new System.Drawing.Size(121, 21);
            this.cbSearchOptions.TabIndex = 47;
            this.cbSearchOptions.SelectedIndexChanged += new System.EventHandler(this.cbSearchOptions_SelectedIndexChanged);
            // 
            // showLicensesHistoryToolStripMenuItem
            // 
            this.showLicensesHistoryToolStripMenuItem.Image = global::DVLD.Properties.Resources.history;
            this.showLicensesHistoryToolStripMenuItem.Name = "showLicensesHistoryToolStripMenuItem";
            this.showLicensesHistoryToolStripMenuItem.Size = new System.Drawing.Size(204, 22);
            this.showLicensesHistoryToolStripMenuItem.Text = "Show Licenses History";
            this.showLicensesHistoryToolStripMenuItem.Click += new System.EventHandler(this.showLicensesHistoryToolStripMenuItem_Click);
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Consolas", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.Control;
            this.label1.Location = new System.Drawing.Point(17, 170);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(93, 34);
            this.label1.TabIndex = 46;
            this.label1.Text = "Search By: ";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(224, 6);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(224, 6);
            // 
            // showPersonalInfoToolStripMenuItem
            // 
            this.showPersonalInfoToolStripMenuItem.Image = global::DVLD.Properties.Resources.info;
            this.showPersonalInfoToolStripMenuItem.Name = "showPersonalInfoToolStripMenuItem";
            this.showPersonalInfoToolStripMenuItem.Size = new System.Drawing.Size(204, 22);
            this.showPersonalInfoToolStripMenuItem.Text = "Show Personal Info";
            this.showPersonalInfoToolStripMenuItem.Click += new System.EventHandler(this.showPersonalInfoToolStripMenuItem_Click);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.showPersonalInfoToolStripMenuItem,
            this.toolStripMenuItem1,
            this.showLicenseInfoToolStripMenuItem,
            this.toolStripMenuItem2,
            this.showLicensesHistoryToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(205, 104);
            // 
            // btnClose
            // 
            this.btnClose.BackColor = System.Drawing.Color.LightGray;
            this.btnClose.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btnClose.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClose.Font = new System.Drawing.Font("Rockwell", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.ImageKey = "(none)";
            this.btnClose.Location = new System.Drawing.Point(643, 559);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(108, 34);
            this.btnClose.TabIndex = 43;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = false;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Consolas", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.SystemColors.Control;
            this.label2.Location = new System.Drawing.Point(16, 556);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(228, 34);
            this.label2.TabIndex = 45;
            this.label2.Text = "Number of Records: ";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // dgvInternationalLicenses
            // 
            this.dgvInternationalLicenses.AllowUserToAddRows = false;
            this.dgvInternationalLicenses.AllowUserToDeleteRows = false;
            this.dgvInternationalLicenses.AllowUserToOrderColumns = true;
            this.dgvInternationalLicenses.AllowUserToResizeRows = false;
            this.dgvInternationalLicenses.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvInternationalLicenses.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvInternationalLicenses.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dgvInternationalLicenses.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.dgvInternationalLicenses.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvInternationalLicenses.ContextMenuStrip = this.contextMenuStrip1;
            this.dgvInternationalLicenses.Location = new System.Drawing.Point(16, 207);
            this.dgvInternationalLicenses.Name = "dgvInternationalLicenses";
            this.dgvInternationalLicenses.ReadOnly = true;
            this.dgvInternationalLicenses.Size = new System.Drawing.Size(735, 346);
            this.dgvInternationalLicenses.TabIndex = 44;
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "add.png");
            // 
            // btnAdd
            // 
            this.btnAdd.BackColor = System.Drawing.Color.LightGray;
            this.btnAdd.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btnAdd.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnAdd.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAdd.Font = new System.Drawing.Font("Rockwell", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAdd.ImageKey = "add.png";
            this.btnAdd.ImageList = this.imageList1;
            this.btnAdd.Location = new System.Drawing.Point(678, 160);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(73, 44);
            this.btnAdd.TabIndex = 51;
            this.btnAdd.UseVisualStyleBackColor = false;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = global::DVLD.Properties.Resources.international;
            this.pictureBox2.Location = new System.Drawing.Point(413, 62);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(40, 40);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox2.TabIndex = 53;
            this.pictureBox2.TabStop = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::DVLD.Properties.Resources.manage_application;
            this.pictureBox1.Location = new System.Drawing.Point(313, 47);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(114, 114);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 52;
            this.pictureBox1.TabStop = false;
            // 
            // pnlSelectStatus
            // 
            this.pnlSelectStatus.Controls.Add(this.rbActive);
            this.pnlSelectStatus.Controls.Add(this.rbInactive);
            this.pnlSelectStatus.Location = new System.Drawing.Point(236, 174);
            this.pnlSelectStatus.Name = "pnlSelectStatus";
            this.pnlSelectStatus.Size = new System.Drawing.Size(149, 27);
            this.pnlSelectStatus.TabIndex = 54;
            this.pnlSelectStatus.Visible = false;
            // 
            // rbActive
            // 
            this.rbActive.AutoSize = true;
            this.rbActive.Dock = System.Windows.Forms.DockStyle.Left;
            this.rbActive.Font = new System.Drawing.Font("Lucida Fax", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbActive.ForeColor = System.Drawing.Color.White;
            this.rbActive.Location = new System.Drawing.Point(0, 0);
            this.rbActive.Name = "rbActive";
            this.rbActive.Size = new System.Drawing.Size(65, 27);
            this.rbActive.TabIndex = 15;
            this.rbActive.TabStop = true;
            this.rbActive.Text = "Active";
            this.rbActive.UseVisualStyleBackColor = true;
            this.rbActive.CheckedChanged += new System.EventHandler(this.rbActive_CheckedChanged);
            // 
            // rbInactive
            // 
            this.rbInactive.AutoSize = true;
            this.rbInactive.Dock = System.Windows.Forms.DockStyle.Right;
            this.rbInactive.Font = new System.Drawing.Font("Lucida Fax", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbInactive.ForeColor = System.Drawing.Color.White;
            this.rbInactive.Location = new System.Drawing.Point(73, 0);
            this.rbInactive.Name = "rbInactive";
            this.rbInactive.Size = new System.Drawing.Size(76, 27);
            this.rbInactive.TabIndex = 16;
            this.rbInactive.TabStop = true;
            this.rbInactive.Text = "Inactive";
            this.rbInactive.UseVisualStyleBackColor = true;
            this.rbInactive.CheckedChanged += new System.EventHandler(this.rbInactive_CheckedChanged);
            // 
            // showLicenseInfoToolStripMenuItem
            // 
            this.showLicenseInfoToolStripMenuItem.Image = global::DVLD.Properties.Resources.driving_license2;
            this.showLicenseInfoToolStripMenuItem.Name = "showLicenseInfoToolStripMenuItem";
            this.showLicenseInfoToolStripMenuItem.Size = new System.Drawing.Size(204, 22);
            this.showLicenseInfoToolStripMenuItem.Text = "Show License Info";
            this.showLicenseInfoToolStripMenuItem.Click += new System.EventHandler(this.showLicenseInfoToolStripMenuItem_Click);
            // 
            // frmManageInternationalLicenses
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.ClientSize = new System.Drawing.Size(767, 602);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.txbSearch);
            this.Controls.Add(this.lblNumberOfRecords);
            this.Controls.Add(this.btnClearSearch);
            this.Controls.Add(this.cbSearchOptions);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.dgvInternationalLicenses);
            this.Controls.Add(this.pnlSelectStatus);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmManageInternationalLicenses";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Manage International Licenses";
            this.Load += new System.EventHandler(this.frmManageInternationalLicenses_Load);
            this.contextMenuStrip1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvInternationalLicenses)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.pnlSelectStatus.ResumeLayout(false);
            this.pnlSelectStatus.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.TextBox txbSearch;
        private System.Windows.Forms.Label lblNumberOfRecords;
        private System.Windows.Forms.Button btnClearSearch;
        private System.Windows.Forms.ComboBox cbSearchOptions;
        private System.Windows.Forms.ToolStripMenuItem showLicensesHistoryToolStripMenuItem;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem2;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem showPersonalInfoToolStripMenuItem;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridView dgvInternationalLicenses;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Panel pnlSelectStatus;
        private System.Windows.Forms.RadioButton rbActive;
        private System.Windows.Forms.RadioButton rbInactive;
        private System.Windows.Forms.ToolStripMenuItem showLicenseInfoToolStripMenuItem;
    }
}