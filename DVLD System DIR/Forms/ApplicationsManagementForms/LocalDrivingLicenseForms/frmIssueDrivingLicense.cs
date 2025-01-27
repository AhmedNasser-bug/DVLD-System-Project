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
    public partial class frmIssueDrivingLicense : Form
    {
        public LocalDrivingLicense localDrivingLicense { get; set; }
        public int PassedTests;

        public frmIssueDrivingLicense(LocalDrivingLicense localDrivingLicense, int PassedTests)
        {
            InitializeComponent();

            // Initialize variables
            this.localDrivingLicense = localDrivingLicense;
            this.PassedTests = PassedTests;

            // Initialize controls
            ctrlDrivingLicenseApplicationDataData.InitializeLabels(localDrivingLicense, PassedTests);

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            Driver newDriver = new Driver();
            newDriver.CreatedByUserID = User.GlobalUser.UserID;
            newDriver.CreatedDate = DateTime.Now;
            newDriver.PersonID = localDrivingLicense.AssociatedApp.ApplicantPersonID;

            bool saveResult = newDriver.Save();
            if (saveResult)
            {
                License_ newLicense = new License_();
                newLicense.ApplicationID = localDrivingLicense.AssociatedApp.ApplicationID;
                newLicense.CreatedByUserID = User.GlobalUser.UserID;
                newLicense.IssueReason = ((int)License_.enIssueReasons.FirstTime);
                newLicense.IssueDate = DateTime.Now;
                newLicense.PaidFees = localDrivingLicense.AssociatedApp.PaidFees;
                newLicense.DriverID = newDriver.DriverID;
                newLicense.ExpirationDate = DateTime.Now.AddYears(localDrivingLicense.AssociatedLicenseClass.ClassValidityLength);
                newLicense.IsActive = true;
                newLicense.LicenseClassID = localDrivingLicense.LicenseClassID;
                newLicense.Notes = rtbNotes.Text;
                localDrivingLicense.AssociatedApp.ApplicationStatus = Application_.enApplicationStatus.Completed;

                // Save into database
                saveResult = newLicense.Save();

                if (saveResult)
                {
                    MessageBox.Show($"Congratulations! You are now a certified driver with ID: {newDriver.DriverID} and license ID: {newLicense.LicenseID}", "Success",  MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    localDrivingLicense.Save();
                    return;
                }
                else
                {
                    MessageBox.Show("Error saving License driver details is added", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Error Adding Driver ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
