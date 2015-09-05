using System;
using System.Collections.Generic;
using System.Data.Linq;
using System.Linq;
using System.Text;


namespace Kadr.Data
{
    public partial class MaterialResponsibility : UIX.Views.IDecorable, UIX.Views.IValidatable
    {
       /* public MaterialResponsibility(UIX.Commands.ICommandManager commandManager, FactStaff fsStaff)
            : this()
        {
            commandManager.Execute(new UIX.Commands.GenericPropertyCommand<MaterialResponsibility, FactStaff>(this, "FactStaff", fsStaff, null), this);
        }*/

        public override string ToString()
        {
            return "Запись по материальной ответственности " + FactStaffPrikaz.FactStaff;
        }

        #region Properties

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

        public Prikaz PrikazBegin
        {
            get { return FactStaffPrikaz.Prikaz; }
            set { if (value != null) FactStaffPrikaz.Prikaz = value; }
        }

        public string ContractName
        {
            get { return Contract.ContractName; }
            set { Contract.ContractName = value; }
        }

        public DateTime DateContract
        {
            get
            {
                return Contract.DateContract != null ? Contract.DateContract.Value : DateTime.MinValue;
            }
            set { Contract.DateContract = value; }
        }

        public Prikaz PrikazEnd
        {
            get { return FactStaffPrikaz.PrikazEnd; }
            set { FactStaffPrikaz.PrikazEnd = value; }
        }

        public FactStaff FactStaff
        {
            get { return FactStaffPrikaz.FactStaff; }
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

            if (FactStaffPrikaz.idPrikaz == 0) throw new ArgumentNullException("Приказ назначения ответственности.");
            if ((Contract.ContractName == null) || (Contract.ContractName.Trim() == "")) throw new ArgumentNullException("Номер договора.");
            if (Contract.DateContract == null) throw new ArgumentNullException("Дата договора.");
            if (FactStaffPrikaz.DateBegin == null) throw new ArgumentNullException("Дата начала действия.");
            if (FactStaffPrikaz.PrikazEnd != null)
                if (FactStaffPrikaz.DateEnd == null) throw new ArgumentNullException("Дата окончания ответственности.");
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
