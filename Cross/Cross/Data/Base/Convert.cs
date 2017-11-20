using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Cross.Data.Base
{
    public static class Convert
    {
        public static string _MobileFormat(string sMobile)
        {
            Regex rgx = new Regex("(\\+98|0|98|980)?9\\d{9}");
            if (rgx.IsMatch(sMobile))
            {
                int iCount = sMobile.Length;
                sMobile = sMobile.Substring((iCount - 10), 10);
                sMobile = "+98." + sMobile;
            }
            return sMobile;
        }
    }
}
