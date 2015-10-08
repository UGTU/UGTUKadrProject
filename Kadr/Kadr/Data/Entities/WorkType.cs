using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Kadr.Data.Common;
using Kadr.Controllers;

namespace Kadr.Data
{
    public partial class WorkType : INullable, IComparable
    {
        /// <summary>
        /// возвращает вид работы "почасовики"
        /// </summary>
        public static WorkType hourWorkType
        {
            get
            {
                return KadrController.Instance.Model.WorkTypes.Where(wt => wt.id == 19).FirstOrDefault();
            }
        }

        /// <summary>
        /// возвращает основной вид работы
        /// </summary>
        static public WorkType MainWorkType
        {
            get
            {
                return Kadr.Controllers.KadrController.Instance.Model.WorkTypes.Where(wt => wt.id == 1).First();
            }
        }
        
        public override string ToString()
        {
            return this.TypeWorkShortName;
        }


        #region Члены IComparable

        public int CompareTo(object obj)
        {
            return TypeWorkName.CompareTo(obj.ToString());
        }

        #endregion
    }

    public class NullWorkType : WorkType, INull
    {

        private NullWorkType()
        {
            this.id = 0;
        }

        public static readonly NullWorkType Instance = new NullWorkType();

        public override string ToString()
        {
            return "(Не задан)";
        }
    }

}
