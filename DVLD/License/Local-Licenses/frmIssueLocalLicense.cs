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

namespace DVLD.License
{
    public partial class frmIssueLocalLicense : Form
    {
        private clsLocalLicenseApplication _LLApplication = null;
        public frmIssueLocalLicense(int LocalLicenseApplicationID)
        {
            InitializeComponent();
            _LLApplication = clsLocalLicenseApplication.FindByLLApplicationID(LocalLicenseApplicationID);
        }


        private void frmIssueLocalLicense_Load(object sender, EventArgs e)
        {
            if (_LLApplication.IsPassedAllTests())
                ctrlLocalLicenseApplicationCard1.LoadApplicationInfo(_LLApplication);
            else
            {
                MessageBox.Show("Error: Person Must Pass All Tests First.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnIssue_Click(object sender, EventArgs e)
        {
            int LicenseID = _LLApplication.IssueLicenseForTheFirstTime(txbNotes.Text);

            if (LicenseID != 1)
                MessageBox.Show($"License Data Saved Successfully.\nLicense ID = {LicenseID}", "Done");
            else
                MessageBox.Show("Error: License Data was NOT Saved Successfully.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            this.Close();


        }
    }
}
