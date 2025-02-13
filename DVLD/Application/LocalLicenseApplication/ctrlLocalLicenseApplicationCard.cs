using DVLD.People;
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

namespace DVLD.Application.LocalLicenseApplication
{
    public partial class ctrlLocalLicenseApplicationCard : UserControl
    {
        public clsLocalLicenseApplication SelectedLLApplication = null; 

        public ctrlLocalLicenseApplicationCard()
        {
            InitializeComponent();
        }


        private void _FillCard()
        {
            byte PassedTestCount = clsLocalLicenseApplication.GetPassedTestCount(SelectedLLApplication.ID);

            lblLLApplicationID.Text = SelectedLLApplication.ID.ToString();
            lblPassedTests.Text = $"[{PassedTestCount}/3]";
            lblLicenseClass.Text = SelectedLLApplication.LicenseClassInfo.Title;

            lblApplicationID.Text = SelectedLLApplication.ApplicationID.ToString();
            lblApplicationStatus.Text = SelectedLLApplication.StatusText; 
            lblApplicationFees.Text = SelectedLLApplication.Fees.ToString();
            lblApplicationType.Text = SelectedLLApplication.Type.Title;
            lblApplicantPerson.Text = SelectedLLApplication.ApplicantPerson.FullName;
            lblApplicationDate.Text = SelectedLLApplication.ApplicationDate.ToString("ddd, dd/MMM/yyyy");
            lblLastStatusDate.Text = SelectedLLApplication.LastStatusDate.ToString("ddd, dd/MMM/yyyy");
            lblCreatedByUsername.Text = clsGlobalSettings.LoggedInUser.Username;

            llShowLicenseInfo.Enabled = PassedTestCount == 3;
        }

        public void LoadApplicationInfo(clsLocalLicenseApplication LocalLicenseApplication)
        {
            if (LocalLicenseApplication != null)
            {
                SelectedLLApplication = LocalLicenseApplication;
                _FillCard();
            }
            else
                MessageBox.Show("Local License Application Was Not Found", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

        }

        public void LoadApplicationInfo(int LocalLicenseApplicationID)
        {
            this.LoadApplicationInfo(clsLocalLicenseApplication.FindByLLApplicationID(LocalLicenseApplicationID));
        }
        public void LoadApplicationInfoByBaseApplicationID(int BaseApplicationID)
        {
            this.LoadApplicationInfo(clsLocalLicenseApplication.FindByApplicationID(BaseApplicationID));
        }

        private void FormClosed(object sender, FormClosedEventArgs e)
        {
            LoadApplicationInfo(SelectedLLApplication.ID);
        }

        private void llViewPersonInfo_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmPersonDetails frmPD = new frmPersonDetails(SelectedLLApplication.ApplicantPersonID);
            frmPD.FormClosed += FormClosed;
            frmPD.ShowDialog();
        }


        private void llShowLicenseInfo_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            MessageBox.Show("Not implemented yet...");
        }
    }
}
