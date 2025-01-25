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
        public enum enTestType { Vision = 1, Writing = 2, Street = 3 }
        public enum enApplicationStatus { New = 1, Cancelled = 2, Completed = 3 }

        public enum enIssueReason { FirstTime = 1, Renew = 2, ReplaceForLost = 3, ReplaceForDamage = 4 }//


    }
}
