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
    public class Application_
    {
        enum enModes { AddNew, Update}
        public enum enApplicationStatus { New = 1, Canceled = 2, Completed = 3 }

        public int ApplicationID { get; set; }

        public int ApplicantPersonID { get; set; }
        public Person AssociatedPerson { get; set; }

        public int ApplicationTypeID { get; set; }
        public ApplicationType AssociatedAppType { get; set; }

        public int CreatedByUserID { get; set; }
        public User CreatedByUser { get; set; }

        public enApplicationStatus ApplicationStatus { get; set; }
        public DateTime LastStatusDate{ get; set; }
        public DateTime ApplicationDate { get; set; }
        public decimal PaidFees { get; set; }
        private enModes Mode { get; set; }


        public Application_() 
        { 
            ApplicationID = -1;
            ApplicationDate = DateTime.MinValue;
            ApplicationTypeID = -1;
            ApplicationStatus = enApplicationStatus.New;
            LastStatusDate = DateTime.MinValue;
            CreatedByUserID = -1;
            ApplicationStatus = enApplicationStatus.New;
            LastStatusDate = DateTime.MinValue;
            PaidFees = 0;
        }

        private Application_(int applicationID, int applicantPersonID, DateTime applicationDate, int applicationTypeID, enApplicationStatus applicationStatus, DateTime lastStatusDate, decimal paidFees, int createdByUserID)
        {
            ApplicationID = applicationID;
            ApplicantPersonID = applicantPersonID;
            ApplicationDate = applicationDate;
            ApplicationTypeID = applicationTypeID;
            ApplicationStatus = applicationStatus;
            LastStatusDate = lastStatusDate;
            PaidFees = paidFees;
            CreatedByUserID = createdByUserID;
            CreatedByUser = User.Find(createdByUserID);
            AssociatedPerson = Person.Find(applicantPersonID);
            AssociatedAppType = ApplicationType.Find(applicationTypeID);
            Mode = enModes.Update;
        }

        private bool _Update()
        {
            bool result = ApplicationsAccess.UpdateApplication(ApplicationID, ApplicantPersonID, ApplicationDate, ApplicationTypeID, (short)ApplicationStatus, LastStatusDate, PaidFees, CreatedByUserID);
            return result;
        }

        public bool Delete()
        { 
            bool result = ApplicationsAccess.DeleteApplication(ApplicationID);
            return result;
        }

        public bool Cancel()
        {
            ApplicationStatus = enApplicationStatus.Canceled;
            LastStatusDate = DateTime.Now;
            return Save();
        }

        private bool _AddNew()
        {
            ApplicationID = ApplicationsAccess.AddApplication(ApplicantPersonID, ApplicationDate, ApplicationTypeID, (short)ApplicationStatus, LastStatusDate, PaidFees, CreatedByUserID);
            return ApplicationID != -1;

        }

        public static Application_ Find(int Application_ID)
        {
            int  ApplicantPersonID = -1, ApplicationTypeID = -1, CreatedByUserID = -1;
            short ApplicationStatus = 1;
            decimal PaidFees = -1;
            DateTime ApplicationDate = DateTime.MinValue, LastStatusDate = DateTime.MinValue;

            bool result = ApplicationsAccess.FindApplicationByID(Application_ID,ref ApplicantPersonID, ref ApplicationDate, ref ApplicationTypeID, ref ApplicationStatus, ref LastStatusDate, ref PaidFees, ref CreatedByUserID);
            if(result)return new Application_(Application_ID, ApplicantPersonID, ApplicationDate, ApplicationTypeID, (enApplicationStatus)ApplicationStatus, LastStatusDate, PaidFees, CreatedByUserID);

            return null;

        }

        internal bool Save()
        {
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
                        return false;
                    }

                case enModes.Update:
                    return _Update();
                    
                default:
                    return false;
                    
            }
        }

        public static DataTable GetFullTable()
        {
            return ApplicationsAccess.GetApplicationsTable();
        }

    }
}
