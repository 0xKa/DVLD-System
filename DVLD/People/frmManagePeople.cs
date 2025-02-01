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

        private void btnAddPerson_Click(object sender, EventArgs e)
        {
            frmAddEditPerson frmAEP = new frmAddEditPerson();
            frmAEP.ShowDialog();
        }
    }
}
