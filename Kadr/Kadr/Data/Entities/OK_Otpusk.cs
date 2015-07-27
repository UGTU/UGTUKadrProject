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
            return "Отпуск " + RealFactStaff;
        }

        public Prikaz RealPrikaz
        {
            get
            {
                return FactStaffPrikaz.Prikaz;
            }
            set
            {
                FactStaffPrikaz.Prikaz = value;
            }
        }

        public FactStaff RealFactStaff
        {
            get
            {
                return FactStaffPrikaz.FactStaff;
            }
            set
            {
                FactStaffPrikaz.FactStaff = value;
            }
        }

        public DateTime? RealDateBegin
        {
            get
            {
                return FactStaffPrikaz.DateBegin;
            }
            set
            {
                FactStaffPrikaz.DateBegin = value;
            }
        }

        public DateTime? RealDateEnd
        {
            get
            {
                return FactStaffPrikaz.DateEnd;
            }
            set
            {
                FactStaffPrikaz.DateEnd = value;
            }
        }
        
        #region IDecorable Members

        public object GetDecorator()
        {
            return new OK_OtpuskDecorator(this);
        }


        #endregion
    }
}
