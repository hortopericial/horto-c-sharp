using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace WpfNutWatch
{
    public class RegularExpression
    {
        public static bool checkForEmail(String email)
        {
            bool IsValid = false;
            Regex regex = new Regex(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$");
            if (regex.IsMatch(email))
            {
                IsValid = true;
            }
            return IsValid;        
        }
    }
}
