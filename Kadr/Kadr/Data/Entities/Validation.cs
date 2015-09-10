using System;
using System.Collections.Generic;
using System.Data.Linq;
using System.Linq;
using System.Text;

namespace Kadr.Data
{
    public partial class Validation : UIX.Views.IDecorable, UIX.Views.IValidatable, IComparable
    {

        // для временного хранения данных подтверждающего документа
        public DateTime? TDocDate = null;
        public string TSerie = null;
        public string TNumber = null;

         #region partial Methods

       public override string ToString()
        {
            string res = "Аттестация";


            if (Event != null)
            {
                if (Event.FactStaff != null)
                    res = string.Format(" сотрудника {0}", Event.FactStaff.Employee);

                if (Event.Prikaz != null)
                    res = string.Format("{0} по приказу: {1}", res, Event.Prikaz.ToString());
            }

            if (ValidationDecision != null)
            res = string.Format("{0}, решение: {1}",res, ValidationDecision.ToString());
             
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
               if (Event == null) throw new ArgumentNullException("Приказ по сотруднику");

               if (EducDocument != null) 
               {
                   //if (EducDocument.Organisation == null) throw new ArgumentNullException("Выдавшая организация");
                   if (EducDocument.DocDate> DateTime.Now) throw new ArgumentNullException("Дата выдачи не может находиться в будущем");
                   if (EducDocument.DocDate < Event.DateBegin) throw new ArgumentNullException("Дата выдачи не может быть раньше даты аттестации");
               }

               if (Event.Prikaz == null) throw new ArgumentNullException("Приказ");

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
            return new ValidationDecorator(this);
        }

        #endregion

        public int CompareTo(object obj)
        {
            return this.ToString().CompareTo(obj.ToString());
        }
    }
    }
