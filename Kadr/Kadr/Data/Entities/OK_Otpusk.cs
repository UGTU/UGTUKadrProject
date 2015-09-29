using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Linq;
using Kadr.Data.Common;

namespace Kadr.Data
{
    public partial class OK_Otpusk : UIX.Views.IDecorable, UIX.Views.IValidatable
    {
        public override string ToString()
        {
            return "Отпуск " + RealFactStaff;
        }

        public Prikaz RealPrikaz
        {
            get
            {
                return Event.Prikaz;
            }
            set
            {
                Event.Prikaz = value;
            }
        }

        public FactStaff RealFactStaff
        {
            get
            {
                return Event.FactStaff;
            }
            set
            {
                Event.FactStaff = value;
            }
        }

        public DateTime? RealDateBegin
        {
            get
            {
                return Event.DateBegin;
            }
            set
            {
                Event.DateBegin = value;
            }
        }

        public DateTime? RealDateEnd
        {
            get
            {
                return Event.DateEnd;
            }
            set
            {
                Event.DateEnd = value;
            }
        }

        public bool WithSocialFareTransit
        {
            get
            {
                return SocialFareTransit != null;
            }
        }

        public Prikaz PrikazLgot
        {
            get { return (SocialFareTransit.Event != null) ? SocialFareTransit.Event.Prikaz : null; }
        }

        #region IDecorable Members

        public object GetDecorator()
        {
            return new OK_OtpuskDecorator(this);
        }


        #endregion


        #region partial Methods


        partial void OnValidate(System.Data.Linq.ChangeAction action)
        {
            if ((action == ChangeAction.Insert) || (action == ChangeAction.Update))
            {
                if (SocialFareTransit != null)
                    if (SocialFareTransit.IsNull())
                        SocialFareTransit = null;
                if (Event.IsNull() || Event == null) throw new ArgumentNullException("Приказ.");
                if ((OK_Otpuskvid == null) || (OK_Otpuskvid.IsNull())) throw new ArgumentNullException("Вид отпуска.");
                if ((OK_Otpuskvid == null) || (OK_Otpuskvid.IsNull())) throw new ArgumentNullException("Вид отпуска.");
                if ((RealDateBegin == null) || (RealDateBegin == DateTime.MinValue)) throw new ArgumentNullException("Дата начала отпуска.");
                if ((RealDateEnd == null) || (RealDateEnd == DateTime.MinValue)) throw new ArgumentNullException("Дата окончания отпуска.");
                if (RealDateEnd != null)
                    if (RealDateEnd < RealDateBegin)
                        throw new ArgumentOutOfRangeException("Дата окончания отпуска должна быть позже даты его начала.");
                DateBegin = RealDateBegin;
                DateEnd = RealDateEnd;
            }
        }


        #endregion


        #region IValidatable Members

        void UIX.Views.IValidatable.Validate()
        {
            OnValidate(ChangeAction.Insert);
        }

        #endregion
    }
}
