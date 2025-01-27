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
    public partial class frmAddTestAppointment : Form
    {
        private decimal TotalFees;
        private TestType testType;
        public frmAddTestAppointment(TestType testType, LocalDrivingLicense LDL_App, int PrevAppointments)
        {
            InitializeComponent();

            //Initialize Variables
            lblFees.Text = testType.TestTypeFee.ToString();
            lblLDL_App_ID.Text = LDL_App.LDLicenseID.ToString();
            lblName.Text = LDL_App.AssociatedApp.AssociatedPerson.FullName;
            lblTrials.Text = PrevAppointments.ToString();
            gbRetakeTest.Enabled = false;
            TotalFees = testType.TestTypeFee;

            // Initialize Properties
            this.testType = testType;


            // if there is previous appointments to the same test enable retaking the test and increment the total fees of the appointment
            if (PrevAppointments > 0)
            {
                lblTitle.Text = "Schedule Retake Test";

                gbRetakeTest.Enabled = true;
                TotalFees += 5;
                lblTotalFees.Text = Convert.ToString(TotalFees);
            }
        }

        // --------------------------------------------------- Button behaviors
        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            TestAppointment appointment = new TestAppointment();

            // Initialize test Data
            appointment.PaidFees = (float)TotalFees;
            appointment.IsLocked = false;
            appointment.LocalDrivingLicenseApplicationID = Convert.ToInt32(lblLDL_App_ID.Text);
            appointment.TestTypeID = testType.TestTypeID;
            appointment.CreatedByUserID = User.GlobalUser.UserID;
            appointment.AppointmentDate = dtpAppointmentDate.Value;
            
            // Save to database
            bool saveSuccess = appointment.Save();

            if (saveSuccess)
            {
                MessageBox.Show($"Appointment saved successfully with ID: {appointment.TestAppointmentID}", "Success!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Save Failed (Fatal Error return to the developer)", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            Close(); // Close the form
        }
    }
}
