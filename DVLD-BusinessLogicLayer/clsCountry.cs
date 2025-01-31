using DVLD_DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLD_BusinessLogicLayer
{
    public class clsCountry
    {
        public int ID { get; set; }
        public string Name { get; set; }

        public clsCountry()
        {
            ID = -1;
            Name = string.Empty;
        }

        private clsCountry(int ID, string Name)
        {
            this.ID = ID;
            this.Name = Name;
        }

        public static clsCountry Find(int ID)
        {
            string Name = string.Empty;

            if (clsCountryData.GetCountryInfo(ID, ref Name))
                return new clsCountry(ID, Name);
            else
                return null;
        }

        public static clsCountry Find(string Name)
        {
            int ID = -1;

            if (clsCountryData.GetCountryInfoByName(Name, ref ID))
                return new clsCountry(ID, Name);
            else
                return null;
        }

        public static DataTable GetAllCountries()
        {
            return clsCountryData.GetAllCountries();
        }
    }

}
