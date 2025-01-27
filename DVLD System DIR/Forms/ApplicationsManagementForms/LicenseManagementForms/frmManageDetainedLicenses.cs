using DVLD_System.Forms.ManageDriversForms;
using DVLD_System.Forms.ManagePeopleForms;
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

namespace DVLD_System.Forms.ApplicationsManagementForms.LicenseManagementForms
{
    public partial class frmManageDetainedLicenses : Form
    {
        public frmManageDetainedLicenses()
        {
            InitializeComponent();

            // Initialize controls
            DataTable dtDetainedLicenses = DetainedLicense.GetAllDetainedLicenses();
            ctrlFilterTable.InitializeProperties(contextMenuStrip, dtDetainedLicenses, new KeyValuePair<string, bool>("DetainID", false), new KeyValuePair<string, bool>("LicenseID", false), new KeyValuePair<string, bool>("IsReleased", false));

        }
        // ---------------------------------------------- Helper Methods
        private DetainedLicense SelectedDetainedLicense()
        {
            return DetainedLicense.FindWithID(ctrlFilterTable.GetSelectedPK());
        }

        private void RefreshTable()
        {
            DataTable dtDetainedLicenses = DetainedLicense.GetAllDetainedLicenses();
            ctrlFilterTable.RefreshTable(dtDetainedLicenses);
        }

        // ---------------------------------------------- Events
        private void showPersonDetailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Person selectedPerson = SelectedDetainedLicense().AssociatedLicense.driver.AssosiatedPerson;

            frmPersonDetails frm = new frmPersonDetails(selectedPerson);
            frm.ShowDialog();
        }

        private void showLicenseDetailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            License_ selectedLicense = SelectedDetainedLicense().AssociatedLicense;

            frmShowLicenseDetails frm = new frmShowLicenseDetails(selectedLicense);
            frm.ShowDialog();
        }

        private void showLicenseHistoryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Driver selectedDriver = SelectedDetainedLicense().AssociatedLicense.driver;

            frmShowLicenseHistory frm = new frmShowLicenseHistory(selectedDriver);
            frm.ShowDialog();
        }

        private void releaseLicenseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DetainedLicense detain = SelectedDetainedLicense();
            if (detain.IsReleased)
            {
                MessageBox.Show("Selected detain is already released!", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            frmReleaseLicense frm = new frmReleaseLicense(detain);
            frm.ShowDialog();
            RefreshTable(); 
        }

        private void btnDetainLicesne_Click(object sender, EventArgs e)
        {
            frmDetainLicense frm = new frmDetainLicense();
            frm.ShowDialog();
            RefreshTable();
        }

        private void btnReleaseLicense_Click(object sender, EventArgs e)
        {
            frmReleaseLicense frm = new frmReleaseLicense();
            frm.ShowDialog();
            RefreshTable();
        }
    }
}
