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

        public enum enIssueReason {
            FirstTime = 1, 
            Renew = 2,
            ReplacementForDamaged = 3,
            ReplacementForLost = 4
        }

        public int ID { get; set; }
        public int ApplicationID { get; set; }
        public int DriverID { get; set; }
        public int LicenseClassID { get; set; }
        public DateTime IssueDate { get; set; }
        public DateTime ExpirationDate { get; set; }
        public string Notes { get; set; }
        public decimal PaidFees { get; set; }
        public bool IsActive { get; set; }
        public byte IssueReason { get; set; }
        public int CreatedByUserID { get; set; }

        public enIssueReason EnIssueReason
        {
            get { return (enIssueReason)IssueReason; }
            set { IssueReason = (byte)value; }
        }
        public string IssueReasonText
        {
            get
            {
                switch (EnIssueReason)
                {
                    case enIssueReason.FirstTime:
                        return "First Time License";
                    case enIssueReason.Renew:
                        return "Renew";
                    case enIssueReason.ReplacementForDamaged:
                        return "Replacement For Damaged License";
                    case enIssueReason.ReplacementForLost:
                        return "Replacement For Lost License";
                    default:
                        return "N\\A";
                }
            }
        }

        public bool IsDetained
        {
            get { return false; }//call a method to check //koko
        }

        public bool IsExpired
        {
            get { return DateTime.Today >= this.ExpirationDate.Date; } //ignore the time component
        }

        public clsApplication ApplicationInfo = null;
        public clsDriver DriverInfo = null;
        public clsLicenseClass LicenseClass = null;
        public clsUser CreatedByUser = null;

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
            IssueReason = 0;
            CreatedByUserID = -1;
        }

        private clsLicense(int ID, int ApplicationID, int DriverID, int LicenseClassID,
            DateTime IssueDate, DateTime ExpirationDate, string Notes, decimal PaidFees,
            bool IsActive, byte IssueReason, int CreatedByUserID)
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

            this.ApplicationInfo = clsApplication.FindBase(ApplicationID);
            this.DriverInfo = clsDriver.Find(DriverID);
            this.LicenseClass = clsLicenseClass.Find(LicenseClassID);
            this.CreatedByUser = clsUser.Find(CreatedByUserID);
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
            byte IssueReason = 0;
            int CreatedByUserID = -1;

            if (clsLicenseData.GetLicenseInfo(ID, ref ApplicationID, ref DriverID, ref LicenseClassID,
                ref IssueDate, ref ExpirationDate, ref Notes, ref PaidFees, ref IsActive,
                ref IssueReason, ref CreatedByUserID))
                return new clsLicense(ID, ApplicationID, DriverID, LicenseClassID, IssueDate,
                    ExpirationDate, Notes, PaidFees, IsActive, IssueReason, CreatedByUserID);
            else
                return null;
        }
        
        public static clsLicense FindByApplicationID(int ApplicationID)
        {
            int ID = -1;
            int DriverID = -1;
            int LicenseClassID = -1;
            DateTime IssueDate = DateTime.MinValue;
            DateTime ExpirationDate = DateTime.MinValue;
            string Notes = string.Empty;
            decimal PaidFees = 0;
            bool IsActive = true;
            byte IssueReason = 0;
            int CreatedByUserID = -1;

            if (clsLicenseData.GetLicenseInfoByApplicationID(ApplicationID, ref ID, ref DriverID, ref LicenseClassID,
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



        public static bool IsLicenseExist(int ID)
        {
            return clsLicenseData.IsLicenseExist(ID);
        }

        public static bool DoesDriverHasActiveLicense(int DriverID, int LicenseClassID)
        {
            return clsLicenseData.DoesDriverHasActiveLicense(DriverID, LicenseClassID);
        }

        public bool DeactivateLicense()
        {
            return clsLicenseData.DeactivateLicense(this.ID);
        }

        public clsLicense Renew(string notes)
        {
            clsApplication RenewApplication = new clsApplication()
            {
                ApplicantPersonID = this.DriverInfo.PersonID,
                ApplicationDate = DateTime.Now,
                enType = clsApplicationType.enApplicationType.RenewDrivingLicense,
                enStatus = clsApplication.enApplicationStatus.Completed,
                LastStatusDate = DateTime.Now,
                Fees = clsApplicationType.GetApplicationFees(clsApplicationType.enApplicationType.RenewDrivingLicense),
                CreatedByUserID = clsGlobalSettings.LoggedInUser.ID
            };
            if (RenewApplication.Save())
                clsLocalLicenseApplicationData.LinkApplicationWithLocalApplication(RenewApplication.ApplicationID, this.ApplicationID);
            else
                return null;

            clsLicense NewLicense = new clsLicense()
            {
                ApplicationID = RenewApplication.ApplicationID,
                DriverID = this.DriverID,
                LicenseClassID = this.LicenseClassID,
                IssueDate = DateTime.Now,
                ExpirationDate = DateTime.Now.AddYears(this.LicenseClass.ValidityYears),
                Notes = notes,
                PaidFees = this.LicenseClass.Fees,
                IsActive = true,
                EnIssueReason = enIssueReason.Renew,
                CreatedByUserID = clsGlobalSettings.LoggedInUser.ID
            };
            if (!NewLicense.Save())
                return null;

            this.DeactivateLicense();
            return clsLicense.Find(NewLicense.ID); //i use find() to fill up composition members
        }
        public clsLicense Replace(clsApplicationType.enApplicationType ReplacementType, string notes)
        {
            clsApplication ReplacementApplication = new clsApplication()
            {
                ApplicantPersonID = this.DriverInfo.PersonID,
                ApplicationDate = DateTime.Now,
                enType = ReplacementType,
                enStatus = clsApplication.enApplicationStatus.Completed,
                LastStatusDate = DateTime.Now,
                Fees = clsApplicationType.GetApplicationFees(ReplacementType),
                CreatedByUserID = clsGlobalSettings.LoggedInUser.ID
            };
            if (ReplacementApplication.Save())
                clsLocalLicenseApplicationData.LinkApplicationWithLocalApplication(ReplacementApplication.ApplicationID, this.ApplicationID);
            else
                return null;

            clsLicense NewLicense = new clsLicense()
            {
                ApplicationID = ReplacementApplication.ApplicationID,
                DriverID = this.DriverID,
                LicenseClassID = this.LicenseClassID,
                IssueDate = DateTime.Now,
                ExpirationDate = this.ExpirationDate, //exp. date can't be changed becasue it is a replacment not renew 
                Notes = notes,
                PaidFees = this.LicenseClass.Fees,
                IsActive = true,
                EnIssueReason = (enIssueReason)ReplacementType,
                CreatedByUserID = clsGlobalSettings.LoggedInUser.ID
            };
            if (!NewLicense.Save())
                return null;


            this.DeactivateLicense();
            return clsLicense.Find(NewLicense.ID); 
        }
        public clsDetainedLicense Detain(decimal fineFees)
        {
            clsDetainedLicense DetainedLicense = new clsDetainedLicense()
            {
                LicenseID = this.ID,
                DetainDate = DateTime.Now,
                FineFees = fineFees,
                CreatedByUserID = clsGlobalSettings.LoggedInUser.ID,
                IsReleased = false,

                ReleasedDate = null,
                ReleaseApplicationID = null,
                ReleasedByUserID = null

            };

            this.DeactivateLicense();

            DetainedLicense.Save();
            return clsDetainedLicense.Find(DetainedLicense.ID);
        }
    }
}
