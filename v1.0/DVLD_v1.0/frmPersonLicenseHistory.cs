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
    public partial class frmPersonLicenseHistory : Form
    {
        int _PersonID = -1;
        public frmPersonLicenseHistory(int PersonID)
        {
            InitializeComponent();
            _PersonID = PersonID;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void _LoadLocalLicenseInfo(int DriverID)
        {
            dgvLocalLicenseList.DataSource = clsLicense.GetLicensesOfADriver(DriverID);
            lblLocalLicenseNumberOfRecords.Text += dgvLocalLicenseList.RowCount.ToString();
        }

        private void _LoadInternationalLicenseInfo(int DriverID)
        {
            dgvInternationalLicenseList.DataSource = clsInternationalLicense.GetInternationalLicensesOfADriver(DriverID);
            lblInternationalLicenseNumberOfRecords.Text += dgvInternationalLicenseList.RowCount.ToString();
        }

        private void frmPersonLicenseHistory_Load(object sender, EventArgs e)
        {
            ctrlPersonCard1.LoadPersonInfo(_PersonID);
            
            int DriverID = clsDriver.FindByPersonID(_PersonID).ID;

            _LoadLocalLicenseInfo(DriverID);
            _LoadInternationalLicenseInfo(DriverID);
        }
    }
}
