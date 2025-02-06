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

namespace DVLD.Test.TestTypes
{
    public partial class frmEditTestType : Form
    {
        private clsTestType _TestType = null;
        public frmEditTestType(int TestTypeID)
        {
            InitializeComponent();
            _TestType = clsTestType.Find(TestTypeID);
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            txbTestTypeTitle.Clear();
            txbTestTypeDescription.Clear();
            txbTestTypeFees.Clear();
        }

        private void frmEditTestType_Load(object sender, EventArgs e)
        {
            lblTestTypeID.Text = _TestType.ID.ToString();
            txbTestTypeTitle.Text = _TestType.Title;
            txbTestTypeDescription.Text = _TestType.Description;
            txbTestTypeFees.Text = _TestType.Fees.ToString();
        }


        private bool _IsDataValid()
        {
            return !string.IsNullOrWhiteSpace(txbTestTypeTitle.Text) &&
                      !string.IsNullOrWhiteSpace(txbTestTypeDescription.Text) &&
                      !string.IsNullOrWhiteSpace(txbTestTypeFees.Text) &&
                      clsValidation.IsPositiveDecimal(txbTestTypeFees.Text);
        }

        private void _FillTestTypeObject()
        {
            _TestType.Title = txbTestTypeTitle.Text.Trim();
            _TestType.Description = txbTestTypeDescription.Text.Trim();
            _TestType.Fees = Convert.ToDecimal(txbTestTypeFees.Text);
        }


        private void btnSave_Click(object sender, EventArgs e)
        {
            if (_IsDataValid())
            {
                _FillTestTypeObject();

                if (_TestType.Save())
                    MessageBox.Show("Test Type Data Saved Successfully.", "Done");
                else
                    MessageBox.Show("Error: Test Type Data was NOT Saved Successfully.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                this.Close();
            }
            else
                MessageBox.Show("Enter Test Type Title and Valid Fees Value.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

        }
    }
}
