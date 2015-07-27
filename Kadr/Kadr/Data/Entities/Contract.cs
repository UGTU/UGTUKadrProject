using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Kadr.Data.Common;
using Kadr.Controllers;
using System.Data.Linq;

namespace Kadr.Data
{
    public partial class Contract : INull, UIX.Views.IDecorable, UIX.Views.IValidatable
    {


        public bool IsNull()
        {
            throw new NotImplementedException();
        }

        public object GetDecorator()
        {
            throw new NotImplementedException();
        }

        public void Validate()
        {
            throw new NotImplementedException();
        }
    }
}
