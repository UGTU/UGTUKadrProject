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
        public string EmployeeName
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
            return  EmployeeName;
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
                //if ((SexBit == null) ) throw new ArgumentNullException("Пол сотрудника.");
                //if (Prikaz.IsNull()) throw new ArgumentNullException("Приказ в записи штатного расписания.");
                //if (StaffCount <= 0) throw new ArgumentOutOfRangeException("Количество ставок в записи штатного расписания.");
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
