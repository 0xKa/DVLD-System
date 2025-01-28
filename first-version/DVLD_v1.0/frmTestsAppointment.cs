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

        private void _InitiateTitleAndImage()
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
            _InitiateTitleAndImage();
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

            frmScheduleTests frmST = new frmScheduleTests(-1, _LDLApplicationID, _TestType);
            frmST.MdiParent = this.MdiParent;

            frmST.FormClosed += frmSchduleTest_FormClosed;
            frmST.Show();
        }
        private void frmSchduleTest_FormClosed(object sender, FormClosedEventArgs e)
        {
            _RefreshDgvList();
        }

        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmScheduleTests frmST = null;

            if (clsTest.IsPassedThisTest((int)_TestType, _LDLApplicationID) || clsTestAppointment.IsAppointmentLocked((int)dgvAppointmentsList.CurrentRow.Cells[0].Value))
                frmST = new frmScheduleTests((int)dgvAppointmentsList.CurrentRow.Cells[0].Value, _LDLApplicationID, _TestType, true);
            else
                frmST = new frmScheduleTests((int)dgvAppointmentsList.CurrentRow.Cells[0].Value, _LDLApplicationID, _TestType);

            frmST.MdiParent = this.MdiParent;

            frmST.FormClosed += frmSchduleTest_FormClosed;
            frmST.Show();

        }

        private void takeTestToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (clsTest.IsPassedThisTest((int)_TestType, _LDLApplicationID))
            {
                MessageBox.Show("The Person Already Passed This Test.", "Already Passed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else if (clsTestAppointment.IsAppointmentLocked((int)dgvAppointmentsList.CurrentRow.Cells[0].Value))
            {
                MessageBox.Show("This Appointment is Locked.", "Locked", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            frmTakeTest frmTT = new frmTakeTest(_TestType, (int)dgvAppointmentsList.CurrentRow.Cells[0].Value, _LDLApplicationID);
            frmTT.MdiParent = this.MdiParent;

            frmTT.FormClosed += frmSchduleTest_FormClosed;
            frmTT.Show();

        }
    }
}
