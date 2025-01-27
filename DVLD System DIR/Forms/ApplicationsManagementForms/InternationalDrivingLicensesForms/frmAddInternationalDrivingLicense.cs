using DVLD_System.Forms.ManageDriversForms;
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

namespace DVLD_System.Forms.ApplicationsManagementForms.InternationalDrivingLicensesForms
{
    public partial class frmAddInternationalDrivingLicense : Form
    {
        
        public License_ selectedLicense { get{return ctrlFindLicense.GetSelectedLicense();}}
        private InternationalLicense newLicense { get; set; }

        private void SetNewLicense(InternationalLicense IntLicense)
        {
            newLicense = IntLicense;
            ctrlFindLicense.SetExternalLicense(IntLicense.AssociatedLicense);
            llblShowLicenseInfo.Enabled = true;
        }

        public frmAddInternationalDrivingLicense(License_ license = null)
        {
            InitializeComponent();


            // Initialize labels
            lblApplicationDate.Text = DateTime.Now.ToShortDateString();
            lblCreatedBy.Text = User.GlobalUser.UserName;
            if (ctrlFindLicense.cbLicenseIDs.Items.Count > 0)
            {
                lblExpDate.Text = DateTime.Now.AddYears(selectedLicense.licenseClass.ClassValidityLength).ToShortDateString();
                lblFees.Text = ApplicationType.Find(6).AppTypeFee.ToString();
                lblIssueDate.Text = DateTime.Now.ToShortDateString();
            }
            else
            {
                ctrlFindLicense.Enabled = false;
                lblShowLicenseHistory.Enabled = false;
                btnSave.Enabled = false;
            }

            // Initialize variables if there is a given license
            if (license != null)
            {
                ctrlFindLicense.SetExternalLicense(license);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
           // initialize application First then International License second, get data from selected license thro ctrl
            if (!selectedLicense.isValidForInternational())
            {
                MessageBox.Show("Not a valid local license for international license," +
                                "\nLicense must be from Class 3 and Active and Not detained!" +
                                "\nif the above requirements are matched contact the developer",
                                "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Initialize application
            Application_ newIntrApplication = new Application_();
            newIntrApplication.ApplicationStatus = Application_.enApplicationStatus.Completed;
            newIntrApplication.ApplicationDate = DateTime.Today;
            newIntrApplication.ApplicantPersonID = selectedLicense.driver.PersonID;
            newIntrApplication.LastStatusDate = DateTime.Today;
            newIntrApplication.ApplicationTypeID = 6;
            newIntrApplication.CreatedByUserID = User.GlobalUser.UserID;
            newIntrApplication.PaidFees = Convert.ToDecimal(lblFees.Text);
            
            // Initialize International License
            InternationalLicense IntrLicense = new InternationalLicense();
            IntrLicense.IssueDate = DateTime.Today;
            IntrLicense.ExpirationDate = DateTime.Today.AddYears(LicenseClass.GetLicenseClassWithID(3).ClassValidityLength);
            IntrLicense.IssuedByLocalLicenseID = selectedLicense.LicenseID;
            IntrLicense.DriverID = selectedLicense.DriverID;
            IntrLicense.IsActive = true;
            IntrLicense.CreatedByUserID = User.GlobalUser.UserID;
            IntrLicense.AssociatedApplication = newIntrApplication;
            
            bool saveResult = IntrLicense.Save();

            if (saveResult == true)
            {
                MessageBox.Show($"Successfully saved new International Driving License With ID {IntrLicense.InternationalLicenseID}", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                SetNewLicense(IntrLicense);
            }
            else
            {
                MessageBox.Show("Failed to Add Application to database\nContact the develeoper immediately", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            



        }

        private void lblShowLicenseHistory_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Form frmLicenseHist = new frmShowLicenseHistory(ctrlFindLicense.GetSelectedLicense().driver);
            frmLicenseHist.ShowDialog();
        }

        private void lblShowLicenseInfo_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Form frmIntLicenseDetails = new frmInternationalLicenseDetails(newLicense);
            frmIntLicenseDetails.ShowDialog();  
        }

        private void frmAddInternationalDrivingLicense_Load(object sender, EventArgs e)
        {

        }
    }
}
