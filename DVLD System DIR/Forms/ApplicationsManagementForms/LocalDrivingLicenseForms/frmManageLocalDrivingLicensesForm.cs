using DVLD_System.Forms.ManageDriversForms;
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

namespace DVLD_System.Forms.ApplicationsManagementForms.LocalDrivingLicenseForms
{
    public partial class frmManageLocalDrivingLicensesForm : Form
    {
        enum enSearchBy {enLDL_ID = 0, enName = 1, enNationalNumber = 2}

        DataTable dtLDLs = LocalDrivingLicense.GetFullTable();
        public frmManageLocalDrivingLicensesForm()
        {
            InitializeComponent();

            // Initialize Data Grid View
            RefreshTable();
            cbSearchBy.SelectedIndex = 0;
        }

        // ------------------------------------------------------------------ Helper functions
        private LocalDrivingLicense SelectedLicense()
        {
            int SelectedLDL_ID = dgvUtils.GetSelectedPK(ref dgvLocalDrivingLicenses);
            return LocalDrivingLicense.Find(SelectedLDL_ID);
        }

        private void EnableEyeTest()
        {
            cancelApplicationToolStripMenuItem.Enabled = true;
            deleteApplicationToolStripMenuItem.Enabled = true;
            editApplicationToolStripMenuItem.Enabled = true;
            scheduleTestsToolStripMenuItem.Enabled = true;
            eyeTestToolStripMenuItem.Enabled = true;
        }

        private void EnableWritingTest()
        {
            cancelApplicationToolStripMenuItem.Enabled = true;
            deleteApplicationToolStripMenuItem.Enabled = true;
            editApplicationToolStripMenuItem.Enabled = true;
            scheduleTestsToolStripMenuItem.Enabled = true;
            writingTestToolStripMenuItem.Enabled = true;
        }

        private void EnableStreetTest()
        {
            cancelApplicationToolStripMenuItem.Enabled = true;
            deleteApplicationToolStripMenuItem.Enabled = true;
            editApplicationToolStripMenuItem.Enabled = true;
            scheduleTestsToolStripMenuItem.Enabled = true;
            streetTestToolStripMenuItem.Enabled = true;
        }

        private void EnableLicensing()
        {
            issueLicenseToolStripMenuItem.Enabled = true;
            deleteApplicationToolStripMenuItem.Enabled = true;
            cancelApplicationToolStripMenuItem.Enabled = true;
            editApplicationToolStripMenuItem.Enabled = true;
        }

        private void EnableCompletedMenuStrip()
        {
            showLicenseHistoryToolStripMenuItem.Enabled = true;
            showLicenseToolStripMenuItem.Enabled = true;
        }

        private void ResetContextMenu()
        {
            issueLicenseToolStripMenuItem.Enabled = false;
            showLicenseHistoryToolStripMenuItem.Enabled = false;
            showLicenseToolStripMenuItem.Enabled = false;
            scheduleTestsToolStripMenuItem.Enabled = false;
            streetTestToolStripMenuItem.Enabled = false;
            writingTestToolStripMenuItem.Enabled = false;
            eyeTestToolStripMenuItem.Enabled = false;
            cancelApplicationToolStripMenuItem.Enabled = false;
            deleteApplicationToolStripMenuItem.Enabled = false;
            editApplicationToolStripMenuItem.Enabled = false;

        }

        private void RefreshTable()
        {
            dtLDLs = LocalDrivingLicense.GetFullTable();
            dgvLocalDrivingLicenses.DataSource = dtLDLs;
        }

        private int PassedTests()
        {
            return Convert.ToInt32(dgvUtils.GetSelectedCell(ref dgvLocalDrivingLicenses, 5));
        }

        private LocalDrivingLicense GetSelectedLicenseApplication()
        {
            int PK = dgvUtils.GetSelectedPK(ref dgvLocalDrivingLicenses);

            return LocalDrivingLicense.Find(PK);
        }

        private License_ GetSelectedLicense()
        {
            int selectedApplicationID = GetSelectedLicenseApplication().ApplicationID;
            License_ selectedLicense = License_.FindWithApplicationID(selectedApplicationID);
            return selectedLicense;
        }

        private void OpenTest(int TypeID)
        {
            TestType testType = TestType.Find(TypeID);

            Form frmScheduleTests = new frmScheuleTests(GetSelectedLicenseApplication(), testType, PassedTests());
            frmScheduleTests.ShowDialog();

            RefreshTable();
        }

        void FilterTable()
        {
            enSearchBy choice = (enSearchBy)cbSearchBy.SelectedIndex;
            string searchColumn = "";
            string searchText = tbSearchBox.Text;
            bool isLikeStatement = false;

            switch (choice)
            {
                case enSearchBy.enLDL_ID:
                    searchColumn = "LocalDrivingLicenseApplicationID";
                    break;
                case enSearchBy.enName:
                    searchColumn = "FullName";
                    isLikeStatement = true;
                    break;
                case enSearchBy.enNationalNumber:
                    searchColumn = "NationalNo";
                    isLikeStatement = true;
                    break;
                default:
                    break;

            }

            dgvLocalDrivingLicenses.DataSource = DataTableUtils.GetFilteredTable(dtLDLs, searchColumn, searchText, isLikeStatement);
        }

        // ------------------------------------------------------------------ Events
        private void btnAddLDL_Click(object sender, EventArgs e)
        {
            Form frmAddLDL = new frmAddNewLocalDrivingLicense();
            frmAddLDL.ShowDialog();
            RefreshTable();
        }

        private void tbSearchBox_TextChanged(object sender, EventArgs e)
       {
            if (tbSearchBox.Text.Length > 0)
            {
                FilterTable();
            }
            else
            {
                RefreshTable();
            }
        }

        private void cancelApplicationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult confirmCancel = MessageBox.Show("Are you sure you want to cancel? ", "Confirm", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);

            if (confirmCancel == DialogResult.Cancel) return;
            
            if (SelectedLicense().AssociatedApp.Cancel())
            {
                MessageBox.Show("Cancelled Successfully!", "Notice", MessageBoxButtons.OK, MessageBoxIcon.Information);
                RefreshTable();
            }
            else
            {
                MessageBox.Show("Error cancelling application", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
        }

        private void cmsDgvLDLChoices_Opened(object sender, EventArgs e)
        {
            ResetContextMenu();
      
            int NumOfPassedTests = PassedTests();
            string Status = Convert.ToString(dgvUtils.GetSelectedCell(ref dgvLocalDrivingLicenses, 6));

            switch (Status)
            {
                case "Completed":
                    EnableCompletedMenuStrip();
                    return;
                case "Cancelled":
                    return;
            } 
                
            switch (NumOfPassedTests)
            {
                case 0:
                    EnableEyeTest();
                    break;
                case 1:
                    EnableWritingTest();
                    break;
                case 2:
                    EnableStreetTest();
                    break;
                case 3:
                    EnableLicensing();
                    break;
                    
                default:
                    break;
            }

        }

        private void deleteApplicationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult ConfirmDelete = MessageBox.Show("Are You sure you want to delete this Application?", "Confirm", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
            if(ConfirmDelete == DialogResult.OK)
            {
                // deletes the license from database
                bool deleteResult = SelectedLicense().AssociatedApp.Delete();
                if(deleteResult == true)
                {
                    MessageBox.Show("Deleted succesfully!", "Success!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Error Deleting application!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                RefreshTable();
            } 

        }

        private void showApplicationDetailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Get Seletced application
            LocalDrivingLicense LDL_app = GetSelectedLicenseApplication();

            // Open frmShowApplicationData 
            Form frmAppDetails = new frmLocalDrivingLicenseApplicationsDetails(LDL_app, PassedTests());
            frmAppDetails.ShowDialog();
        }

        private void eyeTestToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenTest(1);
        }

        private void writingTestToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenTest(2);
        }

        private void streetTestToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenTest(3);
        }

        private void editApplicationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            /// TODO
        }

        private void issueLicenseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Get selected license and passed tests
            LocalDrivingLicense selectedLocalDrivingLicense = GetSelectedLicenseApplication();

            // Open form and refresh table in case any changes are made.
            Form frmIssueLicense = new frmIssueDrivingLicense(selectedLocalDrivingLicense, PassedTests());
            frmIssueLicense.ShowDialog();
            RefreshTable();
        }

        private void showLicenseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Get Selected License
            License_ selectedLicense = GetSelectedLicense();

            // Open License Details Form
            Form frmLicenseDetails = new frmShowLicenseDetails(selectedLicense);
            frmLicenseDetails.ShowDialog();
        }

        private void showLicenseHistoryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Get selected License
            License_ selectedLicense = GetSelectedLicense();

            // Open License History Form
            Form frmShowLicenseHist = new frmShowLicenseHistory(selectedLicense.driver);
            frmShowLicenseHist.ShowDialog();
        }

        private void cmsDgvLDLChoices_Opening(object sender, CancelEventArgs e)
        {

        }
    }
}
