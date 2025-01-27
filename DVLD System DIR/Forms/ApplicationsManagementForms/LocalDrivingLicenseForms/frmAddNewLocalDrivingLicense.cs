using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DVLDBuisnessLayer;

namespace DVLD_System.Forms.ApplicationsManagementForms
{
    public partial class frmAddNewLocalDrivingLicense : Form
    {
        int SelectedPersonID = -1;
        public frmAddNewLocalDrivingLicense()
        {
            InitializeComponent();
            tabPageConfirmation.Enabled = false;
            
        }

        private void InitializeConfirmation()
        {
            // Change buttons
            btnConfirm.Enabled = true;
            btnConfirm.Visible = true;
            btnNext.Enabled = false;
            btnNext.Visible = false;

            // Sets the application date and fees
            lblApplicationDate.Text = DateTime.Now.ToString();
            lblCreatedBy.Text = User.GlobalUser.UserName;
            lblApplicationFees.Text = "15";
            
            // Get All the license Classes
            cbLicenseClasses.DataSource = LicenseClass.GetAllLicenseClasses().DefaultView;
            cbLicenseClasses.DisplayMember = "ClassName";

            // Change the current control
            SelectedPersonID = ctrlFindPerson1.personID;
            tabControl1.SelectedTab = tabPageConfirmation;
            tabPageConfirmation.Enabled = true;
            tabPagePerson.Enabled = false;
            tabPageConfirmation.Select();
            
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            bool foundPerson = ctrlFindPerson1.personID != -1;
            
            if (foundPerson)
            {
                InitializeConfirmation();
            }
            else
            {
                MessageBox.Show("Please select a Valid Person", "Notice", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }

        }

        private LicenseClass SelectedLicenseClass()
        {
            int selectedID = cbLicenseClasses.SelectedIndex + 1;
            LicenseClass selectedLicenseClass = LicenseClass.GetLicenseClassWithID(selectedID);
            return selectedLicenseClass;
        }

        private void btnConfirm_Click(object sender, EventArgs e)
        {
            // Initialize the new application data
            Application_ candidate_Application = new Application_();
            candidate_Application.ApplicantPersonID = ctrlFindPerson1.personID;
            candidate_Application.ApplicationDate = DateTime.Now;
            candidate_Application.ApplicationStatus = Application_.enApplicationStatus.New;
            candidate_Application.ApplicationTypeID = 1;
            candidate_Application.CreatedByUserID = User.GlobalUser.UserID;
            candidate_Application.LastStatusDate = DateTime.Now;
            candidate_Application.PaidFees = 15;

            // Add local driving license application
            // Initialize new local driving license data
            LocalDrivingLicense candidate_ldl = new LocalDrivingLicense();
            candidate_ldl.AssociatedApp = candidate_Application;
            candidate_ldl.LicenseClassID = SelectedLicenseClass().LicenseClassID;

            // Check the validity of the Application
            if(!candidate_ldl.IsValidApplication())
            {
                MessageBox.Show("\aThis person already have a pending application for this Driving License", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // save into database
            bool success = candidate_ldl.Save();
            if (success)
            {   
                MessageBox.Show($"Application saved with ID: {candidate_ldl.LDLicenseID}", "Notice", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            
            MessageBox.Show("Error saving the application", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
           

        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

    }
}
