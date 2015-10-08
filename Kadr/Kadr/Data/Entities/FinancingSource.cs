using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Kadr.Data.Common;

namespace Kadr.Data
{
    public partial class FinancingSource : INullable, IComparable
    {
        public override string ToString()
        {
            return this.FinancingSourceName;
        }

        
        static public FinancingSource GetFinancingSourceByName(string FinancingSourceName)
        {
            return Kadr.Controllers.KadrController.Instance.Model.FinancingSources.Where(finS => finS.FinancingSourceName == FinancingSourceName).First();
        }


        #region Члены IComparable

        public int CompareTo(object obj)
        {
            return FinancingSourceName.CompareTo(obj.ToString());
        }

        #endregion
    }

    public class NullFinancingSource : FinancingSource, INull
    {

        private NullFinancingSource()
        {
            this.id = -1;
            FinancingSourceName = "(Не задан)";
        }

        public static readonly NullFinancingSource Instance = new NullFinancingSource();


        public override string ToString()
        {
            return "(Не задан)";
        }

    }

}

