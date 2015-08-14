using Kadr.Data;
using Kadr.UI.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Kadr.Controllers
{
    public static class CRUDMembFam
    {
        public static void Create(Employee e, BindingSource oKFamBindingSource, object sender)
        {
            using (PropertyGridDialogAdding<OK_Fam> dlg =
               SimpleActionsProvider.NewSimpleObjectAddingDialog<OK_Fam>())
                {

                    dlg.InitializeNewObject = (x) =>
                    {
                        dlg.CommandManager.Execute(new UIX.Commands.GenericPropertyCommand<OK_Fam, Employee>(x, "Employee", e, null), sender);
                        dlg.CommandManager.Execute(new UIX.Commands.GenericPropertyCommand<OK_Fam, OK_MembFam>(x, "OK_MembFam", NullOK_MembFam.Instance, null), sender);
                    };

                    dlg.ShowDialog();
                }

            Read(e, oKFamBindingSource);
        }

        public static void Read(Employee e, BindingSource oKFamBindingSource)
        {
            oKFamBindingSource.DataSource = KadrController.Instance.Model.OK_Fams.Where(fM => fM.Employee == e).ToArray();
        }

        public static void Update(Employee e, BindingSource oKFamBindingSource)
        {
            if (oKFamBindingSource.Current != null)
                LinqActionsController<OK_Fam>.Instance.EditObject(
                        oKFamBindingSource.Current as OK_Fam, true);
            Read(e, oKFamBindingSource);
        }

        public static void Delete(Employee e, BindingSource oKFamBindingSource)
        {
            OK_Fam CurrentFamMemb = oKFamBindingSource.Current as OK_Fam;

            if (CurrentFamMemb == null)
            {
                MessageBox.Show("Не выбран удаляемый родственник.", "ИС \"Управление кадрами\"");
                return;
            }

            if (MessageBox.Show("Удалить родственника?", "ИС \"Управление кадрами\"", MessageBoxButtons.OKCancel)
                != DialogResult.OK)
            {
                return;
            }

            LinqActionsController<OK_Fam>.Instance.DeleteObject(CurrentFamMemb, KadrController.Instance.Model.OK_Fams, null);

            Read(e, oKFamBindingSource);
        }
    }
}
