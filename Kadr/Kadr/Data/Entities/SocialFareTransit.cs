using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Kadr.Data
{
    partial class SocialFareTransit
    {
        public override string ToString()
        {
            return "Льготный проезд "+Employee+" c "+DateBegin.ToString()+" по "+DateEnd.ToString();
        }
    }
}
