using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Kadr.Data.Common;
using Kadr.Controllers;
using System.Data.Linq;

namespace Kadr.Data
{
    public partial class EmployeeDegree : UIX.Views.IDecorable, UIX.Views.IValidatable, INull, IComparable
    {

        public override string ToString()
        {

            if ((Degree != null) && (ScienceType != null))
            {
                try
                {
                     return Degree.DegreeAbbrev+" "+ScienceType.ScienceTypeAbbrev;
                }
                catch (InvalidOperationException)
                {
                    return "";
                }
            }
            return "";
        }

        #region partial Methods

        partial void OnCreated()
        {
            this.degreeDate = DateTime.Today;
            this.diplWhere = "ВАК России";
            this.DissertCouncil = "Не указан";
        }

        /// <summary>
        /// Проверка всех параметров перед сохранением
        /// </summary>
        /// <param name="action"></param>
        partial void OnValidate(System.Data.Linq.ChangeAction action)
        {
            if ((action == ChangeAction.Insert) || (action == ChangeAction.Update))
            {
                if (Degree.IsNull())
                    throw new ArgumentNullException("Научная степень.");
                if (ScienceType.IsNull())
                    throw new ArgumentNullException("Научное направление.");
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

        #region IDecorable Members

        public object GetDecorator()
        {
            return new EmployeeDegreeDecorator(this);
        }

        #endregion


        #region INull Members

        bool INull.IsNull()
        {
            return false;
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
            return (Degree.CompareTo((obj as EmployeeDegree).Degree));
        }

        #endregion
    }

    public class NullEmployeeDegree : EmployeeDegree, INull
    {

        private NullEmployeeDegree()
        {
            //this.id = 0;
        }

        public static readonly NullEmployeeDegree Instance = new NullEmployeeDegree();

        #region INull Members

        bool INull.IsNull()
        {
            return true;
        }

        public override string ToString()
        {
            return "(Не задано)";
        }

        #endregion
    }

}




