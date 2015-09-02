using Kadr.Data;
using Kadr.UI.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Kadr.Controllers
{
    public static class CRUDIncapacity
    {
        public static void Create(Employee e, BindingSource inkapacityDecoratorBindingSource, object sender)
        {
                using (Kadr.UI.Common.PropertyGridDialogAdding<OK_Inkapacity> dlg =
               SimpleActionsProvider.NewSimpleObjectAddingDialog<OK_Inkapacity>())
            {
             
                dlg.InitializeNewObject = (x =>
                {
                    dlg.CommandManager.Execute(new UIX.Commands.GenericPropertyCommand<OK_Inkapacity, Employee>(x, "Employee", e, null), sender);
                    dlg.CommandManager.Execute(new UIX.Commands.GenericPropertyCommand<OK_Inkapacity, EducDocument>(x, "EducDocument",
                        new EducDocument(dlg.CommandManager, KadrController.Instance.Model.EducDocumentTypes.FirstOrDefault(q => q.DocTypeName == Properties.Settings.Default.InkapacityDocTypeName))), sender);
                    dlg.CommandManager.Execute(new UIX.Commands.GenericPropertyCommand<OK_Inkapacity, DateTime>(x, "DateBegin", DateTime.Today.Date, null), sender);
                    dlg.CommandManager.Execute(new UIX.Commands.GenericPropertyCommand<OK_Inkapacity, DateTime?>(x, "DateEnd", DateTime.Today.AddDays(7).Date, null), sender);
                    dlg.CommandManager.Execute(new UIX.Commands.GenericPropertyCommand<OK_Inkapacity, bool>(x, "IsFinished", true, null), sender);
                });
              
                dlg.ShowDialog();
            }


            Read(e, inkapacityDecoratorBindingSource);
        }

        public static void Read(Employee e, BindingSource inkapacityDecoratorBindingSource)
        {
            inkapacityDecoratorBindingSource.DataSource = KadrController.Instance.Model.OK_Inkapacities.Where(x => x.Employee == e)
                    .OrderBy(x => x.DateBegin)
                    .Select(x => new InkapacityDecorator(x)); 
        }

        public static void Update(Employee e, BindingSource inkapacityDecoratorBindingSource)
        {
            if (inkapacityDecoratorBindingSource.Current != null)
                LinqActionsController<OK_Inkapacity>.Instance.EditObject(
                        (inkapacityDecoratorBindingSource.Current as InkapacityDecorator).GetInkapacity(), true);
            Read(e, inkapacityDecoratorBindingSource);
        }

        public static void Delete(Employee e, BindingSource inkapacityDecoratorBindingSource)
        {
             if (inkapacityDecoratorBindingSource.Current == null)
                MessageBox.Show("Не выбран социальный статус!");
            else
                if (MessageBox.Show(string.Format("Вы уверены, что хотите удалить '{0}'?", (inkapacityDecoratorBindingSource.Current as InkapacityDecorator).ToString()), "Подтверждение", MessageBoxButtons.OKCancel) == DialogResult.OK)
                {
                    OK_Inkapacity i = (inkapacityDecoratorBindingSource.Current as InkapacityDecorator).GetInkapacity();

                    if (i.EducDocument!=null)
                    KadrController.Instance.Model.EducDocuments.DeleteOnSubmit(i.EducDocument);
                    LinqActionsController<OK_Inkapacity>.Instance.DeleteObject(i, KadrController.Instance.Model.OK_Inkapacities, null);

                }
            Read(e, inkapacityDecoratorBindingSource);
        }
    }
    
}
