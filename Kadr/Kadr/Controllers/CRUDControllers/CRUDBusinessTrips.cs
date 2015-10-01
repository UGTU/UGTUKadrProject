using Kadr.Data;
using Kadr.UI.Common;
using Kadr.UI.Dialogs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using UIX.Commands;

namespace Kadr.Controllers
{
    

    public static class CRUDBusinessTrips
    {
        public static void Create(FactStaff fs, BindingSource BusinessTripsBindingSource, object sender)
        {
            using (PropertyGridDialogAdding<BusinessTrip> dlg =
               SimpleActionsProvider.NewSimpleObjectAddingDialog<BusinessTrip>())
            {
                    
                    dlg.InitializeNewObject = (x) =>
                    {
                        new BusinessTripRegionType(dlg.CommandManager, x, DateTime.Now.Date, DateTime.Now.Date, KadrController.Instance.Model.RegionTypes.First());
                        //new Event_BusinessTrip(dlg.CommandManager, fs.CurrentChange, MagicNumberController.BeginEventType, x, null, DateTime.Today);
                        dlg.CommandManager.Execute(new UIX.Commands.GenericPropertyCommand<BusinessTrip, string>(x, "TripTargetPlace", "", null), sender);
                        dlg.CommandManager.Execute(new UIX.Commands.GenericPropertyCommand<BusinessTrip, FinancingSource>(x, "FinancingSource", 
                            KadrController.Instance.Model.FinancingSources.FirstOrDefault(), null), sender);
                       
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
            BusinessTripsBindingSource.DataSource = KadrController.Instance.Model.FactStaffHistories.Where(t => t.FactStaff == fs).SelectMany(x => x.Events).Where(x=>x.idPrikazEnd==null).Select(x => x.Event_BusinessTrip).Where(t=>t!=null).Select(t=>t.BusinessTrip).Distinct().Select(x => x.GetDecorator()).ToList();
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

                foreach (Event_BusinessTrip e in bt.Event_BusinessTrips)
                    KadrController.Instance.Model.Event_BusinessTrips.DeleteOnSubmit(e);

                KadrController.Instance.Model.BusinessTrips.DeleteOnSubmit(bt);
                
                KadrController.Instance.Model.Events.DeleteOnSubmit(bt.Event);
                KadrController.Instance.Model.SubmitChanges();
            }
            Read(fs, BusinessTripsBindingSource);
        }

        public static void CancelTrip(BindingSource BusinessTripsBindingSource)
        {
            using (PrikazSelectionDialog dlg = new PrikazSelectionDialog(MagicNumberController.BusinessTripPrikazType))
            {
                dlg.Text = "Приказ отмены командировки";

                if (dlg.ShowDialog() == DialogResult.OK)
                {
                    (BusinessTripsBindingSource.Current as BusinessTripDecorator).CancelTrip((Prikaz)dlg.DialogObject);
                    KadrController.Instance.Model.SubmitChanges();
                }

            }

        }

        public static void TripChangeDates(FactStaffHistory fsh, BindingSource BusinessTripsBindingSource)
        {
            /*using (PrikazSelectionDialog dlg = new PrikazSelectionDialog(MagicNumberController.BusinessTripPrikazType))
            {
                dlg.Text = "Приказ изменения сроков командировки";

                if (dlg.ShowDialog() == DialogResult.OK)
                {
                    BusinessTripDecorator dec = (BusinessTripDecorator)BusinessTripsBindingSource.Current;
                    
                    using (DatesRangeDialog dlgdates = new DatesRangeDialog(dec.DateBegin, dec.DateEnd))
                    {
                        dlgdates.Text = "Новые сроки командировки";
                        if (dlgdates.ShowDialog() == DialogResult.OK)
                        {
                            ICommandManager CM = new UIX.Commands.CommandManager();

                            CM.BeginBatchCommand();

                            Event_BusinessTrip ebt = new Event_BusinessTrip(CM, fsh, MagicNumberController.ChangeTermsEventType, dec.GetTrip(), null, null);
                            CM.Execute(new UIX.Commands.GenericPropertyCommand<Event, Prikaz>(ebt.Event, "Prikaz", (Prikaz)dlg.DialogObject, null), null);
                            CM.Execute(new UIX.Commands.GenericPropertyCommand<Event, Event>(ebt.Event, "Event1", dec.GetTrip().Event, null), null);
                            (BusinessTripsBindingSource.Current as BusinessTripDecorator).ChangeDates(dlgdates.dBegin.Value, dlgdates.dEnd.Value);

                            CM.EndBatchCommand();
                            KadrController.Instance.Model.SubmitChanges();
                        }
                    }
                }

            }*/
        }
    }
}
