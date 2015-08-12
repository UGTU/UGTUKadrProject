using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Kadr.Data.Common;

namespace Kadr.Data
{
    partial class SocialFareTransit : UIX.Views.IDecorable, INull
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

        #region Члены INull

        bool INull.IsNull()
        {
            return false;
        }

        #endregion

        
    }

    public class NullSocialFareTransit : SocialFareTransit, INull
    {

        private NullSocialFareTransit()
        {
            this.id = 0;
        }

        public static readonly NullSocialFareTransit Instance = new NullSocialFareTransit();

        #region INull Members

        bool INull.IsNull()
        {
            return true;
        }

        public override string ToString()
        {
            return "(Не задан)";
        }

        #endregion
    }
}
