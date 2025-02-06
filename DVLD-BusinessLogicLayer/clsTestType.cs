using DVLD_DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLD_BusinessLogicLayer
{
    public class clsTestType
    {
        clsGlobalSettings.enMode _Mode = clsGlobalSettings.enMode.AddNew;

        public enum enTestType { VisionTest = 1, TheoryTest = 2, PracticalTest = 3 };

        public int ID { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public decimal Fees { get; set; }
        public enTestType TestType { get { return (enTestType)ID; } }

        public clsTestType()
        {
            _Mode = clsGlobalSettings.enMode.AddNew;

            ID = -1;
            Title = string.Empty;
            Description = string.Empty;
            Fees = 0m;
        }

        private clsTestType(int ID, string Title, string Description, decimal Fees)
        {
            _Mode = clsGlobalSettings.enMode.Update;

            this.ID = ID;
            this.Title = Title;
            this.Description = Description;
            this.Fees = Fees;
        }

        private bool _AddNewTestType()
        {
            this.ID = clsTestTypeData.AddNewTestType(Title, Description, Fees);
            return ID != -1;
        }

        private bool _UpdateTestType()
        {
            return clsTestTypeData.UpdateTestType(ID, Title, Description, Fees);
        }

        public static clsTestType Find(int ID)
        {
            string Title = string.Empty;
            string Description = string.Empty;
            decimal Fees = 0m;

            if (clsTestTypeData.GetTestTypeInfo(ID, ref Title, ref Description, ref Fees))
                return new clsTestType(ID, Title, Description, Fees);
            else
                return null;
        }

        public static clsTestType FindByName(string Title)
        {
            int ID = -1;
            string Description = string.Empty;
            decimal Fees = 0m;

            if (clsTestTypeData.GetTestTypeInfoByName(Title, ref ID, ref Description, ref Fees))
                return new clsTestType(ID, Title, Description, Fees);
            else
                return null;
        }

        public bool Save()
        {
            switch (_Mode)
            {
                case clsGlobalSettings.enMode.AddNew:
                    _Mode = clsGlobalSettings.enMode.Update;
                    return _AddNewTestType();

                case clsGlobalSettings.enMode.Update:
                    return _UpdateTestType();

                default:
                    return false;
            }
        }

        public static bool DeleteTestType(int ID)
        {
            return clsTestTypeData.DeleteTestType(ID);
        }

        public static DataTable GetAllTestTypes()
        {
            return clsTestTypeData.GetAllTestTypes();
        }
    }

}
