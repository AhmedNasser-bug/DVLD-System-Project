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
    public partial class ctrlInternatiolDrivingLicenseDetails : UserControl
    {
        public ctrlInternatiolDrivingLicenseDetails()
        {
            InitializeComponent();
        }
        
        public void InitializeLabels(ref InternationalLicense IntLicense)
        {
            lblInternationalLicenseAppID.Text = IntLicense.ApplicationID.ToString();
            lblInternationalLicenseID.Text = IntLicense.InternationalLicenseID.ToString();
            lblGender.Text = IntLicense.AssociatedDriver.AssosiatedPerson.Gender.ToString();
            lblName.Text = IntLicense.AssociatedDriver.AssosiatedPerson.FullName.ToString();
            lblNationalNo.Text = IntLicense.AssociatedDriver.AssosiatedPerson.NationalNo.ToString();
            lblExpDate.Text = IntLicense.ExpirationDate.ToShortDateString();
            lblIsActive.Text = IntLicense.IsActive.ToString();
            lblDateOfBirth.Text = IntLicense.AssociatedDriver.AssosiatedPerson.DateOfBirth.ToShortDateString();
            lblDriverID.Text = IntLicense.AssociatedDriver.DriverID.ToString();
            lblIssueDate.Text = IntLicense.IssueDate.ToShortDateString();
            lblLocalLicense.Text = IntLicense.IssuedByLocalLicenseID.ToString();
        }

    }
}
