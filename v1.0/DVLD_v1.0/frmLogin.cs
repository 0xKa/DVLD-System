using DVLD_BusinessLayer;
using System;
using System.IO;
using System.Windows.Forms;

namespace DVLD_v1._0
{
    public partial class frmLogin : Form
    {
        public frmLogin()
        {
            InitializeComponent();
        }

        private string _RememberMeFilePath = @"F:\ProgrammingAdvices\Course 19 - Full Real Project\DVLD\DVLD_v1.0\RememberMeLoginCredentials.txt";
        private void _LoadCredentials()
        {
            if (File.Exists(_RememberMeFilePath))
            {
                string[] lines = File.ReadAllLines(_RememberMeFilePath);

                if (lines.Length > 0)
                {
                    txbUsername.Text = lines[0];
                    txbPassword.Text = lines[1];
                    chkRememberMe.Checked = true;
                }

            }
        }
        private void frmLogin_Load(object sender, EventArgs e)
        {
            _LoadCredentials();
        }

        private void _SaveCredentials(string username, string password)
        {
            File.WriteAllLines(_RememberMeFilePath, new string[] { username, password });
        }
        
        private void _ClearCredentials()
        {
            if (File.Exists(_RememberMeFilePath)) 
                File.Delete(_RememberMeFilePath);
        }

        private bool _ValidateLogin(string Username, string Password)
        {
            clsUser CurrentUser = clsUser.Find(Username);

            if (CurrentUser != null && CurrentUser.Password == Password && CurrentUser.IsActive)
            {
                clsGlobalSettings.CurrentUser = CurrentUser;
                return true;
            }

            return false;
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string Username = txbUsername.Text;
            string Password = txbPassword.Text;


            if (_ValidateLogin(Username, Password))
            {
                if (chkRememberMe.Checked)
                    _SaveCredentials(Username, Password);
                else
                    _ClearCredentials();

                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            else
                MessageBox.Show("Invalid login. Please try again.", "Login Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);

        }

        
    }
}
