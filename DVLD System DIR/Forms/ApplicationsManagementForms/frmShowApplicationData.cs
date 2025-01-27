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

namespace DVLD_System.Forms.ApplicationsManagementForms
{
    public partial class frmShowApplicationData : Form
    {
        public frmShowApplicationData(Application_ application)
        {
            InitializeComponent();

            // Initialize variables
            ctrlShowAppData.InitializeLabels(application);
        }
    }
}
