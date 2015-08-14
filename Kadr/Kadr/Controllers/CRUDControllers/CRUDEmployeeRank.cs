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
        public static void Create(Employee e, object sender)
        {
            using (PropertyGridDialogAdding<EmployeeRank> dlg =
               SimpleActionsProvider.NewSimpleObjectAddingDialog<EmployeeRank>())
            {
                    dlg.InitializeNewObject = (x) =>
                    {
                        EducDocument educDocument = new EducDocument();
                        EducDocumentType docType = Kadr.Controllers.KadrController.Instance.Model.EducDocumentTypes.Where(educDocType
                            => educDocType.id == 2).First();
                        dlg.CommandManager.Execute(new UIX.Commands.GenericPropertyCommand<EducDocument, EducDocumentType>(educDocument, "EducDocumentType", docType, null), sender);

                        dlg.CommandManager.Execute(new UIX.Commands.GenericPropertyCommand<EmployeeRank, Rank>(x, "Rank", NullRank.Instance, null), sender);
                        dlg.CommandManager.Execute(new UIX.Commands.GenericPropertyCommand<EmployeeRank, Employee>(x, "Employee", e, null), sender);
                        dlg.CommandManager.Execute(new UIX.Commands.GenericPropertyCommand<EmployeeRank, EducDocument>(x, "EducDocument", educDocument, null), sender);

                    };

                    dlg.ShowDialog();
            }

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

        public static void Delete(BindingSource employeeRankBindingSource)
        {
            if (MessageBox.Show("Удалить ученое звание сотрудника?", "ИС \"Управление кадрами\"", MessageBoxButtons.OKCancel)
                 == DialogResult.OK)
            {
                LinqActionsController<EducDocument>.Instance.DeleteObject((employeeRankBindingSource.Current as EmployeeRank).EducDocument,
                     KadrController.Instance.Model.EducDocuments, null);

                LinqActionsController<EmployeeRank>.Instance.DeleteObject(employeeRankBindingSource.Current as EmployeeRank,
                     KadrController.Instance.Model.EmployeeRanks, employeeRankBindingSource);
            }
        }
    }
}
