using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Linq;

namespace Kadr.Data
{
    partial class BonusHistory : UIX.Views.IDecorable, UIX.Views.IValidatable
    {

        public override string ToString()
        {
            return "Изменение " + Bonus.ToString();
        }

        /*public Prikaz PrikazChange
        {
            get
            {
                if (IsLatest)
                    return Bonus.Prikaz;
                else
                {
                    bonusHistory nextChange = BonusNextChange;
                    if (nextChange != null)
                        return nextChange.Prikaz;  
                }
                return null;
            }
            set
            {
                if (IsLatest)
                    Bonus.Prikaz = value;
                else
                {
                    bonusHistory nextChange = BonusNextChange;
                    if (nextChange != null)
                        nextChange.Prikaz = value;
                }
            }
        }

        /// <summary>
        /// Возвращает следующее после данного изменение надбавки
        /// </summary>
        public bonusHistory BonusNextChange
        {
            get
            {
                return this.BonusHistories.FirstOrDefault();
                //return Bonus.BonusHistories.Where(bonHist => bonHist.bonusHistory1 == this).FirstOrDefault();
            }
        }

        /// <summary>
        /// Новый размер надбавки
        /// </summary>
        public decimal NewBonusCount
        {
            get
            {
                if (IsLatest)
                    return Bonus.BonusCount;
                else
                    if (BonusNextChange != null)
                        return BonusNextChange.PrevBonusCount;
                return 0;
            }
            set
            {
                if (IsLatest)
                    Bonus.BonusCount = value;
                else
                    if (BonusNextChange != null)
                        BonusNextChange.PrevBonusCount = value;
            }
        }
        */
        /// <summary>
        /// Признак последнего (по дате) изменения надбавки
        /// </summary>
        public bool IsLatest
        {
            get
            {
                if (this == Bonus.BonusHistories.OrderBy(bonHist => bonHist.DateBegin).LastOrDefault())
                    return true;
                else
                    return false;
                
            }
        }
 
        #region partial Methods
        partial void OnCreated()
        {
            DateBegin = DateTime.Today;
        }


        /// <summary>
        /// Проверка всех параметров перед сохранением
        /// </summary>
        /// <param name="action"></param>
        partial void OnValidate(System.Data.Linq.ChangeAction action)
        {
            if ((action == ChangeAction.Insert) || (action == ChangeAction.Update))
            {

                if ((BonusCount < 0))
                    throw new ArgumentOutOfRangeException("Размер надбавки должен быть больше или равен 0.");
                if (DateBegin == null)
                    throw new ArgumentNullException("Дата изменения.");
                if (((Prikaz as Kadr.Data.Common.INull).IsNull()) || (Prikaz == null))
                    throw new ArgumentNullException("Приказ изменения.");
                if ((Bonus.DateEnd != null) && (Bonus.DateEnd < this.DateBegin))
                    throw new ArgumentOutOfRangeException("Дата изменения. Указана позже, чем Дата окончания действия надбавки "+Bonus.DateEnd.ToString()+" )!");
            }

            /*if (action == ChangeAction.Delete)
            {
                if (IsLatest)
                {
                    FactStaff.StaffCount = this.PrevStaffCount;
                    FactStaff.WorkType = this.WorkType1;
                    FactStaff.Prikaz = this.Prikaz1;
                }
            }*/
        }
        #endregion

        public object GetDecorator()
        {
            return new BonusHistoryDecorator(this);
        }

        #region IValidatable Members

        void UIX.Views.IValidatable.Validate()
        {
            OnValidate(ChangeAction.Insert);
        }
        #endregion

    }
}

