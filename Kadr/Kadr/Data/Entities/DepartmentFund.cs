using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Kadr.Data.Common;

namespace Kadr.Data
{
    partial class DepartmentFund : INull, UIX.Views.IDecorable, UIX.Views.IValidatable
    {
        public override string ToString()
        {
            return "Бюджетный фонд отдела "+ Dep.DepartmentName.ToLower();
        }

        #region partial Methods

        partial void OnCreated()
        {
            DateBegin = DateTime.Today.Date;
            //this.
        }

        /// <summary>
        /// Проверка всех параметров перед сохранением
        /// </summary>
        /// <param name="action"></param>
        partial void OnValidate(System.Data.Linq.ChangeAction action)
        {
            if ((action == System.Data.Linq.ChangeAction.Insert) || (action == System.Data.Linq.ChangeAction.Update))
            {
                if (this.Dep.IsNull()) throw new ArgumentNullException("Отдел.");
                if (this.PlanFundSum <= 0) throw new ArgumentNullException("Плановый размер фонда.");
                if (this.FactFundSum <= 0) throw new ArgumentNullException("Фактический размер фонда.");
            }
        }
        #endregion

        #region IDecorable Members

        public object GetDecorator()
        {
            return new DepartmentFundDecorator(this);
        }


        #endregion


        #region IValidatable Members

        void UIX.Views.IValidatable.Validate()
        {
            OnValidate(System.Data.Linq.ChangeAction.Insert);
        }

        #endregion

        bool INull.IsNull()
        {
            return false;
        }
    }

    public class NullDepartmentFund : DepartmentFund, INull
    {

        private NullDepartmentFund()
        {
 
        }

        public static readonly NullDepartmentFund Instance = new NullDepartmentFund();

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


