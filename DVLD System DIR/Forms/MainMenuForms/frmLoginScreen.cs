using DVLD_DataAccessLayer.Utils;
using DVLD_System.Forms.ManageUsersForms;
using DVLD_System.Utils;
using DVLDBuisnessLayer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLD_System
{
    public partial class frmLoginScreen : Form
    {
        private User currentUser = null;
        public frmLoginScreen()
        {
            InitializeComponent();
        }

        private void LoadProgram()
        {
            User.GlobalUser = currentUser;

            if (rbRememberUser.Checked)
            {
                FileUtils.RememberUser(tbUsername.Text, tbPassword.Text);
            }
            else
            {
                FileUtils.ClearLogins();
            }

            this.Hide();
            frmMainScreen frm = new frmMainScreen(this);
            frm.ShowDialog();
        }

        private void LogUser()
        {
            bool validUser = ValidCredintials();

            if (validUser)
            {
                LoadProgram();
            }
            else
            {
                if (currentUser != null && !currentUser.IsActive)
                {
                    MessageBox.Show("User IS INACTIVE please contact your Admin", "Notice", MessageBoxButtons.OK, MessageBoxIcon.Warning );
                }
                else 
                {
                    errorProvider.SetError(btnLogin, "Username or Password Are invalid");
                }
                
            }
        }

        private bool ValidCredintials()
        {
            currentUser = User.Find(tbUsername.Text);

            bool validUsername = currentUser != null && currentUser.IsActive;
            bool validPassword = currentUser != null && currentUser.Password == CryptograpgyUtils.ComputeHash(tbPassword.Text);

            return validUsername && validPassword;
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            LogUser();
        }

        private void frmLoginScreen_Load(object sender, EventArgs e)
        {
            if (FileUtils.HasOldUser())
            {
                string[] Credintials = FileUtils.CurrentCredintials();
                tbUsername.Text = Credintials[0];
                tbPassword.Text = Credintials[1];
            }
        }

    }
}
