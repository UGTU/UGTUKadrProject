using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Kadr.Data;
using Kadr.Controllers;

namespace Kadr.KadrTreeView.NodeAction
{

    public class EmployeeTreeNodeActions : APG.CodeHelper.DBTreeView.DBTreeNodeAction
    {
        #region EmployeeTreeNodeActions Members


        //[APG.CodeHelper.ContextMenuHelper.ContextMenuMethod("Добавить сотрудника...", true)]
        //protected override void AddExecute(object sender)
        //{
        //    using (Kadr.UI.Common.PropertyGridDialogAdding<Employee> dlg =
        //        new Kadr.UI.Common.PropertyGridDialogAdding<Employee>())
        //    {
        //        dlg.UseInternalCommandManager = true;
        //        dlg.ObjectList = KadrController.Instance.Model.Employees;
        //        dlg.BindingSource = null; ;
        //        dlg.InitializeNewObject = (x) =>
        //        {

        //            dlg.CommandManager.Execute(new UIX.Commands.GenericPropertyCommand<Employee, Grazd>(x, "Grazd", NullGrazd.Instance, null), this);
        //            dlg.CommandManager.Execute(new UIX.Commands.GenericPropertyCommand<Employee, SemPol>(x, "SemPol", NullSemPol.Instance, null), this);
        //        };

        //        dlg.ShowDialog();
        //    }
        //}

        protected override void AddExecute(object sender)
        {
            
        }

        protected override void DeleteExecute(object sender)
        {
            //MessageBox.Show("DeleteExecute");
        }

        protected override void CopyExecute(object sender)
        {
            //MessageBox.Show("CopyExecute");
        }

        protected override void CutExecute(object sender)
        {
            //MessageBox.Show("CutExecute");
        }

        protected override void PasteExecute(object sender)
        {
            //MessageBox.Show("PasteExecute");
        }


        [APG.CodeHelper.ContextMenuHelper.ContextMenuMethod("Свойства...", true)]
        protected override void UpdateExecute(object sender)
        {
            using (Kadr.UI.Common.PropertyGridDialog dlg = new Kadr.UI.Common.PropertyGridDialog())
            {
                dlg.UseInternalCommandManager = true;
                dlg.SelectedObjects = new object[] { (NodeObject as KadrEmployeeObject).Employee };
                //dlg.Text = "Отдел " + (NodeObject as RootNodeObject).Department.DepartmentName;
                dlg.ShowDialog();
            }
        }

        protected override void ExportExecute(object sender)
        {
            
        }

        protected override void AddHistoryExecute(object sender)
        {

        }

        protected override void HistoryExecute(object sender)
        {

        }


        protected override bool CanAdd(object sender)
        {

            return false;
        }

        protected override bool CanDelete(object sender)
        {
            return false;
        }

        protected override bool CanCopy(object sender)
        {
            return false;
        }

        protected override bool CanCut(object sender)
        {
            return false;
        }

        protected override bool CanPaste(object sender)
        {
            return false;
        }

        protected override bool CanUpdate(object sender)
        {
            return true;
        }

        protected override bool CanExport(object sender)
        {
            return false;
        }

        protected override bool CanAddHistory(object sender)
        {
            return false;
        }

        protected override bool CanHistory(object sender)
        {
            return false;
        }

        private string[] captions = new string[9] {"Добавить сотрудника...", "Удалить сотрудника",
        "Копировать сотрудников", "Вырезать сотрудников", "Свойства...", "Вставить сотрудников", 
        "Экспорт в Excel", "Изменить", "Просмотреть историю"};

        protected override string GetCaption(APG.CodeHelper.Actions.UIObjectAction index)
        {
            return captions[(int)index];
        }

        protected override void SetCaption(APG.CodeHelper.Actions.UIObjectAction index, string caption)
        {
            captions[(int)index] = caption;
        }


        #endregion

        public EmployeeTreeNodeActions(APG.CodeHelper.DBTreeView.DBTreeNodeObject nodeObj) : base(nodeObj) { }

    }
}


