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

namespace DVLD_System.Forms.ManageDriversForms
{
    public partial class frmShowLicenseHistory : Form
    {
        public frmShowLicenseHistory(Driver driver)
        {
            InitializeComponent();

            // Initialize Controls
            ctrlDisplayPersonDetails1.ShowData(driver.AssosiatedPerson);
            dgvLocalDrivingLicenses.DataSource = License_.GetTableOfDriver(driver.DriverID, false);
            dgvInternationalLicenses.DataSource = License_.GetTableOfDriver(driver.DriverID, true);
        }

    }
}
