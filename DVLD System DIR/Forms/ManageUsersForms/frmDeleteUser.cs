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
    public partial class frmDeleteUser : Form
    {
        private User selectedUser;
        public frmDeleteUser(User user)
        {
            InitializeComponent();
            ctrlDisplayUserData1.ShowData(user);
            selectedUser = user;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (selectedUser.UserID == 4037) MessageBox.Show("CAN NOT DELETE ADMIN", "FATAL ERROR", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            bool success = selectedUser.Delete();
            if (success)
            {
                MessageBox.Show("User Deleted Successfully", "Notice", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else
            {
                MessageBox.Show("Error Deleting User", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            Close();

        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
