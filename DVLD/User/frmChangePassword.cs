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

namespace DVLD.User
{
    public partial class frmChangePassword : Form
    {
        private clsUser _User = null;
        public frmChangePassword(int UserID)
        {
            InitializeComponent();
            _User = clsUser.Find(UserID);
        }

        private void frmChangePassword_Load(object sender, EventArgs e)
        {
            ctrlUserCard1.LoadUserInfo(_User.ID);
            this.Text = $"Change User {_User.ID} Password";
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }


        private void btnViewPassword_MouseDown(object sender, MouseEventArgs e)
        {
            txbNewPassword.PasswordChar = '\0';
            txbConfirmPassword.PasswordChar = '\0';

        }
        private void btnViewPassword_MouseUp(object sender, MouseEventArgs e)
        {
            txbConfirmPassword.PasswordChar = '*';
            txbNewPassword.PasswordChar = '*';

        }

        private bool _IsRequiredDataFilled()
        {
            return !string.IsNullOrWhiteSpace(txbNewPassword.Text) &&
                    !string.IsNullOrWhiteSpace(txbCurrentPassword.Text) &&
                    !string.IsNullOrWhiteSpace(txbConfirmPassword.Text);
        }
        private bool _IsDataValid()
        {
            bool IsValid = false;
            if (!_IsRequiredDataFilled())
                MessageBox.Show("Please Fill Required Information", "Info Missing!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else if (txbCurrentPassword.Text != _User.Password)
            { MessageBox.Show("Current Password is Wrong!", "Password Wrong!", MessageBoxButtons.OK, MessageBoxIcon.Error); txbCurrentPassword.Focus(); }
            else if (txbNewPassword.Text != txbConfirmPassword.Text)
            { MessageBox.Show("Password Confirmation does not match the New Password!", "Confirm Password", MessageBoxButtons.OK, MessageBoxIcon.Error); txbConfirmPassword.Focus(); }
            else if (txbNewPassword.Text == _User.Password)
            { MessageBox.Show("Enter a New Password, You cannot use the same Password!", "Enter New Password", MessageBoxButtons.OK, MessageBoxIcon.Error); txbNewPassword.Focus(); }
            else
                IsValid = true;

            return IsValid;
        }


        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!_IsDataValid())
                return;

            if (_User.ChangePassword(txbNewPassword.Text))
                MessageBox.Show("User Password Changed Successfully.", "Done", MessageBoxButtons.OK, MessageBoxIcon.Information);
            else
                MessageBox.Show("Error: User Password was NOT Changed Successfully.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            
            this.Close();
        }
    }
}
