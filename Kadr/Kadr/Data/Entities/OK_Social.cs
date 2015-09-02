using System;
using System.Collections.Generic;
using System.Data.Linq;
using System.Linq;
using System.Text;

namespace Kadr.Data
{
    public partial class OK_Social : Common.CompareObject, UIX.Views.IDecorable, UIX.Views.IValidatable
    {
        #region partial Methods

        public override string ToString()
        {
            string res = "";

            if (OK_SocialStatus != null)
                res = string.Format("Cотрудник: {1}, cоциальный статус: {0}", OK_SocialStatus.SocialStatusName, Employee.EmployeeSmallName);

            return res;
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
                    //if (EducDocument.DocDate==null) throw new ArgumentNullException("Дата выдачи документа");
                    //if (EducDocument.Organisation == null) throw new ArgumentNullException("Выдавшая организация");
                    if (EducDocument.DocDate != null)
                    if (EducDocument.DocDate > DateTime.Now) throw new ArgumentOutOfRangeException("Дата выдачи документа не может находиться в будущем");
                    //if ((EducDocument.DocNumber == "") || (EducDocument.DocNumber == null)) throw new ArgumentNullException("Номер документа");
                }

                if (Employee == null) throw new ArgumentNullException("Сотрудник");
                if (OK_SocialStatus == null) throw new ArgumentNullException("Социальный статус");
            }
        }

        #endregion

        #region IValidatable Members

        void UIX.Views.IValidatable.Validate()
        {
            OnValidate(ChangeAction.Insert);
        }

        #endregion

        #region IDecorable Members

        public object GetDecorator()
        {
            return new SocialDecorator(this);
        }

        #endregion

        /*public int CompareTo(object obj)
        {
            return this.ToString().CompareTo(obj.ToString());
        }*/
    }
}
