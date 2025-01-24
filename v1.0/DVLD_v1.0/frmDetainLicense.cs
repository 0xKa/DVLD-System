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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace DVLD_v1._0
{
    public partial class frmDetainLicense : Form
    {
        private clsDetainedLicense _DetainedLicense = null;
        private double _FineFees = 0.0;
        public frmDetainLicense()
        {
            InitializeComponent();
            ctrlLicenseCardWithFilter1.LicenseFound += CtrlLicenseCardWithFilter1_LicenseFound;
        }

        private void CtrlLicenseCardWithFilter1_LicenseFound()
        {
            llShowLicenseHistory.Enabled = true;

            if (ctrlLicenseCardWithFilter1.License.IsActive && DateTime.Now < ctrlLicenseCardWithFilter1.License.ExpirationDate)
            {
                lblLicenseID.Text = ctrlLicenseCardWithFilter1.License.ID.ToString();
                txbFineFees.Enabled = true;
                btnDetain.Enabled = true;
            }
            else
            {
                btnDetain.Enabled = false;
                MessageBox.Show("This License Cannot be Detained Because It is Expired or Not Active", "License Invalid", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void frmDetainLicense_Load(object sender, EventArgs e)
        {
            lblDetainDate.Text = DateTime.Today.ToString("dd/MMMM/yyyy");
            lblCreatedByUsername.Text = clsGlobalSettings.CurrentUser.Username;
        }

        //validate txb to accept numbers only
        private void txbFineFees_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Allow digits, decimal point, and control keys
            if ((!char.IsDigit(e.KeyChar) && e.KeyChar != '.' && !char.IsControl(e.KeyChar) ) 
                || (e.KeyChar == '.' && txbFineFees.Text.Contains("."))) // Allow only one decimal point
                e.Handled = true;
        }
        private void txbFineFees_Leave(object sender, EventArgs e)
        {
            if (!double.TryParse(txbFineFees.Text, out double result))
            {
                MessageBox.Show("Invalid input. Please enter a valid number.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txbFineFees.Focus();
            }

            _FineFees = result;
        }


        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private bool _SaveDetainedLicense()
        {
            _DetainedLicense = new clsDetainedLicense()
            {
                LicenseID = ctrlLicenseCardWithFilter1.License.ID,
                DetainDate = DateTime.Now,
                FineFees = Convert.ToDouble(txbFineFees.Text),
                CreatedByUserID = clsGlobalSettings.CurrentUser.ID,
                IsReleased = false

            };

            return _DetainedLicense.Save();
        }

        private void _UpdateFormControls()
        {
            btnDetain.Enabled = false;
            txbFineFees.Enabled = false;
            llShowNewLicense.Enabled = true;
            lblDetainID.Text = _DetainedLicense.ID.ToString();

        }

        private void btnDetain_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txbFineFees.Text))
            { MessageBox.Show("Enter the Fine Fees."); txbFineFees.Focus(); return; }


            if(_SaveDetainedLicense() && ctrlLicenseCardWithFilter1.License.ChangeActiveState(false))
            {
                _UpdateFormControls();
                MessageBox.Show("License Detained Successfully.", "Succeed", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
                MessageBox.Show("Detain License Failed.", "Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);

        }

        private void llShowLicenseHistory_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmPersonLicenseHistory frmPLH = new frmPersonLicenseHistory(clsDriver.Find(ctrlLicenseCardWithFilter1.License.DriverID).PersonID);
            frmPLH.MdiParent = this.MdiParent;

            frmPLH.Show();
        }

        private void llShowNewLicense_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmLicenseDetails frmLD = new frmLicenseDetails(ctrlLicenseCardWithFilter1.License.ID);
            frmLD.MdiParent = this.MdiParent;

            frmLD.Show();
        }
    }
}
