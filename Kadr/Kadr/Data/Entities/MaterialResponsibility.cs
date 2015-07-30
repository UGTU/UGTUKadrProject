using System;
using System.Collections.Generic;
using System.Data.Linq;
using System.Linq;
using System.Text;


namespace Kadr.Data
{
    public partial class MaterialResponsibility : UIX.Views.IDecorable, UIX.Views.IValidatable
    {
        public override string ToString()
        {
            return "Запись по материальной ответственности " + FactStaffPrikaz.FactStaff;
        }

        #region Properties

        public Kadr.Data.Prikaz Prikaz
        {
            get
            {
                return FactStaffPrikaz.Prikaz;
            }
            set
            {
                if (value != null) FactStaffPrikaz.Prikaz = value;
            }
        }

        public DateTime? DateBegin
        {
            get
            {
                return FactStaffPrikaz.DateBegin; 
            }
            set
            {
                FactStaffPrikaz.DateBegin = value;
            }
        }

        public DateTime? DateEnd
        {
            get
            {
                return FactStaffPrikaz.DateEnd;
            }
            set
            {
                FactStaffPrikaz.DateEnd = value;
         
            }
        }

        public string ContractName
        {
            get
            {
                return Contract.ContractName;
            }
            set
            {
                Contract.ContractName = value;
            }
        }

        public DateTime? DateContract
        {
            get
            {
                return Contract.DateContract;
            }
            set
            {
                Contract.DateContract = value;
            }
        }

        #endregion

        #region partial Methods

        /// <summary>
        /// Проверка всех параметров перед сохранением
        /// </summary>
        /// <param name="action"></param>
        partial void OnValidate(ChangeAction action)
        {
            if ((action != ChangeAction.Insert) && (action != ChangeAction.Update)) return;

            if (FactStaffPrikaz == null) throw new ArgumentNullException("Приказ.");
            if ((Contract.ContractName == null) || (Contract.ContractName.Trim()=="")) throw new ArgumentNullException("Номер договора.");
            if (Contract.DateContract == null) throw new ArgumentNullException("Дата договора.");
            if (FactStaffPrikaz.DateBegin == null) throw new ArgumentNullException("Дата начала действия.");
            if (FactStaffPrikaz.DateEnd == DateTime.MinValue)
                FactStaffPrikaz.DateEnd = null;
            if  (FactStaffPrikaz.DateEnd == null) return;
            if (FactStaffPrikaz.DateEnd <= FactStaffPrikaz.DateBegin)
                throw new ArgumentOutOfRangeException("Дата окончания ответственности должна быть позже даты начала.");
        }

        #endregion

        public void Validate()
        {
            OnValidate(ChangeAction.Insert);
        }

        public object GetDecorator()
        {
            return new MaterialResponsibilityDecorator(this);
        }
    }
}
