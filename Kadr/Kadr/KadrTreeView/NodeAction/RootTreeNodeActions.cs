using System;
using System.Windows.Forms;
using Kadr.Controllers;
using Kadr.Reporting;
using Kadr.UI.Reporting;
using Kadr.UI.Common;

namespace Kadr.KadrTreeView.NodeAction
{

    public class RootTreeNodeActions : APG.CodeHelper.DBTreeView.DBTreeNodeAction
    {
        #region IDBTreeNodeAction Members
        //[APG.CodeHelper.ContextMenuHelper.ContextMenuMethod("Настроить путь сохранения шаблона", true, visible: false)]
        //[APG.CodeHelper.ContextMenuHelper.ContextMenuMethod("Настроить путь сохранения шаблона", true)]
        public void CreateReport(object sender)
        {

        }

        [APG.CodeHelper.ContextMenuHelper.ContextMenuMethod("Получить график отпусков...", true)]
        [APG.CodeHelper.ContextMenuHelper.ActionCaption(typeof(VacationReportCaptionProvider))]
        public void CreateVacationPlanReport(object sender)
        {
            var root = NodeObject as RootNodeObject;
            if (root == null) return;
            var script =
                new ScheduleBuildingScript(
                    new VacationPlanParams(root.Department.DepartmentGUID,
                    System.IO.Path.GetFullPath(Properties.Settings.Default.VacationPlanTemplatePath),
                    BuildOutputFileName(root)) {PageName = root.Department.LastChange?.DepartmentSmallName}
                    );
            script.Run();
        }

        private static string BuildOutputFileName(RootNodeObject root)
        {
            var departmentName = root.Department.LastChange.DepartmentSmallName;
            var folder = Properties.Settings.Default.ReportsOutputFolder;
            if (string.IsNullOrEmpty(folder))
                folder = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            folder += "\\";

            var fileName = string.Empty;
            try
            {
                var today = DateTime.Today;
                fileName = string.Format(Properties.Settings.Default.DefaultVacationReportOutputFormat, departmentName,
                    $"{today.Day}-{today.Month}-{today.Year}", today.Month > 8 ? today.Year + 1 : today.Year);

            }
            catch (FormatException)
            {
                
            }
            return folder + fileName;
        }

      //  [APG.CodeHelper.ContextMenuHelper.ContextMenuMethod("Добавить отдел...", true)]
        protected override void AddExecute(object sender)
        {
            /*using (Kadr.UI.Common.PropertyGridDialogAdding<Dep> dlg =
                new Kadr.UI.Common.PropertyGridDialogAdding<Dep>())
            {
                dlg.UseInternalCommandManager = true;
                dlg.ObjectList = KadrController.Instance.Model.Deps;
                dlg.BindingSource = null; ;
                dlg.InitializeNewObject = (x) =>
                {
                    DepartmentHistory depHistory = new DepartmentHistory();
                    dlg.CommandManager.Execute(new UIX.Commands.GenericPropertyCommand<DepartmentHistory, Prikaz>(depHistory, "Prikaz", NullPrikaz.Instance, null), this);
                    dlg.CommandManager.Execute(new UIX.Commands.GenericPropertyCommand<DepartmentHistory, Dep>(depHistory, "Dep", x, null), this);
                    
                    dlg.CommandManager.Execute(new UIX.Commands.GenericPropertyCommand<DepartmentHistory, Dep>(depHistory, "Dep1", (NodeObject as RootNodeObject).Department, null), this);

                    dlg.CommandManager.Execute(new UIX.Commands.GenericPropertyCommand<Dep, Guid>(x, "DepartmentGUID", Guid.NewGuid(), null), this);

                    FundingCenter center = (NodeObject as RootNodeObject).Department.FundingCenter;
                    if (center == null)
                        dlg.CommandManager.Execute(new UIX.Commands.GenericPropertyCommand<Dep, FundingCenter>(x, "FundingCenter", NullFundingCenter.Instance, null), this);
                    else
                        dlg.CommandManager.Execute(new UIX.Commands.GenericPropertyCommand<Dep, FundingCenter>(x, "FundingCenter", center, null), this);

                };

                dlg.ShowDialog();
                (NodeObject as RootNodeObject).Refresh();
            }*/


        }

        protected override void DeleteExecute(object sender)
        {
            //MessageBox.Show("DeleteExecute");
            /*KadrController.Instance.Model.DepartmentHistories.DeleteAllOnSubmit(KadrController.Instance.Model.DepartmentHistories.Where(depHist => depHist.Dep == (NodeObject as RootNodeObject).Department));

            LinqActionsController<Dep>.Instance.DeleteObject((NodeObject as RootNodeObject).Department ,
                 KadrController.Instance.Model.Deps, null);

            //если узел удален, обновляем поддерево
            if ((KadrController.Instance.Model.Deps.Where(dep => dep == (NodeObject as RootNodeObject).Department).Count() == 0)
                && (NodeObject.Parent != null))
                NodeObject.Parent.Refresh();
                //treeView.Refresh();*/

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

      //  [APG.CodeHelper.ContextMenuHelper.ContextMenuMethod("Свойства...", true)]
        protected override void UpdateExecute(object sender)
        {
            /*if ((NodeObject as RootNodeObject).Department.FundingCenter == null)
                (NodeObject as RootNodeObject).Department.FundingCenter = NullFundingCenter.Instance;
            LinqActionsController<Dep>.Instance.EditObject((NodeObject as RootNodeObject).Department, false);
            NodeObject.Refresh();*/
        }

        [APG.CodeHelper.ContextMenuHelper.ContextMenuMethod("Экспортировать в Excel", true)]
        protected override void ExportExecute(object sender)
        {

            ExcelExportController.Instance.ExportDepartmentsToExcel((NodeObject as RootNodeObject).Department.id);
        }


        protected override void AddHistoryExecute(object sender)
        {
            /*Dep currentDepartment = (NodeObject as RootNodeObject).Department;
            using (Kadr.UI.Common.PropertyGridDialogAdding<DepartmentHistory> dlg =
                 new Kadr.UI.Common.PropertyGridDialogAdding<DepartmentHistory>())
            {
                dlg.UseInternalCommandManager = true;
                dlg.ObjectList = KadrController.Instance.Model.DepartmentHistories;
                //dlg.BindingSource = planStaffBindingSource;
                dlg.PrikazButtonVisible = true;
                dlg.oneObjectCreated = true;
                dlg.InitializeNewObject = (x) =>
                {
                    dlg.CommandManager.Execute(new UIX.Commands.GenericPropertyCommand<DepartmentHistory, string>(x, "DepartmentName", currentDepartment.DepartmentName, null), this);
                    dlg.CommandManager.Execute(new UIX.Commands.GenericPropertyCommand<DepartmentHistory, string>(x, "DepartmentSmallName", currentDepartment.DepartmentSmallName, null), this);
                    dlg.CommandManager.Execute(new UIX.Commands.GenericPropertyCommand<DepartmentHistory, Prikaz>(x, "Prikaz", NullPrikaz.Instance, null), this);
                    dlg.CommandManager.Execute(new UIX.Commands.GenericPropertyCommand<DepartmentHistory, Dep>(x, "Dep1", currentDepartment.ManagerDepartment, null), this);
                    dlg.CommandManager.Execute(new UIX.Commands.GenericPropertyCommand<DepartmentHistory, Dep>(x, "Dep", currentDepartment, null), this);

                };

                dlg.UpdateObjectList = () =>
                {
                    dlg.ObjectList = KadrController.Instance.Model.DepartmentHistories;
                };

                dlg.ShowDialog();
                NodeObject.Refresh();
            }*/
        }

        protected override void HistoryExecute(object sender)
        {
            /*using (Kadr.UI.Forms.DepartmentHistoryForm HistForm =
                           new Kadr.UI.Forms.DepartmentHistoryForm())
            {
                HistForm.Department = (NodeObject as RootNodeObject).Department;
                HistForm.ShowDialog();
            }
            NodeObject.Refresh();*/
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
            return false;
        }

        protected override bool CanExport(object sender)
        {
            return true;
        }

        protected override bool CanAddHistory(object sender)
        {
            return false;
        }

        protected override bool CanHistory(object sender)
        {
            return false;
        }


        private string[] captions = new string[9] {"Добавить отдел...", "Удалить отдел",
        "Копировать отдел", "Вырезать отдел", "Свойства...", "Вставить отдел", 
        "Экспортировать в Excel", "Добавить изменение", "Просмотреть историю"};

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

