using DVLD.Application;
using DVLD.Application.ApplicationTypes;
using DVLD.Application.LocalLicenseApplication;
using DVLD.Detain_Release_License;
using DVLD.Driver;
using DVLD.License.International_License;
using DVLD.License.Local_Licenses;
using DVLD.People;
using DVLD.Test;
using DVLD.User;
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

namespace DVLD
{
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();
        }

        private Form _CurrentForm = null;

        private void peopleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _CurrentForm = new frmManagePeople();
            _CurrentForm.ShowDialog();
        }

        private void usersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _CurrentForm = new frmManageUsers();
            _CurrentForm.ShowDialog();
        }

        private void logOutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to log out?", "Confirm Logout", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
        }

        private void currentUserInfoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _CurrentForm = new frmUserDetails(clsGlobalSettings.LoggedInUser.ID);
            _CurrentForm.ShowDialog();
        }

        private void changePasswordToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _CurrentForm = new frmChangePassword(clsGlobalSettings.LoggedInUser.ID);
            _CurrentForm.ShowDialog();
        }

        private void accountSettingsToolStripMenuItem_MouseHover(object sender, EventArgs e)
        {
            if (lblUserLoogedIn.Visible)
                lblUserLoogedIn.Text = $"User Logged In: {clsGlobalSettings.LoggedInUser.Username}";
            else
                lblUserLoogedIn.Visible = true;
        }
        private void accountSettingsToolStripMenuItem_MouseLeave(object sender, EventArgs e)
        {
            lblUserLoogedIn.Visible = false ;
        }

        private void manageApplicationTypesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _CurrentForm = new frmManageApplicationTypes();
            _CurrentForm.ShowDialog();
        }

        private void manageTestTypesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _CurrentForm = new frmManageTestType();
            _CurrentForm.ShowDialog();
        }

        private void localLicenseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _CurrentForm = new frmAddEditLocalLicenseApplication();
            _CurrentForm.ShowDialog();
        }

        private void localDrivingLicenseApplicationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _CurrentForm = new frmManageLocalLicenseApplications();
            _CurrentForm.ShowDialog();
        }

        private void retakeTestToolStripMenuItem_Click(object sender, EventArgs e)
        {
            localDrivingLicenseApplicationToolStripMenuItem.PerformClick();
        }

        private void renewDrivingLicenseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _CurrentForm = new frmRenewLicenseApplication();
            _CurrentForm.ShowDialog();
        }

        private void replacementForLostOrDamagedLicenseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _CurrentForm = new frmLicenseReplacementApplication();
            _CurrentForm.ShowDialog();
        }

        private void driversToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _CurrentForm = new frmManageDrivers();
            _CurrentForm.ShowDialog();
        }

        private void manageDetainedLicensesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _CurrentForm = new frmManageDetainedLicenses();
            _CurrentForm.ShowDialog();
        }

        private void detainLicenseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _CurrentForm = new frmDetainLicense();
            _CurrentForm.ShowDialog();
        }

        private void releaseDetainedLicenseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _CurrentForm = new frmReleaseDetainedLicense();
            _CurrentForm.ShowDialog();
        }

        private void releaseDetainDrivingLicenseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            releaseDetainedLicenseToolStripMenuItem.PerformClick();
        }

        private void internationalLicenseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _CurrentForm = new frmAddNewInternationalLicense();
            _CurrentForm.ShowDialog();
        }

        private void internationalDrivingLicenseApplicationsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _CurrentForm = new frmManageInternationalLicenses();
            _CurrentForm.ShowDialog();
        }
    }
}
