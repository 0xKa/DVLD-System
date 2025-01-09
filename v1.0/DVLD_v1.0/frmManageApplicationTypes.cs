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
    public partial class frmManageApplicationTypes : Form
    {
        public frmManageApplicationTypes()
        {
            InitializeComponent();
        }

        private void _RefreshDgvList()
        {
            dgvApplicationTypes.DataSource = clsApplicationType.GetAllApplicationTypes();
            lblNumberOfRecords.Text = "Number of Records: " + dgvApplicationTypes.RowCount.ToString();
        }

        private void _EditListColumns()
        {
            dgvApplicationTypes.Columns["ApplicationTypeID"].Width = 110;
            dgvApplicationTypes.Columns["ApplicationFees"].Width = 110;
        }


        private void frmManageApplicationTypes_Load(object sender, EventArgs e)
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
            frmUpdateApplicationType frmUpdateApplicationType = new frmUpdateApplicationType((int)dgvApplicationTypes.CurrentRow.Cells[0].Value);
            frmUpdateApplicationType.MdiParent = this.MdiParent;

            frmUpdateApplicationType.FormClosed += FrmUpdateApplicationType_FormClosed;
            frmUpdateApplicationType.Show();
        }

        private void FrmUpdateApplicationType_FormClosed(object sender, FormClosedEventArgs e)
        {
            _RefreshDgvList();
        }

        private void dgvApplicationTypes_DoubleClick(object sender, EventArgs e)
        {
            editToolStripMenuItem_Click(sender, e );
        }
    }
}
