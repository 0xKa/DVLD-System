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
    public partial class frmManageUsers : Form
    {
        public frmManageUsers()
        {
            InitializeComponent();
        }

        private void _RefreshUsersList()
        {
            dgvUsersList.DataSource = clsUser.GetPublicUsersList();
            lblNumberOfRecords.Text = "Number of Records: " + dgvUsersList.RowCount;
        }

        private void _EditListColumns()
        {
            dgvUsersList.Columns["UserID"].Width = 60;
            dgvUsersList.Columns["PersonID"].Width = 60;
            dgvUsersList.Columns["Username"].Width = 100;
            dgvUsersList.Columns["IsActive"].Width = 60;
        }

        private BindingSource bs = new BindingSource();
        private void _SetFilterOptions()
        {

            cbFilterOptions.SelectedIndex = 0;
            bs.DataSource = dgvUsersList.DataSource;
            dgvUsersList.DataSource = bs;
        }

        private void frmManageUsers_Load(object sender, EventArgs e)
        {
            _RefreshUsersList();
            _EditListColumns();
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
            cbIsActiveAnswer.Visible = false;

            switch (cbFilterOptions.SelectedItem)
            {
                case "None":
                    break;
                    
                case "Activity":
                    cbIsActiveAnswer.Visible = true;
                    cbIsActiveAnswer.SelectedIndex = 0;
                    cbIsActiveAnswer.Focus();
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
                case "UserID":
                case "PersonID":

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

        private void cbIsActiveAnswer_SelectedIndexChanged(object sender, EventArgs e)
        {

            switch (cbIsActiveAnswer.SelectedIndex)
            {
                case 0:
                    bs.RemoveFilter();
                    break;

                case 1:
                    bs.Filter = "IsActive = 1";
                    break;
                    
                case 2:
                    bs.Filter = "IsActive = 0";
                    break;

            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            txbFilterBy.Text = string.Empty;
            txbFilterBy.Focus();
        }

        public void On_frmAddEditUser_Closed(object sender, FormClosedEventArgs e)
        {
            _RefreshUsersList();
            _SetFilterOptions();
        }
        private void btnAddUser_Click(object sender, EventArgs e)
        {
            frmAddEditUsers addEditForm = new frmAddEditUsers(-1);
            addEditForm.MdiParent = this.MdiParent;

            addEditForm.FormClosed += On_frmAddEditUser_Closed;
            addEditForm.Show();
        }

        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmAddEditUsers addEditForm = new frmAddEditUsers((int) dgvUsersList.CurrentRow.Cells[0].Value);
            addEditForm.MdiParent = this.MdiParent;

            addEditForm.FormClosed += On_frmAddEditUser_Closed;
            addEditForm.Show();
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to delete user [" + dgvUsersList.CurrentRow.Cells[0].Value + "]", "Confirm Delete", MessageBoxButtons.OKCancel, MessageBoxIcon.Information) == DialogResult.OK)
            {
                if (clsUser.DeleteUser((int)dgvUsersList.CurrentRow.Cells[0].Value))
                {
                    MessageBox.Show("User Deleted Successfully.", "Done");
                    _RefreshUsersList();
                    _SetFilterOptions();
                }
                else
                    MessageBox.Show("Operation Canceled.\nThis User Can't be Deleted. it has Data Linked to it.", "Canceled !", MessageBoxButtons.OK, MessageBoxIcon.Stop);


            }
        }

        private void addNewUserToolStripMenuItem_Click(object sender, EventArgs e)
        {
            btnAddUser_Click(sender, e);
        }

        private void showDetailToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmUserDetails frmUserDetails = new frmUserDetails((int)dgvUsersList.CurrentRow.Cells[0].Value);
            frmUserDetails.MdiParent = this.MdiParent;

            frmUserDetails.FormClosed += On_frmAddEditUser_Closed;
            frmUserDetails.Show();
        
        }

        private void changePasswordToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmChangePassword frmChangePassword = new frmChangePassword((int)dgvUsersList.CurrentRow.Cells[0].Value);
            frmChangePassword.MdiParent = this.MdiParent;

            frmChangePassword.FormClosed += On_frmAddEditUser_Closed;
            frmChangePassword.Show();
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
