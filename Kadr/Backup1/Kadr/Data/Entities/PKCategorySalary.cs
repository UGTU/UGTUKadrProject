using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Kadr.Data.Common;
using Kadr.Controllers;
using System.Data.Linq;

namespace Kadr.Data
{
    public partial class PKCategorySalary : UIX.Views.IDecorable, UIX.Views.IValidatable, INull 
    {
        public override string ToString()
        {
            return Convert.ToString(this.SalarySize);
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
                if (this.PKCategory.IsNull()) throw new ArgumentNullException("Профессиональная категория.");
                if (this.SalarySize <= 0) throw new ArgumentOutOfRangeException("Размер оклада.");
                if (DateBegin >= DateEnd) throw new ArgumentOutOfRangeException("Дата отмены оклада должна быть позже даты назначения.");
            }
        }
        #endregion

        #region Члены IDecorable

        public object GetDecorator()
        {
            return new PKCategorySalaryDecorator(this);
        }

        #endregion

        #region Члены IValidatable

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


    public class NullPKCategorySalary : PKCategorySalary, INull
    {

        private NullPKCategorySalary()
        {
            this.id = 0;
            //this.SalarySize = 0;
        }

        public static readonly NullPKCategorySalary Instance = new NullPKCategorySalary();

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







