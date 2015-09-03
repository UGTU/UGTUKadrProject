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
    public static class CRUDAward
    {
        public static void Create(Employee e, BindingSource awardDecoratorBindingSource, object sender)
        {
            using (PropertyGridDialogAdding<Award> dlg =
               SimpleActionsProvider.NewSimpleObjectAddingDialog<Award>())
            {
                dlg.InitializeNewObject = (x =>
                {
                    dlg.CommandManager.Execute(new GenericPropertyCommand<Award, Employee>(x, "Employee", e, null), sender);
                    dlg.CommandManager.Execute(new GenericPropertyCommand<Award, EducDocument>(x, "EducDocument",
                        new EducDocument(dlg.CommandManager, KadrController.Instance.Model.EducDocumentTypes.FirstOrDefault(q => q.DocTypeName == Properties.Settings.Default.AwardDocTypeName))), sender);
                    dlg.CommandManager.Execute(new UIX.Commands.GenericPropertyCommand<Award, AwardType>(x, "AwardType", KadrController.Instance.Model.AwardTypes.FirstOrDefault(), null), sender);
                    dlg.CommandManager.Execute(new UIX.Commands.GenericPropertyCommand<Award, AwardLevel>(x, "AwardLevel", KadrController.Instance.Model.AwardLevels.FirstOrDefault(), null), sender);
                
                });

                dlg.ShowDialog();
            }
            Read(e, awardDecoratorBindingSource);
        }

        public static void Read(Employee e, BindingSource awardDecoratorBindingSource)
        {
            awardDecoratorBindingSource.DataSource = KadrController.Instance.Model.Awards.Where(x => x.Employee == e)
                    .OrderBy(x => x.EducDocument.DocDate)
                    .Select(x => new AwardDecorator(x));

        }

        public static void Update(Employee e, BindingSource awardDecoratorBindingSource)
        {
            if (awardDecoratorBindingSource.Current != null)
                LinqActionsController<Award>.Instance.EditObject(
                        (awardDecoratorBindingSource.Current as AwardDecorator).GetAward(), true);
            Read(e, awardDecoratorBindingSource);
        }

        public static void Delete(Employee e, BindingSource awardDecoratorBindingSource)
        {
            if (awardDecoratorBindingSource.Current == null)
                MessageBox.Show("Не выбрана награда!");
            else
                if (MessageBox.Show(string.Format("Вы уверены, что хотите удалить '{0}'?", (awardDecoratorBindingSource.Current as AwardDecorator).ToString()), "Подтверждение", MessageBoxButtons.OKCancel) == DialogResult.OK)
                {
                    Award a = (awardDecoratorBindingSource.Current as AwardDecorator).GetAward();
                    KadrController.Instance.Model.EducDocuments.DeleteOnSubmit(a.EducDocument);
                    LinqActionsController<Award>.Instance.DeleteObject(a, KadrController.Instance.Model.Awards, null);
                }

            Read(e, awardDecoratorBindingSource);
        }
    }
    
}
