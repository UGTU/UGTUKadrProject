using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace Kadr.Data
{
    public partial class MaterialResponsibility : UIX.Views.IDecorable
    {
        public override string ToString()
        {
            return "Запись по материальной ответственности " + FactStaffPrikaz.FactStaff;
        }

        public object GetDecorator()
        {
            return new MaterialResponsibilityDecorator(this);
        }
    }
}
