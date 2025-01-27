using DVLD_DataAccessLayer;
using DVLD_System.Utils;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Security.Permissions;
using System.Text;
using System.Threading.Tasks;

namespace DVLDBuisnessLayer
{
    public class Person
    {
        enum enMode { AddNew, Update}
        private enMode _Mode = enMode.AddNew;

        public int PersonID { get; private set; }
        public string NationalNo { get; set; }
        public string FirstName { get; set; }
        public string SecondName { get; set; }
        public string ThirdName { get; set; }
        public string LastName { get; set; }
        public string FullName { get
            {
                return FirstName + " " + SecondName + " " + ThirdName + " " +LastName;
            } 
        }
        public DateTime DateOfBirth { get; set; }
        public bool Gender { get; set ; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public int NationalityCountryID { get; set; }
        public string CountryName { get {
                return _CountryName();
            }  }
        public string ImagePath { get; set; }
        private string _OldPath {  get; set; }


        private Person(int PersonID, string FirstName, string SecondName, string ThirdName, string LastName,
                                        string NationalNo, DateTime DateOfBirth, bool Gender, string Address, string Phone,
                                        string Email, int CountryID, string ImagePath)
        { 
            this.PersonID = PersonID;
            this.FirstName = FirstName;
            this.SecondName = SecondName;
            this.ThirdName = ThirdName;
            this.LastName = LastName;
            this.NationalNo = NationalNo;
            this.DateOfBirth = DateOfBirth;
            this.Gender = Gender;   
            this.Address = Address;
            this.Phone = Phone;
            this.Email = Email;
            this.NationalityCountryID = CountryID;
            this.ImagePath = ImagePath;
            this._OldPath = ImagePath;
            _Mode = enMode.Update;
        }
        public Person()
        {
            PersonID = -1;
            NationalNo = "";
            NationalityCountryID = -1;
            FirstName = "";
            SecondName = "";
            ThirdName = "";
            LastName = "";
            DateOfBirth = DateTime.Now;
            Gender = false;
            Address = "";
            Phone = "";
            Email = "";
            ImagePath = "";

        }

        private bool _Update()
        {
            if (ImagePath != "") ImagePath = ImageUtils.ReplacePersonImage(_OldPath, ImagePath);
            else ImageUtils.RemovePersonImage(_OldPath);

            bool result = PeopleAccess.UpdatePerson(PersonID, FirstName, SecondName, ThirdName, LastName, NationalNo, DateOfBirth, Gender, Address, Phone, Email, NationalityCountryID, ImagePath );

            return result;
        }

        private bool _AddNewPerson()
        {
            ImagePath = ImageUtils.AddPersonImage(ImagePath);

            PersonID = PeopleAccess.AddNewPerson(NationalNo, FirstName, SecondName, ThirdName, LastName, DateOfBirth, Gender, Address, Phone, Email, NationalityCountryID, ImagePath);

            return PersonID != -1;
        }

        private string _CountryName()
        {
            Country country = Country.Find(NationalityCountryID);
            if(country == null)
            {
                return "";
            }
            return country.Name;
        }

        public static Person Find(int PersonID)
        {
            string NationalNo = "", FirstName = "", SecondName = "", ThirdName = "", LastName = "", Address = "", Phone = "", Email = "", ImagePath = "";
            int NationalCountryID = -1;
            bool Gender = false;
            DateTime DateOfBirth = DateTime.Now;

            bool found = PeopleAccess.GetPersonByID(PersonID, ref NationalNo, ref FirstName, ref SecondName, ref ThirdName, ref LastName, 
                                                        ref DateOfBirth, ref Gender, ref Address, ref Phone, ref Email, ref NationalCountryID, ref ImagePath);
            if (found)
            {
                return new Person(PersonID, FirstName, SecondName, ThirdName, LastName, NationalNo, DateOfBirth, Gender, Address, Phone, Email, NationalCountryID, ImagePath);
            }

            return null;
        }

        public static Person Find(string NationalNo)
        {
            string FirstName = "", SecondName = "", ThirdName = "", LastName = "", Address = "", Phone = "", Email = "", ImagePath = "";
            int NationalCountryID = -1, PersonID = -1;
            bool Gender = false;
            DateTime DateOfBirth = DateTime.Now;

            bool found = PeopleAccess.GetPersonByNationalNo(NationalNo ,ref PersonID, ref FirstName, ref SecondName, ref ThirdName, ref LastName,
                                                        ref DateOfBirth, ref Gender, ref Address, ref Phone, ref Email, ref NationalCountryID, ref ImagePath);
            if (found)
            {
                return new Person(PersonID, FirstName, SecondName, ThirdName, LastName, NationalNo, DateOfBirth, Gender, Address, Phone, Email, NationalCountryID, ImagePath);
            }

            return null;
        }

        public static bool IsPersonExist(string NationalNo)
        {
            bool isFound = PeopleAccess.IsPersonExist(NationalNo);

            return isFound;
        }

        public static bool IsPersonExist(int PersonID)
        {
            bool isFound = PeopleAccess.IsPersonExist(PersonID);

            return isFound;
        }

        public bool Save()
        {
            switch (_Mode)
            {
                case enMode.AddNew:

                    if (_AddNewPerson())
                    {
                        _Mode = enMode.Update;
                        return true;
                    }

                    return false;

                case enMode.Update:

                    return _Update();
                    
                default:
                    break;
            }
            return false;
        }

        public bool Delete() 
        {
            ImageUtils.RemovePersonImage(ImagePath);
            bool result = PeopleAccess.DeletePerson(PersonID) > 0;

            return result;
        }

        public static DataTable GetPeopleTable()
        {
            return PeopleAccess.GetPeopleTable();
        }

        public static DataTable GetNonUsersTable() 
        {
            return PeopleAccess.GetAllNonUsers();
        }

        public bool IsUser()
        {
            return PeopleAccess.IsUser(PersonID);
        }
    }
}
