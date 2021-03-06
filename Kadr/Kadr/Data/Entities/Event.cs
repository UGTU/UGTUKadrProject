﻿using System.Data.Linq.Mapping;
using Kadr.Data.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Kadr.Data;
using System.Data.Linq;
using Kadr.Controllers;

namespace Kadr.Data
{
    public partial class Event : UIX.Views.IValidatable, INullable, IObjectState, IComparable
    {
        #region Properties

        public Prikaz PrikazEnd
        {
            get { return Prikaz1; }
            set { Prikaz1 = value; }
        }

        public FactStaff FactStaff
        {
            get
            {
                if (FactStaffHistory != null)
                return FactStaffHistory.FactStaff;
                else
                    return null;
            }
            set
            {
                if (FactStaffHistory != null)
                value = FactStaffHistory.FactStaff;
            }
        }

        #endregion

        public Event(UIX.Commands.ICommandManager CommandManager, FactStaffHistory factStaffHistory, EventKind eventKind = null, EventType eventType = null, bool WithContract = false, Prikaz prikaz = null, DateTime? dateEnd = null)
            : this()
        {
            CommandManager.Execute(new UIX.Commands.GenericPropertyCommand<Event, FactStaffHistory>(this, "FactStaffHistory", factStaffHistory, null), null);
            CommandManager.Execute(new UIX.Commands.GenericPropertyCommand<Event, Prikaz>(this, "Prikaz", prikaz?? NullPrikaz.Instance, null), null);
            CommandManager.Execute(new UIX.Commands.GenericPropertyCommand<Event, EventKind>(this, "EventKind", eventKind, null), null);
            CommandManager.Execute(
                            new UIX.Commands.GenericPropertyCommand<Event, EventType>(this, "EventType", eventType, null), this);
            CommandManager.Execute(new UIX.Commands.GenericPropertyCommand<Event, DateTime?>(this, "DateBegin", DateTime.Today, null), null);
            CommandManager.Execute(new UIX.Commands.GenericPropertyCommand<Event, DateTime?>(this, "DateEnd", dateEnd, null), null);

            if (WithContract) 
            {
                new Contract(CommandManager, this, eventKind.ForFactStaff ? factStaffHistory.GlobalMainContract : null, "", DateTime.Today.Date, DateTime.Today.Date);
            }
        }
        
        public override string ToString()
        {
            return string.Format("Приказ {0}  — сотрудник {1}", Prikaz.PrikazFullName, this.FactStaff.Employee.ToString()); ;
        }

        
        #region partial Methods


        /// <summary>
        /// Проверка всех параметров перед сохранением
        /// </summary>
        /// <param name="action"></param>
        partial void OnValidate(System.Data.Linq.ChangeAction action)
        {
            if ((action == ChangeAction.Insert) || (action == ChangeAction.Update))
            {

                if (FactStaffHistory == null ) throw new ArgumentNullException("Сотрудник.");
                if (EventKind == null)
                    throw new ArgumentNullException("Тип события.");
                //if (Prikaz == null || (Prikaz.IsNull())) throw new ArgumentNullException("Приказ.");
                if ((DateEnd != null) && (DateBegin != null))
                    if (DateEnd < DateBegin)
                        throw new ArgumentOutOfRangeException("Дата окончания действия должна быть позже даты начала.");
                    else
                        DateEnd = DateEnd.Value.Date;

                //если не создается изменение, а редактируется
                if (FactStaffHistory.id != 0)
                    FactStaffHistory = FactStaff.GetHistoryForDate(DateBegin);

                if (Contract != null)
                {
                    (Contract as UIX.Views.IValidatable).Validate();
                }

                
                if (EventKind.ForFactStaff)
                {
                    DateBegin = FactStaffHistory.DateBegin;
                    Prikaz = FactStaffHistory.Prikaz;
                }

                if (Prikaz.IsNull())
                    Prikaz = null;
            }

            /*if (action == ChangeAction.Insert)
            {
                if ((EventKind == Kadr.Controllers.MagicNumberController.FactStaffCreateEventKind) && (Contract != null))
                {
                    Prikaz ContractPrikaz = CRUDPrikaz.Create(Contract.ContractName, Kadr.Controllers.MagicNumberController.ContractPrikazType, Contract.DateContract, Contract.DateBegin, Contract.DateEnd);
                    if ((ContractPrikaz != null) && (FactStaffHistory != null))
                    {
                        FactStaff currentFactStaff = FactStaffHistory.FactStaff;
                        if (!(currentFactStaff.idlaborcontrakt > 0))
                            currentFactStaff.idlaborcontrakt = ContractPrikaz.id;
                        else
                            FactStaffHistory.idlaborcontrakt = ContractPrikaz.id;
                    }
                }
            }*/

        }

        #endregion


        #region IValidatable Members

        void UIX.Views.IValidatable.Validate()
        {
            OnValidate(ChangeAction.Insert);
        }

        #endregion



        #region IObjectState Members

        ObjectState IObjectState.State()
        {
            //TODO: статус приказа по персоналу должен определяться тем, есть ли отменяющий его приказ
                return ObjectState.Current;

        }

        #endregion

        public int CompareTo(object obj)
        {
            return this.ToString().CompareTo(obj.ToString());
        }
         
    }
}
