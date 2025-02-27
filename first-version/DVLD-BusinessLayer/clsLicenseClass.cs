﻿using DVLD_DataAccessLayer;
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

        public static byte GetLicenseLengthInYears(int LicenseClassID)
        {
            return clsLicenseClassesData.GetLicenseLengthInYears(LicenseClassID);
        }
        public static byte GetMinimumAllowedAge(int LicenseClassID)
        {
            return clsLicenseClassesData.GetMinimumAllowedAge(LicenseClassID);
        }

        public static double GetClassFees(int LicenseClassID)
        {
            return clsLicenseClassesData.GetClassFees(LicenseClassID);
        }

    }
}
