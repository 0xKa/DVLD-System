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

namespace DVLD.Application.ApplicationTypes
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
            if (dgvApplicationTypes.RowCount > 0)
            {

                dgvApplicationTypes.Columns["ID"].Width = 110;
                dgvApplicationTypes.Columns["Fees"].Width = 110;
            }
        }


        private void frmManageApplicationTypes_Load(object sender, EventArgs e)
        {
            _RefreshDgvList();
            _EditListColumns();
        }

        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmEditApplicationType frmEAT = new frmEditApplicationType((int)dgvApplicationTypes.CurrentRow.Cells[0].Value);
            frmEAT.ShowDialog();
            _RefreshDgvList();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dgvApplicationTypes_DoubleClick(object sender, EventArgs e)
        {
            editToolStripMenuItem.PerformClick();
        }
    }
}
