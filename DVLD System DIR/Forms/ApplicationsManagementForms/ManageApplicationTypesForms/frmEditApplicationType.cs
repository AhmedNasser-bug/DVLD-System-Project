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
    public partial class frmEditApplicationType : Form
    {
        private int AppID;
        public frmEditApplicationType(int CurAppTypeID)
        {
            InitializeComponent();
            AppID = CurAppTypeID;
            lblAppTypeID.Text = AppID.ToString();
            tbAppTypeTitle.Text = ApplicationType.Find(CurAppTypeID).AppTypeTitle;
        }

        private void btnConfirm_Click(object sender, EventArgs e)
        {
            string newAppTypeTitle = tbAppTypeTitle.Text;
            decimal newAppTypeFee = Convert.ToDecimal(mtbAppTypeFee.Text);

            bool resutlt = ApplicationType.Update(AppID, newAppTypeTitle, newAppTypeFee);

            if (resutlt) 
            {
                MessageBox.Show("Successfully Updated the Application Type", "Notice", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Error Updating The Application Type", "Notice", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
