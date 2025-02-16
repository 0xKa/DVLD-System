using DVLD_DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLD_BusinessLogicLayer
{
    public class clsInternationalLicense
    {
        clsGlobalSettings.enMode _Mode = clsGlobalSettings.enMode.AddNew;

        public int ID { get; set; }
        public int ApplicationID { get; set; }
        public int DriverID { get; set; }
        public int LocalLicenseID { get; set; }
        public DateTime IssueDate { get; set; }
        public DateTime ExpirationDate { get; set; }
        public bool IsActive { get; set; }
        public int CreatedByUserID { get; set; }

        public clsInternationalLicense()
        {
            _Mode = clsGlobalSettings.enMode.AddNew;

            ID = -1;
            ApplicationID = -1;
            DriverID = -1;
            LocalLicenseID = -1;
            IssueDate = DateTime.MinValue;
            ExpirationDate = DateTime.MinValue;
            IsActive = true; // Default to active
            CreatedByUserID = -1;
        }

        private clsInternationalLicense(int ID, int ApplicationID, int DriverID, int LocalLicenseID,
            DateTime IssueDate, DateTime ExpirationDate, bool IsActive, int CreatedByUserID)
        {
            _Mode = clsGlobalSettings.enMode.Update;

            this.ID = ID;
            this.ApplicationID = ApplicationID;
            this.DriverID = DriverID;
            this.LocalLicenseID = LocalLicenseID;
            this.IssueDate = IssueDate;
            this.ExpirationDate = ExpirationDate;
            this.IsActive = IsActive;
            this.CreatedByUserID = CreatedByUserID;
        }

        private bool _AddNewInternationalLicense()
        {
            this.ID = clsInternationalLicenseData.AddNewInternationalLicense(ApplicationID, DriverID, LocalLicenseID,
                IssueDate, ExpirationDate, IsActive, CreatedByUserID);

            return ID != -1;
        }

        private bool _UpdateInternationalLicense()
        {
            return clsInternationalLicenseData.UpdateInternationalLicense(ID, ApplicationID, DriverID, LocalLicenseID,
                IssueDate, ExpirationDate, IsActive, CreatedByUserID);
        }

        public static clsInternationalLicense Find(int ID)
        {
            int ApplicationID = -1;
            int DriverID = -1;
            int LocalLicenseID = -1;
            DateTime IssueDate = DateTime.MinValue;
            DateTime ExpirationDate = DateTime.MinValue;
            bool IsActive = false;
            int CreatedByUserID = -1;

            if (clsInternationalLicenseData.GetInternationalLicenseInfo(ID, ref ApplicationID, ref DriverID, ref LocalLicenseID,
                ref IssueDate, ref ExpirationDate, ref IsActive, ref CreatedByUserID))
                return new clsInternationalLicense(ID, ApplicationID, DriverID, LocalLicenseID,
                    IssueDate, ExpirationDate, IsActive, CreatedByUserID);
            else
                return null;
        }

        public bool Save()
        {
            switch (_Mode)
            {
                case clsGlobalSettings.enMode.AddNew:
                    _Mode = clsGlobalSettings.enMode.Update;
                    return _AddNewInternationalLicense();

                case clsGlobalSettings.enMode.Update:
                    return _UpdateInternationalLicense();

                default:
                    return false;
            }
        }

        public static bool DeleteInternationalLicense(int ID)
        {
            return clsInternationalLicenseData.DeleteInternationalLicense(ID);
        }

        public static DataTable GetAllInternationalLicenses()
        {
            return clsInternationalLicenseData.GetAllInternationalLicenses();
        }

        public static bool IsInternationalLicenseExist(int ID)
        {
            return clsInternationalLicenseData.IsInternationalLicenseExist(ID);
        }
    }
}
