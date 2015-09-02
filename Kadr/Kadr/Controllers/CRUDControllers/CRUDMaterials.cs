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
            using (PropertyGridDialogAdding<MaterialResponsibility> dlg =
               SimpleActionsProvider.NewSimpleObjectAddingDialog<MaterialResponsibility>())
            {
                    dlg.InitializeNewObject = (x) =>
                    {
                        x.FactStaff = fs;
                        var factStaffPrikaz = new FactStaffPrikaz();
                        var factStaffPrikazEnd = new FactStaffPrikaz();
                        dlg.CommandManager.Execute(
                            new GenericPropertyCommand<FactStaffPrikaz, FactStaff>(factStaffPrikaz, "FactStaff",
                                fs, null), sender);

                        dlg.CommandManager.Execute(
                            new GenericPropertyCommand<FactStaffPrikaz, Prikaz>(factStaffPrikaz, "Prikaz",
                                NullPrikaz.Instance, null), sender);

                        dlg.CommandManager.Execute(
                            new GenericPropertyCommand<FactStaffPrikaz, DateTime?>(factStaffPrikaz, "DateBegin",
                                DateTime.Today, null), sender);
                        dlg.CommandManager.Execute(
                            new GenericPropertyCommand<FactStaffPrikaz, DateTime?>(factStaffPrikaz, "DateEnd",
                                null, null), sender);
                        dlg.CommandManager.Execute(
                            new GenericPropertyCommand<MaterialResponsibility, decimal?>(x, "Perc",
                                10, null), sender);

                        dlg.CommandManager.Execute(
                            new GenericPropertyCommand<MaterialResponsibility, FactStaffPrikaz>(x,
                                "FactStaffPrikaz", factStaffPrikaz, null), sender);

                        // var contract = new Data.Contract();
                        dlg.CommandManager.Execute(new GenericPropertyCommand<MaterialResponsibility, Prikaz>(x, "Prikaz", 
                            new Prikaz(dlg.CommandManager, KadrController.Instance.Model.PrikazTypes.FirstOrDefault(y => y.id == Prikaz.MaterialPrikaz)), null), sender);
                        dlg.CommandManager.Execute(new GenericPropertyCommand<Prikaz, DateTime?>(x.Contract, "DatePrikaz", DateTime.Today, null), sender);
                        dlg.CommandManager.Execute(
                            new GenericPropertyCommand<Prikaz, string>(x.Contract, "PrikazName", "", null),
                            sender);

                    };

                    dlg.ShowDialog();
                }
 
            Read(fs, MaterialResponsibilitybindingSource);
        }

        public static void Read(FactStaff fs, BindingSource MaterialResponsibilitybindingSource)
        {
            MaterialResponsibilitybindingSource.DataSource = KadrController.Instance.Model.MaterialResponsibilities.Where(t => t.FactStaffPrikaz.FactStaff == fs);
        }

        public static void Update(FactStaff fs, BindingSource MaterialResponsibilitybindingSource)
        {
            if (MaterialResponsibilitybindingSource.Current != null)
            {
                var currMaterial = MaterialResponsibilitybindingSource.Current as MaterialResponsibility;
                currMaterial.FactStaff = fs;
                LinqActionsController<MaterialResponsibility>.Instance.EditObject(
                    currMaterial, true);
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

            var currMaterial = MaterialResponsibilitybindingSource.Current as MaterialResponsibility;

            if (MessageBox.Show("Удалить материальную ответственность?", "ИС \"Управление кадрами\"", MessageBoxButtons.OKCancel)
                != DialogResult.OK)
            {
                return;
            }
            var currentPrikaz = currMaterial.FactStaffPrikaz;
            var currContract = currMaterial.Contract;

            KadrController.Instance.Model.MaterialResponsibilities.DeleteOnSubmit(currMaterial);
            LinqActionsController<FactStaffPrikaz>.Instance.DeleteObject(currentPrikaz, KadrController.Instance.Model.FactStaffPrikazs, null);
            LinqActionsController<Prikaz>.Instance.DeleteObject(currContract, KadrController.Instance.Model.Prikazs, null);

            Read(fs, MaterialResponsibilitybindingSource);
        }
    }
}
