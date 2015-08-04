using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Kadr.Data.Common;

namespace Kadr.Data
{
    public partial class OK_Educ : UIX.Views.IDecorable, UIX.Views.IValidatable, INull, IComparable
    {
        public override string ToString()
        {
            if ((EducDocumentType == null) || (Spec == null)) return "";
            try
            {
                return EducDocumentType.DocTypeName + " " + Spec;
            }
            catch (InvalidOperationException)
            {
                return "";
            }
        }

        #region IDecorable Members

        public object GetDecorator()
        {
            return new OkEducDecorator(this);
        }

        #endregion

        public void Validate()
        {
            throw new NotImplementedException();
        }

        public bool IsNull()
        {
            throw new NotImplementedException();
        }

        public int CompareTo(object obj)
        {
            throw new NotImplementedException();
        }
    }
}
