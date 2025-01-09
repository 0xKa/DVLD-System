using DVLD_DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLD_BusinessLayer
{
    public class clsApplicationType
    {
        public int ID {  get; set; }
        public string Title { get; set; }
        public double Fees { get; set; }

        private clsApplicationType(int ID, string Title, double Fees) 
        { 
            this.ID = ID;
            this.Title = Title;
            this.Fees = Fees;
        }

        private bool _UpdateApplicationType()
        {
            return clsApplicationTypesData.UpdateApplicationType(ID, Title, Fees);
        }

        public static clsApplicationType Find(int ApplicationTypeID)
        {
            string Name = string.Empty;
            double Fees = 0;

            if (clsApplicationTypesData.GetApplicationType(ApplicationTypeID, ref Name, ref Fees))
                return new clsApplicationType(ApplicationTypeID, Name,Fees);
            else
                return null;
        }

        public bool Save()
        {
            return _UpdateApplicationType();
        }

        public static DataTable GetAllApplicationTypes()
        {
            return clsApplicationTypesData.GetAllApplicationTypes();
        }

        public static void IsApplicationTypeExist(int ApplicationTypeID)
        {
            clsApplicationTypesData.IsApplicationTypeExist(ApplicationTypeID);
        }
    }
}
