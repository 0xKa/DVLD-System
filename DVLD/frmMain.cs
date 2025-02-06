﻿using DVLD.People;
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
            frmUserDetails frmUD = new frmUserDetails(clsGlobalSettings.LoggedInUser.ID);
            frmUD.ShowDialog();
        }

        private void changePasswordToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmChangePassword frmCP = new frmChangePassword(clsGlobalSettings.LoggedInUser.ID);
            frmCP.ShowDialog();
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
    }
}
