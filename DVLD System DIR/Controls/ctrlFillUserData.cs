using DVLD_DataAccessLayer.Utils;
using DVLD_System.Forms.ManagePeopleForms;
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

namespace DVLD_System.Controls
{
    public partial class ctrlFillUserData : UserControl
    {
        public User curUser = new User();

        bool updateMode = false;

        public ctrlFillUserData()
        {
            InitializeComponent();
        }

        public void UpdateMode(User user)
        {
            this.curUser = user;
            btnFindPersonID.Enabled = false;
            btnAddPerson.Enabled = false;
            cbPersons.Text = curUser.PersonID.ToString();
            updateMode = true;
        }

        private void ctrlFillUserData_Load(object sender, EventArgs e)
        {
            cbPersons.DataSource = Person.GetNonUsersTable();
            cbPersons.DisplayMember = "PersonID";
            //cbPersons.SelectedIndex = 0;
        }

        private bool ValidateUserName()
        {
            string potentialUsername = tbUserName.Text;

            bool usernameAlreadyExist = User.IsUserExist(potentialUsername);

            bool confirmationError = potentialUsername != tbConfirmUserName.Text;

            bool emptyUsername = tbUserName.Text.Length == 0;

            return !usernameAlreadyExist && !confirmationError && !emptyUsername;

        }

        private bool ValidatePassword()
        {
            string potentialPassword = tbPassword.Text;

            bool confirmationError = potentialPassword != tbConfirmPassword.Text;

            bool emptyPassword = tbPassword.Text.Length == 0;  

            return !confirmationError && !emptyPassword;

        }

        public int Save()
        {
            bool validPassword = ValidatePassword();

            bool validUsername = ValidateUserName();

            bool validData = validUsername && validPassword;


            if (!validUsername)
            {
                errorProvider.SetError(tbConfirmUserName, "Username doesn't match");
            }
            if (!validPassword)
            {
                errorProvider.SetError(tbConfirmPassword, "Password doesn't match");
            }


            if (validData)
            {
                curUser.UserName = tbUserName.Text;
                curUser.Password = CryptograpgyUtils.ComputeHash(tbPassword.Text);
                curUser.PersonID = Convert.ToInt32(cbPersons.Text);
                curUser.IsActive = cbIsActive.Checked;

                bool saveResult = curUser.Save();

                if (saveResult) return curUser.UserID;
                else return -1;
            }

            return -1;

        }

        private void btnAddPerson_Click(object sender, EventArgs e)
        {
            frmAddPerson frmAddP = new frmAddPerson();
            
            frmAddP.ShowDialog();

            cbPersons.DataSource = Person.GetNonUsersTable();
        }

        private void SelectID(object sender, int PersonID)
        {
            cbPersons.Text = PersonID.ToString();
        }

        private void btnFindPersonID_Click(object sender, EventArgs e)
        {
            frmFindPerson frmFindP = new frmFindPerson();

            frmFindP.DataBack += SelectID;

            frmFindP.ShowDialog();
        }

        private void cbPersons_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
