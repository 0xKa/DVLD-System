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
using static DVLD_BusinessLogicLayer.clsLocalLicenseApplication;

namespace DVLD.Tests
{
    public partial class frmManageTestAppointments : Form
    {
        private enTestType _TestType;
        private clsLocalLicenseApplication _LLApplication = null;

        public frmManageTestAppointments(int LocalLicenseApplicationID, enTestType TestType)
        {
            InitializeComponent();
            _TestType = TestType;
            _LLApplication = FindByLLApplicationID(LocalLicenseApplicationID);
        }

        private DataTable _dtAppointments = null;
        private void _RefreshDGV()
        {
            _dtAppointments = clsTestAppointment.GetAllTestAppointments(_LLApplication.ID, _TestType);
            dgvAppointmentsList.DataSource = _dtAppointments;
            lblNumberOfRecords.Text = dgvAppointmentsList.RowCount.ToString();
        }
        private void _EditDGV()
        {
            if (dgvAppointmentsList.RowCount > 0)
            {
                dgvAppointmentsList.Columns["AppointmentDate"].DefaultCellStyle.Format = "MM/dd/yyyy hh:mm:ss tt";
            }
        }
        private void _InitiateTitleAndImage()
        {
            switch (_TestType)
            {
                case enTestType.VisionTest:
                    this.Text = "Manage Vision Test Appointments";
                    lblTitle.Text = "Vision Test Appointment";
                    pictureBox1.Image = Properties.Resources.vision_test;
                    break;
                case enTestType.TheoryTest:
                    this.Text = "Manage Theory Test Appointments";
                    lblTitle.Text = "Theory Test Appointment";
                    pictureBox1.Image = Properties.Resources.theory_test;
                    break;
                case enTestType.PracticalTest:
                    this.Text = "Manage Practical Test Appointments";
                    lblTitle.Text = "Practical Test Appointment";
                    pictureBox1.Image = Properties.Resources.practical_test;
                    break;
            }
        }


        private void frmManageTestAppointments_Load(object sender, EventArgs e)
        {
            _RefreshDGV();
            _EditDGV();
            _InitiateTitleAndImage();
            ctrlLocalLicenseApplicationCard1.LoadApplicationInfo(_LLApplication.ID);
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }


        private bool _IsNewAppointmentAllowed()
        {
            if (clsTest.IsPassedTest(_LLApplication.ID, _TestType))
            { MessageBox.Show("This Person Already Passed This Test Type.", "Already Passed", MessageBoxButtons.OK, MessageBoxIcon.Error); return false; }
            else if  (clsTestAppointment.DoesHasAnActiveAppointment(_LLApplication.ID, _TestType))
            { MessageBox.Show("This Person Has An Active Test Appointment.", "Already Scheduled", MessageBoxButtons.OK, MessageBoxIcon.Error); return false; }
            else
                return true;
        }
        private void btnAddAppointment_Click(object sender, EventArgs e)
        {
            if (_IsNewAppointmentAllowed())
            {
                frmScheduleTest frmST = new frmScheduleTest(enTestType.VisionTest, _LLApplication.ID);
                frmST.FormClosed += Refresh_OnFormClosed;
                frmST.ShowDialog();
            }
        }

        private void Refresh_OnFormClosed(object sender, FormClosedEventArgs e)
        {
            _RefreshDGV();
        }

        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmScheduleTest frmST = null;

            if (clsTest.IsPassedTest(_LLApplication.ID, _TestType) || clsTestAppointment.IsAppointmentLocked((int)dgvAppointmentsList.CurrentRow.Cells[0].Value))
                frmST = new frmScheduleTest(_TestType, _LLApplication.ID, (int)dgvAppointmentsList.CurrentRow.Cells[0].Value, true);
            else
                frmST = new frmScheduleTest(_TestType, _LLApplication.ID, (int)dgvAppointmentsList.CurrentRow.Cells[0].Value);

            frmST.MdiParent = this.MdiParent;

            frmST.FormClosed += Refresh_OnFormClosed;
            frmST.Show();
        }
        private void dgvAppointmentsList_DoubleClick(object sender, EventArgs e)
        {
            editToolStripMenuItem.PerformClick();
        }
        private void takeTestToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

    }
}
