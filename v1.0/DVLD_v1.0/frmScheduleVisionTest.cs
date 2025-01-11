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
//vision test type id = 1

namespace DVLD_v1._0
{
    public partial class frmScheduleVisionTest : Form
    {
        clsGlobalSettings.enMode _Mode = clsGlobalSettings.enMode.AddNew;

        private clsLocalDLApplication _LDLApplication = null;
        private clsApplication _Application = null;
        private clsTestAppointment _TestAppointment = null;

        public frmScheduleVisionTest(int TestAppointmentID, int LDLApplicationID, bool IsLocked = false)
        {
            InitializeComponent();
            
            _LDLApplication = clsLocalDLApplication.Find(LDLApplicationID);

            if (TestAppointmentID == -1)
                _Mode = clsGlobalSettings.enMode.AddNew;
            else
            {
                _Mode = clsGlobalSettings.enMode.Update;
                _TestAppointment = clsTestAppointment.Find(TestAppointmentID);
            }

            if (IsLocked)
                _DisableSave();
        }

        private void _DisableSave()
        {
            btnSave.Enabled = false;
            dtpTestDateTime.Enabled = false;
            lblAppointmentLockMessage.Text = "This Appointment is Locked.";
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private byte _NumberOfTrials = 0;
        private double _VisionTestFees = 0;
        private double _RetakeTestFees = 0;
        private double _TotalFees = 0;
        private void _CalculateFees()
        {
            if (_IsRetakeTest)
                _RetakeTestFees = clsApplicationType.Find(8).Fees;
    
            _VisionTestFees = clsTestType.Find(1).Fees;
            _TotalFees = _VisionTestFees + _RetakeTestFees;
        }

        private void _FillBasicInfo()
        {
            lblLDLApplicationID.Text = _LDLApplication.ID.ToString();
            lblLicenseClass.Text = clsLicenseClass.GetClassName(_LDLApplication.LicenseClassID);
            
            _NumberOfTrials = clsTestAppointment.GetTestTrials(_LDLApplication.ID, 1);
            lblTrials.Text = _NumberOfTrials.ToString();

            lblFees.Text = _VisionTestFees.ToString();
            _TotalFees = _VisionTestFees;
        }

        private void _FillRetakeTestInfo()
        {
            gbRetakeTestInfo.Visible = true;

            _TotalFees = _RetakeTestFees + _VisionTestFees;

            lblRetakeTestFees.Text = _RetakeTestFees.ToString(); //8 for retake test application
            lblTotalFees.Text = _TotalFees.ToString();
        }

        private bool _IsRetakeTest = false;
        private void _LoadInfo()
        {
            _IsRetakeTest = clsTest.IsFailedThisTestBefore(1, _LDLApplication.ID);
            _CalculateFees();
            _FillBasicInfo();

            if (_IsRetakeTest)
                _FillRetakeTestInfo();
        
            if (_Mode == clsGlobalSettings.enMode.AddNew)
            {
                this.Text = "Add New Vision Test Appointment";
                _TestAppointment = new clsTestAppointment();
            }
            else
            {
                this.Text = "Edit Vision Test Appointment";
                dtpTestDateTime.Value = _TestAppointment.AppointmentDate;
            }

        }

        private void frmScheduleVisionTest_Load(object sender, EventArgs e)
        {
            _LoadInfo();
            dtpTestDateTime.MinDate = DateTime.Now.AddHours(1);
            dtpTestDateTime.MaxDate = DateTime.Now.AddMonths(3);
        
        }

        private void _FillTestAppointmentObject()
        {
            _TestAppointment.TestTypeID = 1;
            _TestAppointment.LDLAppID = _LDLApplication.ID;
            _TestAppointment.AppointmentDate = dtpTestDateTime.Value;
            _TestAppointment.PaidFees = _TotalFees;
            _TestAppointment.CreatedByUserID = clsGlobalSettings.CurrentUser.ID;
            _TestAppointment.IsLocked = false;
        }

        clsApplication _RetakeTestApplication = null;
        private void _FillRetakeTestApplicationObject()
        {
            _Application = clsApplication.Find(_LDLApplication.ApplicationID);
            _RetakeTestApplication = new clsApplication()
            {
                ApplicantID = _Application.ApplicantID,
                ApplicationDate = DateTime.Now,
                ApplicationTypeID = 8,
                ApplicationStatus = 1,
                LastStatusDate = DateTime.Now,
                PaidFees = _RetakeTestFees,
                CreatedByUserID = clsGlobalSettings.CurrentUser.ID

            };
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            _FillTestAppointmentObject();

            if(_IsRetakeTest)
            {
                _FillRetakeTestApplicationObject();

                if (_RetakeTestApplication.Save())
                {
                    _LDLApplication.ApplicationID = _RetakeTestApplication.ID;
                    _LDLApplication.Save();
                }
                else
                {
                    MessageBox.Show("Error: Retake Test Application Data was NOT Saved Successfully.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }

 
            if (_TestAppointment.Save())
                MessageBox.Show("Appointment Data Saved Successfully.", "Done");
            else
                MessageBox.Show("Error: Appointment Data was NOT Saved Successfully.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            

            _Mode = clsGlobalSettings.enMode.Update;
            this.Text = "Edit Vision Test Appointment";

        }
    }
}
