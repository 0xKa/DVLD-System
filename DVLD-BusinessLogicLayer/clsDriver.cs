using DVLD_DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLD_BusinessLogicLayer
{
    public class clsDriver
    {
        clsGlobalSettings.enMode _Mode = clsGlobalSettings.enMode.AddNew;

        public int ID { get; set; }
        public int PersonID { get; set; }
        public DateTime CreatedDate { get; set; }
        public int CreatedByUserID { get; set; }

        public clsPerson PersonInfo = null;
        public clsUser CreatedByUser = null;

        public clsDriver()
        {
            _Mode = clsGlobalSettings.enMode.AddNew;
            ID = -1;
            PersonID = -1;
            CreatedDate = DateTime.Now;
            CreatedByUserID = -1;
        }

        private clsDriver(int ID, int PersonID, DateTime CreatedDate, int CreatedByUserID)
        {
            _Mode = clsGlobalSettings.enMode.Update;

            this.ID = ID;
            this.PersonID = PersonID;
            this.CreatedDate = CreatedDate;
            this.CreatedByUserID = CreatedByUserID;

            this.PersonInfo = clsPerson.Find(PersonID);
            this.CreatedByUser = clsUser.Find(CreatedByUserID);
        }

        private bool _AddNewDriver()
        {
            this.ID = clsDriverData.AddNewDriver(PersonID, CreatedByUserID);
            return ID != -1;
        }

        private bool _UpdateDriver()
        {
            return clsDriverData.UpdateDriver(ID, PersonID, CreatedByUserID);
        }

        public static clsDriver Find(int ID)
        {
            int PersonID = -1;
            DateTime CreatedDate = DateTime.Now;
            int CreatedByUserID = -1;

            if (clsDriverData.GetDriverInfo(ID, ref PersonID, ref CreatedDate, ref CreatedByUserID))
                return new clsDriver(ID, PersonID, CreatedDate, CreatedByUserID);
            else
                return null;
        }
        public static clsDriver FindByPersonID(int PersonID)
        {
            int ID = -1;
            DateTime CreatedDate = DateTime.Now;
            int CreatedByUserID = -1;

            if (clsDriverData.GetDriverInfoByPersonID(PersonID, ref ID, ref CreatedDate, ref CreatedByUserID))
                return new clsDriver(ID, PersonID, CreatedDate, CreatedByUserID);
            else
                return null;
        }

        public bool Save()
        {
            switch (_Mode)
            {
                case clsGlobalSettings.enMode.AddNew:
                    _Mode = clsGlobalSettings.enMode.Update;
                    return _AddNewDriver();

                case clsGlobalSettings.enMode.Update:
                    return _UpdateDriver();

                default:
                    return false;
            }
        }

        public static bool DeleteDriver(int ID)
        {
            return clsDriverData.DeleteDriver(ID);
        }

        public static DataTable GetAllDrivers()
        {
            return clsDriverData.GetAllDrivers();
        }
    }

}
