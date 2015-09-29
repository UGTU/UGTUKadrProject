using System;
using System.Collections.Generic;
using System.Data.Linq;
using System.Linq;
using System.Text;

namespace Kadr.Data
{
    public partial class OK_DopEducation : UIX.Views.IDecorable, UIX.Views.IValidatable, IComparable
    {
        #region partial Methods

        public override string ToString()
        {
            return DopEducType.DopEducName + (DopEducType.Duration != "" ? " (" + DopEducType.Duration + " часов)" : "");
        }

        public FactStaff FactStaff { get; set; }

        public Prikaz Prikaz
        {
            get { return (Event != null) ? Event.Prikaz : TempPrikaz; }
            set
            {
                if (Event != null) Event.Prikaz = value;
                else TempPrikaz = value;
                
            }
        }

        public Prikaz TempPrikaz { get; set; }

        /// <summary>
        /// Проверка всех параметров перед сохранением
        /// </summary>
        /// <param name="action"></param>
        partial void OnValidate(System.Data.Linq.ChangeAction action)
        {
            if ((action == ChangeAction.Insert) || (action == ChangeAction.Update))
            {
                if (DopEducType == null) throw new ArgumentNullException("Тип повыщения квалификации");
                if (EducDocument != null)
                {
                    if (EducDocument.DocDate > DateTime.Now) throw new ArgumentNullException("Дата выдачи не должна превышать текущую дату");
                }
                if (Employee == null) throw new ArgumentNullException("Сотрудник");
                if ((DateBegin != null)&&(DateEnd != null))
                if (DateEnd <= DateBegin)
                    throw new ArgumentOutOfRangeException("Дата окончания обучения должна быть позже даты начала.");
            }
        }

        #endregion

        public object GetDecorator()
        {
            return new DopEducationDecorator(this);
        }

        public void Validate()
        {
            OnValidate(ChangeAction.Insert);
        }

        public int CompareTo(object obj)
        {
            return ToString().CompareTo(obj.ToString());
        }
    }
}
