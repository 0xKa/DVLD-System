﻿using DVLD_BusinessLogicLayer;
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

        private DataTable _dtAllUsers = null;
        private void _RefreshDGV()
        {
            _dtAllUsers = clsUser.GetAllUsers();
            dgvUsersList.DataSource = _dtAllUsers;
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
         
            _dtAllUsers.DefaultView.RowFilter = string.Empty;
        }

        private void txbSearch_TextChanged(object sender, EventArgs e)
        {
            string Search = txbSearch.Text.Trim();
            string SearchColumn = cbSearchOptions.SelectedItem.ToString();

            if (Search == string.Empty)
            {
                _dtAllUsers.DefaultView.RowFilter = string.Empty;
                btnClearSearch.Visible = false;
            }
            else
            {
                btnClearSearch.Visible = true;

                //search logic
                if (SearchColumn.Contains("ID"))
                    _dtAllUsers.DefaultView.RowFilter = $"{SearchColumn} = {Convert.ToInt32(Search)}";
                else
                    _dtAllUsers.DefaultView.RowFilter = $"{SearchColumn} LIKE '%{Search}%'";

            }

            lblNumberOfRecords.Text = dgvUsersList.RowCount.ToString();
        }

        private void txbSearchBy_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((cbSearchOptions.SelectedIndex == 1 || cbSearchOptions.SelectedIndex == 2)
                && !char.IsDigit(e.KeyChar) && e.KeyChar != (char)Keys.Back)
                e.Handled = true;
        }

        private void rbActive_CheckedChanged(object sender, EventArgs e)
        {
            _dtAllUsers.DefaultView.RowFilter = "[Active Status] = 1 ";
        }
        private void rbInactive_CheckedChanged(object sender, EventArgs e)
        {
            _dtAllUsers.DefaultView.RowFilter = "[Active Status] = 0 ";
        }

        private void btnClearSearch_Click(object sender, EventArgs e)
        {
            txbSearch.Clear();
            txbSearch.Focus();
        }

       
    }
}
