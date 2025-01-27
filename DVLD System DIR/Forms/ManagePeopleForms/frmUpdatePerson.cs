using DVLD_System.Utils;
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

namespace DVLD_System.Forms.ManagePeopleForms
{
    public partial class frmUpdatePerson : Form
    {
        public frmUpdatePerson(Person person)
        {
            
            InitializeComponent();
            ctrlDisplayPersonDetails1.person = person;
            ctrlGetPersonData.curPerson = person;
            ctrlGetPersonData.LoadData(person);

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
           string oldImage1 = ctrlDisplayPersonDetails1.RemoveImage();
           string oldImage2 = ctrlGetPersonData.RemoveImage();

            bool result = ctrlGetPersonData.Save();

            if (result)
            {
                MessageBox.Show("Person Saved Successfully", "Hint");
            }
            else
            {
                MessageBox.Show("Error Saving Person", "Hint");

            }
            ctrlDisplayPersonDetails1.ShowData(ctrlGetPersonData.curPerson);
            ctrlGetPersonData.ResetImage(ctrlGetPersonData.curPerson.ImagePath);
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

    }
}
