using System;

namespace APG.Base
{
    /// <summary>
    /// Расширяет использование числовых типов
    /// </summary>
    public static class NumericExtensions
    {
        /// <summary>
        /// Получает строку в правильном спряжении для заданного значения
        /// </summary>
        /// <param name="value">Число</param>
        /// <param name="nStr">Именительный падеж</param>
        /// <param name="pStr">Множественное</param>
        /// <param name="npStr">Мн</param>
        /// <returns>Строка в правильном спряжении</returns>
        public static string FormatIntToRusString(this int value, string nStr, string pStr, string npStr)
        {
            var off = value % 100;
            if (off > 10 && off < 20)
                return pStr;

            off = off % 10;

            switch (off)
            {
                case 1:
                    return nStr;
                case 2:
                case 3:
                case 4:
                    return npStr;
                default:
                    return pStr;
            }
        }
        /// <summary>
        /// Получает строку в правильном склонении года
        /// </summary>
        /// <param name="years">Год</param>
        /// <returns>Строка в правильном склонении года</returns>
        public static string GetYearStr(this int years)
        {
            return years.FormatIntToRusString("год", "лет", "года");
        }
        /// <summary>
        /// Получает строку в правильном склонении месяца
        /// </summary>
        /// <param name="monthes">Месяц</param>
        /// <returns>Строка в правильном склонении месяца</returns>
        public static string GetMonthStr(this int monthes)
        {
            return monthes.FormatIntToRusString("месяц", "месяцев", "месяца");
        }
        /// <summary>
        /// Получает строку в правильном склонении дня
        /// </summary>
        /// <param name="days">День</param>
        /// <returns>Строка в правильном склонении дня</returns>

        public static string GetDayStr(this int days)
        {
            return days.FormatIntToRusString("день", "дней", "дня");
        }

        public static string FormatDate(int years, int monthes, int days)
        {
            return string.Format("{0} {1}, {2} {3}, {4} {5}",
                years, years.GetYearStr(), monthes, monthes.GetMonthStr(),
                days, days.GetDayStr());
        }
    }
}
