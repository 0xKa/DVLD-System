using DVLD_BusinessLogicLayer;
using DVLD_BusinessLogicLayer.GlobalClasses;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using static DVLD_BusinessLogicLayer.clsGlobalSettings;

namespace DVLD.People
{
    public partial class frmAddEditPerson : Form
    {
        private enMode _Mode = enMode.AddNew;
        private clsPerson _Person = null;

        public frmAddEditPerson(int PersonID = -1)
        {
            InitializeComponent();

            if (PersonID == -1)
                { _Person = new clsPerson(); _Mode = enMode.AddNew; }
            else
                { _Person = clsPerson.Find(PersonID); _Mode = enMode.Update; }

        }

        private void _FillCountriesInComboBox()
        {
            DataTable dtCountries = clsCountry.GetAllCountries();

            foreach (DataRow row in dtCountries.Rows)
            {
                cbCountries.Items.Add(row["CountryName"]);
            }
            cbCountries.SelectedItem = "Oman";
        }
        private void _ClearControlsValue()
        {
            txbFirstName.Text = string.Empty;
            txbSecondName.Text = string.Empty;
            txbThirdName.Text = string.Empty;
            txbLastName.Text = string.Empty;
            txbNationalNo.Text = string.Empty;
            txbPhone.Text = string.Empty;
            txbEmail.Text = string.Empty;
            txbAddress.Text = string.Empty;
            rbMale.Checked = true;
            dtpDateOfBirth.Value = dtpDateOfBirth.MaxDate;
            cbCountries.SelectedItem = "Oman";
        }
        private void _SetDefaultValues()
        {
            _FillCountriesInComboBox();
            
            dtpDateOfBirth.MaxDate = DateTime.Now.AddYears(-18);
            dtpDateOfBirth.MinDate = DateTime.Now.AddYears(-100);
            dtpDateOfBirth.Value = dtpDateOfBirth.MaxDate;

            if (_Mode == enMode.AddNew)
            {
                lblTitle.Text = "Add New Person";
                pbModeIcon.Image = Properties.Resources.add_user;
                this.Text = "Add New Person";
            }
            else
            {
                lblTitle.Text = "Update Person";
                pbModeIcon.Image = Properties.Resources.edit_user;
                this.Text = "Update Person";
            }

            openFileDialog1.Filter = "Image Files|*.jpg;*.jpeg;*.png;";
            _ClearControlsValue();
        }

        private void _LoadPersonData()
        {
            lblPersonID.Text = _Person.ID.ToString();
            txbFirstName.Text = _Person.FirstName;
            txbSecondName.Text = _Person.SecondName;
            txbThirdName.Text = _Person.ThirdName;
            txbLastName.Text = _Person.LastName;
            txbNationalNo.Text = _Person.NationalNo;
            txbPhone.Text = _Person.Phone;
            txbEmail.Text = _Person.Email;
            txbAddress.Text = _Person.Address;
            cbCountries.SelectedItem = _Person.CountryInfo.Name;
            dtpDateOfBirth.Value = _Person.DateOfBirth;

            //handle gender
            if (_Person.enGender == enGender.Male)
                rbMale.Checked = true;
            else 
                rbFemale.Checked = false;

            //handle image
            if (string.IsNullOrEmpty(_Person.ImagePath))
                pbPersonImage.Image = rbMale.Checked ? Properties.Resources.default_male : Properties.Resources.default_female;
            else
                { pbPersonImage.ImageLocation = _Person.ImagePath; llRemoveImage.Visible = true; }

            txbNationalNo.Enabled = false; //can't edit NationalNo
        }

        private void frmAddEditPerson_Load(object sender, EventArgs e)
        {
            _SetDefaultValues();

            if (_Mode == enMode.Update)
                _LoadPersonData();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            _ClearControlsValue();
        }

        private void rbMale_CheckedChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(pbPersonImage.ImageLocation))
                pbPersonImage.Image = Properties.Resources.default_male;
        }
        private void rbFemale_CheckedChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(pbPersonImage.ImageLocation)) 
                pbPersonImage.Image = Properties.Resources.default_female;
        }

        private void llSetImage_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            try
            { 
                if (openFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    string fileExtension = Path.GetExtension(openFileDialog1.FileName).ToLower();
                    if (fileExtension == ".png" || fileExtension == ".jpg" || fileExtension == ".jpeg")
                    {
                        pbPersonImage.Load(openFileDialog1.FileName);
                        llRemoveImage.Visible = true;
                    }
                    else
                        MessageBox.Show("Only PNG, JPG, and JPEG files are allowed.", "Invalid File Type", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch
            {
                // Handle the case where the file is not a valid image
                MessageBox.Show("The selected file is not a valid image.\nFile must be in (.jpg), (.jpeg), or (.png) format", "Invalid File", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void llRemoveImage_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            llRemoveImage.Visible = false;
            pbPersonImage.ImageLocation = null;
            pbPersonImage.Image = rbMale.Checked ? Properties.Resources.default_male : Properties.Resources.default_female;
        }

        private bool _IsRequiredTextBoxesFilled()
        {
            return !string.IsNullOrWhiteSpace(txbFirstName.Text) &&
                    !string.IsNullOrWhiteSpace(txbSecondName.Text) &&
                    !string.IsNullOrWhiteSpace(txbLastName.Text) &&
                    !string.IsNullOrWhiteSpace(txbNationalNo.Text) &&
                    !string.IsNullOrWhiteSpace(txbPhone.Text) &&
                    !string.IsNullOrWhiteSpace(txbAddress.Text);
        }
        private bool _IsDataValid()
        {
            bool IsValid = false;
            if (!_IsRequiredTextBoxesFilled())
                MessageBox.Show("Please Fill Required Information", "Info Missing!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            else if (clsPerson.IsPersonExist(txbNationalNo.Text) && _Mode == enMode.AddNew)
                { MessageBox.Show("This National Number Already Exists", "National Number is not Valid!", MessageBoxButtons.OK, MessageBoxIcon.Information); txbNationalNo.Focus();}
            else if (!clsValidation.ValidateEmail(txbEmail.Text))
                { MessageBox.Show("Please Enter a Valid Email", "Email is not Valid!", MessageBoxButtons.OK, MessageBoxIcon.Information); txbEmail.Focus(); }
            else 
                IsValid = true;

            return IsValid;
        }

        private void _HandlePersonImage()
        {
            if (pbPersonImage.ImageLocation == _Person.ImagePath)
                return;

            if (!string.IsNullOrEmpty(_Person.ImagePath) && pbPersonImage.ImageLocation != _Person.ImagePath)
            {
                if (File.Exists(_Person.ImagePath))
                    File.Delete(_Person.ImagePath); //delete existing image because pb image is changed
            }

            if (!string.IsNullOrEmpty(pbPersonImage.ImageLocation))
                _Person.ImagePath = clsUtil.SaveNewImage(pbPersonImage.ImageLocation); 
            else
                _Person.ImagePath = null; 

        }
        private void _FillPersonObject()
        {
            _Person.FirstName = txbFirstName.Text;
            _Person.SecondName = txbSecondName.Text;
            _Person.ThirdName = txbThirdName.Text;
            _Person.LastName = txbLastName.Text;
            _Person.NationalNo = txbNationalNo.Text;
            _Person.DateOfBirth = dtpDateOfBirth.Value;
            _Person.Gender = rbMale.Checked ? (byte)1 : (byte)0;
            _Person.Phone = txbPhone.Text;
            _Person.Email = txbEmail.Text;
            _Person.NationalityCountryID = cbCountries.SelectedIndex + 1; // +1 because CB index starts from 0, while database start from 1 
            _Person.Address = txbAddress.Text;
            _HandlePersonImage();
        }
        private void _ChangeFormMode()
        {
            _Mode = enMode.Update;
            lblPersonID.Text = _Person.ID.ToString();
            lblTitle.Text = "Update Person";
            pbModeIcon.Image = Properties.Resources.edit_user;
            this.Text = "Update Person";
            txbNationalNo.Enabled = false;
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!_IsDataValid())
                return;

            _FillPersonObject();

            if (_Person.Save())
                MessageBox.Show("Person Data Saved Successfully.", "Done", MessageBoxButtons.OK, MessageBoxIcon.Information);
            else
                MessageBox.Show("Error: Person Data was NOT Saved Successfully.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            _ChangeFormMode();

        }
    }
}
