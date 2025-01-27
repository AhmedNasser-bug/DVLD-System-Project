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
    public partial class frmTakeTest : Form
    {
        public TestAppointment TestAppointment {  get; set; }
        public LocalDrivingLicense LocalDrivingLicense {  get; set; }
        public delegate void DataBackEventHandler(object sender, bool PassedTest);
        public event DataBackEventHandler DataBack;

        public frmTakeTest(int Trials, LocalDrivingLicense localDrivingLicense, TestAppointment testAppointment, TestType testType)
        {
            InitializeComponent();

            // Initialize Variables
            lblFees.Text = testType.TestTypeFee.ToString();
            lblLDL_App_ID.Text = localDrivingLicense.LDLicenseID.ToString();
            lblTrials.Text = Trials.ToString();
            lblName.Text = localDrivingLicense.AssociatedApp.AssociatedPerson.FullName;
            lblTestDate.Text = testAppointment.AppointmentDate.ToString();
            lblTitle.Text = $"Take {testType.TestTypeName}";

            // Set Propereties
            TestAppointment = testAppointment;
            LocalDrivingLicense = localDrivingLicense;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            // Initialize new test
            Test test = new Test();
            test.Notes = rtbNotes.Text;
            test.TestResult = rbFailed.Checked ? false: true;
            test.CreatedByUserID = User.GlobalUser.UserID;
            test.TestAppointmentID = TestAppointment.TestAppointmentID;
            TestAppointment.IsLocked = true;
            LocalDrivingLicense.AssociatedApp.PaidFees += Convert.ToDecimal(lblFees.Text);

            // Save test into database
            bool saveResult = TestAppointment.Save();
            if (saveResult)
            {
                saveResult = test.AddTest();
                if (saveResult)
                {
                    MessageBox.Show("Test Taken successfully", "Success!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Error saving Test Results (Appointment is locked)", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Error Saving appointment data", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            DataBack?.Invoke(this, test.TestResult);
            Close();

        }
    }
}
