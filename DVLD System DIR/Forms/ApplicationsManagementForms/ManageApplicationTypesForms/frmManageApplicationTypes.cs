using DVLD_System.Utils;
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

namespace DVLD_System.Forms.ApplicationsManagementForms.ManageApplicationTypesForms
{
    public partial class frmManageApplicationTypes : Form
    {
        public frmManageApplicationTypes()
        {
            InitializeComponent();
        }


        private void RefreshData()
        {
            dgvAllAppTypes.DataSource = ApplicationType.GetAllAppTypes();
        }


        private void frmManageApplicationTypes_Load(object sender, EventArgs e)
        {
            RefreshData();
        }

        

        private void updateApplicationTypeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int selectedAppTypeID = dgvUtils.GetSelectedPK(ref dgvAllAppTypes);

            Form frmEditAppType = new frmEditApplicationType(selectedAppTypeID);

            frmEditAppType.ShowDialog();

            RefreshData();
        }
    }
}
