using DVLD_BusinessLayer;
using System;
using System.Data;
using System.Windows.Forms;
using System.IO; //to copy, delete, edit files

namespace DVLD_v1._0
{
    public partial class frmAddEditPeople : Form
    {
        public delegate void DataBackEventHandler(object sender, int PersonID);
        public event DataBackEventHandler DataBack;

        private clsPerson.enMode _Mode = clsPerson.enMode.AddNew;

        private int _PersonID = -1;
        private clsPerson _Person = null;

        public frmAddEditPeople( int PersonID )
        {
            InitializeComponent();
            
            _PersonID = PersonID;
            _Mode = PersonID == -1 ? clsPerson.enMode.AddNew : clsPerson.enMode.Update; 
        }

        private void _FillCountriesInComboBox()
        {
            DataTable dtCountries = clsCountry.GetAllCountries();

            foreach ( DataRow row in dtCountries.Rows)
            {
                cbCountries.Items.Add(row["CountryName"] );
            }
            cbCountries.SelectedItem = "Oman";
        }
        private void _InitializeControlsValues()
        {
            rbMale.Checked = true;
            dtpDateOfBirth.MaxDate = DateTime.Now.AddYears(-18); //to make only above 18yo dates
            _FillCountriesInComboBox();
        }

        private void _FillPersonInfoInEditForm(clsPerson person)
        {
            lblPersonID.Text = person.ID.ToString();
            txbFirstName.Text = person.FirstName;
            txbSecondName.Text = person.SecondName;
            txbThirdName.Text = person.ThirdName;
            txbLastName.Text = person.LastName;
            txbNationalNo.Text = person.NationalNumber;
            dtpDateOfBirth.Value = person.DateOfBirth;
            rbMale.Checked = person.Gender == 0;
            rbFemale.Checked = person.Gender == 1;
            txbPhone.Text = person.Phone;
            txbEmail.Text = person.Email;
            cbCountries.SelectedIndex = person.NationalityCountryID - 1; // - 1 because CB index starts from 0, while in databse it start from 1
            txbAddress.Text = person.Address;

            if (!string.IsNullOrEmpty(person.ImagePath))
            {
                pbPersonImage.Load(person.ImagePath);
                llRemoveImage.Visible = true;
            }
        }

        private void _LoadData()
        {
            _InitializeControlsValues();

            if (_Mode == clsPerson.enMode.AddNew)
            {
                lblTitle.Text = "Add New Person";
                _Person = new clsPerson();
                return;
            }

            _Person = clsPerson.Find(_PersonID);

            if (_Person == null)
            {
                MessageBox.Show($"Person with ID = {_PersonID} Not Found!!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
                return;
            }

            lblTitle.Text = "Edit Person ID = " + _PersonID.ToString();
            _FillPersonInfoInEditForm(_Person);
        }

        private void frmAddEditPeople_Load(object sender, EventArgs e)
        {
            _LoadData();
        }

        private bool _isClosing = false;
        private void btnClose_Click(object sender, EventArgs e)
        {
            if(lblPersonID.Text != "N/A")
                DataBack?.Invoke(this, Convert.ToInt32(lblPersonID.Text)); //this line was added later while working on ctrlPersonCardWithFilter

            _isClosing = true;
            this.Close();
        }

        //returns the new image path
        private string _SavePersonImage()
        {
            if (string.IsNullOrEmpty(pbPersonImage.ImageLocation))
                return string.Empty;

            string PeopleImagesFolderPath = @"F:\ProgrammingAdvices\Course 19 - Full Real Project\DVLD-People_Images";
            Directory.CreateDirectory(PeopleImagesFolderPath); // Ensure the directory exists

            string UniqueFileName = Guid.NewGuid().ToString() + Path.GetExtension(pbPersonImage.ImageLocation);
            string NewImagePath = Path.Combine(PeopleImagesFolderPath, UniqueFileName);

            try
            {
                File.Copy(pbPersonImage.ImageLocation, NewImagePath, true);
                return NewImagePath;
            }
            catch(Exception ex)
            {
                MessageBox.Show("An error occurred while copying the image: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null; // Return null if there was an error
            }


        }

        private void _HandlePersonImage()
        {
            if (pbPersonImage.ImageLocation == _Person.ImagePath)
                return;

            if (!string.IsNullOrEmpty(_Person.ImagePath))
            {
                //if picturBox image changed
                if (pbPersonImage.ImageLocation != _Person.ImagePath)
                {
                    try
                    {
                        if (File.Exists(_Person.ImagePath))
                            File.Delete(_Person.ImagePath); //delete old image
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("An error occurred while deleting the old image: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }

            //now we save the new image if there is one
            if (!string.IsNullOrEmpty(pbPersonImage.ImageLocation))
            {
                // Call method to save image and update path
                _Person.ImagePath = _SavePersonImage(); // Save new image and update path
            }
            else
            {
                _Person.ImagePath = null; // Set to null if no image
            }

        }

        private void _FillPersonObject()
        {
            _Person.FirstName = txbFirstName.Text;
            _Person.SecondName = txbSecondName.Text;
            _Person.ThirdName = txbThirdName.Text;
            _Person.LastName = txbLastName.Text;
            _Person.NationalNumber = txbNationalNo.Text;
            _Person.DateOfBirth = dtpDateOfBirth.Value;
            _Person.Gender = rbMale.Checked ? (byte)0 : (byte)1;
            _Person.Phone = txbPhone.Text;
            _Person.Email = txbEmail.Text;
            _Person.NationalityCountryID = cbCountries.SelectedIndex + 1; // +1 because CB index starts from 0, while in database it start from 1 
            _Person.Address = txbAddress.Text;
            _HandlePersonImage();

        }

        private void _UpdateFormLabels()
        {
            lblTitle.Text = "Edit Person ID = " + _Person.ID.ToString();
            lblPersonID.Text = _Person.ID.ToString();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            _FillPersonObject();

            if(_Person.Save())
                MessageBox.Show("Person Data Saved Successfully.", "Done");
            else
                MessageBox.Show("Error: Person Data was NOT Saved Successfully.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            _Mode = clsPerson.enMode.Update;
            _UpdateFormLabels();

        }

        private void llSetImage_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                pbPersonImage.Load(openFileDialog1.FileName);
                llRemoveImage.Visible = true;
            }
        }

        private void llRemoveImage_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            llRemoveImage.Visible = false;
            pbPersonImage.ImageLocation = null;
            pbPersonImage.Image = rbMale.Checked ? Properties.Resources.default_male : Properties.Resources.default_female;

        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            btnSave.Enabled = false;

            txbFirstName.Text = string.Empty;
            txbSecondName.Text = string.Empty;
            txbThirdName.Text = string.Empty;
            txbLastName.Text = string.Empty;
            txbNationalNo.Text = string.Empty;
            dtpDateOfBirth.Value = dtpDateOfBirth.MaxDate;
            rbMale.Checked = true;
            txbPhone.Text = string.Empty;
            txbEmail.Text = string.Empty;
            cbCountries.SelectedIndex = 130; //130 for Oman
            txbAddress.Text = string.Empty;

        }

        private void _UpdateSaveButtonState()
        {
            bool isFieldsFilled = !string.IsNullOrWhiteSpace(txbFirstName.Text) &&
                                   !string.IsNullOrWhiteSpace(txbSecondName.Text) &&
                                   !string.IsNullOrWhiteSpace(txbLastName.Text) &&
                                   !string.IsNullOrWhiteSpace(txbNationalNo.Text) &&
                                   !string.IsNullOrWhiteSpace(txbPhone.Text) &&
                                   !string.IsNullOrWhiteSpace(txbAddress.Text);

            btnSave.Enabled = isFieldsFilled;
        }
        private void _ValidateTextBox(string ErrorMessage, TextBox txb, System.ComponentModel.CancelEventArgs e)
        {
            if (_isClosing)
                return;

            if (string.IsNullOrWhiteSpace(txb.Text))
            {
                e.Cancel = true; //this will automaticlly set focus on txb
                errorProvider1.SetError(txb, ErrorMessage);
            }
            else
            {
                e.Cancel = false;
                errorProvider1.SetError(txb, string.Empty);
            }

            _UpdateSaveButtonState();
        }
        
        private void txbFirstName_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            _ValidateTextBox("First Name is required.", txbFirstName,  e);
        }
        private void txbSecondName_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            _ValidateTextBox("Second Name is required.", txbSecondName, e);
        }
        private void txbLastName_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            _ValidateTextBox("Last Name is required.", txbLastName, e);
        }
        private void txbPhone_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            _ValidateTextBox("Phone Number is required.", txbPhone, e);
        }
        private void txbAddress_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            _ValidateTextBox("Address is required.", txbAddress, e);
        }

        private void txbNationalNo_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (_isClosing)
                return;

            string NationalNo = txbNationalNo.Text;

            if (string.IsNullOrWhiteSpace(NationalNo))
            {
                e.Cancel = true;
                errorProvider1.SetError(txbNationalNo, "National Number is required");
            }
            else if (clsPerson.IsPersonExist(NationalNo))
            {
                e.Cancel = true;
                errorProvider1.SetError(txbNationalNo, "National Number already exists!");
            }
            else
                errorProvider1.SetError(txbNationalNo, string.Empty);
        }

        private void txbEmail_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (_isClosing)
                return;

            if (!txbEmail.Text.Contains("@") && !string.IsNullOrWhiteSpace(txbEmail.Text))
            {
                e.Cancel = true;
                errorProvider1.SetError(txbEmail, "Invalid Email Format");
            }
            else
                errorProvider1.SetError(txbEmail, string.Empty);

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

        

    }
}
