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
    public partial class ctrlDisplayUserData : UserControl
    {
        
        public ctrlDisplayUserData()
        {
            InitializeComponent();
        }

        public void ShowData(User user)
        {
            ctrlDisplayPersonDetails1.person = user.AssociatedPerson;
            ctrlDisplayPersonDetails1.ShowData(user.AssociatedPerson);
            lblUserID.Text = user.UserID.ToString();
            lblPersonID.Text = user.PersonID.ToString();
            lblUsername.Text = user.UserName; 
            if (user.IsActive)
            {
                lblIsActive.Text = "Active";
            }
            else
            {
                lblIsActive.Text = "InActive";
            }

        }

        private void ctrlDisplayUserData_Load(object sender, EventArgs e)
        {

        }
    }
}
