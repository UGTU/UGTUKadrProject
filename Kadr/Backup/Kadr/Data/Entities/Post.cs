using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Kadr.Data.Common;
using System.Data.Linq;

namespace Kadr.Data
{
    public partial class Post : INull, UIX.Views.IDecorable, UIX.Views.IValidatable, IComparable
    {
        public override string ToString()
        {
            return this.PostName;
        }

        #region partial Methods

        partial void OnCreated()
        {
            PostName = "Новая должность";
        }

        /// <summary>
        /// Проверка всех параметров перед сохранением
        /// </summary>
        /// <param name="action"></param>
        partial void OnValidate(System.Data.Linq.ChangeAction action)
        {
            if ((action == ChangeAction.Insert) || (action == ChangeAction.Update))
            {
                if ((action == ChangeAction.Insert) || (action == ChangeAction.Update))
                {
                    if (PKCategory.IsNull()) throw new ArgumentNullException("Профессиональная категория.");
                    if (GlobalPrikaz.IsNull()) throw new ArgumentNullException("Приказ министерства.");

                }


            }
        }

        #endregion



        #region INull Members

        bool INull.IsNull()
        {
            return false;
        }

        #endregion

        #region Члены IDecorable

        public object GetDecorator()
        {
            return new PostDecorator(this);
        }

        #endregion

        #region Члены IValidatable

        void UIX.Views.IValidatable.Validate()
        {
            OnValidate(ChangeAction.Insert);
        }

        #endregion

        #region Члены IComparable

        public int CompareTo(object obj)
        {
            return PostName.CompareTo(obj.ToString());
        }

        #endregion
    }

    public class NullPost : Post, INull
    {

        private NullPost()
        {
            this.id = 0;
        }

        public static readonly NullPost Instance = new NullPost();

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
