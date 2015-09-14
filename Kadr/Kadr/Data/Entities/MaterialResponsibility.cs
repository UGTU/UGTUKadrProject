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
            return "Запись по материальной ответственности " + Event_MaterialResponsibilities.FirstOrDefault().Event.FactStaff;
        }

        #region Properties

        public DateTime? DateBegin
        {
            get
            {
                return Event_MaterialResponsibilities.FirstOrDefault().Event.DateBegin; 
            }
            set
            {
                Event_MaterialResponsibilities.FirstOrDefault().Event.DateBegin = value;
            }
        }

        public DateTime? DateEnd
        {
            get
            {
                return Event_MaterialResponsibilities.FirstOrDefault().Event.DateEnd;
            }
            set
            {
                Event_MaterialResponsibilities.FirstOrDefault().Event.DateEnd = value;
         
            }
        }

        public Prikaz PrikazBegin
        {
            get { return Event_MaterialResponsibilities.FirstOrDefault().Event.Prikaz; }
            set { if (value != null) Event_MaterialResponsibilities.FirstOrDefault().Event.Prikaz = value; }
        }

        public string ContractName
        {
            get { return Event_MaterialResponsibilities.FirstOrDefault().Event.Contract.ContractName; }
            set { Event_MaterialResponsibilities.FirstOrDefault().Event.Contract.ContractName = value; }
        }

        public DateTime DateContract
        {
            get
            {
                return Event_MaterialResponsibilities.FirstOrDefault().Event.Contract.DateContract != null ? Event_MaterialResponsibilities.FirstOrDefault().Event.Contract.DateContract.Value : DateTime.MinValue;
            }
            set { Event_MaterialResponsibilities.FirstOrDefault().Event.Contract.DateContract = value; }
        }

        public Prikaz PrikazEnd
        {
            get { return Event_MaterialResponsibilities.FirstOrDefault().Event.PrikazEnd; }
            set { Event_MaterialResponsibilities.FirstOrDefault().Event.PrikazEnd = value; }
        }

        public FactStaff FactStaff
        {
            get { return Event_MaterialResponsibilities.FirstOrDefault().Event.FactStaff; }
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

            if (Event_MaterialResponsibilities.FirstOrDefault().Event.idPrikaz == 0) throw new ArgumentNullException("Приказ назначения ответственности.");
            if ((Event_MaterialResponsibilities.FirstOrDefault().Event.Contract.ContractName == null) || (Event_MaterialResponsibilities.FirstOrDefault().Event.Contract.ContractName.Trim() == "")) throw new ArgumentNullException("Номер договора.");
            if (Event_MaterialResponsibilities.FirstOrDefault().Event.Contract.DateContract == null) throw new ArgumentNullException("Дата договора.");
            if (Event_MaterialResponsibilities.FirstOrDefault().Event.DateBegin == null) throw new ArgumentNullException("Дата начала действия.");
            if (Event_MaterialResponsibilities.FirstOrDefault().Event.PrikazEnd != null)
                if (Event_MaterialResponsibilities.FirstOrDefault().Event.DateEnd == null) throw new ArgumentNullException("Дата окончания ответственности.");
            if (Event_MaterialResponsibilities.FirstOrDefault().Event.DateEnd == DateTime.MinValue)
                Event_MaterialResponsibilities.FirstOrDefault().Event.DateEnd = null;
            if (Event_MaterialResponsibilities.FirstOrDefault().Event.DateEnd == null) return;
            if (Event_MaterialResponsibilities.FirstOrDefault().Event.DateEnd <= Event_MaterialResponsibilities.FirstOrDefault().Event.DateBegin)
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
