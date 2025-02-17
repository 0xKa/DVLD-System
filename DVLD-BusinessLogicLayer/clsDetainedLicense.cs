using DVLD_DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLD_BusinessLogicLayer
{
    public class clsDetainedLicense
    {
        clsGlobalSettings.enMode _Mode = clsGlobalSettings.enMode.AddNew;

        public int ID { get; set; }
        public int LicenseID { get; set; }
        public DateTime DetainDate { get; set; }
        public decimal FineFees { get; set; }
        public int CreatedByUserID { get; set; }
        public bool IsReleased { get; set; }
        public DateTime? ReleasedDate { get; set; }
        public int? ReleasedByUserID { get; set; }
        public int? ReleaseApplicationID { get; set; }

        public clsLicense LicenseInfo = null;
        public clsUser CreatedByUser = null;
        public clsUser ReleasedByUser = null;
        public clsApplication ReleaseApplication = null;

        public clsDetainedLicense()
        {
            _Mode = clsGlobalSettings.enMode.AddNew;

            ID = -1;
            LicenseID = -1;
            DetainDate = DateTime.MinValue;
            FineFees = 0;
            CreatedByUserID = -1;
            IsReleased = false;
            ReleasedDate = null;
            ReleasedByUserID = null;
            ReleaseApplicationID = null;
        }

        private clsDetainedLicense(int ID, int LicenseID, DateTime DetainDate, decimal FineFees,
            int CreatedByUserID, bool IsReleased, DateTime? ReleasedDate, int? ReleasedByUserID, int? ReleaseApplicationID)
        {
            _Mode = clsGlobalSettings.enMode.Update;

            this.ID = ID;
            this.LicenseID = LicenseID;
            this.DetainDate = DetainDate;
            this.FineFees = FineFees;
            this.CreatedByUserID = CreatedByUserID;
            this.IsReleased = IsReleased;
            this.ReleasedDate = ReleasedDate;
            this.ReleasedByUserID = ReleasedByUserID;
            this.ReleaseApplicationID = ReleaseApplicationID;

            this.LicenseInfo = clsLicense.Find(LicenseID);
            this.CreatedByUser = clsUser.Find(CreatedByUserID);
            this.ReleasedByUser = ReleasedByUserID.HasValue ? clsUser.Find(ReleasedByUserID.Value) : null;
            this.ReleaseApplication = ReleaseApplicationID.HasValue ? clsApplication.FindBase(ReleaseApplicationID.Value) : null;

        }

        private bool _AddNewDetainedLicense()
        {
            this.ID = clsDetainedLicenseData.AddNewDetainedLicense(LicenseID, DetainDate, FineFees, CreatedByUserID,
                IsReleased, ReleasedDate, ReleasedByUserID, ReleaseApplicationID);

            return ID != -1;
        }

        private bool _UpdateDetainedLicense()
        {
            return clsDetainedLicenseData.UpdateDetainedLicense(ID, LicenseID, DetainDate, FineFees,
                CreatedByUserID, IsReleased, ReleasedDate, ReleasedByUserID, ReleaseApplicationID);
        }

        public static clsDetainedLicense Find(int ID)
        {
            int LicenseID = -1;
            DateTime DetainDate = DateTime.MinValue;
            decimal FineFees = 0;
            int CreatedByUserID = -1;
            bool IsReleased = false;
            DateTime? ReleasedDate = null;
            int? ReleasedByUserID = null;
            int? ReleaseApplicationID = null;

            if (clsDetainedLicenseData.GetDetainedLicenseInfo(ID, ref LicenseID, ref DetainDate, ref FineFees,
                ref CreatedByUserID, ref IsReleased, ref ReleasedDate, ref ReleasedByUserID, ref ReleaseApplicationID))
                return new clsDetainedLicense(ID, LicenseID, DetainDate, FineFees, CreatedByUserID,
                    IsReleased, ReleasedDate, ReleasedByUserID, ReleaseApplicationID);
            else
                return null;
        }

        public bool Save()
        {
            switch (_Mode)
            {
                case clsGlobalSettings.enMode.AddNew:
                    _Mode = clsGlobalSettings.enMode.Update;
                    return _AddNewDetainedLicense();

                case clsGlobalSettings.enMode.Update:
                    return _UpdateDetainedLicense();

                default:
                    return false;
            }
        }

        public static bool DeleteDetainedLicense(int ID)
        {
            return clsDetainedLicenseData.DeleteDetainedLicense(ID);
        }

        public static DataTable GetAllDetainedLicenses()
        {
            return clsDetainedLicenseData.GetAllDetainedLicenses();
        }

        public static bool IsLicenseDetained(int LicenseID)
        {
            return clsDetainedLicenseData.IsLicenseDetained(LicenseID);
        }
    }
}
