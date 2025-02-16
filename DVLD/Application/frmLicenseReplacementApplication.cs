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

namespace DVLD.Application
{
    public partial class frmLicenseReplacementApplication : Form
    {
        public frmLicenseReplacementApplication()
        {
            InitializeComponent();
            ctrlCard.LicenseSelected += CtrlCard_LicenseSelected; ;
        }

        private decimal _GetApplicationFees()
        {
            return rbDamagedLicense.Checked ? 
                GetApplicationFees(enApplicationType.ReplacementforaDamagedDrivingLicense) 
                : 
                GetApplicationFees(enApplicationType.ReplacementforaLostDrivingLicense);
        }
        private void _LoadReplacmentInfo()
        {
            lblApplicationDate.Text = DateTime.Now.ToString("dd/MMM/yyyy");
            lblCreatedByUsername.Text = clsGlobalSettings.LoggedInUser.Username;
            lblApplicationFees.Text = _GetApplicationFees().ToString();
         
            if (ctrlCard.IsLicenseSelected)
                lblOldLicenseID.Text = ctrlCard.SelectedLicense.ID.ToString();
        }
        private void CtrlCard_LicenseSelected()
        {
            llShowLicenseHistory.Enabled = true;
            btnIssueReplacement.Enabled = false;
            txbNotes.Enabled = false;
            
            _LoadReplacmentInfo();
            if (ctrlCard.SelectedLicense.IsActive && !ctrlCard.SelectedLicense.IsExpired)
            {
                btnIssueReplacement.Enabled = true;
                txbNotes.Enabled = true;
            }
            else
            {
                btnIssueReplacement.Enabled = false;
                MessageBox.Show("This License Cannot be Replaced Because It is Expired or Not Active", "License Invalid", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void rbDamagedLicense_CheckedChanged(object sender, EventArgs e)
        {
            if (rbDamagedLicense.Checked) 
            { 
                rbDamagedLicense.ForeColor = Color.Firebrick;
                rbLostLicense.ForeColor = Color.White;
                this.Text = "Replacement For Damaged License";
            }
            else
            {
                rbDamagedLicense.ForeColor = Color.White;
                rbLostLicense.ForeColor = Color.Firebrick;
                this.Text = "Replacement For Lost License";
            }

            lblApplicationFees.Text = _GetApplicationFees().ToString();
        }


        private clsLicense _ReplacedLicense = null;
        private void _UpdateFormControls()
        {
            btnIssueReplacement.Enabled = false;
            llShowNewLicense.Enabled = true;
            lblLicenseReplacementApplicationID.Text = _ReplacedLicense.ApplicationID.ToString();
            lblReplacedLicenseID.Text = _ReplacedLicense.ID.ToString();
        }
        private void btnIssueReplacement_Click(object sender, EventArgs e)
        {
            enApplicationType ReplacementType = rbDamagedLicense.Checked ? enApplicationType.ReplacementforaDamagedDrivingLicense : enApplicationType.ReplacementforaLostDrivingLicense;
            _ReplacedLicense = ctrlCard.SelectedLicense.Replace(ReplacementType, txbNotes.Text);

            if (_ReplacedLicense != null)
            {
                _UpdateFormControls();
                MessageBox.Show("License Renewed Successfully.", "Succeed", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
                MessageBox.Show("License Renew Failed.", "Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
            
        }


        private void llShowLicenseHistory_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmLicensesHistory frmPL = new frmLicensesHistory(ctrlCard.SelectedLicense.DriverInfo);
            frmPL.ShowDialog();
        }
        private void llShowNewLicense_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmLicenseDetails frmLD = new frmLicenseDetails(_ReplacedLicense);
            frmLD.Show();
        }

        private void frmLicenseReplacementApplication_Load(object sender, EventArgs e)
        {
            _LoadReplacmentInfo();
        }
    }
}
