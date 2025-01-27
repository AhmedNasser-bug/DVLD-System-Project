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
        /// <summary>
        /// Gets a user with the given UserID and fills the given ref parameters with the found user data.
        /// </summary>
        /// <returns>True if the user with the given userID is found, false otherwise.</returns>
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

        /// <summary>
        /// Gets a user with the given UserName and fills the given ref parameters with the found user data.
        /// </summary>
        /// <returns>True if the user with the given username is found, false otherwise.</returns>
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

        /// <summary>
        /// Adds a new user to the database.
        /// </summary>
        /// <returns>The ID of the newly added user, -1 if the user could not be added.</returns>
        public static int AddNewUser( int PersonID, string UserName, string Password, bool IsActive)
        {
            string query = "Insert into Users (PersonID, Username, Password, IsActive ) Values ( @PersonID, @UserName, @Password, @IsActive ) ; select Scope_Identity();";

            int UserID = ConnectionUtils.AddRowToTable(query, PersonID, UserName, Password, IsActive);

            return UserID;

        }

        /// <summary>
        /// Updates the user with the given user ID.
        /// </summary>
        /// <returns>True if the user is successfully updated, false otherwise.</returns>
        public static bool UpdateUser(int UserID, int PersonID, string UserName, string Password, bool IsActive)
        {
            string query = "Update Users" +
                            " Set PersonID = @PersonID, UserName = @UserName, Password = @Password, IsActive = @IsActive " +
                            "Where UserID = @UserID";
            bool result = ConnectionUtils.UpdateTableRow(query, PersonID, UserName, Password, IsActive, UserID);
            
            return result;

        }

        /// <summary>
        /// Deletes the user with the given user ID.
        /// </summary>
        /// <returns>True if the user is successfully deleted, false otherwise.</returns>
        public static bool DeleteUser(int UserID)
        {
            string query = "delete from Users where UserID = @UserID";

            bool result = ConnectionUtils.DeleteTableRow(query, UserID);

            return result;
        }

        /// <summary>
        /// Checks if a User with the given UserID exists.
        /// </summary>
        /// <returns>True if the user exists, false otherwise.</returns>
        public static bool IsUserExist(int UserID)
        {
            string query = "select 1 from Users where UserID = @UserID";

            bool result = ConnectionUtils.IsRowExist(query, UserID);

            return result;
        }

        /// <summary>
        /// Checks if a User with the given UserName exists.
        /// </summary>
        /// <param name="UserName"></param>
        /// <returns>True if the user exists, false otherwise.</returns>
        public static bool IsUserExist(string UserName)
        {
            string query = "select 1 from Users where UserName = @UserName";

            bool result = ConnectionUtils.IsRowExist(query, UserName);

            return result;
        }

        /// <summary>
        /// Checks if the given person is already a user.
        /// </summary>
        /// <returns>True if the given person is a user, false otherwise.</returns>
        public static bool PersonIsAlreadyUser(int PersonID)
        {
            string query = "SELECT 1 FROM Users WHERE PersonID = @PID";

            bool isFound = ConnectionUtils.IsRowExist(query, PersonID);

            return isFound;
        }

        /// <summary>
        /// Gets a table of all users including active and inactive users.
        /// </summary>
        /// <returns>A DataTable object of all users present in the system.</returns>
        public static DataTable GetUsers()
        {
            return ConnectionUtils.GetTable("SELECT UserID, FullName = FirstName + ' ' + SecondName + ' ' + ThirdName + ' ' + LastName,UserName, IsActive  \r\nFROM Users \r\nINNER JOIN People\r\nON Users.PersonID = People.PersonID");
        }

    }
}
