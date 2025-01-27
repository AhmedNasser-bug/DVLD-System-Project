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

namespace DVLD_System.Forms
{
    public partial class frmShowLicenseDetails : Form
    {
        public frmShowLicenseDetails(License_ license)
        {
            InitializeComponent();

            // Initialize labels
            ctrlShowLicense1.InitializeLabels(license);
        }
    }
}
