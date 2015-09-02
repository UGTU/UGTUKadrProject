using System;
using System.Collections.Generic;
using System.Data.Linq;
using System.Linq;
using System.Text;

namespace Kadr.Data
{
    public partial class Award : UIX.Views.IDecorable, UIX.Views.IValidatable, IComparable
    {
     #region partial Methods

       public override string ToString()
        {
            string res ="";

            if (AwardType != null)
                res = string.Format("Награда: {0}", AwardType.Name, Employee.EmployeeSmallName);

            if (EducDocument != null)
                if (EducDocument.DocDate!=null)
            res = string.Format("{0}, выдана {1}",res, EducDocument.DocDate);

            if (Employee != null)
             res = string.Format("{0}, сотрудник: {1}",res, Employee.EmployeeSmallName);
             
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
               if (EducDocument == null) throw new ArgumentNullException("Подтверждающий документ");
               else
               {
                   //if (EducDocument.Organisation == null) throw new ArgumentNullException("Выдавшая организация");
                   if (EducDocument.DocDate > DateTime.Now) throw new ArgumentOutOfRangeException("Дата выдачи не может находиться в будущем");
                   //if ((EducDocument.DocNumber == "") || (EducDocument.DocNumber == null)) throw new ArgumentNullException("Номер документа");
               }

               if (Employee == null) throw new ArgumentNullException("Сотрудник");
               if (AwardType == null) throw new ArgumentNullException("Наименование награды");
               if (AwardLevel == null) throw new ArgumentNullException("Уровень награды");
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
            return new AwardDecorator(this);
        }

        #endregion

        public int CompareTo(object obj)
        {
            return this.ToString().CompareTo(obj.ToString());
        }
    }
}

