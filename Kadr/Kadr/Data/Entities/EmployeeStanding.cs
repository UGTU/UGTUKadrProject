using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Kadr.Data
{
    public partial class EmployeeStanding : UIX.Views.IDecorable
    {
        public override string ToString()
        {
            return this.Post +" ("+ this.WorkPlace+") ";
        }

        #region IDecorable Members

        public object GetDecorator()
        {
            return new EmployeeStandingDecorator(this);
        }


        #endregion
    }
}
