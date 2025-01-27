using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLD_DataAccessLayer
{
    public class TestsAppointmentsAccess
    {
        /// <summary>
        /// Fills the given ref parameters with the given TestAppointment ID if it is found.s
        /// </summary>
        /// <returns>True if the TestAppointment is found, false otherwise.</returns>
        public static bool GetTestAppointmentWithID(int TestAppointmentID, ref int TestTypeID, ref int LDLAppID, ref DateTime AppointmentDate, ref float PaidFees, ref int CreatedByUserID, ref bool IsLocked)
        {
            string query = "SELECT TestTypeID, LocalDrivingLicenseApplicationID, AppointmentDate, PaidFees, CreatedByUserID, IsLocked FROM TestAppointments  WHERE TestAppointmentID = @TestAppointmentID";

            List<object> row = ConnectionUtils.GetRow(query, TestAppointmentID);

            bool found = row.Count > 0;

            if(found)
            {
                TestTypeID = Convert.ToInt32(row[0]);
                LDLAppID = Convert.ToInt32(row[1]);
                AppointmentDate =  Convert.ToDateTime(row[2]);
                PaidFees = Convert.ToInt32(row[3]);
                CreatedByUserID = Convert.ToInt32(row[4]);
                IsLocked = Convert.ToBoolean(row[5]);
            }

            return found;
        }

        /// <summary>
        /// Adds a new Test Appointment to the database.
        /// </summary>
        /// <returns>Primary key of the new Test Appointment.</returns>
        public static int AddTestAppointment(int TestTypeID, int LDLAppID, DateTime ApplicationDate, float PaidFees, int CreatedByUserID, bool IsLocked)
        {
            string query = "INSERT INTO TestAppointments" +
                            " VALUES ( @TestTypeID, @LDLAppID, @AppointmentDate, @PaidFees, @UserID, @IsLocked );" +
                            " SELECT SCOPE_IDENTITY()";
            int PrimaryKey = ConnectionUtils.AddRowToTable(query, TestTypeID, LDLAppID, ApplicationDate, PaidFees, CreatedByUserID, IsLocked);

            return PrimaryKey;
        }

        /// <summary>
        /// Edits the Test Appointment with the given ID.
        /// </summary>
        /// <returns>True if the Test Appointment is found and edited, false otherwise.</returns>
        public static bool EditTestAppointment(int TestAppointmentID, DateTime AppointmentDate, bool IsLocked)
        {
            string query = "UPDATE TestAppointments" +
                " SET AppointmentDate = @AppointMentDate, IsLocked = @isLocked " +
                    " Where TestAppointmentID = @TAppID";
            bool result = ConnectionUtils.UpdateTableRow(query, AppointmentDate, IsLocked, TestAppointmentID);
            return result;
        }

        /// <summary>
        /// Get All the applicant tests in the database.
        /// </summary>
        /// <param name="LDL_ID"></param>
        /// <param name="TestTypeID"></param>
        /// <returns>DataTable of all the tests.</returns>
        public static DataTable GetTableOfID(int LDL_ID, int TestTypeID)
        {
            string query = "SELECT * FROM TestAppointments WHERE LocalDrivingLicenseApplicationID = @LDL_ID and TestTypeID = @TestTypeID";

            return ConnectionUtils.GetTable(query, LDL_ID, TestTypeID);
        }

        /// <summary>
        /// Returns True if the given local driving license application is eligible to add a new appointment.
        /// </summary>
        public static bool CanAddAppointmentTo(int LDL_ID)
        {
            string query = "SELECT 1 FROM TestAppointments WHERE LocalDrivingLicenseApplicationID = @LDL_ID And IsLocked = 0";

            bool CanNotAdd = ConnectionUtils.IsRowExist(query, LDL_ID);

            return !CanNotAdd;
        }
    }
}
