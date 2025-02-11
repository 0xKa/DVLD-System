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
    public partial class ctrlTakeTests : UserControl
    {
        public delegate void TestConductedEventHandler(object sender, EventArgs e);
        public event TestConductedEventHandler TestConducted;

        public ctrlTakeTests()
        {
            InitializeComponent();
        }
        
        private enTestType _TestType = enTestType.VisionTest;
        public enTestType TestType
        {
            get { return _TestType; }
            set
            {
                _TestType = value;

                switch (_TestType)
                {
                    case enTestType.VisionTest:
                        pictureBox1.Image = Properties.Resources.vision_test;
                        gbTestInfo.Text = "Vision Test Info";
                        break;

                    case enTestType.TheoryTest:
                        pictureBox1.Image = Properties.Resources.theory_test;
                        gbTestInfo.Text = "Theory Test Info";
                        break;

                    case enTestType.PracticalTest:
                        pictureBox1.Image = Properties.Resources.practical_test;
                        gbTestInfo.Text = "Practical Test Info";
                        break;
                }
            }
        }
        
        private clsLocalLicenseApplication _LLApplication = null;
        private clsTestAppointment _TestAppointment = null;

        private void _FillData()
        {
            lblLLApplicationID.Text = _LLApplication.ID.ToString();
            lblTestAppointmentID.Text = _TestAppointment.ID.ToString();
            lblLicenseClass.Text = _LLApplication.LicenseClassInfo.Title;
            lblApplicantPerson.Text = _LLApplication.ApplicantPerson.FullName;
            lblTrials.Text = clsTestAppointment.GetTestTrials(_LLApplication.ID, TestType).ToString();
            lblDate.Text = _TestAppointment.AppointmentDate.ToString("dd/MMM/yyyy [HH:mm:ss tt]");
            lblFees.Text = _TestAppointment.PaidFees.ToString();

        }
        public void LoadInfo(int LocalLicenseApplicationID, int AppointmentID)
        {
            _LLApplication = clsLocalLicenseApplication.FindByLLApplicationID(LocalLicenseApplicationID);
            _TestAppointment = clsTestAppointment.Find(AppointmentID);

            _FillData();


        }

        clsTest _Test = null;
        private void _FillTestObject()
        {
            _Test = new clsTest
            {
                TestAppointmentID = _TestAppointment.ID,
                Result = rbPass.Checked,
                Notes = txbNotes.Text,
                CreatedByUserID = clsGlobalSettings.LoggedInUser.ID
            };
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            _FillTestObject();

            if (_Test.Save())
            {
                MessageBox.Show("Test Data Saved Successfully.", "Done");
                TestConducted?.Invoke(null, null);
            }
            else
                MessageBox.Show("Error: Test Data was NOT Saved Successfully.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

        }
    }
}
