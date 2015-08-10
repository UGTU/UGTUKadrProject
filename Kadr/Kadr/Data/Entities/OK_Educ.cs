using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Kadr.Data.Common;

namespace Kadr.Data
{
    public partial class OK_Educ : UIX.Views.IDecorable, UIX.Views.IValidatable, INull, IComparable
    {
       

        #region IDecorable Members

        public object GetDecorator()
        {
            return new EducationDecorator(this);
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
