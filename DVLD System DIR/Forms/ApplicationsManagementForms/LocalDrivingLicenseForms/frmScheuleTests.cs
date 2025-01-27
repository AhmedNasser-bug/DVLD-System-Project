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
using System.Windows.Navigation;

namespace DVLD_System.Forms.ApplicationsManagementForms.LocalDrivingLicenseForms
{
    public partial class frmScheuleTests : Form
    {
        LocalDrivingLicense LocalDrivingLicenseApp {  get; set; }
        TestType testType {  get; set; }
        DataTable dtPreviousAppointments {  get; set; }
        bool PassedTest {  get; set; }

        public frmScheuleTests(LocalDrivingLicense localDrivingLicense, TestType testType, int PassedTests)
        {
            InitializeComponent();

            // Initialize variables
            lblTitle.Text = $"Schedule {testType.TestTypeName}";
            ctrlDrivingLicenseApplicationDataData.InitializeLabels(localDrivingLicense, PassedTests);
            LocalDrivingLicenseApp = localDrivingLicense;
            this.testType = testType;
            RefreshTable();
        }

        // ------------------------------------------------ Helper Methods
        void RefreshTable()
        {
            dtPreviousAppointments = TestAppointment.GetTableOf(LocalDrivingLicenseApp.LDLicenseID, testType.TestTypeID);

            dgvAppointments.DataSource = dtPreviousAppointments.DefaultView;
            
            
        }

        bool HasOnlyLockedAppointments()
        {
            return TestAppointment.CanAddAppointment(LocalDrivingLicenseApp.LDLicenseID);
        }

        int PreviousAppointments()
        {
            return dgvAppointments.RowCount > 0 ? DataTableUtils.GetFilteredTable(dtPreviousAppointments, "IsLocked", "1").Rows.Count : 0;
        }

        void OpenAddAppointmentForm()
        {
            if (HasOnlyLockedAppointments())
            {
                // Add appointment if Applicant have no Open appointments
                Form frmScheduleNewAppointment = new frmAddTestAppointment(testType, LocalDrivingLicenseApp, PreviousAppointments());
                frmScheduleNewAppointment.ShowDialog();
                RefreshTable();
            }
            else
            {
                MessageBox.Show("There IS ALREADY A pending open Appointment", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        TestAppointment GetSelectedAppointment()
        {
            int App_ID = dgvUtils.GetSelectedPK(ref dgvAppointments);
            return TestAppointment.Find(App_ID);
        }

        void ProcessTestResult(object sender, bool Result)
        {
            PassedTest = Result;
        }

        void TakeTest()
        {
            TestAppointment selectedTestAppointment = GetSelectedAppointment();
            
            // Check if appointment is Unlocked
            if (selectedTestAppointment == null || selectedTestAppointment.IsLocked)
            {
                MessageBox.Show("Error Taking Test, if the appointment is not locked Contact the Developer", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Take test if its a valid appointment
            frmTakeTest FrmTakeTest = new frmTakeTest(PreviousAppointments(), LocalDrivingLicenseApp, selectedTestAppointment, testType);
            FrmTakeTest.DataBack += ProcessTestResult;
            FrmTakeTest.ShowDialog();

            // Close Form if Applicant Passed the test
            if (PassedTest)
            {
                Close();
            }

            // Refresh Table if Applicant did not pass
            RefreshTable();
        }

        // ------------------------------------------------ Button methods
        private void takeTestToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TakeTest();
        }

        private void btnAddAppointment_Click(object sender, EventArgs e)
        {
            OpenAddAppointmentForm();
        }

        private void changeAppointmentDateToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form frmEditAppointment = new frmEditTestAppointment(GetSelectedAppointment());
            frmEditAppointment.ShowDialog();
            RefreshTable();
        }

    }
}
