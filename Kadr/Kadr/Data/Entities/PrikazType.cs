using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Kadr.Data.Common;


namespace Kadr.Data
{
    public partial class PrikazType :  INullable, IComparable
    {
        public override string ToString()
        {
            return this.PrikazTypeName;
        }

        #region Члены IComparable

        public int CompareTo(object obj)
        {
            return PrikazTypeName.CompareTo(obj.ToString());
        }

        #endregion
    }

    public class NullPrikazType : PrikazType, INull
    {

        private NullPrikazType()
        {
            this.id = 0;
            //this.PrikazLongName = "(Не задан)";
        }

        public static readonly NullPrikazType Instance = new NullPrikazType();



        public override string ToString()
        {
            return "(Не задан)";
        }

    }

}
