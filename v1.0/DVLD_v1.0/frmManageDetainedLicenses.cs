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
    public partial class frmManageDetainedLicenses : Form
    {
        public frmManageDetainedLicenses()
        {
            InitializeComponent();
        }

        private void _RefreshDGVList()
        {
            dgvDetainedLicensesList.DataSource = clsDetainedLicense.GetDetainedLicenses_People_view();
            lblNumberOfRecords.Text = "Number of Records = " + dgvDetainedLicensesList.RowCount;
        }
        private void _EditDGVColumns()
        {
            dgvDetainedLicensesList.Columns["DetainID"].Width = 60;
            dgvDetainedLicensesList.Columns["LicenseID"].Width = 60;
            dgvDetainedLicensesList.Columns["NationalNo"].Width = 65;
            dgvDetainedLicensesList.Columns["DetainDate"].Width = 150;
            dgvDetainedLicensesList.Columns["FullName"].Width = 300;
            dgvDetainedLicensesList.Columns["FineFees"].Width = 80;
            dgvDetainedLicensesList.Columns["IsReleased"].Width = 65;
            dgvDetainedLicensesList.Columns["ReleaseApplicationID"].Width = 120;

            dgvDetainedLicensesList.Columns["DetainDate"].DefaultCellStyle.Format = "dd/MMM/yyyy [HH:mm:ss tt]";
            dgvDetainedLicensesList.Columns["ReleaseDate"].DefaultCellStyle.Format = "dd/MMM/yyyy";
        }

        private BindingSource bs = new BindingSource();
        private void _SetFilterOptions()
        {
            cbFilterOptions.SelectedIndex = 0;
            bs.DataSource = dgvDetainedLicensesList.DataSource;
            dgvDetainedLicensesList.DataSource = bs;
            txbFilterBy.Text = string.Empty;
        }

        private void frmManageDetainedLicenses_Load(object sender, EventArgs e)
        {
            _RefreshDGVList();
            _EditDGVColumns();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
