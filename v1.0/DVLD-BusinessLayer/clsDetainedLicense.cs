using DVLD_DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLD_BusinessLayer
{
    public class clsDetainedLicense
    {
        clsGlobalSettings.enMode _Mode = clsGlobalSettings.enMode.AddNew;

        public int ID { get; set; }
        public int LicenseID { get; set; }
        public DateTime DetainDate { get; set; }
        public double FineFees { get; set; }
        public int CreatedByUserID { get; set; }
        public bool IsReleased { get; set; }
        public DateTime? ReleasedDate { get; set; }
        public int ReleasedByUserID { get; set; }
        public int ReleaseApplicationID { get; set; }

        public clsDetainedLicense()
        {
            _Mode = clsGlobalSettings.enMode.AddNew;
            ID = -1;
            LicenseID = -1;
            DetainDate = DateTime.Now;
            FineFees = 0.0;
            CreatedByUserID = -1;
            IsReleased = false;
            ReleasedDate = null;
            ReleasedByUserID = -1;
            ReleaseApplicationID = -1;
        }

        private clsDetainedLicense(int ID, int LicenseID, DateTime DetainDate, double FineFees, int CreatedByUserID, bool IsReleased, DateTime? ReleasedDate, int ReleasedByUserID, int ReleaseApplicationID)
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
        }

        private bool _AddNewDetainedLicense()
        {
            this.ID = clsDetainedLicensesData.AddNewDetainedLicense(LicenseID, DetainDate, FineFees, CreatedByUserID, IsReleased, ReleasedDate, ReleasedByUserID, ReleaseApplicationID);
            return ID != -1;
        }

        private bool _UpdateDetainedLicense()
        {
            return clsDetainedLicensesData.UpdateDetainedLicense(ID, LicenseID, DetainDate, FineFees, CreatedByUserID, IsReleased, ReleasedDate, ReleasedByUserID, ReleaseApplicationID);
        }

        public static clsDetainedLicense Find(int DetainID)
        {
            int LicenseID = -1;
            DateTime DetainDate = DateTime.Now;
            double FineFees = 0.0;
            int CreatedByUserID = -1;
            bool IsReleased = false;
            DateTime? ReleasedDate = null;
            int ReleasedByUserID = -1;
            int ReleaseApplicationID = -1;

            if (clsDetainedLicensesData.GetDetainedLicenseInfo(DetainID, ref LicenseID, ref DetainDate, ref FineFees, ref CreatedByUserID, ref IsReleased, ref ReleasedDate, ref ReleasedByUserID, ref ReleaseApplicationID))
            {
                return new clsDetainedLicense(DetainID, LicenseID, DetainDate, FineFees, CreatedByUserID, IsReleased, ReleasedDate, ReleasedByUserID, ReleaseApplicationID);
            }
            else
            {
                return null;
            }
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

        public static bool DeleteDetainedLicense(int DetainID)
        {
            return clsDetainedLicensesData.DeleteDetainedLicense(DetainID);
        }

        public static bool IsDetainedLicenseExists(int DetainID)
        {
            return clsDetainedLicensesData.IsDetainedLicenseExists(DetainID);
        }

        public static DataTable GetAllDetainedLicenses()
        {
            return clsDetainedLicensesData.GetAllDetainedLicenses();
        }
    }
}
