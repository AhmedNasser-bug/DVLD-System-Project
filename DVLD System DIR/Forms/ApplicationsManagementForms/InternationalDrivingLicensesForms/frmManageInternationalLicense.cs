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
using DVLD_System.Forms.ManagePeopleForms;
using DVLD_System.Forms.ManageDriversForms;

namespace DVLD_System.Forms.ApplicationsManagementForms.InternationalDrivingLicensesForms
{
    public partial class frmManageInternationalLicense : Form
    {
        public frmManageInternationalLicense()
        {
            InitializeComponent();

            // Initialize Controls
            DataTable dtIntrLicense = InternationalLicense.GetAllInternationalLicenses();
            ctrlFilterTable.InitializeProperties(cmsInternationalLicenseMenu, dtIntrLicense, new KeyValuePair<string, bool>("InternationalLicenseID", false), new KeyValuePair<string, bool>("ApplicationID", false), new KeyValuePair<string, bool>("DriverID", false));
        }

        private InternationalLicense SelectedLicense()
        {
            InternationalLicense IntrLicense = InternationalLicense.Find(ctrlFilterTable.GetSelectedPK());
            return IntrLicense;
        }

        private void showLicenseHistoryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Get driver details
            Driver selectedDriver = SelectedLicense().AssociatedDriver;

            // Open History Form for selected ID;
            Form frmLicenseHistory = new frmShowLicenseHistory(selectedDriver);
            frmLicenseHistory.ShowDialog();
                
        }

        private void showLicenseDetailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Get selected LicenseID
            InternationalLicense selectedIntrLicense = SelectedLicense();

            // Open Details form for selected licens
            Form frmLicenseDetails = new frmInternationalLicenseDetails(selectedIntrLicense);
            frmLicenseDetails.ShowDialog();
        }

        private void showPersonDetailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Get selected Person
            Person selectedPerson = SelectedLicense().AssociatedDriver.AssosiatedPerson;

            // Open Person Details Form For Selected Person
            Form frmShowPersonDet = new frmPersonDetails(selectedPerson);
            frmShowPersonDet.ShowDialog();

        }

        private void btnAddIntLicesnse_Click(object sender, EventArgs e)
        {
            Form frmAddLicesnse = new frmAddInternationalDrivingLicense();
            frmAddLicesnse.ShowDialog();
        }
    }
}
