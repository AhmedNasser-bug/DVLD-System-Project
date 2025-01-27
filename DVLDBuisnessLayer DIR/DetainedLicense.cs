using DVLD_DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace DVLDBuisnessLayer
{
    public class DetainedLicense
    {
        public int DetainID { get; set; }
        
        public int LicenseID { get; set; }
        public License_ AssociatedLicense { get; set; }

        public DateTime DetainDate { get; set; }
        public decimal DetainFees { get; set; }
        public int CreatedByUserID{ get; set; }
        public bool IsReleased{ get; set; }
        public DateTime ReleaseDate { get; set; }
        public int ReleasedByUserID { get; set; }

        public int ReleaseApplicationID { get; set; }
        public Application_ ReleaseApplication { get; set; }

        private DetainedLicense(int detainID, int licenseID, DateTime detainDate, decimal detainFees, int createdByUserID, bool isReleased, DateTime releaseDate, int releasedByUserID, int releaseApplicationID)
        {
            DetainID = detainID;
            LicenseID = licenseID;
            AssociatedLicense = License_.FindWithID(licenseID);
            DetainDate = detainDate;
            DetainFees = detainFees;
            CreatedByUserID = createdByUserID;
            IsReleased = isReleased;
            ReleaseDate = releaseDate;
            ReleasedByUserID = releasedByUserID;
            ReleaseApplicationID = releaseApplicationID;
            ReleaseApplication = Application_.Find(releaseApplicationID);
        }

        public DetainedLicense()
        {
            LicenseID = -1;
            DetainID = -1;
            DetainFees = -1;
            CreatedByUserID = -1;
            IsReleased = false;
            ReleaseApplicationID = -1;
            ReleaseDate = DateTime.MinValue;
            ReleasedByUserID = -1;
            DetainDate = DateTime.MinValue;
        }

        public static DetainedLicense FindWithID(int DetainID)
        { 
            decimal DetainFees = -1;
            int LicenseID = -1,
            CreatedByUserID = -1,
            ReleaseApplicationID = -1,
            ReleasedByUserID = -1;
            bool IsReleased = false;
            DateTime ReleaseDate = DateTime.MinValue,
            DetainDate = DateTime.MinValue;

            bool Found = DetainedLicensesAccess.FindWithID(DetainID, ref LicenseID, ref DetainDate, ref DetainFees, ref CreatedByUserID, ref IsReleased, ref ReleaseDate, ref ReleasedByUserID, ref ReleaseApplicationID);
            if (Found) return new DetainedLicense(DetainID, LicenseID, DetainDate, DetainFees, CreatedByUserID, IsReleased, ReleaseDate, ReleasedByUserID, ReleaseApplicationID);
            else return null;
        }

        public static DetainedLicense FindWithLicenseID(int LicenseID)
        {
            decimal DetainFees = -1;
            int DetainID = -1,
            CreatedByUserID = -1,
            ReleaseApplicationID = -1,
            ReleasedByUserID = -1;
            bool IsReleased = false;
            DateTime ReleaseDate = DateTime.MinValue,
            DetainDate = DateTime.MinValue;

            bool Found = DetainedLicensesAccess.FindWithLicenseID(LicenseID, ref DetainID, ref DetainDate, ref DetainFees, ref CreatedByUserID, ref IsReleased, ref ReleaseDate, ref ReleasedByUserID, ref ReleaseApplicationID);
            if (Found) return new DetainedLicense(DetainID, LicenseID, DetainDate, DetainFees, CreatedByUserID, IsReleased, ReleaseDate, ReleasedByUserID, ReleaseApplicationID);
            else return null;
        }

        public bool ConfirmDetain()
        {
            // Deactivate license
            License_ associatedLicense = License_.FindWithID(LicenseID);
            associatedLicense.IsActive = false;
            bool saveResult = associatedLicense.Detain();
            AssociatedLicense = associatedLicense;

            DetainID = DetainedLicensesAccess.AddDetainedLicense(LicenseID, DetainDate, DetainFees, CreatedByUserID, IsReleased, ReleaseDate, ReleasedByUserID, ReleaseApplicationID);
            return DetainID != -1 && saveResult;
        }

        public bool Release()
        {
            ApplicationType ReleaseLicenseAppType = ApplicationType.Find(((int)ApplicationType.enAppTypeIDs.ReleaseDetainedDrivingLicense));

            Application_ newApplication = new Application_();
            newApplication.ApplicationStatus = Application_.enApplicationStatus.Completed;
            newApplication.ApplicantPersonID = AssociatedLicense.driver.PersonID;
            newApplication.ApplicationDate = DateTime.Now;
            newApplication.LastStatusDate = DateTime.Now;
            newApplication.ApplicationTypeID = ReleaseLicenseAppType.AppTypeID;
            newApplication.PaidFees = ReleaseLicenseAppType.AppTypeFee;
            newApplication.CreatedByUserID = User.GlobalUser.UserID;

            // save to database
            bool saveResult = newApplication.Save();

            // if application is successfully added, update license data
            if (saveResult) 
            {
                ReleaseDate = DateTime.Now;
                ReleasedByUserID = User.GlobalUser.UserID;
                ReleaseApplicationID = newApplication.ApplicationID;
                return DetainedLicensesAccess.ReleaseDetainedLicense(DetainID, ReleaseDate, ReleasedByUserID, ReleaseApplicationID);
            }
            return false;
        }

        public static DataTable GetAllDetainedLicenses()
        {
            return DetainedLicensesAccess.GetTable();
        }
    }
}
