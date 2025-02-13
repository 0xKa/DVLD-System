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

namespace DVLD.License.Local_Licenses
{
    public partial class frmLicenseDetails : Form
    {
        public frmLicenseDetails(clsLicense License = null, int LicenseID = -1)
        {
            InitializeComponent();
            if (LicenseID == -1 ) 
                ctrlLicenseCard1.LoadInfo(License);
            else if (License == null)
                ctrlLicenseCard1.LoadInfo(LicenseID);
            else
                MessageBox.Show("License Was Not Found!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
