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
    public partial class frmRenewDrivingLicense : Form
    {
        public frmRenewDrivingLicense()
        {
            InitializeComponent();
            ctrlLicenseCardWithFilter1.LicenseFound += CtrlLicenseCardWithFilter1_FindButtonClicked;
        }

        private void CtrlLicenseCardWithFilter1_FindButtonClicked()
        {
            MessageBox.Show("Done");
        }

        private void frmRenewDrivingLicense_Load(object sender, EventArgs e)
        {
        }
    }
}
