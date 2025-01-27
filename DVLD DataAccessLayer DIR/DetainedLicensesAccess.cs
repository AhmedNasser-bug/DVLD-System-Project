using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net.Configuration;
using System.Text;
using System.Threading.Tasks;

namespace DVLD_DataAccessLayer
{
    public static class DetainedLicensesAccess
    {
        /// <summary>
        /// Returns the detain data for the given detain ID inside the given ref parameters.
        /// </summary>
        /// <param name="DetainID"></param>
        /// <param name="LicenseID"></param>
        /// <param name="DetainDate"></param>
        /// <param name="FineFees"></param>
        /// <param name="CreatedByUserID"></param>
        /// <param name="isReleased"></param>
        /// <param name="ReleaseDate"></param>
        /// <param name="ReleasedByUserID"></param>
        /// <param name="ReleaseApplicationID"></param>
        /// <returns>True if the DetainedLicense is found, false otherwise.</returns>
        public static bool FindWithID(int DetainID, ref int LicenseID, ref DateTime DetainDate, ref decimal FineFees, ref int CreatedByUserID, ref bool isReleased,
            ref DateTime ReleaseDate, ref int ReleasedByUserID, ref int ReleaseApplicationID)
        {
            string query = "SELECT * FROM DetainedLicenses WHERE DetainID = @DEID";

            List<object> Row = ConnectionUtils.GetRow(query, DetainID);
            bool Found = Row.Count > 0;

            if (Found) 
            {
                LicenseID = Convert.ToInt32(Row[1]);
                DetainDate = Convert.ToDateTime(Row[2]);
                FineFees = Convert.ToDecimal(Row[3]);
                CreatedByUserID = Convert.ToInt32(Row[4]);
                isReleased = Convert.ToBoolean(Row[5]);

                if (isReleased)
                {
                    ReleaseDate = Convert.ToDateTime(Row[6]);
                    ReleasedByUserID = Convert.ToInt32(Row[7]);
                    ReleaseApplicationID = Convert.ToInt32(Row[8]);
                }
            }

            return Found;
        }

        /// <summary>
        /// Returns the detain data for the given license ID inside the given ref parameters.
        /// </summary>
        /// <param name="LicenseID"></param>
        /// <param name="DetainID"></param>
        /// <param name="DetainDate"></param>
        /// <param name="FineFees"></param>
        /// <param name="CreatedByUserID"></param>
        /// <param name="isReleased"></param>
        /// <param name="ReleaseDate"></param>
        /// <param name="ReleasedByUserID"></param>
        /// <param name="ReleaseApplicationID"></param>
        /// <returns>True if the given license is detained, false otherwise.</returns>
        public static bool FindWithLicenseID(int LicenseID, ref int DetainID, ref DateTime DetainDate, ref decimal FineFees, ref int CreatedByUserID, ref bool isReleased,
            ref DateTime ReleaseDate, ref int ReleasedByUserID, ref int ReleaseApplicationID)
        {
            string query = "SELECT * FROM DetainedLicenses WHERE LicenseID = @LID and IsReleased = 0";

            List<object> Row = ConnectionUtils.GetRow(query, LicenseID);
            bool Found = Row.Count > 0;

            if (Found)
            {
                DetainID = Convert.ToInt32(Row[0]);
                DetainDate = Convert.ToDateTime(Row[2]);
                FineFees = Convert.ToDecimal(Row[3]);
                CreatedByUserID = Convert.ToInt32(Row[4]);
                isReleased = false;
            }

            return Found;
        }

        /// <summary>
        /// Adds a new detained license to the database.
        /// </summary>
        /// <param name="LicenseID"></param>
        /// <param name="DetainDate"></param>
        /// <param name="FineFees"></param>
        /// <param name="CreatedByUserID"></param>
        /// <param name="isReleased"></param>
        /// <param name="ReleaseDate"></param>
        /// <param name="ReleasedByUserID"></param>
        /// <param name="ReleaseApplicationID"></param>
        /// <returns>The DetainID of the newly detained license, -1 in case of failing to add it to the table</returns>
        public static int AddDetainedLicense(int LicenseID, DateTime DetainDate, decimal FineFees, int CreatedByUserID, bool isReleased,
            DateTime ReleaseDate, int ReleasedByUserID, int ReleaseApplicationID)
        {
            string query = "  INSERT INTO DetainedLicenses " +
                            "  VALUES (@LID, @DEDATE, @FINEFEES, @CRUID, @ISRLSD, @RELSDATE, @RELUID, @RELAPPID);" +
                            " SELECT SCOPE_IDENTITY()";

            int DetainedLicenseID = ConnectionUtils.AddRowToTable(query, LicenseID, DetainDate, FineFees, CreatedByUserID, isReleased, ReleaseDate, ReleasedByUserID, ReleaseApplicationID);

            return DetainedLicenseID;
        }

        /// <summary>
        /// Releases the detained license with the given DetainID.
        /// </summary>
        /// <param name="DetainedLicenseID"></param>
        /// <param name="ReleaseDate"></param>
        /// <param name="ReleasedByUserID"></param>
        /// <param name="ReleasedApplicationID"></param>
        /// <returns>True if the release is successful, false otherwise.</returns>
        public static bool ReleaseDetainedLicense(int DetainedLicenseID, DateTime ReleaseDate, int ReleasedByUserID, int ReleasedApplicationID) // TODO: Make SP_ReleaseDetainedLicense for faster querying
        {
            string query = "UPDATE Licenses " +
                           "SET IsActive = 1" +
                           " WHERE LicenseID in (SELECT LicenseID " +
                                                "FROM DetainedLicenses " +
                                                "WHERE DetainID = @DetainID);";

            bool result = ConnectionUtils.UpdateTableRow(query, DetainedLicenseID);

            query = "UPDATE DetainedLicenses " +
                    "SET isReleased = 1, ReleaseDate = @RELDATE, ReleasedByUserID = @RELUID, ReleaseApplicationID = @RELAPPID " +
                    "WHERE DetainID = @DEID ";

            result = result && ConnectionUtils.UpdateTableRow(query, ReleaseDate, ReleasedByUserID, ReleasedApplicationID, DetainedLicenseID);

            return result;
        }

        /// <summary>
        /// Fetches a table containing all the detained licenses in the database.
        /// </summary>
        /// <returns>A DataTable object containing all the detained licenses data.</returns>
        public static DataTable GetTable()
        {
            string query = "SELECT * FROM DetainedLicenses";
            return ConnectionUtils.GetTable(query);
        }
    }
}
