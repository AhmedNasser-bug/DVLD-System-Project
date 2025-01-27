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
    public partial class frmReleaseLicense : Form
    {
        DetainedLicense _ExternalLicense = null;

        public frmReleaseLicense()
        {
            InitializeComponent();

            // Initialize controls
            DataTable dtDetainedLicenses = DetainedLicense.GetAllDetainedLicenses();
            ctrlFindLicense.ChangeLicensesList(dtDetainedLicenses);
            ctrlFindLicense.DataBack += SetLabels;
        }

        public frmReleaseLicense(DetainedLicense detainedLicense)
        {
            InitializeComponent();

            // Initialize controls
            ctrlFindLicense.SetExternalLicense(detainedLicense.AssociatedLicense);
            lblCreatedBy.Text = User.GlobalUser.UserName;
            lblDetainDate.Text = detainedLicense.DetainDate.ToShortDateString();
            lblDetainID.Text = detainedLicense.DetainID.ToString();
            lblLicenseID.Text = detainedLicense.LicenseID.ToString();
            lblFineFees.Text = detainedLicense.DetainFees.ToString();
            lblAppFees.Text = ApplicationType.Find(((int)ApplicationType.enAppTypeIDs.ReleaseDetainedDrivingLicense)).AppTypeFee.ToString();
            lblTotal.Text = $"{Convert.ToDecimal(lblAppFees.Text) + detainedLicense.DetainFees}";
        }

        private void SetLabels(object sender, License_ ChosenLicense)
        {
            DetainedLicense detainedLicense = DetainedLicense.FindWithLicenseID(ChosenLicense.LicenseID); 

            lblCreatedBy.Text = User.GlobalUser.UserName;
            lblDetainDate.Text = detainedLicense.DetainDate.ToShortDateString();
            lblDetainID.Text = detainedLicense.DetainID.ToString();
            lblLicenseID.Text = detainedLicense.LicenseID.ToString();
            lblFineFees.Text = detainedLicense.DetainFees.ToString();
            lblAppFees.Text = ApplicationType.Find(((int)ApplicationType.enAppTypeIDs.ReleaseDetainedDrivingLicense)).AppTypeFee.ToString();
            lblTotal.Text = $"{Convert.ToDecimal(lblAppFees.Text) + detainedLicense.DetainFees}";
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            License_ selectedLicense = ctrlFindLicense.GetSelectedLicense();

            if (selectedLicense == null)
            {
                MessageBox.Show("There is no detained licenses at the moment!", "Notice", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (!selectedLicense.IsDetained())
            {
                MessageBox.Show("Selected licesne is no detained choose another one!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else
            {
                DetainedLicense licenseDetain = DetainedLicense.FindWithLicenseID(selectedLicense.LicenseID);

                if (licenseDetain != null)
                {
                    bool saveResult = licenseDetain.Release();

                    if (saveResult)
                    {
                        MessageBox.Show("Successfully released license!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("Error releasing license!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show("Selected licesne is no detained choose another one!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
