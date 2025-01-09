namespace DVLD_v1._0
{
    partial class frmAddEditPeople
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmAddEditPeople));
            this.lblTitle = new System.Windows.Forms.Label();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.lblPersonID = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.llRemoveImage = new System.Windows.Forms.LinkLabel();
            this.llSetImage = new System.Windows.Forms.LinkLabel();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnClear = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.txbAddress = new System.Windows.Forms.TextBox();
            this.cbCountries = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txbEmail = new System.Windows.Forms.TextBox();
            this.lblAddress = new System.Windows.Forms.Label();
            this.lblEmail = new System.Windows.Forms.Label();
            this.txbPhone = new System.Windows.Forms.TextBox();
            this.lblPhone = new System.Windows.Forms.Label();
            this.rbFemale = new System.Windows.Forms.RadioButton();
            this.rbMale = new System.Windows.Forms.RadioButton();
            this.lblGender = new System.Windows.Forms.Label();
            this.pbPersonImage = new System.Windows.Forms.PictureBox();
            this.dtpDateOfBirth = new System.Windows.Forms.DateTimePicker();
            this.lblDateOfBirth = new System.Windows.Forms.Label();
            this.txbNationalNo = new System.Windows.Forms.TextBox();
            this.lblNationalNo = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txbLastName = new System.Windows.Forms.TextBox();
            this.txbThirdName = new System.Windows.Forms.TextBox();
            this.txbSecondName = new System.Windows.Forms.TextBox();
            this.txbFirstName = new System.Windows.Forms.TextBox();
            this.lblName = new System.Windows.Forms.Label();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.lbl1 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbPersonImage)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // lblTitle
            // 
            this.lblTitle.Font = new System.Drawing.Font("Copperplate Gothic Bold", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.ForeColor = System.Drawing.SystemColors.Control;
            this.lblTitle.Location = new System.Drawing.Point(123, 9);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(524, 34);
            this.lblTitle.TabIndex = 3;
            this.lblTitle.Text = "Add New Person";
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.imageList1.Images.SetKeyName(0, "fingerprint.png");
            this.imageList1.Images.SetKeyName(1, "user (3).png");
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
            // lblPersonID
            // 
            this.lblPersonID.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblPersonID.Font = new System.Drawing.Font("Consolas", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPersonID.ForeColor = System.Drawing.SystemColors.Control;
            this.lblPersonID.Location = new System.Drawing.Point(132, 39);
            this.lblPersonID.Name = "lblPersonID";
            this.lblPersonID.Size = new System.Drawing.Size(109, 28);
            this.lblPersonID.TabIndex = 6;
            this.lblPersonID.Text = "N/A";
            this.lblPersonID.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.BackColor = System.Drawing.Color.Silver;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel1.Controls.Add(this.llRemoveImage);
            this.panel1.Controls.Add(this.llSetImage);
            this.panel1.Controls.Add(this.btnClose);
            this.panel1.Controls.Add(this.btnClear);
            this.panel1.Controls.Add(this.btnSave);
            this.panel1.Controls.Add(this.txbAddress);
            this.panel1.Controls.Add(this.cbCountries);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.txbEmail);
            this.panel1.Controls.Add(this.lblAddress);
            this.panel1.Controls.Add(this.lblEmail);
            this.panel1.Controls.Add(this.txbPhone);
            this.panel1.Controls.Add(this.lblPhone);
            this.panel1.Controls.Add(this.rbFemale);
            this.panel1.Controls.Add(this.rbMale);
            this.panel1.Controls.Add(this.lblGender);
            this.panel1.Controls.Add(this.pbPersonImage);
            this.panel1.Controls.Add(this.dtpDateOfBirth);
            this.panel1.Controls.Add(this.lblDateOfBirth);
            this.panel1.Controls.Add(this.txbNationalNo);
            this.panel1.Controls.Add(this.lblNationalNo);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.txbLastName);
            this.panel1.Controls.Add(this.txbThirdName);
            this.panel1.Controls.Add(this.txbSecondName);
            this.panel1.Controls.Add(this.txbFirstName);
            this.panel1.Controls.Add(this.lblName);
            this.panel1.Location = new System.Drawing.Point(15, 70);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(743, 261);
            this.panel1.TabIndex = 7;
            // 
            // llRemoveImage
            // 
            this.llRemoveImage.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.llRemoveImage.Location = new System.Drawing.Point(601, 230);
            this.llRemoveImage.Name = "llRemoveImage";
            this.llRemoveImage.Size = new System.Drawing.Size(100, 17);
            this.llRemoveImage.TabIndex = 37;
            this.llRemoveImage.TabStop = true;
            this.llRemoveImage.Text = "Remove Image";
            this.llRemoveImage.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.llRemoveImage.Visible = false;
            this.llRemoveImage.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.llRemoveImage_LinkClicked);
            // 
            // llSetImage
            // 
            this.llSetImage.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.llSetImage.Location = new System.Drawing.Point(601, 209);
            this.llSetImage.Name = "llSetImage";
            this.llSetImage.Size = new System.Drawing.Size(100, 17);
            this.llSetImage.TabIndex = 36;
            this.llSetImage.TabStop = true;
            this.llSetImage.Text = "Set Image";
            this.llSetImage.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.llSetImage.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.llSetImage_LinkClicked);
            // 
            // btnClose
            // 
            this.btnClose.CausesValidation = false;
            this.btnClose.FlatAppearance.MouseDownBackColor = System.Drawing.Color.DimGray;
            this.btnClose.FlatAppearance.MouseOverBackColor = System.Drawing.Color.White;
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClose.Font = new System.Drawing.Font("Consolas", 10F);
            this.btnClose.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnClose.ImageIndex = 12;
            this.btnClose.ImageList = this.imageList1;
            this.btnClose.Location = new System.Drawing.Point(236, 216);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(85, 31);
            this.btnClose.TabIndex = 35;
            this.btnClose.Text = "Close";
            this.btnClose.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnClear
            // 
            this.btnClear.FlatAppearance.MouseDownBackColor = System.Drawing.Color.DimGray;
            this.btnClear.FlatAppearance.MouseOverBackColor = System.Drawing.Color.White;
            this.btnClear.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClear.Font = new System.Drawing.Font("Consolas", 10F);
            this.btnClear.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnClear.ImageIndex = 11;
            this.btnClear.ImageList = this.imageList1;
            this.btnClear.Location = new System.Drawing.Point(337, 216);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(85, 31);
            this.btnClear.TabIndex = 34;
            this.btnClear.Text = "Clear";
            this.btnClear.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // btnSave
            // 
            this.btnSave.Enabled = false;
            this.btnSave.FlatAppearance.MouseDownBackColor = System.Drawing.Color.DimGray;
            this.btnSave.FlatAppearance.MouseOverBackColor = System.Drawing.Color.White;
            this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSave.Font = new System.Drawing.Font("Consolas", 10F);
            this.btnSave.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSave.ImageIndex = 10;
            this.btnSave.ImageList = this.imageList1;
            this.btnSave.Location = new System.Drawing.Point(438, 216);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(85, 31);
            this.btnSave.TabIndex = 33;
            this.btnSave.Text = "Save";
            this.btnSave.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // txbAddress
            // 
            this.txbAddress.Location = new System.Drawing.Point(148, 167);
            this.txbAddress.Multiline = true;
            this.txbAddress.Name = "txbAddress";
            this.txbAddress.Size = new System.Drawing.Size(423, 39);
            this.txbAddress.TabIndex = 32;
            this.txbAddress.Validating += new System.ComponentModel.CancelEventHandler(this.txbAddress_Validating);
            // 
            // cbCountries
            // 
            this.cbCountries.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbCountries.FormattingEnabled = true;
            this.cbCountries.Location = new System.Drawing.Point(438, 134);
            this.cbCountries.Name = "cbCountries";
            this.cbCountries.Size = new System.Drawing.Size(133, 21);
            this.cbCountries.TabIndex = 31;
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Consolas", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.label1.ImageIndex = 8;
            this.label1.ImageList = this.imageList1;
            this.label1.Location = new System.Drawing.Point(325, 133);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(104, 20);
            this.label1.TabIndex = 30;
            this.label1.Text = "Country:";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txbEmail
            // 
            this.txbEmail.Location = new System.Drawing.Point(148, 134);
            this.txbEmail.Name = "txbEmail";
            this.txbEmail.Size = new System.Drawing.Size(133, 20);
            this.txbEmail.TabIndex = 29;
            this.txbEmail.Validating += new System.ComponentModel.CancelEventHandler(this.txbEmail_Validating);
            // 
            // lblAddress
            // 
            this.lblAddress.Font = new System.Drawing.Font("Consolas", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAddress.ForeColor = System.Drawing.Color.Black;
            this.lblAddress.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lblAddress.ImageIndex = 9;
            this.lblAddress.ImageList = this.imageList1;
            this.lblAddress.Location = new System.Drawing.Point(12, 166);
            this.lblAddress.Name = "lblAddress";
            this.lblAddress.Size = new System.Drawing.Size(130, 20);
            this.lblAddress.TabIndex = 28;
            this.lblAddress.Text = "Address:";
            this.lblAddress.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblEmail
            // 
            this.lblEmail.Font = new System.Drawing.Font("Consolas", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEmail.ForeColor = System.Drawing.Color.Black;
            this.lblEmail.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lblEmail.ImageIndex = 7;
            this.lblEmail.ImageList = this.imageList1;
            this.lblEmail.Location = new System.Drawing.Point(12, 133);
            this.lblEmail.Name = "lblEmail";
            this.lblEmail.Size = new System.Drawing.Size(130, 20);
            this.lblEmail.TabIndex = 27;
            this.lblEmail.Text = "Email:";
            this.lblEmail.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txbPhone
            // 
            this.txbPhone.Location = new System.Drawing.Point(438, 100);
            this.txbPhone.Name = "txbPhone";
            this.txbPhone.Size = new System.Drawing.Size(133, 20);
            this.txbPhone.TabIndex = 26;
            this.txbPhone.Validating += new System.ComponentModel.CancelEventHandler(this.txbPhone_Validating);
            // 
            // lblPhone
            // 
            this.lblPhone.Font = new System.Drawing.Font("Consolas", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPhone.ForeColor = System.Drawing.Color.Black;
            this.lblPhone.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lblPhone.ImageIndex = 6;
            this.lblPhone.ImageList = this.imageList1;
            this.lblPhone.Location = new System.Drawing.Point(328, 100);
            this.lblPhone.Name = "lblPhone";
            this.lblPhone.Size = new System.Drawing.Size(101, 20);
            this.lblPhone.TabIndex = 25;
            this.lblPhone.Text = "Phone:";
            this.lblPhone.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // rbFemale
            // 
            this.rbFemale.AutoSize = true;
            this.rbFemale.Font = new System.Drawing.Font("Consolas", 11F);
            this.rbFemale.ImageList = this.imageList1;
            this.rbFemale.Location = new System.Drawing.Point(223, 99);
            this.rbFemale.Name = "rbFemale";
            this.rbFemale.Size = new System.Drawing.Size(74, 22);
            this.rbFemale.TabIndex = 24;
            this.rbFemale.TabStop = true;
            this.rbFemale.Text = "Female";
            this.rbFemale.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.rbFemale.UseVisualStyleBackColor = true;
            this.rbFemale.CheckedChanged += new System.EventHandler(this.rbFemale_CheckedChanged);
            // 
            // rbMale
            // 
            this.rbMale.AutoSize = true;
            this.rbMale.Font = new System.Drawing.Font("Consolas", 11F);
            this.rbMale.ImageList = this.imageList1;
            this.rbMale.Location = new System.Drawing.Point(148, 99);
            this.rbMale.Name = "rbMale";
            this.rbMale.Size = new System.Drawing.Size(58, 22);
            this.rbMale.TabIndex = 23;
            this.rbMale.TabStop = true;
            this.rbMale.Text = "Male";
            this.rbMale.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.rbMale.UseVisualStyleBackColor = true;
            this.rbMale.CheckedChanged += new System.EventHandler(this.rbMale_CheckedChanged);
            // 
            // lblGender
            // 
            this.lblGender.Font = new System.Drawing.Font("Consolas", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblGender.ForeColor = System.Drawing.Color.Black;
            this.lblGender.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lblGender.ImageKey = "user (2).png";
            this.lblGender.ImageList = this.imageList1;
            this.lblGender.Location = new System.Drawing.Point(12, 100);
            this.lblGender.Name = "lblGender";
            this.lblGender.Size = new System.Drawing.Size(130, 20);
            this.lblGender.TabIndex = 22;
            this.lblGender.Text = "Gender:";
            this.lblGender.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // pbPersonImage
            // 
            this.pbPersonImage.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pbPersonImage.Image = global::DVLD_v1._0.Properties.Resources.default_male;
            this.pbPersonImage.Location = new System.Drawing.Point(583, 63);
            this.pbPersonImage.Name = "pbPersonImage";
            this.pbPersonImage.Size = new System.Drawing.Size(143, 143);
            this.pbPersonImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbPersonImage.TabIndex = 21;
            this.pbPersonImage.TabStop = false;
            // 
            // dtpDateOfBirth
            // 
            this.dtpDateOfBirth.CustomFormat = "yyyy/MMM/dd";
            this.dtpDateOfBirth.Font = new System.Drawing.Font("Consolas", 10F);
            this.dtpDateOfBirth.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpDateOfBirth.Location = new System.Drawing.Point(438, 66);
            this.dtpDateOfBirth.Name = "dtpDateOfBirth";
            this.dtpDateOfBirth.Size = new System.Drawing.Size(125, 23);
            this.dtpDateOfBirth.TabIndex = 20;
            // 
            // lblDateOfBirth
            // 
            this.lblDateOfBirth.Font = new System.Drawing.Font("Consolas", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDateOfBirth.ForeColor = System.Drawing.Color.Black;
            this.lblDateOfBirth.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lblDateOfBirth.ImageIndex = 3;
            this.lblDateOfBirth.ImageList = this.imageList1;
            this.lblDateOfBirth.Location = new System.Drawing.Point(293, 67);
            this.lblDateOfBirth.Name = "lblDateOfBirth";
            this.lblDateOfBirth.Size = new System.Drawing.Size(130, 20);
            this.lblDateOfBirth.TabIndex = 19;
            this.lblDateOfBirth.Text = "Birth Date:";
            this.lblDateOfBirth.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txbNationalNo
            // 
            this.txbNationalNo.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txbNationalNo.Location = new System.Drawing.Point(148, 67);
            this.txbNationalNo.Name = "txbNationalNo";
            this.txbNationalNo.Size = new System.Drawing.Size(133, 20);
            this.txbNationalNo.TabIndex = 18;
            this.txbNationalNo.Validating += new System.ComponentModel.CancelEventHandler(this.txbNationalNo_Validating);
            // 
            // lblNationalNo
            // 
            this.lblNationalNo.Font = new System.Drawing.Font("Consolas", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNationalNo.ForeColor = System.Drawing.Color.Black;
            this.lblNationalNo.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lblNationalNo.ImageIndex = 2;
            this.lblNationalNo.ImageList = this.imageList1;
            this.lblNationalNo.Location = new System.Drawing.Point(12, 67);
            this.lblNationalNo.Name = "lblNationalNo";
            this.lblNationalNo.Size = new System.Drawing.Size(130, 20);
            this.lblNationalNo.TabIndex = 17;
            this.lblNationalNo.Text = "NationalNo:";
            this.lblNationalNo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label6
            // 
            this.label6.Font = new System.Drawing.Font("Consolas", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.Black;
            this.label6.Location = new System.Drawing.Point(583, 11);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(133, 20);
            this.label6.TabIndex = 16;
            this.label6.Text = "Last";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label5
            // 
            this.label5.Font = new System.Drawing.Font("Consolas", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.Black;
            this.label5.Location = new System.Drawing.Point(438, 11);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(133, 20);
            this.label5.TabIndex = 15;
            this.label5.Text = "Third";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label4
            // 
            this.label4.Font = new System.Drawing.Font("Consolas", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.Black;
            this.label4.Location = new System.Drawing.Point(293, 11);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(133, 20);
            this.label4.TabIndex = 14;
            this.label4.Text = "Second";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label3
            // 
            this.label3.Font = new System.Drawing.Font("Consolas", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Black;
            this.label3.Location = new System.Drawing.Point(148, 11);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(133, 20);
            this.label3.TabIndex = 13;
            this.label3.Text = "First";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txbLastName
            // 
            this.txbLastName.Location = new System.Drawing.Point(583, 34);
            this.txbLastName.Name = "txbLastName";
            this.txbLastName.Size = new System.Drawing.Size(133, 20);
            this.txbLastName.TabIndex = 12;
            this.txbLastName.Validating += new System.ComponentModel.CancelEventHandler(this.txbLastName_Validating);
            // 
            // txbThirdName
            // 
            this.txbThirdName.Location = new System.Drawing.Point(438, 34);
            this.txbThirdName.Name = "txbThirdName";
            this.txbThirdName.Size = new System.Drawing.Size(133, 20);
            this.txbThirdName.TabIndex = 11;
            // 
            // txbSecondName
            // 
            this.txbSecondName.Location = new System.Drawing.Point(293, 34);
            this.txbSecondName.Name = "txbSecondName";
            this.txbSecondName.Size = new System.Drawing.Size(133, 20);
            this.txbSecondName.TabIndex = 10;
            this.txbSecondName.Validating += new System.ComponentModel.CancelEventHandler(this.txbSecondName_Validating);
            // 
            // txbFirstName
            // 
            this.txbFirstName.Location = new System.Drawing.Point(148, 34);
            this.txbFirstName.Name = "txbFirstName";
            this.txbFirstName.Size = new System.Drawing.Size(133, 20);
            this.txbFirstName.TabIndex = 9;
            this.txbFirstName.Validating += new System.ComponentModel.CancelEventHandler(this.txbFirstName_Validating);
            // 
            // lblName
            // 
            this.lblName.Font = new System.Drawing.Font("Consolas", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblName.ForeColor = System.Drawing.Color.Black;
            this.lblName.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lblName.ImageIndex = 1;
            this.lblName.ImageList = this.imageList1;
            this.lblName.Location = new System.Drawing.Point(12, 34);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(130, 20);
            this.lblName.TabIndex = 8;
            this.lblName.Text = "Name:";
            this.lblName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            this.openFileDialog1.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.gif;*.bmp";
            this.openFileDialog1.RestoreDirectory = true;
            // 
            // errorProvider1
            // 
            this.errorProvider1.BlinkRate = 500;
            this.errorProvider1.BlinkStyle = System.Windows.Forms.ErrorBlinkStyle.AlwaysBlink;
            this.errorProvider1.ContainerControl = this;
            // 
            // lbl1
            // 
            this.lbl1.BackColor = System.Drawing.Color.Silver;
            this.lbl1.Font = new System.Drawing.Font("Consolas", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl1.ForeColor = System.Drawing.Color.Black;
            this.lbl1.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lbl1.ImageIndex = 0;
            this.lbl1.ImageList = this.imageList1;
            this.lbl1.Location = new System.Drawing.Point(15, 39);
            this.lbl1.Name = "lbl1";
            this.lbl1.Size = new System.Drawing.Size(111, 28);
            this.lbl1.TabIndex = 5;
            this.lbl1.Text = "Person ID: ";
            this.lbl1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // frmAddEditPeople
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.ClientSize = new System.Drawing.Size(770, 343);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.lblPersonID);
            this.Controls.Add(this.lbl1);
            this.Controls.Add(this.lblTitle);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmAddEditPeople";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Add/Edit People";
            this.Load += new System.EventHandler(this.frmAddEditPeople_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbPersonImage)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lbl1;
        private System.Windows.Forms.Label lblPersonID;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.TextBox txbLastName;
        private System.Windows.Forms.TextBox txbThirdName;
        private System.Windows.Forms.TextBox txbSecondName;
        private System.Windows.Forms.TextBox txbFirstName;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.Label lblNationalNo;
        private System.Windows.Forms.TextBox txbNationalNo;
        private System.Windows.Forms.DateTimePicker dtpDateOfBirth;
        private System.Windows.Forms.Label lblDateOfBirth;
        private System.Windows.Forms.PictureBox pbPersonImage;
        private System.Windows.Forms.Label lblGender;
        private System.Windows.Forms.RadioButton rbMale;
        private System.Windows.Forms.RadioButton rbFemale;
        private System.Windows.Forms.Label lblPhone;
        private System.Windows.Forms.TextBox txbPhone;
        private System.Windows.Forms.TextBox txbEmail;
        private System.Windows.Forms.Label lblAddress;
        private System.Windows.Forms.Label lblEmail;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txbAddress;
        private System.Windows.Forms.ComboBox cbCountries;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.LinkLabel llRemoveImage;
        private System.Windows.Forms.LinkLabel llSetImage;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.ErrorProvider errorProvider1;
    }
}