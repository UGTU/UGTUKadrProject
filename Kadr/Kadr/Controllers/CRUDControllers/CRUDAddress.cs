using Kadr.Data;
using Kadr.UI.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Kadr.Controllers
{
    public static class CRUDAddress
    {
        public static void Create(Employee e, BindingSource oKAdressBindingSource, object sender)
        {
            using (PropertyGridDialogAdding<OK_Adress> dlg =
               SimpleActionsProvider.NewSimpleObjectAddingDialog<OK_Adress>())
            {
                dlg.InitializeNewObject = (x) =>
                {
                    dlg.CommandManager.Execute(new UIX.Commands.GenericPropertyCommand<OK_Adress, Employee>(x, "Employee", e, null), sender);
                    dlg.CommandManager.Execute(new UIX.Commands.GenericPropertyCommand<OK_Adress, DateTime?>(x, "DateReg", DateTime.Today, null), sender);
                };

                dlg.ShowDialog();
            }
            Read(e, oKAdressBindingSource);
        }

        public static void Read(Employee e, BindingSource oKAdressBindingSource)
        {
            oKAdressBindingSource.DataSource = KadrController.Instance.Model.OK_Adresses.Where(Addr => Addr.Employee == e).ToArray();
        }

        public static void Update(Employee e, BindingSource oKAdressBindingSource)
        {
            if (oKAdressBindingSource.Current != null)
                LinqActionsController<OK_Adress>.Instance.EditObject(
                        oKAdressBindingSource.Current as OK_Adress, true);
            Read(e, oKAdressBindingSource);
        }

        public static void Delete(Employee e, BindingSource oKAdressBindingSource)
        {
            OK_Adress CurrentAddress = oKAdressBindingSource.Current as OK_Adress;

            if (CurrentAddress == null)
            {
                MessageBox.Show("Не выбран удаляемый адрес.", "ИС \"Управление кадрами\"");
                return;
            }

            if (MessageBox.Show("Удалить адрес?", "ИС \"Управление кадрами\"", MessageBoxButtons.OKCancel)
                != DialogResult.OK)
            {
                return;
            }

            LinqActionsController<OK_Adress>.Instance.DeleteObject(CurrentAddress, KadrController.Instance.Model.OK_Adresses, null);

            Read(e, oKAdressBindingSource);
        }
    }
    
}
