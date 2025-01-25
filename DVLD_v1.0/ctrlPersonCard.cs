using DVLD_BusinessLayer;
using System.Windows.Forms;

namespace DVLD_v1._0
{
    public partial class ctrlPersonCard : UserControl
    {
        public ctrlPersonCard()
        {
            InitializeComponent();
        }

        public int _PersonID = -1;

        public bool LoadPersonInfo(clsPerson person)
        {
            if (person == null)
                return false;

            _PersonID = person.ID;
            lblID.Text = _PersonID.ToString();
            lblFullName.Text = $"{person.FirstName} {person.SecondName} {person.ThirdName} {person.LastName}";
            lblNationalNo.Text = person.NationalNumber;
            lblGender.Text = person.Gender == 0 ? "Male" : "Female";
            lblEmail.Text = person.Email;
            lblAddress.Text = person.Address;
            lblPhone.Text = person.Phone;
            lblDateOfBirth.Text = person.DateOfBirth.ToString("yyyy/MMM/dd");
            lblCountry.Text = clsCountry.GetCountryName(person.NationalityCountryID);

            if (string.IsNullOrWhiteSpace(person.ImagePath))
                pbPersonImage.Image = person.Gender == 0 ? Properties.Resources.default_male : Properties.Resources.default_female;
            else
                pbPersonImage.ImageLocation = person.ImagePath;
            
            return true;

        }
        public bool LoadPersonInfo(int PersonID)
        {
            clsPerson person = clsPerson.Find(PersonID);
                
            return LoadPersonInfo(person);
        }
        public bool LoadPersonInfo(string NationalNo)
        {
            clsPerson person = clsPerson.Find(NationalNo);

            return LoadPersonInfo(person);
        }

        //Disable or Enable edit button 
        public void SwitchEditButtonState()
        {
            llEditDetails.Enabled = !llEditDetails.Enabled;
        }

        public void ChangeTitle(string title)
        {
            lblTitle.Text = title.ToString();
        }

        private void llEditDetails_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {

            frmAddEditPeople editPerson = new frmAddEditPeople(_PersonID);

            //Traverse up the hierarchy to find the MDI parent if available
            Form parentForm = this.FindForm();
            if (parentForm.MdiParent != null)
            {
                editPerson.MdiParent = parentForm.MdiParent;

                editPerson.FormClosed += EditPerson_FormClosed;
                editPerson.Show();
            }
            else
            {
                MessageBox.Show("MDI parent not found!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void EditPerson_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (_PersonID != -1)
                LoadPersonInfo(clsPerson.Find(_PersonID));
        }

    }
}
