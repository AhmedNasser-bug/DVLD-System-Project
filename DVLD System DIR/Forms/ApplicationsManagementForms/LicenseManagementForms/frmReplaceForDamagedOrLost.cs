using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics.Eventing.Reader;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DVLD_System.Forms.ManageDriversForms;
using DVLDBuisnessLayer;

namespace DVLD_System.Forms.ApplicationsManagementForms
{
    public partial class frmReplaceForDamagedOrLost : Form
    {
        License_ newLicense;
        ApplicationType appType;
        License_.enIssueReasons IssueReason;

        public frmReplaceForDamagedOrLost()
        {
            InitializeComponent();

            // Initialize props
            appType = ApplicationType.Find(((int)ApplicationType.enAppTypeIDs.ReplacementForBroken));
            IssueReason = License_.enIssueReasons.Broken;

            // Initialize controls
            rbBroken.Checked = true;
            ctrlFindLicense1.DataBack += ChangeLabels;

            // Initialize labels
            lblAppDate.Text = DateTime.Now.ToShortDateString();
            License_ selectedLicense = SelectedLicense();
            if (selectedLicense != null)
            {
                lblOldLicenseID.Text = selectedLicense.LicenseID.ToString();
                lblAppFees.Text = appType.AppTypeFee.ToString();
                lblCreatedBy.Text = User.GlobalUser.UserName;
            }
            else
            {
                ctrlFindLicense1.Enabled = false;
                btnSave.Enabled = false;
                lklShowLicenseHistory.Enabled = false;
            }
    
        }

        // ------------------------------------------------------------- Helper Methods
        private License_ SelectedLicense()
        {
            return ctrlFindLicense1.GetSelectedLicense();
        }

        private void ChangeLabels(object sender, License_ selectedLicense)
        {
            newLicense = null;
            lblOldLicenseID.Text = selectedLicense.LicenseID.ToString();
            lblAppFees.Text = appType.AppTypeFee.ToString();
            lblCreatedBy.Text = User.GlobalUser.UserName;
            lklShowNewLicenseDetails.Enabled = true;
        }

        private void SetAppTypeLabels()
        {
            if (rbBroken.Checked)
            {
                appType = ApplicationType.Find(((int)ApplicationType.enAppTypeIDs.ReplacementForBroken));
                IssueReason = License_.enIssueReasons.Broken;
            }
            else
            {
                appType = ApplicationType.Find(((int)ApplicationType.enAppTypeIDs.ReplacementForLost));
                IssueReason = License_.enIssueReasons.Lost;
            }

            lblAppFees.Text = appType.AppTypeFee.ToString();
        }

        // ------------------------------------------------------------- Events
        private void rbBroken_CheckedChanged(object sender, EventArgs e)
        {
            // Change Fees Labels
            SetAppTypeLabels();
        }

        private void lklShowNewLicenseDetails_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            // if the new license is not null, open license details form for it
            if(newLicense != null)
            {
             frmShowLicenseDetails frm = new frmShowLicenseDetails(newLicense);
             frm.ShowDialog();
            }
        }

        private void lklShowLicenseHistory_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            // open license history for selected license
            License_ selectedLicense = SelectedLicense();

            frmShowLicenseHistory frm = new frmShowLicenseHistory(selectedLicense.driver);
            frm.ShowDialog();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            // Replace license for selected license
            License_ selectedLicense = SelectedLicense();

            bool saveResult = selectedLicense.Replace(IssueReason, appType);

            if (saveResult)
            {
                MessageBox.Show($"Replaced License Successfully with new ID: {selectedLicense.LicenseClassID}", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                newLicense = selectedLicense;
                lklShowNewLicenseDetails.Enabled = true;
            }
            else
            {
                MessageBox.Show("Error saving new license!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void rbLost_CheckedChanged(object sender, EventArgs e)
        {
            SetAppTypeLabels();
        }
    }
}
