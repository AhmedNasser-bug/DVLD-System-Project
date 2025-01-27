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

namespace DVLD_System.Forms.ApplicationsManagementForms.LocalDrivingLicenseForms
{
    public partial class frmEditTestAppointment : Form
    {
        TestAppointment appointment;
        public frmEditTestAppointment(TestAppointment testAppointment)
        {
            InitializeComponent();

            // Initialize variables
            appointment = testAppointment;
            cbLocked.Checked = appointment.IsLocked;
            dtpAppointmentDate.Value = appointment.AppointmentDate;
            dtpAppointmentDate.MinDate = DateTime.Now;
        }

        // -------------------------------------------------- Events
        private void btnSave_Click(object sender, EventArgs e)
        {
            // Update appointment data
            appointment.IsLocked = cbLocked.Checked;
            appointment.AppointmentDate = dtpAppointmentDate.Value;

            bool saveResult = appointment.Save();
            if (saveResult)
            {
                MessageBox.Show("\aAppointment Saved Successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("\aError Saving Appointment", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            Close();

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
