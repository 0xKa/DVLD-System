using DVLD_BusinessLayer;
using System;
using System.Windows.Forms;

namespace DVLD_v1._0
{
    public partial class frmUpdateTestType : Form
    {
        int _TestTypeID = -1;
        clsTestType _TestType = null;
        public frmUpdateTestType(int TestTypeID)
        {
            InitializeComponent();
            _TestTypeID = TestTypeID;
        }

        private void _LoadData()
        {
            _TestType = clsTestType.Find(_TestTypeID);

            if (_TestType != null )
            {
                lblID.Text = _TestType.ID.ToString();
                txbTitle.Text = _TestType.Title;
                txbDescription.Text = _TestType.Description;
                txbFees.Text = _TestType.Fees.ToString();
            }
            else
                MessageBox.Show($"Test Type with ID = {_TestType.ID} Not Found!!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

        }

        private void frmUpdateTestType_Load(object sender, EventArgs e)
        {
            _LoadData();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            txbTitle.Text = string.Empty;
            txbDescription.Text = string.Empty;
            txbFees.Text = string.Empty;

            btnSave.Enabled = false;
        }

        private void _FillTestTypeObject()
        {
            _TestType.Title = txbTitle.Text;
            _TestType.Description = txbDescription.Text;
            _TestType.Fees = Convert.ToDouble(txbFees.Text);
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            _FillTestTypeObject();

            if (_TestType.Save())
                MessageBox.Show("Test Type Data Saved Successfully.", "Done");
            else
                MessageBox.Show("Error: Test Type Data was NOT Saved Successfully.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void _UpdateSaveButtonState()
        {
            bool isFieldsFilled = !string.IsNullOrWhiteSpace(txbTitle.Text) &&
                                   !string.IsNullOrWhiteSpace(txbDescription.Text) &&
                                   !string.IsNullOrWhiteSpace(txbFees.Text) &&
                                   double.TryParse(txbFees.Text, out double Fees) && Fees > 0;

            btnSave.Enabled = isFieldsFilled;
        }
        private void _ValidateTextBox(string ErrorMessage, TextBox txb)
        {
            if (string.IsNullOrWhiteSpace(txb.Text))
                errorProvider1.SetError(txb, ErrorMessage);
            else
                errorProvider1.SetError(txb, string.Empty);

            _UpdateSaveButtonState();
        }

        private void txbTitle_Validated(object sender, EventArgs e)
        {
            _ValidateTextBox("Title is required.", txbTitle);
        }

        private void txbDescription_Validated(object sender, EventArgs e)
        {
            _ValidateTextBox("Description is required.", txbDescription);
        }

        private void txbFees_Validated(object sender, EventArgs e)
        {
            _ValidateTextBox("Fee is required. (must be a positive number)", txbFees);
        }
    }
}
