using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Linq;

namespace Kadr.Data
{
    partial class FactStaffHistory : UIX.Views.IDecorable, UIX.Views.IValidatable
    {

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
                        if ((Prikaz as Kadr.Data.Common.INull).IsNull() && FactStaff.IsHourStaff)
                            Prikaz = null;
                }
                else
                {
                    if ((Prikaz as Kadr.Data.Common.INull).IsNull()  && !FactStaff.IsHourStaff)
                        throw new ArgumentNullException("Приказ изменения.");
                }
                if ((StaffCount <= 0) || (StaffCount == null)) 
                    throw new ArgumentOutOfRangeException("Количество ставок.");
                if (DateBegin == null) 
                    throw new ArgumentNullException("Дата изменения.");

                //проверка на переполнение штатов на начало периода
                /*decimal factStaffCount = Kadr.Controllers.KadrController.Instance.Model.GetFactStaffByPeriod(DateBegin, DateBegin).Where(fcSt => fcSt.idPlanStaff == FactStaff.idPlanStaff).Sum(fcSt => fcSt.StaffCount);
                decimal planStaffCount = Kadr.Controllers.KadrController.Instance.Model*/
            }
         }
        #endregion

        public object GetDecorator()
        {
            if (FactStaff.IsReplacement)
                return new FactStaffHistoryReplacementDecorator(this);
            return new FactStaffHistoryDecorator(this);
        }

        #region IValidatable Members

        void UIX.Views.IValidatable.Validate()
        {
            OnValidate(ChangeAction.Insert);
        }
        #endregion

    }
}
