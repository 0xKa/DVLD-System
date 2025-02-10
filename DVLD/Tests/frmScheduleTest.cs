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

namespace DVLD.Tests
{
    public partial class frmScheduleTest : Form
    {
        public frmScheduleTest(clsTestType.enTestType TestType, int LocalLicenseApplicationID, int AppointmentID = -1)
        {
            InitializeComponent();
            ctrlScheduleTests1.LoadInfo(LocalLicenseApplicationID, AppointmentID);
        }

        private void frmScheduleTest_Load(object sender, EventArgs e)
        {
            
        }
    }
}
