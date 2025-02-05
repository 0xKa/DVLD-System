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
            lblActiveStatus.Text = SelectedUser.IsActive ? "Active" : "Inactive";
            pbActiveStatus.Image = SelectedUser.IsActive ? Resources.active : Resources.inactive;
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
