using DVLD_BusinessLogicLayer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLD.People
{
    public partial class ctrlPersonCard : UserControl
    {
        public ctrlPersonCard()
        {
            InitializeComponent();
        }

        public clsPerson SelectedPerson = null;
        

        private void _FillCard()
        {
            lblID.Text = SelectedPerson.ID.ToString();
            lblFullName.Text = SelectedPerson.FullName;
            lblNationalNo.Text = SelectedPerson.NationalNo;
            lblDateOfBirth.Text = SelectedPerson.DateOfBirth.ToString("dd/MMM/yyyy");
            lblPhone.Text = SelectedPerson.Phone;
            lblEmail.Text = SelectedPerson.Email;
            lblAddress.Text = SelectedPerson.Address;
            lblCountry.Text = SelectedPerson.CountryInfo.Name;
            lblGender.Text = SelectedPerson.GenderText;

            if (string.IsNullOrEmpty(SelectedPerson.ImagePath))
                pbPersonImage.Image = SelectedPerson.enGender == clsPerson.enumGender.Male ? Properties.Resources.default_male : Properties.Resources.default_female;
            else
                pbPersonImage.ImageLocation = SelectedPerson.ImagePath; 

        }

        public void LoadPersonInfo(clsPerson Person)
        {
            if (Person != null)
            {
                SelectedPerson = Person;
                _FillCard();
                EnableEditDetailsButton = true;
            }
            else
                MessageBox.Show("Person Was Not Found", "Error",MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        public void LoadPersonInfo(int PersonID)
        {
            this.LoadPersonInfo(clsPerson.Find(PersonID));
        }
        public void LoadPersonInfo(string NationalNo)
        {
            this.LoadPersonInfo(clsPerson.Find(NationalNo));
        }


        private void llEditDetails_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmAddEditPerson frmAEP = new frmAddEditPerson(SelectedPerson.ID);
            frmAEP.FormClosed += FrmAEP_FormClosed;
            frmAEP.ShowDialog();
        }

        public bool EnableEditDetailsButton 
        { 
            set { llEditDetails.Enabled = value; }
        }

        private void FrmAEP_FormClosed(object sender, FormClosedEventArgs e)
        {
            _FillCard();
        }

        public void Clear()
        {
            SelectedPerson = null;
            lblID.Text = "[-1]";
            lblFullName.Text = "[???? ???? ???? ????]";
            lblNationalNo.Text = "[????]";
            lblDateOfBirth.Text = "[????]";
            lblPhone.Text = "[????]";
            lblEmail.Text = "[????]";
            lblAddress.Text = "[????]";
            lblCountry.Text = "[????]";
            lblGender.Text = "[????]";
            pbPersonImage.Image = Properties.Resources.default_male;
            EnableEditDetailsButton = false;
        }
    }
}
