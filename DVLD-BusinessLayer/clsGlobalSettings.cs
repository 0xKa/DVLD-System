using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLD_BusinessLayer
{
    public class clsGlobalSettings
    {
        public enum enMode { AddNew = 0, Update = 1 }
        public static clsUser CurrentUser { get; set; }

    }
}
