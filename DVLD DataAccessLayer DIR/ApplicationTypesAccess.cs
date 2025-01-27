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

        public static bool UpdateAppType(int AppTypeID, string AppTypeTitle, decimal AppTypeFee)
        {
            string query = "UPDATE ApplicationTypes " +
                           "SET ApplicationTypeTitle = @AppTypeTitle, ApplicationTypeFee = @AppTypeFee " +
                           "WHERE ApplicationTypeID = @AppTypeID";

            bool result = ConnectionUtils.UpdateTableRow(query, AppTypeTitle, AppTypeFee, AppTypeID);

            return result is true;
        }

        public static DataTable GetAllAppTypes()
        {
            string query = "SELECT * FROM ApplicationTypes";

            DataTable dtAppTypes = ConnectionUtils.GetTable(query);

            return dtAppTypes;
        }

    }
}
