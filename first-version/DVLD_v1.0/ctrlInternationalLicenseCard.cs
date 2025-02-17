using DVLD_BusinessLayer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLD_v1._0
{
    public partial class ctrlInternationalLicenseCard : UserControl
    {
        public ctrlInternationalLicenseCard()
        {
            InitializeComponent();
        }

        public clsInternationalLicense License = null;

        private void _ChangeLabelsColor()
        {
            lblIsActive.ForeColor = License.IsActive ? Color.Green : Color.Firebrick;
            lblIsDetained.ForeColor = License.IsDetained ? Color.Firebrick : Color.Green;
            lblExpirationDate.ForeColor = License.ExpirationDate <= DateTime.Now ? Color.Firebrick : Color.Green;
        }
        private void _LoadImage()
        {
            //handle image
            if (string.IsNullOrEmpty(License.DriverInfo.PersonInfo.ImagePath))
            {
                pbPersonImage.Image = License.DriverInfo.PersonInfo.enGender == clsPerson.enumGender.Male ? Properties.Resources.default_male : Properties.Resources.default_female;
            }
            else
            {
                if (File.Exists(License.DriverInfo.PersonInfo.ImagePath))
                    pbPersonImage.ImageLocation = License.DriverInfo.PersonInfo.ImagePath;
                else
                    MessageBox.Show($"Could Not Find the Image: {License.DriverInfo.PersonInfo.ImagePath}");
            }
        }
        public void LoadInfo(int InternationalLicenseID)
        {
            License = clsInternationalLicense.Find(InternationalLicenseID);

            clsApplication LicenseApplication = clsApplication.Find(License.ApplicationID);
            clsPerson LicenseOwner = clsPerson.Find(LicenseApplication.ApplicantID);

            lblInternationalLicenseID.Text = InternationalLicenseID.ToString();
            lblDriverID.Text = License.DriverID.ToString();
            lblIsActive.Text = License.IsActive ? "Yes" : "No";
            lblIssueDate.Text = License.IssueDate.ToString("dd/MMM/yyyy");
            lblExpirationDate.Text = License.ExpirationDate.ToString("dd/MMM/yyyy");
            lblApplicationID.Text = License.ApplicationID.ToString();
            lblLocalLicenseID.Text = License.IssuedUsingLocalLicenseID.ToString();

            lblFullName.Text = LicenseOwner.GetFullName();
            lblNationalNo.Text = LicenseOwner.NationalNumber.ToString();
            lblGender.Text = LicenseOwner.Gender == 0 ? "Male" : "Female";
            lblDateOfBirth.Text = LicenseOwner.DateOfBirth.ToString("dd/MMM/yyyy");
            pbPersonImage.ImageLocation = LicenseOwner.ImagePath;

            _LoadImage();
            _ChangeLabelsColor();
        }
        
    }
}
