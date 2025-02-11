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
        public frmScheduleTest(clsTestType.enTestType TestType, int LocalLicenseApplicationID, int AppointmentID = -1, bool IsLocked = false)
        {
            InitializeComponent();
            ctrlScheduleTests1.TestType = TestType;
            ctrlScheduleTests1.LoadInfo(LocalLicenseApplicationID, AppointmentID);
            if (IsLocked)
                ctrlScheduleTests1.LockTheAppointmentSave();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
