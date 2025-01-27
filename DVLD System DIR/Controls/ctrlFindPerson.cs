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
using System.Windows.Controls.Primitives;
using System.Windows.Forms;

namespace DVLD_System.Controls
{
    public partial class ctrlFindPerson : UserControl
    {
        public int personID = -1;

        public ctrlFindPerson()
        {
            InitializeComponent();
            InitializeComboBox();
            
        }

        private void InitializeComboBox()
        {
            cbPersons.DataSource = Person.GetPeopleTable().DefaultView;
            cbPersons.DisplayMember = "PersonID";
        }

     
        private int FindPerson()
        {
            int potentialPersonID = Convert.ToInt32(cbPersons.Text);

            if (Person.IsPersonExist(potentialPersonID))
            {
                Person foundPerson = Person.Find(potentialPersonID);

                ctrlDisplayPersonDetails1.ShowData(foundPerson);

                return potentialPersonID;
            }
            else
            {
                MessageBox.Show("Person Not Found", "Notice", MessageBoxButtons.OK, MessageBoxIcon.Information);

                return -1;
            }
        }

        private void btnFindPersonID_Click(object sender, EventArgs e)
        {
           this.personID =  FindPerson();
           bool found = personID != -1;

                Person person = Person.Find(personID);

               if(found)ctrlDisplayPersonDetails1.ShowData(person);
            
        }

        private void btnAddPerson_Click(object sender, EventArgs e)
        {
            frmAddPerson frmAddP = new frmAddPerson();

            frmAddP.ShowDialog();

            InitializeComboBox();
        }
    }
}
