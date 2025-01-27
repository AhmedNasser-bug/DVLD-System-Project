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
    public partial class frmManageUsers : Form
    {
        private User selectedUser { get {
                return GetSelectedUser();
            }
        }
        enum enFilterChoices { enUserID, enUsername, enName}
        DataTable AllUsers = User.GetAllUsers();

        public frmManageUsers()
        {
            InitializeComponent();
            RefreshData();
            cbFilter.SelectedIndex = 0;
        }
        private void RefreshData()
        {
            dgvUsersTable.DataSource = User.GetAllUsers();
        }
        
        private User GetSelectedUser()
        {
            DataGridViewRow selectedRow = dgvUsersTable.Rows[dgvUsersTable.SelectedCells[0].RowIndex];
            User selectedUser = User.Find((int)selectedRow.Cells[0].Value);
            return selectedUser;
        }
        

        private void btnAddUser_Click(object sender, EventArgs e)
        {
            frmAddUser addUserFrm = new frmAddUser();
            addUserFrm.ShowDialog();
            RefreshData();

        }


        private void showUserDetailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmDisplayUser frmDetails = new frmDisplayUser(selectedUser);
            frmDetails.ShowDialog();
        }


        private void deleteUserToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmDeleteUser frmDelete = new frmDeleteUser(selectedUser);
            frmDelete.ShowDialog();
            RefreshData();
        }


        private void updateUserToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmUpdateUser frmUpdate = new frmUpdateUser(selectedUser);
            frmUpdate.ShowDialog();
            RefreshData();
        }


        private void changePasswordToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmChangePassword frmChange = new frmChangePassword(selectedUser);
            frmChange.ShowDialog();
        }


        private void PerformFilter()
        {
            enFilterChoices currentFilterChoice = (enFilterChoices) cbFilter.SelectedIndex;
            string filterValue = tbFilterParams.Text;

            if (filterValue.Length > 0)
            switch (currentFilterChoice)
            {
                case enFilterChoices.enUserID:
                    dgvUsersTable.DataSource = DataTableUtils.GetFilteredTable(AllUsers, "UserID", filterValue);
                    break;

                case enFilterChoices.enUsername:
                    dgvUsersTable.DataSource = DataTableUtils.GetFilteredTable(AllUsers, "Username", filterValue);
                    break;

                case enFilterChoices.enName:
                    dgvUsersTable.DataSource = DataTableUtils.GetFilteredTable(AllUsers, "FullName", filterValue, true);
                    break;

                default:
                    break;
            }
            if (filterValue.Length == 0)
            {
                dgvUsersTable.DataSource = AllUsers;
            }
        }


        private void tbFilterParams_TextChanged(object sender, EventArgs e)
        {
            PerformFilter();
        }
    }
}
