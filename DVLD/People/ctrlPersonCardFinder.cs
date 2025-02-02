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

namespace DVLD.People
{
    public partial class ctrlPersonCardFinder : UserControl
    {
        public ctrlPersonCardFinder()
        {
            InitializeComponent();
        }

        public bool EnableFinder
        {
            set { pnlFinder.Enabled = value; }
        }
        public bool EnableAddPersonButton
        {
            set { btnAddPerson.Enabled = value; }
        }
        public clsPerson SelectedPerson
        {
            get { return ctrlPersonCard1.SelectedPerson; }
        }

        private void ctrlPersonCardFinder_Load(object sender, EventArgs e)
        {
            cbFindBy.SelectedIndex = 1;
            txbFindBy.Focus();
        }

        public void LoadPersonInfo(int PersonID)
        {
            pnlFinder.Enabled = false;
            ctrlPersonCard1.LoadPersonInfo(PersonID);
        }

        private void _Find()
        {
            string Filter = txbFindBy.Text;

            switch (cbFindBy.SelectedItem)
            {
                case "NationalNo":
                    
                    if (clsPerson.IsPersonExist(Filter))
                        ctrlPersonCard1.LoadPersonInfo(Filter);
                    else
                        MessageBox.Show("National Number not Found!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    break;

                case "PersonID":

                    if (int.TryParse(Filter, out int id) && clsPerson.IsPersonExist(id))
                        ctrlPersonCard1.LoadPersonInfo(id);
                    else
                        MessageBox.Show("Person ID Not Valid/Found", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);


                    break;
            }

        }
        private void btnFind_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txbFindBy.Text))
                _Find();

        }

        private void btnAddPerson_Click(object sender, EventArgs e)
        {
            frmAddEditPerson frmAEP = new frmAddEditPerson();
            frmAEP.NewPersonAdded += FrmAEP_NewPersonAdded;
            frmAEP.ShowDialog();
        }

        private void FrmAEP_NewPersonAdded(int AddedPersonID)
        {
            ctrlPersonCard1.LoadPersonInfo(AddedPersonID);
        }

        private void txbFindBy_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true; //cancel the key action (make it like 'Enter' wasn't pressed)
                btnFind.PerformClick();
            }
        }
    }
}
