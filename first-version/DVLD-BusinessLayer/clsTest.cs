using DVLD_DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLD_BusinessLayer
{
    public class clsTest
    {
        private clsGlobalSettings.enMode _Mode = clsGlobalSettings.enMode.AddNew;

        public int ID { get; set; }
        public int TestAppointmentID { get; set; }
        public bool TestResult { get; set; }
        public string Notes { get; set; }
        public int CreatedByUserID { get; set; }

        public clsTest()
        {
            _Mode = clsGlobalSettings.enMode.AddNew;

            ID = -1;
            TestAppointmentID = -1;
            TestResult = false;
            Notes = string.Empty;
            CreatedByUserID = -1;
        }
        private clsTest(int ID, int TestAppointmentID, bool TestResult, string Notes, int CreatedByUserID)
        {
            _Mode = clsGlobalSettings.enMode.Update;

            this.ID = ID;
            this.TestAppointmentID = TestAppointmentID;
            this.TestResult = TestResult;
            this.Notes = Notes;
            this.CreatedByUserID = CreatedByUserID;
        }

        private bool _AddNewTest()
        {
            this.ID = clsTestsData.AddNewTest(TestAppointmentID, TestResult, Notes, CreatedByUserID);

            return ID != -1;
        }
        private bool _UpdateTest()
        {
            return clsTestsData.UpdateTest(ID, TestAppointmentID, TestResult, Notes, CreatedByUserID);
        }


        public static clsTest Find(int TestID)
        {
            int TestAppointmentID = -1;
            bool TestResult = false;
            string Notes = string.Empty;
            int CreatedByUserID = -1;

            if (clsTestsData.GetTestInfo(TestID, ref TestAppointmentID, ref TestResult, ref Notes, ref CreatedByUserID))
                return new clsTest(TestID, TestAppointmentID, TestResult, Notes, CreatedByUserID);
            else
                return null;
        }

        public bool Save()
        {
            switch (_Mode)
            {
                case clsGlobalSettings.enMode.AddNew:
                    _Mode = clsGlobalSettings.enMode.Update;
                    return _AddNewTest();

                case clsGlobalSettings.enMode.Update:
                    return _UpdateTest();

                default:
                    return false;
            }
        }


        public static bool DeleteTest(int TestID)
        {
            return clsTestsData.DeleteTest(TestID);
        }

        public static bool IsPassedThisTest(int TestTypeID, int LocalDrivingLicenseApplicationID)
        {
            return clsTestsData.IsPassedThisTest(TestTypeID, LocalDrivingLicenseApplicationID);
        }
        public static bool IsFailedThisTestBefore(int TestTypeID, int LocalDrivingLicenseApplicationID)
        {
            return clsTestsData.IsFailedThisTestBefore(TestTypeID, LocalDrivingLicenseApplicationID);
        }


    }
}
