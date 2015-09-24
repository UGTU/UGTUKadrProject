using Kadr.Data;
using Kadr.UI.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using UIX.Commands;

namespace Kadr.Controllers
{
    public static class CRUDMaterial
    {
        public static void Create(FactStaff fs, BindingSource MaterialResponsibilitybindingSource, object sender)
        {
            using (var dlg =
               SimpleActionsProvider.NewSimpleObjectAddingDialog<MaterialResponsibility>())
            {
                    dlg.InitializeNewObject = (x) =>
                    {
                        var EventMat = new Event_MaterialResponsibility(dlg.CommandManager,fs, MagicNumberController.BeginEventType);
                        dlg.CommandManager.Execute(
                            new GenericPropertyCommand<Event_MaterialResponsibility, MaterialResponsibility>(EventMat, "MaterialResponsibility",
                                x, null), sender);
                        dlg.CommandManager.Execute(
                            new GenericPropertyCommand<MaterialResponsibility, decimal?>(x, "Perc",
                                10, null), sender);
                    };

                    dlg.BeforeApplyAction = BeforeApplyAction(dlg.CommandManager, sender);

                    dlg.UpdateObjectList = () =>
                    {
                        dlg.ObjectList = KadrController.Instance.Model.MaterialResponsibilities;
                    };

                    dlg.ShowDialog();
                }
 
            Read(fs, MaterialResponsibilitybindingSource);
        }

        private static Action<MaterialResponsibility> BeforeApplyAction(ICommandManager commandManager, object sender)
        {
            return (x) =>
            {
                if (x.TempPrikazEnd == null) return;
                var eventMat = new Event_MaterialResponsibility(commandManager,x.FactStaff, MagicNumberController.EndEventType,x, 
                    x.TempPrikazEnd, x.DateEnd);

                commandManager.Execute(
                    new GenericPropertyCommand<Event_MaterialResponsibility, MaterialResponsibility>(eventMat,
                        "MaterialResponsibility", x, null), sender);
            };
        }

        public static void Read(FactStaff fs, BindingSource MaterialResponsibilitybindingSource)
        {
            MaterialResponsibilitybindingSource.DataSource = KadrController.Instance.Model.MaterialResponsibilities.Where(t => t.Event_MaterialResponsibilities.FirstOrDefault().Event.FactStaffHistory.FactStaff == fs).Select(x => x.GetDecorator()).ToList(); 
        }

        public static void Update(FactStaff fs, BindingSource MaterialResponsibilitybindingSource, object sender)
        {
            if (MaterialResponsibilitybindingSource.Current != null)
            {
                var ed = (MaterialResponsibilitybindingSource.Current as MaterialResponsibilityDecorator).GetMaterial();
                using (var dlg = new LinqPropertyGridDialogEditing<MaterialResponsibility>())
                {
                    dlg.UseInternalCommandManager = true;
                    dlg.SelectedObjects = new object[] { ed };
                    dlg.BeforeApplyAction = BeforeApplyAction(dlg.CommandManager, sender);
                    dlg.UpdateObjectList = () =>
                    {
                        dlg.ObjectList = KadrController.Instance.Model.MaterialResponsibilities;
                    };
                    dlg.ShowDialog();
                }
            }
            Read(fs, MaterialResponsibilitybindingSource);
        }

        public static void Delete(FactStaff fs, BindingSource MaterialResponsibilitybindingSource)
        {
            if (MaterialResponsibilitybindingSource.Current == null)
            {
                MessageBox.Show(@"Не выбрана удаляемая материальная ответственность.", @"ИС ""Управление кадрами""");
                return;
            }

            var currMaterial = (MaterialResponsibilitybindingSource.Current as MaterialResponsibilityDecorator).GetMaterial();

            if (MessageBox.Show("Удалить материальную ответственность?", "ИС \"Управление кадрами\"", MessageBoxButtons.OKCancel)
                != DialogResult.OK)
            {
                return;
            }

            var currContract = currMaterial.MainEvent.Contract;
            foreach (var evMat in currMaterial.Event_MaterialResponsibilities)
            {
              //  LinqActionsController<Event>.Instance.DeleteObject(evMat.Event, KadrController.Instance.Model.Events, null);
                KadrController.Instance.Model.Events.DeleteOnSubmit(evMat.Event);
            }

            //var currentPrikaz = currMaterial.Event_MaterialResponsibilities.FirstOrDefault().Event;
            

            KadrController.Instance.Model.MaterialResponsibilities.DeleteOnSubmit(currMaterial);
          //  LinqActionsController<Event>.Instance.DeleteObject(currentPrikaz, KadrController.Instance.Model.Events, null);
            LinqActionsController<Contract>.Instance.DeleteObject(currContract, KadrController.Instance.Model.Contracts, null);

            Read(fs, MaterialResponsibilitybindingSource);
        }
    }
}
