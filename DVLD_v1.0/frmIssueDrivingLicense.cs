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
    public partial class frmIssueDrivingLicense : Form
    {
        private clsLocalDLApplication _LDLApplication = null;
        private clsApplication _Application = null;
        private clsDriver _Driver = null;
        private clsLicense _License = null;

        public frmIssueDrivingLicense(int LDLApplicationID)
        {
            InitializeComponent();
            _LDLApplication = clsLocalDLApplication.Find(LDLApplicationID);
            _Application = clsApplication.Find(_LDLApplication.ApplicationID);
        }

        private void frmIssueDrivingLicense_Load(object sender, EventArgs e)
        {
            ctrlLDLApplicationInfoCard1.LoadInfo(_LDLApplication.ID);
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private bool _AddNewDriver()
        {
            if (clsDriver.IsPersonDriver(_Application.ApplicantID))
            {
                _Driver = clsDriver.FindByPersonID(_Application.ApplicantID);
                return true;
            }

            _Driver = new clsDriver()
            {
                PersonID = _Application.ApplicantID,
                CreatedByUserID = clsGlobalSettings.CurrentUser.ID,
                CreatedDate = DateTime.Now
            };


            if (_Driver.Save())
            {
                MessageBox.Show("Driver Data Saved Successfully.", "Done");
                return true;
            }
            else
            {
                MessageBox.Show("Error: Driver Data was NOT Saved Successfully.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }


        }

        private void _FillLicenseObject()
        {
            _License = new clsLicense
            {
                ApplicationID = _LDLApplication.ApplicationID,
                DriverID = _Driver.ID,
                LicenseClassID = _LDLApplication.LicenseClassID,
                IssueDate = DateTime.Now,
                ExpirationDate = DateTime.Now.AddYears(clsLicenseClass.GetLicenseLengthInYears(_LDLApplication.LicenseClassID)),
                Notes = txbNotes.Text,
                PaidFees = clsLicenseClass.GetClassFees(_LDLApplication.LicenseClassID),
                IsActive = true,
                IssueReason = 1,
                CreatedByUserID = clsGlobalSettings.CurrentUser.ID
            };

        }

        private void btnIssue_Click(object sender, EventArgs e)
        {
            if (_AddNewDriver())
                _FillLicenseObject();
            else
                return;

            if (_License.Save() && _Application.ChangeApplicationStatus(clsGlobalSettings.enApplicationStatus.Completed))
                MessageBox.Show($"License Data Saved Successfully.\nLicense ID = {_License.ID}", "Done");
            else
                MessageBox.Show("Error: License Data was NOT Saved Successfully.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            this.Close();
        }
    }
}
