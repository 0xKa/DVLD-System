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

namespace DVLD.License.International_License
{
    public partial class frmManageInternationalLicenses : Form
    {
        public frmManageInternationalLicenses()
        {
            InitializeComponent();
        }

        private DataTable _dtInternationalLicensesList = null;
        private void _RefreshDGV()
        {
            _dtInternationalLicensesList = clsInternationalLicense.GetAllInternationalLicenses();
            dgvInternationalLicenses.DataSource = _dtInternationalLicensesList;
            lblNumberOfRecords.Text = dgvInternationalLicenses.RowCount.ToString();
        }
        private void _EditDGV()
        {
            if (dgvInternationalLicenses.RowCount > 0)
            {
                dgvInternationalLicenses.Columns["ID"].Width = 25;
                dgvInternationalLicenses.Columns["ApplicationID"].Width = 70;
                dgvInternationalLicenses.Columns["DriverID"].Width = 55;
                dgvInternationalLicenses.Columns["LocalLicenseID"].Width = 85;
                dgvInternationalLicenses.Columns["Active Status"].Width = 80;
                dgvInternationalLicenses.Columns["IssueDate"].DefaultCellStyle.Format = "dd/MMM/yyyy, hh:mm:ss tt";
                dgvInternationalLicenses.Columns["ExpirationDate"].DefaultCellStyle.Format = "dd/MMM/yyyy, hh:mm:ss tt";

            }
            cbSearchOptions.SelectedIndex = 0;
        }
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmManageInternationalLicenses_Load(object sender, EventArgs e)
        {
            _RefreshDGV();
            _EditDGV();
        }

        private void btnClearSearch_Click(object sender, EventArgs e)
        {
            txbSearch.Clear();
            txbSearch.Focus();
        }
        private void cbSearchOptions_SelectedIndexChanged(object sender, EventArgs e)
        {
            btnClearSearch.PerformClick();

            switch (cbSearchOptions.SelectedItem)
            {
                case "None":
                    txbSearch.Visible = false;
                    pnlSelectStatus.Visible = false;
                    break;

                case "Active Status":
                    txbSearch.Visible = false;
                    pnlSelectStatus.Visible = true;
                    pnlSelectStatus.Focus();
                    rbActive.Checked = false;
                    rbInactive.Checked = false;
                    break;

                default:
                    pnlSelectStatus.Visible = false;
                    txbSearch.Visible = true;
                    txbSearch.Focus();
                    break;
            }

            _dtInternationalLicensesList.DefaultView.RowFilter = string.Empty;
        }
        private void txbSearch_TextChanged(object sender, EventArgs e)
        {
            string Search = txbSearch.Text.Trim();
            string SearchColumn = cbSearchOptions.SelectedItem.ToString();

            if (Search == string.Empty)
            {
                _dtInternationalLicensesList.DefaultView.RowFilter = string.Empty;
                btnClearSearch.Visible = false;
            }
            else
            {
                btnClearSearch.Visible = true;

                //search logic
                if (SearchColumn.Contains("ID"))
                    _dtInternationalLicensesList.DefaultView.RowFilter = $"{SearchColumn} = {Convert.ToInt32(Search)}";
                else
                    _dtInternationalLicensesList.DefaultView.RowFilter = $"{SearchColumn} LIKE '%{Search}%'";

            }

            lblNumberOfRecords.Text = dgvInternationalLicenses.RowCount.ToString();
        }
        private void txbSearch_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (cbSearchOptions.SelectedIndex.ToString().Contains("ID")
                && !char.IsDigit(e.KeyChar) && e.KeyChar != (char)Keys.Back)
                e.Handled = true;
        }
        private void rbActive_CheckedChanged(object sender, EventArgs e)
        {
            _dtInternationalLicensesList.DefaultView.RowFilter = "[Active Status] = 1 ";
        }
        private void rbInactive_CheckedChanged(object sender, EventArgs e)
        {
            _dtInternationalLicensesList.DefaultView.RowFilter = "[Active Status] = 0 ";
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            frmAddNewInternationalLicense frmANIL = new frmAddNewInternationalLicense();
            frmANIL.FormClosed += Refresh_OnFormClosed;
            frmANIL.ShowDialog();
        }

        private void Refresh_OnFormClosed(object sender, FormClosedEventArgs e)
        {
            _RefreshDGV();
        }
        private void showPersonalInfoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmPersonDetails frmPD = new frmPersonDetails(clsDriver.Find((int)dgvInternationalLicenses.CurrentRow.Cells[2].Value).PersonID);
            frmPD.FormClosed += Refresh_OnFormClosed;
            frmPD.ShowDialog();
        }
        private void showLicenseInfoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmInternationalLicenseDetails frmILD = new frmInternationalLicenseDetails(null ,(int)dgvInternationalLicenses.CurrentRow.Cells[0].Value);
            frmILD.ShowDialog();
        }
        private void showLicensesHistoryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmLicensesHistory frmLH = new frmLicensesHistory(clsDriver.Find((int)dgvInternationalLicenses.CurrentRow.Cells[2].Value));
            frmLH.FormClosed += Refresh_OnFormClosed;
            frmLH.ShowDialog();
        }
    }
}
