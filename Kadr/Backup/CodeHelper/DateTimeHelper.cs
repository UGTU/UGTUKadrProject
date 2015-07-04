using System;
using System.Collections.Generic;
using System.Text;

namespace APG.CodeHelper
{
    public class DateTimeHelper
    {
        public enum TimeChangeType
        {
            Unchanged,
            WinterTime,
            SummerTime
        }

        //Функция, определяющая день перехода с зимнего на летнее время
        public static TimeChangeType GetTimeChange(DateTime time)
        {
            if (time.Date == TimeZone.CurrentTimeZone.GetDaylightChanges(time.Year).Start.Date) return TimeChangeType.SummerTime;
            else
                if (time.Date == TimeZone.CurrentTimeZone.GetDaylightChanges(time.Year).End.Date) return TimeChangeType.WinterTime;
                else return TimeChangeType.Unchanged;
        }

        //определение критического часа для зимнего перехода (первый промежуток 2:00 - 2:59)
        public static bool IsWinterCriticalHour(DateTime time)
        {
            if ((time.IsDaylightSavingTime() != time.ToUniversalTime().Add(GetChangeDelta(time.Year)).ToLocalTime().IsDaylightSavingTime()) && (GetTimeChange(time) == TimeChangeType.WinterTime))
                return true;
            else return false;
            
        }

        public static TimeSpan GetChangeDelta(int year)
        {
            return TimeZone.CurrentTimeZone.GetDaylightChanges(2007).Delta;
        }

        public static bool IsEndWork(DateTime day, int second)
        {
            // Число секунд в одних сутках
            int DaySeconds = 24 * 60 * 60 - 2;
            //Для зимнего и летнего переходов день - не стандартный
            if (day.Date == TimeZone.CurrentTimeZone.GetDaylightChanges(day.Year).Start.Date) DaySeconds = DaySeconds - 60 * 60 * GetChangeDelta(day.Year).Hours;
            if (day.Date == TimeZone.CurrentTimeZone.GetDaylightChanges(day.Year).End.Date) DaySeconds = DaySeconds + 60 * 60 * GetChangeDelta(day.Year).Hours;
            if (second >= DaySeconds) return true;
             else return false;
        }
    }
}
