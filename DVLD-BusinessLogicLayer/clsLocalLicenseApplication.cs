using DVLD_DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace DVLD_BusinessLogicLayer
{
    public class clsLocalLicenseApplication : clsApplication
    {
        clsGlobalSettings.enMode _Mode = clsGlobalSettings.enMode.AddNew;

        public int ID { get; set; }
        public int LicenseClassID { get; set; }

        public clsLicenseClass LicenseClassInfo = null;

        public clsLocalLicenseApplication()
        {
            _Mode = clsGlobalSettings.enMode.AddNew;
            
            ID = -1;
            LicenseClassID = -1;
        }

        private clsLocalLicenseApplication(int LLApplicationID, int ApplicationID, int ApplicantPersonID, int TypeID, DateTime ApplicationDate, byte Status, DateTime LastStatusDate, decimal Fees, int CreatedByUserID, int LicenseClassID)
        {
            _Mode = clsGlobalSettings.enMode.Update;

            this.ID = LLApplicationID;
            this.ApplicationID = ApplicationID;
            this.ApplicantPersonID = ApplicantPersonID;
            this.TypeID = TypeID;
            this.ApplicationDate = ApplicationDate;
            this.Status = Status;
            this.LastStatusDate = LastStatusDate;
            this.Fees = Fees;
            this.CreatedByUserID = CreatedByUserID;
            this.LicenseClassID = LicenseClassID;

            this.LicenseClassInfo = clsLicenseClass.Find(this.LicenseClassID);
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

        public static clsLocalLicenseApplication FindByLLApplicationID(int LLApplicationID)
        {
            int ApplicationID = -1, LicenseClassID = -1;

            if (clsLocalLicenseApplicationData.GetLocalLicenseApplicationInfo(LLApplicationID, ref ApplicationID, ref LicenseClassID))
            {
                clsApplication application = clsApplication.FindBase(ApplicationID); //get base application properties
                return new clsLocalLicenseApplication(LLApplicationID, ApplicationID, application.ApplicantPersonID, application.TypeID, application.ApplicationDate, application.Status, application.LastStatusDate, application.Fees, application.CreatedByUserID, LicenseClassID);
            }
            else
                return null;
        }

        public static clsLocalLicenseApplication FindByApplicationID(int ApplicationID)
        {
            int LLApplicationID = -1, LicenseClassID = -1;

            if (clsLocalLicenseApplicationData.GetLocalLicenseApplicationInfoByApplicationID(ApplicationID, ref LLApplicationID, ref LicenseClassID))
            {
                clsApplication application = clsApplication.FindBase(ApplicationID); //get base application properties
                return new clsLocalLicenseApplication(LLApplicationID, ApplicationID, application.ApplicantPersonID, application.TypeID, application.ApplicationDate, application.Status, application.LastStatusDate, application.Fees, application.CreatedByUserID, LicenseClassID);
            }
            else
                return null;
        }

        public new bool Save()
        {
            if (!base.Save()) //save base applcation to database first then LLApplication 
                return false;

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
        public static bool DeleteLocalLicenseApplication(int LLApplicationID)
        {
            return clsLocalLicenseApplicationData.DeleteLocalLicenseApplication(LLApplicationID);
        }
        public static DataTable GetAllLocalLicenseApplications()
        {
            return clsLocalLicenseApplicationData.GetAllLocalLicenseApplications();
        }
    }

}
