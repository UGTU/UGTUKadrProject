using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Kadr.Data.Common;

namespace Kadr.Data
{
    partial class SocialFareTransit : UIX.Views.IDecorable, INullable
    {
        /// <summary>
        /// продолжительность периода льготного проезда
        /// </summary>
        public const int SocialFareLength = 2;

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

    public class NullSocialFareTransit : SocialFareTransit, INull
    {

        private NullSocialFareTransit()
        {
            this.id = 0;
        }

        public static readonly NullSocialFareTransit Instance = new NullSocialFareTransit();
        public override string ToString()
        {
            return "(Не задан)";
        }

    }
}
