﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DVLD_BusinessLayer;

namespace DVLD_v1._0
{
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();
        }

        private Form _CurrentScreen = null;

        private void peopleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (_CurrentScreen == null || _CurrentScreen.IsDisposed)
            {
                _CurrentScreen = new frmManagePeople();
                _CurrentScreen.MdiParent = this;
                _CurrentScreen.Show();
            }
            else
                _CurrentScreen.BringToFront(); // Bring the form to the front if it is already open

        }

        private void usersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (_CurrentScreen == null || _CurrentScreen.IsDisposed)
            {
                _CurrentScreen = new frmManageUsers();
                _CurrentScreen.MdiParent = this;
                _CurrentScreen.Show();
            }
            else
                _CurrentScreen.BringToFront();

        }

        private void currentUserInfoToolStripMenuItem_Click(object sender, EventArgs e)
        {

            if (_CurrentScreen == null || _CurrentScreen.IsDisposed)
            {
                _CurrentScreen = new frmUserDetails(clsGlobalSettings.CurrentUser.ID);
                _CurrentScreen.MdiParent = this;
                _CurrentScreen.Show();
            }
            else
                _CurrentScreen.BringToFront();

        }

        private void changePasswordToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (_CurrentScreen == null || _CurrentScreen.IsDisposed)
            {
                _CurrentScreen = new frmChangePassword(clsGlobalSettings.CurrentUser.ID);
                _CurrentScreen.MdiParent = this;
                _CurrentScreen.Show();
            }
            else
                _CurrentScreen.BringToFront();
        }
        
        private void logOutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to log out?", "Confirm Logout", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
        }

        private void manageApplicationTypesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (_CurrentScreen == null || _CurrentScreen.IsDisposed)
            {
                _CurrentScreen = new frmManageApplicationTypes();
                _CurrentScreen.MdiParent = this;
                _CurrentScreen.Show();
            }
            else
                _CurrentScreen.BringToFront();
        }

        private void manageTestTypesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (_CurrentScreen == null || _CurrentScreen.IsDisposed)
            {
                _CurrentScreen = new frmManageTestTypes();
                _CurrentScreen.MdiParent = this;
                _CurrentScreen.Show();
            }
            else
                _CurrentScreen.BringToFront();
        }

        private void localDrivingLicenseApplicationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (_CurrentScreen == null || _CurrentScreen.IsDisposed)
            {
                _CurrentScreen = new frmManageLocalDLApplications();
                _CurrentScreen.MdiParent = this;
                _CurrentScreen.Show();
            }
            else
                _CurrentScreen.BringToFront();
        }

        private void localLicenseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (_CurrentScreen == null || _CurrentScreen.IsDisposed)
            {
                _CurrentScreen = new frmAddEditLocalDLApplication();
                _CurrentScreen.MdiParent = this;
                _CurrentScreen.Show();
            }
            else
                _CurrentScreen.BringToFront();
        }
    }
}
