using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Kadr.Controllers;
using Kadr.Data;
using System.Collections;
using Kadr.Data.Common;

namespace Kadr.UI.Frames
{
    public partial class KadrPostFrame : KadrBaseFrame
    {

        private PKCategory CurrentCategory
        {
            get
            {
                return (pKCategoryBindingSource.Current as PKCategory);
            }
        }

        public KadrPostFrame()
        {
            InitializeComponent();
        }


        public KadrPostFrame(object AObject)
        {
            InitializeComponent();
            FrameObject = AObject;
        }

        private void LoadPosts(ArrayList postFilters)
        {
            //фильтруем элементы 
            IEnumerable<Post> posts =
                KadrController.Instance.Model.Posts.OrderBy(post => post.PostName);
            List<Post> postList = new List<Post>();
            foreach (Post post in posts)
                if (postFilters.Contains((post as IObjectState).State()))
                {
                    postList.Add(post);
                }
            postBindingSource.DataSource = postList;
        }

        protected override void DoRefreshFrame()
        {
            LoadPosts(ObjectStateController.Instance.GetObjectStatesForFilter(tsbPostFilter, null));


            //ReportClass report = new ReportClass();
            ////ReportDocument
            //report.FileName = "D:\\main Projects\\kadr\\Kadr\\Kadr\\Reports\\CRSimpleReport.rpt";
            ////crystalReportViewer1.ReportSource = "C:\\Users\\tanyav.IST\\Desktop\\kadr\\Kadr\\Kadr\\Reports\\CRSimpleReport.rpt";
            //report.SetDataSource(KadrController.Instance.Model.Employees.Select(x => new { FirstName = x.FirstName, LastName = x.LastName, Otch = x.Otch, BirthPlace = x.BirthPlace, SexBit = x.SexBit }));
            //crystalReportViewer1.ReportSource = report;

        }

        private void AddPKCatBtn_Click(object sender, EventArgs e)
        {
            using (Kadr.UI.Common.PropertyGridDialogAdding<PKCategory> dlg =
            new Kadr.UI.Common.PropertyGridDialogAdding<PKCategory>())
            {
                dlg.UseInternalCommandManager = true;
                dlg.ObjectList = KadrController.Instance.Model.PKCategories;
                dlg.BindingSource = pKCategoryBindingSource;
                dlg.InitializeNewObject = (x) =>
                {
                    if ((dlg.SelectedObjects != null) && (dlg.SelectedObjects.Length == 1))
                    {
                        PKCategory prev = dlg.SelectedObjects[0] as PKCategory;
                        dlg.CommandManager.Execute(new UIX.Commands.GenericPropertyCommand<PKCategory, PKGroup>(x, "PKGroup", prev.PKGroup, null), this);
                        dlg.CommandManager.Execute(new UIX.Commands.GenericPropertyCommand<PKCategory, int>(x, "PKCategoryNumber", prev.PKCategoryNumber, null), this);
                    }
                    else
                    {
                        dlg.CommandManager.Execute(new UIX.Commands.GenericPropertyCommand<PKCategory, PKGroup>(x, "PKGroup", NullPKGroup.Instance, null), this);
                        dlg.CommandManager.Execute(new UIX.Commands.GenericPropertyCommand<PKCategory, int>(x, "PKCategoryNumber", 1, null), this);

                    }
                    dlg.CommandManager.Execute(new UIX.Commands.GenericPropertyCommand<PKCategory, int>(x, "PKSubCategoryNumber", 1, null), this);
                };

                dlg.ShowDialog();
                KadrController.Instance.DeleteModel();
                //RefreshFrame();
            }
 
        }

        private void EditPKCatBtn_Click(object sender, EventArgs e)
        {
            LinqActionsController<PKCategory>.Instance.EditObject(CurrentCategory, false);
        }

        private void DelPKCatBtn_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Удалить профессиональную категорию?", "АИС Штатное расписание", MessageBoxButtons.OKCancel)
                == DialogResult.OK)
            {
               // PKCategory delpkCat = CurrentCategory;
                LinqActionsController<PKCategory>.Instance.DeleteObject(CurrentCategory,
                     KadrController.Instance.Model.PKCategories, pKCategoryBindingSource);

            }

        }

        private void AddSalaryBtn_Click(object sender, EventArgs e)
        {
            using (Kadr.UI.Common.PropertyGridDialogAdding<PKCategorySalary> dlg =
                new Kadr.UI.Common.PropertyGridDialogAdding<PKCategorySalary>())
            {
                dlg.UseInternalCommandManager = true;
                dlg.ObjectList = KadrController.Instance.Model.PKCategorySalaries;
                dlg.oneObjectCreated = true;

                //dlg.BindingSource = postDecoratorBindingSource;
                dlg.InitializeNewObject = (x) =>
                {
                    dlg.CommandManager.Execute(new UIX.Commands.GenericPropertyCommand<PKCategorySalary, PKCategory>(x, "PKCategory", CurrentCategory, null), this);
                };

                dlg.ShowDialog();
                RefreshFrame();
            }

        }

        private void EditSalaryBtn_Click(object sender, EventArgs e)
        {
            PKCategory CurrentPKCategory = pKCategoryBindingSource.Current as Kadr.Data.PKCategory;
            if (CurrentPKCategory != null)
            {
                using (Kadr.UI.Forms.PlanStaffSalaryHistoryForm dlg =
                    new Kadr.UI.Forms.PlanStaffSalaryHistoryForm())
                {
                    dlg.SalaryObject = CurrentPKCategory;
                    dlg.ShowDialog();
                    RefreshFrame();
                }
            }
            /*if (CurrentCategory.HaveSalary)
            {
                LinqActionsController<PKCategorySalary>.Instance.EditObject(CurrentCategory.PKCategorySalary, false);
                RefreshFrame();
            }
            else
            {
                MessageBox.Show("Выбранной вами категории еще не назначен оклад.", "АИС Штатное расписание", MessageBoxButtons.OK);

            }*/
        }

        private void dgvPKCategory_DoubleClick(object sender, EventArgs e)
        {
            EditPKCatBtn_Click(sender, e);
        }

        private void AddPostBtn_Click(object sender, EventArgs e)
        {
            using (Kadr.UI.Common.PropertyGridDialogAdding<Post> dlg =
            new Kadr.UI.Common.PropertyGridDialogAdding<Post>())
            {
                dlg.UseInternalCommandManager = true;
                dlg.ObjectList = KadrController.Instance.Model.Posts;
                dlg.BindingSource = postBindingSource;
                dlg.InitializeNewObject = (x) =>
                {
                    dlg.CommandManager.Execute(new UIX.Commands.GenericPropertyCommand<Post, Guid>(x, "PostGUID", Guid.NewGuid(), null), this);
                    if ((dlg.SelectedObjects != null) && (dlg.SelectedObjects.Length == 1))
                    {
                        Post prev = dlg.SelectedObjects[0] as Post;
                        dlg.CommandManager.Execute(new UIX.Commands.GenericPropertyCommand<Post, PKCategory>(x, "PKCategory", prev.PKCategory, null), this);
                        dlg.CommandManager.Execute(new UIX.Commands.GenericPropertyCommand<Post, Category>(x, "Category", prev.Category, null), this);
                        dlg.CommandManager.Execute(new UIX.Commands.GenericPropertyCommand<Post, GlobalPrikaz>(x, "GlobalPrikaz", prev.GlobalPrikaz, null), this);


                    }
                    else
                    {
                        dlg.CommandManager.Execute(new UIX.Commands.GenericPropertyCommand<Post, PKCategory>(x, "PKCategory", NullPKCategory.Instance, null), this);
                        dlg.CommandManager.Execute(new UIX.Commands.GenericPropertyCommand<Post, GlobalPrikaz>(x, "GlobalPrikaz", NullGlobalPrikaz.Instance, null), this);
                        dlg.CommandManager.Execute(new UIX.Commands.GenericPropertyCommand<Post, Category>(x, "Category", NullCategory.Instance, null), this);
                    }
                };


                dlg.ShowDialog();
                //RefreshFrame();
            }
        }

        private void EditPostBtn_Click(object sender, EventArgs e)
        {
            LinqActionsController<Post>.Instance.EditObject((postBindingSource.Current as Post), false);
        }

        private void dgvPost_DoubleClick(object sender, EventArgs e)
        {
            EditPostBtn_Click(sender, e);

        }

        private void DelPostBtn_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Удалить должность?", "АИС Штатное расписание", MessageBoxButtons.OKCancel)
                == DialogResult.OK)
            {
                LinqActionsController<Post>.Instance.DeleteObject(postBindingSource.Current as Post,
                     KadrController.Instance.Model.Posts, postBindingSource);


            }


        }

        private void AddEmployeeBtn_Click(object sender, EventArgs e)
        {
            using (Kadr.UI.Common.PropertyGridDialogAdding<Employee> dlg =
                new Kadr.UI.Common.PropertyGridDialogAdding<Employee>())
            {
                dlg.UseInternalCommandManager = true;
                dlg.ObjectList = KadrController.Instance.Model.Employees;
                dlg.BindingSource = employeeBindingSource;
                dlg.InitializeNewObject = (x) =>
                {
                    dlg.CommandManager.Execute(new UIX.Commands.GenericPropertyCommand<Employee, Guid>(x, "GUID", Guid.NewGuid(), null), this);
                    if ((dlg.SelectedObjects != null) && (dlg.SelectedObjects.Length == 1))
                    {
                        Employee prev = dlg.SelectedObjects[0] as Employee;
                        dlg.CommandManager.Execute(new UIX.Commands.GenericPropertyCommand<Employee, SemPol>(x, "SemPol", prev.SemPol, null), this);
                        dlg.CommandManager.Execute(new UIX.Commands.GenericPropertyCommand<Employee, Grazd>(x, "Grazd", prev.Grazd, null), this);

                    }
                    else
                    {
                        dlg.CommandManager.Execute(new UIX.Commands.GenericPropertyCommand<Employee, SemPol>(x, "SemPol", NullSemPol.Instance, null), this);
                        dlg.CommandManager.Execute(new UIX.Commands.GenericPropertyCommand<Employee, Grazd>(x, "Grazd", NullGrazd.Instance, null), this);

                    }
                };


                dlg.ShowDialog();
                //RefreshFrame();
            }

        }

        private void EditEmployeeBtn_Click(object sender, EventArgs e)
        {
            LinqActionsController<Employee>.Instance.EditObject((employeeBindingSource.Current as Employee), false);
        }

        private void DelEmployeeBtn_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Удалить сотрудника?", "АИС Штатное расписание", MessageBoxButtons.OKCancel)
                 == DialogResult.OK)
            {
                LinqActionsController<Employee>.Instance.DeleteObject(employeeBindingSource.Current as Employee,
                     KadrController.Instance.Model.Employees, employeeBindingSource);
            }


        }

        private void btnBonus_Click(object sender, EventArgs e)
        {
            using (Kadr.UI.Forms.KadrBonusForm bonFrm =
                new Kadr.UI.Forms.KadrBonusForm())
            {
                bonFrm.BonusObject = postBindingSource.Current as Kadr.Data.Post;
                bonFrm.ShowDialog();
            }

        }


        private void tcDepartment_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tcDepartment.SelectedTab == tpPKCategory)
            {
                pKCategoryBindingSource.DataSource = KadrController.Instance.Model.PKCategories.OrderBy(pkc => pkc.PKGroup.GroupNumber).ThenBy(pkc => pkc.PKCategoryNumber).ThenBy(pkc => pkc.PKSubCategoryNumber);
            }

            if (tcDepartment.SelectedTab == tpEmployee)
            {
                employeeBindingSource.DataSource = KadrController.Instance.Model.Employees.OrderBy(empl => empl.LastName).ThenBy(empl => empl.FirstName).ThenBy(empl => empl.Otch);
            }

            if (tcDepartment.SelectedTab == tpBonusType)
            {
                LoadBonusTypes(ObjectStateController.Instance.GetObjectStatesForFilter(tsbBonusTypeFilter, null));
            }
        }

        private void LoadBonusTypes(ArrayList bntFilters)
        {
            //фильтруем элементы 
            IEnumerable<BonusType> bonusTypes =
                KadrController.Instance.Model.BonusTypes.OrderBy(bon => bon.BonusTypeName);
            List<BonusType> bnTList = new List<BonusType>();
            foreach (BonusType bonusType in bonusTypes)
                if (bntFilters.Contains((bonusType as IObjectState).State()))
                {
                    bnTList.Add(bonusType);
                }
            bonusTypeBindingSource.DataSource = bnTList;
        }

        private void btnPostToExcel_Click(object sender, EventArgs e)
        {
            Kadr.Controllers.ExcelExportController.Instance.ExportToExcel(dgvPost);
        }

        private void btnCategoriesToExcel_Click(object sender, EventArgs e)
        {
            Kadr.Controllers.ExcelExportController.Instance.ExportToExcel(dgvPKCategory);
        }

        private void btnEmployeeToExcel_Click(object sender, EventArgs e)
        {
            Kadr.Controllers.ExcelExportController.Instance.ExportToExcel(dgvEmployee);
        }

        private void tsbPostFilter_DropDownItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            LoadPosts(ObjectStateController.Instance.GetObjectStatesForFilter(tsbPostFilter, e));
        }

        private void btnAddBonusType_Click(object sender, EventArgs e)
        {
            using (Kadr.UI.Common.PropertyGridDialogAdding<BonusType> dlg =
                new Kadr.UI.Common.PropertyGridDialogAdding<BonusType>())
            {
                dlg.UseInternalCommandManager = true;
                dlg.ObjectList = KadrController.Instance.Model.BonusTypes;
                dlg.BindingSource = bonusTypeBindingSource;
                dlg.InitializeNewObject = (x) =>
                {
                    if ((dlg.SelectedObjects != null) && (dlg.SelectedObjects.Length == 1))
                    {
                        BonusType prev = dlg.SelectedObjects[0] as BonusType;
                        dlg.CommandManager.Execute(new UIX.Commands.GenericPropertyCommand<BonusType, FinancingSource>(x, "FinancingSource", prev.FinancingSource, null), this);
                        dlg.CommandManager.Execute(new UIX.Commands.GenericPropertyCommand<BonusType, BonusSuperType>(x, "BonusSuperType", prev.BonusSuperType, null), this);
                        dlg.CommandManager.Execute(new UIX.Commands.GenericPropertyCommand<BonusType, BonusMeasure>(x, "BonusMeasure", prev.BonusMeasure, null), this);
                        dlg.CommandManager.Execute(new UIX.Commands.GenericPropertyCommand<BonusType, Boolean>(x, "IsStaffRateable", prev.IsStaffRateable, null), this);
                        dlg.CommandManager.Execute(new UIX.Commands.GenericPropertyCommand<BonusType, Boolean>(x, "HasEnvironmentBonus", prev.HasEnvironmentBonus, null), this);
                    }
                    else
                    {
                        dlg.CommandManager.Execute(new UIX.Commands.GenericPropertyCommand<BonusType, FinancingSource>(x, "FinancingSource", NullFinancingSource.Instance, null), this);
                        dlg.CommandManager.Execute(new UIX.Commands.GenericPropertyCommand<BonusType, BonusSuperType>(x, "BonusSuperType", NullBonusSuperType.Instance, null), this);
                        dlg.CommandManager.Execute(new UIX.Commands.GenericPropertyCommand<BonusType, BonusMeasure>(x, "BonusMeasure", NullBonusMeasure.Instance, null), this);
                        dlg.CommandManager.Execute(new UIX.Commands.GenericPropertyCommand<BonusType, Boolean>(x, "IsStaffRateable", true, null), this);
                        dlg.CommandManager.Execute(new UIX.Commands.GenericPropertyCommand<BonusType, Boolean>(x, "HasEnvironmentBonus", true, null), this);

                    }
                };


                dlg.ShowDialog();
                //RefreshFrame();
            }
        }

        private void btnEditBonusType_Click(object sender, EventArgs e)
        {
            LinqActionsController<BonusType>.Instance.EditObject((bonusTypeBindingSource.Current as BonusType), false);
        }

        private void btnDelBonusType_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Удалить вид надбавки?", "АИС Штатное расписание", MessageBoxButtons.OKCancel)
                 == DialogResult.OK)
            {
                LinqActionsController<BonusType>.Instance.DeleteObject(bonusTypeBindingSource.Current as BonusType,
                     KadrController.Instance.Model.BonusTypes, bonusTypeBindingSource);
            }
        }

        private void btnExportToExcelBonusType_Click(object sender, EventArgs e)
        {
            Kadr.Controllers.ExcelExportController.Instance.ExportToExcel(dgvBonusTypes);
        }

        private void tsbBonusTypeFilter_DropDownItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            LoadBonusTypes(ObjectStateController.Instance.GetObjectStatesForFilter(tsbBonusTypeFilter, e));
        }

        

    }

    
        
}
