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
    public partial class frmEditTestType : Form
    {
        TestType curTestType;
        public frmEditTestType(int TestTypeID)
        {
            InitializeComponent();
            curTestType = TestType.Find(TestTypeID);
            lblTestTypeID.Text = TestTypeID.ToString();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnConfirm_Click(object sender, EventArgs e)
        {
            curTestType.TestTypeFee = Convert.ToDecimal(mtbTestTypeFee.Text);
            curTestType.TestTypeDesc = rtbTestType.Text;
            curTestType.TestTypeName = tbTestTypeTitle.Text;

            bool result = curTestType.Save();

            if (result) 
            {
                MessageBox.Show("Succesfully updated Test Type", "Notice", MessageBoxButtons.OK, MessageBoxIcon.Information );
            }
            else
            {
                MessageBox.Show("Failed  to update Test Type", "Notice", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

    }
}
