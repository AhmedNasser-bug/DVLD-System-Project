using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DVLD_System.Utils;
using DVLDBuisnessLayer;

namespace DVLD_System.Controls
{
    public partial class ctrlShowLicense : UserControl
    {
        public ctrlShowLicense()
        {
            InitializeComponent();
        }

        public void InitializeLabels(License_ license)
        {
            lblNotes.Text = license.Notes;
            lblIsDetained.Text = license.IsDetained().ToString();
            lblNationalNo.Text = license.driver.AssosiatedPerson.NationalNo;
            lblName.Text = license.driver.AssosiatedPerson.FullName;
            lblLicenseID.Text = license.LicenseID.ToString();
            lblLicenseClass.Text = license.licenseClass.LicenseClassName;
            lblIssueReason.Text = license.strIssueReason();
            lblIssueDate.Text = license.IssueDate.ToShortDateString();
            lblIsActive.Text = license.IsActive.ToString();
            lblGender.Text = license.application.AssociatedPerson.Gender.ToString();
            lblExpiryDate.Text = license.ExpirationDate.ToShortDateString();
            lblDriverID.Text = license.DriverID.ToString();
            lblDateOfBirth.Text = license.application.AssociatedPerson.DateOfBirth.ToShortDateString();
            if(license.driver.AssosiatedPerson.ImagePath != "") pbPersonalPhoto.Image = Image.FromFile(license.driver.AssosiatedPerson.ImagePath);
        }
    }
}
