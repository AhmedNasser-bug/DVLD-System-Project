using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DVLD_System.Forms.ManageDriversForms;
using DVLDBuisnessLayer;

namespace DVLD_System.Forms.ApplicationsManagementForms
{
    public partial class frmDetainLicense : Form
    {
        private DetainedLicense newlyAddedLicense = null;

        public frmDetainLicense()
        {
            InitializeComponent();

            // Initialize Controls
            DataTable dtActiveLicenses = License_.GetActiveLicensesTable();
            ctrlFindLicense.ChangeLicensesList(dtActiveLicenses);

            // Initialize labels
            lblDetainDate.Text = DateTime.Now.ToShortDateString();
            lblCreatedBy.Text = User.GlobalUser.UserName;

            // Subscribe to events
            ctrlFindLicense.DataBack += SetLabels;
            
        }
        // ----------------------------------------------------- Helper Methods
        private void SetLabels(object sender, License_ selectedLicense)
        {
            lblLicenseID.Text = selectedLicense.LicenseID.ToString();
        }

        // ----------------------------------------------------- Events
        private void btnSave_Click(object sender, EventArgs e)
        {
            License_ selectedLicense = ctrlFindLicense.GetSelectedLicense();

            if (selectedLicense.IsDetained())
            {
                MessageBox.Show("Selected licesne is already detained choose another one!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if(!ValidateFees()) return;

            // Initialize new detain application
            DetainedLicense newDetain = new DetainedLicense();
            newDetain.LicenseID = selectedLicense.LicenseID;
            newDetain.DetainFees = Convert.ToInt32(mtbFineFees.Text);
            newDetain.DetainDate = DateTime.Now;
            newDetain.CreatedByUserID = User.GlobalUser.UserID;
            
            // save to database
            bool saveResult = newDetain.ConfirmDetain();

            if (saveResult)
            {
                MessageBox.Show($"License Detained successfully with detain ID :{newDetain.DetainID}", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                newlyAddedLicense = newDetain;
                lklShowNewLicenseDetails.Enabled = true;
            }
            else
            {
                MessageBox.Show("Error saving the detain!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void lklShowLicenseHistory_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmShowLicenseHistory frm = new frmShowLicenseHistory(ctrlFindLicense.GetSelectedLicense().driver);
            frm.ShowDialog();
        }

        private void lklShowNewLicenseDetails_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if(newlyAddedLicense != null)
            {
                frmShowLicenseDetails frm = new frmShowLicenseDetails(newlyAddedLicense.AssociatedLicense);
                frm.ShowDialog();
            }
        }

        private bool ValidateFees()
        {
             if(mtbFineFees.Text.Length == 0)
             {
                errorProvider.SetError(mtbFineFees, "Must have a value");
                mtbFineFees.Focus();
                return false;
             }
            return true;
        }

        
    }
}
