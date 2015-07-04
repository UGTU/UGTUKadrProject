using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Kadr.Data.Common;

namespace Kadr.Data
{
    partial class DepartmentTimeNorm: UIX.Views.IDecorable, UIX.Views.IValidatable
    {
        public override string ToString()
        {
            return "Норма времени отдела "+ Dep.DepartmentName.ToLower();
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
                if (this.FinancingSource.IsNull()) throw new ArgumentNullException("Источник финансирования.");
                if (this.NormHoursCount <= 0) throw new ArgumentNullException("Норма времени.");
               
            }
        }
        #endregion

        #region IDecorable Members

        public object GetDecorator()
        {
            return new DepartmentTimeNormDecorator(this);
        }


        #endregion


        #region IValidatable Members

        void UIX.Views.IValidatable.Validate()
        {
            OnValidate(System.Data.Linq.ChangeAction.Insert);
        }

        #endregion

    }
}
