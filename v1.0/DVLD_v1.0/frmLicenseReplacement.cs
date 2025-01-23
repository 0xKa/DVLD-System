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
    public partial class frmLicenseReplacement : Form
    {
        private clsLocalDLApplication _LDLApplication = null;
        private clsApplication _NewApplication = null;
        private clsLicense _ReplacedLicense = null;
        public frmLicenseReplacement()
        {
            InitializeComponent();
            ctrlLicenseCardWithFilter1.LicenseFound += CtrlLicenseCardWithFilter1_LicenseFound;
        }

        private double _GetApplicationFees()
        {
            return rbDamagedLicense.Checked ? clsApplicationType.Find(4).Fees : clsApplicationType.Find(3).Fees;
        }

        private void _LoadReplacmentInfo()
        {
            lblApplicationDate.Text = DateTime.Now.ToString("dd/MMM/yyyy");
            lblCreatedByUsername.Text = clsGlobalSettings.CurrentUser.Username;
            lblOldLicenseID.Text = ctrlLicenseCardWithFilter1.License.ID.ToString();
            lblApplicationFees.Text = _GetApplicationFees().ToString();
        }

        private bool _IsLicenseValidForReplacment()
        {
            return ctrlLicenseCardWithFilter1.License.IsActive && (DateTime.Now < ctrlLicenseCardWithFilter1.License.ExpirationDate);
        }

        private void CtrlLicenseCardWithFilter1_LicenseFound()
        {
            llShowLicenseHistory.Enabled = true;
            _LoadReplacmentInfo();

            if (_IsLicenseValidForReplacment())
            {
                btnIssue.Enabled = true;
            }
            else
            {
                MessageBox.Show("This License Cannot be Replaced Because It is Expired or Not Active", "License Invalid", MessageBoxButtons.OK, MessageBoxIcon.Error);
                btnIssue.Enabled = false;
            }

        }

        private void rbDamagedLicense_CheckedChanged(object sender, EventArgs e)
        {
            lblApplicationFees.Text = _GetApplicationFees().ToString(); 
            
            if (rbDamagedLicense.Checked)
            {
                this.Text = "Replacement For Damaged License";
                lblTitle.Text = "Replacement For Damaged License";
            }
            else
            {
                this.Text = "Replacement For Lost License";
                lblTitle.Text = "Replacement For Lost License";
            }

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private bool _ApplyForReplacmentApplication()
        {
            _NewApplication = new clsApplication()
            {
                ApplicantID = clsDriver.Find(ctrlLicenseCardWithFilter1.License.DriverID).PersonID,
                ApplicationDate = DateTime.Now,
                ApplicationTypeID = rbDamagedLicense.Checked ? 4 : 3,
                ApplicationStatus = 3,
                LastStatusDate = DateTime.Now,
                PaidFees = _GetApplicationFees(),
                CreatedByUserID = clsGlobalSettings.CurrentUser.ID
            };

            _NewApplication.Save();

            _LDLApplication = clsLocalDLApplication.FindByApplicationID(ctrlLicenseCardWithFilter1.License.ApplicationID);
            _LDLApplication.ApplicationID = _NewApplication.ID; 
            return _LDLApplication.Save();

        }

        private bool _IssueNewLicense()
        {
            _ReplacedLicense = new clsLicense()
            {
                ApplicationID = _NewApplication.ID,
                DriverID = ctrlLicenseCardWithFilter1.License.DriverID,
                LicenseClassID = ctrlLicenseCardWithFilter1.License.LicenseClassID,
                IssueDate = ctrlLicenseCardWithFilter1.License.IssueDate,
                ExpirationDate = ctrlLicenseCardWithFilter1.License.ExpirationDate,
                Notes = txbNotes.Text,
                PaidFees = clsLicenseClass.GetClassFees(ctrlLicenseCardWithFilter1.License.LicenseClassID),
                IsActive = true,
                IssueReason = (byte)(rbDamagedLicense.Checked ? 4 : 3),
                CreatedByUserID = clsGlobalSettings.CurrentUser.ID
            };

            return _ReplacedLicense.Save();

        }

        private void _UpdateFormControls()
        {
            btnIssue.Enabled = false;
            llShowNewLicense.Enabled = true;
            lblReplacedLicenseApplicationID.Text = _NewApplication.ID.ToString();
            lblReplacedLicenseID.Text = _ReplacedLicense.ID.ToString();

        }

        private void btnIssue_Click(object sender, EventArgs e)
        {
            ctrlLicenseCardWithFilter1.License.ChangeActiveState(false);

            if (_ApplyForReplacmentApplication() && _IssueNewLicense())
            {
                _UpdateFormControls();
                MessageBox.Show("License Replacement Issued Successfully.", "Succeed", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
                MessageBox.Show("Issue License Replacement Failed.", "Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);

        }

        private void llShowLicenseHistory_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmPersonLicenseHistory frmPLH = new frmPersonLicenseHistory(clsDriver.Find(ctrlLicenseCardWithFilter1.License.DriverID).PersonID);
            frmPLH.MdiParent = this.MdiParent;

            frmPLH.Show();
        }

        private void llShowNewLicense_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmLicenseDetails frmLD = new frmLicenseDetails(_ReplacedLicense.ID);
            frmLD.MdiParent = this.MdiParent;
            frmLD.Show();
        }
    }
}
