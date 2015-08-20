using Kadr.Data;
using Kadr.UI.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Kadr.Controllers
{
    public static class CRUDEducation
    {
        public static void Create(Employee e, BindingSource EducationBindingSource, object sender)
        {
            using (PropertyGridDialogAdding<OK_Educ> dlg =
               SimpleActionsProvider.NewSimpleObjectAddingDialog<OK_Educ>())
            {

                dlg.InitializeNewObject = (x) =>
                {
                    dlg.CommandManager.Execute(new UIX.Commands.GenericPropertyCommand<OK_Educ, Employee>(x, "Employee", e, null), sender);
                    dlg.CommandManager.Execute(new UIX.Commands.GenericPropertyCommand<OK_Educ, EducDocument>(x, "EducDocument",
                         new EducDocument(dlg.CommandManager, KadrController.Instance.Model.EducDocumentTypes.FirstOrDefault(q => q.id == EducDocumentType.EducationDoc))), sender);
                    dlg.CommandManager.Execute(new UIX.Commands.GenericPropertyCommand<OK_Educ, EducationType>(x, "EducationType", KadrController.Instance.Model.EducationTypes.FirstOrDefault(), null), sender);
                    dlg.CommandManager.Execute(new UIX.Commands.GenericPropertyCommand<OK_Educ, int?>(x, "EducWhen", DateTime.Today.Year, null), sender);
                };

                dlg.ShowDialog();
            }

            Read(e, EducationBindingSource);
        }

        public static void Read(Employee e, BindingSource EducationBindingSource)
        {
            EducationBindingSource.DataSource = KadrController.Instance.Model.OK_Educs.Where(educ => educ.Employee == e).Select(x => x.GetDecorator()).ToList();
            
        }

        public static void Update(Employee e, BindingSource EducationBindingSource)
        {
            if (EducationBindingSource.Current != null)
            {
                var ed = (EducationBindingSource.Current as EducationDecorator).GetEmplEduc();
                if (ed.EducDocument == null) ed.EducDocument = new EducDocument();
                LinqActionsController<OK_Educ>.Instance.EditObject(ed, false);
            }

            Read(e, EducationBindingSource);
        }

        public static void Delete(Employee e, BindingSource EducationBindingSource)
        {
            if (EducationBindingSource.Current == null)
                MessageBox.Show("Не выбрано удаляемое образование!");
            else
                if (MessageBox.Show(string.Format("Вы уверены, что хотите удалить '{0}'?", (EducationBindingSource.Current as EducationDecorator).ToString()), "Подтверждение", MessageBoxButtons.OKCancel) == DialogResult.OK)
                {
                    var educ = (EducationBindingSource.Current as EducationDecorator).GetEmplEduc();
                    if (educ.EducDocument != null)
                        LinqActionsController<EducDocument>.Instance.DeleteObject(educ.EducDocument, KadrController.Instance.Model.EducDocuments, null);
                    LinqActionsController<OK_Educ>.Instance.DeleteObject(educ, KadrController.Instance.Model.OK_Educs, EducationBindingSource);
                }
            Read(e, EducationBindingSource);
        }
    }
}
