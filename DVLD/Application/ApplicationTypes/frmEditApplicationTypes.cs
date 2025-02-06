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

namespace DVLD.Application.ApplicationTypes
{
    public partial class frmEditApplicationTypes : Form
    {

        private clsApplicationType _ApplicationType = null;

        public frmEditApplicationTypes(int ApplicationTypeID)
        {
            InitializeComponent();
            _ApplicationType = clsApplicationType.Find(ApplicationTypeID);
        }

        private void frmEditApplicationTypes_Load(object sender, EventArgs e)
        {
            lblApplicationTypeID.Text = _ApplicationType.ID.ToString();
            txbApplicationTypeTitle.Text = _ApplicationType.Title;
            txbApplicationTypeFees.Text = _ApplicationType.Fees.ToString();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            txbApplicationTypeFees.Clear();
            txbApplicationTypeTitle.Clear();
        }

        private bool _IsDataValid()
        {
            return !string.IsNullOrWhiteSpace(txbApplicationTypeTitle.Text) &&
                      !string.IsNullOrWhiteSpace(txbApplicationTypeFees.Text) &&
                      decimal.TryParse(txbApplicationTypeFees.Text, out decimal Fees) && Fees > 0;
        }

        private void _FillApplicationTypeObject()
        {
            _ApplicationType.Title = txbApplicationTypeTitle.Text.Trim();
            _ApplicationType.Fees = Convert.ToDecimal(txbApplicationTypeFees.Text);
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (_IsDataValid())
            {
                _FillApplicationTypeObject();
               
                if (_ApplicationType.Save())
                    MessageBox.Show("Application Type Data Saved Successfully.", "Done");
                else
                    MessageBox.Show("Error: Application Type Data was NOT Saved Successfully.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                this.Close();
            }
            else
                MessageBox.Show("Enter Application Type Title and Valid Fees Value.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

        }
    }
}
