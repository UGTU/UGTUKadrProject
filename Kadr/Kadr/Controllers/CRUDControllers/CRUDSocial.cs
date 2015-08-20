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
    public static class CRUDSocial
    {
        public static void Create(Employee e, BindingSource socialDecoratorBindingSource, object sender)
        {
            using (PropertyGridDialogAdding<OK_Social> dlg =
               SimpleActionsProvider.NewSimpleObjectAddingDialog<OK_Social>())
            {
                dlg.InitializeNewObject = (x =>
                {
                    dlg.CommandManager.Execute(new UIX.Commands.GenericPropertyCommand<OK_Social, Employee>(x, "Employee", e, null), sender);
                    dlg.CommandManager.Execute(new UIX.Commands.GenericPropertyCommand<OK_Social, EducDocument>(x, "EducDocument",
                        new EducDocument(dlg.CommandManager, KadrController.Instance.Model.EducDocumentTypes.FirstOrDefault(q => q.DocTypeName == Properties.Settings.Default.SocialDocType))), sender);
                    dlg.CommandManager.Execute(new UIX.Commands.GenericPropertyCommand<OK_Social, OK_SocialStatus>(x, "OK_SocialStatus", KadrController.Instance.Model.OK_SocialStatus.FirstOrDefault(), null), sender);
                });
               
                dlg.ShowDialog();
            }
            Read(e, socialDecoratorBindingSource);
        }

        public static void Read(Employee e, BindingSource socialDecoratorBindingSource)
        {
            socialDecoratorBindingSource.DataSource = KadrController.Instance.Model.OK_Socials.Where(x => x.Employee == e)
                    .Select(x => new SocialDecorator(x)); 
        }

        public static void Update(Employee e, BindingSource socialDecoratorBindingSource)
        {
            if (socialDecoratorBindingSource.Current != null)
                LinqActionsController<OK_Social>.Instance.EditObject(
                        (socialDecoratorBindingSource.Current as SocialDecorator).GetSocial(), true);
            Read(e, socialDecoratorBindingSource);
        }

        public static void Delete(Employee e, BindingSource socialDecoratorBindingSource)
        {
            if (socialDecoratorBindingSource.Current == null)
                MessageBox.Show("Не выбран социальный статус!");
            else
                if (MessageBox.Show(string.Format("Вы уверены, что хотите удалить '{0}'?", (socialDecoratorBindingSource.Current as SocialDecorator).ToString()), "Подтверждение", MessageBoxButtons.OKCancel) == DialogResult.OK)
                {
                    OK_Social o = (socialDecoratorBindingSource.Current as SocialDecorator).GetSocial();

                    if (o.EducDocument != null)
                        KadrController.Instance.Model.EducDocuments.DeleteOnSubmit(o.EducDocument);
                    LinqActionsController<OK_Social>.Instance.DeleteObject(o, KadrController.Instance.Model.OK_Socials, null);

                }
            Read(e, socialDecoratorBindingSource);
        }
    }
    
}
