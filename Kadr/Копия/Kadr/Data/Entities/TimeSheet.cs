using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Kadr.Controllers;
using System.Data.Linq;
using Kadr.Data.Common;


namespace Kadr.Data
{
    public partial class TimeSheet : UIX.Views.IDecorable, UIX.Views.IValidatable
    {
        public override string ToString()
        {
            string res;
            res = MonthController.Instance.GetMonthName(TimeSheetMonth)+" "+TimeSheetYear.ToString();

            return res;
        }

        public string MonthName
        {
            get
            {
                return MonthController.Instance.GetMonthName(TimeSheetMonth);
                
            }
            set
            {
                TimeSheetMonth = MonthController.Instance.GetMonthNumber(value);
            }

        }

        private DateTime MonthBegin
        {
            get
            {
                return new DateTime(TimeSheetYear, TimeSheetMonth, 1);
            }
        }

        private DateTime MonthEnd
        {
            get
            {
                return new DateTime(TimeSheetYear, TimeSheetMonth, DateTime.DaysInMonth(TimeSheetYear, TimeSheetMonth));
            }
        }


        partial void OnIsClosedChanged()
        {
            if (IsClosed == true)
                IsFilled = true;
        }

        partial void  OnIsFilledChanging(bool? value)
        {
            if ((IsClosed == true) && (value == false))
            {
                throw new ArgumentOutOfRangeException("Табель не может быть закрыт и не заполнен.");
            }
 	
        }

        /// <summary>
        /// возвращает текущий табель
        /// </summary>
        /// <returns></returns>
        public static TimeSheet CurrentTimeSheet()
        {
            int CurrentMonthNumber = 0;
            int CurrentYearNumber = 0;
            if (DateTime.Today.Day > 20)
            {
                CurrentMonthNumber = DateTime.Today.Month;
                CurrentYearNumber = DateTime.Today.Year;
            }
            else
            {
                CurrentMonthNumber = DateTime.Today.AddMonths(-1).Month;
                CurrentYearNumber = DateTime.Today.AddMonths(-1).Year;
            }
            
            return KadrController.Instance.Model.TimeSheets.Where(ts =>
                    (ts.TimeSheetMonth == CurrentMonthNumber) && (ts.TimeSheetYear == CurrentYearNumber)).FirstOrDefault();
        }

        /// <summary>
        /// Возвращает список сотрудников, переданых отделов
        /// </summary>
        /// <returns></returns>
        public IEnumerable<GetFactStaffForTimeSheetResult> GetStaffByPeriod()
        {
            return KadrController.Instance.Model.GetFactStaffForTimeSheet(MonthBegin, MonthEnd).Where(staff =>
                !Convert.ToBoolean(staff.IsReplacement)).Where(staff => (staff.idFactStaff != null));
        }



        /// <summary>
        /// Возвращает список сотрудников отдела для табеля
        /// </summary>
        /// <param name="dep">Отдел</param>
        /// <returns></returns>
        public IEnumerable<GetFactStaffForTimeSheetResult> GetStaffByPeriod(Dep dep)
        {
            
            if ((dep==null) || (dep.IsNull()))
                return GetStaffByPeriod();
            else
                return GetStaffByPeriod().ToArray().Where(staff => (staff.idDepartment == dep.id));
        }


        /// <summary>
        /// Создает (пересоздает) записи табелей для определенного отдела
        /// </summary>
        /// <param name="dep">Отдел</param>
        public void CreateTimeSheetRecords(Dep dep)
        {
            //получаем список сотрyдников отдела за период
            IEnumerable<GetFactStaffForTimeSheetResult> DepStaff = GetStaffByPeriod(dep);
                       

            IEnumerable<TimeSheetFSWorkingDay> InsertedTSRecords = null;

            DeleteDepsTShRecords(dep);

            InsertedTSRecords = DepStaff.Select(depSt =>
                new TimeSheetFSWorkingDay()
                {
                    TimeSheet = this,
                    idFactStaff = Convert.ToInt32(depSt.idFactStaff),
                    StaffCount = Convert.ToDecimal(depSt.StaffCount),
                    WorkingDaysCount = this.TimeSheetWorkingDayCount
                }).Distinct();

            KadrController.Instance.Model.TimeSheetFSWorkingDays.InsertAllOnSubmit(InsertedTSRecords);
            KadrController.Instance.SubmitChanges();
        }


       

        /// <summary>
        /// Удаляет записи табеля, относящиеся к отделe
        /// </summary>
        /// <param name="dep">Oтдел</param>
        public void DeleteDepsTShRecords(Dep dep)
        {
            IEnumerable<TimeSheetFSWorkingDay> DepTimeSheetRecords = GetDepsTShRecords(dep);
            if (DepTimeSheetRecords.Count() > 0)
            {
                KadrController.Instance.Model.TimeSheetFSWorkingDays.DeleteAllOnSubmit(DepTimeSheetRecords);
            }
        }


         public static readonly Func<dckadrDataContext, int, int, IEnumerable<TimeSheetFSWorkingDay>> DepsTShRecords =
            CompiledQuery.Compile<dckadrDataContext, int, int, IEnumerable<TimeSheetFSWorkingDay>>(
                (ctx, dep, tsh) => from tshRecord in ctx.TimeSheetFSWorkingDays
                                   where tshRecord.TimeSheet.id == tsh &&
                                        (dep < 0 ||
                                        tshRecord.FactStaff.PlanStaff.Dep.id == dep)
                                   select tshRecord);


        /// <summary>
        /// Возвращает список записей табеля, относящихся к отделy
        /// </summary>
        /// <param name="deps">Oтдел</param>
         public IEnumerable<TimeSheetFSWorkingDay> GetDepsTShRecords(Dep dep)
        {
            if (dep == null)
                return TimeSheetFSWorkingDays;
            else
                return
                    KadrController.Instance.Model.TimeSheetFSWorkingDays.Where(tswd =>
                       (tswd.TimeSheet == this) &&
                       (tswd.FactStaff.PlanStaff.Dep == dep));
                    
        }

        /// <summary>
        /// Возвращает список имеющихся в табеле штатных единиц, которые должны там быть
        /// </summary>
        /// <param name="staff">Общий список штатных единиц</param>
        /// <returns></returns>
        public IEnumerable<GetFactStaffForTimeSheetResult> GetInsertedStaff(IEnumerable<GetFactStaffForTimeSheetResult> staff)
        {


            IEnumerable<GetFactStaffForTimeSheetResult> InsertedStaff =
            (from st in staff
             join tsRec in TimeSheetFSWorkingDays
               on new { id = (int?)st.idFactStaff, StaffCount = (double?)st.StaffCount }
               equals new { id = (int?)tsRec.idFactStaff, StaffCount = (double?)tsRec.StaffCount }
             select new 
             {
                 TSFactStaff = st
             }).Select(st => st.TSFactStaff).ToArray();

            return InsertedStaff;
         }

        /// <summary>
        /// Возвращает список имеющихся в табеле штатных единиц, которые должны там быть
        /// </summary>
        /// <param name="staff">Общий список штатных единиц</param>
        /// <returns></returns>
        public IEnumerable<GetFactStaffForTimeSheetResult> GetNotInsertedStaff(IEnumerable<GetFactStaffForTimeSheetResult> staff)
        {
            IEnumerable<GetFactStaffForTimeSheetResult> NotInsertedStaff = staff.Except(GetInsertedStaff(staff)).Distinct().ToArray();

            return NotInsertedStaff;
        }
       
        /// <summary>
        /// Возвращает список недостающих в табеле штатных единиц
        /// </summary>
        /// <param name="staff">Общий список штатных единиц</param>
        /// <returns></returns>
        public IEnumerable<TimeSheetFSWorkingDay> GetStaffRecordsForInsert(IEnumerable<GetFactStaffForTimeSheetResult> staff)
        {
            IEnumerable<TimeSheetFSWorkingDay> RecordsForInsert = GetNotInsertedStaff(staff).Select(st => new TimeSheetFSWorkingDay
            {
                idFactStaff = (int)st.idFactStaff,
                TimeSheet = this,
                StaffCount = st.StaffCount,
                WorkingDaysCount = Convert.ToInt32(st.daysCount),
                IsClosed = false
            }).Distinct().ToArray();

            return RecordsForInsert;
        }

        /// <summary>
        /// Возвращает список записей табеля для удаления (строки не соответствуют штатке)
        /// </summary>
        /// <param name="staff">Общий список штатных единиц</param>
        /// <returns></returns>
        public IEnumerable<TimeSheetFSWorkingDay> GetStaffRecordsForDelete(IEnumerable<GetFactStaffForTimeSheetResult> staff, Dep dep)
        {
            IEnumerable<TimeSheetFSWorkingDay> StaffTShRecords = DepsTShRecords.Invoke(KadrController.Instance.Model, dep.id, id).ToArray();

                    IEnumerable<TimeSheetFSWorkingDay> RecordsForDelete = StaffTShRecords.Except(
                (from st in GetInsertedStaff(staff)
                 join tsRec in TimeSheetFSWorkingDays
                   on new { id = (int?)st.idFactStaff, StaffCount = (double?)st.StaffCount }
                   equals new { id = (int?)tsRec.idFactStaff, StaffCount = (double?)tsRec.StaffCount }
                 select new
                 {
                     TSRecord = tsRec
                 }).Select(st => st.TSRecord)).ToArray();

            return RecordsForDelete;
        }


 
        /// <summary>
        /// Обновляет записи табеля для определенного отдела
        /// </summary>
        /// <param name="dep">Отдел</param>
        public void UpdateDepartmentsTimeSheet(Dep dep)
        {
            //получаем список сотрyдников отдела за период
            IEnumerable<GetFactStaffForTimeSheetResult> DepStaff = GetStaffByPeriod(dep).ToArray();

            
            //удаляем записи, сотрудники которых не работали в периоде
            IEnumerable<TimeSheetFSWorkingDay> RecordsForDelete = GetStaffRecordsForDelete(DepStaff, dep);
            if (RecordsForDelete.Count() > 0)
            {
                KadrController.Instance.Model.TimeSheetFSWorkingDays.DeleteAllOnSubmit(RecordsForDelete);
            }


            IEnumerable<TimeSheetFSWorkingDay> RecordsForInsert = GetStaffRecordsForInsert(DepStaff);


            KadrController.Instance.Model.TimeSheetFSWorkingDays.InsertAllOnSubmit(RecordsForInsert);
            KadrController.Instance.SubmitChanges();
        }


        /// <summary>
        /// Проверка всех параметров перед сохранением
        /// </summary>
        /// <param name="action"></param>
        partial void OnValidate(System.Data.Linq.ChangeAction action)
        {
            if ((action == ChangeAction.Insert) || (action == ChangeAction.Update))
            {
                if ((TimeSheetMonth < 1) || (TimeSheetMonth > 12))
                    throw new ArgumentOutOfRangeException("Месяц табеля");
                if ((TimeSheetWorkingDayCount < 1) || (TimeSheetWorkingDayCount > DateTime.DaysInMonth(TimeSheetYear, TimeSheetMonth)))
                    throw new ArgumentOutOfRangeException("Количество дней в месяце");
             }
        }



        public object GetDecorator()
        {
            return new TimeSheetDecorator(this);       
        }

        public void Validate()
        {
            OnValidate(ChangeAction.Insert); 
        }
    }
}
