using Kadr.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Kadr.UI.Common;

namespace Kadr.Controllers
{
    static class CRUDValidation
    {
        public static void Create(FactStaff fs, BindingSource ValidationDecoratorBS, object sender)
        {
        using (PropertyGridDialogAdding<Validation> dlg =
               SimpleActionsProvider.NewSimpleObjectAddingDialog<Validation>())
            {

                dlg.InitializeNewObject = (x =>
                     dlg.CommandManager.Execute(new UIX.Commands.GenericPropertyCommand<Validation, Event>(x, "Event", new Event(DateTime.Now.Date, null, fs), null), sender)
                );

                dlg.BeforeApplyAction = (x =>
                    {
                        dlg.CommandManager.Execute(new UIX.Commands.GenericPropertyCommand<Validation, EducDocument>(x, "EducDocument",
                            new EducDocument(dlg.CommandManager, KadrController.Instance.Model.EducDocumentTypes.FirstOrDefault(q => q.DocTypeName == Properties.Settings.Default.ValidationDocType))), sender);

                        dlg.CommandManager.Execute(new UIX.Commands.GenericPropertyCommand<EducDocument, string>(x.EducDocument, "DocSeries", x.TSerie), sender);
                        dlg.CommandManager.Execute(new UIX.Commands.GenericPropertyCommand<EducDocument, string>(x.EducDocument, "DocNumber", x.TNumber), sender);
                        dlg.CommandManager.Execute(new UIX.Commands.GenericPropertyCommand<EducDocument, DateTime?>(x.EducDocument, "DocDate", x.TDocDate), sender);
                    });

                dlg.ShowDialog();
            }

        Read(fs, ValidationDecoratorBS);
        }

        public static void Read(FactStaff fs, BindingSource ValidationDecoratorBS)
        {
            ValidationDecoratorBS.DataSource = KadrController.Instance.Model.Validations.Where(t => t.Event.FactStaff == fs)
                .Select(x => x.GetDecorator()).ToList();
        }

        public static void Update(FactStaff fs, BindingSource ValidationDecoratorBS)
        {
            if (ValidationDecoratorBS.Current != null)
                LinqActionsController<Validation>.Instance.EditObject(
                        (ValidationDecoratorBS.Current as ValidationDecorator).GetValidation(), true);
            Read(fs, ValidationDecoratorBS);
        }

        public static void Delete(FactStaff fs, BindingSource ValidationDecoratorBS)
        {
            if (ValidationDecoratorBS.Current == null)
                MessageBox.Show("Не выбрана аттестация!");
            else
                if (MessageBox.Show(string.Format("Вы уверены, что хотите удалить '{0}'?", (ValidationDecoratorBS.Current as ValidationDecorator).ToString()), "Подтверждение", MessageBoxButtons.OKCancel) == DialogResult.OK)
                {
                    Validation v = (ValidationDecoratorBS.Current as ValidationDecorator).GetValidation();

                    if (v.EducDocument != null)
                        KadrController.Instance.Model.EducDocuments.DeleteOnSubmit(v.EducDocument);

                    if (v.Event != null)
                        KadrController.Instance.Model.Events.DeleteOnSubmit(v.Event);

                    LinqActionsController<Validation>.Instance.DeleteObject(v, KadrController.Instance.Model.Validations, null);

                }
            Read(fs, ValidationDecoratorBS);
        }

        
    }
}
