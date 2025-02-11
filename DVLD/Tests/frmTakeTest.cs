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
    public partial class frmTakeTest : Form
    {
        public frmTakeTest(clsTestType.enTestType TestType, int LocalLicenseApplicationID, int TestAppointmentID)
        {
            InitializeComponent();
            ctrlTakeTests1.TestType = TestType;
            ctrlTakeTests1.LoadInfo(LocalLicenseApplicationID, TestAppointmentID);
            ctrlTakeTests1.TestConducted += btnClose_Click;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
