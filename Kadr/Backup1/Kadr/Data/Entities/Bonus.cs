using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Kadr.Data.Common;
using Kadr.Controllers;
using System.Data.Linq;

namespace Kadr.Data
{
    public partial class Bonus : UIX.Views.IDecorable, UIX.Views.IValidatable, INull
    {
        public override string ToString()
        {
            return "Надбавка " + FactStaff.Employee.ToString() + ", " + BonusType.ToString();
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
            BonusCount = 0;
        }

        /// <summary>
        /// Проверка всех параметров перед сохранением
        /// </summary>
        /// <param name="action"></param>
        partial void OnValidate(System.Data.Linq.ChangeAction action)
        {
            if ((action == ChangeAction.Insert) || (action == ChangeAction.Update))
            {
                if (BonusType.IsNull()) throw new ArgumentNullException("Вид надбавки.");
                if (FactStaff.IsNull()) throw new ArgumentNullException("Сотрудник.");
                if (Prikaz.IsNull()) throw new ArgumentNullException("Приказ назначения надбавки.");
                if ((BonusCount<=0))
                    throw new ArgumentOutOfRangeException("Размер надбавки должен быть больше 0.");
                if ((DateEnd != null) && (DateEnd <= DateBegin))
                    throw new ArgumentOutOfRangeException("Дата отмены должна быть позже даты назначения.");

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
