using DVLD_BusinessLogicLayer;
using DVLD_BusinessLogicLayer.GlobalClasses;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLD
{
    public partial class frmLogin : Form
    {
        public frmLogin()
        {
            InitializeComponent();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        byte LoginFailedTrials = 0;
        private void btnLogin_Click(object sender, EventArgs e)
        {
            clsUser User = clsUser.FindByUsernameAndPassword(txbUsername.Text, txbPassword.Text);

            if (User != null)
            {
                if (User.IsActive)
                {
                    if (chkRememberMe.Checked)
                        clsUtil.SaveLoginCredentialsToWinRegistry(txbUsername.Text, txbPassword.Text);
                    else
                        clsUtil.ClearLoginCredentialsFromWinRegistry();

                    clsGlobalSettings.LoggedInUser = User;
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
                else
                { MessageBox.Show("This User Account is Not Active.", "Login Failed", MessageBoxButtons.OK, MessageBoxIcon.Error); txbUsername.Focus(); }

            }
            else
            { 
                MessageBox.Show("Invalid Username/Password.", "Login Failed", MessageBoxButtons.OK, MessageBoxIcon.Error); 
                txbUsername.Focus();

                if (LoginFailedTrials == 2)
                {
                    btnLogin.Enabled = false;
                    txbUsername.Enabled = false;
                    txbPassword.Enabled = false;
                    chkRememberMe.Enabled = false;
                    MessageBox.Show("Login Locked, Invalid Username/Password was entered 3 times", "Locked", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    clsUtil.LogError($"Invalid username/password was entered 3 times. username={txbUsername.Text}, password={txbPassword.Text}", System.Diagnostics.EventLogEntryType.Warning);
                }
                else
                    LoginFailedTrials++; 
            }

        }

        private void frmLogin_Load(object sender, EventArgs e)
        {
            string username = clsUtil.GetUsernameFromWinRegistry();
            string password = clsUtil.GetPasswordFromWinRegistry();

            if (!string.IsNullOrWhiteSpace(username) && !string.IsNullOrWhiteSpace(password))
            {
                txbUsername.Text = username;
                txbPassword.Text = password;
                chkRememberMe.Checked = true;
            }
        }
    }
}
