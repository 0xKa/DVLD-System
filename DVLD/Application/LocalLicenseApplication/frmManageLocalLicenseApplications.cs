using DVLD.Tests;
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
using static DVLD_BusinessLogicLayer.clsApplication;
using static DVLD_BusinessLogicLayer.clsLocalLicenseApplication;

namespace DVLD.Application.LocalLicenseApplication
{
    public partial class frmManageLocalLicenseApplications : Form
    {
        public frmManageLocalLicenseApplications()
        {
            InitializeComponent();
        }

        private DataTable _dtLLApplicationsList = null;
        private void _RefreshDGV()
        {
            _dtLLApplicationsList = clsLocalLicenseApplication.GetAllLocalLicenseApplications();
            dgvLLApplicationsList.DataSource = _dtLLApplicationsList;
            dgvLLApplicationsList.Sort(dgvLLApplicationsList.Columns[0], ListSortDirection.Descending);
            lblNumberOfRecords.Text = dgvLLApplicationsList.RowCount.ToString();
        }
        private void _EditDGV()
        {
            if (dgvLLApplicationsList.RowCount > 0)
            {
                dgvLLApplicationsList.Columns["ID"].Width = 50;
                dgvLLApplicationsList.Columns["NationalNo"].Width = 50;
                dgvLLApplicationsList.Columns["LicenseClass"].Width = 150;
                dgvLLApplicationsList.Columns["ApplicationDate"].Width = 100;
                dgvLLApplicationsList.Columns["PassedTests"].Width = 50;
                dgvLLApplicationsList.Columns["ApplicationStatus"].Width = 100;

                dgvLLApplicationsList.Columns["ApplicationDate"].DefaultCellStyle.Format = "dd/MMM/yyyy, hh:mm:ss tt";
            }
            cbSearchOptions.SelectedIndex = 0;
        }
        private void frmManageLocalLicenseApplications_Load(object sender, EventArgs e)
        {
            _RefreshDGV();
            _EditDGV();
        }

        private void btnAddPerson_Click(object sender, EventArgs e)
        {
            frmAddEditLocalLicenseApplication frmAELLA = new frmAddEditLocalLicenseApplication();
            frmAELLA.FormClosed += Refresh_OnFormClosed;
            frmAELLA.ShowDialog();
        }
        private void Refresh_OnFormClosed(object sender, FormClosedEventArgs e)
        {
            _RefreshDGV();
        }
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }


        private void btnClearSearch_Click(object sender, EventArgs e)
        {
            txbSearchBy.Clear();
            txbSearchBy.Focus();

        }
        private void cbSearchOptions_SelectedIndexChanged(object sender, EventArgs e)
        {
            btnClearSearch.PerformClick();

            switch (cbSearchOptions.SelectedItem)
            {

                case "None":
                    txbSearchBy.Visible = false;

                    break;

                default:
                    txbSearchBy.Visible = true;
                    txbSearchBy.Focus();
                    break;
            }

            _dtLLApplicationsList.DefaultView.RowFilter = string.Empty;

        }
        private void txbSearchBy_TextChanged(object sender, EventArgs e)
        {
            string Search = txbSearchBy.Text.Trim();
            string SearchColumn = cbSearchOptions.SelectedItem.ToString();

            if (Search == string.Empty)
            {
                _dtLLApplicationsList.DefaultView.RowFilter = string.Empty;
                btnClearSearch.Visible = false;
            }
            else
            {
                btnClearSearch.Visible = true;

                //search logic
                if (SearchColumn == "ID" || SearchColumn == "PassedTests")
                    _dtLLApplicationsList.DefaultView.RowFilter = $"{SearchColumn} = {Convert.ToInt32(Search)}";
                else
                    _dtLLApplicationsList.DefaultView.RowFilter = $"{SearchColumn} LIKE '%{Search}%'";

            }

            lblNumberOfRecords.Text = dgvLLApplicationsList.RowCount.ToString();
        }
        private void txbSearchBy_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (((string)cbSearchOptions.SelectedItem == "ID" || (string)cbSearchOptions.SelectedItem == "PassedTests")
                && !char.IsDigit(e.KeyChar) && e.KeyChar != (char)Keys.Back)
                e.Handled = true;
        }


        private void _EnableTestsSchedule()
        {
            issueDrivingLicenseToolStripMenuItem.Enabled = false;

            int passedTests = (int)dgvLLApplicationsList.CurrentRow.Cells["PassedTests"].Value;
            if (passedTests == 0)
            {
                visionTestToolStripMenuItem.Enabled = true;
                theoryTestToolStripMenuItem.Enabled = false;
                practicalTestToolStripMenuItem.Enabled = false;
            }
            else if (passedTests == 1)
            {
                visionTestToolStripMenuItem.Enabled = false;
                theoryTestToolStripMenuItem.Enabled = true;
                practicalTestToolStripMenuItem.Enabled = false;
            }
            else if (passedTests == 2)
            {
                visionTestToolStripMenuItem.Enabled = false;
                theoryTestToolStripMenuItem.Enabled = false;
                practicalTestToolStripMenuItem.Enabled = true;
            }
            else
            {
                scheduleTestsToolStripMenuItem.Enabled = false;
                issueDrivingLicenseToolStripMenuItem.Enabled = true;
            }
        }
        private void _EnableMenuItems(bool IsEnabled)
        {
            editToolStripMenuItem.Enabled = IsEnabled;
            deleteToolStripMenuItem.Enabled = IsEnabled;
            cancelApplicationToolStripMenuItem.Enabled = IsEnabled;
            scheduleTestsToolStripMenuItem.Enabled = IsEnabled;
            issueDrivingLicenseToolStripMenuItem.Enabled = IsEnabled;
            showLicenseToolStripMenuItem.Enabled = IsEnabled;
        }
        private void contextMenuStrip1_Opening(object sender, CancelEventArgs e)
        {
            enApplicationStatus status = FindByLLApplicationID((int)dgvLLApplicationsList.CurrentRow.Cells[0].Value).enStatus;
            
            if (status == enApplicationStatus.New)
            {
                _EnableMenuItems(true);
                _EnableTestsSchedule();
            }
            else
                _EnableMenuItems(false);

            showLicenseToolStripMenuItem.Enabled = (status == enApplicationStatus.Completed);
        }



        private void showDetailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmLocalLicenseApplicationDetails frmLLAD = new frmLocalLicenseApplicationDetails((int)dgvLLApplicationsList.CurrentRow.Cells[0].Value);
            frmLLAD.FormClosed += Refresh_OnFormClosed;
            frmLLAD.ShowDialog();
        }
        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmAddEditLocalLicenseApplication frmAELLD = new frmAddEditLocalLicenseApplication((int)dgvLLApplicationsList.CurrentRow.Cells[0].Value);
            frmAELLD.FormClosed += Refresh_OnFormClosed;
            frmAELLD.ShowDialog();
        }
        private void dgvLLApplicationsList_DoubleClick(object sender, EventArgs e)
        {
            showDetailsToolStripMenuItem.PerformClick();
        }
        private void cancelApplicationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ChangeApplicationStatus(FindByLLApplicationID((int)dgvLLApplicationsList.CurrentRow.Cells[0].Value).ApplicationID, enApplicationStatus.Canceled);
            _RefreshDGV();
        }


        private void visionTestToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmManageTestAppointments frmMTA = new frmManageTestAppointments((int)dgvLLApplicationsList.CurrentRow.Cells[0].Value, clsTestType.enTestType.VisionTest);
            frmMTA.FormClosed += Refresh_OnFormClosed;
            frmMTA.ShowDialog();

        }
        private void theoryTestToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmManageTestAppointments frmMTA = new frmManageTestAppointments((int)dgvLLApplicationsList.CurrentRow.Cells[0].Value, clsTestType.enTestType.TheoryTest);
            frmMTA.FormClosed += Refresh_OnFormClosed;
            frmMTA.ShowDialog();
        }
        private void practicalTestToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmManageTestAppointments frmMTA = new frmManageTestAppointments((int)dgvLLApplicationsList.CurrentRow.Cells[0].Value, clsTestType.enTestType.PracticalTest);
            frmMTA.FormClosed += Refresh_OnFormClosed;
            frmMTA.ShowDialog();
        }
        private void issueDrivingLicenseToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void showLicenseToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
    }
}
