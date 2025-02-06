using DVLD_DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLD_BusinessLogicLayer
{
    public class clsLocalLicenseApplication
    {
        clsGlobalSettings.enMode _Mode = clsGlobalSettings.enMode.AddNew;

        public int ID { get; set; }
        public int ApplicationID { get; set; }
        public int LicenseClassID { get; set; }

        public clsLocalLicenseApplication()
        {
            _Mode = clsGlobalSettings.enMode.AddNew;

            ID = -1;
            ApplicationID = -1;
            LicenseClassID = -1;
        }

        private clsLocalLicenseApplication(int ID, int ApplicationID, int LicenseClassID)
        {
            _Mode = clsGlobalSettings.enMode.Update;

            this.ID = ID;
            this.ApplicationID = ApplicationID;
            this.LicenseClassID = LicenseClassID;
        }

        private bool _AddNewLocalLicenseApplication()
        {
            this.ID = clsLocalLicenseApplicationData.AddNewLocalLicenseApplication(ApplicationID, LicenseClassID);
            return ID != -1;
        }

        private bool _UpdateLocalLicenseApplication()
        {
            return clsLocalLicenseApplicationData.UpdateLocalLicenseApplication(ID, ApplicationID, LicenseClassID);
        }

        public static clsLocalLicenseApplication Find(int ID)
        {
            int ApplicationID = -1, LicenseClassID = -1;

            if (clsLocalLicenseApplicationData.GetLocalLicenseApplicationInfo(ID, ref ApplicationID, ref LicenseClassID))
                return new clsLocalLicenseApplication(ID, ApplicationID, LicenseClassID);
            else
                return null;
        }

        public static clsLocalLicenseApplication FindByApplicationID(int ApplicationID)
        {
            int ID = -1, LicenseClassID = -1;

            if (clsLocalLicenseApplicationData.GetLocalLicenseApplicationInfoByApplicationID(ApplicationID, ref ID, ref LicenseClassID))
                return new clsLocalLicenseApplication(ID, ApplicationID, LicenseClassID);
            else
                return null;
        }


        public bool Save()
        {
            switch (_Mode)
            {
                case clsGlobalSettings.enMode.AddNew:
                    _Mode = clsGlobalSettings.enMode.Update;
                    return _AddNewLocalLicenseApplication();

                case clsGlobalSettings.enMode.Update:
                    return _UpdateLocalLicenseApplication();

                default:
                    return false;
            }
        }

        public static bool DeleteLocalLicenseApplication(int ID)
        {
            return clsLocalLicenseApplicationData.DeleteLocalLicenseApplication(ID);
        }

        public static DataTable GetAllLocalLicenseApplications()
        {
            return clsLocalLicenseApplicationData.GetAllLocalLicenseApplications();
        }
    }

}
