using DVLD_DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace DVLDBuisnessLayer
{
    public class LicenseClass
    {
        public int LicenseClassID { get; }
        public string LicenseClassName { get; }
        public string  LicenseClassDesc { get;  }
        public int MinimumAllowedAge{ get; set; }
        public int ClassValidityLength { get; set; }
        public decimal LicenseClassFee { get; set; }

        private LicenseClass(int LicenseClassID, string LicenseClassName, string LicenseClassDesc, int MinimumAllowedAge, int ClassValidityLength, decimal LicenseClassFee) 
        {
            this.ClassValidityLength = ClassValidityLength;
            this.LicenseClassFee = LicenseClassFee;
            this.MinimumAllowedAge = MinimumAllowedAge;
            this.LicenseClassName = LicenseClassName;
            this.LicenseClassDesc = LicenseClassDesc;
            this.LicenseClassID = LicenseClassID;
        }


        private bool _Update()
        {
            bool result = LicenseClassAccess.EditLicenseClass(LicenseClassID, MinimumAllowedAge, ClassValidityLength, LicenseClassFee);

            return result;
        }

        
        public static LicenseClass GetLicenseClassWithID(int ID)
        {
            int MinimumAllowedAge = -1, ClassValidityLength = -1;
            string LicenseClassName = "", LicenseClassDesc = "";
            decimal LicenseClassFees = -1;

            bool found = LicenseClassAccess.GetLicenseClassWithID(ID, ref LicenseClassName, ref LicenseClassDesc, ref MinimumAllowedAge, ref ClassValidityLength, ref LicenseClassFees);

            if (found) return new LicenseClass(ID, LicenseClassName, LicenseClassDesc, MinimumAllowedAge, ClassValidityLength, LicenseClassFees);

            return null;
        }

        public bool Save()
        {
            return _Update();
        }

        public static DataTable GetAllLicenseClasses()
        {
            return LicenseClassAccess.GetAllLicenseClasses();
        }

    }
}
