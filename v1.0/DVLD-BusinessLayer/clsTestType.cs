using DVLD_DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLD_BusinessLayer
{
    public class clsTestType
    {
        public int ID { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public double Fees { get; set; }

        private clsTestType(int ID, string Title, string Description, double Fees) 
        {
            this.ID = ID;
            this.Title = Title;
            this.Description = Description;
            this.Fees = Fees;
        }

        private bool _UpdateTestType()
        {
            return clsTestTypesData.UpdateTestType(ID, Title, Description, Fees);
        }

        public static clsTestType Find(int TestTypeID)
        {
            string Title = string.Empty , Description = string.Empty;
            double Fees = 0;

            if (clsTestTypesData.GetTestType(TestTypeID, ref Title, ref Description, ref Fees))
            {
                return new clsTestType(TestTypeID, Title, Description, Fees);
            }
            else
                return null;

        }

        public bool Save()
        {
            return _UpdateTestType();
        }

        public static DataTable GetAllTestTypes()
        {
            return clsTestTypesData.GetAllTestTypes();
        }

        public static bool IsTestTypeExist(int TestTypeID)
        {
            return clsTestTypesData.IsTestTypeExist(TestTypeID);
        }

    }
}
