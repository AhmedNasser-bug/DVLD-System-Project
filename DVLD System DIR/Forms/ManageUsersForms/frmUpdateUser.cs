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
    public partial class frmUpdateUser : Form
    {
        frmDisplayUser frmUserDetails;
        User selectedUser;

        public frmUpdateUser(User selectedUser)
        {
            InitializeComponent();

            this.selectedUser  = selectedUser;
            frmUserDetails = new frmDisplayUser(selectedUser);
            ctrlFillUserData1.UpdateMode(selectedUser) ;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            bool saveSuccess = ctrlFillUserData1.Save() != -1;

            if (saveSuccess)
            {
                MessageBox.Show($"Save Successful With ID: {ctrlFillUserData1.curUser.UserID}");

                frmUserDetails.DisplayUser(selectedUser);
            }
            else
            {
                MessageBox.Show($"Save Failed");
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnDisplayDetails_Click(object sender, EventArgs e)
        {
            frmUserDetails.ShowDialog();
        }
    }
}
