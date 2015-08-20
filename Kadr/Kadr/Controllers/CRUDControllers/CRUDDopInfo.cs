using Kadr.Data;
using Kadr.UI.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Kadr.Controllers
{
    static class CRUDDopInfo
    {
        public static void Create(Employee e, BindingSource oKDopInfBindingSource, object sender)
        {
            using (PropertyGridDialogAdding<OK_DopInf> dlg =
              SimpleActionsProvider.NewSimpleObjectAddingDialog<OK_DopInf>())
            {
                dlg.InitializeNewObject = (x) =>
                {
                    dlg.CommandManager.Execute(new UIX.Commands.GenericPropertyCommand<OK_DopInf, Employee>(x, "Employee", e, null), sender);
                };

                dlg.ShowDialog();
            }

            Read(e, oKDopInfBindingSource);
        }

        public static void Read(Employee e, BindingSource oKDopInfBindingSource)
        {
            oKDopInfBindingSource.DataSource = KadrController.Instance.Model.OK_DopInfs.Where(dInf => dInf.Employee == e).ToArray();
        }

        public static void Update(Employee e, BindingSource oKDopInfBindingSource)
        {
            if (oKDopInfBindingSource.Current != null)
                LinqActionsController<OK_DopInf>.Instance.EditObject(
                        oKDopInfBindingSource.Current as OK_DopInf, true);

            Read(e, oKDopInfBindingSource);
        }

        public static void Delete(Employee e, BindingSource oKDopInfBindingSource)
        {

            OK_DopInf CurrentDopInf = oKDopInfBindingSource.Current as OK_DopInf;

            if (CurrentDopInf == null)
            {
                MessageBox.Show("Не выбрана удаляемая строка.", "ИС \"Управление кадрами\"");
                return;
            }

            if (MessageBox.Show("Удалить выбранную строку из дополнительных сведений?", "ИС \"Управление кадрами\"", MessageBoxButtons.OKCancel)
                != DialogResult.OK)
            {
                return;
            }

            LinqActionsController<OK_DopInf>.Instance.DeleteObject(CurrentDopInf, KadrController.Instance.Model.OK_DopInfs, null);

            Read(e, oKDopInfBindingSource);
        }


    }
}
