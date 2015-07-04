using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace UIX.Actions
{
    public interface IAddObject
    {
        //void InitializeNewObject(object mainObject);
        void CopyTo(object target);
        void Clear();
    }
}
