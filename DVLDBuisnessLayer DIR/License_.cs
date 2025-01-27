using DVLD_DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLDBuisnessLayer
{
    public class License_
    {
        public enum enIssueReasons { FirstTime = 0, Renew = 1, Broken = 2, Lost = 3 }
        enum enMode{ eAddNew, eUpdate }
        public static string[] IssueReasons = {"First Time", "Renew", "Broken", "Lost"};

        public int LicenseID { get; set; }

        public int ApplicationID { get; set; }
        public Application_ application { get; set; }

        public int DriverID { get; set; }
        public Driver driver { get; set; }
        
        public int LicenseClassID { get; set; }
        public LicenseClass licenseClass { get; set; }
        
        public int CreatedByUserID { get; set; }
        public int IssueReason { get; set; }
        public decimal PaidFees { get; set; }
        public string Notes;

        public DateTime IssueDate { get; set; }
        public DateTime ExpirationDate { get; set; }

        public bool IsActive { get; set; }
        private enMode Mode { get; set; }

        private License_(int licenseID, int applicationID, int driverID, int licenseClassID, int createdByUserID, decimal paidFees, string notes, bool IsActive, int issueReason, DateTime issueDate, DateTime expirationDate)
        {
            LicenseID = licenseID;
            ApplicationID = applicationID;
            this.application = Application_.Find(applicationID);
            DriverID = driverID;
            this.driver = Driver.Find(driverID);
            LicenseClassID = licenseClassID;
            this.licenseClass = LicenseClass.GetLicenseClassWithID(licenseClassID);
            CreatedByUserID = createdByUserID;
            PaidFees = paidFees;
            Notes = notes;
            IssueDate = issueDate;
            this.IsActive = IsActive;
            ExpirationDate = expirationDate;
            this.IssueReason = issueReason;
            Mode = enMode.eUpdate;
        }

        public License_()
        {
            LicenseID = -1;
            ApplicationID = -1;
            DriverID = -1;
            LicenseClassID = -1;
            CreatedByUserID = -1;
            PaidFees = -1;
            Notes = "";
            ExpirationDate = DateTime.MinValue;
            IssueDate= DateTime.MinValue;
            IsActive = false;
            Mode = enMode.eAddNew;
        }

        private bool _AddNew()
        {
            LicenseID = LicensesAccess.AddNewLicense(ApplicationID, DriverID, LicenseClassID, IssueReason, PaidFees, CreatedByUserID, IsActive, IssueDate, ExpirationDate, Notes);
            return LicenseID != -1;
        }

        /// <summary>
        /// Gets The License With the given ID.
        /// </summary>
        /// <param name="LicenseID">The primary key of the license</param>
        /// <param name="ApplicationID"></param>
        /// <param name="DriverID"></param>
        /// <param name="LicenseClassID"></param>
        /// <param name="IssueReason"></param>
        /// <param name="PaidFees"></param>
        /// <param name="CreatedByUserID"></param>
        /// <param name="IsActive"></param>
        /// <param name="IssueDate"></param>
        /// <param name="ExpirationDate"></param>
        /// <param name="Notes"></param>
        /// <returns>boolean value indicating wether the row is found or not.</returns>
        public static License_ FindWithID(int LicenseID)
        {
            int issurReason = -1, ApplicationID = -1, DriverID = -1, LicenseClassID = -1, CreatedByUserID = -1;
            DateTime issueDate = DateTime.MinValue, expDate = DateTime.MinValue;
            decimal PaidFees = -1;
            string Notes = ""; bool isActive = false;
            
            // return the license object if its valid
            bool Found = LicensesAccess.FindWithLicenseID(LicenseID, ref ApplicationID, ref DriverID, ref LicenseClassID, ref issurReason, ref PaidFees, ref CreatedByUserID, ref isActive, ref issueDate, ref expDate, ref Notes);
            if (Found) return new License_(LicenseID, ApplicationID, DriverID, LicenseClassID, CreatedByUserID, PaidFees, Notes, isActive, issurReason, issueDate, expDate);
            return null;
            
        }

        /// <summary>
        /// Gets The License With the given ApplicationID.
        /// </summary>
        /// <param name="LicenseID">The primary key of the license</param>
        /// <param name="ApplicationID"></param>
        /// <param name="DriverID"></param>
        /// <param name="LicenseClassID"></param>
        /// <param name="IssueReason"></param>
        /// <param name="PaidFees"></param>
        /// <param name="CreatedByUserID"></param>
        /// <param name="IsActive"></param>
        /// <param name="IssueDate"></param>
        /// <param name="ExpirationDate"></param>
        /// <param name="Notes"></param>
        /// <returns>boolean value indicating wether the row is found or not, 
        /// fills the given parameters with the row data if it is found.
        /// </returns>
        public static License_ FindWithApplicationID(int ApplicationID)
        {
            int issurReason = -1, LicenseID = -1, DriverID = -1, LicenseClassID = -1, CreatedByUserID = -1;
            DateTime issueDate = DateTime.MinValue, expDate = DateTime.MinValue;
            decimal PaidFees = -1;
            string Notes = ""; bool isActive = false;

            // return the license object if its valid
            bool Found = LicensesAccess.FindWithApplicationID(ApplicationID, ref LicenseID, ref DriverID, ref LicenseClassID, ref issurReason, ref PaidFees, ref CreatedByUserID, ref isActive, ref issueDate, ref expDate, ref Notes);
            if (Found) return new License_(LicenseID, ApplicationID, DriverID, LicenseClassID, CreatedByUserID, PaidFees, Notes, isActive, issurReason, issueDate, expDate);
            return null;

        }

        public bool Save()
        {
            switch (Mode)
            {
                case enMode.eAddNew:
                    if (_AddNew())
                    {
                        Mode = enMode.eUpdate;
                        return true;
                    }
                    return false;
                    
                case enMode.eUpdate:
                    return false;

                default:
                    return false;
            }
        }

        public bool Replace(enIssueReasons Reason, ApplicationType applicationType)
        {
            this.IsActive = false;
            Save();

            // Make new application with the new reason
            Application_ newApplication = new Application_();
            newApplication.ApplicationStatus = Application_.enApplicationStatus.Completed;
            newApplication.PaidFees = applicationType.AppTypeFee;
            newApplication.ApplicationTypeID = applicationType.AppTypeID;
            newApplication.CreatedByUserID = User.GlobalUser.UserID;
            newApplication.ApplicationDate = DateTime.Today;
            newApplication.LastStatusDate = DateTime.Today;
            newApplication.ApplicantPersonID = application.ApplicantPersonID;

            // add the application and make a new licesnse for the same person
            if (newApplication.Save())
            {
                this.IsActive = true;
                this.IssueReason = (int)Reason;
                this.IssueDate = DateTime.Today;
                this.ExpirationDate = IssueDate.AddYears(licenseClass.ClassValidityLength);
                this.CreatedByUserID = User.GlobalUser.UserID;
                this.Mode = enMode.eAddNew;
                this.ApplicationID = newApplication.ApplicationID;
                bool saveResult = this.Save();

                return saveResult;
            }

            return false;
        }

        public bool Detain()
        {
            return LicensesAccess.DetainLicense(LicenseID);
        }

        public bool IsDetained()
        {
            return LicensesAccess.IsDetained(LicenseID);
        }

        public bool NeedRenew()
        {
            return DateTime.Now > ExpirationDate;
        }

        public bool isValidForInternational()
        {
            return !IsDetained() && IsActive && LicenseClassID == 3 && !LicensesAccess.HaveInternationalPair(LicenseID) ;
        }

        public string strIssueReason()
        {
            return IssueReasons[IssueReason - 1];
        }

        /// <summary>
        /// Gets The License history DataTable of a driver
        /// </summary>
        /// <param name="DriverID">ID Of the driver of the licenses table</param>
        /// <returns>DataTable of the license history of the given driver</returns>
        public static DataTable GetTableOfDriver(int DriverID, bool isInternational)
        {
            if (isInternational)
            {
                DataTable InternationalDrivingLicenses = LicensesAccess.GetInternationalTableOf(DriverID);
                return InternationalDrivingLicenses;
            }
            else
            {
                DataTable LocalDrivingLicenses = LicensesAccess.GetTableOf(DriverID);
                return LocalDrivingLicenses;
            }
        }

        public static DataTable GetTable()
        {
            return LicensesAccess.GetFullTable();
        }

        public static DataTable GetActiveLicensesTable()
        {
            return LicensesAccess.GetActiveLicenses();
        }
        
    }
}
