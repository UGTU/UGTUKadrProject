using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Kadr.Data.Common;
using Kadr.Controllers;
using System.Data.Linq;

namespace Kadr.Data
{
    public partial class EmployeeRank : UIX.Views.IDecorable, UIX.Views.IValidatable, INull, IComparable
    {
        public override string ToString()
        {
            return Rank.SmallName;
        }

        #region partial Methods

        partial void OnCreated()
        {
            this.rankWhere = "Не указано";
        }

        /// <summary>
        /// Проверка всех параметров перед сохранением
        /// </summary>
        /// <param name="action"></param>
        partial void OnValidate(System.Data.Linq.ChangeAction action)
        {
            if ((action == ChangeAction.Insert) || (action == ChangeAction.Update))
            {
                if (Rank.IsNull())
                    throw new ArgumentNullException("Ученое звание.");
                if (Employee.IsNull())
                    throw new ArgumentNullException("Сотрудник.");
                if ((EducDocument.DocNumber == "") || (EducDocument.DocNumber == null))
                    throw new ArgumentNullException("Номер диплома.");
                if (EducDocument.IsNull())
                    throw new ArgumentNullException("Данные диплома.");

            }
        }

        partial void OnLoaded()
        {
            //if (PlanStaff == null)
            //    PlanStaff = NullPlanStaff.Instance;

        }


        #endregion


        bool INull.IsNull()
        {
            return false;
        }

        #region IDecorable Members

        public object GetDecorator()
        {
            return new EmployeeRankDecorator(this);
        }

        #endregion

        #region IValidatable Members

        public void Validate()
        {
            OnValidate(ChangeAction.Insert);
        }

        #endregion


        #region Члены IComparable

        public int CompareTo(object obj)
        {
            return (Rank.CompareTo((obj as EmployeeRank).Rank));
        }

        #endregion

    }

    public class NullEmployeeRank : EmployeeRank, INull
    {

        private NullEmployeeRank()
        {
            //this.id = 0;
        }

        public static readonly NullEmployeeRank Instance = new NullEmployeeRank();

        #region INull Members

        bool INull.IsNull()
        {
            return true;
        }

        public override string ToString()
        {
            return "(Не заданo)";
        }

        #endregion
    }
}
