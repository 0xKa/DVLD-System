using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLD.Application.LocalLicenseApplication
{
    public partial class frmLocalLicenseApplicationDetails : Form
    {
        int _LLApplicationID = -1;
        public frmLocalLicenseApplicationDetails(int LLApplicationID)
        {
            InitializeComponent();
            _LLApplicationID = LLApplicationID;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmLocalLicenseApplicationDetails_Load(object sender, EventArgs e)
        {
            this.Activated += FrmLocalLicenseApplicationDetails_Activated; ;
            this.Text = $"Local License Application No. {_LLApplicationID} Details";
        }

        private void FrmLocalLicenseApplicationDetails_Activated(object sender, EventArgs e)
        {
            ctrlLocalLicenseApplicationCard1.LoadApplicationInfo(_LLApplicationID);
        }
    }
}
