using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLD_BusinessLogicLayer
{
    public class clsGlobalSettings
    {
        public enum enMode { AddNew, Update }
        public enum enGender { Female = 0, Male = 1 }


        public static string PeopleImagesFolder = @"..\..\People-Images";

    }
}
