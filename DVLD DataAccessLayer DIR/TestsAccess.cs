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

        public static int AddTest(int TestAppointmentID, bool TestResult, string Notes, int CreatedByUserID)
        {
            string query = "INSERT INTO Tests " +
                            "VALUES ( @AppointmentID , @Result , @Notes,  @UserID ); " +
                            "SELECT SCOPE_IDENTITY()";
            int PrimaryKey = ConnectionUtils.AddRowToTable(query, TestAppointmentID, TestResult, Notes, CreatedByUserID);

            return PrimaryKey;
        }

        public static DataTable GetTestsTable()
        {
            string query = "SELECT * FROM Tests";
            DataTable TestsTable = ConnectionUtils.GetTable(query);
            return TestsTable;
        }
    }
}
