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
    public partial class frmTestsAppointment : Form
    {
        clsGlobalSettings.enTestType _TestType;
        int _LDLApplicationID = -1;
        public frmTestsAppointment(int LDLApplicationID, clsGlobalSettings.enTestType TestType)
        {
            InitializeComponent();
            _TestType = TestType;
            _LDLApplicationID = LDLApplicationID;
        }

        private void _InitiateTitle()
        {
            switch (_TestType)
            {
                case clsGlobalSettings.enTestType.Vision:
                    lblTitle.Text = "Vision Test Appointment";
                    pictureBox1.Image = Properties.Resources.shared_vision;
                    break;
                case clsGlobalSettings.enTestType.Writing:
                    lblTitle.Text = "Writing Test Appointment";
                    pictureBox1.Image = Properties.Resources.writing;
                    break;
                case clsGlobalSettings.enTestType.Street:
                    lblTitle.Text = "Street Test Appointment";
                    pictureBox1.Image = Properties.Resources.motorway;
                    break;
            }
        }
        private void _RefreshDgvList()
        {
            dgvAppointmentsList.DataSource = clsTestAppointment.GetTestAppointments(_LDLApplicationID, (int)_TestType);
            lblNumberOfRecords.Text = "Number of Records: " + dgvAppointmentsList.RowCount.ToString();


            if (dgvAppointmentsList.RowCount > 0)
            {
                dgvAppointmentsList.Columns["AppointmentDate"].DefaultCellStyle.Format = "dd/MMM/yyyy [HH:mm:ss tt]";
                dgvAppointmentsList.Sort(dgvAppointmentsList.Columns[0], ListSortDirection.Descending);
            }
        }

        private void frmTestsAppointment_Load(object sender, EventArgs e)
        {
            _InitiateTitle();
            _RefreshDgvList();
            ctrlLDLApplicationInfoCard1.LoadInfo(_LDLApplicationID);
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAddAppointment_Click(object sender, EventArgs e)
        {
            if (clsTest.IsPassedThisTest((int)_TestType, _LDLApplicationID))
            {
                MessageBox.Show("This Person Already Passed This Test Type.", "Already Passed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else if (clsTestAppointment.DoesHasAnActiveAppointment((int)_TestType, _LDLApplicationID))
            {
                MessageBox.Show("This Person Has An Active Test Appointment.", "Alredy Scheduled", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            Form frmSchduleTest = null;
            switch (_TestType)
            {
                case clsGlobalSettings.enTestType.Vision:
                    frmSchduleTest = new frmScheduleVisionTest(-1, _LDLApplicationID);
                    break;
                case clsGlobalSettings.enTestType.Writing:
                    //
                    break;
                case clsGlobalSettings.enTestType.Street:
                    //
                    break;
            }

            frmSchduleTest.MdiParent = this.MdiParent;

            frmSchduleTest.FormClosed += frmSchduleTest_FormClosed;
            frmSchduleTest.Show();
        }
        private void frmSchduleTest_FormClosed(object sender, FormClosedEventArgs e)
        {
            _RefreshDgvList();
        }

        private void _ShowVisionTestEditForm() 
        {
            frmScheduleVisionTest frmSVT = null;

            if (clsTest.IsPassedThisTest(1, _LDLApplicationID) || clsTestAppointment.IsAppointmentLocked((int)dgvAppointmentsList.CurrentRow.Cells[0].Value))
                frmSVT = new frmScheduleVisionTest((int)dgvAppointmentsList.CurrentRow.Cells[0].Value, _LDLApplicationID, true);
            else
                frmSVT = new frmScheduleVisionTest((int)dgvAppointmentsList.CurrentRow.Cells[0].Value, _LDLApplicationID);

            frmSVT.MdiParent = this.MdiParent;

            frmSVT.FormClosed += frmSchduleTest_FormClosed;
            frmSVT.Show();
        }
        private void _ShowWritingTestEditForm() 
        {
            
        }
        private void _ShowStreetTestEditForm() 
        {
            
        }
        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {
            switch (_TestType)
            {
                case clsGlobalSettings.enTestType.Vision:
                    _ShowVisionTestEditForm();
                    break;
                case clsGlobalSettings.enTestType.Writing:
                    _ShowWritingTestEditForm();//
                    break;
                case clsGlobalSettings.enTestType.Street:
                    _ShowStreetTestEditForm();//
                    break;
            }
        }

        private void _ShowVisionTakeTestForm()
        {
            if (clsTest.IsPassedThisTest(1, _LDLApplicationID))
            {
                MessageBox.Show("This Person Already Passed Vision Test.", "Already Passed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else if (clsTestAppointment.IsAppointmentLocked((int)dgvAppointmentsList.CurrentRow.Cells[0].Value))
            {
                MessageBox.Show("This Appointment Is Locked.", "Locked", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            frmTakeTest frmTT = new frmTakeTest(clsGlobalSettings.enTestType.Vision, (int)dgvAppointmentsList.CurrentRow.Cells[0].Value, _LDLApplicationID);
            frmTT.MdiParent = this.MdiParent;

            frmTT.FormClosed += frmSchduleTest_FormClosed;
            frmTT.Show();
        }
        private void _ShowWritingTakeTestForm()
        {

        }
        private void _ShowStreetTakeTestForm()
        {

        }
        private void takeTestToolStripMenuItem_Click(object sender, EventArgs e)
        {
            switch (_TestType)
            {
                case clsGlobalSettings.enTestType.Vision:
                    _ShowVisionTakeTestForm();
                    break;
                case clsGlobalSettings.enTestType.Writing:
                    _ShowWritingTakeTestForm();//
                    break;
                case clsGlobalSettings.enTestType.Street:
                    _ShowStreetTakeTestForm();//
                    break;
            }
        }
    }
}
