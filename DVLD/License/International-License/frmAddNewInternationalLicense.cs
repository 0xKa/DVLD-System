using DVLD.License.Local_Licenses;
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

namespace DVLD.License.International_License
{
    public partial class frmAddNewInternationalLicense : Form
    {
        public frmAddNewInternationalLicense()
        {
            InitializeComponent();
            ctrlCard.LicenseSelected += CtrlCard_LicenseSelected; ;

        }


        private void CtrlCard_LicenseSelected()
        {
            llShowLicenseHistory.Enabled = true;
            llShowNewInternationalLicense.Enabled = false;
            btnIssue.Enabled = false;

            if (clsDriver.DoesHasAnActiveInternationalLicense(ctrlCard.SelectedLicense.DriverID))
            { MessageBox.Show("This Driver already has an Active International License", "License Invalid", MessageBoxButtons.OK, MessageBoxIcon.Error); llShowNewInternationalLicense.Enabled = true; }
            else if (ctrlCard.SelectedLicense.EnLicenseClass != clsLicenseClass.enLicenseClass.OrdinaryDrivingLicense)
                MessageBox.Show("Local License must belong to Ordinary Driving License Class", "License Invalid", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else if (ctrlCard.SelectedLicense.IsExpired || (!ctrlCard.SelectedLicense.IsActive) || ctrlCard.SelectedLicense.IsDetained)
                MessageBox.Show("Selected License is Expired/Not Active", "License Invalid", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else
            {
                lblLocalLicenseID.Text = ctrlCard.SelectedLicense.ID.ToString();
                btnIssue.Enabled = true;
            }
        }
        private void frmAddNewInternationalLicense_Load(object sender, EventArgs e)
        {
            lblIssueDate.Text = DateTime.Now.ToString("dd-MMM-yyyy");
            lblExpirationDate.Text = DateTime.Now.AddYears(clsLicenseClass.GetLicenseValidityYears(clsLicenseClass.enLicenseClass.OrdinaryDrivingLicense)).ToString("dd-MMM-yyyy");
            lblFees.Text = clsApplicationType.GetApplicationFees(clsApplicationType.enApplicationType.NewInternationalLicense).ToString();
            lblCreatedByUsername.Text = clsGlobalSettings.LoggedInUser.Username;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private clsInternationalLicense _InternationalLicense = null;
        private void _UpdateFormControls()
        {
            lblInternationalLicenseApplicationID.Text = _InternationalLicense.ApplicationInfo.ApplicationID.ToString();
            lblInternationalLicenseID.Text = _InternationalLicense.ID.ToString();
            llShowNewInternationalLicense.Enabled = true;
            btnIssue.Enabled = false;
        }
        private void btnIssue_Click(object sender, EventArgs e)
        {
            _InternationalLicense = ctrlCard.SelectedLicense.IssueInternationlLicense();

            if (_InternationalLicense != null)
            {
                _UpdateFormControls();
                MessageBox.Show("License Saved Successfully.", "Succeed", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
                MessageBox.Show("License Data Was Not Saved.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

        }

        private void llShowNewInternationalLicense_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (_InternationalLicense == null)
                _InternationalLicense = clsInternationalLicense.FindActiveLicense(ctrlCard.SelectedLicense.DriverID);
            frmInternationalLicenseDetails frmILD = new frmInternationalLicenseDetails(_InternationalLicense);
            frmILD.ShowDialog();
            
        }
        private void llShowLicenseHistory_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmLicensesHistory frmLH = new frmLicensesHistory(ctrlCard.SelectedLicense.DriverInfo);
            frmLH.ShowDialog();
        }
    }
}
