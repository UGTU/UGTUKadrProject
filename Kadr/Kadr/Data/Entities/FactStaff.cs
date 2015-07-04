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

    public partial class FactStaff : UIX.Views.IDecorable, UIX.Views.IValidatable, INull, IObjectState, IComparable
    {

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

        #region Properties



        public decimal? MonthHourCount
        {
            get;
            set;
        }

        public Kadr.Data.Dep Department
        {
            get
            {
                if (PlanStaff == null)
                    return Dep;//почасовик
                else
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

        public FinancingSource FinSource
        {
            get
            {
                if (PlanStaff != null)
                    return PlanStaff.FinancingSource;
                else
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
                else
                    return PlanStaff.Post;
            }
            set
            {
                if (PlanStaff != null)
                    PlanStaff.Post = value;
            }
        }

        /// <summary>
        /// Сумма уже отработанных часов
        /// </summary>
        public decimal WorkedHoursSum
        {
            get
            {
                if (FactStaffMonthHours.Count() > 0)
                {
                    return FactStaffMonthHours.Sum(fcStH => fcStH.HourCount);
                }
                return 0;
            }
        }

        public decimal RestHours
        {
            get
            {
                return HourCount.Value - WorkedHoursSum;
            }
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
        public FactStaffHistory LastChange
        {
            get
            {
                return FactStaffHistories./*Where(fcStHist => fcStHist.DateBegin <= DateTime.Today.Date).*/OrderBy(fcStHist => fcStHist.DateBegin).LastOrDefault();
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
                else
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
                else
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

        /*public Category Category
        {
            get
            {
                return this.
            }
        }*/

       /* public int PKSubSubCategoryNumber
        {
            get
            {
                if ()
                return SalaryKoeff.PKSubSubCategoryNumber;
            }
            set
            {
                SalaryKoeff.PKSubSubCategoryNumber = value;
            }
        }*/

        public decimal StaffCount
        {
            get
            {
                if (LastChange == null)
                    return 0;
                else
                    return LastChange.StaffCount;
            }
            set
            {
                LastChange.StaffCount = value;
            }
        }

        public decimal? HourStaffCount
        {
            get
            {
                if (LastChange == null)
                    return 0;
                else
                    return LastChange.HourStaffCount;
            }
            set
            {
                LastChange.HourStaffCount = value;
            }
        }
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

        public decimal? HourCount
        {
            get
            {
                if (LastChange == null)
                    return 0;
                else
                    return LastChange.HourCount;
            }
            set
            {
                LastChange.HourCount = value;
            }
        }

        public decimal? HourSalary
        {
            get
            {
                if (LastChange == null)
                    return 0;
                else
                    return LastChange.HourSalary;
            }
            set
            {
                LastChange.HourSalary = value;
            }
        }

        public decimal? HourFullSalary
        {
            get
            {
                if (LastChange == null)
                    return 0;
                else
                    return LastChange.HourFullSalary;
            }
            set
            {
                LastChange.HourFullSalary = value;
            }
        }

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
        /*
        /// <summary>
        /// Первоначальное значение FactStaff
        /// </summary>
        public FactStaff FirstFactStaff
        {
            get
            {
                FactStaff PrevFactStaff = this;
                while (PrevFactStaff.FactStaff.FirstOrDefault() != null)
                {
                    PrevFactStaff = PrevFactStaff.FactStaff.FirstOrDefault();
                }
                return PrevFactStaff;
            }
        }
        
        /// <summary>
        /// Первоначальная дата назначения - с учетом всех изменений
        /// </summary>
        public DateTime? FirstDateBegin
        {
            get
            {
                return FirstFactStaff.DateBegin;
            }
            set
            {
                FirstFactStaff.DateBegin = value;

            }
        }

        public Kadr.Data.Employee ReplacedEmployee
        {
            get
            {
                return KadrController.Instance.Model.FactStaffReplacements.Where(replmnt => replmnt.FactStaff == this).Select(replmn => replmn.FactStaff.Employee).FirstOrDefault();
            }
        }*/

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

        public string ReplacedEmployeeName
        {
            get
            {
                string res = "";
                if (this.FactStaffReplacements.Count > 0 )
                {
                    foreach (FactStaffReplacement factStaffRepl in this.FactStaffReplacements)
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
                OK_Otpusk leave = OK_Otpusks.Where(otp => ((otp.OK_Otpuskvid.isMaternity) && (otp.DateBegin <= DateTime.Today) && ((otp.DateEnd == null) || (otp.DateEnd >= DateTime.Today)))).FirstOrDefault();
                if (leave != null)
                    return leave.OK_Otpuskvid.otpTypeShortName;
                return null;
            }
        }

        #endregion 

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
            }
        }

        #endregion


        #region HourFactStaff 

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



        #region IDecorable Members

        public object GetDecorator()
        {
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
            if ((((Prikaz == null) && (DateEnd == null)) || (DateEnd > DateTime.Today))&& (FactStaffHistories.Where(fcSt => fcSt.DateBegin <= DateTime.Today).Count()>0))
                return ObjectState.Current;
            else
                return ObjectState.Canceled;

        }

        #endregion

        public int CompareTo(object obj)
        {
            return this.ToString().CompareTo(obj.ToString());
        }

        /*public FactStaffHour FactStaffHour
        {
            get
            {
                return new FactStaffHour(this);
            }
        }*/
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
