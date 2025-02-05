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
using static DVLD_BusinessLogicLayer.clsGlobalSettings;

namespace DVLD.User
{
    public partial class frmAddEditUser : Form
    {
        private enMode _Mode = enMode.AddNew;
        private clsUser _User = null;

        public frmAddEditUser(int UserID = -1)
        {
            InitializeComponent();
           
            if (UserID == -1)
            { _User = new clsUser(); _Mode = enMode.AddNew; }
            else
            { _User = clsUser.Find(UserID); _Mode = enMode.Update; }

            ctrlPersonCardFinder1.PersonSelected += CtrlPersonCardFinder1_PersonSelected;
        }

        private void CtrlPersonCardFinder1_PersonSelected()
        {

            if (clsUser.IsPersonAUser(ctrlPersonCardFinder1.SelectedPerson.ID))
            {
                MessageBox.Show("This Person Already a User, Choose Another Person.", "The Person is User", MessageBoxButtons.OK, MessageBoxIcon.Error);
                tabControl1.TabPages.Remove(tpLoginInfo);
                btnNext.Enabled = false;
            }
            else
                btnNext.Enabled = true;
        }

        private void _SetDefaultValues()
        {
            tabControl1.TabPages.Remove(tpLoginInfo);

            if (_Mode == enMode.AddNew)
            {
                lblTitle.Text = "Add New User";
                pbModeIcon.Image = Properties.Resources.add;
                this.Text = "Add New User";
            }
            else
            {
                lblTitle.Text = "Update User";
                pbModeIcon.Image = Properties.Resources.edit;
                this.Text = "Update User";
                tabControl1.TabPages.Add(tpLoginInfo);
            }

        }

        private void _LoadUserData()
        {
            ctrlPersonCardFinder1.LoadPersonInfo(_User.PersonID);
            lblUserID.Text = _User.ID.ToString();
            txbUsername.Text = _User.Username;
            txbPassword.Text = _User.Password;
            txbConfirmPassword.Text = _User.Password;
            chbActive.Checked = _User.IsActive;
            btnNext.Enabled = true;
        }

        private void frmAddEditUser_Load(object sender, EventArgs e)
        {
            _SetDefaultValues();

            if (_Mode == enMode.Update)
                _LoadUserData();
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            if (tabControl1.TabPages.Count == 1 && ctrlPersonCardFinder1.IsPersonSelected)
                tabControl1.TabPages.Add(tpLoginInfo);
                
            ++tabControl1.SelectedIndex;

        }
        private void btnPrevious_Click(object sender, EventArgs e)
        {
            --tabControl1.SelectedIndex;
        }
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void btnClear_Click(object sender, EventArgs e)
        {
            txbUsername.Clear();
            txbPassword.Clear();
            txbConfirmPassword.Clear();
            chbActive.Checked = false;

            if (_Mode == enMode.AddNew)
            {
                tabControl1.TabPages.Remove(tpLoginInfo);
                ctrlPersonCardFinder1.Clear();
            }
        }


        private bool _IsRequiredDataFilled()
        {
            return !string.IsNullOrWhiteSpace(txbUsername.Text) &&
                    !string.IsNullOrWhiteSpace(txbPassword.Text) &&
                    !string.IsNullOrWhiteSpace(txbConfirmPassword.Text);
        }
        private bool _IsDataValid()
        {
            bool IsValid = false;
            if (!_IsRequiredDataFilled())
                MessageBox.Show("Please Fill Required Information", "Info Missing!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else if (txbPassword.Text != txbConfirmPassword.Text)
                MessageBox.Show("Password Confirmation does not match the Password!", "Confirm Password", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else
                IsValid = true;

            return IsValid;
        }

        private void _FillUserObject()
        {
            _User.Username = txbUsername.Text;
            _User.Password = txbPassword.Text;
            _User.IsActive = chbActive.Checked;
            _User.PersonID = ctrlPersonCardFinder1.SelectedPerson.ID;
        }

        private void _ChangeFormMode()
        {
            _Mode = enMode.Update;
            lblUserID.Text = _User.ID.ToString();
            lblTitle.Text = "Update User";
            pbModeIcon.Image = Properties.Resources.edit;
            this.Text = "Update User";
            ctrlPersonCardFinder1.EnableFinder = false;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!_IsDataValid())
                return;

            _FillUserObject();

            if (_User.Save())
                MessageBox.Show("User Data Saved Successfully.", "Done", MessageBoxButtons.OK, MessageBoxIcon.Information);
            else
                MessageBox.Show("Error: User Data was NOT Saved Successfully.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            _ChangeFormMode();
        }
    }
}
