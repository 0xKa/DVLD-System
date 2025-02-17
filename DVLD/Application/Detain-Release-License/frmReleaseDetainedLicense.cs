using DVLD.License;
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
using static DVLD_BusinessLogicLayer.clsApplicationType;

namespace DVLD.Detain_Release_License
{
    public partial class frmReleaseDetainedLicense : Form
    {
        public frmReleaseDetainedLicense()
        {
            InitializeComponent();
            ctrlCard.LicenseSelected += CtrlCard_LicenseSelected;
        }
        public frmReleaseDetainedLicense(int LicenseID)
        {
            InitializeComponent();
            ctrlCard.LoadLicenseInfo(LicenseID);
            CtrlCard_LicenseSelected();
            lblFilterDisabledTitle.Text = $"Release License {LicenseID}";
            lblFilterDisabledTitle.Visible = true;
        }

        private clsDetainedLicense _DetainedLicense = null;
        private decimal _ReleaseApplicationFees = GetApplicationFees(enApplicationType.ReleaseDetainedDrivingLicsense);
        private decimal _TotalFees = 0;

        private void _LoadApplicationInfo()
        {
            _TotalFees = _DetainedLicense.FineFees + _ReleaseApplicationFees;

            lblDetainID.Text = _DetainedLicense.ID.ToString();
            lblSelectedLicenseID.Text = ctrlCard.SelectedLicense.ID.ToString();
            lblDetainDate.Text = _DetainedLicense.DetainDate.ToString("dd/MMM/yyyy");
            lblReleaseDate.Text = DateTime.Now.ToString("dd/MMM/yyyy");
            lblCreatedByUsername.Text = clsGlobalSettings.LoggedInUser.Username;
            lblFineFees.Text = _DetainedLicense.FineFees.ToString();
            lblApplicationFees.Text = _ReleaseApplicationFees.ToString();
            lblTotalFees.Text = _TotalFees.ToString();

        }
        private void CtrlCard_LicenseSelected()
        {
            llShowLicenseHistory.Enabled = true;
            btnRelease.Enabled = false;

            if (!ctrlCard.SelectedLicense.IsDetained)
                MessageBox.Show("Selected License is Not Detained", "License Invalid", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else if (ctrlCard.SelectedLicense.IsExpired)
                MessageBox.Show("Cannot Release the Selected License Becasue it is Expired", "License Invalid", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else
            {
                _DetainedLicense = clsDetainedLicense.FindByLicenseID(ctrlCard.SelectedLicense.ID);
                _LoadApplicationInfo();
                btnRelease.Enabled = true;
            }
        }
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }


        private void _UpdateFormControls()
        {
            btnRelease.Enabled = false;
            llShowNewLicense.Enabled = true;
            lblReleaseApplicationID.Text = _DetainedLicense.ReleaseApplicationID.ToString();
        }
        private void btnRelease_Click(object sender, EventArgs e)
        {
            clsDetainedLicense ReleasedLicense = _DetainedLicense.Release();

            if (ReleasedLicense != null)
            {
                _DetainedLicense = ReleasedLicense;
                _UpdateFormControls();
                MessageBox.Show("License Released Successfully.", "Succeed", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
                MessageBox.Show("Release License Failed.", "Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);

        }

        private void llShowNewLicense_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmLicenseDetails frmLD = new frmLicenseDetails(_DetainedLicense.LicenseInfo);
            frmLD.ShowDialog();
        }
        private void llShowLicenseHistory_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmLicensesHistory frmLH = new frmLicensesHistory(ctrlCard.SelectedLicense.DriverInfo);
            frmLH.ShowDialog();
        }
    }
}
