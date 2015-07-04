using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Kadr.Data.Common;
using Kadr.Controllers;
using System.Data.Linq;

namespace Kadr.Data
{
    public partial class OKVED : INull
    {
        public override string ToString()
        {
            return OKVEDName;
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
                 if (OKVEDName == null)
                    throw new ArgumentNullException("Название ОКВЕД.");
            }
        }

        #endregion

        #region INull Members

        bool INull.IsNull()
        {
            return false;

        }

        #endregion
    }

    public class NullOKVED : OKVED, INull
    {

        private NullOKVED()
        {
            this.id = 0;
        }

        public static readonly NullOKVED Instance = new NullOKVED();

        #region INull Members

        bool INull.IsNull()
        {
            return true;
        }
        public override string ToString()
        {
            return "(Не задан)";
        }

        #endregion
    }
}
