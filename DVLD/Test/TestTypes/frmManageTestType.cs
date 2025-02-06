using DVLD.Test.TestTypes;
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

namespace DVLD.Test
{
    public partial class frmManageTestType : Form
    {
        public frmManageTestType()
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
            if (dgvTestTypes.RowCount > 0)
            {
                dgvTestTypes.Columns["ID"].Width = 70;
                dgvTestTypes.Columns["Title"].Width = 70;
                dgvTestTypes.Columns["Fees"].Width = 70;
            }

        }


        private void frmManageTestType_Load(object sender, EventArgs e)
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
            frmEditTestType frmETT  = new frmEditTestType((int)dgvTestTypes.CurrentRow.Cells[0].Value);
            frmETT.ShowDialog();

            _RefreshDgvList();  
        }

        private void dgvTestTypes_DoubleClick(object sender, EventArgs e)
        {
            editToolStripMenuItem.PerformClick();
        }
    }
}
