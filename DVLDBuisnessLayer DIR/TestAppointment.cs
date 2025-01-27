using DVLD_DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLDBuisnessLayer
{
    public class TestAppointment
    {
        enum enModes { enAddNew, enUpdate}

        public int TestAppointmentID { get; set; }

        public int TestTypeID {  get; set; }
        public TestType AssociatedTestType { get; set; }
        
        public int LocalDrivingLicenseApplicationID {get; set;}
        public LocalDrivingLicense AssociatedLocalDrivingLicense {get; set;}
        
        public int CreatedByUserID { get; set; }
        public float PaidFees { get; set;}
        public DateTime AppointmentDate { get; set;}
        public bool IsLocked { get; set; }
        private enModes Mode { get; set; }

        public TestAppointment()
        {
            TestAppointmentID = -1;
            TestTypeID = -1;
            LocalDrivingLicenseApplicationID = -1;
            CreatedByUserID = -1;
            PaidFees = -1;
            AppointmentDate = DateTime.Now;
            IsLocked = false;
            Mode = enModes.enAddNew;
        }

        private TestAppointment(int testAppointmentID, int testTypeID, int localDrivingLicenseApplicationID, int createdByUserID, float paidFees, DateTime appointmentDate, bool isLocked)
        {
            TestAppointmentID = testAppointmentID;
            TestTypeID = testTypeID;
            AssociatedTestType = TestType.Find(testTypeID);
            LocalDrivingLicenseApplicationID = localDrivingLicenseApplicationID;
            AssociatedLocalDrivingLicense = LocalDrivingLicense.Find(localDrivingLicenseApplicationID);
            CreatedByUserID = createdByUserID;
            PaidFees = paidFees;
            AppointmentDate = appointmentDate;
            IsLocked = isLocked;
            Mode = enModes.enUpdate;
        }

        public static TestAppointment Find(int testAppointmentID)
        {
            int TestTypeID = -1,LocalDrivingLicenseApplicationID = -1,CreatedByUserID = -1;
            float PaidFees = -1;
            DateTime AppointmentDate = DateTime.Now;
            bool IsLocked = false;

            bool found = TestsAppointmentsAccess.GetTestAppointmentWithID(testAppointmentID, ref TestTypeID, ref LocalDrivingLicenseApplicationID, ref AppointmentDate, ref PaidFees, ref CreatedByUserID, ref IsLocked);

            if (found) return new TestAppointment(testAppointmentID, TestTypeID, LocalDrivingLicenseApplicationID, CreatedByUserID, PaidFees, AppointmentDate, IsLocked);

            return null;
        }

        private bool _AddNew()
        {
            TestAppointmentID = TestsAppointmentsAccess.AddTestAppointment(TestTypeID, LocalDrivingLicenseApplicationID, AppointmentDate, PaidFees, CreatedByUserID, IsLocked);

            bool AddSuccessful = TestAppointmentID != -1;

            return AddSuccessful;
        }

        private bool _Update()
        {
            bool result = TestsAppointmentsAccess.EditTestAppointment(TestAppointmentID, AppointmentDate, IsLocked);

            return result;
        }

        public bool Save()
        {
            switch (Mode)
            {
                case enModes.enAddNew:
                    if (_AddNew())
                    {
                        Mode = enModes.enUpdate;
                        return true;
                    }
                    return false;
                    
                case enModes.enUpdate:
                    return _Update();
                    
                default:
                    return false;
            }

        }

        public static DataTable GetTableOf(int LocalDrivingLicenseApplication_ID, int TestTypeID)
        {
            return TestsAppointmentsAccess.GetTableOfID(LocalDrivingLicenseApplication_ID, TestTypeID);
        }

        public static bool CanAddAppointment(int LocalDrivingLicenseApp_ID)
        {
            return TestsAppointmentsAccess.CanAddAppointmentTo(LocalDrivingLicenseApp_ID);
        }
    }
}
