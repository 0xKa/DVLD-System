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

        private void _RefreshDGV()
        {
            dgvPeopleList.DataSource = clsPerson.GetAllPeople();
            lblNumberOfRecords.Text = "Number of Records: " + dgvPeopleList.RowCount.ToString();
        }

        private void frmManagePeople_Load(object sender, EventArgs e)
        {
            _RefreshDGV();
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
    }
}
