using Kadr.Data.Common;
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
            /*
            if ((action == ChangeAction.Insert) || (action == ChangeAction.Update))
            {
                if ((PlanStaff == null) && (HourCount == null)) throw new ArgumentNullException("Элемент штатного расписания.");
                if ((Dep == null) && (HourCount > 0)) throw new ArgumentNullException("Отдел для почасовика.");

                if (MainFactStaff != null)
                    if (MainFactStaff.IsNull())
                        MainFactStaff = null;

                if (Employee != null)
                    if (Employee.IsNull())
                        Employee = null;
                if (Employee == null && (MainFactStaff == null)) throw new ArgumentNullException("Сотрудник.");
                if (WorkType.IsNull()) throw new ArgumentNullException("Вид работы.");
                if (PrikazBegin != null)
                {
                    if (((PrikazBegin.IsNull())) && !IsHourStaff) throw new ArgumentNullException("Приказ назначения.");
                    if (PrikazBegin.IsNull() && IsHourStaff)
                        PrikazBegin = null;
                }
                if (this.DateBegin == null)
                    throw new ArgumentNullException("Дата назначения на работу.");
                if ((StaffCount < 0) && (HourCount == null)) throw new ArgumentOutOfRangeException("Количество ставок.");
                if (DateEnd == DateTime.MinValue)
                    DateEnd = null;
                if (DateEnd != null)
                    if (DateEnd <= DateBegin)
                        throw new ArgumentOutOfRangeException("Дата увольнения должна быть позже даты назначения.");
                    else
                        DateEnd = DateEnd.Value.Date;

                if ((Prikaz != null) && (DateEnd == null))
                    throw new ArgumentNullException("Дата увольнения, так как указан приказ об увольнении.");
                if ((Prikaz == null) && (DateEnd != null) && !IsHourStaff) //для почасовиков приказ необязателен
                    throw new ArgumentNullException("Приказ об увольнении, так как указана дата увольнения.");
                if (FundingCenter != null)
                    if (FundingCenter.IsNull())
                        FundingCenter = null;
                if (OKVED != null)
                    if (OKVED.IsNull())
                        OKVED = null;
            }*/
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
