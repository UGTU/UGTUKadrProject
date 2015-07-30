using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Kadr.Data
{
    partial class OK_phone : UIX.Views.IDecorable
    {
        public override string ToString()
        {
            return "Номер телефона " + Employee.EmployeeSmallName;
        }


        #region Члены IDecorable

        public object GetDecorator()
        {
            return new OK_phoneDecorator(this);
        }

        #endregion
    }
}
