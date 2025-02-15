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

namespace DVLD.License
{
    public partial class ctrlLicenseCard : UserControl
    {
        public ctrlLicenseCard()
        {
            InitializeComponent();
        }

        public clsLicense License = null;

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
        public void LoadInfo(clsLicense License)
        {
            this.License = License;
            lblFullName.Text = License.DriverInfo.PersonInfo.FullName;
            lblLicenseID.Text = License.ID.ToString();
            lblNationalNo.Text = License.DriverInfo.PersonInfo.NationalNo;
            lblGender.Text = License.DriverInfo.PersonInfo.GenderText;
            lblDateOfBirth.Text = License.DriverInfo.PersonInfo.DateOfBirth.ToString("dd/MMM/yyyy");

            lblDriverID.Text = License.DriverID.ToString();
            lblIssueDate.Text = License.IssueDate.ToString("dd/MMM/yyyy");
            lblExpirationDate.Text = License.ExpirationDate.ToString("dd/MMM/yyyy");
            lblNotes.Text = string.IsNullOrEmpty(License.Notes) ? "No Notes" : License.Notes;
            lblIsActive.Text = License.IsActive ? "Yes" : "No";
            lblIsDetained.Text = License.IsDetained ? "Yes" : "No";

            lblLicenseClass.Text = License.LicenseClass.Title;
            lblIssueReason.Text = License.IssueReasonText;

            
            _LoadImage();
            _ChangeLabelsColor();
        }
        public void LoadInfo(int LicenseID)
        {
            this.LoadInfo(clsLicense.Find(LicenseID));
        }

    }
}
