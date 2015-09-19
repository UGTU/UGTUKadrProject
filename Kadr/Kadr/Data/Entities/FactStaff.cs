using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Kadr.Data.Common;
using Kadr.Controllers;
using System.Data.Linq;
using Kadr.Data;


namespace Kadr.Data
{
    public enum FactStaffState {Present, Incapable, OnTrip, OnVacation};

    public partial class FactStaff : UIX.Views.IDecorable, UIX.Views.IValidatable, INull, IObjectState, IComparable, IEmployeeExperienceRecord
    {

        public override string ToString()
        {
            string res;
            res = "";
            if (UniversalEmployee != null)
                res = res + UniversalEmployee.ToString();

            /* if (MainFactStaff != null)
                 res = res + MainFactStaff.Employee.ToString();*/
            if (this.PlanStaff == null)
            {
                if (Dep != null)
                    res = res + ", " + this.Dep.ToString();
            }
            else
            {
                res = res + ", " + this.PlanStaff.Post.ToString();
            }

            if (this.WorkType != null)
                res = res + ", " + this.WorkType.ToString();
            res = res + ", " + StaffCount.ToString() + " ставки";
            return res;
        }

        #region NewEmployeeFactStaffProperties

        /// <summary>
        /// Признак того, что запись создана одновременно с новым сотрудником
        /// </summary>
        public bool WithNewEmployee
        {
            get;
            set;
        }

        /*public FactStaff(Employee employee)
        {
            NewEmployee = employee;
        }

        public Employee NewEmployee
        {
            get;
            set;
        }*/
        
        #endregion


        #region MainProperties
        /// <summary>
        /// текущий статус сотрудника
        /// </summary>
        public FactStaffState CurrentState
        {
            get
            {

                var trips = CurrentChange.Events.SelectMany(x => x.BusinessTrips).Where(t => (t.Event.DateBegin < DateTime.Now) && (t.Event.DateEnd > DateTime.Now));
                if (trips.Any()) return FactStaffState.OnTrip;


                var incapacities = Employee.OK_Inkapacities.Where(t => (t.DateBegin < DateTime.Now) && (t.DateEnd > DateTime.Now));
                if (incapacities.Any()) return FactStaffState.Incapable;

                var vacs = OK_Otpusks.Where(t => (t.DateBegin < DateTime.Now) && (t.DateEnd > DateTime.Now));
                if (vacs.Any()) return FactStaffState.OnVacation;

                return FactStaffState.Present;
            }
        }

        public DateTime DateBegin
        {
            get
            {
                return FirstDesignate.DateBegin;
            }
            set
            {
                FirstDesignate.DateBegin = value;
            }
        }


        public Prikaz PrikazBegin
        {
            get
            {
                if (LastChange == null)
                    return null;
               return LastChange.Prikaz;
            }
            set
            {
                LastChange.Prikaz = value;
            }
        }

        public WorkType WorkType
        {
            get
            {
                if (LastChange == null)
                    return null;
                return LastChange.WorkType;
            }
            set
            {
                LastChange.WorkType = value;
            }
        }

        public SalaryKoeff SalaryKoeff
        {
            get
            {
                return LastChange.SalaryKoeff;
            }
            set
            {
                LastChange.SalaryKoeff = value;
            }
        }

        public decimal StaffCount
        {
            get
            {
                if (LastChange == null)
                    return 0;
                return LastChange.StaffCount;
            }
            set
            {
                LastChange.StaffCount = value;
            }
        }

        public Category Category
        {
            get
            {
                if (PlanStaff != null)
                    return PlanStaff.Post.Category;
                return NullCategory.Instance;
            }
        }

        public PKCategory PKCategory
        {
            get
            {
                if (PlanStaff != null)
                    return PlanStaff.Post.PKCategory;
                return NullPKCategory.Instance;
            }
        }

        public string SalarySize
        {
            get
            {
                if (PlanStaff != null)
                    return PlanStaff.SalarySize;
                return HourSalary.ToString();
                //return null;
            }
        }

        

        #endregion


        #region FactStaffHistories
        /// <summary>
        /// Первоначальное назначение (изменение)
        /// </summary>
        public FactStaffHistory GetHistoryForDate(DateTime? Date)
        {
            if ((Date == null) || (Date == DateTime.MinValue))
                return CurrentChange;
            return FactStaffHistories.Where(fcStHist => fcStHist.DateBegin <= Date).OrderBy(fcStHist => fcStHist.DateBegin).LastOrDefault()?? CurrentChange;
        }

        /// <summary>
        /// Первоначальное назначение (изменение)
        /// </summary>
        public FactStaffHistory FirstDesignate
        {
            get
            {
                return FactStaffHistories.OrderBy(fcStHist => fcStHist.DateBegin).FirstOrDefault();
            }
        }

        /// <summary>
        /// Последнее изменение
        /// </summary>
        public FactStaffHistory CurrentChange
        {
            get
            {
                return FactStaffHistories.Where(fcStHist => fcStHist.DateBegin <= DateTime.Today.Date).OrderBy(fcStHist => fcStHist.DateBegin).LastOrDefault()??
                    FactStaffHistories.FirstOrDefault();
            }
        }

        /// <summary>
        /// Последнее изменение
        /// </summary>
        public FactStaffHistory LastChange
        {
            get
            {
                return FactStaffHistories.OrderBy(fcStHist => fcStHist.DateBegin).LastOrDefault();
            }
        }

        #endregion

        #region HourStaffProperties

        /// <summary>
        /// Сумма уже отработанных часов
        /// </summary>
        public decimal WorkedHoursSum
        {
            get
            {
                if (FactStaffMonthHours.Any())
                {
                    return FactStaffMonthHours.Sum(fcStH => fcStH.HourCount);
                }
                return 0;
            }
        }

        /// <summary>
        /// кол-во оставшихся часов
        /// </summary>
        public decimal RestHours
        {
            get
            {
                if (HourCount != null)
                    return HourCount.Value - WorkedHoursSum;
                return 0;
            }
        }

        /// <summary>
        /// Признак почасовика. Проверяется по наличию привязки к должности в штатах. Если ее нет, значит почасовик и наоборот.
        /// </summary>
        public bool IsHourStaff
        {
            get
            {
                return (PlanStaff == null);
            }
        }

        /// <summary>
        /// Признак почасовика-контрактника
        /// </summary>
        public bool IsContractHourStaff
        {
            get
            {
                return IsHourStaff && (MainFactStaff != null);
            }
        }

        /// <summary>
        /// Признак почасовика по приказу
        /// </summary>
        public bool IsPrikazHourStaff
        {
            get
            {
                return IsHourStaff && (MainFactStaff == null);
            }
        }

        /// <summary>
        /// кол-во ставок для почасовиков
        /// </summary>
        public decimal? HourStaffCount
        {
            get
            {
                if (LastChange == null)
                    return 0;
                return LastChange.HourStaffCount;
            }
            set
            {
                LastChange.HourStaffCount = value;
            }
        }

        /// <summary>
        /// основная ставка сотрудника (для почасовиков)
        /// </summary>
        public FactStaff MainFactStaff
        {
            get
            {
                return FactStaff1;
            }
            set
            {
                FactStaff1 = value;
            }
        }

        public FactStaffCurrentMainData MainFactStaffData
        {
            get
            {
                if (MainFactStaff != null)
                    return KadrController.Instance.Model.FactStaffCurrentMainDatas.Where(fcSt => fcSt.id == MainFactStaff.id).SingleOrDefault();
                else return null;
            }
        }

        /// <summary>
        /// кол-во часов
        /// </summary>
        public decimal? HourCount
        {
            get
            {
                if (LastChange == null)
                    return 0;
                return LastChange.HourCount;
            }
            set
            {
                LastChange.HourCount = value;
            }
        }

        /// <summary>
        /// оплата за час
        /// </summary>
        public decimal? HourSalary
        {
            get
            {
                if (LastChange == null)
                    return 0;
                return LastChange.HourSalary;
            }
            set
            {
                LastChange.HourSalary = value;
            }
        }

        /// <summary>
        /// полная оплата за час
        /// </summary>
        public decimal? HourFullSalary
        {
            get
            {
                if (LastChange == null)
                    return 0;
                return LastChange.HourFullSalary;
            }
            set
            {
                LastChange.HourFullSalary = value;
            }
        }

        /// <summary>
        /// кол-во часов за месяц (для почасовиков в редактировании)
        /// </summary>
        public decimal? MonthHourCount
        {
            get;
            set;
        }

        #endregion

        #region UniversalProperties
        /// <summary>
        /// Отдел
        /// </summary>
        public Kadr.Data.Dep Department
        {
            get
            {
                if (PlanStaff == null)
                    return Dep;//почасовик
                return PlanStaff.Dep;//обычный сотрудник
            }
            set
            {
                if (PlanStaff == null)
                    Dep = value;
                else
                    PlanStaff.Dep = value;
            }
        }

        /// <summary>
        /// Сотрудник (общий для почасовиков и остальных)
        /// </summary>
        public Employee UniversalEmployee
        {
            get
            {
                if (Employee != null)
                    return Employee;
                if (MainFactStaff != null)
                    return MainFactStaff.Employee;
                return NullEmployee.Instance;
            }
        }

        /// <summary>
        /// Источник фин-я (общий)
        /// </summary>
        public FinancingSource FinSource
        {
            get
            {
                if (PlanStaff != null)
                    return PlanStaff.FinancingSource;
                return FinancingSource;
            }
            set
            {
                if (PlanStaff != null)
                    PlanStaff.FinancingSource = value;
                else
                    FinancingSource = value;
            }
        }

        public Kadr.Data.Post Post
        {
            get
            {
                if (PlanStaff == null)
                    return NullPost.Instance;
                return PlanStaff.Post;
            }
            set
            {
                if (PlanStaff != null)
                    PlanStaff.Post = value;
            }
        }
        #endregion 

        #region Contracts


        public Contract CurrentContract
        {
            get
            {
                return CurrentChange.Contract;
            }
            set
            {
                CurrentChange.Contract = value;
            }
        }

        public Contract MainContract
        {
            get
            {
                if (CurrentChange.Contract != null)
                    return CurrentChange.Contract.MainContract;
                return null;
            }
            set
            {
                if (CurrentChange.Contract != null)
                    CurrentChange.Contract.MainContract = value;
            }
        }

        /*public bool IsMainContract
        {
        }*/
        #endregion


        #region ReplacementData

        public bool isReplacement
        {
            get
            {
                if (FactStaffReplacement != null)
                    if ((FactStaffReplacement.DateEnd == null) || (FactStaffReplacement.DateEnd > DateTime.Today))
                        return true;

                return false;
            }
        }

        public string ReplacedEmployeeName
        {
            get
            {
                string res = "";
                if (FactStaffReplacements.Any())
                {
                    foreach (FactStaffReplacement factStaffRepl in FactStaffReplacements)
                    {
                        if ((factStaffRepl.DateEnd == null) || (factStaffRepl.DateEnd > DateTime.Today))
                        {
                            if ((factStaffRepl.MainFactStaff.Prikaz == null) && (factStaffRepl.MainFactStaff.Employee != null))
                            {
                                if (res != "")
                                    res += "; ";
                                res += factStaffRepl.MainFactStaff.Employee.EmployeeSmallName + " (" +
                                    factStaffRepl.ReplacedPercent.ToString("N2") + "%)";
                            }
                        }
                    }

                    //KadrController.Instance.Model.FactStaffReplacements.Where(replmnt => replmnt.FactStaff == this).Select(replmn => replmn.FactStaff1.Employee).Select(empl => empl.EmployeeSmallName).FirstOrDefault();
                }
                return res;
            }
        }

        public string MaternityLeave
        {
            get
            {
                var leave = OK_Otpusks.Where(otp => ((otp.OK_Otpuskvid.isMaternity) && (otp.DateBegin <= DateTime.Today) && ((otp.DateEnd == null) || (otp.DateEnd >= DateTime.Today)))).FirstOrDefault();
                if (leave != null)
                    return leave.OK_Otpuskvid.otpTypeShortName;
                return null;
            }
        }

        #endregion 

        /// <summary>
        /// свойства надбавки - использутся для назначения надбавок
        /// </summary>
        #region BonusProperties
        public decimal? BonusCount
        {
            get;
            set;
        }

        public DateTime? BonusDateBegin
        {
            get;
            set;
        }

        public string BonusFinancingSourceName
        {
            get;
            set;
        }
        #endregion

        #region HourFactStaffCreate 

        public FactStaffHour FactStaffHour
        {
            get
            {
                return new FactStaffHour(this);
            }
        }


        public FactStaffHourContract FactStaffHourContract
        {
            get
            {
                return new FactStaffHourContract(this);
            }
        
        }
 
        #endregion

        #region PostEducation
        public EmployeeDegree EmployeeDegree
        {
            get
            {
                return UniversalEmployee.Degree;
            }
        }

        public EmployeeRank EmployeeRank
        {
            get
            {
                return UniversalEmployee.Rank;
            }
        }
        #endregion

        #region partial Methods

 
        /// <summary>
        /// Проверка всех параметров перед сохранением
        /// </summary>
        /// <param name="action"></param>
        partial void OnValidate(System.Data.Linq.ChangeAction action)
        {
            if ((action == ChangeAction.Insert) || (action == ChangeAction.Update))
            {
                if ((PlanStaff == null) && (HourCount == null)) throw new ArgumentNullException("Элемент штатного расписания.");
                if ((Dep == null) && (HourCount > 0)) throw new ArgumentNullException("Отдел для почасовика.");

                if (MainFactStaff != null)
                    if (MainFactStaff.IsNull())
                        MainFactStaff = null;

                if (Employee != null)
                    if (Employee.IsNull())
                        Employee = null;
                if (Employee == null && (MainFactStaff == null) ) throw new ArgumentNullException("Сотрудник.");
                if (WorkType.IsNull()) throw new ArgumentNullException("Вид работы.");
                if (PrikazBegin != null)
                {
                    if (((PrikazBegin.IsNull())) && !IsHourStaff) throw new ArgumentNullException("Приказ назначения.");
                    if (PrikazBegin.IsNull() && IsHourStaff)
                        PrikazBegin = null;
                }
                if (this.DateBegin == null)
                    throw new ArgumentNullException("Дата назначения на работу.");
                if ((StaffCount < 0) && (HourCount==null)) throw new ArgumentOutOfRangeException("Количество ставок.");
                if (DateEnd == DateTime.MinValue)
                    DateEnd = null;
                if (DateEnd != null)
                    if (DateEnd <= DateBegin)
                        throw new ArgumentOutOfRangeException("Дата увольнения должна быть позже даты назначения.");
                    else
                        DateEnd = DateEnd.Value.Date;

                if ((Prikaz != null) && (DateEnd == null))
                    throw new ArgumentNullException("Дата увольнения, так как указан приказ об увольнении.");
                if ((Prikaz == null) && (DateEnd != null) && !IsHourStaff) //для почасовиков приказ необязателен
                    throw new ArgumentNullException("Приказ об увольнении, так как указана дата увольнения.");
                if (FundingCenter != null)
                    if (FundingCenter.IsNull())
                        FundingCenter = null;
                if (OKVED != null)
                    if (OKVED.IsNull())
                        OKVED = null;

                (CurrentChange as UIX.Views.IValidatable).Validate();
            }
        }

        #endregion

        #region IDecorable Members

        public object GetDecorator()
        {
            if (WithNewEmployee)
                return new FactStaffEmployeeAddingDecorator(this);
            if (IsHourStaff)
                return new FactStaffHourDecorator(this);
            return new FactStaffDecorator(this);
        }


        #endregion




        #region IValidatable Members

        void UIX.Views.IValidatable.Validate()
        {
            OnValidate(ChangeAction.Insert);
        }

        #endregion


        #region INull Members

        bool INull.IsNull()
        {
            return false;
        }

        #endregion


        #region IObjectState Members

        ObjectState IObjectState.State()
        {
            if ((((Prikaz == null) && (DateEnd == null)) || (DateEnd > DateTime.Today))/*&& (FactStaffHistories.Where(fcSt => fcSt.DateBegin <= DateTime.Today).Count()>0)*/)
                return ObjectState.Current;
            return ObjectState.Canceled;
        }

        #endregion

        public int CompareTo(object obj)
        {
            return ToString().CompareTo(obj.ToString());
        }

        /*public FactStaffHour FactStaffHour
        {
            get
            {
                return new FactStaffHour(this);
            }
        }*/
        
        /// <summary>
        /// Признак того, что этот стаж имеет дату завершения
        /// </summary>
        public bool IsEnded { get { return DateEnd.HasValue; } }

        public TerritoryConditions Territory
        {
            get
            {

                //Заглушка до тех пор, пока не определимся, что указывает на территориальные условия
                return TerritoryConditions.North;
            }
        }
        public KindOfExperience Experience {
            get
            {
                return Category.GetKindOfExperience();
            }

        }
        
        public Affilations Affilation {
            get
            {
                // Записи штатного расписания всегда являются стажем в организации
                return Affilations.Organization;
            }
        }

        public WorkOrganizationWorkType WorkWorkType
        {
            get { return WorkType.GetOrganizationWorkType(); }
        }

        public DateTime Start { get { return DateBegin; }
            set { }
        }
        public DateTime Stop { get { return DateEnd.HasValue ? DateEnd.Value : DateTime.Today; }
            set { }
        }
    }


    public class NullFactStaff : FactStaff, INull
    {

        private NullFactStaff()
        {
            this.id = 0;
        }

        public static readonly NullFactStaff Instance = new NullFactStaff();

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
