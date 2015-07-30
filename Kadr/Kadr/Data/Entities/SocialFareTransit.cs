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


        public bool IsUsed
        {
            get
            {
                return (Kadr.Controllers.KadrController.Instance.Model.OK_Otpusks.Where(otp => otp.SocialFareTransit == this).Count()==1);
            }
        }

        #region Члены IDecorable

        public object GetDecorator()
        {
            return new SocialFareTransitDecorator(this);
        }

        #endregion
    }
}
