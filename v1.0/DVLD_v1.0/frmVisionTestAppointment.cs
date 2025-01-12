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
    public partial class frmVisionTestAppointment : Form
    {
        int _LDLApplicationID = 0;
        public frmVisionTestAppointment(int LDLApplicationID)
        {
            InitializeComponent();
            _LDLApplicationID = LDLApplicationID;
        }

        private void _RefreshDgvList()
        {
            dgvAppointmentsList.DataSource = clsTestAppointment.GetTestAppointments(_LDLApplicationID,1);
            lblNumberOfRecords.Text = "Number of Records: " + dgvAppointmentsList.RowCount.ToString();


            if (dgvAppointmentsList.RowCount > 0)
            {
                dgvAppointmentsList.Columns["AppointmentDate"].DefaultCellStyle.Format = "dd/MMM/yyyy [HH:mm:ss tt]";
                dgvAppointmentsList.Sort(dgvAppointmentsList.Columns[0], ListSortDirection.Descending);
            }
        }

        private void frmVisionTestAppointment_Load(object sender, EventArgs e)
        {
            _RefreshDgvList();
            ctrlLDLApplicationInfoCard1.LoadInfo(_LDLApplicationID);
          }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAddAppointment_Click(object sender, EventArgs e)
        {

            if (clsTest.IsPassedThisTest(1, _LDLApplicationID))
            {
                MessageBox.Show("This Person Already Passed Vision Test.", "Already Passed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else if (clsTestAppointment.DoesHasAnActiveAppointment(1, _LDLApplicationID))
            {
                MessageBox.Show("This Person Has An Active Vision Test Appointment.", "Alredy Scheduled", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            frmScheduleVisionTest frmSVT = new frmScheduleVisionTest(-1, _LDLApplicationID);
            frmSVT.MdiParent = this.MdiParent;

            frmSVT.FormClosed += FrmSVT_FormClosed;
            frmSVT.Show();

        }

        private void FrmSVT_FormClosed(object sender, FormClosedEventArgs e)
        {
            _RefreshDgvList();
        }

        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmScheduleVisionTest frmSVT = null;
            
            if (clsTest.IsPassedThisTest(1, _LDLApplicationID) || clsTestAppointment.IsAppointmentLocked((int)dgvAppointmentsList.CurrentRow.Cells[0].Value))
                frmSVT = new frmScheduleVisionTest((int)dgvAppointmentsList.CurrentRow.Cells[0].Value, _LDLApplicationID, true);
            else 
                frmSVT = new frmScheduleVisionTest((int)dgvAppointmentsList.CurrentRow.Cells[0].Value, _LDLApplicationID);
            
            frmSVT.MdiParent = this.MdiParent;

            frmSVT.FormClosed += FrmSVT_FormClosed;
            frmSVT.Show();

        }

        private void takeTestToolStripMenuItem_Click(object sender, EventArgs e)
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

            frmTakeTest frmTT = new frmTakeTest(frmTakeTest.enTestType.Vision, (int)dgvAppointmentsList.CurrentRow.Cells[0].Value, _LDLApplicationID);
            frmTT.MdiParent = this.MdiParent;

            frmTT.FormClosed += FrmSVT_FormClosed;
            frmTT.Show();

        }
    }
}
