using DVLD_DataAccessLayer.Utils;
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

namespace DVLD_System.Forms.ManageUsersForms
{
    public partial class frmChangePassword : Form
    {
        private User curUser;
        public frmChangePassword(User curUser)
        {
            InitializeComponent();
            this.curUser = curUser;
            lblUserID.Text = curUser.UserID.ToString();
            lblUserName.Text = curUser.UserName;
        }

        private void ValidateOldPassword()
        {
            if(curUser.Password != CryptograpgyUtils.ComputeHash(tbOldPassword.Text))
            {
                errorProvider.SetError(tbOldPassword, "Wrong Password");
                tbOldPassword.Focus();
            }
            else
            {
                errorProvider.Clear();
            }
        }

        private void SaveNewCredintials()
        {
            ValidateOldPassword();

            if (tbNewPasswordConf.Text == tbNewPassword.Text && tbNewPassword.Text.Length > 0)
            {
                curUser.Password = tbNewPasswordConf.Text;
                bool saveSuccess = curUser.Save();

                if (saveSuccess)
                {
                    MessageBox.Show("Password Changed Successfully", "Notice", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Error Saving New Password", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                errorProvider.SetError(tbNewPassword, "Illegal Password");
            }

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            SaveNewCredintials();
        }

        private void tbNewPasswordConf_TextChanged(object sender, EventArgs e)
        {
            if (tbNewPasswordConf.Text != tbNewPassword.Text)
            {
                errorProvider.SetError(tbNewPasswordConf, "Passwords Does not match");
            }
            else
            {
                errorProvider.Clear();
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
