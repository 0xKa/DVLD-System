using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLD.User
{
    public partial class frmUserDetails : Form
    {
        int _UserID = 1;
        public frmUserDetails(int UserID)
        {
            InitializeComponent();
            _UserID = UserID;
        }

        private void frmUserDetails_Load(object sender, EventArgs e)
        {
            this.Activated += FrmUserDetails_Activated;
            this.Text = $"User {_UserID} Details";
        }

        private void FrmUserDetails_Activated(object sender, EventArgs e)
        {
            ctrlUserCard1.LoadUserInfo(_UserID);
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

    }
}
