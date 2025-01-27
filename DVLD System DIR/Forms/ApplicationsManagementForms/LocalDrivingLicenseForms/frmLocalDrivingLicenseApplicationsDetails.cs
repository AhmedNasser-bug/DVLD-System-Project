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
    public partial class frmLocalDrivingLicenseApplicationsDetails : Form
    {
        public frmLocalDrivingLicenseApplicationsDetails(LocalDrivingLicense LDL_App, int PassedTests)
        {
            InitializeComponent();

            // Initialize labels
            ctrlDrivingLicenseApplicationDataData1.InitializeLabels(LDL_App, PassedTests);
        }
    }
}
