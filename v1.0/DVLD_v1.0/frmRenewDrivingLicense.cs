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
    public partial class frmRenewDrivingLicense : Form
    {
        private clsApplication _RenewApplication = null;
        private clsLicense _RenewedLicense = null;

        public frmRenewDrivingLicense()
        {
            InitializeComponent();
            ctrlLicenseCardWithFilter1.LicenseFound += CtrlLicenseCardWithFilter1_LicenseFound;
        }

        private double _LicenseFees = 0, _RenewApplicationFees = 0;
        private double _CalculateTotalFees()
        {
            _LicenseFees = clsLicenseClass.GetClassFees(ctrlLicenseCardWithFilter1.License.LicenseClassID);
            _RenewApplicationFees = clsApplicationType.Find(2).Fees; //2 for Rnew
            return _LicenseFees + _RenewApplicationFees;
        }

        private void _LoadRenewInfo()
        {
            lblOldLicenseID.Text = ctrlLicenseCardWithFilter1.License.ID.ToString();
            lblIssueDate.Text = DateTime.Now.ToString("dd/MMM/yyyy");
            lblExpirationDate.Text = DateTime.Now.AddYears(clsLicenseClass.GetLicenseLengthInYears(ctrlLicenseCardWithFilter1.License.LicenseClassID)).ToString("dd/MMM/yyyy");
            lblCreatedByUsername.Text = clsGlobalSettings.CurrentUser.Username;
            lblApplicationFees.Text = clsApplicationType.Find(2).Fees.ToString();
            lblLicenseFees.Text = clsLicenseClass.GetClassFees(ctrlLicenseCardWithFilter1.License.LicenseClassID).ToString();
            
            lblTotalFees.Text = _CalculateTotalFees().ToString();

        }

        private void CtrlLicenseCardWithFilter1_LicenseFound()
        {
            llShowLicenseHistory.Enabled = true;
                _LoadRenewInfo();
            if (DateTime.Today >= ctrlLicenseCardWithFilter1.License.ExpirationDate)
            {
                btnRenew.Enabled = true;
            }
            else
            {
                btnRenew.Enabled = false;
                MessageBox.Show($"This License Cannot be Renewed Because It is Not Expired.\nLicense Expire Date: {ctrlLicenseCardWithFilter1.License.ExpirationDate.ToString("dd/MMMM/yyyy")}", "Not Expired License", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

        private bool _ApplyForRenewApplication()
        {
            _RenewApplication = new clsApplication()
            {
                ApplicantID = clsDriver.Find(ctrlLicenseCardWithFilter1.License.DriverID).PersonID,
                ApplicationDate = DateTime.Now,
                ApplicationTypeID = 2,
                ApplicationStatus = 3,
                LastStatusDate = DateTime.Now,
                PaidFees = _RenewApplicationFees,
                CreatedByUserID = clsGlobalSettings.CurrentUser.ID
            };

            return _RenewApplication.Save();

        }

        private bool _IssueNewLicense()
        {
            _RenewedLicense = new clsLicense()
            {
                ApplicationID = _RenewApplication.ID,
                DriverID = ctrlLicenseCardWithFilter1.License.DriverID,
                LicenseClassID = ctrlLicenseCardWithFilter1.License.LicenseClassID,
                IssueDate = DateTime.Now,
                ExpirationDate = DateTime.Now.AddYears(clsLicenseClass.GetLicenseLengthInYears(ctrlLicenseCardWithFilter1.License.LicenseClassID)),
                Notes = txbNotes.Text,
                PaidFees = _LicenseFees,
                IsActive = true,
                IssueReason = 2,
                CreatedByUserID = clsGlobalSettings.CurrentUser.ID
            };

            return _RenewedLicense.Save();

        }

        private void _UpdateFormControls()
        {
            btnRenew.Enabled = false;
            llShowNewLicense.Enabled = true;
            lblRenewedLicenseApplicationID.Text = _RenewApplication.ID.ToString();
            lblRenewedLicenseID.Text = _RenewedLicense.ID.ToString();

        }

        private void btnRenew_Click(object sender, EventArgs e)
        {
            ctrlLicenseCardWithFilter1.License.ChangeActiveState(false);

            if (_ApplyForRenewApplication() && _IssueNewLicense())
            {
                _UpdateFormControls();
                MessageBox.Show("License Renewed Successfully.", "Succeed", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
                MessageBox.Show("License Renew Failed.", "Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);

        }
        private void llShowNewLicense_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmLicenseDetails frmLD = new frmLicenseDetails(_RenewedLicense.ID);
            frmLD.MdiParent = this.MdiParent;
            frmLD.Show();
        }
    }
}
