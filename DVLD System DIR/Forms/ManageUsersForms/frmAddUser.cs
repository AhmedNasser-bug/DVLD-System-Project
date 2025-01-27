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
    public partial class frmAddUser : Form
    {
        public frmAddUser()
        {
            InitializeComponent();
        }


        private bool PersonIsAlreadyUser(int personID)
        {
            bool isFound = User.IsPersonAlreadyUser(personID);

            return isFound;
        }


        private void btnSave_Click(object sender, EventArgs e)
        {
            if (PersonIsAlreadyUser(ctrlFillUserData1.curUser.PersonID))
            {
                MessageBox.Show("Already a User!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            
            bool saveSuccess = ctrlFillUserData1.Save() != -1;

            if (saveSuccess) 
            {
                MessageBox.Show( $"Save Successful With ID: {ctrlFillUserData1.curUser.UserID}");
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

        
    }
}
