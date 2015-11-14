using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Kadr.Data
{
    class FactStaffMonthHourDecorator
    {

        private FactStaffMonthHour factStaffMonthHour;
        public FactStaffMonthHourDecorator(FactStaffMonthHour factStaffMonthHour)
        {
            this.factStaffMonthHour = factStaffMonthHour;
        }

        override public string ToString()
        {
            return factStaffMonthHour.ToString();
        }

        [System.ComponentModel.DisplayName("Сотрудник")]
        [System.ComponentModel.Category("Общие")]
        [System.ComponentModel.Description("Сотрудник, для которого указываются часы")]
        [System.ComponentModel.ReadOnly(true)]
        [System.ComponentModel.Browsable(false)]
        public FactStaff FactStaff
        {
            get
            {
                return factStaffMonthHour.FactStaff;
            }
            set
            {
                factStaffMonthHour.FactStaff = value;
            }
        }

        [System.ComponentModel.DisplayName("Количество часов")]
        [System.ComponentModel.Category("Основные атрибуты")]
        [System.ComponentModel.Description("Проведенное количество часов за месяц")]
        [System.ComponentModel.ReadOnly(false)]
        public decimal HourCount
        {
            get
            {
                return factStaffMonthHour.HourCount;
            }
            set
            {
                factStaffMonthHour.HourCount = value;
            }
        }

        [System.ComponentModel.DisplayName("Месяц")]
        [System.ComponentModel.Category("Основные параметры")]
        [System.ComponentModel.Description("Месяц")]
        [System.ComponentModel.ReadOnly(false)]
        [System.ComponentModel.Editor(typeof(Kadr.UI.Editors.MonthEditor), typeof(System.Drawing.Design.UITypeEditor))]
        public string MonthName
        {
            get
            {
                return factStaffMonthHour.MonthName;
            }
            set
            {
                factStaffMonthHour.MonthName = value;
            }
        }

        [System.ComponentModel.DisplayName("Год")]
        [System.ComponentModel.Category("Основные параметры")]
        [System.ComponentModel.Description("Год, для которого указываются часы")]
        [System.ComponentModel.ReadOnly(false)]
        public int YearNumber
        {
            get
            {
                return factStaffMonthHour.YearNumber;
            }
            set
            {
                factStaffMonthHour.YearNumber = value;
            }
        }
    }
}
