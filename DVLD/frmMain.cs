using DVLD.People;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLD
{
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();
        }

        private Form _CurrentScreen = null;

        private void peopleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _CurrentScreen = new frmManagePeople();
            _CurrentScreen.ShowDialog();
        }

        private void usersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _CurrentScreen = new frmLogin();
            _CurrentScreen.ShowDialog();
        }
    }
}
