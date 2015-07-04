using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Kadr.Controllers;
using System.Data.Linq;
using Kadr.Data.Common;

namespace Kadr.Data
{
    public partial class TimeSheetFSWorkingDay : UIX.Views.IDecorable, UIX.Views.IValidatable, INull
    {
        public override string ToString()
        {
            return FactStaff.ToString() + " " + TimeSheet.ToString();

        }



        public Dep department
        {
            get
            {
                if (FactStaff != null)
                    return FactStaff.PlanStaff.Dep;
                return null;
            }

        }
        
        public string Department
        {
            get
            {
                if (FactStaff != null)
                    return FactStaff.PlanStaff.Dep.DepartmentSmallName;
                return "";
            }

        }

        /// <summary>
        /// Проверка всех параметров перед сохранением
        /// </summary>
        /// <param name="action"></param>
        partial void OnValidate(System.Data.Linq.ChangeAction action)
        {
            if ((action == ChangeAction.Insert) || (action == ChangeAction.Update))
            {
                if (WorkingDaysCount > TimeSheet.TimeSheetWorkingDayCount)
                    throw new ArgumentOutOfRangeException("Количество рабочих дней в месяце");
                if (StaffCount <= 0) throw new ArgumentOutOfRangeException("Количество ставок.");
            }
        }

        public object GetDecorator()
        {
            return new TimeSheetFSWorkingDaysDecorator(this);
        }

        public void Validate()
        {
            OnValidate(ChangeAction.Insert); 
        }

        bool INull.IsNull()
        {
            return false;
        }
    }


    public class NullTimeSheetFSWorkingDay : TimeSheetFSWorkingDay, INull
    {

        private NullTimeSheetFSWorkingDay()
        {
            
        }

        public static readonly NullTimeSheetFSWorkingDay Instance = new NullTimeSheetFSWorkingDay();

        #region INull Members

        bool INull.IsNull()
        {
            return true;
        }

        public override string ToString()
        {
            return "(Не задан)";
        }

        #endregion
    }

}
