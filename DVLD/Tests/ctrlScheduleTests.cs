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
using static DVLD_BusinessLogicLayer.clsTestType;

namespace DVLD.Tests
{
    public partial class ctrlScheduleTests : UserControl
    {
        public enum enCreationMode { FirstTimeTest, RetakeTest }
        private enCreationMode _CreationMode = enCreationMode.FirstTimeTest;
        private clsGlobalSettings.enMode _Mode = clsGlobalSettings.enMode.AddNew;

        public enTestType TestType
        {
            get { return TestType; }
            set
            {
                TestType = value;

                switch (TestType)
                {
                    case enTestType.VisionTest:
                        pictureBox1.Image = Properties.Resources.vision_test;
                        gbRetakeTestInfo.Text = "Retake Vision Test Info";
                        break;

                    case enTestType.TheoryTest:
                        pictureBox1.Image = Properties.Resources.theory_test;
                        gbRetakeTestInfo.Text = "Retake Theory Test Info";
                        break;

                    case enTestType.PracticalTest:
                        pictureBox1.Image = Properties.Resources.practical_test;
                        gbRetakeTestInfo.Text = "Retake Practical Test Info";
                        break;
                }
            }
        }

        private clsLocalLicenseApplication _LLApplication = null;
        private clsTestAppointment _TestAppointment = null;
        public ctrlScheduleTests()
        {
            InitializeComponent();
        }

        private decimal _TestTypeFees = 0;
        private decimal _RetakeTestFees = 0;
        private decimal _TotalFees = 0;
        private void _CalculateFees()
        {
            if (_CreationMode == enCreationMode.RetakeTest)
                _RetakeTestFees = clsApplicationType.GetApplicationFees(clsApplicationType.enApplicationType.RetakeTest);

            _TestTypeFees = clsTestType.Find((int)TestType).Fees;
            _TotalFees = _RetakeTestFees + _TestTypeFees;
        }
        private void _FillData()
        {
            _CalculateFees();

            lblLLApplicationID.Text = _LLApplication.ID.ToString();
            lblLicenseClass.Text = _LLApplication.LicenseClassInfo.Title;
            lblTrials.Text = clsTestAppointment.GetTestTrials(_LLApplication.ID, TestType).ToString();
            lblFees.Text = _TestTypeFees.ToString();

            if (_CreationMode == enCreationMode.RetakeTest)
            {
                gbRetakeTestInfo.Visible = true;

                lblRetakeTestFees.Text = _RetakeTestFees.ToString();
                lblTotalFees.Text = _TotalFees.ToString();
                lblRetakeTestAppID.Text = _LLApplication.ApplicationID.ToString();
            }
        }
        public void LoadInfo(int LocalLicenseApplicationID, int AppointmentID = -1)
        {
            _Mode = AppointmentID == -1 ? clsGlobalSettings.enMode.AddNew : clsGlobalSettings.enMode.Update;

            _LLApplication = clsLocalLicenseApplication.FindByLLApplicationID(LocalLicenseApplicationID);

            if (_LLApplication != null)
            {
                _CreationMode = clsTest.IsRetakeTest(_LLApplication.ID, TestType) ? enCreationMode.RetakeTest : enCreationMode.FirstTimeTest;

                _FillData();

                if (_Mode == clsGlobalSettings.enMode.AddNew)
                    _TestAppointment = new clsTestAppointment();
                else
                {
                    _TestAppointment = clsTestAppointment.Find(AppointmentID);
                    dtpTestDateTime.Value = _TestAppointment.AppointmentDate;
                }

                //appointment allowed date range 
                dtpTestDateTime.MinDate = DateTime.Now.AddHours(1);
                dtpTestDateTime.MaxDate = DateTime.Now.AddMonths(3);
            }
            else
                MessageBox.Show("Error: Local License Application Was Not Found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);


        }

        private void _FillTestAppointmentObject()
        {
            _TestAppointment.TestTypeID = (int)TestType;
            _TestAppointment.LocalLicenseApplicationID = _LLApplication.ID;
            _TestAppointment.AppointmentDate = dtpTestDateTime.Value;
            _TestAppointment.PaidFees = _TotalFees;
            _TestAppointment.CreatedByUserID = clsGlobalSettings.LoggedInUser.ID;
            _TestAppointment.IsLocked = false;
        }
        private bool _SaveRetakeTestApplication()
        {
            clsApplication RetakeTestApplication = new clsApplication()
            {
                ApplicantPersonID = _LLApplication.ApplicantPerson.ID,
                ApplicationDate = DateTime.Now,
                enType = clsApplicationType.enApplicationType.RetakeTest,
                enStatus = clsApplication.enApplicationStatus.New,
                LastStatusDate = DateTime.Now,
                Fees = _RetakeTestFees,
                CreatedByUserID = clsGlobalSettings.LoggedInUser.ID

            };

            if (RetakeTestApplication.Save())
            {
                _LLApplication.ApplicationID = RetakeTestApplication.ApplicationID;
                return _LLApplication.Save();
            }
            else
                return false;


        }


        private void btnSave_Click(object sender, EventArgs e)
        {
            _FillTestAppointmentObject();

            if (_CreationMode == enCreationMode.RetakeTest)
            {
                if (!_SaveRetakeTestApplication())
                    MessageBox.Show("Error: Retake Test Application Data was NOT Saved Successfully.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            if (_TestAppointment.Save())
                MessageBox.Show("Appointment Data Saved Successfully.", "Done");
            else
                MessageBox.Show("Error: Appointment Data was NOT Saved Successfully.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            _Mode = clsGlobalSettings.enMode.Update;

        }
    }
}
