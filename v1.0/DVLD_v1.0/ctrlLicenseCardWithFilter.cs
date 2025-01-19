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
    public partial class ctrlLicenseCardWithFilter : UserControl
    {
        public ctrlLicenseCardWithFilter()
        {
            InitializeComponent();
        }

        public bool IsCardFilled = false;
        public clsLicense License = null;

        public bool LoadLicenseInfo(int LicenseID)
        {
            groupBox1.Enabled = false;

            ctrlLicenseCard1.LoadInfo(LicenseID);
            this.License = ctrlLicenseCard1.License;

            IsCardFilled = true;

            return IsCardFilled;
        }

        private void ctrlLicenseCardWithFilter_Load(object sender, EventArgs e)
        {
            txbFilter.Focus();
        }
        private void btnFind_Click(object sender, EventArgs e)
        {
            string Filter = txbFilter.Text;
            if (string.IsNullOrWhiteSpace(Filter))
            { return; }

            if (int.TryParse(Filter, out int LicenseID))
            {
                if (clsLicense.IsLicenseExists(LicenseID))
                {
                    ctrlLicenseCard1.LoadInfo(LicenseID);
                    this.License = ctrlLicenseCard1.License;
                    IsCardFilled = true;
                }
                else
                    MessageBox.Show("License ID not Found!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
                MessageBox.Show("License ID Not Valid", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

        }

        private void txbFilter_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true; //silence the bell sound
                btnFind_Click(sender, e);
            }
        }
    }
}
