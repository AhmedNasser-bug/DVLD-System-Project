using DVLD_DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLDBuisnessLayer
{
    public class ApplicationType
    {
        public enum enAppTypeIDs { NewLocalDrivingLicense = 1, RenewDrivingLicense = 2, ReplacementForLost = 3,
                            ReplacementForBroken = 4, ReleaseDetainedDrivingLicense = 5, NewInternationalLicense = 6};

        public int AppTypeID { get; set; }
        public string AppTypeTitle {  get; set; }
        public decimal AppTypeFee {  get; set; }

        private ApplicationType(int ApplicationTypeID, string AppTypeTitle, decimal AppTypeFee)
        {
            AppTypeID = ApplicationTypeID;
            this.AppTypeTitle = AppTypeTitle;
            this.AppTypeFee = AppTypeFee;
        }

        public static ApplicationType Find(int AppTypeID)
        {
            string appTypeTitle = "";
            decimal appTypeFee = -1;

            bool result = ApplicationTypesAccess.GetAppTypeByID(AppTypeID, ref appTypeTitle, ref appTypeFee);

            if(result) return new ApplicationType(AppTypeID, appTypeTitle, appTypeFee);
            else return null;
            
        }

        public static bool Update(int AppTypeID, string newAppTypeTitle, decimal newAppTypeFee)
        {
            bool result = ApplicationTypesAccess.UpdateAppType(AppTypeID, newAppTypeTitle, newAppTypeFee);

            return result is true;
        }


        public static DataTable GetAllAppTypes()
        {
            DataTable dtAppTypes = ApplicationTypesAccess.GetAllAppTypes();

            return dtAppTypes;
        }
    }
}
