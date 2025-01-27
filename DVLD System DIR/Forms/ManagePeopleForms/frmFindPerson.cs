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
    public partial class frmFindPerson : Form
    {
        public delegate void DataBackEventHandler(object sender, int PersonID);

        public event DataBackEventHandler DataBack;
        
        public frmFindPerson()
        {
            InitializeComponent();
        }
        
        private void btnConfirm_Click(object sender, EventArgs e)
        {
            int PersonID = FindPerson();
            if (PersonID != -1)
            {
                DataBack?.Invoke(this, PersonID);

                Close();
            }
        }

        
        private int FindPerson()
        {
            int potentialPersonID = Convert.ToInt32(tbPersonID.Text);

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


        private void button1_Click(object sender, EventArgs e)
        {
            FindPerson();
        }

        private void frmFindPerson_Load(object sender, EventArgs e)
        {

        }
    }
}
