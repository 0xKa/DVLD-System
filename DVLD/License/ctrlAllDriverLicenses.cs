using DVLD.License.Local_Licenses;
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

namespace DVLD.License
{
    public partial class ctrlAllDriverLicenses : UserControl
    {
        clsDriver _Driver = null;

        public ctrlAllDriverLicenses()
        {
            InitializeComponent();

        }

        private void _LoadLocalLicenseInfo()
        {
            dgvLocalLicenses.DataSource = clsLicense.GetDriverLocalLicenses(_Driver.ID);
            lblNumberOfLocalLicenses.Text = dgvLocalLicenses.RowCount.ToString();

            if (dgvLocalLicenses.RowCount > 0)
            {
                dgvLocalLicenses.Columns["ID"].Width = 50;
                dgvLocalLicenses.Columns["ApplicationID"].Width = 50;
                dgvLocalLicenses.Columns["IssueDate"].Width = 55;
                dgvLocalLicenses.Columns["IssueDate"].DefaultCellStyle.Format = "dd/MMM/yyyy";
                dgvLocalLicenses.Columns["ExpirationDate"].Width = 55;
                dgvLocalLicenses.Columns["ExpirationDate"].DefaultCellStyle.Format = "dd/MMM/yyyy";
                dgvLocalLicenses.Columns["IsActive"].Width = 50;
            }
        }
        private void _LoadInternationalLicenseInfo()
        {
            dgvInternationalLicenses.DataSource = clsLicense.GetDriverInternationalLicenses(_Driver.ID);
            lblNumberOfInternationalLicenses.Text = dgvInternationalLicenses.RowCount.ToString();
            
            if (dgvInternationalLicenses.RowCount > 0)
            {
                dgvLocalLicenses.Columns["ID"].Width = 50;
                dgvLocalLicenses.Columns["ApplicationID"].Width = 50;
                dgvLocalLicenses.Columns["IssueDate"].Width = 55;
                dgvLocalLicenses.Columns["IssueDate"].DefaultCellStyle.Format = "dd/MMM/yyyy";
                dgvLocalLicenses.Columns["ExpirationDate"].Width = 55;
                dgvLocalLicenses.Columns["ExpirationDate"].DefaultCellStyle.Format = "dd/MMM/yyyy";
                dgvLocalLicenses.Columns["IsActive"].Width = 50;
            }
        }

        public void LoadInfo(clsDriver driver)
        {
            if (driver != null)
            {
                _Driver = driver;
                _LoadLocalLicenseInfo();
                _LoadInternationalLicenseInfo();
            }
            else
                MessageBox.Show("Driver was not found!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

        }
        public void LoadInfo(int DriverID)
        {
            this.LoadInfo(clsDriver.Find(DriverID));
        }
        public void LoadInfoByPersonID(int PersonID)
        {
            this.LoadInfo(clsDriver.FindByPersonID(PersonID));
        }
       
        private void showLocalLicenseInfoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmLicenseDetails frmLicenseDetails = new frmLicenseDetails(null, (int)dgvLocalLicenses.CurrentRow.Cells[0].Value);
            frmLicenseDetails.ShowDialog();
        }
        private void showInternationalLicenseInfoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //koko
        }
        private void dgvLocalLicenses_DoubleClick_1(object sender, EventArgs e)
        {
            showLocalLicenseInfoToolStripMenuItem.PerformClick();
        }
        private void dgvInternationalLicenses_DoubleClick_1(object sender, EventArgs e)
        {
            showInternationalLicenseInfoToolStripMenuItem.PerformClick();

        }
    }
}
