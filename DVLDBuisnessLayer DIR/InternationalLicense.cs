using DVLD_DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace DVLDBuisnessLayer
{
    public class InternationalLicense
    {
        enum enModes { AddNew, Update}

        public int InternationalLicenseID { get; set; }
        
        public int ApplicationID { get; set; }
        public Application_ AssociatedApplication { get; set; }

        public int IssuedByLocalLicenseID { get; set; }
        public License_ AssociatedLicense { get; set; }

        public int DriverID { get; set; }
        public Driver AssociatedDriver { get; set; }

        public int CreatedByUserID { get; set; }

        public DateTime IssueDate { get; set; }
        public DateTime ExpirationDate { get; set; }

        public bool IsActive { get; set; }

        enModes Mode { get; set; }

        public InternationalLicense()
        {
            InternationalLicenseID = -1;
            ApplicationID = -1;
            IssuedByLocalLicenseID = -1;
            DriverID = -1;
            CreatedByUserID = -1;
            IssueDate = DateTime.MinValue;
            ExpirationDate = DateTime.MinValue;
            IsActive = false;
            Mode = enModes.AddNew;
            
        }

        private InternationalLicense(int internationalLicenseID, int applicationID, int issuedByLocalLicenseID, int driverID, int createdByUserID, DateTime issueDate, DateTime expirationDate, bool isActive)
        {
            InternationalLicenseID = internationalLicenseID;
            ApplicationID = applicationID;
            AssociatedApplication = Application_.Find(applicationID);
            IssuedByLocalLicenseID = issuedByLocalLicenseID;
            AssociatedLicense = License_.FindWithID(issuedByLocalLicenseID);
            DriverID = driverID;
            AssociatedDriver = Driver.Find(driverID);
            CreatedByUserID = createdByUserID;
            IssueDate = issueDate;
            ExpirationDate = expirationDate;
            IsActive = isActive;
            Mode = enModes.AddNew;
        }

        private bool _AddNew()
        {
            InternationalLicenseID = InternationalLicensesAccess.AddNewInternationalLicense(ApplicationID, DriverID, IssuedByLocalLicenseID, IssueDate, ExpirationDate, IsActive, CreatedByUserID);
            if (InternationalLicenseID != -1)
            {
                AssociatedApplication = Application_.Find(ApplicationID);
                AssociatedLicense = License_.FindWithID(IssuedByLocalLicenseID);
                AssociatedDriver = Driver.Find(DriverID);
                return true;
            }
            return false;
        }

        private bool _Update()
        {
            return InternationalLicensesAccess.UpdateInternationLicense(InternationalLicenseID, ApplicationID, DriverID, IssuedByLocalLicenseID, IssueDate, ExpirationDate, IsActive, CreatedByUserID);
        }

        public static InternationalLicense Find(int InternationalLicenseID)
        {
            int ApplicationID = -1,
            IssuedByLocalLicenseID = -1,
            DriverID = -1,
            CreatedByUserID = -1;
            DateTime IssueDate = DateTime.MinValue,
            ExpirationDate = DateTime.MinValue;
            bool IsActive = false;

            bool Found = InternationalLicensesAccess.FindWithID(InternationalLicenseID, ref ApplicationID, ref DriverID, ref IssuedByLocalLicenseID, ref IssueDate, ref ExpirationDate, ref IsActive, ref CreatedByUserID);
            if (Found) return new InternationalLicense(InternationalLicenseID, ApplicationID, IssuedByLocalLicenseID, DriverID, CreatedByUserID, IssueDate, ExpirationDate, IsActive);
            return null;
        }

        public bool Save()
        {
            switch (Mode)
            {
                case enModes.AddNew:
                    if (AssociatedApplication.Save())
                    {
                        ApplicationID = AssociatedApplication.ApplicationID;
                        if (_AddNew())
                        {
                            Mode = enModes.Update;
                            return true;
                        }
                    }
                    return false;

                case enModes.Update:
                    return _Update();
            }

            return false;
        }

        public bool Delete()
        {
            return InternationalLicensesAccess.Delete(InternationalLicenseID);
        }

        public DataTable GetLicensesTable()
        {
            return InternationalLicensesAccess.GetTableOFID(InternationalLicenseID);
        }

        public static DataTable GetAllInternationalLicenses()
        {
            return InternationalLicensesAccess.GetFullTable();
        }
    }
}
