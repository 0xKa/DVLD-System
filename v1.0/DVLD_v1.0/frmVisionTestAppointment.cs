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
                dgvAppointmentsList.Columns["AppointmentDate"].DefaultCellStyle.Format = "dd/MMM/yyyy [HH:mm:ss tt]";
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
                MessageBox.Show("This Person Already Passed Vision Test.");
                return;
            }
            else if (clsTestAppointment.DoesHasAnActiveAppointment(1, _LDLApplicationID))
            {
                MessageBox.Show("This Person Has An Active Vision Test Appointment.");
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
            if (clsTest.IsPassedThisTest(1, _LDLApplicationID))
            {
                MessageBox.Show("This Person Already Passed Vision Test.");
                return;
            }
            else if (clsTestAppointment.IsAppointmentLocked((int)dgvAppointmentsList.CurrentRow.Cells[0].Value))
            {
                MessageBox.Show("This Appointment Is Locked.");
                return;
            }

            frmScheduleVisionTest frmSVT = new frmScheduleVisionTest((int)dgvAppointmentsList.CurrentRow.Cells[0].Value, _LDLApplicationID);
            frmSVT.MdiParent = this.MdiParent;

            frmSVT.FormClosed += FrmSVT_FormClosed;
            frmSVT.Show();
        }

        private void takeTestToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmTakeTest frmTT = new frmTakeTest();
            frmTT.MdiParent = this.MdiParent;

            frmTT.FormClosed += FrmSVT_FormClosed;
            frmTT.Show();

        }
    }
}
