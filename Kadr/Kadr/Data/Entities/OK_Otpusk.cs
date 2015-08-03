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


        #region partial Methods


        partial void OnValidate(System.Data.Linq.ChangeAction action)
        {
            if ((action == ChangeAction.Insert) || (action == ChangeAction.Update))
            {

                if (FactStaffPrikaz.IsNull() || FactStaffPrikaz == null) throw new ArgumentNullException("Приказ.");
                if ((OK_Otpuskvid == null) || (OK_Otpuskvid.IsNull())) throw new ArgumentNullException("Вид отпуска.");
                if (RealDateEnd != null)
                    if (RealDateEnd < RealDateBegin)
                        throw new ArgumentOutOfRangeException("Дата окончания отпуска должна быть позже даты его начала.");
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
