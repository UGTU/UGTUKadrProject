using System;
using System.Collections.Generic;
using System.Data.Linq;
using System.Linq;
using System.Text;

namespace Kadr.Data
{
    public partial class OK_EmployeeLang : UIX.Views.IDecorable, UIX.Views.IValidatable, IComparable
    {
        #region partial Methods

        public override string ToString()
        {   
            var res = string.Format("Язык: {0}", OK_Language.languagename);

            if (LanguageLevel != null)
                res = string.Format("{0}, степень владения: {1}.", res, LanguageLevel.LevelName);

            return res;
        }

        public string Level
        {
            get
            {
                if (LanguageLevel != null) return (LanguageLevel.GoodBit ? "Да" : "Нет");
                return (goodlevelbit ? "Да" : "Нет");
            }
        }

        public int CompareTo(object obj)
        {
            return this.ToString().CompareTo(obj.ToString());
        }

        /// <summary>
        /// Проверка всех параметров перед сохранением
        /// </summary>
        /// <param name="action"></param>
        partial void OnValidate(System.Data.Linq.ChangeAction action)
        {
            if ((action == ChangeAction.Insert) || (action == ChangeAction.Update))
            {
                if (EducDocument != null) 
                {
                    if (EducDocument.DocDate > DateTime.Now) throw new ArgumentNullException("Дата выдачи не должна превышать текущую дату");
                }
                if (Employee == null) throw new ArgumentNullException("Сотрудник");
                if (OK_Language == null) throw new ArgumentNullException("Название языка");
            }
        }

        #endregion

        public object GetDecorator()
        {
            return new EmployeeLangDecorator(this);
        }

        void UIX.Views.IValidatable.Validate()
        {
            OnValidate(ChangeAction.Insert);
        }
    }
}
