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
    public partial class frmPersonLicenseHistory : Form
    {
        int _PersonID = -1;
        public frmPersonLicenseHistory(int PersonID)
        {
            InitializeComponent();
            _PersonID = PersonID;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void _LoadLocalLicenseInfo(int DriverID)
        {
            dgvLocalLicenseList.DataSource = clsLicense.GetLicensesOfADriver(DriverID);
            lblLocalLicenseNumberOfRecords.Text += dgvLocalLicenseList.RowCount.ToString();

            if (dgvLocalLicenseList.RowCount > 0)
                dgvLocalLicenseList.Sort(dgvLocalLicenseList.Columns[0], ListSortDirection.Descending);

        }

        private void _LoadInternationalLicenseInfo(int DriverID)
        {
            dgvInternationalLicenseList.DataSource = clsInternationalLicense.GetInternationalLicensesOfADriver(DriverID);
            lblInternationalLicenseNumberOfRecords.Text += dgvInternationalLicenseList.RowCount.ToString();
            
            if (dgvInternationalLicenseList.RowCount > 0)
                dgvInternationalLicenseList.Sort(dgvInternationalLicenseList.Columns[0], ListSortDirection.Descending);
        }

        private void frmPersonLicenseHistory_Load(object sender, EventArgs e)
        {
            ctrlPersonCard1.LoadPersonInfo(_PersonID);
            
            int DriverID = clsDriver.FindByPersonID(_PersonID).ID;

            _LoadLocalLicenseInfo(DriverID);
            _LoadInternationalLicenseInfo(DriverID);
        }

        private void dgvLocalLicenseList_DoubleClick(object sender, EventArgs e)
        {
            frmLicenseDetails frmLD = new frmLicenseDetails((int)dgvLocalLicenseList.CurrentRow.Cells[0].Value);
            frmLD.MdiParent = this.MdiParent;
            frmLD.Show();
        }

        private void dgvInternationalLicenseList_DoubleClick(object sender, EventArgs e)
        {
            frmInternationalLicenseDetails frmILD = new frmInternationalLicenseDetails((int)dgvInternationalLicenseList.CurrentRow.Cells[0].Value);
            frmILD.MdiParent = this.MdiParent;
            frmILD.Show();
        }
    }
}
