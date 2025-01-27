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

namespace DVLD_System.Controls
{
    public partial class ctrlDrivingLicenseApplicationDataData : UserControl
    {
        LocalDrivingLicense curLDL {  get; set; }

        public ctrlDrivingLicenseApplicationDataData()
        {
            InitializeComponent();
        }

        public void InitializeLabels(LocalDrivingLicense LDL_obj, int PassedTests)
        {
            curLDL = LDL_obj;

            lblDriverAppID.Text = curLDL.LDLicenseID.ToString();
            lblLicenseTitle.Text = curLDL.AssociatedLicenseClass.LicenseClassName.ToString();
            lblPassedTests.Text = PassedTests.ToString();

            ctrlShowApplicationInfo1.InitializeLabels(curLDL.AssociatedApp);

        }
    }

}
