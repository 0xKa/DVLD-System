using DVLD_DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLD_BusinessLayer
{
    public class clsTestAppointment
    {
        private clsGlobalSettings.enMode _Mode = clsGlobalSettings.enMode.AddNew;

        public int ID { get; set; }
        public int TestTypeID { get; set; }
        public int LDLAppID { get; set; }
        public DateTime AppointmentDate { get; set; }
        public double PaidFees { get; set; }
        public int CreatedByUserID { get; set; }
        public bool IsLocked { get; set; }

        public clsTestAppointment()
        {
            _Mode = clsGlobalSettings.enMode.AddNew;

            ID = -1;
            TestTypeID = -1;
            LDLAppID = -1;
            AppointmentDate = DateTime.Now;
            PaidFees = 0;
            CreatedByUserID = -1;
            IsLocked = false;
        }

        private clsTestAppointment(int ID, int TestTypeID, int LDLAppID, DateTime AppointmentDate, 
            double PaidFees, int CreatedByUserID, bool IsLocked)
        {
            _Mode = clsGlobalSettings.enMode.Update;

            this.ID = ID;
            this.TestTypeID = TestTypeID;
            this.LDLAppID = LDLAppID;
            this.AppointmentDate = AppointmentDate;
            this.PaidFees = PaidFees;
            this.CreatedByUserID = CreatedByUserID;
            this.IsLocked = IsLocked;
        }

        private bool _AddNewTestAppointment()
        {
            this.ID = clsTestAppointmentData.AddNewTestAppointment(TestTypeID, LDLAppID, AppointmentDate, PaidFees, CreatedByUserID, IsLocked);

            return ID != -1;
        }
        private bool _UpdateTestAppointment()
        {
            return clsTestAppointmentData.UpdateTestAppointment(ID, TestTypeID, LDLAppID, AppointmentDate, PaidFees, CreatedByUserID, IsLocked);
        }


        public static clsTestAppointment Find(int TestAppointmentID)
        {
            int TestTypeID = -1;
            int LDLAppID = -1;
            DateTime AppointmentDate = DateTime.Now;
            double PaidFees = 0;
            int CreatedByUserID = -1;
            bool IsLocked = false;

            if (clsTestAppointmentData.GetTestAppointmentInfo(TestAppointmentID, ref TestTypeID, 
                ref LDLAppID, ref AppointmentDate, ref PaidFees, ref CreatedByUserID, ref IsLocked))
                return new clsTestAppointment(TestAppointmentID, TestTypeID, LDLAppID, AppointmentDate, PaidFees, CreatedByUserID, IsLocked);
            else
                return null;
        }

        public bool Save()
        {
            switch (_Mode)
            {
                case clsGlobalSettings.enMode.AddNew:
                    _Mode = clsGlobalSettings.enMode.Update;
                    return _AddNewTestAppointment();

                case clsGlobalSettings.enMode.Update:
                    return _UpdateTestAppointment();

                default:
                    return false;
            }
        }


        public static bool DeleteTestAppointment(int TestAppointmentID)
        {
            return clsTestAppointmentData.DeleteTestAppointment(TestAppointmentID);
        }

        public static byte GetTestTrials(int LocalDrivingLicenseApplicationID, int TestTypeID)
        {
            return clsTestAppointmentData.GetTestTrials(LocalDrivingLicenseApplicationID, TestTypeID);
        }
        public static bool DoesHasAnActiveAppointment(int TestTypeID, int LocalDrivingLicenseApplicationID)
        {
            return clsTestAppointmentData.DoesHasAnActiveAppointment(TestTypeID, LocalDrivingLicenseApplicationID);
        }
        public static DataTable GetTestAppointments(int LocalDrivingLicenseApplicationID, int TestTypeID)
        {
            return clsTestAppointmentData.GetTestAppointments(LocalDrivingLicenseApplicationID, TestTypeID);
        }

        public static bool IsAppointmentLocked(int TestAppointmentID)
        {
            return clsTestAppointmentData.IsAppointmentLocked(TestAppointmentID);
        }


    }
}
