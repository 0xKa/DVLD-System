using DVLD_DataAccessLayer;
using System.Data;

namespace DVLD_BusinessLayer
{
    public  class clsCountry
    {
        public static string GetCountryName(int CountryID)
        {
            return clsCountryData.GetCountryName(CountryID);
        }

        public static DataTable GetAllCountries()
        {
            return clsCountryData.GetAllCountries();
        }

    }
}
