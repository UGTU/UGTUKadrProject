using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Linq;
using Kadr.Controllers;

namespace Kadr.Data
{
    partial class FactStaffMonthHour : UIX.Views.IDecorable//, UIX.Views.IValidatable
    {

        public override string ToString()
        {
            return "Часы за " +FactStaff.ToString() +" "+ MonthController.Instance.GetMonthName(MonthNumber);
        }

        public string MonthName
        {
            get
            {
                return MonthController.Instance.GetMonthName(MonthNumber);

            }
            set
            {
                MonthNumber = MonthController.Instance.GetMonthNumber(value);
            }

        }

        public decimal? BonusSum
        {
            get
            {
                return this.HourCount * this.FactStaff.LastChange.HourSalary;
            }
        }

        public object GetDecorator()
        {
             return new FactStaffMonthHourDecorator(this);
        }
    }
}
