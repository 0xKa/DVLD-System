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
    public partial class ctrlUserCard : UserControl
    {
        public ctrlUserCard()
        {
            InitializeComponent();
        }

        public void LoadUserInfo(clsUser User)
        {
            ctrlPersonCard1.LoadPersonInfo(User.PersonID);

            lblUserID.Text = User.ID.ToString();
            lblUsername.Text = User.Username.ToString();

            if (User.IsActive)
            {
                pbActivity.Image = imageList1.Images[0];
                lblUserID.ForeColor = Color.LightGreen;
                lblUsername.ForeColor = Color.LightGreen;
            }
            else
            {
                pbActivity.Image = imageList1.Images[1];
                lblUserID.ForeColor = Color.FromArgb(192, 0, 0);
                lblUsername.ForeColor = Color.FromArgb(192, 0, 0);
            }
        }
        public void LoadUserInfo(int UserID)
        {
            LoadUserInfo(clsUser.Find(UserID));
        }

        private void ctrlUserCard_Load(object sender, EventArgs e)
        {
            ctrlPersonCard1.ChangeTitle("User Details");
        }
    }
}
