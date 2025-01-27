using DVLD_DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLDBuisnessLayer
{
    public class User
    {
        // Add Modes
        enum enModes { AddNew, Update }
        enModes Mode;

        public int UserID{ get; set; }
        public int PersonID {  get; set; }
        public string UserName{ get; set; }
        public string Password{ get; set; }
        public bool IsActive {  get; set; }
        public Person AssociatedPerson { get
            {
                return Person.Find(PersonID);
            }
        }
        public static User GlobalUser { get; set; }

        private User(int UserID, int PersonID, string UserName, string Password, bool IsActive)
        {
            this.UserID = UserID;
            this.PersonID = PersonID;
            this.UserName = UserName;
            this.Password = Password;
            this.IsActive = IsActive;
            Mode = enModes.Update;
        }
        
        public User()
        {
            UserID = -1;
            PersonID = -1;
            UserName = "";
            Password = "";
            IsActive = false;
        }
        
        private bool _Update()
        {
            bool result = UsersAccess.UpdateUser(UserID, PersonID, UserName, Password, IsActive);

            return result;
                
        }
        
        private bool _AddNew()
        {
            UserID = UsersAccess.AddNewUser(PersonID, UserName, Password, IsActive);

            return UserID != -1;

        }
        
        public bool Save()
        {
            switch (Mode)
            {
                case enModes.AddNew:
                  
                    if (_AddNew())
                    {
                        Mode = enModes.Update;
                        return true;
                    }
                    return false;
                    
                case enModes.Update:
                    return _Update();

                default:
                    return false;

            }
            
        }
        
        public static User Find(string Username)
        {
            int PersonID = -1, UserID = -1;
            string Password = "";
            bool IsActive = false;

            bool isFound = UsersAccess.GetUserByUserName(Username, ref UserID, ref PersonID, ref Password, ref IsActive);

            if (isFound)
            {
                return new User(UserID, PersonID, Username, Password, IsActive);
            }
            return null;

        }
        
        public static User Find(int UserID)
        {
            int PersonID = -1;
            string UserName = "", Password = "";
            bool IsActive = false;

            bool isFound = UsersAccess.GetUserByID(UserID, ref PersonID, ref UserName, ref Password, ref IsActive);

            if (isFound) 
            {
                return new User(UserID, PersonID, UserName, Password, IsActive);
            }
            return null;
        }

        public bool Delete()
        {
            bool result = UsersAccess.DeleteUser(UserID);
            
            return result;
        }
        
        public static bool IsUserExist(int UserID)
        {
            return UsersAccess.IsUserExist(UserID);
        }
        
        public static bool IsUserExist(string UserName)
        {
            return UsersAccess.IsUserExist(UserName);
        }

        public static bool IsPersonAlreadyUser(int PersonID)
        {
            return UsersAccess.PersonIsAlreadyUser(PersonID);
        }

        public static DataTable GetAllUsers()
        {
            return UsersAccess.GetUsers();
        }

        
    }
}
