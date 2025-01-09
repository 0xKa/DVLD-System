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
    public partial class ctrlPersonCardWithFilter : UserControl
    {
        public ctrlPersonCardWithFilter()
        {
            InitializeComponent();
        }
        public bool IsCardFilled = false;
        public int PersonID = -1;

        public bool LoadPersonInfo(int PersonID)
        {
            groupBox1.Enabled = false;
            this.PersonID = PersonID;
            
            if (ctrlPersonCard1.LoadPersonInfo(PersonID))
                IsCardFilled = true;
            
            return IsCardFilled;
        }

        private void ctrlPersonCardWithFilter_Load(object sender, EventArgs e)
        {
           
            cbFilter.SelectedIndex = 1;
            txbFilter.Focus();
        }

        private void btnFind_Click(object sender, EventArgs e)
        {
            string Filter = txbFilter.Text;
            if (string.IsNullOrWhiteSpace(Filter))
            { return; }


            switch (cbFilter.SelectedItem)
            {
                case "PersonID":
                    if (int.TryParse(Filter, out int PersonID))
                    {
                        if (clsPerson.IsPersonExist(PersonID))
                        {
                            ctrlPersonCard1.LoadPersonInfo(PersonID);
                            IsCardFilled = true;
                        }
                        else
                            MessageBox.Show("Person ID not Found!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                        MessageBox.Show("Person ID Not Valid", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    break;

                case "NationalNo":
                    if (clsPerson.IsPersonExist(Filter))
                    {
                        ctrlPersonCard1.LoadPersonInfo(Filter);
                        IsCardFilled = true;
                    }
                    else
                        MessageBox.Show("National Number not Found!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    break;
            }

            PersonID = ctrlPersonCard1._PersonID;
        }

        private void btnAddPerson_Click(object sender, EventArgs e)
        {
            Form CurrentForm = this.FindForm();

            frmAddEditPeople addNewPerson = new frmAddEditPeople(-1);
            addNewPerson.MdiParent = CurrentForm.MdiParent;

            //addNewPerson.SendPersonIDBack();
            addNewPerson.DataBack += AddNewPerson_DataBack;
            addNewPerson.Show();

        }

        private void AddNewPerson_DataBack(object sender, int PersonID)
        {
            ctrlPersonCard1.LoadPersonInfo(PersonID);
            IsCardFilled = true;
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
