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

namespace DVLD.Detain_Release_License
{
    public partial class frmDetainLicense : Form
    {
        public frmDetainLicense()
        {
            InitializeComponent();
            ctrlCard.LicenseSelected += CtrlCard_LicenseSelected;
        }
         public frmDetainLicense(int LicenseID)
        {
            InitializeComponent();
            ctrlCard.LoadLicenseInfo(LicenseID);
            CtrlCard_LicenseSelected();
            lblFilterDisabledTitle.Text = $"Detain License {LicenseID}";
            lblFilterDisabledTitle.Visible = true;
        }


        private void CtrlCard_LicenseSelected()
        {
            llShowLicenseHistory.Enabled = true;
            btnDetain.Enabled = false;
            txbFineFees.Enabled = false;
            lblLicenseID.Text = "[????]";

            if (ctrlCard.SelectedLicense.IsDetained)
                MessageBox.Show("Selected License Already Detained", "License Invalid", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else if (!ctrlCard.SelectedLicense.IsActive || ctrlCard.SelectedLicense.IsExpired)
                MessageBox.Show("This License Cannot be Detained Because It is Expired or Not Active", "License Invalid", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else
            {
                lblLicenseID.Text = ctrlCard.SelectedLicense.ID.ToString();
                txbFineFees.Enabled = true;
                btnDetain.Enabled = true;
            }

        }
        private void frmDetainLicense_Load(object sender, EventArgs e)
        {
            lblDetainDate.Text = DateTime.Now.ToString("dd/MMM/yyyy");
            lblCreatedByUsername.Text = clsGlobalSettings.LoggedInUser.Username;
        }
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }



        private decimal _FineFees = 0;
        private void txbFineFees_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((!char.IsDigit(e.KeyChar) && e.KeyChar != '.' && !char.IsControl(e.KeyChar))
                            || (e.KeyChar == '.' && txbFineFees.Text.Contains("."))) // Allow only one decimal point
                e.Handled = true;
        }
        private void txbFineFees_Leave(object sender, EventArgs e)
        {
            if (!decimal.TryParse(txbFineFees.Text, out decimal result) || string.IsNullOrWhiteSpace(txbFineFees.Text))
            {
                lblValidateFees.Visible = true;
                btnDetain.Enabled = false;

            }
            else
            {
                _FineFees = result;
                lblValidateFees.Visible = false;
                btnDetain.Enabled = true;

            }

        }


        private void _UpdateFormControls()
        {
            btnDetain.Enabled = false;
            txbFineFees.Enabled = false;
            llShowNewLicense.Enabled = true;
            lblDetainID.Text = _DetainedLicense.ID.ToString();
        }
        private clsDetainedLicense _DetainedLicense = null;
        private void btnDetain_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txbFineFees.Text))
            { MessageBox.Show("Enter the Fine Fees."); txbFineFees.Focus(); return; }

            _DetainedLicense = ctrlCard.SelectedLicense.Detain(_FineFees);

            if (_DetainedLicense != null)
            {
                _UpdateFormControls();
                MessageBox.Show("License Detained Successfully.", "Succeed", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
                MessageBox.Show("Detain License Failed.", "Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);


        }

        private void llShowLicenseHistory_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmLicensesHistory frmLH = new frmLicensesHistory(ctrlCard.SelectedLicense.DriverInfo);
            frmLH.ShowDialog();
        }
        private void llShowNewLicense_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmLicenseDetails frmLD = new frmLicenseDetails(_DetainedLicense.LicenseInfo);
            frmLD.ShowDialog();
        }
    }
}
