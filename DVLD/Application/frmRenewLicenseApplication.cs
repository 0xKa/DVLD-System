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

namespace DVLD.License.Local_Licenses
{
    public partial class frmRenewLicenseApplication : Form
    {
        public frmRenewLicenseApplication()
        {
            InitializeComponent();
            ctrlCard.LicenseSelected += CtrlLicenseCardFinder1_LicenseSelected;
        }

        private decimal _RenewApplicationFees = GetApplicationFees(enApplicationType.RenewDrivingLicense);
        private decimal _LicenseFees = 0;
        
        private decimal _CalculateTotalFees()
        {
            _LicenseFees = ctrlCard.SelectedLicense.LicenseClass.Fees;
            return _LicenseFees + _RenewApplicationFees;
        }
        private void _LoadRenewInfo()
        {
            lblOldLicenseID.Text = ctrlCard.SelectedLicense.ID.ToString();
            lblIssueDate.Text = DateTime.Now.ToString("dd/MMM/yyyy");
            lblExpirationDate.Text = DateTime.Now.AddYears(ctrlCard.SelectedLicense.LicenseClass.ValidityYears).ToString("dd/MMM/yyyy");
            lblCreatedByUsername.Text = clsGlobalSettings.LoggedInUser.Username;
            
            lblTotalFees.Text = _CalculateTotalFees().ToString();
            lblApplicationFees.Text = _RenewApplicationFees.ToString();
            lblLicenseFees.Text = _LicenseFees.ToString();
        }
        private void CtrlLicenseCardFinder1_LicenseSelected()
        {
            llShowLicenseHistory.Enabled = true;
            btnRenew.Enabled = false;
            txbNotes.Enabled = false;

            _LoadRenewInfo();
            if (ctrlCard.SelectedLicense.IsActive && !ctrlCard.SelectedLicense.IsExpired)
                MessageBox.Show($"Cannot Renew This License Because It is Active or Not Expired.\nLicense Expire Date: {ctrlCard.SelectedLicense.ExpirationDate.ToString("dd/MMMM/yyyy")}", "Not Expired License", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else if (clsLicense.DoesDriverHasActiveLicense(ctrlCard.SelectedLicense.DriverID, ctrlCard.SelectedLicense.LicenseClassID))
                MessageBox.Show($"This Driver Already Have an Active Driving Licenses", "Cannot Renew License", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else
            {
                btnRenew.Enabled = true;
                txbNotes.Enabled = true;
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private clsLicense _RenewedLicense = null;
        private void _UpdateFormControls()
        {
            btnRenew.Enabled = false;
            llShowNewLicense.Enabled = true;
            lblRenewedLicenseApplicationID.Text = _RenewedLicense.ApplicationID.ToString();
            lblRenewedLicenseID.Text = _RenewedLicense.ID.ToString();
        }
        private void btnRenew_Click(object sender, EventArgs e)
        {
            _RenewedLicense = ctrlCard.SelectedLicense.Renew(txbNotes.Text);

            if (_RenewedLicense != null)
            {
                _UpdateFormControls();
                MessageBox.Show("License Renewed Successfully.", "Succeed", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
                MessageBox.Show("License Renew Failed.", "Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);


        }


        private void llShowLicenseHistory_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            MessageBox.Show("..."); //koko
        }
        private void llShowNewLicense_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmLicenseDetails frmLD = new frmLicenseDetails(_RenewedLicense);
            frmLD.MdiParent = this.MdiParent;
            frmLD.Show();
        }

    }
}
