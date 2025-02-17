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

namespace DVLD.License.International_License
{
    public partial class frmInternationalLicenseDetails : Form
    {
        public frmInternationalLicenseDetails(clsInternationalLicense InternationalLicense = null, int InternationalLicenseID = -1)
        {
            InitializeComponent();
            if (InternationalLicenseID == -1)
                ctrlInternationalLicenseCard1.LoadInfo(InternationalLicense);
            else if (InternationalLicense == null)
                ctrlInternationalLicenseCard1.LoadInfo(InternationalLicenseID);
            else
                MessageBox.Show("License Was Not Found!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
