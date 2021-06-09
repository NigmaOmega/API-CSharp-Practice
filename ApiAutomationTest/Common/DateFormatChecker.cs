using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiAutomationTest
{
    static class DateFormatChecker
    {
        public static string RssFormat { get; } = "ddd, dd MMM yyyy HH:mm:ss +ffff";
        public static bool HasValidFormat(this string date, string format) {
            DateTime resultDate;
            if (DateTime.TryParseExact(date, format,CultureInfo.InvariantCulture, DateTimeStyles.None, out resultDate))
            {
                return true;
            }
            else {
                return false;
            }
        }
    }
}
