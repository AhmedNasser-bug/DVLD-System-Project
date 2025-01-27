using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace DVLD_DataAccessLayer
{
    public static class LicensesAccess
    {
        /// <summary>
        /// Gets The License With the given ID.
        /// </summary>
        /// <param name="LicenseID">The primary key of the license</param>
        /// <param name="ApplicationID"></param>
        /// <param name="DriverID"></param>
        /// <param name="LicenseClassID"></param>
        /// <param name="IssueReason"></param>
        /// <param name="PaidFees"></param>
        /// <param name="CreatedByUserID"></param>
        /// <param name="IsActive"></param>
        /// <param name="IssueDate"></param>
        /// <param name="ExpirationDate"></param>
        /// <param name="Notes"></param>
        /// <returns>boolean value indicating wether the row is found or not.</returns>
        public static bool FindWithLicenseID(int LicenseID, ref int ApplicationID, ref int DriverID, ref int LicenseClassID, ref int IssueReason, ref decimal PaidFees, ref int CreatedByUserID, ref bool IsActive,
                            ref DateTime IssueDate, ref DateTime ExpirationDate, ref string Notes)
        {
            string query = "SELECT [LicenseID], [ApplicationID], [DriverID], [LicenseClass], [IssueDate], [ExpirationDate], [Notes], [PaidFees], [IsActive], [IssueReason], [CreatedByUserID] FROM Licenses WHERE LicenseID = @LID";
            List<object> Row = ConnectionUtils.GetRow(query, LicenseID);

            // Check if the row is valid then get the values of the row
            bool Found = Row.Count > 0;
            if(Found)
            {
                ApplicationID = Convert.ToInt32(Row[1]);
                DriverID = Convert.ToInt32(Row[2]);
                LicenseClassID = Convert.ToInt32(Row[3]);
                IssueDate = Convert.ToDateTime(Row[4]);
                ExpirationDate = Convert.ToDateTime(Row[5]);
                Notes = Convert.ToString(Row[6]);
                PaidFees = Convert.ToDecimal(Row[7]);
                IsActive = Convert.ToBoolean(Row[8]);
                IssueReason = Convert.ToInt32(Row[9]);
                CreatedByUserID = Convert.ToInt32(Row[10]);
            }
            return Found;
            
        }

        /// <summary>
        /// Gets The License With the given ApplicationID.
        /// </summary>
        /// <param name="LicenseID">The primary key of the license</param>
        /// <param name="ApplicationID"></param>
        /// <param name="DriverID"></param>
        /// <param name="LicenseClassID"></param>
        /// <param name="IssueReason"></param>
        /// <param name="PaidFees"></param>
        /// <param name="CreatedByUserID"></param>
        /// <param name="IsActive"></param>
        /// <param name="IssueDate"></param>
        /// <param name="ExpirationDate"></param>
        /// <param name="Notes"></param>
        /// <returns>boolean value indicating wether the row is found or not, 
        /// fills the given parameters with the row data if it is found.
        /// </returns>
        public static bool FindWithApplicationID(int ApplicationID, ref int LicenseID, ref int DriverID, ref int LicenseClassID, ref int IssueReason, ref decimal PaidFees, ref int CreatedByUserID, ref bool IsActive,
                            ref DateTime IssueDate, ref DateTime ExpirationDate, ref string Notes)
        {
            string query = "SELECT [ApplicationID], [LicenseID], [DriverID], [LicenseClass], [IssueDate], [ExpirationDate], [Notes], [PaidFees], [IsActive], [IssueReason], [CreatedByUserID] FROM Licenses WHERE ApplicationID = @APPID";
            List<object> Row = ConnectionUtils.GetRow(query, ApplicationID);

            // Check if the row is valid then get the values of the row
            bool Found = Row.Count > 0;
            if (Found)
            {
                LicenseID = Convert.ToInt32(Row[1]);
                DriverID = Convert.ToInt32(Row[2]);
                LicenseClassID = Convert.ToInt32(Row[3]);
                IssueDate = Convert.ToDateTime(Row[4]);
                ExpirationDate = Convert.ToDateTime(Row[5]);
                Notes = Convert.ToString(Row[6]);
                PaidFees = Convert.ToDecimal(Row[7]);
                IsActive = Convert.ToBoolean(Row[8]);
                IssueReason = Convert.ToInt32(Row[9]);
                CreatedByUserID = Convert.ToInt32(Row[10]);
            }
            return Found;

        }

        /// <summary>
        /// Adds a new license to the database.
        /// </summary>
        /// <param name="ApplicationID"></param>
        /// <param name="DriverID"></param>
        /// <param name="LicenseClassID"></param>
        /// <param name="IssueReason"></param>
        /// <param name="PaidFees"></param>
        /// <param name="CreatedByUserID"></param>
        /// <param name="IsActive"></param>
        /// <param name="IssueDate"></param>
        /// <param name="ExpirationDate"></param>
        /// <param name="Notes"></param>
        /// <returns>The ID of the newly added license.</returns>
        public static int AddNewLicense(int ApplicationID, int DriverID, int LicenseClassID, int IssueReason, decimal PaidFees, int CreatedByUserID, bool IsActive,
                            DateTime IssueDate, DateTime ExpirationDate, string Notes)
        {
            string query = "INSERT INTO Licenses " +
                            "VALUES (@APPID, @DID, @LCLASS, @ISSDATE, @EXPDATE, @NOTES, @PAIDFEES, @ISACTIVE, @ISSREAS, @CRUID); " +
                            "SELECT SCOPE_IDENTITY()";
            int LicenseID = ConnectionUtils.AddRowToTable(query, ApplicationID, DriverID, LicenseClassID, IssueDate, ExpirationDate, Notes, PaidFees, IsActive, IssueReason, CreatedByUserID);
            return LicenseID;
        }
        
        /// <summary>
        /// The Local driving license history of a driver
        /// </summary>
        /// <param name="DriverID">ID Of the driver of the licenses table</param>
        /// <returns>DataTable of the license history of the given driver</returns>
        public static DataTable GetTableOf(int DriverID)
        {
            string query = "SELECT * FROM Licenses WHERE DriverID = @DID and ApplicationID in (SELECT ApplicationID FROM Applications WHERE ApplicationTypeID = 1 )";

            return ConnectionUtils.GetTable(query, DriverID);
        }

        /// <summary>
        /// The International driving license history of a driver
        /// </summary>
        /// <param name="DriverID">ID Of the driver of the licenses table</param>
        /// <returns>DataTable of the license history of the given driver</returns>
        public static DataTable GetInternationalTableOf(int DriverID)
        {
            string query = "SELECT * FROM InternationalLicenses WHERE DriverID = @DID";

            return ConnectionUtils.GetTable(query, DriverID);
        }

        /// <summary>
        /// Gets the full table of licenses in the system.
        /// </summary>
        /// <returns>DataTable of all the licenses in the system</returns>
        public static DataTable GetFullTable()
        {
            string query = "SELECT * FROM Licenses";
            return ConnectionUtils.GetTable(query);
        }

        /// <summary>
        /// Gets the full table of Active licenses in the system.
        /// </summary>
        /// <returns>DataTable of all the Active licenses in the system</returns>
        public static DataTable GetActiveLicenses()
        {
            string query = "SELECT * FROM Licenses Where IsActive = 1";
            return ConnectionUtils.GetTable(query);
        }

        /// <summary>
        /// Returns True if the license with the given license id is detained, false otherwise.
        /// </summary>
        /// <param name="LicenseID"></param>
        public static bool IsDetained(int LicenseID)
        {
            string query = "SELECT 1 FROM DetainedLicenses WHERE LicenseID = @LID and IsReleased = 0";
            return ConnectionUtils.IsRowExist(query, LicenseID);
        }

        /// <summary>
        /// Returns True if the given license have an international pair, false otherwise.
        /// </summary>
        /// <param name="LicenseID"></param>
        public static bool HaveInternationalPair(int LicenseID)
        {
            string query = "SELECT LicenseID FROM Licenses WHERE LicenseID in (SELECT LicenseID FROM InternationalLicenses) and LicenseID = @LID";
            return ConnectionUtils.IsRowExist(query, LicenseID);
        }

        /// <summary>
        /// Detains the license with the given licenseID.
        /// </summary>
        /// <param name="LicenseID"></param>
        /// <returns>True if the given license is successfully detained, false otherwise</returns>
        public static bool DetainLicense(int LicenseID)
        {
            string query = "UPDATE Licenses " +
                            "SET IsActive = 0 " +
                            "WHERE LicenseID = @LID";

            return ConnectionUtils.UpdateTableRow(query, LicenseID);
        }

        }
}
