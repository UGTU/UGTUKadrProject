using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Kadr.Data
{
    partial class SocialFareTransit : UIX.Views.IDecorable
    {
        public override string ToString()
        {
            return "Льготный проезд " + Employee.EmployeeSmallName + " c " + DateBegin.ToShortDateString() + " по " + DateEnd.ToShortDateString();
        }


        #region Члены IDecorable

        public object GetDecorator()
        {
            return new SocialFareTransitDecorator(this);
        }

        #endregion
    }
}
