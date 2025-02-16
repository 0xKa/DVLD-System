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

namespace DVLD.License
{
    public partial class frmLicensesHistory : Form
    {
        clsDriver _Driver = null;
        public frmLicensesHistory(clsDriver driver)
        {
            InitializeComponent();
            this._Driver = driver;
        }
        public frmLicensesHistory(int DriverID)
        {
            InitializeComponent();
            this._Driver = clsDriver.Find(DriverID);
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmLicensesHistory_Load(object sender, EventArgs e)
        {
            lblTitle.Text = $"Driver {_Driver.ID} License History";
            ctrlPersonCard1.LoadPersonInfo(_Driver.PersonID);
            ctrlAllDriverLicenses1.LoadInfo(_Driver);
        }
    }
}
