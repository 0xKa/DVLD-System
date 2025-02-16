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
            lblNumberOfLocalLicenses.Text += dgvLocalLicenses.RowCount.ToString();
        }
        private void _LoadInternationalLicenseInfo()
        {
            dgvLocalLicenses.DataSource = clsLicense.GetDriverInternationalLicenses(_Driver.ID);
            lblNumberOfInternationalLicenses.Text += dgvLocalLicenses.RowCount.ToString();
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
        private void dgvLocalLicenses_DoubleClick(object sender, EventArgs e)
        {
            showLocalLicenseInfoToolStripMenuItem.PerformClick();
        }
        private void dgvInternationalLicenses_DoubleClick(object sender, EventArgs e)
        {
            showInternationalLicenseInfoToolStripMenuItem.PerformClick();
        }
    }
}
