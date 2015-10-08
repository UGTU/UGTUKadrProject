using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Kadr.Data.Common;
using Kadr.Controllers;
using System.Data.Linq;
using UIX.Views;

namespace Kadr.Data
{
    public partial class PostGroup : INullable
    {
        public override string ToString()
        {
            return GroupName;
        }
    }


    public class NullPostGroup : PostGroup, INull
    {

        private NullPostGroup()
        {
            this.id = 0;
        }

        public static readonly NullPostGroup Instance = new NullPostGroup();


        public override string ToString()
        {
            return "(Не задана)";
        }

    }
}
