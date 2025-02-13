namespace DVLD.License.Local_Licenses
{
    partial class ctrlLicenseCardFinder
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ctrlLicenseCardFinder));
            this.ctrlLicenseCard1 = new DVLD.License.ctrlLicenseCard();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.pnlFinder = new System.Windows.Forms.Panel();
            this.btnFind = new System.Windows.Forms.Button();
            this.txbSearch = new System.Windows.Forms.TextBox();
            this.lbl1 = new System.Windows.Forms.Label();
            this.pnlFinder.SuspendLayout();
            this.SuspendLayout();
            // 
            // ctrlLicenseCard1
            // 
            this.ctrlLicenseCard1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.ctrlLicenseCard1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.ctrlLicenseCard1.Location = new System.Drawing.Point(0, 65);
            this.ctrlLicenseCard1.Name = "ctrlLicenseCard1";
            this.ctrlLicenseCard1.Size = new System.Drawing.Size(804, 341);
            this.ctrlLicenseCard1.TabIndex = 0;
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "add.png");
            this.imageList1.Images.SetKeyName(1, "find.png");
            // 
            // pnlFinder
            // 
            this.pnlFinder.Controls.Add(this.btnFind);
            this.pnlFinder.Controls.Add(this.txbSearch);
            this.pnlFinder.Controls.Add(this.lbl1);
            this.pnlFinder.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlFinder.Location = new System.Drawing.Point(0, 0);
            this.pnlFinder.Name = "pnlFinder";
            this.pnlFinder.Size = new System.Drawing.Size(804, 59);
            this.pnlFinder.TabIndex = 4;
            // 
            // btnFind
            // 
            this.btnFind.BackColor = System.Drawing.Color.White;
            this.btnFind.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.btnFind.FlatAppearance.BorderSize = 2;
            this.btnFind.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnFind.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Gray;
            this.btnFind.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnFind.ForeColor = System.Drawing.Color.Black;
            this.btnFind.ImageKey = "find.png";
            this.btnFind.ImageList = this.imageList1;
            this.btnFind.Location = new System.Drawing.Point(727, 7);
            this.btnFind.Name = "btnFind";
            this.btnFind.Size = new System.Drawing.Size(65, 45);
            this.btnFind.TabIndex = 50;
            this.btnFind.UseVisualStyleBackColor = false;
            // 
            // txbSearch
            // 
            this.txbSearch.AcceptsReturn = true;
            this.txbSearch.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txbSearch.Location = new System.Drawing.Point(153, 19);
            this.txbSearch.Name = "txbSearch";
            this.txbSearch.Size = new System.Drawing.Size(568, 20);
            this.txbSearch.TabIndex = 48;
            // 
            // lbl1
            // 
            this.lbl1.Font = new System.Drawing.Font("Consolas", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl1.ForeColor = System.Drawing.Color.White;
            this.lbl1.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lbl1.ImageKey = "id.png";
            this.lbl1.Location = new System.Drawing.Point(3, 11);
            this.lbl1.Name = "lbl1";
            this.lbl1.Size = new System.Drawing.Size(147, 36);
            this.lbl1.TabIndex = 49;
            this.lbl1.Text = "Enter License ID: ";
            this.lbl1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // ctrlLicenseCardFinder
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.Controls.Add(this.pnlFinder);
            this.Controls.Add(this.ctrlLicenseCard1);
            this.Name = "ctrlLicenseCardFinder";
            this.Size = new System.Drawing.Size(804, 406);
            this.Load += new System.EventHandler(this.ctrlLicenseCardFinder_Load);
            this.pnlFinder.ResumeLayout(false);
            this.pnlFinder.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private ctrlLicenseCard ctrlLicenseCard1;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.Panel pnlFinder;
        private System.Windows.Forms.Button btnFind;
        private System.Windows.Forms.TextBox txbSearch;
        private System.Windows.Forms.Label lbl1;
    }
}
