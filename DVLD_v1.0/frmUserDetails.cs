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
    public partial class frmUserDetails : Form
    {
        private int _UserID = -1;
        public frmUserDetails(int UserID)
        {
            InitializeComponent();
            this._UserID = UserID;
        }

        private void _LoadUserDetails()
        {
            clsUser user = clsUser.Find(_UserID);

            if (user != null)
            {
                ctrlUserCard1.LoadUserInfo(user);
            }
            else
            {
                MessageBox.Show("User not found!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();  // Close the form if user data is not found
            }


        }

        private void frmUserDetails_Load(object sender, EventArgs e)
        {
            _LoadUserDetails();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
