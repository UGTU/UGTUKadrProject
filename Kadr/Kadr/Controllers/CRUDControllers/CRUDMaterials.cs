﻿using Kadr.Data;
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
                        
                        var factStaffPrikaz = new FactStaffPrikaz();
                      //  var factStaffPrikazEnd = new FactStaffPrikaz();

                        dlg.CommandManager.Execute(
                            new GenericPropertyCommand<FactStaffPrikaz, FactStaff>(factStaffPrikaz, "FactStaff",
                                fs, null), sender);
                       /* dlg.CommandManager.Execute(
                            new GenericPropertyCommand<FactStaffPrikaz, FactStaff>(factStaffPrikazEnd, "FactStaff",
                                fs, null), sender);
                        */
                        dlg.CommandManager.Execute(
                            new GenericPropertyCommand<FactStaffPrikaz, Prikaz>(factStaffPrikaz, "Prikaz",
                                NullPrikaz.Instance, null), sender);
                    /*    dlg.CommandManager.Execute(
                            new GenericPropertyCommand<FactStaffPrikaz, Prikaz>(factStaffPrikazEnd, "Prikaz",
                                NullPrikaz.Instance, null), sender);*/

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
                       /* dlg.CommandManager.Execute(
                            new GenericPropertyCommand<MaterialResponsibility, FactStaffPrikaz>(x,
                                "FactStaffPrikaz1", factStaffPrikazEnd, null), sender);*/

                        // var contract = new Data.Contract();
                        dlg.CommandManager.Execute(new GenericPropertyCommand<MaterialResponsibility, Contract>(x, "Contract",
                            new Contract(), null), sender);
                        dlg.CommandManager.Execute(new GenericPropertyCommand<Contract, DateTime?>(x.Contract, "DateContract", DateTime.Today, null), sender);
                        dlg.CommandManager.Execute(
                            new GenericPropertyCommand<Contract, string>(x.Contract, "ContractName", "", null),
                            sender);

                    };

                    dlg.BeforeApplyAction = BeforeApplyAction();

                dlg.UpdateObjectList = () =>
                    {
                        dlg.ObjectList = KadrController.Instance.Model.MaterialResponsibilities;
                    };

                

                    dlg.ShowDialog();
                }
 
            Read(fs, MaterialResponsibilitybindingSource);
        }

        private static Action<MaterialResponsibility> BeforeApplyAction()
        {
            return x =>
            {
                if (x.PrikazTempEnd != null)
                    x.FactStaffPrikaz1 = new FactStaffPrikaz()
                    {
                        FactStaff = x.FactStaff,
                        Prikaz = x.PrikazTempEnd
                    };
            };
        }

        public static void Read(FactStaff fs, BindingSource MaterialResponsibilitybindingSource)
        {
            MaterialResponsibilitybindingSource.DataSource = KadrController.Instance.Model.MaterialResponsibilities.Where(t => t.FactStaffPrikaz.FactStaff == fs).Select(x => x.GetDecorator()).ToList(); 
        }

        public static void Update(FactStaff fs, BindingSource MaterialResponsibilitybindingSource)
        {
            if (MaterialResponsibilitybindingSource.Current != null)
            {
                var currMaterial = (MaterialResponsibilitybindingSource.Current as MaterialResponsibilityDecorator).GetMaterial();

                if (currMaterial == null)
                {
                    MessageBox.Show("Не выбран редактируемый объект.", "ИС \"Управление кадрами\"");
                    return;
                }

                using (var dlg = new LinqPropertyGridDialogEditing<MaterialResponsibility>())
                {
                    dlg.UseInternalCommandManager = true;
                    dlg.SelectedObjects = new object[] { currMaterial };

                    dlg.BeforeApplyAction = BeforeApplyAction();
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
            LinqActionsController<Contract>.Instance.DeleteObject(currContract, KadrController.Instance.Model.Contracts, null);

            Read(fs, MaterialResponsibilitybindingSource);
        }
    }
}
