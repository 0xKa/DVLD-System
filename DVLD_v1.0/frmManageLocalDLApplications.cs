using DVLD_BusinessLayer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace DVLD_v1._0
{
    public partial class frmManageLocalDLApplications : Form
    {
        public frmManageLocalDLApplications()
        {
            InitializeComponent();
        }

        private void _RefreshDGVList()
        {
            dgvApplicationsList.DataSource = clsLocalDLApplication.GetLocalDrivingLicenseApplication_View();
            lblNumberOfRecords.Text = "Number of Records = " + dgvApplicationsList.RowCount; 
        }
        private void _EditDGVColumns()
        {
            dgvApplicationsList.Columns[0].HeaderText = "ID";
            dgvApplicationsList.Columns[0].Width = 60;
            dgvApplicationsList.Columns["ClassName"].Width = 150;
            dgvApplicationsList.Columns["NationalNo"].Width = 65;
            dgvApplicationsList.Columns["ApplicationDate"].Width = 100;
            dgvApplicationsList.Columns["PassedTestCount"].Width = 80;
            dgvApplicationsList.Columns["Status"].Width = 100;

            dgvApplicationsList.Columns["ApplicationDate"].DefaultCellStyle.Format = "dd/MMM/yyyy [HH:mm:ss tt]";
        }

        private BindingSource bs = new BindingSource();
        private void _SetFilterOptions()
        {
            cbFilterOptions.SelectedIndex = 0;
            bs.DataSource = dgvApplicationsList.DataSource;
            dgvApplicationsList.DataSource = bs;
            txbFilterBy.Text = string.Empty;
        }

        private void frmManageLocalDLApplications_Load(object sender, EventArgs e)
        {
            _RefreshDGVList();
            _EditDGVColumns();
            _SetFilterOptions();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txbFilterBy_TextChanged(object sender, EventArgs e)
        {
            string ColumnToFilter = cbFilterOptions.Text;
            string FilterText = txbFilterBy.Text;

            if (string.IsNullOrEmpty(FilterText) || ColumnToFilter == "None")
            {
                bs.RemoveFilter();
                return;
            }

            FilterText = FilterText.Replace("'", "''"); // Handle single quotes to avoid SQL errors
     
            if (ColumnToFilter == "ID")
            {
                //handling inteager columns
                if (int.TryParse(FilterText, out int value))
                    bs.Filter = $"LocalDrivingLicenseApplicationID = {value}";
                else
                    bs.Filter = "1 = 0";
            }
            else //string columns
                bs.Filter = $"{ColumnToFilter} LIKE '%{FilterText}%'";
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            txbFilterBy.Clear();
            txbFilterBy.Focus();
        }

        private void cbFilterOptions_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbFilterOptions.SelectedIndex != 0)
            {
                txbFilterBy.Visible = true;
                btnClear.Visible = true;
                txbFilterBy.Focus();
            }
            else
            {
                txbFilterBy.Visible = false;
                btnClear.Visible = false;
            }
        }

        private void btnAddApplication_Click(object sender, EventArgs e)
        {
            frmAddEditLocalDLApplication frmAddApplication = new frmAddEditLocalDLApplication(-1);
            frmAddApplication.MdiParent = this.MdiParent;

            frmAddApplication.FormClosed += FrmAddApplication_FormClosed;
            frmAddApplication.Show();
        }

        private void FrmAddApplication_FormClosed(object sender, FormClosedEventArgs e)
        {
            _RefreshDGVList();
            _SetFilterOptions();
        }

        private void cancelToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int ApplicationID = clsLocalDLApplication.Find((int)dgvApplicationsList.CurrentRow.Cells[0].Value).ApplicationID;
            
            clsApplication application = clsApplication.Find(ApplicationID);
            
            application.ChangeApplicationStatus(clsGlobalSettings.enApplicationStatus.Cancelled);
            _RefreshDGVList();
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int ApplicationID = clsLocalDLApplication.Find((int)dgvApplicationsList.CurrentRow.Cells[0].Value).ApplicationID;

            clsApplication application = clsApplication.Find(ApplicationID);

            if (application.ApplicationStatus != 3) // 3 = completed
            {
                if (clsLocalDLApplication.DeleteApplication((int)dgvApplicationsList.CurrentRow.Cells[0].Value) &&
                clsApplication.DeleteApplication(ApplicationID))
                    _RefreshDGVList();
                else
                    MessageBox.Show("Cannot delete this application. It has active appointments", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            else
                MessageBox.Show("Cannot delete a completed application.", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);

        }

        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int LDLApplicaitonID = (int)dgvApplicationsList.CurrentRow.Cells[0].Value;

            int ApplicationID = clsLocalDLApplication.Find(LDLApplicaitonID).ApplicationID;
            clsApplication application = clsApplication.Find(ApplicationID);

            if (application.ApplicationStatus == 1) // 1 = new
            {
                frmAddEditLocalDLApplication frmEditApplication = new frmAddEditLocalDLApplication(LDLApplicaitonID);
                frmEditApplication.MdiParent = this.MdiParent;

                frmEditApplication.FormClosed += FrmAddApplication_FormClosed;
                frmEditApplication.Show();
            }
            else if (application.ApplicationStatus == 2)
                MessageBox.Show("Cannot edit a Cancelled application.", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else
                MessageBox.Show("Cannot edit a Completed application.", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);


        }

        private void showDetailToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmLDLApplcationDetails LDLapplcationDetails = new frmLDLApplcationDetails((int)dgvApplicationsList.CurrentRow.Cells[0].Value);
            LDLapplcationDetails.MdiParent = this.MdiParent;

            LDLapplcationDetails.Show();

        }

        private void sechduleVisionTestToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmTestsAppointment frmVTP = new frmTestsAppointment((int)dgvApplicationsList.CurrentRow.Cells[0].Value, clsGlobalSettings.enTestType.Vision);
            frmVTP.MdiParent = this.MdiParent;

            frmVTP.FormClosed += FrmAddApplication_FormClosed;
            frmVTP.Show();
        }

        private void sechduleWrittenTestToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmTestsAppointment frmVTP = new frmTestsAppointment((int)dgvApplicationsList.CurrentRow.Cells[0].Value, clsGlobalSettings.enTestType.Writing);
            frmVTP.MdiParent = this.MdiParent;

            frmVTP.FormClosed += FrmAddApplication_FormClosed;
            frmVTP.Show();
        }

        private void sechduleStreetTestToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmTestsAppointment frmVTP = new frmTestsAppointment((int)dgvApplicationsList.CurrentRow.Cells[0].Value, clsGlobalSettings.enTestType.Street);
            frmVTP.MdiParent = this.MdiParent;

            frmVTP.FormClosed += FrmAddApplication_FormClosed;
            frmVTP.Show();
        }

        private void _ManageScheduleTestsMenuItems()
        {
            issueDrivingLicenseFirstTimeToolStripMenuItem.Enabled = false;

            int passedTests = (int)dgvApplicationsList.CurrentRow.Cells["PassedTestCount"].Value;
            if (passedTests == 0)
            {
                scheduleVisionTestToolStripMenuItem.Enabled = true;
                scheduleWrittenTestToolStripMenuItem.Enabled = false;
                scheduleStreetTestToolStripMenuItem.Enabled = false;
            }
            else if (passedTests == 1)
            {
                scheduleVisionTestToolStripMenuItem.Enabled = false;
                scheduleWrittenTestToolStripMenuItem.Enabled = true;
                scheduleStreetTestToolStripMenuItem.Enabled = false;
            }
            else if (passedTests == 2)
            {
                scheduleVisionTestToolStripMenuItem.Enabled = false;
                scheduleWrittenTestToolStripMenuItem.Enabled = false;
                scheduleStreetTestToolStripMenuItem.Enabled = true;
            }
            else
            {
                scheduleTestsToolStripMenuItem.Enabled = false;
                issueDrivingLicenseFirstTimeToolStripMenuItem.Enabled = true;
            }
        }
        private void _EnableDisableMenuOperations(bool IsEnabled)
        {
            editToolStripMenuItem.Enabled = IsEnabled;
            deleteToolStripMenuItem.Enabled = IsEnabled;
            cancelToolStripMenuItem.Enabled = IsEnabled;
            scheduleTestsToolStripMenuItem.Enabled = IsEnabled;
            issueDrivingLicenseFirstTimeToolStripMenuItem.Enabled = IsEnabled;
            showLicenseToolStripMenuItem.Enabled = IsEnabled;
        }

        private void contextMenuStrip1_Opening(object sender, CancelEventArgs e)
        {

            int ApplicationID = clsLocalDLApplication.Find((int)dgvApplicationsList.CurrentRow.Cells[0].Value).ApplicationID;
            clsGlobalSettings.enApplicationStatus status = clsApplication.GetApplicationStatus(ApplicationID);

            if (status == clsGlobalSettings.enApplicationStatus.New)
            {
                _EnableDisableMenuOperations(true);
                _ManageScheduleTestsMenuItems();
            }
            else
            {
                _EnableDisableMenuOperations(false);
            }

            showLicenseToolStripMenuItem.Enabled = status == clsGlobalSettings.enApplicationStatus.Completed ? true : false;
        }

        private void issueDrivingLicenseFirstTimeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmIssueDrivingLicense frmIDL = new frmIssueDrivingLicense((int)dgvApplicationsList.CurrentRow.Cells[0].Value);
            frmIDL.MdiParent = this.MdiParent;

            frmIDL.FormClosed += FrmAddApplication_FormClosed;
            frmIDL.Show();
        }

        private void showLicenseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int ApplicationID = clsLocalDLApplication.Find((int)dgvApplicationsList.CurrentRow.Cells[0].Value).ApplicationID;
            frmLicenseDetails frmLD = new frmLicenseDetails(clsLicense.GetLicenseIDByApplicationID(ApplicationID));
            
            frmLD.MdiParent = this.MdiParent;

            frmLD.Show();

        }

        private void showPersonsLicenseHistoryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int PersonID = clsPerson.Find(dgvApplicationsList.CurrentRow.Cells[2].Value.ToString()).ID;

            if (clsDriver.IsPersonDriver(PersonID))
            {
                frmPersonLicenseHistory frmPLH = new frmPersonLicenseHistory(PersonID);

                frmPLH.MdiParent = this.MdiParent;
                frmPLH.Show();

            }
            else
                MessageBox.Show("This Person does not have Driving License.", "Not a Driver", MessageBoxButtons.OK, MessageBoxIcon.Information);

        }
    }
}
