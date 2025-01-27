using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLD_DataAccessLayer
{
    public static class LocalDrivingLicenseAccess
    {
        /// <summary>
        /// Gets The Local Driving License Application With the given ID and fills the given parameters with the row data if it is found.
        /// </summary>
        /// <param name="LDL_ID"></param>
        /// <param name="Application_ID"></param>
        /// <param name="License_Class_ID"></param>
        /// <returns>True if the local driving license application is found, false otherwise</returns>
        public static bool FindWithID(int LDL_ID, ref int Application_ID, ref int License_Class_ID)
        {
            string query = "SELECT ApplicationID, LicenseClassID" +
                            " FROM dbo.LocalDrivingLicenseApplications " +
                            "WHERE LocalDrivingLicenseApplicationID = @LDL_ID";
            
            List<object> Row_Items = ConnectionUtils.GetRow<int>(query, LDL_ID);

            bool notFound = Row_Items.Count == 0;

            if(notFound is false)
            {
                Application_ID = Convert.ToInt32(Row_Items[0]);
                License_Class_ID = Convert.ToInt32(Row_Items[1]);

                return notFound is false;
            }

            return notFound;


        }

        /// <summary>
        /// Returns true if the application is valid, false otherwise.
        /// </summary>
        /// <param name="Applicant_ID">The applicant you want to check the validity of the license class application</param>
        /// <param name="LicenseClassID"></param>
        /// <returns></returns>
        public static bool ValidApplication(int Applicant_ID, int LicenseClassID)
        {
            string query = "select 1 from dbo.LocalDrivingLicenseApplications Where ApplicationID in (select Applications.ApplicationID from Applications " +
                            " Where Applications.ApplicantPersonID = @ApplicantID AND ApplicationStatus <> 2 ) and LicenseClassID = @licenseClassID ";

            bool result = ConnectionUtils.IsRowExist(query, Applicant_ID, LicenseClassID);

            return !result;
        }

        /// <summary>
        /// ADDS A ROW TO APPLICATION THEN ADDS THE ROW TO THE LDL TABLE ITSELF.
        /// </summary>
        /// <returns>the ID of the newly added row.</returns>
        public static int AddLDLApplication(int ApplicationID, int LicenseClassID)
        {

            string query = "INSERT INTO  dbo.LocalDrivingLicenseApplications" +
                            " VALUES ( @ApplicationID, @LicenseClass ); " +
                            "SELECT SCOPE_IDENTITY()";

            int LDLApp_ID = ConnectionUtils.AddRowToTable(query, ApplicationID, LicenseClassID);

            return LDLApp_ID;
        }

        /// <summary>
        /// Deletes the Local Driving License Application with the given ID.
        /// </summary>
        /// <param name="LDL_ID"></param>
        /// <returns>True if the application is deleted, false otherwise</returns>
        public static bool DeleteLDLApplication(int LDL_ID)
        {
            string query = "DELETE FROM LocalDrivingLicenseApplications " +
                            "WHERE LocalDrivingLicenseApplicationID = @LDL_ID ";
            
            bool result = ConnectionUtils.DeleteTableRow(query, LDL_ID);

            return result;
        }

        /// <summary>
        /// Updates the Local Driving License Application with the given ID.
        /// </summary>
        /// <param name="LDL_ID"></param>
        /// <param name="Application_ID"></param>
        /// <param name="LicenseClassID"></param>
        /// <returns>True if the application is updated, false otherwise</returns>
        public static bool UpdateLDLApplication(int LDL_ID, int Application_ID, int LicenseClassID)
        {
            string query = "UPDATE dbo.LocalDrivingLicenseApplications " +
                           "SET ApplicationID = @AppID ,LicenseClassID = @LicenseClassID " +
                           "WHERE LocalDrivingLicenseApplicationID = @LDL_ID ";

            bool result = ConnectionUtils.UpdateTableRow(query, Application_ID, LicenseClassID, LDL_ID);

            return result;
        }

        /// <summary>
        /// Returns a DataTable of all the Local Driving License Applications.
        /// </summary>
        /// <returns>DataTable of all the Local Driving License Applications.</returns>
        public static DataTable GetTable()
        {
            return ConnectionUtils.GetTable("SELECT * FROM dbo.LocalDrivingLicenseApplications;");
        }

        /// <summary>
        /// Returns a DataTable of all the Local Driving License Applications with detailed information.
        /// </summary>
        /// <returns>DataTable of all the Local Driving License Applications with detailed information.</returns>
        public static DataTable GetDetailedTableView()
        {
            return ConnectionUtils.GetTable("SELECT * FROM dbo.LocalDrivingLicenseApplications_View;");
        }
    }
}
