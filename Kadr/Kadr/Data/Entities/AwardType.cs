using Kadr.Data.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Kadr.Data
{
    public partial class AwardType: IComparable, INullable
    {
        public override string ToString()
        {
            return this.Name;
        }

        public int CompareTo(object obj)
        {
            return this.ToString().CompareTo(obj.ToString());
        }

    }

    public class NullAwardType : AwardType, INull
    {

        private NullAwardType()
        {
            this.Name = "(Не задан)";
            //this.PrikazLongName = "(Не задан)";
        }

        public static readonly NullAwardType Instance = new NullAwardType();

        public override string ToString()
        {
            return "(Не задан)";
        }


    }
}
