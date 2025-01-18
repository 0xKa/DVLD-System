namespace DVLD_v1._0
{
    partial class frmPersonLicenseHistory
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
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tpLocalLicenses = new System.Windows.Forms.TabPage();
            this.dgvLocalLicenseList = new System.Windows.Forms.DataGridView();
            this.btnClose = new System.Windows.Forms.Button();
            this.lblLocalLicenseNumberOfRecords = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.tpInternationalLicenses = new System.Windows.Forms.TabPage();
            this.ctrlPersonCard1 = new DVLD_v1._0.ctrlPersonCard();
            this.dgvInternationalLicenseList = new System.Windows.Forms.DataGridView();
            this.lblInternationalLicenseNumberOfRecords = new System.Windows.Forms.Label();
            this.s = new System.Windows.Forms.Label();
            this.tabControl1.SuspendLayout();
            this.tpLocalLicenses.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLocalLicenseList)).BeginInit();
            this.tpInternationalLicenses.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvInternationalLicenseList)).BeginInit();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tpLocalLicenses);
            this.tabControl1.Controls.Add(this.tpInternationalLicenses);
            this.tabControl1.Location = new System.Drawing.Point(16, 310);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(728, 268);
            this.tabControl1.TabIndex = 36;
            // 
            // tpLocalLicenses
            // 
            this.tpLocalLicenses.BackColor = System.Drawing.Color.Silver;
            this.tpLocalLicenses.Controls.Add(this.dgvLocalLicenseList);
            this.tpLocalLicenses.Controls.Add(this.lblLocalLicenseNumberOfRecords);
            this.tpLocalLicenses.Controls.Add(this.label1);
            this.tpLocalLicenses.Location = new System.Drawing.Point(4, 22);
            this.tpLocalLicenses.Name = "tpLocalLicenses";
            this.tpLocalLicenses.Padding = new System.Windows.Forms.Padding(3);
            this.tpLocalLicenses.Size = new System.Drawing.Size(720, 242);
            this.tpLocalLicenses.TabIndex = 0;
            this.tpLocalLicenses.Text = "Local";
            // 
            // dgvLocalLicenseList
            // 
            this.dgvLocalLicenseList.AllowUserToAddRows = false;
            this.dgvLocalLicenseList.AllowUserToDeleteRows = false;
            this.dgvLocalLicenseList.AllowUserToResizeRows = false;
            this.dgvLocalLicenseList.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvLocalLicenseList.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvLocalLicenseList.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dgvLocalLicenseList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvLocalLicenseList.Location = new System.Drawing.Point(12, 43);
            this.dgvLocalLicenseList.Name = "dgvLocalLicenseList";
            this.dgvLocalLicenseList.ReadOnly = true;
            this.dgvLocalLicenseList.Size = new System.Drawing.Size(697, 153);
            this.dgvLocalLicenseList.TabIndex = 39;
            // 
            // btnClose
            // 
            this.btnClose.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.ImageKey = "(none)";
            this.btnClose.Location = new System.Drawing.Point(610, 534);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(119, 34);
            this.btnClose.TabIndex = 37;
            this.btnClose.Text = "Close";
            this.btnClose.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // lblLocalLicenseNumberOfRecords
            // 
            this.lblLocalLicenseNumberOfRecords.Font = new System.Drawing.Font("Constantia", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLocalLicenseNumberOfRecords.ForeColor = System.Drawing.Color.Black;
            this.lblLocalLicenseNumberOfRecords.Location = new System.Drawing.Point(8, 202);
            this.lblLocalLicenseNumberOfRecords.Name = "lblLocalLicenseNumberOfRecords";
            this.lblLocalLicenseNumberOfRecords.Size = new System.Drawing.Size(327, 34);
            this.lblLocalLicenseNumberOfRecords.TabIndex = 36;
            this.lblLocalLicenseNumberOfRecords.Text = "Number of Records: ";
            this.lblLocalLicenseNumberOfRecords.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Constantia", 14.25F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(8, 6);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(193, 34);
            this.label1.TabIndex = 38;
            this.label1.Text = "Local License History";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // tpInternationalLicenses
            // 
            this.tpInternationalLicenses.BackColor = System.Drawing.Color.Silver;
            this.tpInternationalLicenses.Controls.Add(this.dgvInternationalLicenseList);
            this.tpInternationalLicenses.Controls.Add(this.lblInternationalLicenseNumberOfRecords);
            this.tpInternationalLicenses.Controls.Add(this.s);
            this.tpInternationalLicenses.Location = new System.Drawing.Point(4, 22);
            this.tpInternationalLicenses.Name = "tpInternationalLicenses";
            this.tpInternationalLicenses.Padding = new System.Windows.Forms.Padding(3);
            this.tpInternationalLicenses.Size = new System.Drawing.Size(720, 242);
            this.tpInternationalLicenses.TabIndex = 1;
            this.tpInternationalLicenses.Text = "International";
            // 
            // ctrlPersonCard1
            // 
            this.ctrlPersonCard1.BackColor = System.Drawing.Color.Gray;
            this.ctrlPersonCard1.Location = new System.Drawing.Point(3, -42);
            this.ctrlPersonCard1.Name = "ctrlPersonCard1";
            this.ctrlPersonCard1.Size = new System.Drawing.Size(754, 365);
            this.ctrlPersonCard1.TabIndex = 0;
            // 
            // dgvInternationalLicenseList
            // 
            this.dgvInternationalLicenseList.AllowUserToAddRows = false;
            this.dgvInternationalLicenseList.AllowUserToDeleteRows = false;
            this.dgvInternationalLicenseList.AllowUserToResizeRows = false;
            this.dgvInternationalLicenseList.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvInternationalLicenseList.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvInternationalLicenseList.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dgvInternationalLicenseList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvInternationalLicenseList.Location = new System.Drawing.Point(12, 43);
            this.dgvInternationalLicenseList.Name = "dgvInternationalLicenseList";
            this.dgvInternationalLicenseList.ReadOnly = true;
            this.dgvInternationalLicenseList.Size = new System.Drawing.Size(697, 153);
            this.dgvInternationalLicenseList.TabIndex = 43;
            // 
            // lblInternationalLicenseNumberOfRecords
            // 
            this.lblInternationalLicenseNumberOfRecords.Font = new System.Drawing.Font("Constantia", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblInternationalLicenseNumberOfRecords.ForeColor = System.Drawing.Color.Black;
            this.lblInternationalLicenseNumberOfRecords.Location = new System.Drawing.Point(8, 202);
            this.lblInternationalLicenseNumberOfRecords.Name = "lblInternationalLicenseNumberOfRecords";
            this.lblInternationalLicenseNumberOfRecords.Size = new System.Drawing.Size(327, 34);
            this.lblInternationalLicenseNumberOfRecords.TabIndex = 40;
            this.lblInternationalLicenseNumberOfRecords.Text = "Number of Records: ";
            this.lblInternationalLicenseNumberOfRecords.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // s
            // 
            this.s.Font = new System.Drawing.Font("Constantia", 14.25F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.s.ForeColor = System.Drawing.Color.Black;
            this.s.Location = new System.Drawing.Point(8, 6);
            this.s.Name = "s";
            this.s.Size = new System.Drawing.Size(358, 34);
            this.s.TabIndex = 42;
            this.s.Text = "International License History";
            this.s.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // frmPersonLicenseHistory
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Gray;
            this.ClientSize = new System.Drawing.Size(760, 590);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.ctrlPersonCard1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmPersonLicenseHistory";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "License History";
            this.Load += new System.EventHandler(this.frmPersonLicenseHistory_Load);
            this.tabControl1.ResumeLayout(false);
            this.tpLocalLicenses.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvLocalLicenseList)).EndInit();
            this.tpInternationalLicenses.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvInternationalLicenseList)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private ctrlPersonCard ctrlPersonCard1;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tpLocalLicenses;
        private System.Windows.Forms.DataGridView dgvLocalLicenseList;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Label lblLocalLicenseNumberOfRecords;
        private System.Windows.Forms.TabPage tpInternationalLicenses;
        private System.Windows.Forms.DataGridView dgvInternationalLicenseList;
        private System.Windows.Forms.Label lblInternationalLicenseNumberOfRecords;
        private System.Windows.Forms.Label s;
    }
}