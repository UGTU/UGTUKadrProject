using Kadr.Data;
using Kadr.UI.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Kadr.Controllers
{
    public static class CRUDLanguage
    {
        public static void Create(Employee e, BindingSource EmplLanguageBindingSource, object sender)
        {
            using (PropertyGridDialogAdding<OK_EmployeeLang> dlg =
               SimpleActionsProvider.NewSimpleObjectAddingDialog<OK_EmployeeLang>())
            {

                dlg.InitializeNewObject = (x =>
                {
                    dlg.CommandManager.Execute(new UIX.Commands.GenericPropertyCommand<OK_EmployeeLang, Employee>(x, "Employee", e, null), sender);
                    dlg.CommandManager.Execute(new UIX.Commands.GenericPropertyCommand<OK_EmployeeLang, EducDocument>(x, "EducDocument",
                        new EducDocument()), sender);
                    dlg.CommandManager.Execute(new UIX.Commands.GenericPropertyCommand<OK_EmployeeLang, OK_Language>(x, "OK_Language", KadrController.Instance.Model.OK_Languages.FirstOrDefault(), null), sender);
                });

                dlg.ShowDialog();
            }

            Read(e, EmplLanguageBindingSource);
        }

        public static void Read(Employee e, BindingSource EmplLanguageBindingSource)
        {
            EmplLanguageBindingSource.DataSource = KadrController.Instance.Model.OK_EmployeeLangs.Where(educLang => educLang.Employee == e).Select(x => x.GetDecorator()).ToList();
        }

        public static void Update(Employee e, BindingSource EmplLanguageBindingSource)
        {
            if (EmplLanguageBindingSource.Current != null)
            {
                var lang = (EmplLanguageBindingSource.Current as EmployeeLangDecorator).GetEmployeeLang();
                if (lang.EducDocument == null) lang.EducDocument = new EducDocument();
                LinqActionsController<OK_EmployeeLang>.Instance.EditObject(lang, true);
            }

            Read(e, EmplLanguageBindingSource);
        }

        public static void Delete(Employee e, BindingSource EmplLanguageBindingSource)
        {
            if (EmplLanguageBindingSource.Current == null)
                MessageBox.Show("Не выбран удаляемый язык!");
            else
                if (MessageBox.Show(string.Format("Вы уверены, что хотите удалить '{0}'?", (EmplLanguageBindingSource.Current as EmployeeLangDecorator)), "Подтверждение", MessageBoxButtons.OKCancel) == DialogResult.OK)
                {
                    var educLang = (EmplLanguageBindingSource.Current as EmployeeLangDecorator).GetEmployeeLang();

                    if (educLang.EducDocument != null)
                        KadrController.Instance.Model.EducDocuments.DeleteOnSubmit(educLang.EducDocument);
                    LinqActionsController<OK_EmployeeLang>.Instance.DeleteObject(educLang, KadrController.Instance.Model.OK_EmployeeLangs, null);

                }
            Read(e, EmplLanguageBindingSource);
        }
    }
}
