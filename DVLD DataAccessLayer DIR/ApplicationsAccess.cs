using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace DVLD_DataAccessLayer
{
    public static class ApplicationsAccess
    {
        public enum ApplicationStatus
        {
            Canceled = 2,
            New = 1,
            Completed = 3
        }


        public static bool FindApplicationByID(int App_ID, ref int ApplicantPerson_ID, ref DateTime ApplicationDate,
                                        ref int ApplicationType_ID, ref short ApplicationStatus, ref DateTime LastStatusUpdate, ref decimal PaidFee, ref int CreatedByUser_ID)
        {
            string query = "SELECT * FROM Applications WHERE ApplicationID = @AppID";

            List<object> RowData = ConnectionUtils.GetRow(query, App_ID);

            bool notFound = RowData.Count == 0;

            if(notFound is false)
            {
                ApplicantPerson_ID = Convert.ToInt32(RowData[1]);
                ApplicationDate = Convert.ToDateTime(RowData[2]);
                ApplicationType_ID = Convert.ToInt32(RowData[3]);
                ApplicationStatus = Convert.ToInt16(RowData[4]);
                LastStatusUpdate = Convert.ToDateTime(RowData[5]);
                PaidFee = Convert.ToDecimal(RowData[6]);
                CreatedByUser_ID = Convert.ToInt32(RowData[7]);
            }

            return notFound is false;

        }

        public static int AddApplication(int ApplicantPerson_ID, DateTime ApplicationDate,
                                        int ApplicationType_ID, int ApplicationStatus, DateTime LastStatusDate, decimal PaidFees, int CreatedByUser_ID)
        {
            string query = "INSERT INTO Applications " +
                            "VALUES ( @APID , @AD , @ATID ,  @AS , @LSU , @PF , @CBUID ); " +
                            "SELECT SCOPE_IDENTITY()";

            int ApplicationID = ConnectionUtils.AddRowToTable(query, ApplicantPerson_ID, ApplicationDate, ApplicationType_ID, ApplicationStatus, LastStatusDate, PaidFees, CreatedByUser_ID);

            return ApplicationID;
        }
        

        public static bool DeleteApplication(int ApplicationID)
        {
            string query = "DELETE FROM Applications " +
                           "WHERE ApplicationID = @AID";

            bool result = ConnectionUtils.DeleteTableRow(query, ApplicationID);

            return result;
        }

        public static bool UpdateStatus(int ApplicationID, ApplicationStatus NewStatus )
        {
            string query = "UPDATE Applications " +
                            "SET ApplicationStatus = @AS" +
                            " WHERE ApplicationID = @AID";
            
            bool result = ConnectionUtils.UpdateTableRow(query, NewStatus, ApplicationID);

            return result;
        }

        public static bool UpdateApplication(int ApplicationID, int ApplicantPerson_ID, DateTime ApplicationDate,
                                        int ApplicationType_ID, int ApplicationStatus, DateTime LastStatusDate, decimal PaidFees, int CreatedByUser_ID)
        {
                string query = "UPDATE Applications " +
                                "SET ApplicantPersonID = @APID, ApplicationDate = @AD, ApplicationTypeID = @ATID, ApplicationStatus = @AS, LastStatusDate = @LSU, PaidFees = @PF, CreatedByUserID = @CBUID" +
                                " WHERE ApplicationID = @AID";

                bool result = ConnectionUtils.UpdateTableRow(query, ApplicantPerson_ID, ApplicationDate, ApplicationType_ID, ApplicationStatus, LastStatusDate, PaidFees, CreatedByUser_ID, ApplicationID);

                return result ;
        }

        public static DataTable GetApplicationsTable()
        {
            string query = "SELECT * FROM Applications";

            return ConnectionUtils.GetTable(query);
        }
    }
}
