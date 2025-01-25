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
    public partial class frmAddNewInternationalLicense : Form
    {
        clsInternationalLicense InternationalLicense = null;
        clsApplication Application = null;
        public frmAddNewInternationalLicense()
        {
            InitializeComponent();
            ctrlLicenseCardWithFilter1.LicenseFound += CtrlLicenseCardWithFilter1_LicenseFound;
        }

        private void CtrlLicenseCardWithFilter1_LicenseFound()
        {
            llShowLicenseHistory.Enabled = true;

            if (DateTime.Now < ctrlLicenseCardWithFilter1.License.ExpirationDate)
            {
                btnIssue.Enabled = true;
            }
            else
            {
                btnIssue.Enabled = false;
                MessageBox.Show("This License is Expired.", "Expired License", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void _LoadInfo()
        {
            lblIssueDate.Text = DateTime.Now.ToString("dd-MMM-yyyy");
            lblExpirationDate.Text = DateTime.Now.AddYears(clsLicenseClass.GetLicenseLengthInYears(3)).ToString("dd-MMM-yyyy");
            lblApplicationFees.Text = clsApplicationType.Find(6).Fees.ToString(); //6 is international license
            lblCreatedByUsername.Text = clsGlobalSettings.CurrentUser.Username;

        }

        private void frmAddNewInternationalLicense_Load(object sender, EventArgs e)
        {
            _LoadInfo();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private bool _IsLicenseValid()
        {
            return ctrlLicenseCardWithFilter1.License.IsActive
                && DateTime.Now < ctrlLicenseCardWithFilter1.License.ExpirationDate
                && ctrlLicenseCardWithFilter1.License.LicenseClassID == 3
                && !clsInternationalLicense.DoesDriverHasInternationalLicense(ctrlLicenseCardWithFilter1.License.DriverID);
        }

        private bool _ApplyForInternationLicense()
        {
            Application = new clsApplication()
            {
                ApplicantID = clsDriver.Find(ctrlLicenseCardWithFilter1.License.DriverID).PersonID,
                ApplicationDate = DateTime.Now,
                LastStatusDate = DateTime.Now,
                ApplicationTypeID = 6,
                ApplicationStatus = 3,
                PaidFees = clsApplicationType.Find(6).Fees,
                CreatedByUserID = clsGlobalSettings.CurrentUser.ID
            };

            return Application.Save();
        }

        private void _FillInternationalLicenseObject()
        {
            InternationalLicense = new clsInternationalLicense()
            {
                ApplicationID = Application.ID,
                DriverID = ctrlLicenseCardWithFilter1.License.DriverID,
                IssuedUsingLocalLicenseID = ctrlLicenseCardWithFilter1.License.ID,
                IssueDate = DateTime.Now,
                ExpirationDate = DateTime.Now.AddYears(clsLicenseClass.GetLicenseLengthInYears(3)),
                IsActive = true,
                CreatedByUserID = Application.CreatedByUserID

            };
        }

        public void _UpdateFormControls()
        {
            lblInternationalLicenseApplicationID.Text = Application.ID.ToString();
            lblInternationalLicenseID.Text = InternationalLicense.ID.ToString();
            lblLocalLicenseID.Text = ctrlLicenseCardWithFilter1.License.ID.ToString();
            llShowInternationalLicense.Enabled = true;
            btnIssue.Enabled = false;
        }

        private void btnIssue_Click(object sender, EventArgs e)
        {

            if (_IsLicenseValid() && _ApplyForInternationLicense())
            {
                _FillInternationalLicenseObject();

                if (InternationalLicense.Save())
                {
                    _UpdateFormControls();
                    MessageBox.Show("License Saved Successfully.", "Succeed", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                    MessageBox.Show("License Data Was Not Saved.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            else
                MessageBox.Show("This License is Not Valid to Apply for International License.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void llShowLicenseHistory_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            
            frmPersonLicenseHistory frmPLH = new frmPersonLicenseHistory(clsDriver.Find(ctrlLicenseCardWithFilter1.License.DriverID).PersonID);
            frmPLH.MdiParent = this.MdiParent;

            frmPLH.Show();

        }

        private void llShowInternationalLicense_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmInternationalLicenseDetails frmILD = new frmInternationalLicenseDetails(InternationalLicense.ID);
            frmILD.MdiParent = this.MdiParent; 
            frmILD.Show();
        }
    }
}
