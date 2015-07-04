using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Kadr.Data.Common;
using Kadr.Controllers;
using System.Data.Linq;

namespace Kadr.Data
{
    public partial class Degree : IComparable, INull
    {

        public override string ToString()
        {

            return this.DegreeName;
        }


        public int CompareTo(object obj)
        {
            return (DegreeOrder.CompareTo((obj as Degree).DegreeOrder));
        }

        bool INull.IsNull()
        {
            return false;
        }
    }


    public class NullDegree : Degree, INull
    {

        private NullDegree()
        {
            this.id = 0;
        }

        public static readonly NullDegree Instance = new NullDegree();

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
