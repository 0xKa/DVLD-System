using DVLD_BusinessLogicLayer;
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

namespace DVLD.License.International_License
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
        public void LoadInfo(clsInternationalLicense InternationalLicense)
        {
            this.License = InternationalLicense;

            lblInternationalLicenseID.Text = InternationalLicense.ID.ToString();
            lblFullName.Text = InternationalLicense.DriverInfo.PersonInfo.FullName;
            lblDriverID.Text = InternationalLicense.DriverID.ToString();
            lblNationalNo.Text = InternationalLicense.DriverInfo.PersonInfo.NationalNo;
            lblGender.Text = InternationalLicense.DriverInfo.PersonInfo.GenderText;
            lblDateOfBirth.Text = InternationalLicense.DriverInfo.PersonInfo.DateOfBirth.ToString("dd/MMM/yyyy");
            lblIsActive.Text = InternationalLicense.IsActive ? "Yes" : "No";
            lblApplicationID.Text = InternationalLicense.ApplicationID.ToString();
            lblLocalLicenseID.Text = InternationalLicense.LocalLicenseID.ToString();
            lblIssueDate.Text = InternationalLicense.IssueDate.ToString("dd/MMM/yyyy");
            lblExpirationDate.Text = InternationalLicense.ExpirationDate.ToString("dd/MMM/yyyy");

            _LoadImage();
            _ChangeLabelsColor();
        }
        public void LoadInfo(int InternationalLicenseID)
        {
            this.LoadInfo(clsInternationalLicense.Find(InternationalLicenseID));
        }
    }
}
