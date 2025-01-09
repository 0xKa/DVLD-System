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
    public partial class frmManagePeople : Form
    {
        public frmManagePeople()
        {
            InitializeComponent();
        }

        private void _RefreshPeopleList()
        {
            dgvPeopleList.DataSource = clsPerson.GetAllPeople();
            lblNumberOfRecords.Text = "Number of Records: " + dgvPeopleList.RowCount.ToString();

        }

        private void _EditListColumns()
        {
            dgvPeopleList.Columns["ImagePath"].Visible = false;
            dgvPeopleList.Columns["DateOfBirth"].DefaultCellStyle.Format = "yyyy/MMM/dd";
        }

        private BindingSource bs = new BindingSource();
        private void _SetFilterOptions()
        {

            cbFilterOptions.SelectedIndex = 0;
            bs.DataSource = dgvPeopleList.DataSource;
            dgvPeopleList.DataSource = bs;
        }

        private void frmManagePeople_Load(object sender, EventArgs e)
        {
            _RefreshPeopleList();
            _EditListColumns();
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

            if (ColumnToFilter == "PersonID" || ColumnToFilter == "NationalityCountryID" || ColumnToFilter == "Gender")
            {
                //handling inteager columns
                if (int.TryParse(FilterText, out int value))
                    bs.Filter = $"{ColumnToFilter} = {value}";
                else
                    bs.Filter = "1 = 0";
            }
            else //string columns
                bs.Filter = $"{ColumnToFilter} LIKE '%{FilterText}%'";


        }

        private void cbFilterOptions_SelectedIndexChanged(object sender, EventArgs e)
        {
            txbFilterBy.Focus(); // Set focus to textBox1 after a selection is made in comboBox1
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            txbFilterBy.Text = string.Empty;
            txbFilterBy.Focus();
        }

        private void dgvPeopleList_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            // Check if the column being formatted is the Gender column
            if (dgvPeopleList.Columns[e.ColumnIndex].Name == "Gender")
            {
                e.Value = (byte)e.Value == 0 ? "Male" : "Female";
                e.FormattingApplied = true;
            }

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        public void On_frmAddEditPeople_Closed(object sender, FormClosedEventArgs e)
        {
            // Refresh the list and filters once the add/edit form closes
            _RefreshPeopleList();
            _SetFilterOptions();
        }
        private void btnAddPerson_Click(object sender, EventArgs e)
        {
            frmAddEditPeople addEditForm = new frmAddEditPeople(-1); //-1 for New Person
            addEditForm.MdiParent = this.MdiParent; // This gets the parent form (frmMain)

            // Subscribe to the FormClosed event
            addEditForm.FormClosed += new FormClosedEventHandler(On_frmAddEditPeople_Closed);
            addEditForm.Show();

        }

        public void editToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int PersonToEdit = (int)dgvPeopleList.CurrentRow.Cells[0].Value; //get the PersonID

            frmAddEditPeople addEditForm = new frmAddEditPeople(PersonToEdit);
            addEditForm.MdiParent = this.MdiParent;

            // Subscribe to the FormClosed event
            addEditForm.FormClosed += new FormClosedEventHandler(On_frmAddEditPeople_Closed);
            addEditForm.Show();
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to delete person [" + dgvPeopleList.CurrentRow.Cells[0].Value + "]", "Confirm Delete", MessageBoxButtons.OKCancel, MessageBoxIcon.Information) == DialogResult.OK)
            {
                if (clsPerson.DeletePerson((int)dgvPeopleList.CurrentRow.Cells[0].Value))
                {
                    MessageBox.Show("Person Deleted Successfully.", "Done");
                    _RefreshPeopleList();
                    _SetFilterOptions();
                }
                else
                    MessageBox.Show("Operation Canceled.\nThis Person Can't be Deleted. it has Data Linked to it.", "Canceled !", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
        }
        private void addNewPersonToolStripMenuItem_Click(object sender, EventArgs e)
        {
            btnAddPerson_Click(sender, e); //click the add person button
        }

        private void showDetailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int PersonToView = (int)dgvPeopleList.CurrentRow.Cells[0].Value;

            frmPersonDetails personDetailsForm = new frmPersonDetails(PersonToView);
            personDetailsForm.MdiParent = this.MdiParent;

            personDetailsForm.FormClosed += On_frmAddEditPeople_Closed;
            personDetailsForm.Show();

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
