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
    public enum FactStaffState {Present, Incapable, OnTrip, OnVacation, Fired};

    public partial class FactStaff : UIX.Views.IDecorable, UIX.Views.IValidatable, INullable, IObjectState, IComparable, IEmployeeExperienceRecord
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

        public FactStaff(UIX.Commands.ICommandManager commandManager, PlanStaff planStaff, Employee employee, bool isReplacement = false, Dep department = null, FinancingSource financingSource = null): this()
        {
            SetProperties(commandManager, planStaff, employee, isReplacement, department, financingSource);
        }

        public void SetProperties(UIX.Commands.ICommandManager commandManager, PlanStaff planStaff, Employee employee, bool isReplacement = false, Dep department = null, FinancingSource financingSource = null)
        {
            commandManager.Execute(new UIX.Commands.GenericPropertyCommand<FactStaff, PlanStaff>(this, "PlanStaff", planStaff, null), null);
            commandManager.Execute(new UIX.Commands.GenericPropertyCommand<FactStaff, Employee>(this, "Employee", employee, null), null);
            commandManager.Execute(new UIX.Commands.GenericPropertyCommand<FactStaff, bool>(this, "IsReplacement", isReplacement, null), null);
            commandManager.Execute(new UIX.Commands.GenericPropertyCommand<FactStaff, Dep>(this, "Dep", department, null), null);
            commandManager.Execute(new UIX.Commands.GenericPropertyCommand<FactStaff, FundingCenter>(this, "FundingCenter", NullFundingCenter.Instance, null), null);
            commandManager.Execute(new UIX.Commands.GenericPropertyCommand<FactStaff, FinancingSource>(this, "FinancingSource", financingSource, null), null);
        }

        #region NewEmployeeFactStaffProperties

        /// <summary>
        /// Признак того, что запись создана одновременно с новым сотрудником
        /// </summary>
        public bool EmployeeReadOnly
        {
            get;
            set;
        }

       
        #endregion


        #region MainProperties
        /// <summary>
        /// текущий статус сотрудника
        /// </summary>
        public FactStaffState CurrentState
        {
            get
            {
                //return FactStaffState.Present;

                var depId = CurrentChange.FactStaff.Department.id;
                if (!CurrentChange.FactStaff.Employee.FactStaffs.Any(x=>(x.Department.id == depId) &&((x.DateEnd > DateTime.Now)||(x.DateEnd == null)))) return FactStaffState.Fired;

                IEnumerable<Event_BusinessTrip> tripevents = CurrentChange.Events.Where(x => (x.idPrikazEnd == null) && (x.idEventType == MagicNumberController.BeginEventTypeId) && (x.DateBegin < DateTime.Now) && (x.DateEnd > DateTime.Now)).Select(x => x.Event_BusinessTrip);
                IEnumerable<BusinessTrip> currenttrips = tripevents.Where(t => t != null).Select(x=>x.BusinessTrip);


                if (currenttrips.Any()) return FactStaffState.OnTrip;

                if (Employee.OK_Inkapacities.Where(t => (t.DateBegin < DateTime.Now) && ((t.DateEnd > DateTime.Now) || (t.DateEnd == null))).Any())
                return FactStaffState.Incapable;

                if (OK_Otpusks.Where(t => (t.DateBegin < DateTime.Now) && (t.DateEnd > DateTime.Now)).Any())
                    return FactStaffState.OnVacation;

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

        public decimal CalcStaffCount
        {
            get
            {
                if (LastChange == null)
                    return 0;
                return LastChange.CalcStaffCount;
            }
            set
            {
                LastChange.CalcStaffCount = value;
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


        public Contract GlobalMainContract
        {
            get
            {
                if (FirstDesignate != null)
                    if (FirstDesignate.Contract != null)
                        return FirstDesignate.Contract.IsMainContract ? FirstDesignate.Contract : FirstDesignate.Contract.MainContract;
                return null;
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
                if (LastChange.idFinancingSource > 0)
                    return LastChange.FinancingSource;
                if (PlanStaff != null)
                    return PlanStaff.FinancingSource;
                return FinancingSource;
            }
            /*set
            {
                if (CurrentChange.idFinancingSource > 0)
                    return CurrentChange.FinancingSource;
                if (PlanStaff != null)
                    return PlanStaff.FinancingSource;
                return FinancingSource;
            }*/
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
                return CurrentChange.Event.Contract;
            }
            set
            {
                CurrentChange.Event.Contract = value;
            }
        }

        public Contract CurrentMainContract
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
                if ((PlanStaff == null) && (HourCount == null)) throw new ArgumentNullException("Количество часов.");
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

                if (FinancingSource != null)
                    if (FinancingSource.IsNull())
                        FinancingSource = null;

                FundingCenter = PlanStaff.Dep.FundingCenter;

                if (OKVED != null)
                    if (OKVED.IsNull())
                        OKVED = null;
                if (OK_Reason != null)
                    if ((OK_Reason.IsNull()) || (OK_Reason.idreason == OK_Reason.NotFired))
                        OK_Reason = null;

                (CurrentChange as UIX.Views.IValidatable).Validate();
            }
        }

        #endregion

        #region IDecorable Members

        public object GetDecorator()
        {
            if ((EmployeeReadOnly) && (PlanStaff.IsNull()))
                return new FactStaffTransferDecorator(this);
            if (EmployeeReadOnly)
                return new FactStaffEmployeeReadOnlyDecorator(this);
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


        public override string ToString()
        {
            return "(Не задан)";
        }

    }

    

}
