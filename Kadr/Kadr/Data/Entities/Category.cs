using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Kadr.Data.Common;
using Kadr.Controllers;
using System.Data.Linq;

namespace Kadr.Data
{
    public partial class Category : INull, IComparable
    {
        public override string ToString()
        {
            return this.CategorySmallName;
        }

     public static Category PPSCategory
        {
            get
            {
                return KadrController.Instance.Model.Categories.Where(cat => cat.id == 2).FirstOrDefault();
            }
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
                if (CategoryName == null) throw new ArgumentNullException("Название категории.");
                if (CategorySmallName == null)
                    throw new ArgumentNullException("Краткое название категории.");
            }
        }

        #endregion


        #region INull Members

        bool INull.IsNull()
        {
            return false;

        }

        #endregion

        #region Члены IComparable

        public int CompareTo(object obj)
        {
            return CategoryName.CompareTo(obj.ToString());
        }

        #endregion
    }

    public class NullCategory : Category, INull
    {

        private NullCategory()
        {
            this.id = 0;
        }

        public static readonly NullCategory Instance = new NullCategory();

        #region INull Members

        bool INull.IsNull()
        {
            return true;
        }
        public override string ToString()
        {
            return "(Не задана)";
        }

        #endregion
    }
}
