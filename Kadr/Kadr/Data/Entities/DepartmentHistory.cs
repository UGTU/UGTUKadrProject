using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Linq;
using Kadr.Data.Common;

namespace Kadr.Data
{
    partial class DepartmentHistory : INull, UIX.Views.IDecorable, UIX.Views.IValidatable
    {

        public override string ToString()
        {
            return "Изменение " + Dep.ToString();
        }


        /*public bool IsLatest
        {
            get
            {
                if (this == FactStaff.FactStaffHistories.OrderBy(fcStHist => fcStHist.DateBegin).LastOrDefault())
                    return true;
                else
                    return false;
            }
        }*/

        /*public decimal DepExtraordSum
        {
            get
            {
                return Dep.DepExtraordSum;
            }
            set
            {
                Dep.DepExtraordSum = value;
            }
        }

        public decimal DepPlanFundSum
        {
            get
            {
                return Dep.DepPlanFundSum;
            }
            set
            {
                Dep.DepPlanFundSum = value;
            }
        }

        public decimal DepFactFundSum
        {
            get
            {
                return Dep.DepFactFundSum;
            }
            set
            {
                Dep.DepFactFundSum = value;
            }
        }*/
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

                if (DateBegin == null) 
                    throw new ArgumentNullException("Дата изменения.");
                if (((Prikaz as Kadr.Data.Common.INull).IsNull()) || (Prikaz == null))
                    throw new ArgumentNullException("Приказ изменения.");
            }

         }
        #endregion

        public object GetDecorator()
        {
            return new DepartmentHistoryDecorator(this);
        }

        #region IValidatable Members

        void UIX.Views.IValidatable.Validate()
        {
            OnValidate(ChangeAction.Insert);
        }
        #endregion

        bool INull.IsNull()
        {
            return false;
        }
    }


    public class NullDepartmentHistory : DepartmentHistory, INull
    {

        private NullDepartmentHistory()
        {
            this.id = -1;
            this.DepartmentName = "(Не задан)";
            this.DepartmentSmallName = "(Не задан)";
            idManagerDepartment = -1;
        }

        public static readonly NullDepartmentHistory Instance = new NullDepartmentHistory();

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



