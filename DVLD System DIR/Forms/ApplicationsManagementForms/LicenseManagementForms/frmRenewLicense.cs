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
    public partial class frmRenewLicense : Form
    {
        ApplicationType appType = ApplicationType.Find(((int)ApplicationType.enAppTypeIDs.RenewDrivingLicense));
        License_ newLicense = null;

        public frmRenewLicense()
        {
            InitializeComponent();

            // Initialize labels
            lblIssueDate.Text = DateTime.Now.ToShortDateString();
            lblCreatedBy.Text = User.GlobalUser.UserName;
            lblAppFees.Text = appType.AppTypeFee.ToString();

            // Subscribe to event
            ctrlFindLicense1.DataBack += SetLabels;
        }

        private License_ SelectedLicense()
        {
            return ctrlFindLicense1.GetSelectedLicense();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {


            // Renew license if it needs so, else raise error
            License_ selectedLicense = SelectedLicense();

            if(selectedLicense != null && selectedLicense.NeedRenew())
            {
                // Replace license
                selectedLicense.Notes = rtbNotes.Text;
                selectedLicense.Replace(License_.enIssueReasons.Renew, appType);

                // Update labels
                lblRenewedLicenseID.Text = selectedLicense.LicenseID.ToString();
                lblRLAppID.Text = selectedLicense.ApplicationID.ToString();
                newLicense = selectedLicense;

            }
            else
            {
                MessageBox.Show("Selected License does not need renewal", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
        }

        private void SetLabels(object sender, License_ license)
        {
            newLicense = null;
            lblExpDate.Text = DateTime.Today.AddYears(license.licenseClass.ClassValidityLength).ToShortDateString();
            lblLicenseClassFees.Text = license.licenseClass.LicenseClassFee.ToString();
            lblOldLicenseID.Text = license.LicenseID.ToString();
            lblTotalFees.Text = $"{appType.AppTypeFee + license.licenseClass.LicenseClassFee}";
        }

    }
}
