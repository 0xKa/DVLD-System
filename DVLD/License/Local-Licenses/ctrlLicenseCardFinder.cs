using DVLD.People;
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
    public partial class ctrlLicenseCardFinder : UserControl
    {
        public delegate void LicenseSelectedEventHandler();
        public event LicenseSelectedEventHandler LicenseSelected;

        public ctrlLicenseCardFinder()
        {
            InitializeComponent();
        }

        public bool FinderEnabled
        {
            set { pnlFinder.Enabled = value; }
        }
        public clsLicense SelectedLicense
        {
            get { return ctrlLicenseCard1.License; }
        }
        public bool IsLicenseSelected
        {
            get { return ctrlLicenseCard1.License != null; }
        }

        public void LoadLicenseInfo(int LicenseID)
        {
            FinderEnabled = false;
            ctrlLicenseCard1.LoadInfo(LicenseID);
        }

        private void _Find()
        {
            string Filter = txbSearch.Text.Trim();

            if (int.TryParse(Filter, out int LicenseID))
            {
                if (clsLicense.IsLicenseExist(LicenseID))
                {
                    ctrlLicenseCard1.LoadInfo(LicenseID);
                    LicenseSelected?.Invoke();
                }
                else
                    MessageBox.Show("License ID not Found!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
                MessageBox.Show("License ID Not Valid", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);


        }
        private void btnFind_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txbSearch.Text))
                _Find();
        }

        private void txbFilter_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true; 
                btnFind.PerformClick();
            }
        }
        private void txbFilter_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != (char)Keys.Back)
                e.Handled = true;
        }

        private void ctrlLicenseCardFinder_Load(object sender, EventArgs e)
        {
            txbSearch.Focus();
        }
     
    }
}
