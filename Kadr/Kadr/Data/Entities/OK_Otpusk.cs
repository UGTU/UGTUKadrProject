using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Kadr.Data
{
    public partial class OK_Otpusk : UIX.Views.IDecorable
    {
        public override string ToString()
        {
            return "Отпуск " + FactStaff;
        }

        #region IDecorable Members

        public object GetDecorator()
        {
            return new OK_OtpuskDecorator(this);
        }


        #endregion
    }
}
