using DVLD_DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLD_BusinessLayer
{
    public class clsLicenseClass
    {
        public static DataTable GetAllLicenseClasses()
        {
            return clsLicenseClassesData.GetAllLicenseClasses();
        }

        public static string GetClassName(int LicenseClassID)
        {
            return clsLicenseClassesData.GetClassName(LicenseClassID);
        }
    }
}
