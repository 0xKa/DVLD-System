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

namespace DVLD.Detain_Release_License
{
    public partial class frmManageDetainedLicenses : Form
    {
        public frmManageDetainedLicenses()
        {
            InitializeComponent();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        
        private DataTable _dtDetainedLicensesList = null;
        private void _RefreshDGV()
        {
            _dtDetainedLicensesList = clsDetainedLicense.GetAllDetainedLicenses();
            dgvDetainedLicensesList.DataSource = _dtDetainedLicensesList;
            lblNumberOfRecords.Text = dgvDetainedLicensesList.RowCount.ToString();
        }
        private void _EditDGV()
        {
            if (dgvDetainedLicensesList.RowCount > 0)
            {
                dgvDetainedLicensesList.Columns["ID"].Width = 50;
                dgvDetainedLicensesList.Columns["LicenseID"].Width = 50;
                dgvDetainedLicensesList.Columns["DetainDate"].Width = 100;
                dgvDetainedLicensesList.Columns["DetainDate"].DefaultCellStyle.Format = "dd/MMM/yyyy, hh:mm:ss tt";
                dgvDetainedLicensesList.Columns["FineFees"].Width = 60;
                dgvDetainedLicensesList.Columns["NationalNo"].Width = 60;
                dgvDetainedLicensesList.Columns["IsReleased"].Width = 50;
                dgvDetainedLicensesList.Columns["ReleaseApplicationID"].Width = 80;
                dgvDetainedLicensesList.Columns["ReleasedDate"].Width = 140;
                dgvDetainedLicensesList.Columns["ReleasedDate"].DefaultCellStyle.Format = "dd/MMM/yyyy, hh:mm:ss tt";

            }
            cbSearchOptions.SelectedIndex = 0;
        }
        private void frmManageDetainedLicenses_Load(object sender, EventArgs e)
        {
            _RefreshDGV();
            _EditDGV();
        }

        private void cbSearchOptions_SelectedIndexChanged(object sender, EventArgs e)
        {
            btnClearSearch.PerformClick();

            switch (cbSearchOptions.SelectedItem)
            {
                case "None":
                    txbSearchBy.Visible = false;
                    pnlIsReleased.Visible = false;
                    break;

                case "IsReleased":
                    txbSearchBy.Visible = false;
                    pnlIsReleased.Visible = true;
                    pnlIsReleased.Focus();
                    rbDetained.Checked = false;
                    rbReleased.Checked = false;
                    break;

                default:
                    pnlIsReleased.Visible = false;
                    txbSearchBy.Visible = true;
                    txbSearchBy.Focus();
                    break;
            }

            _dtDetainedLicensesList.DefaultView.RowFilter = string.Empty;
        }
        private void txbSearchBy_TextChanged(object sender, EventArgs e)
        {
            string Search = txbSearchBy.Text.Trim();
            string SearchColumn = cbSearchOptions.SelectedItem.ToString();

            if (Search == string.Empty)
            {
                _dtDetainedLicensesList.DefaultView.RowFilter = string.Empty;
                btnClearSearch.Visible = false;
            }
            else
            {
                btnClearSearch.Visible = true;

                //search logic
                if (SearchColumn.Contains("ID"))
                    _dtDetainedLicensesList.DefaultView.RowFilter = $"{SearchColumn} = {Convert.ToInt32(Search)}";
                else
                    _dtDetainedLicensesList.DefaultView.RowFilter = $"{SearchColumn} LIKE '%{Search}%'";

            }

            lblNumberOfRecords.Text = dgvDetainedLicensesList.RowCount.ToString();
        }
        private void txbSearchBy_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (cbSearchOptions.SelectedItem.ToString().Contains("ID")
                && !char.IsDigit(e.KeyChar) && e.KeyChar != (char)Keys.Back)
                e.Handled = true;
        }
        private void btnClearSearch_Click(object sender, EventArgs e)
        {
            txbSearchBy.Clear();
            txbSearchBy.Focus();
        }
        private void rbDetained_CheckedChanged(object sender, EventArgs e)
        {
            _dtDetainedLicensesList.DefaultView.RowFilter = "[IsReleased] = 0";
        }
        private void rbReleased_CheckedChanged(object sender, EventArgs e)
        {
            _dtDetainedLicensesList.DefaultView.RowFilter = "[IsReleased] = 1";
        }


        private void Refresh_OnFormClosed(object sender, FormClosedEventArgs e)
        {
            _RefreshDGV();
        }
        private void btnDetainLicense_Click(object sender, EventArgs e)
        {
            frmDetainLicense frmDL = new frmDetainLicense();
            frmDL.FormClosed += Refresh_OnFormClosed; ;
            frmDL.ShowDialog();
        }
        private void btnReleaseLicense_Click(object sender, EventArgs e)
        {
            frmReleaseDetainedLicense frmRDL = new frmReleaseDetainedLicense();
            frmRDL.FormClosed += Refresh_OnFormClosed;
            frmRDL.ShowDialog();
        }
    }
}
