namespace DVLD_v1._0
{
    partial class ctrlPersonCard
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ctrlPersonCard));
            this.lblTitle = new System.Windows.Forms.Label();
            this.gbPersonInformation = new System.Windows.Forms.GroupBox();
            this.llEditDetails = new System.Windows.Forms.LinkLabel();
            this.lblCountry = new System.Windows.Forms.Label();
            this.lblPhone = new System.Windows.Forms.Label();
            this.lblDateOfBirth = new System.Windows.Forms.Label();
            this.lblAddress = new System.Windows.Forms.Label();
            this.lblEmail = new System.Windows.Forms.Label();
            this.lblGender = new System.Windows.Forms.Label();
            this.lblNationalNo = new System.Windows.Forms.Label();
            this.lblFullName = new System.Windows.Forms.Label();
            this.lblID = new System.Windows.Forms.Label();
            this.lbl1 = new System.Windows.Forms.Label();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.lbl9 = new System.Windows.Forms.Label();
            this.lbl6 = new System.Windows.Forms.Label();
            this.lbl5 = new System.Windows.Forms.Label();
            this.lbl8 = new System.Windows.Forms.Label();
            this.lbl4 = new System.Windows.Forms.Label();
            this.pbPersonImage = new System.Windows.Forms.PictureBox();
            this.lbl7 = new System.Windows.Forms.Label();
            this.lbl3 = new System.Windows.Forms.Label();
            this.lbl2 = new System.Windows.Forms.Label();
            this.gbPersonInformation.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbPersonImage)).BeginInit();
            this.SuspendLayout();
            // 
            // lblTitle
            // 
            this.lblTitle.Font = new System.Drawing.Font("Copperplate Gothic Bold", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lblTitle.Location = new System.Drawing.Point(17, 9);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(720, 34);
            this.lblTitle.TabIndex = 3;
            this.lblTitle.Text = "Person Details";
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // gbPersonInformation
            // 
            this.gbPersonInformation.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gbPersonInformation.Controls.Add(this.llEditDetails);
            this.gbPersonInformation.Controls.Add(this.lblCountry);
            this.gbPersonInformation.Controls.Add(this.lblPhone);
            this.gbPersonInformation.Controls.Add(this.lblDateOfBirth);
            this.gbPersonInformation.Controls.Add(this.lblAddress);
            this.gbPersonInformation.Controls.Add(this.lblEmail);
            this.gbPersonInformation.Controls.Add(this.lblGender);
            this.gbPersonInformation.Controls.Add(this.lblNationalNo);
            this.gbPersonInformation.Controls.Add(this.lblFullName);
            this.gbPersonInformation.Controls.Add(this.lblID);
            this.gbPersonInformation.Controls.Add(this.lbl1);
            this.gbPersonInformation.Controls.Add(this.lbl9);
            this.gbPersonInformation.Controls.Add(this.lbl6);
            this.gbPersonInformation.Controls.Add(this.lbl5);
            this.gbPersonInformation.Controls.Add(this.lbl8);
            this.gbPersonInformation.Controls.Add(this.lbl4);
            this.gbPersonInformation.Controls.Add(this.pbPersonImage);
            this.gbPersonInformation.Controls.Add(this.lbl7);
            this.gbPersonInformation.Controls.Add(this.lbl3);
            this.gbPersonInformation.Controls.Add(this.lbl2);
            this.gbPersonInformation.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbPersonInformation.ForeColor = System.Drawing.SystemColors.Control;
            this.gbPersonInformation.Location = new System.Drawing.Point(17, 46);
            this.gbPersonInformation.Name = "gbPersonInformation";
            this.gbPersonInformation.Size = new System.Drawing.Size(720, 299);
            this.gbPersonInformation.TabIndex = 4;
            this.gbPersonInformation.TabStop = false;
            this.gbPersonInformation.Text = "Person Information";
            // 
            // llEditDetails
            // 
            this.llEditDetails.AutoSize = true;
            this.llEditDetails.Font = new System.Drawing.Font("Copperplate Gothic Bold", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.llEditDetails.Location = new System.Drawing.Point(588, 258);
            this.llEditDetails.Name = "llEditDetails";
            this.llEditDetails.Size = new System.Drawing.Size(116, 18);
            this.llEditDetails.TabIndex = 50;
            this.llEditDetails.TabStop = true;
            this.llEditDetails.Text = "Edit Details";
            this.llEditDetails.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.llEditDetails_LinkClicked);
            // 
            // lblCountry
            // 
            this.lblCountry.Font = new System.Drawing.Font("Consolas", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCountry.ForeColor = System.Drawing.Color.Black;
            this.lblCountry.Location = new System.Drawing.Point(465, 196);
            this.lblCountry.Name = "lblCountry";
            this.lblCountry.Size = new System.Drawing.Size(108, 43);
            this.lblCountry.TabIndex = 49;
            this.lblCountry.Text = "[????]";
            // 
            // lblPhone
            // 
            this.lblPhone.Font = new System.Drawing.Font("Consolas", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPhone.ForeColor = System.Drawing.Color.Black;
            this.lblPhone.Location = new System.Drawing.Point(465, 153);
            this.lblPhone.Name = "lblPhone";
            this.lblPhone.Size = new System.Drawing.Size(108, 20);
            this.lblPhone.TabIndex = 48;
            this.lblPhone.Text = "[????]";
            // 
            // lblDateOfBirth
            // 
            this.lblDateOfBirth.Font = new System.Drawing.Font("Consolas", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDateOfBirth.ForeColor = System.Drawing.Color.Black;
            this.lblDateOfBirth.Location = new System.Drawing.Point(465, 112);
            this.lblDateOfBirth.Name = "lblDateOfBirth";
            this.lblDateOfBirth.Size = new System.Drawing.Size(108, 20);
            this.lblDateOfBirth.TabIndex = 47;
            this.lblDateOfBirth.Text = "[????]";
            // 
            // lblAddress
            // 
            this.lblAddress.Font = new System.Drawing.Font("Consolas", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAddress.ForeColor = System.Drawing.Color.Black;
            this.lblAddress.Location = new System.Drawing.Point(166, 239);
            this.lblAddress.Name = "lblAddress";
            this.lblAddress.Size = new System.Drawing.Size(407, 38);
            this.lblAddress.TabIndex = 46;
            this.lblAddress.Text = "[????]";
            // 
            // lblEmail
            // 
            this.lblEmail.Font = new System.Drawing.Font("Consolas", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEmail.ForeColor = System.Drawing.Color.Black;
            this.lblEmail.Location = new System.Drawing.Point(166, 198);
            this.lblEmail.Name = "lblEmail";
            this.lblEmail.Size = new System.Drawing.Size(157, 20);
            this.lblEmail.TabIndex = 45;
            this.lblEmail.Text = "[????]";
            // 
            // lblGender
            // 
            this.lblGender.Font = new System.Drawing.Font("Consolas", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblGender.ForeColor = System.Drawing.Color.Black;
            this.lblGender.Location = new System.Drawing.Point(166, 154);
            this.lblGender.Name = "lblGender";
            this.lblGender.Size = new System.Drawing.Size(157, 20);
            this.lblGender.TabIndex = 44;
            this.lblGender.Text = "[????]";
            // 
            // lblNationalNo
            // 
            this.lblNationalNo.Font = new System.Drawing.Font("Consolas", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNationalNo.ForeColor = System.Drawing.Color.Black;
            this.lblNationalNo.Location = new System.Drawing.Point(166, 112);
            this.lblNationalNo.Name = "lblNationalNo";
            this.lblNationalNo.Size = new System.Drawing.Size(157, 20);
            this.lblNationalNo.TabIndex = 43;
            this.lblNationalNo.Text = "[????]";
            // 
            // lblFullName
            // 
            this.lblFullName.Font = new System.Drawing.Font("Consolas", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFullName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lblFullName.Location = new System.Drawing.Point(166, 70);
            this.lblFullName.Name = "lblFullName";
            this.lblFullName.Size = new System.Drawing.Size(335, 20);
            this.lblFullName.TabIndex = 42;
            this.lblFullName.Text = "[??? ???? ???? ????]";
            // 
            // lblID
            // 
            this.lblID.Font = new System.Drawing.Font("Consolas", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblID.ForeColor = System.Drawing.Color.Black;
            this.lblID.Location = new System.Drawing.Point(166, 28);
            this.lblID.Name = "lblID";
            this.lblID.Size = new System.Drawing.Size(125, 20);
            this.lblID.TabIndex = 41;
            this.lblID.Text = "[-1]";
            // 
            // lbl1
            // 
            this.lbl1.Font = new System.Drawing.Font("Consolas", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl1.ForeColor = System.Drawing.Color.White;
            this.lbl1.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lbl1.ImageKey = "id.png";
            this.lbl1.ImageList = this.imageList1;
            this.lbl1.Location = new System.Drawing.Point(15, 28);
            this.lbl1.Name = "lbl1";
            this.lbl1.Size = new System.Drawing.Size(130, 20);
            this.lbl1.TabIndex = 40;
            this.lbl1.Text = "Person ID: ";
            this.lbl1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.imageList1.Images.SetKeyName(0, "id.png");
            this.imageList1.Images.SetKeyName(1, "user (1).png");
            this.imageList1.Images.SetKeyName(2, "government.png");
            this.imageList1.Images.SetKeyName(3, "birthday.png");
            this.imageList1.Images.SetKeyName(4, "male-user.png");
            this.imageList1.Images.SetKeyName(5, "female.png");
            this.imageList1.Images.SetKeyName(6, "phone-call.png");
            this.imageList1.Images.SetKeyName(7, "email.png");
            this.imageList1.Images.SetKeyName(8, "coronavirus.png");
            this.imageList1.Images.SetKeyName(9, "location.png");
            this.imageList1.Images.SetKeyName(10, "diskette.png");
            this.imageList1.Images.SetKeyName(11, "broom.png");
            this.imageList1.Images.SetKeyName(12, "close (2).png");
            this.imageList1.Images.SetKeyName(13, "user (2).png");
            // 
            // lbl9
            // 
            this.lbl9.Font = new System.Drawing.Font("Consolas", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl9.ForeColor = System.Drawing.Color.White;
            this.lbl9.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lbl9.ImageIndex = 8;
            this.lbl9.ImageList = this.imageList1;
            this.lbl9.Location = new System.Drawing.Point(329, 196);
            this.lbl9.Name = "lbl9";
            this.lbl9.Size = new System.Drawing.Size(130, 20);
            this.lbl9.TabIndex = 39;
            this.lbl9.Text = "Country:";
            this.lbl9.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lbl6
            // 
            this.lbl6.Font = new System.Drawing.Font("Consolas", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl6.ForeColor = System.Drawing.Color.White;
            this.lbl6.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lbl6.ImageIndex = 9;
            this.lbl6.ImageList = this.imageList1;
            this.lbl6.Location = new System.Drawing.Point(15, 238);
            this.lbl6.Name = "lbl6";
            this.lbl6.Size = new System.Drawing.Size(130, 20);
            this.lbl6.TabIndex = 38;
            this.lbl6.Text = "Address:";
            this.lbl6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lbl5
            // 
            this.lbl5.Font = new System.Drawing.Font("Consolas", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl5.ForeColor = System.Drawing.Color.White;
            this.lbl5.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lbl5.ImageIndex = 7;
            this.lbl5.ImageList = this.imageList1;
            this.lbl5.Location = new System.Drawing.Point(15, 196);
            this.lbl5.Name = "lbl5";
            this.lbl5.Size = new System.Drawing.Size(130, 20);
            this.lbl5.TabIndex = 37;
            this.lbl5.Text = "Email:";
            this.lbl5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lbl8
            // 
            this.lbl8.Font = new System.Drawing.Font("Consolas", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl8.ForeColor = System.Drawing.Color.White;
            this.lbl8.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lbl8.ImageIndex = 6;
            this.lbl8.ImageList = this.imageList1;
            this.lbl8.Location = new System.Drawing.Point(329, 153);
            this.lbl8.Name = "lbl8";
            this.lbl8.Size = new System.Drawing.Size(130, 20);
            this.lbl8.TabIndex = 36;
            this.lbl8.Text = "Phone:";
            this.lbl8.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lbl4
            // 
            this.lbl4.Font = new System.Drawing.Font("Consolas", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl4.ForeColor = System.Drawing.Color.White;
            this.lbl4.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lbl4.ImageKey = "user (2).png";
            this.lbl4.ImageList = this.imageList1;
            this.lbl4.Location = new System.Drawing.Point(15, 154);
            this.lbl4.Name = "lbl4";
            this.lbl4.Size = new System.Drawing.Size(130, 20);
            this.lbl4.TabIndex = 35;
            this.lbl4.Text = "Gender:";
            this.lbl4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // pbPersonImage
            // 
            this.pbPersonImage.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pbPersonImage.Image = global::DVLD_v1._0.Properties.Resources.default_male;
            this.pbPersonImage.Location = new System.Drawing.Point(579, 14);
            this.pbPersonImage.Name = "pbPersonImage";
            this.pbPersonImage.Size = new System.Drawing.Size(135, 135);
            this.pbPersonImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbPersonImage.TabIndex = 34;
            this.pbPersonImage.TabStop = false;
            // 
            // lbl7
            // 
            this.lbl7.Font = new System.Drawing.Font("Consolas", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl7.ForeColor = System.Drawing.Color.White;
            this.lbl7.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lbl7.ImageIndex = 3;
            this.lbl7.ImageList = this.imageList1;
            this.lbl7.Location = new System.Drawing.Point(329, 110);
            this.lbl7.Name = "lbl7";
            this.lbl7.Size = new System.Drawing.Size(130, 20);
            this.lbl7.TabIndex = 33;
            this.lbl7.Text = "Birth Date:";
            this.lbl7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lbl3
            // 
            this.lbl3.Font = new System.Drawing.Font("Consolas", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl3.ForeColor = System.Drawing.Color.White;
            this.lbl3.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lbl3.ImageIndex = 2;
            this.lbl3.ImageList = this.imageList1;
            this.lbl3.Location = new System.Drawing.Point(15, 112);
            this.lbl3.Name = "lbl3";
            this.lbl3.Size = new System.Drawing.Size(130, 20);
            this.lbl3.TabIndex = 32;
            this.lbl3.Text = "NationalNo:";
            this.lbl3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lbl2
            // 
            this.lbl2.Font = new System.Drawing.Font("Consolas", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl2.ForeColor = System.Drawing.Color.White;
            this.lbl2.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lbl2.ImageIndex = 1;
            this.lbl2.ImageList = this.imageList1;
            this.lbl2.Location = new System.Drawing.Point(15, 70);
            this.lbl2.Name = "lbl2";
            this.lbl2.Size = new System.Drawing.Size(130, 20);
            this.lbl2.TabIndex = 31;
            this.lbl2.Text = "Name:";
            this.lbl2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // ctrlPersonCard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Gray;
            this.Controls.Add(this.gbPersonInformation);
            this.Controls.Add(this.lblTitle);
            this.Name = "ctrlPersonCard";
            this.Size = new System.Drawing.Size(754, 365);
            this.gbPersonInformation.ResumeLayout(false);
            this.gbPersonInformation.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbPersonImage)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.GroupBox gbPersonInformation;
        private System.Windows.Forms.Label lbl9;
        private System.Windows.Forms.Label lbl6;
        private System.Windows.Forms.Label lbl5;
        private System.Windows.Forms.Label lbl8;
        private System.Windows.Forms.Label lbl4;
        private System.Windows.Forms.PictureBox pbPersonImage;
        private System.Windows.Forms.Label lbl7;
        private System.Windows.Forms.Label lbl3;
        private System.Windows.Forms.Label lbl2;
        private System.Windows.Forms.Label lbl1;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.Label lblID;
        private System.Windows.Forms.Label lblFullName;
        private System.Windows.Forms.Label lblDateOfBirth;
        private System.Windows.Forms.Label lblAddress;
        private System.Windows.Forms.Label lblEmail;
        private System.Windows.Forms.Label lblGender;
        private System.Windows.Forms.Label lblNationalNo;
        private System.Windows.Forms.Label lblCountry;
        private System.Windows.Forms.Label lblPhone;
        private System.Windows.Forms.LinkLabel llEditDetails;
    }
}
