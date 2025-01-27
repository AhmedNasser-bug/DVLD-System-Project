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
    public partial class frmManageDrivers : Form
    {
        public frmManageDrivers()
        {
            InitializeComponent();

            // Initialize Data grid view
            DataTable AllDriversTable = Driver.GetTableView();
            
            ctrlFilterTable.InitializeProperties(cmsDriversChoices, AllDriversTable, new KeyValuePair<string, bool>("NationalNo", true), new KeyValuePair<string, bool>("Full Name", true), new KeyValuePair<string, bool>("DriverID", false));
        }

        private void showDriverDetailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Open ctrlDriverDetails
        }
    }
}
