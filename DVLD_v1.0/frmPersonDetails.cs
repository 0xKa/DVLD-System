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
    public partial class frmPersonDetails : Form
    {
        int _PersonID = -1;
        public frmPersonDetails(int PersonID)
        {
            InitializeComponent();
            _PersonID = PersonID;
        }

        private void _LoadPersonDetails()
        {
            clsPerson person = clsPerson.Find(_PersonID);

            if (person != null)
            {
                ctrlPersonCard1.LoadPersonInfo(person);
            }
            else
            {
                MessageBox.Show("Person not found!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();  // Close the form if person data is not found
            }


        }

        private void frmPersonDetails_Load(object sender, EventArgs e)
        {
            _LoadPersonDetails();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
