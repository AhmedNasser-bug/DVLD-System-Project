using DVLD_DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace DVLDBuisnessLayer
{
    public class Driver
    {
        enum enModes
        {
            eAddNew, eUpdate
        }

        public int DriverID { get; set; }
        public int PersonID { get; set; }
        public Person AssosiatedPerson { get; set; }
        public int CreatedByUserID { get; set; }
        public DateTime CreatedDate { get; set; }
        enModes mode;

        private Driver(int driverID, int personID, int createdByUserID, DateTime createdDate)
        {
            DriverID = driverID;
            PersonID = personID;
            AssosiatedPerson = Person.Find(personID);
            CreatedByUserID = createdByUserID;
            CreatedDate = createdDate;
            mode = enModes.eUpdate;
        }

        public Driver()
        {
            DriverID = -1;
            PersonID = -1;
            CreatedByUserID = -1;
            CreatedDate = DateTime.Now;
            mode = enModes.eAddNew;
        }

        private bool _AddNew()
        {
            DriverID = DriversAccess.AddDriver(PersonID, CreatedByUserID, CreatedDate);
            return DriverID != -1;
        }

        private bool _Update()
        {
            return DriversAccess.UpdateDriver(DriverID, PersonID, CreatedByUserID, CreatedDate);
        }

        /// <summary>
        /// Finds the driver with the given ID
        /// </summary>
        /// <param name="driverID">The ID Of the driver you want to get</param>
        /// <returns>The Driver with the given ID</returns>
        public static Driver Find(int driverID)
        {
            int PersonID = -1, CreatedByUserID = -1;
            DateTime CreatedDate = DateTime.Now;

            bool Found = DriversAccess.FindWithID(driverID, ref PersonID, ref CreatedByUserID, ref CreatedDate);

            if (Found) return new Driver(driverID, PersonID, CreatedByUserID, CreatedDate);
            return null;
        }

        //public bool Delete()
        //{
        //    ///// 
        //}

        public bool Save()
        {
            switch (mode)
            {
                case enModes.eAddNew:
                    if (_AddNew())
                    {
                        mode = enModes.eUpdate;
                        return true;
                    }
                    return false;

                case enModes.eUpdate:
                    return _Update();
                
                default:
                    return false;
            }
        }

        public static DataTable GetTable()
        {
            return DriversAccess.GetTable();
        }

        public static DataTable GetTableView()
        {
            return DriversAccess.GetTableView();
        }
    }
}
