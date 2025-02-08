using DVLD_DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLD_BusinessLogicLayer
{
    public class clsApplication
    {
        clsGlobalSettings.enMode _Mode = clsGlobalSettings.enMode.AddNew;
        public enum enApplicationStatus { New = 1, Canceled = 2, Completed = 3 }

        public int ApplicationID { get; set; }
        public int ApplicantPersonID { get; set; }
        public int TypeID { get; set; }
        public DateTime ApplicationDate { get; set; }
        public byte Status { get; set; }
        public DateTime LastStatusDate { get; set; }
        public decimal Fees { get; set; }
        public int CreatedByUserID { get; set; }

        public enApplicationStatus enStatus { 
            get { return (enApplicationStatus)this.Status; } 
            set { this.Status = (byte)value; }
        }

        public clsPerson ApplicantPerson = null;
        public clsApplicationType Type = null;
        public clsUser CreatedByUser = null;

        public clsApplication()
        {
            _Mode = clsGlobalSettings.enMode.AddNew;

            ApplicationID = -1;
            ApplicantPersonID = -1;
            TypeID = -1;
            ApplicationDate = DateTime.MinValue;
            Status = 0;
            LastStatusDate = DateTime.MinValue;
            Fees = 0m;
            CreatedByUserID = -1;
        }

        private clsApplication(int ID, int ApplicantPersonID, int TypeID, DateTime ApplicationDate, byte Status, DateTime LastStatusDate, decimal Fees, int CreatedByUserID)
        {
            _Mode = clsGlobalSettings.enMode.Update;

            this.ApplicationID = ID;
            this.ApplicantPersonID = ApplicantPersonID;
            this.TypeID = TypeID;
            this.ApplicationDate = ApplicationDate;
            this.Status = Status;
            this.LastStatusDate = LastStatusDate;
            this.Fees = Fees;
            this.CreatedByUserID = CreatedByUserID;

            this.ApplicantPerson = clsPerson.Find(this.ApplicantPersonID);
            this.Type = clsApplicationType.Find(this.TypeID);
            this.CreatedByUser = clsUser.Find(this.CreatedByUserID);
        }

        private bool _AddNewApplication()
        {
            this.ApplicationID = clsApplicationData.AddNewApplication(ApplicantPersonID, TypeID, ApplicationDate, Status, LastStatusDate, Fees, CreatedByUserID);
            return ApplicationID != -1;
        }

        private bool _UpdateApplication()
        {
            return clsApplicationData.UpdateApplication(ApplicationID, ApplicantPersonID, TypeID, ApplicationDate, Status, LastStatusDate, Fees, CreatedByUserID);
        }

        public static clsApplication FindBase(int ID)
        {
            int ApplicantPersonID = -1, TypeID = -1, CreatedByUserID = -1;
            DateTime ApplicationDate = DateTime.MinValue, LastStatusDate = DateTime.MinValue;
            byte Status = 0;
            decimal Fees = 0m;

            if (clsApplicationData.GetApplicationInfo(ID, ref ApplicantPersonID, ref TypeID, ref ApplicationDate, ref Status, ref LastStatusDate, ref Fees, ref CreatedByUserID))
                return new clsApplication(ID, ApplicantPersonID, TypeID, ApplicationDate, Status, LastStatusDate, Fees, CreatedByUserID);
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

        public static bool DeleteApplication(int ID)
        {
            return clsApplicationData.DeleteApplication(ID);
        }

        public static DataTable GetAllApplications()
        {
            return clsApplicationData.GetAllApplications();
        }

        public static bool ChangeApplicationStatus(int ApplicationID, enApplicationStatus NewStatus)
        {
            return clsApplicationData.ChangeApplicationStatus(ApplicationID, (byte)NewStatus);
        }
    }

}
