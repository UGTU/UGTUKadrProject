﻿using Kadr.Data.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Kadr.Data;
using System.Data.Linq;

namespace Kadr.Data
{
    public partial class FactStaffPrikaz : UIX.Views.IValidatable, INull, IObjectState, IComparable
    {
        #region Properties

        #endregion

        public static FactStaffPrikaz CreateFactStaffPrikaz(UIX.Commands.ICommandManager CommandManager, FactStaff factStaff)
        {
            FactStaffPrikaz factStaffPrikaz = new Data.FactStaffPrikaz();
            CommandManager.Execute(new UIX.Commands.GenericPropertyCommand<FactStaffPrikaz, FactStaff>(factStaffPrikaz, "FactStaff", factStaff, null), null);
            CommandManager.Execute(new UIX.Commands.GenericPropertyCommand<FactStaffPrikaz, Prikaz>(factStaffPrikaz, "Prikaz", NullPrikaz.Instance, null), null);
            CommandManager.Execute(new UIX.Commands.GenericPropertyCommand<FactStaffPrikaz, DateTime?>(factStaffPrikaz, "DateBegin", DateTime.Today, null), null);
            CommandManager.Execute(new UIX.Commands.GenericPropertyCommand<FactStaffPrikaz, DateTime?>(factStaffPrikaz, "DateEnd", DateTime.Today, null), null);
            return factStaffPrikaz;
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

                if (FactStaff == null || (FactStaff.IsNull())) throw new ArgumentNullException("Сотрудник.");
                if (Prikaz == null || (Prikaz.IsNull())) throw new ArgumentNullException("Приказ.");
                if ((DateEnd != null) && (DateBegin != null))
                    if (DateEnd <= DateBegin)
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
