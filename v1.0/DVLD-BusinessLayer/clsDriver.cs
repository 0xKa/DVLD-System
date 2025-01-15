using DVLD_DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLD_BusinessLayer
{
    public class clsDriver
    {
        clsGlobalSettings.enMode _Mode = clsGlobalSettings.enMode.AddNew;

        public int ID { get; set; }
        public int PersonID { get; set; }
        public int CreatedByUserID { get; set; }
        public DateTime CreatedDate { get; set; }

        public clsDriver() 
        {
            _Mode = clsGlobalSettings.enMode.AddNew;
            ID = -1;
            PersonID = -1;
            CreatedByUserID = -1;
            CreatedDate = DateTime.Now;
        }
        private clsDriver(int ID, int PersonID, int CreatedByUserID, DateTime CreatedDate) 
        {
            _Mode = clsGlobalSettings.enMode.Update;
            this.ID = ID;
            this.PersonID = PersonID;
            this.CreatedByUserID = CreatedByUserID;
            this.CreatedDate = CreatedDate;
        }


        private bool _AddNewDriver()
        {
            this.ID = clsDriversData.AddNewDriver(PersonID, CreatedByUserID, CreatedDate);

            return ID != -1;
        }
        private bool _UpdateDriver()
        {
            return clsDriversData.UpdateDriver(ID, PersonID, CreatedByUserID, CreatedDate);
        }

        public static clsDriver Find(int DriverID) 
        {
            int PersonID = -1;
            int CreatedByUserID = -1;
            DateTime CreatedDate = DateTime.Now;

            if (clsDriversData.GetDriverInfo(DriverID, ref PersonID, ref CreatedByUserID, ref CreatedDate))
                return new clsDriver(DriverID, PersonID, CreatedByUserID, CreatedDate);
            else
                return null;

        }

        public static clsDriver FindByPersonID(int PersonID)
        {
            int DriverID = -1;
            int CreatedByUserID = -1;
            DateTime CreatedDate = DateTime.Now;

            if (clsDriversData.GetDriverInfoByPersonID(PersonID, ref DriverID, ref CreatedByUserID, ref CreatedDate))
                return new clsDriver(DriverID, PersonID, CreatedByUserID, CreatedDate);
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

        public static bool DeleteDriver(int DriverID)
        {
            return clsDriversData.DeleteDriver(DriverID);
        }

        public static bool IsPersonDriver(int PersonID)
        {
            return clsDriversData.IsPersonDriver(PersonID);
        }

    }
}
