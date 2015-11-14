using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Kadr.Data.Common;

namespace Kadr.Data
{
    public partial class SemPol : CompareObject, INullable//, IComparable
    {
        public override string ToString()
        {
            return this.sempolName;
        }

        static public SemPol DefaultSemPol
        {
            get
            {
                return Kadr.Controllers.KadrController.Instance.Model.SemPols.Where(semP => semP.id == 1).First();
            }
        }

        /*public int CompareTo(object obj)
        {
            return ToString().CompareTo(obj.ToString());
        }*/
    }

    public class NullSemPol : SemPol, INull
    {

        private NullSemPol()
        {
            this.id = 0;
        }

        public static readonly NullSemPol Instance = new NullSemPol();


        public override string ToString()
        {
            return "(Не заданo)";
        }

    }
}

