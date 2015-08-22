using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Kadr.Data.Common;
using Kadr.Controllers;
using System.Data.Linq;

namespace Kadr.Data
{
    public partial class Employee : UIX.Views.IDecorable, UIX.Views.IValidatable, INull, IComparable
    {
       /* public string EmployeeName
        {
            get
            {
                return this.LastName + " " + this.FirstName + " " + this.Otch;
            }
        }

        public string EmployeeSmallName
        {
            get
            {
                if ((FirstName != null) && (Otch != null))
                    return this.LastName + " " + this.FirstName[0] + "." + this.Otch[0] + ".";
                else
                    return LastName;
            }
        }*/

        public int? EmployeeYearsOld
        {
            get
            {
                
                if (BirthDate != null)
                {
                    int YearsDiff = DateTime.Today.Year - BirthDate.Value.Year;
                    if (DateTime.Today < BirthDate.Value.AddYears(YearsDiff))
                        return YearsDiff - 1;
                    else
                        return YearsDiff;
                }
                return null;
            }
        }

        public EmployeeRank Rank
        {
            get
            {
                return EmployeeRanks.OrderBy(empR => empR.Rank.RankOrder).LastOrDefault();
            }
        }

        public EmployeeDegree Degree
        {
            get
            {
                return EmployeeDegrees.OrderBy(empD => empD.Degree.DegreeOrder).LastOrDefault();
            }
        }

        public string EmployeeGender
        {
            get
            {
                if (this.SexBit)
                    return "Мужской";
                else
                    return "Женский"; 
            }
        }

        public override string ToString()
        {
            return this.LastName + " " + this.FirstName + " " + this.Otch;
        }


        #region partial Methods
        partial void OnCreated()
        {
            RayonKoeff = 30;
            SeverKoeff = 50;

        }


        partial void OnValidate(System.Data.Linq.ChangeAction action)
        {
            if ((action == ChangeAction.Insert) || (action == ChangeAction.Update))
            {
                if (Grazd.IsNull()) throw new ArgumentNullException("Гражданство сотрудника.");
                if (SemPol.IsNull()) throw new ArgumentNullException("Семейное положение сотрудника.");
                if ((LastName == null) || (LastName == "")) throw new ArgumentNullException("Фамилия сотрудника.");
                if ((FirstName == null) || (FirstName == "")) throw new ArgumentNullException("Имя сотрудника.");
            }
        }

        partial void OnLoaded()
        {
        }

        #endregion

        #region IDecorable Members

        public object GetDecorator()
        {
            return new EmployeeDecorator(this);
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


        #region Члены IComparable

        public int CompareTo(object obj)
        {
            return EmployeeName.CompareTo(obj.ToString());
        }

        #endregion
    }

    public class NullEmployee : Employee, INull
    {

        private NullEmployee()
        {
            this.id = 0;
        }

        public static readonly NullEmployee Instance = new NullEmployee();

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
