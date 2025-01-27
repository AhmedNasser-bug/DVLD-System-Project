using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLD_DataAccessLayer
{
    public static class ApplicationTypesAccess
    {
        enum ApplicationTypes
        {
            NewLocalDL,
            RenewDL,
            ReplaceLostDL,
            ReplaceDamagedDL,
            ReleaseDetainedDL,
            NewInternationalDL
        }


        /// <summary>
        /// Returns the application type data with the given id within the given ref parameters.
        /// </summary>
        /// <param name="AppTypeID"></param>
        /// <param name="AppTypeTitle"></param>
        /// <param name="AppTypeFee"></param>
        /// <returns>True if the query is successful, false otherwise.</returns>
        public static bool GetAppTypeByID(int AppTypeID, ref string AppTypeTitle, ref decimal AppTypeFee)
        {
            string query = "SELECT ApplicationTypeTitle, ApplicationFees FROM ApplicationTypes WHERE ApplicationTypeID = @ApplicationTypeID";

            List<object> data = ConnectionUtils.GetRow<int>(query, AppTypeID);

            bool isFound = data.Count > 0;

            if (isFound)
            {
                AppTypeTitle = data[0].ToString();
                AppTypeFee = Convert.ToDecimal(data[1]);
                return true;
            }

            return false;
        }

        /// <summary>
        /// Updates the application type with the given id.
        /// </summary>
        /// <param name="AppTypeID"></param>
        /// <param name="AppTypeTitle"></param>
        /// <param name="AppTypeFee"></param>
        /// <returns>True if the AppType is successfully updated, False otherwise.</returns>
        public static bool UpdateAppType(int AppTypeID, string AppTypeTitle, decimal AppTypeFee)
        {
            string query = "UPDATE ApplicationTypes " +
                           "SET ApplicationTypeTitle = @AppTypeTitle, ApplicationTypeFee = @AppTypeFee " +
                           "WHERE ApplicationTypeID = @AppTypeID";

            bool result = ConnectionUtils.UpdateTableRow(query, AppTypeTitle, AppTypeFee, AppTypeID);

            return result is true;
        }

        /// <summary>
        /// Fetches all application types from the database.
        /// </summary>
        /// <returns>A DataTable object with all present AppTypes.</returns>
        public static DataTable GetAllAppTypes()
        {
            string query = "SELECT * FROM ApplicationTypes";

            DataTable dtAppTypes = ConnectionUtils.GetTable(query);

            return dtAppTypes;
        }

    }
}
