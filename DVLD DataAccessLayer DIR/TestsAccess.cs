using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLD_DataAccessLayer
{
    public class TestsAccess
    {
        /// <summary>
        ///  Fills the given ref parameters with the given Test ID if it is found.
        /// </summary>
        /// <param name="TestID"></param>
        /// <param name="TestAppointmentID"></param>
        /// <param name="TestResult"></param>
        /// <param name="Notes"></param>
        /// <param name="CreatedByUserID"></param>
        /// <returns>True if the Test is found, false otherwise.</returns>
        public static bool FindWithID(int TestID, ref int TestAppointmentID, ref bool TestResult, ref string Notes, ref int CreatedByUserID)
        {
            string query = "SELECT * FROM Tests WHERE TestID = @TestID ";

            List<object> Row = ConnectionUtils.GetRow(query, TestID);

            if (Row.Count > 0) 
            {
                TestAppointmentID =Convert.ToInt32(Row[1]);
                TestResult = Convert.ToBoolean(Row[2]);
                Notes = Convert.ToString(Row[3]);
                CreatedByUserID = Convert.ToInt32(Row[4]);

                return true;
            }
            return false;
        }

        /// <summary>
        /// Adds a new Test details to database.
        /// </summary>
        /// <param name="TestAppointmentID"></param>
        /// <param name="TestResult"></param>
        /// <param name="Notes"></param>
        /// <param name="CreatedByUserID"></param>
        /// <returns>Primary key of the new Test.</returns>
        public static int AddTest(int TestAppointmentID, bool TestResult, string Notes, int CreatedByUserID)
        {
            string query = "INSERT INTO Tests " +
                            "VALUES ( @AppointmentID , @Result , @Notes,  @UserID ); " +
                            "SELECT SCOPE_IDENTITY()";
            int PrimaryKey = ConnectionUtils.AddRowToTable(query, TestAppointmentID, TestResult, Notes, CreatedByUserID);

            return PrimaryKey;
        }

        /// <summary>
        /// Get All the applicant tests in the database.
        /// </summary>
        /// <returns>DataTable of all the tests.</returns>
        public static DataTable GetTestsTable()
        {
            string query = "SELECT * FROM Tests";
            DataTable TestsTable = ConnectionUtils.GetTable(query);
            return TestsTable;
        }
    }
}
