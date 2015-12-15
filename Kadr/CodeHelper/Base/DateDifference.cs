using System;
using System.CodeDom;

namespace APG.Base
{
    /// <summary>
    /// Определяет продолжительность с точностью до дат и операцию сложения
    /// </summary>
    public class DateSpan
    {
        protected int _day;
        protected int _month;
        protected int _year;

        /// <summary>
        /// Determines whether the specified <see cref="T:System.Object"/> is equal to the current <see cref="T:System.Object"/>.
        /// </summary>
        /// <returns>
        /// true if the specified <see cref="T:System.Object"/> is equal to the current <see cref="T:System.Object"/>; otherwise, false.
        /// </returns>
        /// <param name="obj">The <see cref="T:System.Object"/> to compare with the current <see cref="T:System.Object"/>. </param>
        public override bool Equals(object obj)
        {
            var otherDate = obj as DateSpan;
            if (otherDate == null) throw new ArgumentNullException(nameof(obj));             
            return (Days == otherDate.Days) && (Months == otherDate.Months) && (Years == otherDate.Years);
        }

        /// <summary>
        /// Serves as a hash function for a particular type. 
        /// </summary>
        /// <returns>
        /// A hash code for the current <see cref="T:System.Object"/>.
        /// </returns>
        public override int GetHashCode()
        {
            return Days ^ Months ^ Years;
        }

        public DateSpan() { }

        public DateSpan(int days, int months, int years)
        {
            if (days < 0 || months < 0 || years < 0) throw new ArgumentException("Значения параметров должны быть больше нуля.");
            if (days > 31 || months > 11)
                throw new ArgumentException("Число дней в дате должно быть меньше 32 и число месяцев меньше 12");
            _year = years;
            _month = months;
            _day = days;
        }

        public static DateSpan operator - (DateSpan ds, int days)
        {
            var years = days/(30*12);
            var months = days % (30*12) / 30;            
            return new DateSpan(ds.Days - days % 30, ds.Months - months, ds.Years - years);
        } 
        public int Years => _year;

        public int Months => _month;

        public int Days => _day;

        public DateSpan Add(DateSpan other)
        {
            var sumDays = other.Days + Days;
            var sumMonths = other.Months + Months;
            var sumYears = other.Years + Years;

            sumMonths += sumDays / 30;
            sumYears += sumMonths / 12;

            return new DateSpan(sumDays % 30, sumMonths % 12, sumYears);
        }        

        public static DateSpan operator +(DateSpan dateSpan, DateSpan other)
        {
            return dateSpan.Add(other);
        }

        public static implicit operator TimeSpan(DateSpan dateSpan)
        {
            return dateSpan.AsTimespan;
        }

        public TimeSpan AsTimespan => new TimeSpan(Days + Months * 30 + Years * 365);
    }

    public class DateSpanDifference : DateSpan
    {
        private readonly int[] _monthDay = new int[12] { 31, -1, 31, 30, 31, 30, 31, 31, 30, 31, 30, 31 };

        public DateSpanDifference(DateTime d1, DateTime d2)
        {
            DateTime fromDate;
            DateTime toDate;
            if (d1 > d2)
            {
                fromDate = d2;
                toDate = d1;
            }
            else
            {
                fromDate = d1;
                toDate = d2;
            }


            var increment = 0;

            if (fromDate.Day > toDate.Day)
            {
                increment = _monthDay[fromDate.Month - 1];
            }

            if (increment == -1)
            {
                if (DateTime.IsLeapYear(fromDate.Year))
                {
                    increment = 29;
                }
                else
                {
                    increment = 28;
                }
            }
            if (increment != 0)
            {
                _day = toDate.Day + increment - fromDate.Day;
                increment = 1;
            }
            else
            {
                _day = toDate.Day - fromDate.Day;
            }


            if (fromDate.Month + increment > toDate.Month)
            {
                _month = toDate.Month + 12 - (fromDate.Month + increment);
                increment = 1;
            }
            else
            {
                _month = toDate.Month - (fromDate.Month + increment);
                increment = 0;
            }

            _year = toDate.Year - (fromDate.Year + increment);
        }

        public override string ToString()
        {
            return NumericExtensions.FormatDate(Years, Months, Days);
        }
    }
}