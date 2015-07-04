using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Kadr.Data.Common;
using Kadr.Controllers;
using System.Data.Linq;

namespace Kadr.Data
{
    public partial class Rank : INull, IComparable
    {
        public override string ToString()
        {
            return RankName;
        }

        public string SmallName
        {
            get
            {
                return RankName;
            }
        }

        bool INull.IsNull()
        {
            return false;
        }

        #region Члены IComparable

        public int CompareTo(object obj)
        {
            return (this.RankOrder.CompareTo((obj as Rank).RankOrder));
        }

        #endregion
    }

    public class NullRank : Rank, INull
    {

        private NullRank()
        {
            this.id = 0;
        }

        public static readonly NullRank Instance = new NullRank();

        #region INull Members

        bool INull.IsNull()
        {
            return true;
        }

        public override string ToString()
        {
            return "(Не заданo)";
        }

        #endregion
    }
}
