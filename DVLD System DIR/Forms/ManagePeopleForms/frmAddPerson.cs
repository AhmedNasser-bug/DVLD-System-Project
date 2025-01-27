using DVLD_System.Utils;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLD_System.Forms.ManagePeopleForms
{
    public partial class frmAddPerson : Form
    {
        public frmAddPerson()
        {
            InitializeComponent();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            bool result = getPersonData.Save();
            
            if (result)
            {
                MessageBox.Show($"Person Saved Successfully With ID : {getPersonData.curPerson.PersonID}", "Hint");
                Close();
            }
            else
            {
                MessageBox.Show("Error Saving Person", "Hint");
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
                        
            this.Close();
        }

    }
}
