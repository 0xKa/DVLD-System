using DVLD_DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace DVLD_BusinessLogicLayer
{
    public class clsTestAppointment
    {
        clsGlobalSettings.enMode _Mode = clsGlobalSettings.enMode.AddNew;

        public int ID { get; set; }
        public int TestTypeID { get; set; }
        public int LocalLicenseApplicationID { get; set; }
        public DateTime AppointmentDate { get; set; }
        public decimal PaidFees { get; set; }
        public bool IsLocked { get; set; }
        public int CreatedByUserID { get; set; }

        public clsTestType.enTestType enTestType
        {
            set { TestTypeID = (int)value; }
            get { return (clsTestType.enTestType)TestTypeID; }
        }

        public clsTestType TestType = null;
        public clsLocalLicenseApplication LocalLicenseApplication = null;
        public clsUser User = null;

        public clsTestAppointment()
        {
            _Mode = clsGlobalSettings.enMode.AddNew;
            ID = -1;
            TestTypeID = -1;
            LocalLicenseApplicationID = -1;
            AppointmentDate = DateTime.MinValue;
            PaidFees = 0m;
            IsLocked = false;
            CreatedByUserID = -1;
        }

        private clsTestAppointment(int ID, int TestTypeID, int LocalLicenseApplicationID, DateTime AppointmentDate,
            decimal PaidFees, bool IsLocked, int CreatedByUserID)
        {
            _Mode = clsGlobalSettings.enMode.Update;

            this.ID = ID;
            this.TestTypeID = TestTypeID;
            this.LocalLicenseApplicationID = LocalLicenseApplicationID;
            this.AppointmentDate = AppointmentDate;
            this.PaidFees = PaidFees;
            this.IsLocked = IsLocked;
            this.CreatedByUserID = CreatedByUserID;

            this.TestType = clsTestType.Find(TestTypeID);
            this.LocalLicenseApplication = clsLocalLicenseApplication.FindByLLApplicationID(LocalLicenseApplicationID);
            this.User = clsUser.Find(CreatedByUserID);

        }

        private bool _AddNewTestAppointment()
        {
            this.ID = clsTestAppointmentData.AddNewTestAppointment(TestTypeID, LocalLicenseApplicationID,
                AppointmentDate, PaidFees, IsLocked, CreatedByUserID);

            return ID != -1;
        }

        private bool _UpdateTestAppointment()
        {
            return clsTestAppointmentData.UpdateTestAppointment(ID, TestTypeID, LocalLicenseApplicationID,
                AppointmentDate, PaidFees, IsLocked, CreatedByUserID);
        }

        public static clsTestAppointment Find(int ID)
        {
            int TestTypeID = -1;
            int LocalLicenseApplicationID = -1;
            DateTime AppointmentDate = DateTime.MinValue;
            decimal PaidFees = 0m;
            bool IsLocked = false;
            int CreatedByUserID = -1;

            if (clsTestAppointmentData.GetTestAppointmentInfo(ID, ref TestTypeID, ref LocalLicenseApplicationID,
                ref AppointmentDate, ref PaidFees, ref IsLocked, ref CreatedByUserID))
                return new clsTestAppointment(ID, TestTypeID, LocalLicenseApplicationID, AppointmentDate,
                    PaidFees, IsLocked, CreatedByUserID);
            else
                return null;
        }
        
        public static clsTestAppointment GetLastTestAppointment(int LocalLicenseApplicationID, int TestTypeID)
        {
            int ID = -1;
            DateTime AppointmentDate = DateTime.MinValue;
            decimal PaidFees = 0m;
            bool IsLocked = false;
            int CreatedByUserID = -1;

            if (clsTestAppointmentData.GetLastTestAppointmentInfo(LocalLicenseApplicationID, TestTypeID, ref ID,
                ref AppointmentDate, ref PaidFees, ref IsLocked, ref CreatedByUserID))
                return new clsTestAppointment(ID, TestTypeID, LocalLicenseApplicationID, AppointmentDate,
                    PaidFees, IsLocked, CreatedByUserID);
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

        public static bool DeleteTestAppointment(int ID)
        {
            return clsTestAppointmentData.DeleteTestAppointment(ID);
        }

        public static DataTable GetAllTestAppointments()
        {
            return clsTestAppointmentData.GetAllTestAppointments();
        }
    }

}
