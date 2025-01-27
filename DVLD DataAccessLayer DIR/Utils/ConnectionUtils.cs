using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;
using DVLD_DataAccessLayer.Utils;

namespace DVLD_DataAccessLayer
{
    internal static class ConnectionUtils // Tailored to DVLD System
    {
        public static string ConnectionString = "Data Source=.;Initial Catalog=DVLD;Persist Security Info=True;User ID=sa;Password=123456;Encrypt=False;TrustServerCertificate=True";
        public static string[] NullValues = {"-1", "", DateTime.MinValue.ToString()};
        private static WinLogger Logger = new WinLogger("SQL ERROR", "Application");

        private static bool IsNull(string value)
        {
            foreach(string Null in NullValues)
            {
                if (Null == value) return true;
            }
            return false;
        }

        private static List<string> _GetParamNames(string query)
        {
            List<string> paramNames = new List<string>();

            StringBuilder Current = new StringBuilder();
            
            for(int i = 0; i < query.Length; i++)
            {
                if (query[i] == '@')
                {
                    while (i < query.Length && query[i] != ' ' && query[i] != ',' && query[i] != ';' && query[i] != ')')
                    {
                        Current.Append(query[i]);
                        i++;
                    }

                    paramNames.Add(Current.ToString());
                    Current = new StringBuilder();
                }

            }
            return paramNames;

        }


        public static SqlConnection InitiateConnection()
        {
            try
            {
                // Connect with credintials specified by the connection string
                SqlConnection connection = new SqlConnection(ConnectionString);
                connection.Open();
                return connection;
            }
            catch (Exception ex)
            {
                Logger.Error(ex);
            }
            return null;
        }
            
        public static int EnsureNonQuerySuccess(ref SqlCommand Command,ref SqlConnection connection)
        {
            int rowsAffected = 0;
            try
            {
                rowsAffected = Command.ExecuteNonQuery();

            }
            catch (Exception ex)
            {
                Logger.Error(ex);
            }
            finally
            {
                connection.Close();
            }
            return rowsAffected;
        }

        public static string ExecuteScalar(ref SqlCommand Command,ref SqlConnection connection)
        {
            string result = null;
            try
            {
                result = Convert.ToString(Command.ExecuteScalar());
            }
            catch (Exception ex)
            {
               Logger.Error(ex);
            }
            finally
            {
                connection.Close();
            }
            return result;
        }

        public static void AddArgsToCommand(ref SqlCommand command, string query, params object[] paramaters)
        {
            List<string> queryParameters = _GetParamNames(query);
            for(int idx = 0; idx < paramaters.Length; idx++)
            {
                object param = paramaters[idx];
                if(!IsNull(param.ToString()))command.Parameters.AddWithValue(queryParameters[idx], param);
                else command.Parameters.AddWithValue(queryParameters[idx], DBNull.Value);
            }
        }

        public static List<object> GetRow<T>(string query, T PrimaryKey)
        {
            SqlConnection connection = InitiateConnection();

            SqlCommand command = new SqlCommand(query, connection);

            AddArgsToCommand(ref command, query, PrimaryKey);

            List<object> rowItems = new List<object>();

            try
            {
                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    for(int idx = 0; idx < reader.FieldCount; idx++)
                    { 
                        rowItems.Add(reader[idx]);
                    }
                    
                }
                reader.Close();
            }
            catch (Exception ex)
            {
                Logger.Error(ex);
            }
            finally
            {
                connection.Close();
            }
            return rowItems;
        }

        /// <summary>
        /// Adds a row to table using the given query
        /// </summary>
        /// <param name="query">The query used to add the row</param>
        /// <param name="parameters">The data of the added row</param>
        /// <returns>The primary key of the added table</returns>
        public static int AddRowToTable(string query,params object[] parameters)
        {
            SqlConnection connection = InitiateConnection();

            SqlCommand command = new SqlCommand(query, connection);

            AddArgsToCommand(ref command, query, parameters);

            string result = ExecuteScalar(ref command, ref connection);

            if (result is null)
            {
                return -1;
            }
            return Convert.ToInt32(result);

        }
       
        public static bool UpdateTableRow(string query, params object[] parameters)
        {
            SqlConnection connection = InitiateConnection();

            SqlCommand command = new SqlCommand(query, connection);

            AddArgsToCommand(ref command, query, parameters);

            int RowsAffected = EnsureNonQuerySuccess(ref command, ref connection);

            return RowsAffected > 0;

        }
        
        public static bool DeleteTableRow(string query, params object[] parameters)
        {
            SqlConnection connection = InitiateConnection();

            SqlCommand command = new SqlCommand(query, connection);

            AddArgsToCommand(ref command, query, parameters);

            int RowsAffected = EnsureNonQuerySuccess(ref command, ref connection);

            return RowsAffected > 0;

        }
        
        public static bool IsRowExist(string query, params object[] parameters)
        {
            SqlConnection connection = InitiateConnection();

            SqlCommand command = new SqlCommand(query, connection);

            AddArgsToCommand(ref command, query, parameters);
            bool isFound = ExecuteScalar(ref command, ref connection) != "";

            return isFound;

        }
       
        public static DataTable GetTable(string query, params object[] parameters)
        {
            DataTable dt = new DataTable();

            SqlConnection connection = InitiateConnection();


            SqlCommand command = new SqlCommand(query, connection);

            AddArgsToCommand(ref command, query, parameters);

            try
            {
                SqlDataReader reader = command.ExecuteReader();

                if (reader.HasRows)
                {
                    dt.Load(reader);
                }

                reader.Close();

            }
            catch (Exception ex)
            {
                Logger.Error(ex);
            }
            finally
            {
                connection.Close();
            }

            return dt;
        }
    }
}
