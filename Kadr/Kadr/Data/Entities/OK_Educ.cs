﻿using System;
using System.Collections.Generic;
using System.Data.Linq;
using System.Linq;
using System.Text;
using Kadr.Data.Common;

namespace Kadr.Data
{
    public partial class OK_Educ : UIX.Views.IDecorable, UIX.Views.IValidatable, INull, IComparable
    {
       #region partial Methods

        public override string ToString()
        {
            var res = "";
            if (EducationType != null)
                res = string.Format("Тип: {0}", EducationType.EduTypeName);
            if (EducDocument != null)
            {
                if (EducDocument.DocDate != null)
                    res = string.Format("{0}, дата: {1}", res, EducDocument.DocDate.Value.Date);
            }
            else res = string.Format("{0}, {1}, {2} год", res, EducWhere, EducWhen);
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
                if (EducationType == null) throw new ArgumentNullException("Вид образования");
                if (EducDocument != null) 
                {
                    if (EducDocument.DocDate > DateTime.Now) throw new ArgumentNullException("Дата выдачи не должна превышать текущую дату");
                }

                if (Employee == null) throw new ArgumentNullException("Сотрудник");
                if (EducationType == null) throw new ArgumentNullException("Тип образования");
            }
        }

       #endregion

        #region IDecorable Members

        public object GetDecorator()
        {
            return new EducationDecorator(this);
        }

        #endregion

        public void Validate()
        {
            throw new NotImplementedException();
        }

        public bool IsNull()
        {
            throw new NotImplementedException();
        }

        public int CompareTo(object obj)
        {
            throw new NotImplementedException();
        }
    }
}
