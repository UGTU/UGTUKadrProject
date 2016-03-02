using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Linq;
using Kadr.Controllers;
using Kadr.Data.Common;

namespace Kadr.Data
{
    partial class FactStaffHistory : UIX.Views.IDecorable, UIX.Views.IValidatable, IEmployeeExperienceRecord
    {

        public EventKind CreatingEventKind
        {
            get;
            set;
        }


        /// <summary>
        /// используется для перевода
        /// </summary>
        public FactStaff transferPrevFactStaff
        {
            get;
            set;
        }

        public FactStaffHistory(UIX.Commands.ICommandManager CommandManager, FactStaff factStaff, WorkType workType, Prikaz prikaz, DateTime dateBegin, EventKind eventKind, EventType eventType, bool withContract = false)
            : this()
        {
            //x.SetProperties(dlg.CommandManager, currentFactStaff, currentFactStaff.WorkType, NullPrikaz.Instance, DateTime.Today.Date, eventKind, eventType, withContract);
            SetProperties(CommandManager, factStaff, workType, prikaz, dateBegin, eventKind, eventType, withContract, null);
        }


        public void SetProperties(UIX.Commands.ICommandManager CommandManager, FactStaff factStaff, WorkType workType, Prikaz prikaz, DateTime dateBegin, EventKind eventKind, EventType eventType, bool withContract = false, FactStaff prevFactStaff = null)
        {
            //если уже есть изменение, то берем львинную долю свойств оттуда
            if (factStaff.CurrentChange != null)
            {
                CommandManager.Execute(new UIX.Commands.GenericPropertyCommand<FactStaffHistory, decimal>(this, "StaffCount", factStaff.StaffCount, null), this);
                CommandManager.Execute(new UIX.Commands.GenericPropertyCommand<FactStaffHistory, decimal?>(this, "HourCount", factStaff.HourCount, null), this);
                CommandManager.Execute(new UIX.Commands.GenericPropertyCommand<FactStaffHistory, decimal?>(this, "HourSalary", factStaff.HourSalary, null), this);
                CommandManager.Execute(new UIX.Commands.GenericPropertyCommand<FactStaffHistory, SalaryKoeff>(this, "SalaryKoeff", factStaff.SalaryKoeff, null), this);
            }

            FinancingSource financingSource = null;
            if (eventKind == MagicNumberController.FactStaffFinSourceChangeEventKind)
                financingSource = factStaff.LastChange.FinancingSource;
            if (eventKind == MagicNumberController.FactStaffHourCreateEventKind)
                financingSource = MagicNumberController.budgetFinancingSource;

            CommandManager.Execute(new UIX.Commands.GenericPropertyCommand<FactStaffHistory, FinancingSource>(this, "FinancingSource", financingSource, null), null);
            CommandManager.Execute(new UIX.Commands.GenericPropertyCommand<FactStaffHistory, EventKind>(this, "CreatingEventKind", eventKind, null), null);
            CommandManager.Execute(new UIX.Commands.GenericPropertyCommand<FactStaffHistory, Prikaz>(this, "Prikaz", prikaz, null), null);
            CommandManager.Execute(new UIX.Commands.GenericPropertyCommand<FactStaffHistory, WorkType>(this, "WorkType", workType, null), null);
            CommandManager.Execute(new UIX.Commands.GenericPropertyCommand<FactStaffHistory, DateTime>(this, "DateBegin", dateBegin, null), null);
            CommandManager.Execute(new UIX.Commands.GenericPropertyCommand<FactStaffHistory, FactStaff>(this, "FactStaff", factStaff, null), null);

            //если это перевод, то заносим соответствующие данные
            if (eventKind == MagicNumberController.FactStaffTransferEventKind)
            {
                CommandManager.Execute(new UIX.Commands.GenericPropertyCommand<FactStaffHistory, FactStaff>(this, "transferPrevFactStaff", prevFactStaff, null), null);
                //CommandManager.Execute(new UIX.Commands.GenericPropertyCommand<FactStaffHistory, FactStaff>(this, "transferPrevFactStaff", transferPrevFactStaff, null), null);
            }

            Event = new Event(CommandManager, this, eventKind, eventType, (eventKind.ForFactStaff) && (eventKind.WithContract.Value), prikaz);
        }

        public override string ToString()
        {
            return "Изменение " + FactStaff.ToString();
        }



        public bool IsLatest
        {
            get
            {
                if (this == FactStaff.FactStaffHistories.OrderBy(fcStHist => fcStHist.DateBegin).LastOrDefault())
                    return true;
                else
                    return false;
            }
        }

        #region EventContractData 





        public Contract GlobalMainContract
        {
            get
            {
                if (transferPrevFactStaff != null)
                    return transferPrevFactStaff.GlobalMainContract;
                if (FactStaff != null)
                    return FactStaff.GlobalMainContract;
                return null;
            }

        }


        /*/// <summary>
        /// Событие назначения этого изменения
        /// </summary>
        public Event MainEvent
        {
            get
            {
                return Events.Where(x => x.EventKind != null).Where(x => x.EventKind.ForFactStaff).FirstOrDefault();
            }
        }*/

        /// <summary>
        /// Событие назначения этого изменения
        /// </summary>
        private Event currentEvent;

        /// <summary>
        /// Связанное событие 
        /// </summary>
        public Event Event
        {
            get
            {
                if (currentEvent == null)
                {
                    currentEvent = Events.Where(x => x.EventKind != null).Where(x => x.EventKind.ForFactStaff).FirstOrDefault();
                }
                return currentEvent;
            }
            set
            {
                currentEvent = value;
            }
        }

        public Contract Contract => Event.Contract;

        /// <summary>
        /// устанавливает даты начала контрактов
        /// </summary>
        /// <param name="value"></param>
        public void SetContractDates(DateTime value)
        {
            if (Contract != null)
            {
                if ((Contract.DateContract == null) || (Contract.DateContract == DateTime.MinValue) || (Contract.DateContract.Value.Date == DateTime.Today.Date))
                {
                    Contract.DateBegin = value;
                    Contract.DateContract = value;
                }
            }
        }

        /// <summary>
        /// Тип события
        /// </summary>
        public EventKind EventKind
        {
            get
            {
                if (Event != null)
                    return Event.EventKind;
                return null;
            }
            set
            {
                if (Event != null)
                    Event.EventKind = value;
            }
        }
        #endregion

        #region partial Methods
        partial void OnCreated()
        {
            DateBegin = DateTime.Today;
            StaffCount = 1;
        }



        /// <summary>
        /// Проверка всех параметров перед сохранением
        /// </summary>
        /// <param name="action"></param>
        partial void OnValidate(System.Data.Linq.ChangeAction action)
        {
            if ((action == ChangeAction.Insert) || (action == ChangeAction.Update))
            {
                if (WorkType == null)
                    throw new ArgumentNullException("Прежний вид работы.");
                if ((HourCount != null) && (FactStaff.idDepartment != null) && (FactStaff.idFinancingSource != null))
                {
                    HourStaffCount =
                        Kadr.Controllers.KadrController.Instance.Model.GetStaffCountForHour(FactStaff.idDepartment, FactStaff.idFinancingSource,
                                                                                            HourCount).GetValueOrDefault();
                    if ((HourStaffCount <= 0) || (HourStaffCount == null))
                        throw new Exception("Занесите нормы времени для отдела.");
                    if (Prikaz != null)
                        if ((Prikaz as INullable).IsNull() && FactStaff.IsHourStaff)
                            Prikaz = null;
                }
                else
                {
                    if ((Prikaz as Kadr.Data.Common.INullable).IsNull() && !FactStaff.IsHourStaff)
                        throw new ArgumentNullException("Приказ назначения.");
                }

                if ((StaffCount <= 0) || (StaffCount == null))
                    throw new ArgumentOutOfRangeException("Количество ставок.");
                if (DateBegin == null)
                    throw new ArgumentNullException("Дата изменения.");


                if (Event != null)
                    (Event as UIX.Views.IValidatable).Validate();

                if (SalaryKoeff != null)
                    if (SalaryKoeff.IsNull())
                        SalaryKoeff = null;

                if (transferPrevFactStaff != null)
                {
                    transferPrevFactStaff.Prikaz = Prikaz;
                    transferPrevFactStaff.DateEnd = DateBegin.AddDays(-1);
                    transferPrevFactStaff.OK_Reason = MagicNumberController.TransferReason;
                    TransferConnectedData();
                }
                //проверка на переполнение штатов на начало периода
                /*decimal factStaffCount = Kadr.Controllers.KadrController.Instance.Model.GetFactStaffByPeriod(DateBegin, DateBegin).Where(fcSt => fcSt.idPlanStaff == FactStaff.idPlanStaff).Sum(fcSt => fcSt.StaffCount);
                decimal planStaffCount = Kadr.Controllers.KadrController.Instance.Model*/
            }
        }

        /// <summary>
        /// переводит все данные на новую должность
        /// </summary>
        private void TransferConnectedData()
        {
            FactStaff.DoTransferConnectedData(transferPrevFactStaff);
        }

        #endregion

        public object GetDecorator()
        {
            if (CreatingEventKind != null)
                if (CreatingEventKind.DecoratorName != null && CreatingEventKind.DecoratorName != "")
                {
                    Type DecoratorType = Type.GetType(CreatingEventKind.DecoratorName);
                    if (DecoratorType != null)
                    {
                        System.Reflection.ConstructorInfo constructor = DecoratorType.GetConstructor(new Type[] { (Type.GetType("Kadr.Data.FactStaffHistory")) });
                        if (constructor != null)
                            return constructor.Invoke(new Object[] { this });
                    }
                }
            if (FactStaff.IsReplacement)
                return new FactStaffHistoryReplacementDecorator(this);
            if (FactStaff.IsHourStaff)
                return new FactStaffHistoryHourDecorator(this);
            return new FactStaffHistoryDecorator(this);
        }

        #region IValidatable Members

        void UIX.Views.IValidatable.Validate()
        {
            OnValidate(ChangeAction.Insert);
        }
        #endregion

        #region Implementation of IRange<DateTime>

        public DateTime Start
        {
            get { return DateBegin; }
            set { }
        }
        public DateTime Stop
        {
            get { return FactStaff.Stop; }
            set { }
        }

        #endregion

        #region Implementation of IEmployeeExperienceRecord

        /// <summary>
        /// Признак того, что этот стаж имеет дату завершения
        /// </summary>
        public bool IsEnded => FactStaff.IsEnded;

        /// <summary>
        /// Получает территориальные условия работы
        /// </summary>
        public TerritoryConditions Territory => (RegionType
                                                 ?? FactStaff.Department?.CurrentRegionType
                                                 ?? RegionType.Default).GetTerritoryCondition();

        /// <summary>
        /// Получает вид стажа
        /// </summary>
        public KindOfExperience Experience => FactStaff.Experience;

        /// <summary>
        /// Получает принадлежность стажа организации
        /// </summary>
        public Affilations Affilation => FactStaff.Affilation;

        /// <summary>
        /// Получает тип стажа в организации
        /// </summary>
        public WorkOrganizationWorkType WorkWorkType => FactStaff.WorkWorkType;

        #endregion
    }
}
