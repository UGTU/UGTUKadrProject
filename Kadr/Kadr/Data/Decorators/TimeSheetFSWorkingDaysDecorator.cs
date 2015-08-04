using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Kadr.Data
{
    class TimeSheetFSWorkingDaysDecorator
    {

        private TimeSheetFSWorkingDay timeSheetFSWorkingDays;
        public TimeSheetFSWorkingDaysDecorator(TimeSheetFSWorkingDay timeSheetFSWorkingDays)
        {
            this.timeSheetFSWorkingDays = timeSheetFSWorkingDays;
        }

        override public string ToString()
        {
            return timeSheetFSWorkingDays.ToString();
        }

        [System.ComponentModel.DisplayName("Сотрудник отдела")]
        [System.ComponentModel.Category("Атрибуты")]
        [System.ComponentModel.Description("Сотрудник отдела")]
        [System.ComponentModel.ReadOnly(true)]
        public FactStaff FactStaff
        {
            get
            {
                return timeSheetFSWorkingDays.FactStaff;
            }
            set
            {
                timeSheetFSWorkingDays.FactStaff = value;
            }
        }

        [System.ComponentModel.DisplayName("Количество ставок")]
        [System.ComponentModel.Category("Атрибуты")]
        [System.ComponentModel.Description("Занимаемое сотрудником на период табеля количество ставок")]
        [System.ComponentModel.ReadOnly(true)]
        public decimal StaffCount
        {
            get
            {
                return timeSheetFSWorkingDays.StaffCount;
            }
            set
            {
                timeSheetFSWorkingDays.StaffCount = value;
            }
        }

        [System.ComponentModel.DisplayName("Табель")]
        [System.ComponentModel.Category("Атрибуты")]
        [System.ComponentModel.Description("Табель")]
        [System.ComponentModel.ReadOnly(true)]
        public TimeSheet TimeSheet
        {
            get
            {
                return timeSheetFSWorkingDays.TimeSheet;
            }
            set
            {
                timeSheetFSWorkingDays.TimeSheet = value;
            }
        }

        [System.ComponentModel.DisplayName("Количество рабочих дней")]
        [System.ComponentModel.Category("Основные параметры")]
        [System.ComponentModel.Description("Общее количество рабочих дней сотрудника за месяц")]
        public int WorkingDaysCount
        {
            get
            {
                return timeSheetFSWorkingDays.WorkingDaysCount;
            }
            set
            {
                timeSheetFSWorkingDays.WorkingDaysCount = value;
            }
        }

        [System.ComponentModel.DisplayName("Заполнена")]
        [System.ComponentModel.Category("Основные параметры")]
        [System.ComponentModel.Description("Признак закрытой записи табеля")]
        [System.ComponentModel.TypeConverter(typeof(Kadr.UI.Common.CustomBooleanConverter))]
        public bool IsClosed
        {
            get
            {
                return timeSheetFSWorkingDays.IsClosed;
            }
            set
            {
                timeSheetFSWorkingDays.IsClosed = value;
            }
        }

    }
}
