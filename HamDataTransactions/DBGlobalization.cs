using System;
using System.Collections.Generic;
using System.Configuration;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HamDataTransactions
{
    public class DBGlobalization
    {
        public static CultureInfo GetCultureInfo()
        {
            CultureInfo cultureInfo = new CultureInfo("en-US");
            cultureInfo.NumberFormat.CurrencySymbol = "Bs.";
            //cultureInfo.DateTimeFormat.ShortDatePattern = "yyyy-MM-dd";
            cultureInfo.DateTimeFormat.ShortDatePattern = "dd/MM/yyyy";
            cultureInfo.DateTimeFormat.ShortTimePattern = "HH:mm:ss";
            cultureInfo.DateTimeFormat.FullDateTimePattern = "dd/MM/yyyy HH:mm:ss";
            cultureInfo.NumberFormat.CurrencyDecimalSeparator = ".";
            cultureInfo.NumberFormat.CurrencyGroupSeparator = ",";
            cultureInfo.NumberFormat.NumberDecimalSeparator = ".";
            cultureInfo.NumberFormat.NumberGroupSeparator = ",";

            return cultureInfo;
        }
    }
}
