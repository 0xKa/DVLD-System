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
    public partial class frmLDLApplcationDetails : Form
    {
        private int _LDLApplicaitonID = -1;
        public frmLDLApplcationDetails(int LDLApplicaitonID)
        {
            InitializeComponent();
            _LDLApplicaitonID = LDLApplicaitonID;
        }

        private void frmLDLApplcationDetails_Load(object sender, EventArgs e)
        {
            ctrlLDLApplicationInfoCard1.LoadInfo(_LDLApplicaitonID);
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
