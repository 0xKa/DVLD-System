using DVLD_BusinessLayer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLD_v1._0
{
    public partial class frmTakeTest : Form
    {
        public enum enTestType { Vision = 1, Writing = 2, Street = 3 }
        private enTestType _TestType;

        private clsLocalDLApplication _LDLApplication = null;
        private clsApplication _Application = null;
        private clsTestAppointment _TestAppointment = null;

        public frmTakeTest(enTestType TestType, int TestAppointmentID, int LDLApplicationID)
        {
            InitializeComponent();
            _TestType = TestType;

            _TestAppointment = clsTestAppointment.Find(TestAppointmentID);
            _LDLApplication = clsLocalDLApplication.Find(LDLApplicationID);
            _Application = clsApplication.Find(_LDLApplication.ApplicationID);
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        
        private void _LoadVisionTestInfo()
        {
            pictureBox1.Image = Properties.Resources.shared_vision;
            gbTestInfo.Text = "Vision Test";
        }
        private void _LoadWritingTestInfo()
        {
            pictureBox1.Image = Properties.Resources.writing;
            gbTestInfo.Text = "Writing Test";

        }
        private void _LoadStreetTestInfo()
        {
            pictureBox1.Image = Properties.Resources.motorway;
            gbTestInfo.Text = "Street Test";

        }

        private void _FillTestInfo()
        {
            lblLDLApplicationID.Text = _LDLApplication.ID.ToString();
            lblLicenseClass.Text = clsLicenseClass.GetClassName(_LDLApplication.LicenseClassID);
            lblApplicantPerson.Text = clsPerson.Find(_Application.ApplicantID).GetFullName();
            lblTrials.Text = clsTestAppointment.GetTestTrials(_LDLApplication.ID, (int)enTestType.Vision).ToString();
            lblDate.Text = _TestAppointment.AppointmentDate.ToString("dd/MMM/yyyy [HH:mm:ss tt]");
            lblFees.Text = _TestAppointment.PaidFees.ToString();
            lblTestAppointmentID.Text = _TestAppointment.ID.ToString();
        }

        private void _LoadInfo()
        {
            switch(_TestType)
            {
                case enTestType.Vision:
                    _LoadVisionTestInfo();
                    break;
                    
                case enTestType.Writing:
                    _LoadWritingTestInfo();
                    break;
                    
                case enTestType.Street:
                    _LoadStreetTestInfo();
                    break;
            }

            _FillTestInfo();


        }

        private void frmTakeTest_Load(object sender, EventArgs e)
        {
            _LoadInfo();
        }
    }
}
