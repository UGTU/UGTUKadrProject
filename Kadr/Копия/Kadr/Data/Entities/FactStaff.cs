using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Kadr.Data.Common;
using Kadr.Controllers;
using System.Data.Linq;


namespace Kadr.Data
{

    public partial class FactStaff : UIX.Views.IDecorable, UIX.Views.IValidatable, INull, IObjectState, IComparable
    {
        #region Properties


        public Kadr.Data.Dep Department
        {
            get
            {
                return PlanStaff.Dep;
            }
            set
            {
                PlanStaff.Dep = value;
            }
        }

        public Kadr.Data.Post Post
        {
            get
            {
                return PlanStaff.Post;
            }
            set
            {
                PlanStaff.Post = value;
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
                return FactStaffHistories.OrderBy(fcStHist => fcStHist.DateBegin).LastOrDefault();
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

        
        /*
        /// <summary>
        /// Первоначальное значение FactStaff
        /// </summary>
        public FactStaff FirstFactStaff
        {
            get
            {
                FactStaff PrevFactStaff = this;
                while (PrevFactStaff.FactStaffs.FirstOrDefault() != null)
                {
                    PrevFactStaff = PrevFactStaff.FactStaffs.FirstOrDefault();
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
                if (this.FactStaffReplacement != null)
                    return true;
                else
                    return false;
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
                        if ((factStaffRepl.FactStaff1.Prikaz == null) && (factStaffRepl.FactStaff1.Employee != null))
                        {
                            if (res != "")
                                res += "; ";
                            res += factStaffRepl.FactStaff1.Employee.EmployeeSmallName + " (" +
                                (factStaffRepl.FactStaff1.StaffCount * 100 / factStaffRepl.FactStaff.StaffCount).ToString("N2") + "%)";
                        }
                    }    
                        
                        //KadrController.Instance.Model.FactStaffReplacements.Where(replmnt => replmnt.FactStaff == this).Select(replmn => replmn.FactStaff1.Employee).Select(empl => empl.EmployeeSmallName).FirstOrDefault();
                }
                return res;
            }
        }
        #endregion 

        public override string ToString()
        {
            string res;
            res = "";
            if (Employee != null)
                res = res+ Employee.ToString();
            if (this.PlanStaff.Post != null)
                res = res  + ", " + this.PlanStaff.Post.ToString();
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
                if (PlanStaff.IsNull()) throw new ArgumentNullException("Элемент штатного расписания.");
                if (Employee.IsNull()) throw new ArgumentNullException("Сотрудник.");
                if (WorkType.IsNull()) throw new ArgumentNullException("Вид работы.");
                if (PrikazBegin.IsNull()) throw new ArgumentNullException("Приказ назначения.");
                if (this.DateBegin == null)
                    throw new ArgumentNullException("Дата назначения на работу.");
                if (StaffCount < 0) throw new ArgumentOutOfRangeException("Количество ставок.");
                if (DateEnd == DateTime.MinValue)
                    DateEnd = null;
                if ((DateEnd != null) && (DateEnd<=DateBegin))
                    throw new ArgumentOutOfRangeException("Дата увольнения должна быть позже даты назначения.");

                if ((Prikaz != null) && (DateEnd == null))
                    throw new ArgumentNullException("Дата увольнения, так как указан приказ об увольнении.");
                if ((Prikaz == null) && (DateEnd != null))
                    throw new ArgumentNullException("Приказ об увольнении, так как указана дата увольнения.");
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
            if (((Prikaz == null) && (DateEnd == null)) || (DateEnd > DateTime.Today))
                return ObjectState.Current;
            else
                return ObjectState.Canceled;

        }

        #endregion

        public int CompareTo(object obj)
        {
            return this.ToString().CompareTo(obj.ToString());
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
