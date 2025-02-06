using DVLD_DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLD_BusinessLogicLayer
{
    public class clsApplicationType
    {
        clsGlobalSettings.enMode _Mode = clsGlobalSettings.enMode.AddNew;

        public int ID { get; set; }
        public string Title { get; set; }
        public decimal Fees { get; set; }

        public clsApplicationType()
        {
            _Mode = clsGlobalSettings.enMode.AddNew;

            ID = -1;
            Title = string.Empty;
            Fees = 0m;
        }

        private clsApplicationType(int ID, string Title, decimal Fees)
        {
            _Mode = clsGlobalSettings.enMode.Update;

            this.ID = ID;
            this.Title = Title;
            this.Fees = Fees;
        }

        private bool _AddNewApplicationType()
        {
            this.ID = clsApplicationTypeData.AddNewApplicationType(Title, Fees);
            return ID != -1;
        }

        private bool _UpdateApplicationType()
        {
            return clsApplicationTypeData.UpdateApplicationType(ID, Title, Fees);
        }

        public static clsApplicationType Find(int ID)
        {
            string Title = string.Empty;
            decimal Fees = 0m;

            if (clsApplicationTypeData.GetApplicationTypeInfo(ID, ref Title, ref Fees))
                return new clsApplicationType(ID, Title, Fees);
            else
                return null;
        }

        public static clsApplicationType FindByName(string Title)
        {
            int ID = -1;
            decimal Fees = 0m;

            if (clsApplicationTypeData.GetApplicationTypeInfoByName(Title, ref ID, ref Fees))
                return new clsApplicationType(ID, Title, Fees);
            else
                return null;
        }

        public bool Save()
        {
            switch (_Mode)
            {
                case clsGlobalSettings.enMode.AddNew:
                    _Mode = clsGlobalSettings.enMode.Update;
                    return _AddNewApplicationType();

                case clsGlobalSettings.enMode.Update:
                    return _UpdateApplicationType();

                default:
                    return false;
            }
        }

        public static bool DeleteApplicationType(int ID)
        {
            return clsApplicationTypeData.DeleteApplicationType(ID);
        }

        public static DataTable GetAllApplicationTypes()
        {
            return clsApplicationTypeData.GetAllApplicationTypes();
        }
    }

}
