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

        public static void Update(BusinessTrip bt)
        {
            /*
            if (BusinessTripsBindingSource.Current != null)
                LinqActionsController<BusinessTripRegionType>.Instance.EditObject(
                        (BusinessTripsBindingSource.Current as BusinessTripDecorator).GetRegionType(), true);
             */
            using (Kadr.UI.Dialogs.TripRegionsDialog dlg = new Kadr.UI.Dialogs.TripRegionsDialog(bt)) 
            {
                //dlg.Text = "График работы";
                //dlg.QueryText = "Выберите график работы";
                //dlg.DataSource =
                //    Kadr.Controllers.KadrController.Instance.Model.WorkShedules.OrderBy(wShed => wShed.NameShedule);
                //dlg.SelectedValue = (Kadr.Data.WorkShedule)value;

                dlg.ShowDialog();
                    
            }
            
           
        }

        public static void Delete()
        {

        }
    }
}
