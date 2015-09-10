using Kadr.Data;
using Kadr.UI.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Kadr.Controllers
{
    

    public static class CRUDBusinessTrips
    {
        public static void Create(FactStaff fs, BindingSource BusinessTripsBindingSource, object sender)
        {
            using (PropertyGridDialogAdding<BusinessTrip> dlg =
               SimpleActionsProvider.NewSimpleObjectAddingDialog<BusinessTrip>())
            {

                    BusinessTripRegionType btrt = new BusinessTripRegionType(DateTime.Now.Date, DateTime.Now.AddDays(7).Date, KadrController.Instance.Model.RegionTypes.First());

                    dlg.InitializeNewObject = (x) =>
                    {
                        dlg.CommandManager.Execute(new UIX.Commands.GenericPropertyCommand<BusinessTripRegionType, BusinessTrip>(btrt, "BusinessTrip", x, null), sender);
                        dlg.CommandManager.Execute(new UIX.Commands.GenericPropertyCommand<BusinessTrip, Event>(x, "Event", new Event(DateTime.Now.Date, DateTime.Now.AddDays(7).Date, fs), null), sender);
                        dlg.CommandManager.Execute(new UIX.Commands.GenericPropertyCommand<BusinessTrip, string>(x, "TripTargetPlace", "", null), sender);
                        dlg.CommandManager.Execute(new UIX.Commands.GenericPropertyCommand<BusinessTrip, FinancingSource>(x, "FinancingSource", KadrController.Instance.Model.FinancingSources.FirstOrDefault(), null), sender);
                        //dlg.CommandManager.Execute(new UIX.Commands.GenericPropertyCommand<BusinessTrip, string>(x, "FinancingSource", KadrController.Instance.Model.FinancingSources.First(), null), this);
                    };

                    dlg.UpdateObjectList = () =>
                    {
                        dlg.ObjectList = KadrController.Instance.Model.BusinessTrips;
                    };

                    dlg.ShowDialog();
                }

            Read(fs, BusinessTripsBindingSource);
        }

        public static void Read(FactStaff fs, BindingSource BusinessTripsBindingSource)
        {
            BusinessTripsBindingSource.DataSource = KadrController.Instance.Model.BusinessTrips.Where(t => t.Event.FactStaff == fs).Select(x => x.GetDecorator()).ToList();
        }

        public static void Update(FactStaff fs, BindingSource BusinessTripsBindingSource)
        {
            if (BusinessTripsBindingSource.Current != null)
                LinqActionsController<BusinessTrip>.Instance.EditObject(
                        (BusinessTripsBindingSource.Current as BusinessTripDecorator).GetTrip(), true);
            Read(fs, BusinessTripsBindingSource);
        }

        public static void Delete(FactStaff fs, BindingSource BusinessTripsBindingSource)
        {
            if (BusinessTripsBindingSource.Current == null)
                MessageBox.Show("Не выбрана командировка!");
            else
            if (MessageBox.Show(string.Format("Вы уверены, что хотите удалить '{0}'?", (BusinessTripsBindingSource.Current as BusinessTripDecorator).ToString()), "Подтверждение", MessageBoxButtons.OKCancel) == DialogResult.OK)
            {
                BusinessTrip bt = (BusinessTripsBindingSource.Current as BusinessTripDecorator).GetTrip();

                foreach (BusinessTripRegionType rt in bt.BusinessTripRegionTypes)
                    KadrController.Instance.Model.BusinessTripRegionTypes.DeleteOnSubmit(rt);

                KadrController.Instance.Model.BusinessTrips.DeleteOnSubmit(bt);
                KadrController.Instance.Model.Events.DeleteOnSubmit(bt.Event);
                KadrController.Instance.Model.SubmitChanges();
            }
            Read(fs, BusinessTripsBindingSource);
        }
    }
}
