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
            _SetFilterOptions();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cbFilterOptions_SelectedIndexChanged(object sender, EventArgs e)
        {
            btnClear.Visible = false;
            txbFilterBy.Visible = false;
            cbIsReleasedAnswer.Visible = false;

            switch (cbFilterOptions.SelectedItem)
            {
                case "None":
                    break;

                case "IsReleased":
                    cbIsReleasedAnswer.Visible = true;
                    cbIsReleasedAnswer.SelectedIndex = 0;
                    cbIsReleasedAnswer.Focus();
                    break;

                default:
                    btnClear.Visible = true;
                    txbFilterBy.Visible = true;
                    txbFilterBy.Focus();
                    break;

            }
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
                case "DetainID":
                case "LicenseID":
                case "FineFees":
                case "ReleaseApplicationID":

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

        private void cbIsReleasedAnswer_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (cbIsReleasedAnswer.SelectedIndex)
            {
                case 0:
                    bs.RemoveFilter();
                    break;

                case 1:
                    bs.Filter = "IsReleased = 1";
                    break;

                case 2:
                    bs.Filter = "IsReleased = 0";
                    break;

            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            txbFilterBy.Text = string.Empty;
            txbFilterBy.Focus();
        }

        private void RefreshOnFormClosed(object sender, FormClosedEventArgs e)
        {
            _RefreshDGVList();
            _SetFilterOptions();
        }

        private void btnDetainLicense_Click(object sender, EventArgs e)
        {
            frmDetainLicense frmDL = new frmDetainLicense();
            frmDL.MdiParent = this.MdiParent;

            frmDL.FormClosed += RefreshOnFormClosed;
            frmDL.Show();
        }

        private void btnReleaseLicense_Click(object sender, EventArgs e)
        {
            frmReleaseDetainedLicense frmRDL = new frmReleaseDetainedLicense();
            frmRDL.MdiParent = this.MdiParent;


            frmRDL.FormClosed += RefreshOnFormClosed;
            frmRDL.Show();
        }

        private void showPersonDetailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int PersonID =  clsDriver.Find(clsLicense.Find((int)dgvDetainedLicensesList.CurrentRow.Cells[1].Value).DriverID).PersonID;
            frmPersonDetails frmPD = new frmPersonDetails(PersonID);

            frmPD.MdiParent = this.MdiParent;
            frmPD.FormClosed += RefreshOnFormClosed;
            frmPD.Show();
        }

        private void showLicenseDetailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int LicenseID = (int)dgvDetainedLicensesList.CurrentRow.Cells[1].Value;
            frmLicenseDetails frmLD = new frmLicenseDetails(LicenseID);

            frmLD.MdiParent = this.MdiParent;
            frmLD.FormClosed += RefreshOnFormClosed;
            frmLD.Show();
        }

        private void showPersonsLicenseHistoryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int PersonID = clsDriver.Find(clsLicense.Find((int)dgvDetainedLicensesList.CurrentRow.Cells[1].Value).DriverID).PersonID;
            frmPersonLicenseHistory frmPLH = new frmPersonLicenseHistory(PersonID);
            
            frmPLH.MdiParent = this.MdiParent;
            frmPLH.FormClosed += RefreshOnFormClosed;
            frmPLH.Show();
        }

        private void releaseDetainedLicecnseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmReleaseDetainedLicense frmRDL = new frmReleaseDetainedLicense((int)dgvDetainedLicensesList.CurrentRow.Cells[1].Value);
            frmRDL.MdiParent = this.MdiParent;


            frmRDL.FormClosed += RefreshOnFormClosed;
            frmRDL.Show();
        }
    }
}
