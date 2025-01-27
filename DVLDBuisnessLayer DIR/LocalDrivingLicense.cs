using DVLD_DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLDBuisnessLayer
{
    public class LocalDrivingLicense
    {
        enum enModes { AddNew, Update};

        public int ApplicationID { get; set; }
        public Application_ AssociatedApp { get; set; }
  
        public int LicenseClassID { get; set; }
        public LicenseClass AssociatedLicenseClass { get; set; }
        
        public int LDLicenseID{ get; set; }
        private enModes Mode;

        private LocalDrivingLicense(int LDLicenseID, int ApplicationID, int LicenseClassID)
        {
            this.LicenseClassID = LicenseClassID;
            this.ApplicationID = ApplicationID;
            this.AssociatedApp = Application_.Find(ApplicationID);
            this.AssociatedLicenseClass = LicenseClass.GetLicenseClassWithID(LicenseClassID);
            this.LDLicenseID = LDLicenseID;
            this.Mode = enModes.Update;
        }

        public LocalDrivingLicense()
        { 
            ApplicationID = -1;
            LicenseClassID = -1;
            LDLicenseID = -1;
            this.Mode = enModes.AddNew;
        }

        public static LocalDrivingLicense Find(int LDL_ID)
        {
            int ApplicationID = -1, LicenseClassID = -1; // Initialize default values
            
            bool found = LocalDrivingLicenseAccess.FindWithID(LDL_ID, ref ApplicationID, ref LicenseClassID);
            if (found)return new LocalDrivingLicense(LDL_ID, ApplicationID, LicenseClassID);

            return null;
        }

        public bool IsValidApplication()
        {
            return LocalDrivingLicenseAccess.ValidApplication(AssociatedApp.ApplicantPersonID, LicenseClassID);
        }

        private bool _Update()
        {
            bool result = LocalDrivingLicenseAccess.UpdateLDLApplication(LDLicenseID, ApplicationID, LicenseClassID);

            return result;
        }

        public bool Delete()
        {
            bool result = LocalDrivingLicenseAccess.DeleteLDLApplication(LDLicenseID);

            return result;
        }

        private bool _AddNew() 
        {
             if(IsValidApplication())this.LDLicenseID = LocalDrivingLicenseAccess.AddLDLApplication(ApplicationID, LicenseClassID);

            return LDLicenseID != -1;
        }

        public bool Save()
        {
            bool res = AssociatedApp.Save();
            if (res)
            {
                ApplicationID = AssociatedApp.ApplicationID;
            }
            else
            {
                return false;
            }
         

            switch (Mode)
            {
                case enModes.AddNew:

                    if (_AddNew())
                    {
                        Mode = enModes.Update;
                        return true;
                    }
                    else
                    {
                        AssociatedApp.Delete();
                        return false;
                    }
                    
                case enModes.Update:

                    return _Update();

                default:
                    return false;
            }
        }

        public static DataTable GetTable()
        {
            return LocalDrivingLicenseAccess.GetTable();
        }

        public static DataTable GetFullTable()
        {
            return LocalDrivingLicenseAccess.GetDetailedTableView();
        }
       
    }
}
