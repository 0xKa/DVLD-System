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

namespace DVLD.Application
{
    public partial class frmAddEditLocalLicenseApplication : Form
    {
        private enMode _Mode = enMode.AddNew;
        private clsLocalLicenseApplication _LLApplication = null;

        public frmAddEditLocalLicenseApplication(int LLApplicationID = -1)
        {
            InitializeComponent();

            if (LLApplicationID == -1)
            { _LLApplication = new clsLocalLicenseApplication(); _Mode = enMode.AddNew; }
            else
            { _LLApplication = clsLocalLicenseApplication.FindByLLApplicationID(LLApplicationID); _Mode = enMode.Update; }

            ctrlPersonCardFinder1.PersonSelected += CtrlPersonCardFinder1_PersonSelected;
        }

        private void CtrlPersonCardFinder1_PersonSelected()
        {
            btnNext.Enabled = true;
        }


        private void _FillLicenseClassesInComboBox()
        {
            DataTable dtLicenseClasses = clsLicenseClass.GetAllLicenseClasses();

            foreach (DataRow row in dtLicenseClasses.Rows)
            {
                cbLicenseClass.Items.Add(row["Title"]);
            }
            cbLicenseClass.SelectedIndex = 2;
        }
        private void _SetDefaultValues()
        {
            _FillLicenseClassesInComboBox();
            tabControl1.TabPages.Remove(tpApplicationInfo);
            lblApplicationDate.Text = DateTime.Now.ToString("dd/MMM/yyyy, hh:mm:ss tt");
            lblApplicationFees.Text = clsApplicationType.GetApplicationFees(clsApplicationType.enApplicationType.NewLocalDrivingLicense).ToString();
            lblCreatedByUserID.Text = clsGlobalSettings.LoggedInUser.Username;

            if (_Mode == enMode.AddNew)
            {
                lblTitle.Text = "Add New Local License Application";
                pbModeIcon.Image = Properties.Resources.add;
                this.Text = "Add New Local License Application";
            }
            else
            {
                lblTitle.Text = "Update Local License Application";
                pbModeIcon.Image = Properties.Resources.edit;
                this.Text = "Update Local License Application";
                tabControl1.TabPages.Add(tpApplicationInfo);
            }

        }
        private void _LoadApplicationData()
        {
            ctrlPersonCardFinder1.LoadPersonInfo(_LLApplication.ApplicantPersonID);
            lblApplicationDate.Text = _LLApplication.ApplicationDate.ToString("dd/MMM/yyyy, hh:mm:ss tt");
            lblApplicationFees.Text = _LLApplication.Fees.ToString();
            lblCreatedByUserID.Text = _LLApplication.CreatedByUserID.ToString();
            lblLLApplicationID.Text = _LLApplication.ID.ToString();
            btnNext.Enabled = true;
        }
        private void frmAddEditLocalLicenseApplication_Load(object sender, EventArgs e)
        {
            _SetDefaultValues();

            if (_Mode == enMode.Update)
                _LoadApplicationData();
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            if (tabControl1.TabPages.Count == 1 && ctrlPersonCardFinder1.IsPersonSelected)
                tabControl1.TabPages.Add(tpApplicationInfo);

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
            cbLicenseClass.SelectedIndex = 2;
            if (_Mode == enMode.AddNew)
            {
                tabControl1.TabPages.Remove(tpApplicationInfo);
                ctrlPersonCardFinder1.Clear();
            }
        }


        private bool _IsPersonAgeValidForLicenseClass()
        {
            DateTime DateOfBirth = ctrlPersonCardFinder1.SelectedPerson.DateOfBirth;
            int age = DateTime.Now.Year - DateOfBirth.Year;

            //check if birth day haven't ouccerd yet
            if (DateOfBirth > DateTime.Now.AddYears(-age))
                age--;

            return age >= clsLicenseClass.GetMinimumAllowedAge((clsLicenseClass.enLicenseClass)(cbLicenseClass.SelectedIndex + 1));
        }
        private bool _IsDataValid()
        {
            bool IsValid = false;
            if (!_IsPersonAgeValidForLicenseClass())
                MessageBox.Show("Selected Person Age is Invalid for the Selected License Class", "Age Invalid", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else if (//here // check if application allowed)
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
            lblLLApplicationID.Text = _LLApplication.ID.ToString();
            lblTitle.Text = "Update Application";
            pbModeIcon.Image = Properties.Resources.edit;
            this.Text = "Update Application";
            ctrlPersonCardFinder1.EnableFinder = false;
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!_IsDataValid())
                return;

            _FillApplicationObject();

            if (_Application.Save())
                MessageBox.Show("Application Data Saved Successfully.", "Done", MessageBoxButtons.OK, MessageBoxIcon.Information);
            else
                MessageBox.Show("Error: Application Data was NOT Saved Successfully.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            _ChangeFormMode();
        }
    }
}
