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
    public partial class frmManageInternationalLicenses : Form
    {
        public frmManageInternationalLicenses()
        {
            InitializeComponent();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void _RefreshDGVList()
        {
            dgvLicensesList.DataSource = clsInternationalLicense.GetAllInternationalLicenses();
            lblNumberOfRecords.Text = "Number of Records = " + dgvLicensesList.RowCount;
        }
        private void _EditDGVColumns()
        {
            dgvLicensesList.Columns[0].HeaderText = "ID";
            dgvLicensesList.Columns[0].Width = 60;
            dgvLicensesList.Columns[1].Width = 100;
            dgvLicensesList.Columns[2].Width = 60;
            dgvLicensesList.Columns[3].Width = 200;

            dgvLicensesList.Columns["IssueDate"].DefaultCellStyle.Format = "dd/MMM/yyyy [HH:mm:ss tt]";
            dgvLicensesList.Columns["ExpirationDate"].DefaultCellStyle.Format = "dd/MMM/yyyy [HH:mm:ss tt]";
        }

        private BindingSource bs = new BindingSource();
        private void _SetFilterOptions()
        {
            cbFilterOptions.SelectedIndex = 0;
            bs.DataSource = dgvLicensesList.DataSource;
            dgvLicensesList.DataSource = bs;
            txbFilterBy.Text = string.Empty;
        }

        private void frmManageInternationalLicenses_Load(object sender, EventArgs e)
        {
            _RefreshDGVList();
            _EditDGVColumns();
            _SetFilterOptions();
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

            FilterText = FilterText.Replace("'", "''"); 


            if (int.TryParse(FilterText, out int value))
                bs.Filter = $"{ColumnToFilter} = {value}";
            else
                bs.Filter = "1 = 0";
              
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

        private void btnClear_Click(object sender, EventArgs e)
        {
            txbFilterBy.Clear();
            txbFilterBy.Focus();
        }

        private void btnAddNewLicense_Click(object sender, EventArgs e)
        {
            frmAddNewInternationalLicense frmANIL = new frmAddNewInternationalLicense();
            frmANIL.MdiParent = this.MdiParent;

            frmANIL.FormClosed += FrmANIL_FormClosed;
            frmANIL.Show();

        }

        private void FrmANIL_FormClosed(object sender, FormClosedEventArgs e)
        {
            _RefreshDGVList();
            _SetFilterOptions();
        }
    }
}
