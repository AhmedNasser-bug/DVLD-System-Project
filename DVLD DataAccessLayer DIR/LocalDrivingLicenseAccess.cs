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

        public static bool ValidApplication(int Applicant_ID, int LicenseClassID)
        {
            string query = "select 1 from dbo.LocalDrivingLicenseApplications Where ApplicationID in (select Applications.ApplicationID from Applications " +
                            " Where Applications.ApplicantPersonID = @ApplicantID AND ApplicationStatus <> 2 ) and LicenseClassID = @licenseClassID ";

            bool result = ConnectionUtils.IsRowExist(query, Applicant_ID, LicenseClassID);

            return !result;
        }
        /// <summary>
        /// ADDS A ROW TO APPLICATION THEN ADDS THE ROW TO THE LDL sTABLE ITSELF
        /// </summary>
        /// <returns></returns>
        public static int AddLDLApplication(int ApplicationID, int LicenseClassID)
        {

            string query = "INSERT INTO  dbo.LocalDrivingLicenseApplications" +
                            " VALUES ( @ApplicationID, @LicenseClass ); " +
                            "SELECT SCOPE_IDENTITY()";

            int LDLApp_ID = ConnectionUtils.AddRowToTable(query, ApplicationID, LicenseClassID);

            return LDLApp_ID;
        }

        public static bool DeleteLDLApplication(int LDL_ID)
        {
            string query = "DELETE FROM LocalDrivingLicenseApplications " +
                            "WHERE LocalDrivingLicenseApplicationID = @LDL_ID ";
            
            bool result = ConnectionUtils.DeleteTableRow(query, LDL_ID);

            return result;
        }
       
        public static bool UpdateLDLApplication(int LDL_ID, int Application_ID, int LicenseClassID)
        {
            string query = "UPDATE dbo.LocalDrivingLicenseApplications " +
                           "SET ApplicationID = @AppID ,LicenseClassID = @LicenseClassID " +
                           "WHERE LocalDrivingLicenseApplicationID = @LDL_ID ";

            bool result = ConnectionUtils.UpdateTableRow(query, Application_ID, LicenseClassID, LDL_ID);

            return result;
        }


        public static DataTable GetTable()
        {
            return ConnectionUtils.GetTable("SELECT * FROM dbo.LocalDrivingLicenseApplications;");
        }
        
        public static DataTable GetDetailedTableView()
        {
            return ConnectionUtils.GetTable("SELECT * FROM dbo.LocalDrivingLicenseApplications_View;");
        }
    }
}
