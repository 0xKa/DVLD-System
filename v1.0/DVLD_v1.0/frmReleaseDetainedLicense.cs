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
    public partial class frmReleaseDetainedLicense : Form
    {
        clsApplication _ReleaseApplication = null;
        private clsDetainedLicense _DetainedLicense = null;
        private double _ReleaseApplicationFees = clsApplicationType.Find(5).Fees;
        private double _TotalFees = 0.0;

        public frmReleaseDetainedLicense(int LicenseID = -1)
        {
            InitializeComponent();
            ctrlLicenseCardWithFilter1.LicenseFound += CtrlLicenseCardWithFilter1_LicenseFound;

            if (LicenseID != -1)
            {
                ctrlLicenseCardWithFilter1.LoadLicenseInfo(LicenseID);
                ctrlLicenseCardWithFilter1.EnableDisableFilter(false);
            }

        }

        private void _LoadReleaseInfo()
        {
            _TotalFees = _DetainedLicense.FineFees + _ReleaseApplicationFees;

            lblDetainID.Text = _DetainedLicense.ID.ToString();
            lblLicenseID.Text = _DetainedLicense.LicenseID.ToString();
            lblDetainDate.Text = _DetainedLicense.DetainDate.ToString("dd/MMMM/yyyy");
            lblReleaseDate.Text = DateTime.Now.ToString("dd/MMMM/yyyy");
            lblCreatedByUsername.Text = clsGlobalSettings.CurrentUser.Username;
            lblFineFees.Text = _DetainedLicense.FineFees.ToString();
            lblApplicationFees.Text =_ReleaseApplicationFees.ToString();
            lblTotalFees.Text = _TotalFees.ToString();

        }

        private void CtrlLicenseCardWithFilter1_LicenseFound()
        {
            llShowLicenseHistory.Enabled = true;

            if (clsDetainedLicense.IsLicenseDetained(ctrlLicenseCardWithFilter1.License.ID))
            {
                _DetainedLicense = clsDetainedLicense.FindByLicenseID(ctrlLicenseCardWithFilter1.License.ID);
                _LoadReleaseInfo();
                btnRelease.Enabled = true;
            }
            else
            {
                btnRelease.Enabled = false;
                MessageBox.Show("Selected License Is Not Detained", "License Invalid", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void llShowLicenseHistory_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmPersonLicenseHistory frmPLH = new frmPersonLicenseHistory(clsDriver.Find(ctrlLicenseCardWithFilter1.License.DriverID).PersonID);
            frmPLH.MdiParent = this.MdiParent;

            frmPLH.Show();
        }

        private void llShowReleasedLicense_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmLicenseDetails frmLD = new frmLicenseDetails(ctrlLicenseCardWithFilter1.License.ID);
            frmLD.MdiParent = this.MdiParent;

            frmLD.Show();
        }

        private bool _SaveReleaseApplication()
        {
            _ReleaseApplication = new clsApplication()
            {
                ApplicantID = clsDriver.Find(ctrlLicenseCardWithFilter1.License.DriverID).PersonID,
                ApplicationDate = DateTime.Now,
                ApplicationTypeID = 5,
                ApplicationStatus = 3,
                LastStatusDate = DateTime.Now,
                PaidFees = _ReleaseApplicationFees,
                CreatedByUserID = clsGlobalSettings.CurrentUser.ID
            };
            return _ReleaseApplication.Save();
        }
        private bool _SaveReleasedLicense()
        {
            _DetainedLicense.IsReleased = true;
            _DetainedLicense.ReleaseDate = DateTime.Now;
            _DetainedLicense.ReleasedByUserID = clsGlobalSettings.CurrentUser.ID;
            _DetainedLicense.ReleaseApplicationID = _ReleaseApplication.ID;
            
            return _DetainedLicense.Save();
        }

        private void _UpdateFormControls()
        {
            btnRelease.Enabled = false;
            llShowReleasedLicense.Enabled = true;
            lblReleasedLicenseApplicationID.Text = _ReleaseApplication.ID.ToString();
        }

        private void btnRelease_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show($"Are you sure you want to release this license\nLicense ID = {_DetainedLicense.LicenseID}", "Alert", MessageBoxButtons.OKCancel, MessageBoxIcon.Information) == DialogResult.Cancel)
                return;

            if (_SaveReleaseApplication() && _SaveReleasedLicense() && ctrlLicenseCardWithFilter1.License.ChangeActiveState(true))
            {
                _UpdateFormControls();
                MessageBox.Show("License Released Successfully.", "Succeed", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
                MessageBox.Show("Release License Failed.", "Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);

        }
    }
}
