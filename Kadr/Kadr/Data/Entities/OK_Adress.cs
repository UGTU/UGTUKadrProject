using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Kadr.Data
{
    partial class OK_Adress : UIX.Views.IDecorable
    {
        public override string ToString()
        {
            return "Адрес " + Employee.EmployeeSmallName;
        }


        #region Члены IDecorable

        public object GetDecorator()
        {
            return new OK_AdressDecorator(this);
        }

        #endregion
    }
}