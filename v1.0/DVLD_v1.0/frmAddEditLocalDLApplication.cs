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

namespace DVLD_v1._0
{
    public partial class frmAddEditLocalDLApplication : Form
    {
        clsGlobalSettings.enMode _Mode = clsGlobalSettings.enMode.AddNew;
        
        private clsApplication _Application = null;
        private clsLocalDLApplication _LocalDLApplication = new clsLocalDLApplication();
        
        public frmAddEditLocalDLApplication(int LocalDLApplicationID = -1)
        {
            InitializeComponent();
            this._LocalDLApplication.ID = LocalDLApplicationID;
            _Mode = _LocalDLApplication.ID == -1 ? clsGlobalSettings.enMode.AddNew : clsGlobalSettings.enMode.Update;
        }


        private void _FillLicenseClassesInComboBox()
        {
            DataTable dtLicenseClasses = clsLicenseClass.GetAllLicenseClasses();

            foreach (DataRow row in dtLicenseClasses.Rows)
            {
                cbLicenseClasses.Items.Add(row["ClassName"]);
            }
            cbLicenseClasses.SelectedIndex = 2;
        }
        private void _FillApplicationInfoInLabels()
        {
            lblApplicationDate.Text = _Application == null ? DateTime.Now.ToShortDateString() : _Application.ApplicationDate.ToString();
            lblFees.Text = clsApplicationType.Find(1).Fees.ToString();
            lblCreatedByUsername.Text = clsGlobalSettings.CurrentUser.Username;
        }
        private void _FillApplicationInfoInEditForm(clsApplication application)
        {
            ctrlPersonCardWithFilter1.LoadPersonInfo(application.ApplicantID);
            
            lblID.Text = application.ID.ToString();
            lblApplicationDate.Text = application.ApplicationDate.ToString();
            lblFees.Text = application.PaidFees.ToString();
            lblCreatedByUsername.Text = clsUser.Find(application.CreatedByUserID).Username;

        }

        private void _LoadData()
        {
            _FillLicenseClassesInComboBox();
            if (_Mode == clsGlobalSettings.enMode.AddNew)
            {
                _FillApplicationInfoInLabels();
                tabControl1.TabPages.Remove(tpApplicationInfo); //hide application info
                lblTitle.Text = "Add New Application";
                _Application = new clsApplication();
                return;
            }

            _LocalDLApplication = clsLocalDLApplication.Find(_LocalDLApplication.ID);
            _Application = clsApplication.Find(_LocalDLApplication.ApplicationID);

            if (_Application == null)
            {
                MessageBox.Show($"Application with ID = {_LocalDLApplication.ApplicationID} Not Found!!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            lblTitle.Text = "Edit Application ID = " + _LocalDLApplication.ApplicationID.ToString();
            btnNext.Enabled = false;

            _FillApplicationInfoInEditForm(_Application);
        }
        private void frmAddEditLocalDLApplication_Load(object sender, EventArgs e)
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
                tabControl1.TabPages.Add(tpApplicationInfo);
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

        private void _SaveApplicationObject()
        { 
            _Application.ApplicantID = ctrlPersonCardWithFilter1.PersonID;
            _Application.ApplicationDate = DateTime.Now;
            _Application.ApplicationTypeID = 1; // 1 -> Local Driving License Service
            _Application.ApplicationStatus = 1; // 1 -> [New]
            _Application.LastStatusDate = DateTime.Now;
            _Application.PaidFees = clsApplicationType.Find(_Application.ApplicationTypeID).Fees;
            _Application.CreatedByUserID = clsGlobalSettings.CurrentUser.ID;

            if (! _Application.Save())
                MessageBox.Show("Error: Application Data was NOT Saved Successfully.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

        }

        private void _SaveLocalDlApplicationObject()
        {
            _LocalDLApplication.ApplicationID = _Application.ID;
            _LocalDLApplication.LicenseClassID = cbLicenseClasses.SelectedIndex + 1;

            if (_LocalDLApplication.Save())
                MessageBox.Show("Application Data Saved Successfully.", "Done");
            else
                MessageBox.Show("Error: Application Data was NOT Saved Successfully.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void _UpdateFormLabels()
        {
            lblTitle.Text = "Edit Local Driving License Application ID = " + _LocalDLApplication.ID;
            
            lblID.Text = _LocalDLApplication.ID.ToString();
            lblApplicationDate.Text = _Application.ApplicationDate.ToString();
            lblFees.Text = _Application.PaidFees.ToString();
            lblCreatedByUsername.Text = clsUser.Find(_Application.CreatedByUserID).Username;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (! clsLocalDLApplication.IsApplicationAllowed(ctrlPersonCardWithFilter1.PersonID, cbLicenseClasses.SelectedIndex + 1))
            {
                MessageBox.Show("This person already has an active or completed application for the selected license class. Please choose a different class.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            _SaveApplicationObject();
            _SaveLocalDlApplicationObject();

            _UpdateFormLabels();
            _Mode = clsGlobalSettings.enMode.Update;
        }


    }
}
