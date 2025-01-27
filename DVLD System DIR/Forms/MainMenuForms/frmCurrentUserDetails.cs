using DVLD_System.Forms.ManageUsersForms;
using DVLDBuisnessLayer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLD_System.Forms.MainMenuForms
{
    public partial class frmCurrentUserDetails : Form
    {
        public frmCurrentUserDetails()
        {
            InitializeComponent();
        }

        private void btnChangePassword_Click(object sender, EventArgs e)
        {
            Form frmChangePassword = new frmChangePassword(User.GlobalUser);

            frmChangePassword.ShowDialog();

        }

        private void btnSignout_Click(object sender, EventArgs e)
        {
            User.GlobalUser = null;

            Application.Exit();

            Application.Run(new frmLoginScreen());
        }

        private void frmCurrentUserDetails_Load(object sender, EventArgs e)
        {
            ctrlDisplayUserData1.ShowData(User.GlobalUser);
        }
    }
}
