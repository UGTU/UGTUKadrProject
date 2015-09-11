using System.Data.Linq.Mapping;
using Kadr.Data.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Kadr.Data;
using System.Data.Linq;

namespace Kadr.Data
{
    public partial class Event : UIX.Views.IValidatable, INull, IObjectState, IComparable
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
                return FactStaffHistory.FactStaff;
            }
            set
            {
                value = FactStaffHistory.FactStaff;
            }
        }

        #endregion

        public Event(UIX.Commands.ICommandManager CommandManager, FactStaff factStaff)
            : this()
        {
            CommandManager.Execute(new UIX.Commands.GenericPropertyCommand<Event, FactStaff>(this, "FactStaff", factStaff, null), null);
            CommandManager.Execute(new UIX.Commands.GenericPropertyCommand<Event, Prikaz>(this, "Prikaz", NullPrikaz.Instance, null), null);
            CommandManager.Execute(new UIX.Commands.GenericPropertyCommand<Event, DateTime?>(this, "DateBegin", DateTime.Today, null), null);
            CommandManager.Execute(new UIX.Commands.GenericPropertyCommand<Event, DateTime?>(this, "DateEnd", DateTime.Today, null), null);
        }
        
        public override string ToString()
        {
            return string.Format("Приказ {0}  — сотрудник {1}", Prikaz.PrikazFullName, this.FactStaff.Employee.ToString()); ;
        }

        public Event(DateTime? beg, DateTime? end, FactStaff fs)
            : this()
        {
            FactStaff = fs;
            DateBegin = beg;
            DateEnd = end;
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

                if (FactStaff == null || (FactStaff.IsNull())) throw new ArgumentNullException("Сотрудник.");
                if (Prikaz == null || (Prikaz.IsNull())) throw new ArgumentNullException("Приказ.");
                if ((DateEnd != null) && (DateBegin != null))
                    if (DateEnd < DateBegin)
                        throw new ArgumentOutOfRangeException("Дата окончания действия должна быть позже даты начала.");
                    else
                        DateEnd = DateEnd.Value.Date;

                
            }
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
