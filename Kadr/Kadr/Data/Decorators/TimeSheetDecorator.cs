using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Kadr.Data
{
    class TimeSheetDecorator
    {

        private TimeSheet timeSheet;
        public TimeSheetDecorator(TimeSheet timeSheet)
        {
            this.timeSheet = timeSheet;
        }

        override public string ToString()
        {
            return "Табель " + timeSheet.ToString();
        }

        [System.ComponentModel.DisplayName("ID")]
        [System.ComponentModel.Category("Атрибуты")]
        [System.ComponentModel.Description("Уникальный код табеля в системе")]
        [System.ComponentModel.ReadOnly(true)]
        public int ID
        {
            get
            {
                return timeSheet.id;
            }
            set
            {
                timeSheet.id = value;
            }
        }


        [System.ComponentModel.DisplayName("Год табеля")]
        [System.ComponentModel.Category("Основные параметры")]
        [System.ComponentModel.Description("Год табеля")]
        public int TimeSheetYear
        {
            get
            {
                return timeSheet.TimeSheetYear;
            }
            set
            {
                timeSheet.TimeSheetYear = value;
            }
        }

        [System.ComponentModel.DisplayName("Среднемесячное количество часов")]
        [System.ComponentModel.Category("Основные параметры")]
        [System.ComponentModel.Description("Среднемесячное количество часов")]
        public double TimeSheetHourCount
        {
            get
            {
                return Convert.ToDouble(timeSheet.TimeSheetWorkingHourCount);
            }
            set
            {
                timeSheet.TimeSheetWorkingHourCount = value;
            }
        }

        [System.ComponentModel.DisplayName("Заполнен")]
        [System.ComponentModel.Category("Основные параметры")]
        [System.ComponentModel.Description("Признак заполненного табеля")]
        [System.ComponentModel.TypeConverter(typeof(Kadr.UI.Common.CustomBooleanConverter))]
        public bool IsFilled
        {
            get
            {
                return Convert.ToBoolean(timeSheet.IsFilled);
            }
            set
            {
                timeSheet.IsFilled = value;
            }
        }

        [System.ComponentModel.DisplayName("Закрыт")]
        [System.ComponentModel.Category("Основные параметры")]
        [System.ComponentModel.Description("Признак закрытого табеля")]
        [System.ComponentModel.TypeConverter(typeof(Kadr.UI.Common.CustomBooleanConverter))]
        public bool IsClosed
        {
            get
            {
                return Convert.ToBoolean(timeSheet.IsClosed);
            }
            set
            {
                timeSheet.IsClosed = value;
            }
        }

        /*[System.ComponentModel.DisplayName("Общее количество дней")]
        [System.ComponentModel.Category("Основные параметры")]
        [System.ComponentModel.Description("Общее количество дней в месяце")]
        public int TimeSheetAllDayCount
        {
            get
            {
                return timeSheet.TimeSheetAllDayCount;
            }
            set
            {
                timeSheet.TimeSheetAllDayCount = value;
            }
        }*/

        [System.ComponentModel.DisplayName("Количество рабочих дней")]
        [System.ComponentModel.Category("Основные параметры")]
        [System.ComponentModel.Description("Количество дней в месяце")]
        public int TimeSheetWorkingDayCount
        {
            get
            {
                return timeSheet.TimeSheetWorkingDayCount;
            }
            set
            {
                timeSheet.TimeSheetWorkingDayCount = value;
            }
        }

        [System.ComponentModel.DisplayName("Месяц")]
        [System.ComponentModel.Category("Основные параметры")]
        [System.ComponentModel.Description("Месяц табеля")]
        [System.ComponentModel.Editor(typeof(Kadr.UI.Editors.MonthEditor), typeof(System.Drawing.Design.UITypeEditor))]
        public string MonthName
        {
            get
            {
                return timeSheet.MonthName;
            }
            set
            {
                timeSheet.MonthName = value;
            }
        }


    }
}
