namespace DVLD.People
{
    partial class ctrlPersonCardFinder
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ctrlPersonCardFinder));
            this.ctrlPersonCard1 = new DVLD.People.ctrlPersonCard();
            this.pnlFinder = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.cbFindBy = new System.Windows.Forms.ComboBox();
            this.txbFindBy = new System.Windows.Forms.TextBox();
            this.btnAddPerson = new System.Windows.Forms.Button();
            this.btnFind = new System.Windows.Forms.Button();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.pnlFinder.SuspendLayout();
            this.SuspendLayout();
            // 
            // ctrlPersonCard1
            // 
            this.ctrlPersonCard1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(25)))), ((int)(((byte)(25)))));
            this.ctrlPersonCard1.Location = new System.Drawing.Point(0, 62);
            this.ctrlPersonCard1.Name = "ctrlPersonCard1";
            this.ctrlPersonCard1.Size = new System.Drawing.Size(639, 255);
            this.ctrlPersonCard1.TabIndex = 0;
            // 
            // pnlFinder
            // 
            this.pnlFinder.Controls.Add(this.btnAddPerson);
            this.pnlFinder.Controls.Add(this.btnFind);
            this.pnlFinder.Controls.Add(this.txbFindBy);
            this.pnlFinder.Controls.Add(this.cbFindBy);
            this.pnlFinder.Controls.Add(this.label1);
            this.pnlFinder.Location = new System.Drawing.Point(3, 3);
            this.pnlFinder.Name = "pnlFinder";
            this.pnlFinder.Size = new System.Drawing.Size(633, 53);
            this.pnlFinder.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Consolas", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Silver;
            this.label1.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.label1.Location = new System.Drawing.Point(3, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(81, 20);
            this.label1.TabIndex = 40;
            this.label1.Text = "Find By:";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // cbFindBy
            // 
            this.cbFindBy.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbFindBy.FormattingEnabled = true;
            this.cbFindBy.Items.AddRange(new object[] {
            "PersonID",
            "NationalNo"});
            this.cbFindBy.Location = new System.Drawing.Point(104, 17);
            this.cbFindBy.Name = "cbFindBy";
            this.cbFindBy.Size = new System.Drawing.Size(201, 21);
            this.cbFindBy.TabIndex = 43;
            // 
            // txbFindBy
            // 
            this.txbFindBy.AcceptsReturn = true;
            this.txbFindBy.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txbFindBy.Location = new System.Drawing.Point(311, 18);
            this.txbFindBy.Name = "txbFindBy";
            this.txbFindBy.Size = new System.Drawing.Size(175, 20);
            this.txbFindBy.TabIndex = 44;
            this.txbFindBy.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txbFindBy_KeyDown);
            // 
            // btnAddPerson
            // 
            this.btnAddPerson.BackColor = System.Drawing.Color.White;
            this.btnAddPerson.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.btnAddPerson.FlatAppearance.BorderSize = 2;
            this.btnAddPerson.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnAddPerson.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Gray;
            this.btnAddPerson.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAddPerson.ForeColor = System.Drawing.Color.Black;
            this.btnAddPerson.ImageKey = "add.png";
            this.btnAddPerson.ImageList = this.imageList1;
            this.btnAddPerson.Location = new System.Drawing.Point(565, 10);
            this.btnAddPerson.Name = "btnAddPerson";
            this.btnAddPerson.Size = new System.Drawing.Size(50, 37);
            this.btnAddPerson.TabIndex = 47;
            this.btnAddPerson.UseVisualStyleBackColor = false;
            this.btnAddPerson.Click += new System.EventHandler(this.btnAddPerson_Click);
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
            this.btnFind.Location = new System.Drawing.Point(509, 10);
            this.btnFind.Name = "btnFind";
            this.btnFind.Size = new System.Drawing.Size(50, 37);
            this.btnFind.TabIndex = 46;
            this.btnFind.UseVisualStyleBackColor = false;
            this.btnFind.Click += new System.EventHandler(this.btnFind_Click);
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "add.png");
            this.imageList1.Images.SetKeyName(1, "find.png");
            // 
            // ctrlPersonCardFinder
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(25)))), ((int)(((byte)(25)))));
            this.Controls.Add(this.pnlFinder);
            this.Controls.Add(this.ctrlPersonCard1);
            this.Name = "ctrlPersonCardFinder";
            this.Size = new System.Drawing.Size(639, 320);
            this.Load += new System.EventHandler(this.ctrlPersonCardFinder_Load);
            this.pnlFinder.ResumeLayout(false);
            this.pnlFinder.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private ctrlPersonCard ctrlPersonCard1;
        private System.Windows.Forms.Panel pnlFinder;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnAddPerson;
        private System.Windows.Forms.Button btnFind;
        private System.Windows.Forms.TextBox txbFindBy;
        private System.Windows.Forms.ComboBox cbFindBy;
        private System.Windows.Forms.ImageList imageList1;
    }
}
