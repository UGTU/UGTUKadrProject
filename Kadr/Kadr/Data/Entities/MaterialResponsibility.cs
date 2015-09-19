using System;
using System.Collections.Generic;
using System.Data.Linq;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Text;
using Kadr.Controllers;


namespace Kadr.Data
{
    public partial class MaterialResponsibility : UIX.Views.IDecorable, UIX.Views.IValidatable
    {
        public MaterialResponsibility(UIX.Commands.ICommandManager commandManager, FactStaff fsStaff)
            : this()
        {
            commandManager.Execute(new UIX.Commands.GenericPropertyCommand<MaterialResponsibility, FactStaff>(this, "FactStaff", fsStaff, null), this);

        }

        public override string ToString()
        {
            return "Запись по материальной ответственности " + MainEvent.FactStaff;
        }

        #region Properties

        public Event MainEvent
        {
            get
            {
                return (Event_MaterialResponsibilities != null)
                    ? Event_MaterialResponsibilities.Single(
                        x => x.Event.EventType == MagicNumberController.BeginEventType).Event
                    : null;
            }
        }

        public Event EndEvent
        {
            get
            {
                return (Event_MaterialResponsibilities != null)
                    ? Event_MaterialResponsibilities.Single(
                        x => x.Event.EventType == MagicNumberController.EndEventType).Event
                    : null;
            }
        }

        public DateTime DateBegin
        {
            get { return (DateTime) MainEvent.DateBegin; }
            set { MainEvent.DateBegin = value; }
        }

        public DateTime? DateEnd
        {
            get { return (EndEvent != null) ? EndEvent.DateBegin : MainEvent.DateEnd; }
            set
            {
                if (EndEvent != null) EndEvent.DateBegin = value;
                else MainEvent.DateEnd = value;
            }
        }

        public Prikaz PrikazBegin
        {
            get { return MainEvent.Prikaz; }
            set { MainEvent.Prikaz = value; }
        }

        public string ContractName
        {
            get { return MainEvent.Contract.ContractName; }
            set { MainEvent.Contract.ContractName = value; }
        }

        public DateTime DateContract
        {
            get { return MainEvent.Contract.DateContract ?? DateTime.MinValue; }
            set { MainEvent.Contract.DateContract = value; }
        }

        public Prikaz TempPrikazEnd { get; set; }

        public Prikaz PrikazEnd
        {
            get { return (EndEvent != null) ? EndEvent.Prikaz : TempPrikazEnd; }
            set
            {
                if (EndEvent != null) EndEvent.Prikaz = null;
                else TempPrikazEnd = value;
            }
        }

        public FactStaff FactStaff
        {
            get { return MainEvent.FactStaff; }
        }

        public decimal SumMoney
        {
            get
            {
                if (Perc != null)
                    Sum =
                        Decimal.Round(
                            (decimal)
                                ((Perc / 100) *
                                 (Convert.ToDecimal(FactStaff.PlanStaff.SalarySize) *
                                  FactStaff.LastChange.StaffCount)), 2);
                return Sum;
            }
            set
            {
                Sum = value;
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

            if (MainEvent.idPrikaz == 0) throw new ArgumentNullException("Приказ назначения ответственности.");
            if ((MainEvent.Contract.ContractName == null) || (MainEvent.Contract.ContractName.Trim() == "")) throw new ArgumentNullException("Номер договора.");
            if (MainEvent.Contract.DateContract == null) throw new ArgumentNullException("Дата договора.");
            if (MainEvent.DateBegin == null) throw new ArgumentNullException("Дата начала действия.");
            if (PrikazEnd != null)
                if (DateEnd == null) throw new ArgumentNullException("Дата окончания ответственности.");
            if (DateEnd <= DateBegin)
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
