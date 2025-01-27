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

namespace DVLD_System.Forms.ApplicationsManagementForms.ManageTestTypesForms
{
    public partial class frmManageTestTypes : Form
    {

        public frmManageTestTypes()
        {
            InitializeComponent();
        }

        private void RefreshData()
        {
            dgvAllTestTypes.DataSource = TestType.GetAllTestTypes();
        }

        private void frmManageTestTypes_Load(object sender, EventArgs e)
        {
            RefreshData();
        }

        private void editTestTypeToolStripMenuItem_Click(object sender, EventArgs e)
        {

            int selectedID = dgvUtils.GetSelectedPK(ref dgvAllTestTypes);

            Form frmEditTest = new frmEditTestType(selectedID);

            frmEditTest.ShowDialog();

            RefreshData();
        }

        private void dgvAllTestTypes_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
