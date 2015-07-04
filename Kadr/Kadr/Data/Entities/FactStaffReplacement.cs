using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Kadr.Data.Common;
using Kadr.Controllers;
using System.Data.Linq;
using UIX.Views;

namespace Kadr.Data
{
    public partial class FactStaffReplacement : INull, UIX.Views.IDecorable, UIX.Views.IValidatable, IComparable
    {
        public override string ToString()
        {
            return "";
        }
        
        bool INull.IsNull()
        {
            return false;
        }

        public FactStaff ReplacedFactStaff
        {
            get
            {
                return FactStaff1;
            }
            set
            {
                FactStaff1 = value;
            }
        }

        public FactStaff MainFactStaff
        {
            get
            {
                return FactStaff;
            }
            set
            {
                FactStaff = value;
            }
        }

        public decimal ReplacedPercent
        {
            get
            {
                return MainFactStaff.StaffCount * 100 / ReplacedFactStaff.StaffCount;
            }
            set
            {
                MainFactStaff.StaffCount = ReplacedFactStaff.StaffCount *
                    value / 100;
            }
        }

        #region partial Methods

        partial void OnCreated()
        {
        }



        /// <summary>
        /// Проверка всех параметров перед сохранением
        /// </summary>
        /// <param name="action"></param>
        partial void OnValidate(System.Data.Linq.ChangeAction action)
        {
            if ((action == ChangeAction.Insert) || (action == ChangeAction.Update))
            {
                if (MainFactStaff.IsNull())
                    throw new ArgumentNullException("Совмещающий сотрудник.");
                if (ReplacedFactStaff.IsNull())
                    throw new ArgumentNullException("Совмещаемый сотрудник.");
                if (FactStaffReplacementReason.IsNull())
                    throw new ArgumentNullException("Причина совмещения.");
                (MainFactStaff as IValidatable).Validate();
                if (DateEnd == DateTime.MinValue)
                    DateEnd = null;

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
            return new FactStaffReplacementDecorator(this);
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
            return (this.ToString().CompareTo(obj.ToString()));
        }

        #endregion
    }

    public class NullFactStaffReplacement : FactStaffReplacement, INull
    {

        private NullFactStaffReplacement()
        {
            
        }

        public static readonly NullFactStaffReplacement Instance = new NullFactStaffReplacement();

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
