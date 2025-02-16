using DVLD.License;
using DVLD.People;
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

namespace DVLD.Driver
{
    public partial class frmManageDrivers : Form
    {
        public frmManageDrivers()
        {
            InitializeComponent();
        }

        private DataTable _dtAllDrivers = null;
        private void _RefreshDGV()
        {
            _dtAllDrivers = clsDriver.GetAllDrivers();
            dgvDriversList.DataSource = _dtAllDrivers;
            lblNumberOfRecords.Text = dgvDriversList.RowCount.ToString();
        }
        private void _EditDGV()
        {
            if (dgvDriversList.RowCount > 0)
            {
                dgvDriversList.Columns["ID"].Width = 50;
                dgvDriversList.Columns["PersonID"].Width = 50;
                dgvDriversList.Columns["NationalNo"].Width = 60;
                dgvDriversList.Columns["CreatedDate"].Width = 100;
                dgvDriversList.Columns["CreatedDate"].DefaultCellStyle.Format = "dd/MM/yyyy hh:mm:ss tt";
                dgvDriversList.Columns["ActiveLicenses"].Width = 90;
            }

            cbSearchOptions.SelectedIndex = 0;
        }
        private void frmManageDrivers_Load(object sender, EventArgs e)
        {
            _RefreshDGV();
            _EditDGV();
        }
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cbSearchOptions_SelectedIndexChanged(object sender, EventArgs e)
        {
            btnClearSearch.PerformClick();

            switch (cbSearchOptions.SelectedItem)
            {
                case "None":
                    txbSearch.Visible = false;
                    break;

                default:
                    txbSearch.Visible = true;
                    txbSearch.Focus();
                    break;
            }

            _dtAllDrivers.DefaultView.RowFilter = string.Empty;
        }
        private void txbSearch_TextChanged(object sender, EventArgs e)
        {
            string Search = txbSearch.Text.Trim();
            string SearchColumn = cbSearchOptions.SelectedItem.ToString();

            if (Search == string.Empty)
            {
                _dtAllDrivers.DefaultView.RowFilter = string.Empty;
                btnClearSearch.Visible = false;
            }
            else
            {
                btnClearSearch.Visible = true;

                //search logic
                if (SearchColumn == "ActiveLicenses" || SearchColumn.Contains("ID"))
                    _dtAllDrivers.DefaultView.RowFilter = $"{SearchColumn} = {Convert.ToInt32(Search)}";
                else
                    _dtAllDrivers.DefaultView.RowFilter = $"{SearchColumn} LIKE '%{Search}%'";

            }

            lblNumberOfRecords.Text = dgvDriversList.RowCount.ToString();
        }
        private void txbSearch_KeyPress(object sender, KeyPressEventArgs e)
        {
            string SearchColumn = cbSearchOptions.SelectedItem.ToString();

            if ( (SearchColumn == "ActiveLicenses" || SearchColumn.Contains("ID") )
                            && !char.IsDigit(e.KeyChar) && e.KeyChar != (char)Keys.Back)
                e.Handled = true;
        }
        private void btnClearSearch_Click(object sender, EventArgs e)
        {
            txbSearch.Clear();
            txbSearch.Focus();
        }


        private void Refresh_OnFormClosed(object sender, FormClosedEventArgs e)
        {
            _RefreshDGV();
        }
        private void dgvDriversList_DoubleClick(object sender, EventArgs e)
        {
            showLicensesHistoryToolStripMenuItem.PerformClick();
        }
        private void showPersonalInfoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmPersonDetails frmPD = new frmPersonDetails((int)dgvDriversList.CurrentRow.Cells[1].Value);
            frmPD.FormClosed += Refresh_OnFormClosed;
            frmPD.ShowDialog();
        }
        private void issueInternationalLicenseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //koko
        }
        private void showLicensesHistoryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmLicensesHistory frmLH = new frmLicensesHistory((int)dgvDriversList.CurrentRow.Cells[0].Value);
            frmLH.FormClosed += Refresh_OnFormClosed;
            frmLH.ShowDialog();

        }
    }
}
