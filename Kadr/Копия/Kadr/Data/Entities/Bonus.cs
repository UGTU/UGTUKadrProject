using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Kadr.Data.Common;
using Kadr.Controllers;
using System.Data.Linq;

namespace Kadr.Data
{
     
    public partial class Bonus : UIX.Views.IDecorable, UIX.Views.IValidatable, INull, IObjectState
    {
        public override string ToString()
        {
            return "Надбавка "+BonusType.ToString();
        }

        public string BonusLevel
        {
            get
            {
                if (this.BonusEmployee != null)
                    return "Сотрудник";

                if (this.BonusFactStaff != null)
                    return "Распределение штатов";

                if (this.BonusPlanStaff != null)
                    return "Штатное расписание";

                if (this.BonusPost != null)
                    return "Должность";

                return "";
            }
        }

        /// <summary>
        /// Первое измение размера надбавки 
        /// </summary>
        public BonusHistory FirstChange
        {
            get
            {
                return BonusHistories.OrderBy(hist => hist.DateBegin).FirstOrDefault();
            }
        }


        /// <summary>
        /// Возвращает последнее изменение из истории изменений
        /// </summary>
        /// <returns></returns>
        public BonusHistory LastChange
        {
            get
            {
                return BonusHistories.OrderBy(hist => hist.DateBegin).LastOrDefault();
            }
        }


        public DateTime? IntermediateDateEnd
        {
            get
            {
                Prikaz IntermediatePrikazEnd = Prikaz1;
                if (IntermediatePrikazEnd != null)
                    return IntermediatePrikazEnd.DatePrikaz;
                else
                    return null;
            }
        }

        public Post Post
        {
            get
            {
                if (this.BonusFactStaff != null)
                    return BonusFactStaff.FactStaff.PlanStaff.Post;

                if (this.BonusPlanStaff != null)
                    return BonusPlanStaff.PlanStaff.Post;

                if (this.BonusPost != null)
                    return this.BonusPost.Post;

                return NullPost.Instance;
            }
        }
 
       /* public string BonusCountWithMeasure
        {
            get
            {
                return BonusCount.ToString() + " "+ this.BonusType.BonusMeasure.Sign;
            }
        }*/

        /// <summary>
        /// Возвращает признак есть ли история изменений
        /// </summary>
        public Boolean HasHistoryChanges
        {
            get
            {
                return (BonusHistories.Count > 1);
            }
        }

        /// <summary>
        /// Последний размер надбавки
        /// </summary>
        public decimal LastBonusCount
        {
            get
            {
                return LastChange.BonusCount;
            }
            set
            {
                LastChange.BonusCount = value;
            }
        }

        /// <summary>
        /// Приказ назначения (последний)
        /// </summary>
        public Prikaz LastPrikazBegin
        {
            get
            {
                return LastChange.Prikaz;
            }
            set
            {
                LastChange.Prikaz = value;
            }
        }

        /// <summary>
        /// Последняя дата изменения
        /// </summary>
        public DateTime LastDateBegin
        {
            get
            {
                return LastChange.DateBegin;
            }
            set
            {
                LastChange.DateBegin = value;
            }
        }

        /// <summary>
        /// Текущее значение надбавки
        /// </summary>
        public decimal BonusCount
        {
            get
            {
                return LastBonusCount;
            }
            set
            {
                LastBonusCount = value;
            }
        }

        /// <summary>
        /// Текущая дата назначения надбавки
        /// </summary>
        public DateTime DateBegin
        {
            get
            {
                return LastDateBegin;
            }
            set
            {
                LastDateBegin = value;
            }
        }

        /// <summary>
        /// Текущий приказ назначения
        /// </summary>
        public Prikaz PrikazBegin
        {
            get
            {
                return LastPrikazBegin;
            }
            set
            {
                LastPrikazBegin = value;
            }
        }


        #region IDecorable Members

        public object GetDecorator()
        {
            return new BonusDecorator(this);
        }


        #endregion


        #region partial Methods

        partial void OnCreated()
        {
            //DateBegin = DateTime.Today;
            //this.
            //BonusCount = 0;
        }

        /// <summary>
        /// Проверка всех параметров перед сохранением
        /// </summary>
        /// <param name="action"></param>
        partial void OnValidate(System.Data.Linq.ChangeAction action)
        {
            if ((action == ChangeAction.Insert) || (action == ChangeAction.Update))
            {
                if (DateEnd == DateTime.MinValue)
                    DateEnd = null;
                if (BonusType.IsNull()) throw new ArgumentNullException("Вид надбавки.");
                //if (FactStaff.IsNull()) throw new ArgumentNullException("Сотрудник.");
                if (PrikazBegin.IsNull()) throw new ArgumentNullException("Приказ назначения надбавки.");                
                if ((DateEnd != null) && (DateEnd < DateBegin))
                    throw new ArgumentOutOfRangeException("Дата отмены должна быть позже даты назначения.");
                if ((Prikaz != null) && (DateEnd == null))
                    throw new ArgumentNullException("Дата отмены надбавки, так как указан приказ отмены.");
            }
        }

        #endregion


        #region IValidatable Members

        void UIX.Views.IValidatable.Validate()
        {
            OnValidate(ChangeAction.Insert);
        }

        #endregion



        #region Члены INull

        bool INull.IsNull()
        {
            return false;
        }

        #endregion

        public ObjectState State()
        {
            ObjectState curState;
            
            if (((DateEnd == null) && (Prikaz == null)) || (DateEnd > DateTime.Today))
                curState = ObjectState.Current;
            else
                curState = ObjectState.Canceled;


            return curState;

        }
    }

    public class NullBonus : Bonus, INull
    {

        private NullBonus()
        {
            this.id = 0;
            this.BonusCount = 0;
        }

        public static readonly NullBonus Instance = new NullBonus();

        #region INull Members

        bool INull.IsNull()
        {
            return true;
        }

        public override string ToString()
        {
            return "(Не задана)";
        }

        #endregion
    }

}
