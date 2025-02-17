using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLD.People
{
    public partial class frmPersonDetails : Form
    {
        private int _PersonID = -1;
        private string _NationalNo = string.Empty;
        public frmPersonDetails(int PersonID)
        {
            InitializeComponent();
            _PersonID = PersonID;
        }
        public frmPersonDetails(string NationalNo)
        {
            InitializeComponent();
            _NationalNo = NationalNo;
        }

        private void frmPersonDetails_Load(object sender, EventArgs e)
        {
            this.Activated += FrmPersonDetails_GotFocus; //activated is when open the form or Get Back to it
            this.Text = $"Person {_PersonID} Details";
        }

        private void FrmPersonDetails_GotFocus(object sender, EventArgs e)
        {
            if (_PersonID != -1)
                ctrlPersonCard1.LoadPersonInfo(_PersonID);
            else
                ctrlPersonCard1.LoadPersonInfo(_NationalNo);
        }
    }
}
