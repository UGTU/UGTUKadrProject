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
    public static class CRUDEmployeeDegree
    {
        public static void Create(Employee e, object sender)
        {
            using (PropertyGridDialogAdding<EmployeeDegree> dlg =
               SimpleActionsProvider.NewSimpleObjectAddingDialog<EmployeeDegree>())
            {

                    dlg.InitializeNewObject = (x) =>
                    {
                        EducDocument educDocument = new EducDocument();
                        EducDocumentType docType = KadrController.Instance.Model.EducDocumentTypes.Where(educDocType
                            => educDocType.id == 1).First();
                        dlg.CommandManager.Execute(new GenericPropertyCommand<EducDocument, EducDocumentType>(educDocument, "EducDocumentType", docType, null), sender);
                        dlg.CommandManager.Execute(new GenericPropertyCommand<EmployeeDegree, ScienceType>(x, "ScienceType", NullScienceType.Instance, null), sender);
                        dlg.CommandManager.Execute(new GenericPropertyCommand<EmployeeDegree, Degree>(x, "Degree", NullDegree.Instance, null), sender);
                        dlg.CommandManager.Execute(new GenericPropertyCommand<EmployeeDegree, Employee>(x, "Employee", e, null), sender);
                        dlg.CommandManager.Execute(new GenericPropertyCommand<EmployeeDegree, EducDocument>(x, "EducDocument", educDocument, null), sender);
                    };


                    dlg.ShowDialog();
             }
            //Read(fs, MaterialResponsibilitybindingSource);
        }

        public static void Read(Employee e, BindingSource employeeDegreeBindingSource)
        {
            employeeDegreeBindingSource.DataSource = KadrController.Instance.Model.EmployeeDegrees.Where(empDegr => empDegr.Employee == e);
            
        }

        public static void Update(BindingSource employeeDegreeBindingSource)
        {
            if (employeeDegreeBindingSource.Current != null)
                LinqActionsController<EmployeeDegree>.Instance.EditObject(
                        employeeDegreeBindingSource.Current as EmployeeDegree, false);
        }

        public static void Delete(BindingSource employeeDegreeBindingSource)
        {
            if (MessageBox.Show("Удалить научную степень сотрудника?", "ИС \"Управление кадрами\"", MessageBoxButtons.OKCancel)
                == DialogResult.OK)
            {
                LinqActionsController<EducDocument>.Instance.DeleteObject((employeeDegreeBindingSource.Current as EmployeeDegree).EducDocument,
                     KadrController.Instance.Model.EducDocuments, null);

                LinqActionsController<EmployeeDegree>.Instance.DeleteObject(employeeDegreeBindingSource.Current as EmployeeDegree,
                     KadrController.Instance.Model.EmployeeDegrees, employeeDegreeBindingSource);
            }
        }
    }
}
