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
    public partial class ctrlLDLApplicationInfoCard : UserControl
    {
        clsLocalDLApplication _localDLApplication = null;
        clsApplication _application = null;

        public ctrlLDLApplicationInfoCard()
        {
            InitializeComponent();
        }

        private void _FillApplicationInfoInLabels()
        {
            byte PassedTests = clsLocalDLApplication.GetPassedTestCount(_localDLApplication.ID);

            lblLDLApplicationID.Text = _localDLApplication.ID.ToString();
            lblPassedTests.Text = $"[{PassedTests}/3]";
            lblLicenseClass.Text = clsLicenseClass.GetClassName(_localDLApplication.LicenseClassID);

            lblApplicationID.Text = _application.ID.ToString();
            lblStatus.Text = _application.ApplicationStatus == 1 ? "New" : _application.ApplicationStatus == 2 ? "Cancelled" : "Completed";
            lblFees.Text = _application.PaidFees.ToString();
            lblApplicationType.Text = clsApplicationType.Find(_application.ApplicationTypeID).Title;
            lblApplicantPerson.Text = clsPerson.Find(_application.ApplicantID).GetFullName();
            lblApplicationDate.Text = _application.ApplicationDate.ToString("ddd, d/M/yyy");
            lblLastStatusDate.Text = _application.LastStatusDate.ToString("ddd, d/M/yyy");
            lblCreatedByUser.Text = clsUser.Find(_application.CreatedByUserID).Username;

            if (PassedTests == 3)
                llShowLicenseInfo.Enabled = true;

        }

        public bool LoadInfo(int LDLApplicaitonID)
        {
            if (!clsLocalDLApplication.IsApplicationExists(LDLApplicaitonID))
                return false;

            _localDLApplication = clsLocalDLApplication.Find(LDLApplicaitonID);
            _application = clsApplication.Find(_localDLApplication.ApplicationID);


            _FillApplicationInfoInLabels();
            return true;

        }

        private void ctrlLDLApplicationInfoCard_Load(object sender, EventArgs e)
        {
        }

        private void llViewPersonInfo_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmPersonDetails personDetails = new frmPersonDetails(_application.ApplicantID);
            personDetails.MdiParent = this.ParentForm.MdiParent;

            personDetails.Show();
        }

        private void llShowLicenseInfo_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            MessageBox.Show("License is not available yet...");
        }
    }
}
