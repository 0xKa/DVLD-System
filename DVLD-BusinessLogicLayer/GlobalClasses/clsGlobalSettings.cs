using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLD_BusinessLogicLayer
{
    public class clsGlobalSettings
    {
        public static clsUser LoggedInUser = null;
        public enum enMode { AddNew, Update }


        public static string PeopleImagesFolder = @"..\..\People-Images";
        public static string RememberMeFilePath = @"..\..\RememberMeLoginInfo.txt";
        public static string RememberMeWinRegistryPath = @"HKEY_CURRENT_USER\SOFTWARE\DVLD";



    }
}
