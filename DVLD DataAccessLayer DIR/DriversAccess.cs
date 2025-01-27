using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLD_DataAccessLayer
{
    public class DriversAccess
    {
        public static bool FindWithID(int DriverID, ref int PersonID, ref int CreatedByUserID, ref DateTime CreatedDate)
        {
            string query = "SELECT * FROM Drivers WHERE DriverID = @DID";

            List<object> Row = ConnectionUtils.GetRow<int>(query, DriverID);

            bool Found = Row.Count > 0;
            if (Found)
            {
                PersonID = Convert.ToInt32(Row[1]);
                CreatedByUserID = Convert.ToInt32(Row[2]);
                CreatedDate = Convert.ToDateTime(Row[3]);
            }
            return Found;
        }

        public static int AddDriver(int PersonID, int CreatedByUserID, DateTime CreateDate)
        {
            string query = "INSERT INTO Drivers " +
                           "VALUES ( @PID, @CUID, @CDATE);" +
                           "SELECT SCOPE_IDENTITY();";
            int DriverId = ConnectionUtils.AddRowToTable(query, PersonID, CreatedByUserID, CreateDate);
            return DriverId;
        }

        public static bool UpdateDriver(int DriverID, int PersonID, int CreatedByUserID, DateTime CreatedDate)
        {
            string query = "UPDATE Drivers " +
                            "SET PersonID = @PID, CreatedByUserID = @CRID, CreatedDate = @CDATE";
            bool success = ConnectionUtils.UpdateTableRow(query, PersonID, CreatedByUserID, CreatedDate);

            return success;
        }

        public static DataTable GetTable()
        {
            string query = "SELECT * FROM Drivers";
            return ConnectionUtils.GetTable(query);
        }

        public static DataTable GetTableView()
        {
            string query = "SELECT * FROM Drivers_View";
            return ConnectionUtils.GetTable(query);
        }
    }
}
