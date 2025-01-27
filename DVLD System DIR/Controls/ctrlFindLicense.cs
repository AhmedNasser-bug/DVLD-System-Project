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

namespace DVLD_System.Controls
{
    public partial class ctrlFindLicense : UserControl
    {
        public License_ externalLicense;
        bool IsExternalControl;

        public delegate void DataBackEventHandler(object sender, License_ selectedLicense);
        public event DataBackEventHandler DataBack;

        public ctrlFindLicense()
        {
            InitializeComponent();

            // Initialize combo box items
            cbLicenseIDs.DataSource = License_.GetTable().DefaultView;
            cbLicenseIDs.DisplayMember = "LicenseID";
            if (cbLicenseIDs.Items.Count > 0)
            {
                cbLicenseIDs.SelectedIndex = 0;
                btnFindLicenseID.Visible = true;
                btnFindLicenseID.Enabled = true;
            }
            else
            {
                btnFindLicenseID.Visible = false;
                btnFindLicenseID.Enabled = false;
            }
        }
        /// <summary>
        /// Changes the list of available licneses on the combobox.
        /// </summary>
        /// <param name="dt">Data table containing licenseID column.</param>
        public void ChangeLicensesList(DataTable dt)
        {
            cbLicenseIDs.DataSource = dt.DefaultView;
            cbLicenseIDs.DisplayMember = "LicenseID";
            if(cbLicenseIDs.Items.Count > 0)cbLicenseIDs.SelectedIndex = 0;
        }

        public void DisableSearch()
        {
            btnFindLicenseID.Enabled = false;
            cbLicenseIDs.Enabled = false;
        }

        public License_ GetSelectedLicense()
        {
            if(IsExternalControl) return externalLicense;
            if(cbLicenseIDs.Items.Count == 0) return null;
            

            int selectedLicenseID = Convert.ToInt32(cbLicenseIDs.GetItemText(cbLicenseIDs.SelectedItem));
            License_ selectedLicense = License_.FindWithID(selectedLicenseID);
            return selectedLicense;
        }

        /// <summary>
        /// Disables search and returns the given licenses when calling GetSelectedLicense
        /// </summary>
        /// <param name="license"></param>
        public void SetExternalLicense(License_ license)
        {
            ctrlShowLicense.InitializeLabels(license);
            externalLicense = license;
            cbLicenseIDs.Enabled = false;
            btnFindLicenseID.Enabled = false;
            label1.Enabled = false;
            IsExternalControl = true;
        }

        private void btnFindLicenseID_Click(object sender, EventArgs e)
        {
            // Get Selected License
            License_ selectedLicense = GetSelectedLicense();

            // initialize Control
            if(selectedLicense != null)ctrlShowLicense.InitializeLabels(selectedLicense);
        }

        private void cbLicenseIDs_SelectedIndexChanged(object sender, EventArgs e)
        {
            DataBack?.Invoke(this, GetSelectedLicense());
        }
    }
}
