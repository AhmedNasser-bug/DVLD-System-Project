using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLD_DataAccessLayer
{
    public static class CountriesAccess
    {
        public static bool GetCountryByID(int countryID, ref string countryName)
        {
            SqlConnection connection = ConnectionUtils.InitiateConnection();

            string query = "select CountryName from Countries where CountryID = @CountryID";
            SqlCommand command = new SqlCommand(query, connection);

            ConnectionUtils.AddArgsToCommand(ref command, query, countryID);

            countryName = ConnectionUtils.ExecuteScalar(ref command, ref connection);

            bool isFound = countryName != "";
            return isFound;
        }

        public static bool GetCountryByName(string countryName, ref int countryID)
        {
            SqlConnection connection = ConnectionUtils.InitiateConnection();

            string query = "select CountryName from Countries where countryName = @countryName";
            SqlCommand command = new SqlCommand(query, connection);

            ConnectionUtils.AddArgsToCommand(ref command, query, countryName);

            countryName = ConnectionUtils.ExecuteScalar(ref command, ref connection);

            bool isFound = countryName != "";
            return isFound;
        }

        public static DataTable GetCountriesTable()
        { 
            DataTable countriesTable = ConnectionUtils.GetTable("select * from Countries");

            return countriesTable;
        }
    }
}
