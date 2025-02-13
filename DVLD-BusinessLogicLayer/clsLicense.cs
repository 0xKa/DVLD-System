using DVLD_DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLD_BusinessLogicLayer
{
    public class clsLicense
    {
        clsGlobalSettings.enMode _Mode = clsGlobalSettings.enMode.AddNew;

        public int ID { get; set; }
        public int ApplicationID { get; set; }
        public int DriverID { get; set; }
        public int LicenseClassID { get; set; }
        public DateTime IssueDate { get; set; }
        public DateTime ExpirationDate { get; set; }
        public string Notes { get; set; }
        public decimal PaidFees { get; set; }
        public bool IsActive { get; set; }
        public string IssueReason { get; set; }
        public int CreatedByUserID { get; set; }

        public clsLicense()
        {
            _Mode = clsGlobalSettings.enMode.AddNew;

            ID = -1;
            ApplicationID = -1;
            DriverID = -1;
            LicenseClassID = -1;
            IssueDate = DateTime.MinValue;
            ExpirationDate = DateTime.MinValue;
            Notes = string.Empty;
            PaidFees = 0;
            IsActive = true;
            IssueReason = string.Empty;
            CreatedByUserID = -1;
        }

        private clsLicense(int ID, int ApplicationID, int DriverID, int LicenseClassID,
            DateTime IssueDate, DateTime ExpirationDate, string Notes, decimal PaidFees,
            bool IsActive, string IssueReason, int CreatedByUserID)
        {
            _Mode = clsGlobalSettings.enMode.Update;

            this.ID = ID;
            this.ApplicationID = ApplicationID;
            this.DriverID = DriverID;
            this.LicenseClassID = LicenseClassID;
            this.IssueDate = IssueDate;
            this.ExpirationDate = ExpirationDate;
            this.Notes = Notes;
            this.PaidFees = PaidFees;
            this.IsActive = IsActive;
            this.IssueReason = IssueReason;
            this.CreatedByUserID = CreatedByUserID;
        }

        private bool _AddNewLicense()
        {
            this.ID = clsLicenseData.AddNewLicense(ApplicationID, DriverID, LicenseClassID,
                IssueDate, ExpirationDate, Notes, PaidFees, IsActive, IssueReason, CreatedByUserID);

            return ID != -1;
        }

        private bool _UpdateLicense()
        {
            return clsLicenseData.UpdateLicense(ID, ApplicationID, DriverID, LicenseClassID,
                IssueDate, ExpirationDate, Notes, PaidFees, IsActive, IssueReason, CreatedByUserID);
        }

        public static clsLicense Find(int ID)
        {
            int ApplicationID = -1;
            int DriverID = -1;
            int LicenseClassID = -1;
            DateTime IssueDate = DateTime.MinValue;
            DateTime ExpirationDate = DateTime.MinValue;
            string Notes = string.Empty;
            decimal PaidFees = 0;
            bool IsActive = true;
            string IssueReason = string.Empty;
            int CreatedByUserID = -1;

            if (clsLicenseData.GetLicenseInfo(ID, ref ApplicationID, ref DriverID, ref LicenseClassID,
                ref IssueDate, ref ExpirationDate, ref Notes, ref PaidFees, ref IsActive,
                ref IssueReason, ref CreatedByUserID))
                return new clsLicense(ID, ApplicationID, DriverID, LicenseClassID, IssueDate,
                    ExpirationDate, Notes, PaidFees, IsActive, IssueReason, CreatedByUserID);
            else
                return null;
        }

        public bool Save()
        {
            switch (_Mode)
            {
                case clsGlobalSettings.enMode.AddNew:
                    _Mode = clsGlobalSettings.enMode.Update;
                    return _AddNewLicense();

                case clsGlobalSettings.enMode.Update:
                    return _UpdateLicense();

                default:
                    return false;
            }
        }

        public static bool DeleteLicense(int ID)
        {
            return clsLicenseData.DeleteLicense(ID);
        }

        public static DataTable GetAllLicenses()
        {
            return clsLicenseData.GetAllLicenses();
        }

        public static bool IsLicenseExist(int ID)
        {
            return clsLicenseData.IsLicenseExist(ID);
        }
    }
}
