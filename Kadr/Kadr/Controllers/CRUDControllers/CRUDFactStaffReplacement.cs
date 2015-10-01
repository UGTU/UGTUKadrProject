using Kadr.Data;
using Kadr.UI.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using UIX.Commands;

namespace Kadr.Controllers.CRUDControllers
{
    class CRUDFactStaffReplacement
    {
        public static void Create(System.Windows.Forms.BindingSource factStaffBindingSource, FactStaff currentFactStaff, object sender)
        {
            if (currentFactStaff == null)
           {
               MessageBox.Show("Выберите сотрудника, которого нужно заместить.", "ИС \"Управление кадрами\"", MessageBoxButtons.OK);
               return;
           }

            if (currentFactStaff.Prikaz != null)
           {
               MessageBox.Show("Замещаемый сотрудник уже уволен!", "ИС \"Управление кадрами\"", MessageBoxButtons.OK);
               return;
           }


           using (Kadr.UI.Common.PropertyGridDialogAdding<FactStaffReplacement> dlg =
                new Kadr.UI.Common.PropertyGridDialogAdding<FactStaffReplacement>())
            {
                dlg.ObjectList = KadrController.Instance.Model.FactStaffReplacements;
                dlg.BindingSource = null;
                dlg.UseInternalCommandManager = true;
                dlg.InitializeNewObject = (x) =>
                {
                    FactStaff factStaff = new FactStaff();
                    factStaff.SetProperties(dlg.CommandManager, currentFactStaff.PlanStaff, NullEmployee.Instance, true, null, NullFinancingSource.Instance);
                    FactStaffHistory fcStHistory = new FactStaffHistory();
                    fcStHistory.SetProperties(dlg.CommandManager, factStaff, KadrController.Instance.Model.WorkTypes.Where(wtp => wtp.IsReplacement).FirstOrDefault(), NullPrikaz.Instance, DateTime.Today, MagicNumberController.ReplacementBeginEventKind,
                            MagicNumberController.BeginEventType, true);
                    //вычисляем то кол-во ставок, которое еще не замещено
                    decimal ReplStaffCount = currentFactStaff.StaffCount;
                    foreach (FactStaffReplacement repl in currentFactStaff.FactStaffReplacements)
                    {
                        if (repl.FactStaff1.Prikaz == null)
                            ReplStaffCount -= repl.FactStaff1.StaffCount;
                    }
                    dlg.CommandManager.Execute(new UIX.Commands.GenericPropertyCommand<FactStaffHistory, decimal>(fcStHistory, "StaffCount", ReplStaffCount, null), sender);

                    dlg.CommandManager.Execute(new UIX.Commands.GenericPropertyCommand<FactStaffReplacement, FactStaff>(x, "MainFactStaff", factStaff, null), sender);
                    dlg.CommandManager.Execute(new UIX.Commands.GenericPropertyCommand<FactStaffReplacement, FactStaff>(x, "ReplacedFactStaff", currentFactStaff, null), sender);
                    if ((dlg.SelectedObjects != null) && (dlg.SelectedObjects.Length == 1))
                    {
                        FactStaffReplacement prev = dlg.SelectedObjects[0] as FactStaffReplacement;
                        dlg.CommandManager.Execute(new UIX.Commands.GenericPropertyCommand<FactStaffReplacement, FactStaffReplacementReason>(x, "FactStaffReplacementReason", prev.FactStaffReplacementReason, null), sender);
                    }
                    else
                    {
                        dlg.CommandManager.Execute(new UIX.Commands.GenericPropertyCommand<FactStaffReplacement, FactStaffReplacementReason>(x, "FactStaffReplacementReason", NullFactStaffReplacementReason.Instance, null), sender);
                    }

                };
                dlg.ShowDialog();
            }

        }
    }
}
