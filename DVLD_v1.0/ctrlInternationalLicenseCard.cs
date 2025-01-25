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

        }
        
    }
}
