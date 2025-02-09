using DVLD_DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLD_BusinessLogicLayer
{
    public class clsTest
    {
        clsGlobalSettings.enMode _Mode = clsGlobalSettings.enMode.AddNew;

        public int ID { get; set; }
        public int TestAppointmentID { get; set; }
        public bool Result { get; set; }
        public string Notes { get; set; }
        public int CreatedByUserID { get; set; }

        public clsTestAppointment TestAppointment = null;
        public clsUser User = null;

        public clsTest()
        {
            _Mode = clsGlobalSettings.enMode.AddNew;
            ID = -1;
            TestAppointmentID = -1;
            Result = false;
            Notes = string.Empty;
            CreatedByUserID = -1;
        }

        private clsTest(int ID, int TestAppointmentID, bool Result, string Notes, int CreatedByUserID)
        {
            _Mode = clsGlobalSettings.enMode.Update;

            this.ID = ID;
            this.TestAppointmentID = TestAppointmentID;
            this.Result = Result;
            this.Notes = Notes;
            this.CreatedByUserID = CreatedByUserID;

            this.TestAppointment = clsTestAppointment.Find(TestAppointmentID);
            this.User = clsUser.Find(CreatedByUserID);
        }

        private bool _AddNewTest()
        {
            this.ID = clsTestData.AddNewTest(TestAppointmentID, Result, Notes, CreatedByUserID);
            return ID != -1;
        }

        private bool _UpdateTest()
        {
            return clsTestData.UpdateTest(ID, TestAppointmentID, Result, Notes, CreatedByUserID);
        }

        public static clsTest Find(int ID)
        {
            int TestAppointmentID = -1;
            bool Result = false;
            string Notes = string.Empty;
            int CreatedByUserID = -1;

            if (clsTestData.GetTestInfo(ID, ref TestAppointmentID, ref Result, ref Notes, ref CreatedByUserID))
                return new clsTest(ID, TestAppointmentID, Result, Notes, CreatedByUserID);
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

        public static bool DeleteTest(int ID)
        {
            return clsTestData.DeleteTest(ID);
        }

        public static DataTable GetAllTests()
        {
            return clsTestData.GetAllTests();
        }

        public static bool IsPassedTest(int LocalLicenseApplication, clsTestType.enTestType TestType)
        {
            return clsTestData.IsPassedTest(LocalLicenseApplication, (int)TestType);
        }
    }

}
