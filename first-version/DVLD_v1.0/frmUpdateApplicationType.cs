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
    public partial class frmUpdateApplicationType : Form
    {
        int _ApplicationTypeID = -1;
        clsApplicationType _ApplicationType = null;

        public frmUpdateApplicationType(int ApplicationTypeID)
        {
            InitializeComponent();
            _ApplicationTypeID = ApplicationTypeID;
        }

        private void _LoadData()
        {
            _ApplicationType = clsApplicationType.Find(_ApplicationTypeID);

            if (_ApplicationType != null)
            {
                lblID.Text = _ApplicationType.ID.ToString();
                txbTitle.Text = _ApplicationType.Title;
                txbFees.Text = _ApplicationType.Fees.ToString();
            }
            else
                MessageBox.Show($"Application Type with ID = {_ApplicationTypeID} Not Found!!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

        }

        private void frmUpdateApplicationType_Load(object sender, EventArgs e)
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
            txbFees.Text= string.Empty;

            btnSave.Enabled = false;
        }

        private void _FillApplicationTypeObject()
        {
            _ApplicationType.Title = txbTitle.Text;
            _ApplicationType.Fees = Convert.ToDouble(txbFees.Text);
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            _FillApplicationTypeObject();

            if (_ApplicationType.Save())
                MessageBox.Show("Application Type Data Saved Successfully.", "Done");
            else
                MessageBox.Show("Error: Application Type Data was NOT Saved Successfully.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

        }

        private void _UpdateSaveButtonState()
        {
            bool isFieldsFilled = !string.IsNullOrWhiteSpace(txbTitle.Text) &&
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

        private void txbFees_Validated(object sender, EventArgs e)
        {
            _ValidateTextBox("Fee is required. (must be a positive number)", txbFees);
        }

    }
}
