using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Kadr.Data.Common;

namespace Kadr.Data
{
    public partial class Grazd : INullable, IComparable
    {
        public override string ToString()
        {
            return this.grazdName;
        }

        static public Grazd DefaultGrazd
        {
            get
            {
                return Kadr.Controllers.KadrController.Instance.Model.Grazds.Where(finS => finS.id == 2).First();
            }
        }


        public int CompareTo(object obj)
        {
            return grazdName.CompareTo(obj.ToString());
        }
    }

    public class NullGrazd : Grazd, INull
    {

        private NullGrazd()
        {
            this.id = 0;
        }

        public static readonly NullGrazd Instance = new NullGrazd();


        public override string ToString()
        {
            return "(Не заданo)";
        }

    }
}
