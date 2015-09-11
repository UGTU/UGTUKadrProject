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
            return "Запись по материальной ответственности " + Event.FactStaff;
        }

        #region Properties

        public DateTime? DateBegin
        {
            get
            {
                return Event.DateBegin; 
            }
            set
            {
                Event.DateBegin = value;
            }
        }

        public DateTime? DateEnd
        {
            get
            {
                return Event.DateEnd;
            }
            set
            {
                Event.DateEnd = value;
         
            }
        }

        public Prikaz PrikazBegin
        {
            get { return Event.Prikaz; }
            set { if (value != null) Event.Prikaz = value; }
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
            get { return Event.PrikazEnd; }
            set { Event.PrikazEnd = value; }
        }

        public FactStaff FactStaff
        {
            get { return Event.FactStaff; }
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

            if (Event.idPrikaz == 0) throw new ArgumentNullException("Приказ назначения ответственности.");
            if ((Contract.ContractName == null) || (Contract.ContractName.Trim() == "")) throw new ArgumentNullException("Номер договора.");
            if (Contract.DateContract == null) throw new ArgumentNullException("Дата договора.");
            if (Event.DateBegin == null) throw new ArgumentNullException("Дата начала действия.");
            if (Event.PrikazEnd != null)
                if (Event.DateEnd == null) throw new ArgumentNullException("Дата окончания ответственности.");
            if (Event.DateEnd == DateTime.MinValue)
                Event.DateEnd = null;
            if  (Event.DateEnd == null) return;
            if (Event.DateEnd <= Event.DateBegin)
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
