using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using Kadr.Data;
using Kadr.Controllers;


namespace Kadr.KadrTreeView.NodeAction
{

    public class RootTreeNodeActions : APG.CodeHelper.DBTreeView.DBTreeNodeAction
    {
        #region IDBTreeNodeAction Members


        [APG.CodeHelper.ContextMenuHelper.ContextMenuMethod("Добавить отдел...", true)]
        protected override void AddExecute(object sender)
        {
            using (Kadr.UI.Common.PropertyGridDialogAdding<Department> dlg =
                new Kadr.UI.Common.PropertyGridDialogAdding<Department>())
            {
                dlg.UseInternalCommandManager = true;
                dlg.ObjectList = KadrController.Instance.Model.Departments;
                dlg.BindingSource = null; ;
                dlg.InitializeNewObject = (x) =>
                {
                    dlg.CommandManager.Execute(new UIX.Commands.GenericPropertyCommand<Department, Department>(x, "Department1", (NodeObject as RootNodeObject).Department, null), this);
                };

                dlg.ShowDialog();
                (NodeObject as RootNodeObject).Refresh();
            }



            /*using (Kadr.UI.Common.PropertyGridDialog dlg = new Kadr.UI.Common.PropertyGridDialog())
            {
                dlg.UseInternalCommandManager = true;
                Department NewDepartment = Kadr.Controllers.KadrController.Instance.Model.CreateNewDepartment((NodeObject as RootNodeObject).Department, null);
                dlg.SelectedObjects = new object[] { NewDepartment };
                dlg.Text = "Добавление нового отдела";
                dlg.ShowDialog();

                //обновляем дерево, если да
                if (dlg.DialogResult == System.Windows.Forms.DialogResult.OK)
                {
                    NodeObject.Refresh();    
                }
                //удаляем отдел, если отмена
                else
                {
                    (NodeObject as RootNodeObject).Department.Departments.Remove(NewDepartment);
                    KadrController.Instance.Model.Departments.DeleteOnSubmit(NewDepartment);
                }
            }*/
        }

        protected override void DeleteExecute(object sender)
        {
            //MessageBox.Show("DeleteExecute");

            LinqActionsController<Department>.Instance.DeleteObject((NodeObject as RootNodeObject).Department ,
                 KadrController.Instance.Model.Departments, null);

            //если узел удален, обновляем поддерево
            if ((KadrController.Instance.Model.Departments.Where(dep => dep == (NodeObject as RootNodeObject).Department).Count() == 0))
                NodeObject.Parent.Refresh();
                //treeView.Refresh();

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
            LinqActionsController<Department>.Instance.EditObject((NodeObject as RootNodeObject).Department, false);
            
        }


        protected override bool CanAdd(object sender)
        {

            return true;
        }

        protected override bool CanDelete(object sender)
        {
            return true;
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

        private string[] captions = new string[6] {"Добавить отдел...", "Удалить отдел",
        "Копировать отдел", "Вырезать отдел", "Свойства...", "Вставить отдел"};

        protected override string GetCaption(APG.CodeHelper.Actions.UIObjectAction index)
        {
            return captions[(int)index];
        }

        protected override void SetCaption(APG.CodeHelper.Actions.UIObjectAction index, string caption)
        {
            captions[(int)index] = caption;
        }


        #endregion

        public RootTreeNodeActions(APG.CodeHelper.DBTreeView.DBTreeNodeObject nodeObj) : base(nodeObj) { }

    }
}

