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

        public static int AddDetainedLicense(int LicenseID, DateTime DetainDate, decimal FineFees, int CreatedByUserID, bool isReleased,
            DateTime ReleaseDate, int ReleasedByUserID, int ReleaseApplicationID)
        {
            string query = "  INSERT INTO DetainedLicenses " +
                            "  VALUES (@LID, @DEDATE, @FINEFEES, @CRUID, @ISRLSD, @RELSDATE, @RELUID, @RELAPPID);" +
                            " SELECT SCOPE_IDENTITY()";

            int DetainedLicenseID = ConnectionUtils.AddRowToTable(query, LicenseID, DetainDate, FineFees, CreatedByUserID, isReleased, ReleaseDate, ReleasedByUserID, ReleaseApplicationID);

            return DetainedLicenseID;
        }

        public static bool ReleaseDetainedLicense(int DetainedLicenseID, DateTime ReleaseDate, int ReleasedByUserID, int ReleasedApplicationID)
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

        public static DataTable GetTable()
        {
            string query = "SELECT * FROM DetainedLicenses";
            return ConnectionUtils.GetTable(query);
        }
    }
}
