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
        /// <summary>
        /// Returns the country data for the given country ID In the ref countryName parameter.
        /// </summary>
        /// <param name="countryID"></param>
        /// <param name="countryName"></param>
        /// <returns>True if the country with the given id is found,false otherwise.</returns>
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

        /// <summary>
        /// Returns the country ID for the given country name in the ref countryID parameter.
        /// </summary>
        /// <param name="countryName"></param>
        /// <param name="countryID"></param>
        /// <returns>True if the country is found, false otherwise.</returns>
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

        /// <summary>
        /// Fetches a table containing all the countries in the database.
        /// </summary>
        /// <returns>A DataTable object containing all Countries data.</returns>
        public static DataTable GetCountriesTable()
        { 
            DataTable countriesTable = ConnectionUtils.GetTable("select * from Countries");

            return countriesTable;
        }
    }
}
