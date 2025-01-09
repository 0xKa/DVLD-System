using DVLD_DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLD_BusinessLayer
{
    public class clsApplication
    {
        public enum enMode { AddNew = 0, Update = 1 }
        private enMode _Mode = enMode.AddNew;

        public int ID { get; set; }
        public int ApplicantID { get; set; }
        public DateTime ApplicationDate { get; set; }
        public int ApplicationTypeID { get; set; }
        public byte ApplicationStatus { get; set; }
        public DateTime LastStatusDate {  get; set; }
        public double PaidFees { get; set; }
        public int CreatedByUserID { get; set; }

        public clsApplication() 
        { 
            _Mode = enMode.AddNew;

            ID = -1;
            ApplicantID = -1;
            ApplicationDate = DateTime.Now;
            ApplicationTypeID = -1;
            ApplicationStatus = 0;
            LastStatusDate = DateTime.Now;
            PaidFees = 0;
            CreatedByUserID = -1;
        }
        private clsApplication(int applicationID, int applicantID, DateTime applicationDate, int applicationTypeID, byte applicationStatus, DateTime lastStatusDate, double paidFees, int createdByUserID)
        {
            _Mode = enMode.Update;

            ID = applicationID;
            ApplicantID = applicantID;
            ApplicationDate = applicationDate;
            ApplicationTypeID = applicationTypeID;
            ApplicationStatus = applicationStatus;
            LastStatusDate = lastStatusDate;
            PaidFees = paidFees;
            CreatedByUserID = createdByUserID;
        }


        private bool _AddNewApplication()
        {
            this.ID = clsApplicationData.AddNewApplication(ApplicantID, ApplicationDate,
                ApplicationTypeID, ApplicationStatus, LastStatusDate, PaidFees, CreatedByUserID);

            return ID != -1;
        }
        private bool _UpdateApplication()
        {
            return clsApplicationData.UpdateApplication(ID, ApplicantID, ApplicationDate,
                ApplicationTypeID, ApplicationStatus, LastStatusDate, PaidFees, CreatedByUserID);
        }

        public static clsApplication Find(int ApplicationID)
        {
           int ApplicantID = -1;
           DateTime ApplicationDate = DateTime.Now;
           int ApplicationTypeID = -1;
           byte ApplicationStatus = 0;
           DateTime LastStatusDate = DateTime.Now;
           double PaidFees = 0;
           int CreatedByUserID = -1;

            if (clsApplicationData.GetApplicationInfo(ApplicationID, ref ApplicantID,
                ref ApplicationDate, ref ApplicationTypeID, ref ApplicationStatus,
                ref LastStatusDate, ref PaidFees, ref CreatedByUserID))
                return new clsApplication(ApplicationID, ApplicantID, ApplicationDate,
                    ApplicationTypeID, ApplicationStatus, LastStatusDate, PaidFees, CreatedByUserID);
            else
                return null;

        }
        public static clsApplication FindByApplicantID(int ApplicantPersonID)
        {
           int ApplicationID = -1;
           DateTime ApplicationDate = DateTime.Now;
           int ApplicationTypeID = -1;
           byte ApplicationStatus = 0;
           DateTime LastStatusDate = DateTime.Now;
           double PaidFees = 0;
           int CreatedByUserID = -1;

            if (clsApplicationData.GetApplicationInfoByApplicantID(ApplicantPersonID, ref ApplicationID,
                ref ApplicationDate, ref ApplicationTypeID, ref ApplicationStatus,
                ref LastStatusDate, ref PaidFees, ref CreatedByUserID))
                return new clsApplication(ApplicantPersonID, ApplicationID, ApplicationDate,
                    ApplicationTypeID, ApplicationStatus, LastStatusDate, PaidFees, CreatedByUserID);
            else
                return null;

        }

        public bool Save()
        {
            switch (_Mode)
            {
                case enMode.AddNew:
                    _Mode = enMode.Update;
                    return _AddNewApplication();

                case enMode.Update:
                    return _UpdateApplication();

                default:
                    return false;
            }
        }

        public static bool DeleteApplication(int ApplicationID)
        {
            return clsApplicationData.DeleteApplication(ApplicationID);
        }

        public static DataTable GetAllApplications()
        {
            return clsApplicationData.GetAllApplications();
        }
        
        public static bool IsApplicationExist(int ApplicationID)
        {
            return clsApplicationData.IsApplicationExist(ApplicationID);
        }

        public enum enApplicationStatus {Cancelled = 2, Completed = 3 }
        public bool ChangeApplicationStatus(enApplicationStatus status)
        {
            if (status == enApplicationStatus.Cancelled)
            {
                ApplicationStatus = 2;
                LastStatusDate = DateTime.Now;
                return this.Save();
            }
            else if (status == enApplicationStatus.Completed)
            {
                ApplicationStatus = 3;
                LastStatusDate = DateTime.Now;
                return this.Save();
            }
            else 
            { return false; }

        }


    }
}
