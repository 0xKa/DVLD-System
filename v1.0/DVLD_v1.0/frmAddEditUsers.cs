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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace DVLD_v1._0
{
    public partial class frmAddEditUsers : Form
    {
        private clsUser.enMode _Mode = clsUser.enMode.AddNew;

        private int _UserID = -1;
        private clsUser _User = null;

        public frmAddEditUsers( int UserID )
        {
            InitializeComponent();

            this._UserID = UserID;
            _Mode = UserID == -1? clsUser.enMode.AddNew : clsUser.enMode.Update;
        }

        private void _FillUserInfoInEditForm(clsUser user)
        {
            ctrlPersonCardWithFilter1.LoadPersonInfo(user.PersonID);
            _PersonChosen = true;
            
            lblUserID.Text = user.ID.ToString();
            txbUsername.Text = user.Username;
            txbPassword.Text = user.Password;
            txbConfirmPassword.Text = user.Password;
            chbActive.Checked = user.IsActive;

        }

        private void _LoadData()
        {
            
            if (_Mode == clsUser.enMode.AddNew)
            {
                tabControl1.TabPages.Remove(tpLoginInfo); //hide login info
                lblTitle.Text = "Add New User";
                _User = new clsUser();
                return;
            }

            _User = clsUser.Find(_UserID);

            if (_User == null)
            {
                MessageBox.Show($"User with ID = {_UserID} Not Found!!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
                return;
            }

            lblTitle.Text = "Edit User ID = " + _UserID.ToString();
            _FillUserInfoInEditForm(_User);
        }

        private void frmAddEditUsers_Load(object sender, EventArgs e)
        {
            _LoadData();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private bool _PersonChosen = false;
        private void btnNext_Click(object sender, EventArgs e)
        {
            if (_PersonChosen)
                tabControl1.SelectedIndex = 1;

            else if (ctrlPersonCardWithFilter1.IsCardFilled)
            {
                tabControl1.TabPages.Add(tpLoginInfo);
                tabControl1.SelectedIndex = 1;
                _PersonChosen = true;
            }
            else
                MessageBox.Show("You Need to Choose a Person First!", "Wait!", MessageBoxButtons.OK, MessageBoxIcon.Information);

        }

        private void btnPrevious_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedIndex = 0;
        }

        private void _FillUserObject()
        {
            _User.Username = txbUsername.Text;
            _User.Password = txbPassword.Text;
            _User.IsActive = chbActive.Checked;
            _User.PersonID = ctrlPersonCardWithFilter1.PersonID;
        }

        private void _UpdateFormLabels()
        {
            lblTitle.Text = "Edit User ID = " + _User.ID;
            lblUserID.Text = _User.ID.ToString();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            _FillUserObject();

            if (_User.Save())
                MessageBox.Show("User Data Saved Successfully.", "Done");
            else
                MessageBox.Show("Error: User Data was NOT Saved Successfully.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            _Mode = clsUser.enMode.Update;

            _UpdateFormLabels();
        }

        private void _UpdateSaveButtonState()
        {
            bool isFieldsFilled = !string.IsNullOrWhiteSpace(txbUsername.Text) &&
                                   !string.IsNullOrWhiteSpace(txbPassword.Text) &&
                                   !string.IsNullOrWhiteSpace(txbConfirmPassword.Text) &&
                                   (txbPassword.Text == txbConfirmPassword.Text);

            btnSave.Enabled = isFieldsFilled;
        }
        private void _ValidateTextBox(string ErrorMessage, System.Windows.Forms.TextBox txb)
        {
            if (string.IsNullOrWhiteSpace(txb.Text))
                errorProvider1.SetError(txb, ErrorMessage);
            else
                errorProvider1.SetError(txb, string.Empty);

            _UpdateSaveButtonState();
        }

        private void txbUsername_Validated(object sender, EventArgs e)
        {
            _ValidateTextBox("Username is required.", txbUsername);
        }
        private void txbPassword_Validated(object sender, EventArgs e)
        {
            _ValidateTextBox("Password is required.", txbPassword);
        }
        private void txbConfirmPassword_Validated(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txbConfirmPassword.Text))
            {
                errorProvider1.SetError(txbConfirmPassword, "Password Confirmation is required.");
            }
            else if (txbPassword.Text != txbConfirmPassword.Text)
            {
                errorProvider1.SetError(txbConfirmPassword, "Does not match the Password!");
            }
            else
            {
                errorProvider1.SetError(txbConfirmPassword, string.Empty);
            }

            _UpdateSaveButtonState();
        }


    }
}
