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
    public partial class ctrlLicenseCard : UserControl
    {
        public ctrlLicenseCard()
        {
            InitializeComponent();
        }

        public clsLicense License = null;
        public void LoadInfo(int LicenseID)
        {
            License = clsLicense.Find(LicenseID);
            clsApplication LicenseApplication = clsApplication.Find(License.ApplicationID);
            clsPerson LicenseOwner = clsPerson.Find(LicenseApplication.ApplicantID);

            lblFullName.Text = LicenseOwner.GetFullName();
            lblLicenseID.Text = LicenseID.ToString();
            lblNationalNo.Text = LicenseOwner.NationalNumber.ToString();
            lblGender.Text = LicenseOwner.Gender == 0 ? "Male" : "Female";
            lblDateOfBirth.Text = LicenseOwner.DateOfBirth.ToString("dd-MMM-yyyy");
            pbPersonImage.ImageLocation = LicenseOwner.ImagePath;

            lblDriverID.Text = License.DriverID.ToString();
            lblIssueDate.Text = License.IssueDate.ToString("dd-MMM-yyyy");
            lblNotes.Text = License.Notes.ToString();
            lblIsActive.Text = License.IsActive ? "Yes" : "No";
            lblExpirationDate.Text = License.ExpirationDate.ToString("dd-MMM-yyyy");
            lblIsDetained.Text = License.IsActive ? "No" : "Yes";

            lblLicenseClass.Text = clsLicenseClass.GetClassName(License.LicenseClassID);
            lblIssueReason.Text = clsLicense.GetIssueReasonString(License.IssueReason);

        }

        

    }
}
