using Kadr.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Kadr.Controllers
{
    public static class CRUDBusinessRegionType
    {
        public static void Create()
        {

        }

        public static void Read()
        {
        }

        public static void Update(BindingSource BusinessTripsBindingSource)
        {
            if (BusinessTripsBindingSource.Current != null)
                LinqActionsController<BusinessTripRegionType>.Instance.EditObject(
                        (BusinessTripsBindingSource.Current as BusinessTripDecorator).GetRegionType(), true);
        }

        public static void Delete()
        {

        }
    }
}
