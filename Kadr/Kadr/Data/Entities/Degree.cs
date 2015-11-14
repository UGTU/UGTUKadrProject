using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Kadr.Data.Common;
using Kadr.Controllers;
using System.Data.Linq;

namespace Kadr.Data
{
    public partial class Degree : IComparable, INullable
    {

        public override string ToString()
        {

            return this.DegreeName;
        }


        public int CompareTo(object obj)
        {
            return (DegreeOrder.CompareTo((obj as Degree).DegreeOrder));
        }

    }


    public class NullDegree : Degree, INull
    {

        private NullDegree()
        {
            this.id = 0;
        }

        public static readonly NullDegree Instance = new NullDegree();


        public override string ToString()
        {
            return "(Не задана)";
        }


    }

}
