using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace DVLD_BusinessLogicLayer
{
    public class clsValidation
    {
        public static bool ValidateEmail(string email)
        {
            string pattern = @"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$";
            return Regex.IsMatch(email, pattern) || string.IsNullOrEmpty(email);
        }

        public static bool ValidatePhoneNumber(string PhoneNumber)
        {
            string pattern = @"^(?:[0-9] ?){7,14}[0-9]$";
            return Regex.IsMatch(PhoneNumber, pattern);
        }

    }
}
