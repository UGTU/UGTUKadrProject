using Kadr.Data;
using Kadr.UI.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Kadr.Controllers
{
    public static class CRUDPhone
    {
        public static void Create(Employee e, BindingSource oKphoneBindingSource, object sender)
        {
            using (PropertyGridDialogAdding<OK_phone> dlg =
               SimpleActionsProvider.NewSimpleObjectAddingDialog<OK_phone>())
            {             
                dlg.InitializeNewObject = (x) =>
                {
                    dlg.CommandManager.Execute(new UIX.Commands.GenericPropertyCommand<OK_phone, Employee>(x, "Employee", e, null), sender);
                };


                dlg.ShowDialog();
            }

            Read(e, oKphoneBindingSource);
        }

        public static void Read(Employee e, BindingSource oKphoneBindingSource)
        {
            oKphoneBindingSource.DataSource = KadrController.Instance.Model.OK_phones.Where(pH => pH.Employee == e).ToArray();
        }

        public static void Update(Employee e, BindingSource oKphoneBindingSource)
        {
            if (oKphoneBindingSource.Current != null)
                LinqActionsController<OK_phone>.Instance.EditObject(
                        oKphoneBindingSource.Current as OK_phone, true);
            Read(e, oKphoneBindingSource);
        }

        public static void Delete(Employee e, BindingSource oKphoneBindingSource)
        {
            OK_phone CurrentPhone = oKphoneBindingSource.Current as OK_phone;

            if (CurrentPhone == null)
            {
                MessageBox.Show("Не выбран удаляемый номер.", "ИС \"Управление кадрами\"");
                return;
            }

            if (MessageBox.Show("Удалить номер?", "ИС \"Управление кадрами\"", MessageBoxButtons.OKCancel)
                != DialogResult.OK)
            {
                return;
            }

            LinqActionsController<OK_phone>.Instance.DeleteObject(CurrentPhone, KadrController.Instance.Model.OK_phones, null);

            Read(e, oKphoneBindingSource);
        }
    }
}
