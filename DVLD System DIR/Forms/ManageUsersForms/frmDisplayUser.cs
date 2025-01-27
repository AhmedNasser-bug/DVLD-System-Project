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
    public partial class frmDisplayUser : Form
    {
        public frmDisplayUser(User user)
        {
            InitializeComponent();
            ctrlDisplayUserData1.ShowData(user);
        }
        public void DisplayUser(User user) 
        {
            ctrlDisplayUserData1.ShowData(user);
        }


    }
}
