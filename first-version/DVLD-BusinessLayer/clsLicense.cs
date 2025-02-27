﻿using DVLD_DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLD_BusinessLayer
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
        public double PaidFees { get; set; }
        public bool IsActive { get; set; }
        public byte IssueReason { get; set; }
        public int CreatedByUserID { get; set; }

        public clsLicense()
        {
            _Mode = clsGlobalSettings.enMode.AddNew;
            ID = -1;
            ApplicationID = -1;
            DriverID = -1;
            LicenseClassID = -1;
            IssueDate = DateTime.Now;
            ExpirationDate = DateTime.Now.AddYears(1);
            Notes = string.Empty;
            PaidFees = 0.0;
            IsActive = true;
            IssueReason = 0;
            CreatedByUserID = -1;
        }

        private clsLicense(int LicenseID, int ApplicationID, int DriverID, int LicenseClassID, DateTime IssueDate, DateTime ExpirationDate, string Notes, double PaidFees, bool IsActive, byte IssueReason, int CreatedByUserID)
        {
            _Mode = clsGlobalSettings.enMode.Update;
            this.ID = LicenseID;
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
            this.ID = clsLicenseData.AddNewLicense(ApplicationID, DriverID, LicenseClassID, IssueDate, ExpirationDate, Notes, PaidFees, IsActive, IssueReason, CreatedByUserID);
            return ID != -1;
        }

        private bool _UpdateLicense()
        {
            return clsLicenseData.UpdateLicense(ID, ApplicationID, DriverID, LicenseClassID, IssueDate, ExpirationDate, Notes, PaidFees, IsActive, IssueReason, CreatedByUserID);
        }

        public static clsLicense Find(int LicenseID)
        {
            int ApplicationID = -1;
            int DriverID = -1;
            int LicenseClassID = -1;
            DateTime IssueDate = DateTime.Now;
            DateTime ExpirationDate = DateTime.Now;
            string Notes = string.Empty;
            double PaidFees = 0.0;
            bool IsActive = true;
            byte IssueReason = 0;
            int CreatedByUserID = -1;

            if (clsLicenseData.GetLicenseInfo(LicenseID, ref ApplicationID, ref DriverID, ref LicenseClassID, ref IssueDate, ref ExpirationDate, ref Notes, ref PaidFees, ref IsActive, ref IssueReason, ref CreatedByUserID))
                return new clsLicense(LicenseID, ApplicationID, DriverID, LicenseClassID, IssueDate, ExpirationDate, Notes, PaidFees, IsActive, IssueReason, CreatedByUserID);
            else
                return null;
        }
        
        public static clsLicense FindByApplicationID(int ApplicationID)
        {
            int LicenseID = -1;
            int DriverID = -1;
            int LicenseClassID = -1;
            DateTime IssueDate = DateTime.Now;
            DateTime ExpirationDate = DateTime.Now;
            string Notes = string.Empty;
            double PaidFees = 0.0;
            bool IsActive = true;
            byte IssueReason = 0;
            int CreatedByUserID = -1;

            if (clsLicenseData.GetLicenseInfoByApplicationID(ApplicationID, ref LicenseID, ref DriverID, ref LicenseClassID, ref IssueDate, ref ExpirationDate, ref Notes, ref PaidFees, ref IsActive, ref IssueReason, ref CreatedByUserID))
                return new clsLicense(LicenseID, ApplicationID, DriverID, LicenseClassID, IssueDate, ExpirationDate, Notes, PaidFees, IsActive, IssueReason, CreatedByUserID);
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

        public static bool DeleteLicense(int LicenseID)
        {
            return clsLicenseData.DeleteLicense(LicenseID);
        }

        public static bool IsLicenseExists(int LicenseID)
        {
            return clsLicenseData.IsLicenseExists(LicenseID);
        }

        public static string GetIssueReasonString(byte IssueReason)
        {
            clsGlobalSettings.enIssueReason enIssueReason = (clsGlobalSettings.enIssueReason)IssueReason;
            switch (enIssueReason)
            {
                case clsGlobalSettings.enIssueReason.FirstTime:
                    return "First Time";
                    
                case clsGlobalSettings.enIssueReason.Renew:
                    return "Renew";
                    
                case clsGlobalSettings.enIssueReason.ReplaceForLost:
                    return "Replacment For Lost";
                    
                case clsGlobalSettings.enIssueReason.ReplaceForDamage:
                    return "Replacment For Damage";

                default:
                    return "First Time";
            }
        }

        public static int GetLicenseIDByApplicationID(int ApplicationID)
        {
            return clsLicenseData.GetLicenseIDByApplicationID(ApplicationID);
        }

        public static DataTable GetLicensesOfADriver(int DriverID)
        {
            return clsLicenseData.GetLicensesOfADriver(DriverID);
        }

        public bool ChangeActiveState(bool IsActive)
        {
            this.IsActive = IsActive;
            return this.Save();
        }

    }
}
