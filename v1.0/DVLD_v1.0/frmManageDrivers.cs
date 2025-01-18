using DVLD_BusinessLayer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLD_v1._0
{
    public partial class frmManageDrivers : Form
    {
        public frmManageDrivers()
        {
            InitializeComponent();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void _RefreshDGVList()
        {
            dgvDriversList.DataSource = clsDriver.GetDriversView();
            lblNumberOfRecords.Text = "Number Of Records: " + dgvDriversList.RowCount.ToString();
        }
        private void _FormatColumns()
        {
            dgvDriversList.Columns["DriverID"].Width = 60;
            dgvDriversList.Columns["PersonID"].Width = 60;
            dgvDriversList.Columns["NationalNo"].Width = 80;
            dgvDriversList.Columns["CreatedDate"].Width = 120;
            dgvDriversList.Columns["CreatedDate"].DefaultCellStyle.Format = "dd/MMM/yyyy [HH:mm:ss tt]";
            dgvDriversList.Columns["ActiveLicenses"].Width = 90;

        }

        private BindingSource bs = new BindingSource();
        private void _SetFilterOptions()
        {
            cbFilterOptions.SelectedIndex = 0;
            bs.DataSource = dgvDriversList.DataSource;
            dgvDriversList.DataSource = bs;
            txbFilterBy.Text = string.Empty;
        }

        private void frmManageDrivers_Load(object sender, EventArgs e)
        {
            _RefreshDGVList();
            _FormatColumns();
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

            FilterText = FilterText.Replace("'", "''"); // Handle single quotes to avoid SQL errors


            switch (ColumnToFilter)
            {
                case "DriverID":
                case "PersonID":
                case "ActiveLicenses":
                    if (int.TryParse(FilterText, out int value))
                        bs.Filter = $"{ColumnToFilter} = {value}";
                    else
                        bs.Filter = "1 = 0";
                    break;
                default:
                    bs.Filter = $"{ColumnToFilter} LIKE '%{FilterText}%'";
                    break;
            
            }
            
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

        private void showDetailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmPersonDetails frmPD = new frmPersonDetails((int)dgvDriversList.CurrentRow.Cells[1].Value);
            frmPD.MdiParent = this.MdiParent;

            frmPD.FormClosed += FrmPD_FormClosed;
            frmPD.Show();

        }

        private void FrmPD_FormClosed(object sender, FormClosedEventArgs e)
        {
            _RefreshDGVList();
        }

        private void sendEmailToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("This Feature is not Implemented Yet.", "Sending Email...", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        private void phoneCallToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("This Feature is not Implemented Yet.", "Phone Calling...", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

    }
}
