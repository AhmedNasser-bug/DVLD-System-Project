using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLD_DataAccessLayer
{
    public static class PeopleAccess
    {
        public static bool GetPersonByNationalNo(string NationalNo, ref int PersonID, ref string FirstName, ref string SecondName, ref string ThirdName, ref string LastName
                                        ,ref DateTime DateOfBirth, ref bool Gender, ref string Address,
                                        ref string Phone, ref string Email, ref int CountryID, ref string ImagePath)
        {
            SqlConnection connection = ConnectionUtils.InitiateConnection();


            string query = "SELECT * FROM People " +
                "WHERE  NationalNo = @NationalNo";

            SqlCommand command = new SqlCommand(query, connection);
            ConnectionUtils.AddArgsToCommand(ref command, query, NationalNo);

            bool IsFound = false;
            try
            {
                SqlDataReader reader = command.ExecuteReader();
                if (reader.Read())
                { 
                    IsFound = true;
                    PersonID = reader.GetInt32(0);
                    NationalNo = reader.GetString(1);
                    FirstName = reader.GetString(2);
                    SecondName= reader.GetString(3);
                    ThirdName = reader.GetString(4);
                    LastName = reader.GetString(5);
                    DateOfBirth = reader.GetDateTime(6);
                    Gender = reader.GetBoolean(7);
                    Address = reader.GetString(8);
                    Phone = reader.GetString(9);
                    Email = reader.GetString(10);
                    CountryID = reader.GetInt32(11);
                    ImagePath = reader.GetString(12);

                }
                reader.Close();
            }
            catch (Exception ex) 
            { 
                ////////////////////////
            }
            finally
            {
                connection.Close();
            }

            return IsFound;

        }

        public static bool GetPersonByID(int PersonID, ref string NationalNo, ref string FirstName, ref string SecondName, ref string ThirdName, ref string LastName
                                        , ref DateTime DateOfBirth, ref bool Gender, ref string Address,
                                        ref string Phone, ref string Email, ref int CountryID, ref string ImagePath)
        {
            SqlConnection connection = ConnectionUtils.InitiateConnection();

            string query = "select * from People where PersonID = @PersonID";
            SqlCommand command = new SqlCommand(query, connection);
            ConnectionUtils.AddArgsToCommand(ref command, query, PersonID);

            bool IsFound = false;
            try
            {
                SqlDataReader reader = command.ExecuteReader();
                if (reader.Read())
                {
                    IsFound = true;
                    NationalNo = reader.GetString(1);
                    FirstName = reader.GetString(2);
                    SecondName = reader.GetString(3);
                    ThirdName = reader.GetString(4);
                    LastName = reader.GetString(5);
                    DateOfBirth = reader.GetDateTime(6);
                    Gender = reader.GetBoolean(7);
                    Address = reader.GetString(8);
                    Phone = reader.GetString(9);
                    Email = reader.GetString(10);
                    CountryID = reader.GetInt32(11);
                    ImagePath = reader.GetString(12);

                }
                reader.Close();
            }
            catch (Exception ex)
            {
                ////////////////////////
            }
            finally
            {
                connection.Close();
            }

            return IsFound;

        }

        public static int AddNewPerson(string NationalNo, string FirstName, string SecondName, string ThirdName, string LastName,
                                         DateTime DateOfBirth, bool Gender, string Address,
                                        string Phone, string Email, int CountryID, string ImagePath)
        {
            SqlConnection connection = ConnectionUtils.InitiateConnection();

            string query = "Insert into People " +
                            "Values (@NationalNo, @FirstName, @SecondName, @ThirdName, @LastName," +
                            " @DateOfBirth, @Gender, @Address, @Phone, @Email, @CountryID, @ImagePath );" +
                            "select Scope_Identity()";

            SqlCommand command = new SqlCommand(query, connection);

            ConnectionUtils.AddArgsToCommand(ref command, query, NationalNo, FirstName, SecondName, ThirdName, LastName, DateOfBirth, Gender, Address, Phone, Email, CountryID, ImagePath);

            string result = ConnectionUtils.ExecuteScalar(ref command, ref connection);

            if (result == "")
            {
                return -1;
            }
            return Convert.ToInt32(result);
        }

        
        public static bool UpdatePerson(int PersonID, string FirstName, string SecondName, string ThirdName, string LastName,
                                        string NationalNo, DateTime DateOfBirth, bool Gender, string Address, string Phone, 
                                        string Email, int CountryID, string ImagePath) 
        {
            SqlConnection connection = ConnectionUtils.InitiateConnection();

            string query = "Update People " +
                            "Set FirstName = @FirstName, SecondName = @SecondName, ThirdName = @ThirdName, LastName = @LastName," +
                            " NationalNo = @NationalNo, DateOfBirth = @DateOfBirth, Gender = @Gender, Address = @Address, Phone = @Phone," +
                            " Email = @Email, NationalityCountryID = @NCountryID, ImagePath = @ImagePath " +
                            "Where PersonID = @PersonID";

            SqlCommand command = new SqlCommand(query, connection);

            ConnectionUtils.AddArgsToCommand( ref command, query, FirstName, SecondName, ThirdName, LastName, NationalNo, DateOfBirth, Gender, Address, Phone, Email, CountryID, ImagePath, PersonID);

            int RowsAffected =  ConnectionUtils.EnsureNonQuerySuccess(ref command,ref connection);

            return RowsAffected > 0;
        }

        public static int DeletePerson(int PersonID)
        {
            SqlConnection connection = ConnectionUtils.InitiateConnection();

            string query = " delete from People where PersonID = @PersonID";

            SqlCommand command = new SqlCommand(query, connection);

            ConnectionUtils.AddArgsToCommand(ref command, query, PersonID);

            int RowsAffected = ConnectionUtils.EnsureNonQuerySuccess(ref command, ref connection);

            return RowsAffected;
        }

        public static bool IsPersonExist(int PersonID)      
        {
            SqlConnection connection = ConnectionUtils.InitiateConnection();

            string query = "select 1 from People where PersonID = @PersonID";

            SqlCommand command = new SqlCommand(query, connection);

            ConnectionUtils.AddArgsToCommand(ref command, query, PersonID);

            bool isFound = ConnectionUtils.ExecuteScalar(ref command, ref connection) != "";

            return isFound;

        }

        public static bool IsPersonExist(string NationalNo)
        {
            SqlConnection connection = ConnectionUtils.InitiateConnection();

            string query = "select 1 from People where NationalNo = @NationalNo";

            SqlCommand command = new SqlCommand(query, connection);

            ConnectionUtils.AddArgsToCommand(ref command, query, NationalNo);

            bool isFound = ConnectionUtils.ExecuteScalar(ref command, ref connection) != "";

            return isFound;

        }

        public static bool IsUser(int PersonID)
        {
            string query = "select 1 from Users where PersonID = @PersonID";

            bool result = ConnectionUtils.IsRowExist(query, PersonID);

            return result;
        }

        public static DataTable GetPeopleTable() 
        {
            DataTable peopleTable = ConnectionUtils.GetTable("select * from People");

            return peopleTable;
                
        }

        public static DataTable GetAllNonUsers()
        {
            DataTable NonUsers = ConnectionUtils.GetTable("select * from People where PersonID not in (select PersonID from Users)");
            
            return NonUsers;
        }

    }
}
