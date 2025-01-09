using DVLD_BusinessLayer;
using System;
using System.Windows.Forms;

namespace DVLD_v1._0
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
            ctrlUserCard1.LoadUserInfo(_User);
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void _UpdateChangePasswordButtonState()
        {
            bool isFieldsFilled = !string.IsNullOrWhiteSpace(txbCurrentPassword.Text) &&
                                   !string.IsNullOrWhiteSpace(txbNewPassword.Text) &&
                                   !string.IsNullOrWhiteSpace(txbConfirmPassword.Text) &&
                                   (txbCurrentPassword.Text == _User.Password) &&
                                   (txbNewPassword.Text == txbConfirmPassword.Text);

            btnChangePassword.Enabled = isFieldsFilled;
        }

        private void txbCurrentPassword_Validated(object sender, EventArgs e)
        {
            if (txbCurrentPassword.Text != _User.Password)
                errorProvider1.SetError(txbCurrentPassword, "User Password is Wrong!");
            else
                errorProvider1.SetError(txbCurrentPassword, string.Empty);

            _UpdateChangePasswordButtonState();
        }
        private void txbNewPassword_Validated(object sender, EventArgs e)
        {
            _UpdateChangePasswordButtonState();
        }
        private void txbConfirmPassword_Validated(object sender, EventArgs e)
        {
            if (txbConfirmPassword.Text != txbNewPassword.Text)
                errorProvider1.SetError(txbConfirmPassword, "Does not match the New Password!");
            else
                errorProvider1.SetError(txbConfirmPassword, string.Empty);
            _UpdateChangePasswordButtonState();
        }

        private void btnChangePassword_Click(object sender, EventArgs e)
        {
            _User.Password = txbNewPassword.Text;

            if (_User.Save())
                MessageBox.Show("Password Changed Successfully.", "Done");
            else
                MessageBox.Show("Error: New Password was NOT Saved Successfully.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

        }
    }
}
