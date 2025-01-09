using DVLD_DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLD_BusinessLayer
{
    public class clsLocalDLApplication
    {
        private clsGlobalSettings.enMode _Mode = clsGlobalSettings.enMode.AddNew;

        public int ID {  get; set; }
        public int ApplicationID { get; set; }
        public int LicenseClassID { get; set; }


        public clsLocalDLApplication()
        {
            _Mode = clsGlobalSettings.enMode.AddNew;
            ID = -1;
            ApplicationID = -1;
            LicenseClassID = -1;
        }

        private clsLocalDLApplication(int LocalDLApplicationID, int ApplicationID, int LicenseClassID)
        {
            _Mode = clsGlobalSettings.enMode.Update;

            this.ID = LocalDLApplicationID;
            this.ApplicationID = ApplicationID;
            this.LicenseClassID = LicenseClassID;
        }

        private bool _AddNewApplication()
        {
            this.ID = clsLocalDLApplicationData.AddNewLDLApplication(ApplicationID, LicenseClassID);

            return ID != -1;
        }
        
        private bool _UpdateApplication()
        {
            return clsLocalDLApplicationData.UpdateLDLApplication(ID, ApplicationID, LicenseClassID);

        }

        public static bool DeleteApplication(int ID)
        {
            return clsLocalDLApplicationData.DeleteLDLApplication(ID);
        }

        public static clsLocalDLApplication Find(int LocalDLApplicationID)
        {
            int ApplicationID = -1;
            int LicenseClassID = -1;

            if (clsLocalDLApplicationData.GetLDLApplicationInfo(LocalDLApplicationID, ref ApplicationID, ref LicenseClassID))
            {
                return new clsLocalDLApplication(LocalDLApplicationID, ApplicationID, LicenseClassID);
            }
            else
                return null;

        }

        public bool Save()
        {
            switch (_Mode)
            {
                case clsGlobalSettings.enMode.AddNew:
                    _Mode = clsGlobalSettings.enMode.Update;
                    return _AddNewApplication();

                case clsGlobalSettings.enMode.Update:
                    return _UpdateApplication();

                default:
                    return false;
            }
        }

        public static DataTable GetLocalDrivingLicenseApplication_View()
        {
            return clsLocalDLApplicationData.GetLocalDrivingLicenseApplication_View();
        }

        public static bool IsApplicationAllowed(int ApplicantPersonID, int LicenseClassID)
        {
            return clsLocalDLApplicationData.IsApplicationAllowed(ApplicantPersonID, LicenseClassID);
        }

        public static bool IsApplicationExists(int LocalDrivingLicenseApplicationID)
        {
            return clsLocalDLApplicationData.IsApplicationExist(LocalDrivingLicenseApplicationID);
        }

        public static byte GetPassedTestCount(int LocalDrivingLicenseApplicationID)
        {
            return clsLocalDLApplicationData.GetPassedTestCount(LocalDrivingLicenseApplicationID);
        }

    }
}
