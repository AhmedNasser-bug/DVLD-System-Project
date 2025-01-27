using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLD_DataAccessLayer
{
    public class UsersAccess
    {
        public static bool GetUserByID(int UserID, ref int PersonID, ref string UserName, ref string Password, ref bool IsActive)
        { 
            string query = "select * from Users where UserID = @UserID";

            List<object> rowItems = ConnectionUtils.GetRow<int>(query, UserID);

            bool isFound = rowItems.Count > 0;

            if (isFound)
            {
                PersonID = Convert.ToInt32(rowItems[1]);
                UserName = Convert.ToString(rowItems[2]);
                Password = Convert.ToString(rowItems[3]);
                IsActive = Convert.ToBoolean(rowItems[4]);
                return true;
            }
            return false;    
            
            

        }
        public static bool GetUserByUserName(string UserName,ref int UserID, ref int PersonID,  ref string Password, ref bool IsActive)
        {
            string query = "select * from Users where UserName = @Username";

            List<object> rowItems = ConnectionUtils.GetRow<string>(query, UserName);
            bool isFound = (rowItems.Count > 0);

            if (isFound)
            {
                UserID = Convert.ToInt32(rowItems[0]);
                PersonID = Convert.ToInt32(rowItems[1]);
                Password = Convert.ToString(rowItems[3]);
                IsActive = Convert.ToBoolean(rowItems[4]);
                return isFound;
            }
            return false;

        }
        public static int AddNewUser( int PersonID, string UserName, string Password, bool IsActive)
        {
            string query = "Insert into Users (PersonID, Username, Password, IsActive ) Values ( @PersonID, @UserName, @Password, @IsActive ) ; select Scope_Identity();";

            int UserID = ConnectionUtils.AddRowToTable(query, PersonID, UserName, Password, IsActive);

            return UserID;

        }
        public static bool UpdateUser(int UserID, int PersonID, string UserName, string Password, bool IsActive)
        {
            string query = "Update Users" +
                            " Set PersonID = @PersonID, UserName = @UserName, Password = @Password, IsActive = @IsActive " +
                            "Where UserID = @UserID";
            bool result = ConnectionUtils.UpdateTableRow(query, PersonID, UserName, Password, IsActive, UserID);
            
            return result;

        }
        public static bool DeleteUser(int UserID)
        {
            string query = "delete from Users where UserID = @UserID";

            bool result = ConnectionUtils.DeleteTableRow(query, UserID);

            return result;
        }
        public static bool IsUserExist(int UserID)
        {
            string query = "select 1 from Users where UserID = @UserID";

            bool result = ConnectionUtils.IsRowExist(query, UserID);

            return result;
        }
        public static bool IsUserExist(string UserName)
        {
            string query = "select 1 from Users where UserName = @UserName";

            bool result = ConnectionUtils.IsRowExist(query, UserName);

            return result;
        }
        public static bool PersonIsAlreadyUser(int PersonID)
        {
            string query = "SELECT 1 FROM Users WHERE PersonID = @PID";

            bool isFound = ConnectionUtils.IsRowExist(query, PersonID);

            return isFound;
        }
        public static DataTable GetUsers()
        {
            return ConnectionUtils.GetTable("SELECT UserID, FullName = FirstName + ' ' + SecondName + ' ' + ThirdName + ' ' + LastName,UserName, IsActive  \r\nFROM Users \r\nINNER JOIN People\r\nON Users.PersonID = People.PersonID");
        }

    }
}
