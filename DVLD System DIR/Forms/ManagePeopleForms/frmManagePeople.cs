using DVLD_System.Forms.ManagePeopleForms;
using DVLDBuisnessLayer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Common;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Input;

namespace DVLD_System.Forms
{
    public partial class frmManagePeople : Form
    {
        enum enFilterChoices { enPersonalID = 0, enNationalNo = 1, enName = 2 };
        DataTable dtPeople;
        enFilterChoices currentChoice;

        public frmManagePeople()
        {
            InitializeComponent();
            dtPeople = Person.GetPeopleTable();
            dgvPeopleTable.DataSource = dtPeople;
            currentChoice = enFilterChoices.enPersonalID;
            cbFilter.SelectedIndex = 0;

        }

        private void RefreshData()
        {
            dgvPeopleTable.DataSource = Person.GetPeopleTable();
            
        }

        private Person GetSelectedPerson()
                {
                    DataGridViewRow selectedRow = dgvPeopleTable.Rows[dgvPeopleTable.SelectedCells[0].RowIndex];
                    Person selectedPerson = Person.Find((int)selectedRow.Cells[0].Value);
                    return selectedPerson;
                }

        private void btnAddPerson_Click(object sender, EventArgs e)
        {
            frmAddPerson addPeopleForm = new frmAddPerson();
            addPeopleForm.ShowDialog();
            RefreshData();
        }

        private void updateUserToolStripMenuItem_Click(object sender, EventArgs e)
        {
           Person selectedPerson = GetSelectedPerson();
            
           frmUpdatePerson updateForm = new frmUpdatePerson(selectedPerson);
           
            updateForm.ShowDialog();

           RefreshData();
        }
      
        private void deletePersonToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Person selectedPerson = GetSelectedPerson();

           DialogResult confirm = MessageBox.Show("Are you sure you want to delete that person?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
           if (confirm == DialogResult.Yes)
           {
                bool deleteResult = selectedPerson.Delete();

                if (deleteResult)
                {
                    MessageBox.Show("Person Deleted Successfully", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    RefreshData();
                }
           }
           

        }

        private void displayDetailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Person selected = GetSelectedPerson();

            frmPersonDetails frmDetails = new frmPersonDetails(selected);

            frmDetails.ShowDialog();
            
        }

        private void FilterTable()
        {
            currentChoice = (enFilterChoices)cbFilter.SelectedIndex;

            switch (currentChoice)
            {
                case enFilterChoices.enPersonalID:
                    dgvPeopleTable.DataSource = DataTableUtils.GetFilteredTable(dtPeople, "PersonID", $"{tbFilterParams.Text}");
                    break;

                case enFilterChoices.enNationalNo:
                    dgvPeopleTable.DataSource = DataTableUtils.GetFilteredTable(dtPeople, "NationalNO", $"'{tbFilterParams.Text}'");
                    break;

                case enFilterChoices.enName:
                    dgvPeopleTable.DataSource = DataTableUtils.GetFilteredTable(dtPeople, "Name", tbFilterParams.Text, true);
                    break;

                default:
                    break;
            }
        }

        private void tbFilterParams_TextChanged(object sender, EventArgs e)
        {
            if (tbFilterParams.Text.Length > 0) 
            {
                FilterTable();
            }
            else
            {
                dgvPeopleTable.DataSource = dtPeople;
            }
        }

        private void dgvPeopleTable_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void frmManagePeople_Load(object sender, EventArgs e)
        {

        }

        private void cbFilter_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}
