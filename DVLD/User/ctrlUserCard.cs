using DVLD.Properties;
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

namespace DVLD.User
{
    public partial class ctrlUserCard : UserControl
    {
        public ctrlUserCard()
        {
            InitializeComponent();
        }

        public clsUser SelectedUser = null;

        private void _FillCard()
        {
            ctrlPersonCard1.LoadPersonInfo(SelectedUser.PersonID);
            lblUserID.Text = SelectedUser.ID.ToString();
            lblUsername.Text = SelectedUser.Username;

            if (SelectedUser.IsActive)
            {
                lblActiveStatus.Text = "Active";
                pbActiveStatus.Image = Resources.active;
                lblUserID.ForeColor = Color.Green;
                lblUsername.ForeColor = Color.Green;
                lblActiveStatus.ForeColor = Color.Green;
            }
            else
            {
                lblActiveStatus.Text = "Inactive";
                pbActiveStatus.Image = Resources.inactive;
                lblUserID.ForeColor = Color.Firebrick;
                lblUsername.ForeColor = Color.Firebrick;
                lblActiveStatus.ForeColor = Color.Firebrick;
            }


        }

        public void LoadUserInfo(clsUser User)
        {
            if (User != null)
            {
                SelectedUser = User;
                _FillCard();
            }
            else
                MessageBox.Show("User Was Not Found", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

        }
        public void LoadUserInfo(int UserID)
        {
            this.LoadUserInfo(clsUser.Find(UserID));
        }
        public void LoadUserInfoUsingPersonID(int PersonID)
        {
            this.LoadUserInfo(clsUser.FindByPersonID(PersonID));
        }
    }
}
