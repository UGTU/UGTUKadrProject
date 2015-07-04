using System;
using System.Collections.Generic;
using System.Text;

namespace APG.CodeHelper
{
    public class NumbersHelper
    {
        // Минимальное значение для smalldatetime (SQL Server 2000/2005)
        public readonly static DateTime MinimumSmallDateTimeValue = new DateTime(1900, 1, 1, 0, 0, 0, 0);

        public static decimal CorrectNumberString(object Value)
        {
            string result = Value.ToString().Replace(".", System.Globalization.CultureInfo.CurrentCulture.NumberFormat.NumberDecimalSeparator);
            
            try
            {
                return Convert.ToDecimal(result);
            }
            catch (Exception )
            {
                return 0;
            }
        }

        public static DateTime CorrectTimeString(object Value)
        {
            string result = Value.ToString();
            int pos = result.ToString().IndexOf(System.Globalization.CultureInfo.CurrentCulture.DateTimeFormat.TimeSeparator);
            if (pos == -1)
              result = string.Format("00{0}{00}", System.Globalization.CultureInfo.CurrentCulture.DateTimeFormat.TimeSeparator);
          
            return DateTime.Parse(result);            
            
        }
    }
}
