using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLD_DataAccessLayer
{
    public static class LicenseClassAccess
    {
        public enum DrivingLicenseClasses
        {
            SmallMotorCycle = 1,
            HeavyMotorCycle = 2,
            Ordinary = 3,
            Commercial = 4,
            Agricultural = 5,
            SmallAndMediumBus =6,
            TruckAndHeavyVehicle = 7
        }

        /// <summary>
        /// Add a new License Class to the database and outputs the data of the found license class in the parameters.
        /// </summary>
        /// <param name="LicenseClass_ID"></param>
        /// <param name="ClassName"></param>
        /// <param name="ClassDescription"></param>
        /// <param name="MinimumAllowedAge"></param>
        /// <param name="ClassValidityLength"></param>
        /// <param name="ClassFees"></param>
        /// <returns>True if the license class is found, false otherwise.</returns>
        public static bool GetLicenseClassWithID(int LicenseClass_ID, ref string ClassName, ref string ClassDescription, ref int MinimumAllowedAge, ref int ClassValidityLength, ref decimal ClassFees)
        {
            string query = "SELECT * FROM LicenseClasses " +
                            "WHERE LicenseClassID = @LCID";

            List<object> LCItems = ConnectionUtils.GetRow<int>(query, LicenseClass_ID);

            bool isFound = LCItems.Count > 0;
            
            if (isFound)
            {
                ClassName = LCItems[1].ToString();
                ClassDescription = LCItems[2].ToString();
                MinimumAllowedAge = Convert.ToInt32(LCItems[3]);
                ClassValidityLength = Convert.ToInt32(LCItems[4]);
                ClassFees = Convert.ToDecimal(LCItems[5]);

                return isFound;
            }

            return false;

        }

        /// <summary>
        /// Edits License Class to the database.
        /// </summary>
        /// <param name="LicenseClass_ID"></param>
        /// <param name="NewMinAllowedAge"></param>
        /// <param name="NewValidityLength"></param>
        /// <param name="NewFees"></param>
        /// <returns>True if the license class is successfully edited, false otherwise.</returns>
        public static bool EditLicenseClass(int LicenseClass_ID, int NewMinAllowedAge, int NewValidityLength, decimal NewFees)
        {
            string query = "UPDATE LicenseClass " +
                            "SET MinimumAllowedAge = @MAA, DefaultValidityLength = @VL, ClassFees = @CF" +
                            " WHERE LicenseClassID = @LCID";

            bool result = ConnectionUtils.UpdateTableRow(query, NewMinAllowedAge, NewValidityLength, NewFees, LicenseClass_ID);

            return result;
        }

        /// <summary>
        /// Gets all License Classes from the database.
        /// </summary>
        /// <returns>DataTable containing all License Classes.</returns>
        public static DataTable GetAllLicenseClasses()
        {
            return ConnectionUtils.GetTable("SELECT * FROM LicenseClasses");
        }

    }
}
