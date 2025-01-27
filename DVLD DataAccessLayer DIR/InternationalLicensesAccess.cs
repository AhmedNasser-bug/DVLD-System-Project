using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLD_DataAccessLayer
{
    public static class InternationalLicensesAccess
    {
        /// <summary>
        /// Find International License with Given InternationalLicenseID and return the values of the columns in the parameters.
        /// </summary>
        /// <param name="InternationLicenseID"></param>
        /// <param name="ApplicationID"></param>
        /// <param name="DriverID"></param>
        /// <param name="IssuedUsingLocalLicenseID"></param>
        /// <param name="IssueDate"></param>
        /// <param name="ExpirationDate"></param>
        /// <param name="IsActive"></param>
        /// <param name="CreatedByUserId"></param>
        /// <returns>True if the license is found, false otherwise.</returns>
        public static bool FindWithID(int InternationLicenseID, ref int ApplicationID, ref int DriverID, ref int IssuedUsingLocalLicenseID, ref DateTime IssueDate, ref DateTime ExpirationDate, ref bool IsActive, ref int CreatedByUserId)
        {
            string query = "SELECT * FROM InternationalLicenses WHERE InternationalLicenseID = @INLID";

            List<object> Row = ConnectionUtils.GetRow(query, InternationLicenseID);
            bool Found = Row.Count > 0;

            if (Found)
            {
                ApplicationID = Convert.ToInt32(Row[1]);
                DriverID = Convert.ToInt32(Row[2]);
                IssuedUsingLocalLicenseID = Convert.ToInt32(Row[3]);
                IssueDate =Convert.ToDateTime(Row[4]);
                ExpirationDate = Convert.ToDateTime(Row[5]);
                IsActive = Convert.ToBoolean(Row[6]);
                CreatedByUserId = Convert.ToInt32(Row[7]);
            }
            return Found;
        }

        /// <summary>
        /// Add a new International License to the database.
        /// </summary>
        /// <param name="ApplicationID"></param>
        /// <param name="DriverID"></param>
        /// <param name="IssuedUsingLocalLicenseID"></param>
        /// <param name="IssueDate"></param>
        /// <param name="ExpirationDate"></param>
        /// <param name="IsActive"></param>
        /// <param name="CreatedByUserId"></param>
        /// <returns>The Primary Key of the new International License.</returns>
        public static int AddNewInternationalLicense(int ApplicationID, int DriverID, int IssuedUsingLocalLicenseID, DateTime IssueDate, DateTime ExpirationDate, bool IsActive, int CreatedByUserId)
        {
            string query = "INSERT INTO InternationalLicenses VALUES" +
                " (@AppID, @DID, @LLICID, @ISSDATE, @EXPDATE, @ISACTIVE, @CRUID)" +
                "SELECT SCOPE_IDENTITY()";
            int PK = ConnectionUtils.AddRowToTable(query, ApplicationID, DriverID, IssuedUsingLocalLicenseID, IssueDate, ExpirationDate, IsActive, CreatedByUserId);
            return PK;
        }

        /// <summary>
        /// Update the values of the International License with the given InternationalLicenseID.
        /// </summary>
        /// <param name="InternationalLicenseID"></param>
        /// <param name="ApplicationID"></param>
        /// <param name="DriverID"></param>
        /// <param name="IssuedUsingLocalLicenseID"></param>
        /// <param name="IssueDate"></param>
        /// <param name="ExpirationDate"></param>
        /// <param name="IsActive"></param>
        /// <param name="CreatedByUserId"></param>
        /// <returns>True if the update was successful, false otherwise.</returns>
        public static bool UpdateInternationLicense(int InternationalLicenseID, int ApplicationID, int DriverID, int IssuedUsingLocalLicenseID, DateTime IssueDate, DateTime ExpirationDate, bool IsActive, int CreatedByUserId)
        {
            string query = "UPDATE InternationalLicenses" +
                " SET ApplicationID = @APPID, DriverID = @DID, IssuedUsingLocalLicenseID = @LLICID, IssueDate = @ISSDATE, ExpirationDate = @EXPDATE, IsActive = @ISACTIVE, CreatedByUserID @CRUID" +
                " WHERE InternationalLicenseID = @INLID";
            bool result = ConnectionUtils.UpdateTableRow(query, ApplicationID, DriverID, IssuedUsingLocalLicenseID, IssueDate, ExpirationDate, IsActive, CreatedByUserId, InternationalLicenseID);
            return result;
        }

        /// <summary>
        /// Delete the International License with the given InternationalLicenseID.
        /// </summary>
        /// <param name="InternationalLicenseID"></param>
        /// <returns>True if the deletion was successful, false otherwise.</returns>
        public static bool Delete(int InternationalLicenseID)
        {
            string query = "DELETE FROM InternationalLicenses WHERE InternationalLicenseID = @INLID";

            bool result = ConnectionUtils.DeleteTableRow(query, InternationalLicenseID);
            return result;
        }

        /// <summary>
        /// Get a DataTable containing all the International Licenses of the given Driver.
        /// </summary>
        /// <param name="InternationalLicenseID"></param>
        /// <returns>DataTable containing all the International Licenses of the given Driver.</returns>
        public static DataTable GetTableOFID(int InternationalLicenseID)
        {
            string query = "SELECT * FROM InternationalLicenses WHERE DriverID = @DriverID";
            return ConnectionUtils.GetTable(query, InternationalLicenseID);
        }

        /// <summary>
        /// Get a DataTable containing all the International Licenses of the given Application.
        /// </summary>
        /// <returns>DataTable containing all the International Licenses of the given Application.</returns>
        public static DataTable GetFullTable()
        {
            string query = "SELECT * FROM InternationalLicenses";
            return ConnectionUtils.GetTable(query);
        }
    }
}
