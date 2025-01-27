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
        /// <summary>
        /// Find a driver with the given ID and fills the given parameters with the found values.
        /// </summary>
        /// <param name="DriverID"></param>
        /// <param name="PersonID"></param>
        /// <param name="CreatedByUserID"></param>
        /// <param name="CreatedDate"></param>
        /// <returns>True if the driver is found, false otherwise.</returns>
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

        /// <summary>
        /// Add a new driver to the database.
        /// </summary>
        /// <param name="PersonID"></param>
        /// <param name="CreatedByUserID"></param>
        /// <param name="CreateDate"></param>
        /// <returns>The ID of the newly added driver, -1 if the driver is not added.</returns>
        public static int AddDriver(int PersonID, int CreatedByUserID, DateTime CreateDate)
        {
            string query = "INSERT INTO Drivers " +
                           "VALUES ( @PID, @CUID, @CDATE);" +
                           "SELECT SCOPE_IDENTITY();";
            int DriverId = ConnectionUtils.AddRowToTable(query, PersonID, CreatedByUserID, CreateDate);
            return DriverId;
        }

        /// <summary>
        /// Update the driver with the given ID.
        /// </summary>
        /// <param name="DriverID"></param>
        /// <param name="PersonID"></param>
        /// <param name="CreatedByUserID"></param>
        /// <param name="CreatedDate"></param>
        /// <returns> True if the driver is successfully added, false otherwise.</returns>
        public static bool UpdateDriver(int DriverID, int PersonID, int CreatedByUserID, DateTime CreatedDate)
        {
            string query = "UPDATE Drivers " +
                            "SET PersonID = @PID, CreatedByUserID = @CRID, CreatedDate = @CDATE";
            bool success = ConnectionUtils.UpdateTableRow(query, PersonID, CreatedByUserID, CreatedDate);

            return success;
        }

        /// <summary>
        /// Gets a DataTable containing all the drivers in the database.
        /// </summary>
        /// <returns>A DataTable object containing all the drivers data.</returns>
        public static DataTable GetTable()
        {
            string query = "SELECT * FROM Drivers";
            return ConnectionUtils.GetTable(query);
        }

        /// <summary>
        /// Gets a DataTable containing all the drivers full data in the database.
        /// </summary>
        /// <returns>A DataTable object containing what the Drivers view have in the database.</returns>
        public static DataTable GetTableView()
        {
            string query = "SELECT * FROM Drivers_View";
            return ConnectionUtils.GetTable(query);
        }
    }
}
