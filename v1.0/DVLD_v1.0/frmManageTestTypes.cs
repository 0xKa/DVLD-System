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
    public partial class frmManageTestTypes : Form
    {
        public frmManageTestTypes()
        {
            InitializeComponent();
        }

        private void _RefreshDgvList()
        {
            dgvTestTypes.DataSource = clsTestType.GetAllTestTypes();
            lblNumberOfRecords.Text = "Number of Records: " + dgvTestTypes.RowCount.ToString();
        }

        private void _EditListColumns()
        {
            dgvTestTypes.Columns["TestTypeID"].Width = 80;
            dgvTestTypes.Columns["TestTypeFees"].Width = 80;
            dgvTestTypes.Columns["TestTypeTitle"].Width = 120;
        }

        private void frmManageTestTypes_Load(object sender, EventArgs e)
        {
            _RefreshDgvList();
            _EditListColumns();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmUpdateTestType frmUpdateTestType = new frmUpdateTestType((int)dgvTestTypes.CurrentRow.Cells[0].Value);
            frmUpdateTestType.MdiParent = this.MdiParent;

            frmUpdateTestType.FormClosed += FrmUpdateTestType_FormClosed;
            frmUpdateTestType.Show();

        }

        private void FrmUpdateTestType_FormClosed(object sender, FormClosedEventArgs e)
        {
            _RefreshDgvList();
        }

        private void dgvTestTypes_DoubleClick(object sender, EventArgs e)
        {
            editToolStripMenuItem_Click(sender, e);
        }
    }
}
