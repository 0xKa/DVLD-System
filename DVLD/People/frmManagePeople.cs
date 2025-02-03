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

namespace DVLD.People
{
    public partial class frmManagePeople : Form
    {
        public frmManagePeople()
        {
            InitializeComponent();
        }

        private DataTable _dtPeopleList = null;
        private void _RefreshDGV()
        {
            _dtPeopleList = clsPerson.GetAllPeople();
            dgvPeopleList.DataSource = _dtPeopleList;
            lblNumberOfRecords.Text = dgvPeopleList.RowCount.ToString();
        }

        private void _EditDGV()
        {
            dgvPeopleList.Columns["ID"].Width = 50;
            dgvPeopleList.Columns["NationalNo"].Width = 50;
            dgvPeopleList.Columns["Gender"].Width = 50;
            dgvPeopleList.Columns["DateOfBirth"].Width = 50;
            dgvPeopleList.Columns["Nationality"].Width = 90;
            dgvPeopleList.Columns["Phone"].Width = 50;
            dgvPeopleList.Columns["Email"].Width = 150;

            dgvPeopleList.Columns["DateOfBirth"].DefaultCellStyle.Format = "dd/MMM/yyyy";
        }

        private void frmManagePeople_Load(object sender, EventArgs e)
        {
            _RefreshDGV();
            _EditDGV();
            cbSearchOptions.SelectedIndex = 0;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Refresh_WhenFormClosed(object sender, FormClosedEventArgs e)
        {
            _RefreshDGV();
        }

        private void btnAddPerson_Click(object sender, EventArgs e)
        {
            frmAddEditPerson frmAEP = new frmAddEditPerson();
            frmAEP.FormClosed += Refresh_WhenFormClosed;
            frmAEP.ShowDialog();
        }

        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmAddEditPerson frmAEP = new frmAddEditPerson((int)dgvPeopleList.CurrentRow.Cells[0].Value);
            frmAEP.FormClosed += Refresh_WhenFormClosed;
            frmAEP.ShowDialog();
        }

        private void showDetailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmPersonDetails frmPD = new frmPersonDetails((int)dgvPeopleList.CurrentRow.Cells[0].Value);
            frmPD.FormClosed += Refresh_WhenFormClosed;
            frmPD.ShowDialog();
        }
        private void dgvPeopleList_DoubleClick(object sender, EventArgs e)
        {
            showDetailsToolStripMenuItem.PerformClick();
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int PersonID = (int)dgvPeopleList.CurrentRow.Cells[0].Value;

            if (MessageBox.Show($"Are you sure you want to Delete Person {PersonID}?", "Delete Person", MessageBoxButtons.OKCancel, MessageBoxIcon.Information) == DialogResult.OK)
            {
                if (clsPerson.DeletePerson(PersonID))
                    _RefreshDGV();
                else
                    MessageBox.Show($"This Person Cannot be Deleted.", "Delete Person", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void addNewPersonToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmAddEditPerson frmAEP = new frmAddEditPerson();
            frmAEP.FormClosed += Refresh_WhenFormClosed;
            frmAEP.ShowDialog();
        }

        private void sendEmailToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show($"This Feature is not Implemeted Yet.", "...", MessageBoxButtons.OK, MessageBoxIcon.Information);

        }

        private void phoneCallToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show($"This Feature is not Implemeted Yet.", "...", MessageBoxButtons.OK, MessageBoxIcon.Information);

        }

        private void txbSearchBy_TextChanged(object sender, EventArgs e)
        {
            string Search = txbSearchBy.Text.Trim();
            string SearchColumn = cbSearchOptions.SelectedItem.ToString();

            if (Search == string.Empty)
            {
                _dtPeopleList.DefaultView.RowFilter = string.Empty;
                lblNumberOfRecords.Text = dgvPeopleList.RowCount.ToString();
                btnClearSearch.Visible = false;
            }
            else
            {
                btnClearSearch.Visible = true;

                //search logic
                if (SearchColumn == "ID")
                    _dtPeopleList.DefaultView.RowFilter = $"{SearchColumn} = {Convert.ToInt32(Search)}";
                else
                    _dtPeopleList.DefaultView.RowFilter = $"{SearchColumn} LIKE '%{Search}%'";

                lblNumberOfRecords.Text = dgvPeopleList.RowCount.ToString();
            }


        }

        private void cbSearchOptions_SelectedIndexChanged(object sender, EventArgs e)
        {
            btnClearSearch.PerformClick();
            _dtPeopleList.DefaultView.RowFilter = string.Empty; //disable filter

            switch (cbSearchOptions.SelectedItem)
            {

                case "None":
                    txbSearchBy.Visible = false;
                    pnlSelectGender.Visible = false;

                    break;

                case "Gender":
                    txbSearchBy.Visible = false;
                    pnlSelectGender.Visible = true;
                    rbMale.Checked = false;
                    rbFemale.Checked = false;
                    break;
                
                default:
                    txbSearchBy.Visible = true;
                    pnlSelectGender.Visible = false;
                    txbSearchBy.Focus();
                    break;
            }

        }

        private void btnClearSearch_Click(object sender, EventArgs e)
        {
            txbSearchBy.Text = string.Empty;
            txbSearchBy.Focus();
        }

        private void rbMale_CheckedChanged(object sender, EventArgs e)
        {
            _dtPeopleList.DefaultView.RowFilter = $"Gender LIKE 'Male'";
        }

        private void rbFemale_CheckedChanged(object sender, EventArgs e)
        {
            _dtPeopleList.DefaultView.RowFilter = $"Gender LIKE 'Female'";

        }
    }
}
