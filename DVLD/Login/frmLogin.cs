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

        private void btnLogin_Click(object sender, EventArgs e)
        {
            clsUser User = clsUser.FindByUsernameAndPassword(txbUsername.Text, txbPassword.Text);

            if (User != null)
            {
                if (User.IsActive)
                {
                    if (chkRememberMe.Checked)
                        clsUtil.SaveLoginCredentialsToFile(txbUsername.Text, txbPassword.Text);
                    else
                        clsUtil.ClearLoginCredentialsFromFile();

                    clsGlobalSettings.LoggedInUser = User;
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
                else
                { MessageBox.Show("This User Account is Not Active.", "Login Failed", MessageBoxButtons.OK, MessageBoxIcon.Error); txbUsername.Focus(); }

            }
            else
            { MessageBox.Show("Invalid Username/Password.", "Login Failed", MessageBoxButtons.OK, MessageBoxIcon.Error); txbUsername.Focus(); }

        }

        private void frmLogin_Load(object sender, EventArgs e)
        {
            if (File.Exists(clsGlobalSettings.RememberMeFilePath))
            {
                string[] lines = File.ReadAllLines(clsGlobalSettings.RememberMeFilePath);

                if (lines.Length > 0)
                {
                    txbUsername.Text = lines[0];
                    txbPassword.Text = lines[1];
                    chkRememberMe.Checked = true;
                }

            }
        }
    }
}
