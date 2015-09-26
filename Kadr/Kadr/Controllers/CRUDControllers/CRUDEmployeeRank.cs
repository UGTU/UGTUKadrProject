using Kadr.Data;
using Kadr.UI.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Kadr.Controllers
{
    public static class CRUDEmployeeRank
    {
        public static void Create(Employee e, object sender, BindingSource employeeRankBindingSource)
        {
            using (PropertyGridDialogAdding<EmployeeRank> dlg =
               SimpleActionsProvider.NewSimpleObjectAddingDialog<EmployeeRank>())
            {
                    dlg.InitializeNewObject = (x) =>
                    {
                        var educDocument = new EducDocument();
                        var docType = KadrController.Instance.Model.EducDocumentTypes.Single(educDocType
                            => educDocType.id == EducDocumentType.RankDoc);
                        dlg.CommandManager.Execute(new UIX.Commands.GenericPropertyCommand<EducDocument, EducDocumentType>(educDocument, "EducDocumentType", docType, null), sender);

                        dlg.CommandManager.Execute(new UIX.Commands.GenericPropertyCommand<EmployeeRank, Rank>(x, "Rank", NullRank.Instance, null), sender);
                        dlg.CommandManager.Execute(new UIX.Commands.GenericPropertyCommand<EmployeeRank, Employee>(x, "Employee", e, null), sender);
                        dlg.CommandManager.Execute(new UIX.Commands.GenericPropertyCommand<EmployeeRank, EducDocument>(x, "EducDocument", educDocument, null), sender);

                    };

                    dlg.UpdateObjectList = () =>
                    {
                        dlg.ObjectList = KadrController.Instance.Model.EmployeeRanks;
                    };

                    dlg.ShowDialog();
            }
            Read(e, employeeRankBindingSource);
        }

        public static void Read(Employee e, BindingSource employeeRankBindingSource)
        {
            employeeRankBindingSource.DataSource = KadrController.Instance.Model.EmployeeRanks.Where(empRank => empRank.Employee == e);
        }

        public static void Update(BindingSource employeeRankBindingSource)
        {
            if (employeeRankBindingSource.Current != null)
                LinqActionsController<EmployeeRank>.Instance.EditObject(
                        employeeRankBindingSource.Current as EmployeeRank, false);
        }

        public static void Delete(Employee e, BindingSource employeeRankBindingSource)
        {
            if (employeeRankBindingSource.Current == null)
                MessageBox.Show("Не выбрано удаляемое звание!");
            else
              if (MessageBox.Show("Удалить ученое звание сотрудника?", "ИС \"Управление кадрами\"", MessageBoxButtons.OKCancel)
                 == DialogResult.OK)
              {
                var rank = employeeRankBindingSource.Current as EmployeeRank;
                KadrController.Instance.Model.EducDocuments.DeleteOnSubmit(rank.EducDocument);
                LinqActionsController<EmployeeRank>.Instance.DeleteObject(rank,
                     KadrController.Instance.Model.EmployeeRanks, employeeRankBindingSource);
            }
            Read(e, employeeRankBindingSource);
         }
        
    }
}
