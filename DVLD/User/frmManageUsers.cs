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

namespace DVLD.User
{
    public partial class frmManageUsers : Form
    {
        public frmManageUsers()
        {
            InitializeComponent();
        }

        private DataTable _dtUsersList = null;
        private void _RefreshDGV()
        {
            _dtUsersList = clsUser.GetAllUsers();
            dgvUsersList.DataSource = _dtUsersList;
            lblNumberOfRecords.Text = dgvUsersList.RowCount.ToString();
        }

        private void _EditDGV()
        {
            dgvUsersList.Columns["ID"].Width = 50;
            dgvUsersList.Columns["PersonID"].Width = 50;
            dgvUsersList.Columns["Username"].Width = 50;
            dgvUsersList.Columns["Active Status"].Width = 100;

            cbSearchOptions.SelectedIndex = 0;
        }

        private void frmManageUsers_Load(object sender, EventArgs e)
        {
            _RefreshDGV();
            _EditDGV();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
       
        private void Refresh_WhenFormClosed(object sender, FormClosedEventArgs e)
        {
            _RefreshDGV();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            MessageBox.Show("...");
        }

        private void cbSearchOptions_SelectedIndexChanged(object sender, EventArgs e)
        {
            btnClearSearch.PerformClick();

            switch (cbSearchOptions.SelectedItem)
            {
                case "None":
                    txbSearchBy.Visible = false;
                    pnlSelectStatus.Visible = false;
                    break;
                    
                case "Active Status":
                    txbSearchBy.Visible = false;
                    pnlSelectStatus.Visible = true;
                    pnlSelectStatus.Focus();
                    rbActive.Checked = false;
                    rbInactive.Checked = false;
                    break;

                default:
                    pnlSelectStatus.Visible = false;
                    txbSearchBy.Visible = true;
                    txbSearchBy.Focus();
                    break;

            }
        }

        private void txbSearchBy_TextChanged(object sender, EventArgs e)
        {
            string Search = txbSearchBy.Text.Trim();
            string SearchColumn = cbSearchOptions.SelectedItem.ToString();

            if (Search == string.Empty)
            {
                _dtUsersList.DefaultView.RowFilter = null;
                lblNumberOfRecords.Text = dgvUsersList.RowCount.ToString();
                btnClearSearch.Visible = false;
            }
            else
            {
                btnClearSearch.Visible = true;

                if (SearchColumn == "ID")
                    _dtUsersList.DefaultView.RowFilter = $"{SearchColumn} = {Convert.ToInt32(Search)}";
                else
                    _dtUsersList.DefaultView.RowFilter = $"{SearchColumn} LIKE '%{Search}%'";

                lblNumberOfRecords.Text = dgvUsersList.RowCount.ToString();

            }

        }
        private void txbSearchBy_KeyPress(object sender, KeyPressEventArgs e)
        {

        }

        private void rbActive_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void rbInactive_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void btnClearSearch_Click(object sender, EventArgs e)
        {
            txbSearchBy.Clear();
            txbSearchBy.Focus();
            _dtUsersList.DefaultView.RowFilter = string.Empty; 
        }
    }
}
