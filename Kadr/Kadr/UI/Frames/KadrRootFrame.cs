using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Kadr.Controllers;
using Kadr.Data;
using Kadr.KadrTreeView;
using Kadr.UI.Dialogs;
using Kadr.Data.Common;
using Reports.Frames;


namespace Kadr.UI.Frames
{
    public partial class KadrRootFrame : KadrBaseFrame
    {
        
        /// <summary>
        /// Отображаемый отдел
        /// </summary>
        public Kadr.Data.Dep Department                    
        {
            get 
            {
                if (this.FrameNodeObject != null)
                    return (this.FrameNodeObject as RootNodeObject).Department;
                else
                    return null;
                
            }
        }

        /// <summary>
        /// Настройки по умолчанию фильтра надбавок
        /// </summary>
        public ArrayList BonusFilterSetting { get; set; }

        private ArrayList depFilterSetting;

        /// <summary>
        /// Настройки по умолчанию фильтра по отделам
        /// </summary>
        public ArrayList DepFilterSetting 
        {
            get
            {
                return depFilterSetting;
            }
            set
            {
                depFilterSetting = value;
                ObjectStateController.Instance.GetFilterForObjectState(tsbDepFilter, DepFilterSetting);
                LoadSprav(ObjectStateController.Instance.GetObjectStatesForFilter(tsbDepFilter, null));
            }
        }

        private ArrayList staffFilterSetting;

        /// <summary>
        /// Настройки по умолчанию фильтра по штатам
        /// </summary>
        public ArrayList StaffFilterSetting
        {
            get
            {
                return staffFilterSetting;
            }
            set
            {
                staffFilterSetting = value;
                ObjectStateController.Instance.GetFilterForObjectState(tspPlanStaffFilter, StaffFilterSetting);
                ObjectStateController.Instance.GetFilterForObjectState(tspFactStaffFilter, StaffFilterSetting);
                ObjectStateController.Instance.GetFilterForObjectState(tspHourFactStaffFilter, StaffFilterSetting);
                LoadPlanStaff(ObjectStateController.Instance.GetObjectStatesForFilter(tspPlanStaffFilter, null));
            }
        }

        /// <summary>
        /// текущая запись штатного расписания
        /// </summary>
        //private PlanStaff CurrentPlanStaff
        //{
        //    get
        //    {
        //        return planStaffBindingSource.
        //    }
        //}

        public KadrRootFrame()
        {
            InitializeComponent();
        }

        public KadrRootFrame(object AObject)
        {
            InitializeComponent();
            FrameObject = AObject;
        }


        #region LoadData

        private void LoadSprav(ArrayList depFilters)
        {
            if (Department != null)
            {
                //departmentBindingSource.DataSource = KadrController.Instance.Model.Departments.Where(dep => dep.idManagerDepartment == Department.id).ToArray().OrderBy(dep => dep.DepartmentName); 
                    //KadrController.Instance.Model.Deps.ToArray().Where(dep => dep.LastChange.idManagerDepartment == Department.id).ToArray().OrderBy(dep => dep.DepartmentName);
                    //Department.DepartmentHistories1.Where(dep => dep.Dep.dateExit == null).OrderBy( dep => dep.DepartmentName);

                //фильтруем элементы
                IEnumerable<Dep> departments = KadrController.Instance.Model.Deps.ToArray().Where(dep => dep.idManagerDepartment == Department.id).ToArray().OrderBy(dep => dep.DepartmentName); 
                ArrayList deps = new ArrayList();
                foreach (Dep dep in departments)
                    if (depFilters.Contains((dep as IObjectState).State()))
                    {
                        deps.Add(dep);
                    }
                departmentBindingSource.DataSource = deps;
                
            }
        }

        private void LoadTimeSheets()
        {
            TimeSheet SelectedTimeSheet = cbTimeSheet.SelectedItem as TimeSheet;
            //timeSheetBindingSource.DataSource = KadrController.Instance.Model.TimeSheets.OrderBy(ts => ts.TimeSheetYear).ThenBy(ts => ts.TimeSheetMonth);
            cbTimeSheet.Items.Clear();
            foreach (TimeSheet timeSheet in KadrController.Instance.Model.TimeSheets.Where(ts => ts.TimeSheetYear >= (DateTime.Today.Year-1)).OrderByDescending(ts => ts.TimeSheetYear).ThenByDescending(ts => ts.TimeSheetMonth))
            {
                cbTimeSheet.Items.Add(timeSheet);
            }
            if (SelectedTimeSheet != null)
            {
                cbTimeSheet.SelectedItem = SelectedTimeSheet;
            }
            if (cbTimeSheet.SelectedItem == null)
                cbTimeSheet.SelectedItem = TimeSheet.CurrentTimeSheet();
        }

        private void LoadTimeNorm()
        {
            departmentTimeNormBindingSource.DataSource =
                KadrController.Instance.Model.DepartmentTimeNorms.Where(tnorm => tnorm.Dep == Department);
        }



        private void LoadPlanStaff()
        {
            tspPlanStaffFilter_DropDownItemClicked(null, null);
        }

        private void LoadFactStaff()
        {
            tspFactStaffFilter_DropDownItemClicked(null, null);
        }

        private void LoadPlanStaff(ArrayList planStaffFilters)
        {

            if (Department != null)
            {
                //фильтруем элементы
                IEnumerable<PlanStaff> planStaff = KadrController.Instance.Model.PlanStaffs.Where(planSt => planSt.Dep == Department).OrderBy(planSt => planSt.PlanStaffHistories.OrderByDescending(plStH => plStH.DateBegin).FirstOrDefault().FinancingSource.OrderBy).ThenBy(planSt => planSt.Post.Category.OrderBy).ThenByDescending(planSt => planSt.Post.PKCategory.PKGroup.GroupNumber).ThenByDescending(planSt => planSt.Post.PKCategory.PKCategoryNumber).ThenByDescending(plSt => plSt.Post.ManagerBit).ThenBy(planSt => planSt.Post.PostName);
                ArrayList plStaff = new ArrayList();
                foreach (PlanStaff plSt in planStaff)
                    if (planStaffFilters.Contains((plSt as IObjectState).State()))
                    {
                        plStaff.Add(plSt);
                    }
                planStaffBindingSource.DataSource = plStaff;
             }
        }

        private void LoadHourFactStaff()
        {
            tspHourFactStaffFilter_DropDownItemClicked(null, null);
            LoadPPSHourStatusBar();
        }

        private void LoadFactStaff(ArrayList factStaffFilters)
        {
            if ((planStaffBindingSource.Current as Kadr.Data.PlanStaff) != null)
            {

                //фильтруем элементы 
                IEnumerable<FactStaff> factStaff =
                    KadrController.Instance.Model.FactStaffs.Where(
                        fact => ((fact.PlanStaff == (planStaffBindingSource.Current as Kadr.Data.PlanStaff)))).OrderBy(
                            plSt => plSt.DateEnd).ThenBy(plSt => plSt.Employee.LastName).ThenBy(
                                plSt => plSt.Employee.FirstName);
                List<FactStaff> fcStaff = new List<FactStaff>();
                foreach (FactStaff fcSt in factStaff)
                    if (factStaffFilters.Contains((fcSt as IObjectState).State()))
                    {
                        fcStaff.Add(fcSt);
                    }
                factStaffBindingSource.DataSource = fcStaff;
            }
        }

        /// <summary>
        /// загрузка статуса для вкладки почасовики
        /// </summary>
        public void LoadPPSHourStatusBar()
        {
            decimal budgetCount = 0, overbudgetCount = 0;
            decimal budgetHourCount = 0, overbudgetHourCount = 0;
            decimal busyBudgetHourCount = 0, busyOverbudgetHourCount = 0;
            IEnumerable<Dep> deps = KadrController.Instance.Model.Deps.Where(dep => dep == Department).ToArray().Where(dep => dep.ManagerDepartment != null);
            if (deps.Count() == 0)
            {
                tslPPSVacations.Text = "";
                return;
                //deps = KadrController.Instance.Model.Deps;
            }
          //вычисляем кол-во вакантных ставок ППС по Источникам финансирования
            foreach (Dep department in deps)
            {
                foreach (PlanStaff plStaff in department.PlanStaffs)
                {
                    if ((plStaff.Category == Kadr.Data.Category.PPSCategory) && ((plStaff as IObjectState).State() == ObjectState.Current))
                    {
                        if (plStaff.FinancingSource == Kadr.Data.FinancingSource.budgetFinancingSource)
                            budgetCount += plStaff.FreeStaffCount;

                        if (plStaff.FinancingSource == Kadr.Data.FinancingSource.extrabudgetFinancingSource)
                            overbudgetCount += plStaff.FreeStaffCount;
                    }
                }
            }
            budgetHourCount = +Department.GetTimeNormForFinSource(Kadr.Data.FinancingSource.budgetFinancingSource) * budgetCount;
            overbudgetHourCount = +Department.GetTimeNormForFinSource(Kadr.Data.FinancingSource.extrabudgetFinancingSource) * overbudgetCount;
            busyBudgetHourCount = +Department.GetBusyHourCountForFinSource(Kadr.Data.FinancingSource.budgetFinancingSource);
            busyOverbudgetHourCount = +Department.GetBusyHourCountForFinSource(Kadr.Data.FinancingSource.extrabudgetFinancingSource);
            tslPPSVacations.Text = "ППС вакантно: бюджет " + budgetCount.ToString() + " ставок, " + Convert.ToDecimal(string.Format("{0:0.0000}", budgetHourCount))
                        + " / " + Convert.ToDecimal(string.Format("{0:0.00}", busyBudgetHourCount))
                 + " часов, внебюджет " + overbudgetCount.ToString() + " ставок, " + Convert.ToDecimal(string.Format("{0:0.0000}",overbudgetHourCount))
                        + " / " + Convert.ToDecimal(string.Format("{0:0.00}", busyOverbudgetHourCount)) + " часов";


        }

        private void LoadHourFactStaff(ArrayList factStaffFilters)
        {
 
                //фильтруем элементы 
                IEnumerable<FactStaff> factStaff =
                    KadrController.Instance.GetHourFactStaff(Department);
                List<FactStaff> fcStaff = new List<FactStaff>();
                foreach (FactStaff fcSt in factStaff)
                    if (factStaffFilters.Contains((fcSt as IObjectState).State()))
                    {
                        fcStaff.Add(fcSt);
                    }
                hourFactStaffBindingSource.DataSource = fcStaff;
        }


        private void LoadContractStaff(ArrayList factStaffFilters)
        {
            //фильтруем элементы 
            IEnumerable<FactStaff> factStaff =
                KadrController.Instance.GetHourFactStaff(Department);
            List<FactStaff> fcStaff = new List<FactStaff>();
            foreach (FactStaff fcSt in factStaff)
                if (factStaffFilters.Contains((fcSt as IObjectState).State()))
                {
                    fcStaff.Add(fcSt);
                }
            ContractStaffBindingSource.DataSource = fcStaff;
        }

        #endregion


        protected override void DoRefreshFrame()
        {
            //ObjectStateController.Instance.GetFilterForObjectState(tsbDepFilter, DepFilterSetting);
            //tcDepartment_SelectedIndexChanged(null, null);
            IsModified = false;
        }



        private void planStaffBindingSource_PositionChanged(object sender, EventArgs e)
        {
            //загружаем соответствующиее распределение штатов
            LoadFactStaff();
        }



        private void btnCancel_Click(object sender, EventArgs e)
        {
            DoCancel();
        }

       private void btnAddPlanStaff_Click(object sender, EventArgs e)
        {           
           using (Kadr.UI.Common.PropertyGridDialogAdding<PlanStaff>dlg = 
                new Kadr.UI.Common.PropertyGridDialogAdding<PlanStaff>())
            {
                dlg.UseInternalCommandManager = true;
                dlg.ObjectList = KadrController.Instance.Model.PlanStaffs;
                dlg.BindingSource = planStaffBindingSource;
                dlg.PrikazButtonVisible = true;
                dlg.InitializeNewObject = (x) => 
                {
                    PlanStaffHistory plStHistory = new PlanStaffHistory();
                    //dlg.CommandManager.Execute(new UIX.Commands.GenericPropertyCommand<PlanStaff, Prikaz>(x, "Prikaz", NullPrikaz.Instance, null), this);                       
                    dlg.CommandManager.Execute(new UIX.Commands.GenericPropertyCommand<PlanStaff, Dep>(x, "Dep", Department, null), this);
                    dlg.CommandManager.Execute(new UIX.Commands.GenericPropertyCommand<PlanStaff, Post>(x, "Post", NullPost.Instance, null), this);
                    //dlg.CommandManager.Execute(new UIX.Commands.GenericPropertyCommand<PlanStaff, WorkShedule>(x, "WorkShedule", KadrController.Instance.Model.WorkShedules.Where(wShed => wShed.id == 1).FirstOrDefault(), null), this);
                    if ((dlg.SelectedObjects != null) && (dlg.SelectedObjects.Length == 1))
                    {
                        PlanStaff prev = dlg.SelectedObjects[0] as PlanStaff;
                        dlg.CommandManager.Execute(new UIX.Commands.GenericPropertyCommand<PlanStaffHistory, Prikaz>(plStHistory, "Prikaz", prev.PrikazBegin, null), this);
                        dlg.CommandManager.Execute(new UIX.Commands.GenericPropertyCommand<PlanStaffHistory, decimal>(plStHistory, "StaffCount", prev.StaffCount, null), this);
                        dlg.CommandManager.Execute(new UIX.Commands.GenericPropertyCommand<PlanStaffHistory, FinancingSource>(plStHistory, "FinancingSource", prev.FinancingSource, null), this);
                        dlg.CommandManager.Execute(new UIX.Commands.GenericPropertyCommand<PlanStaffHistory, DateTime>(plStHistory, "DateBegin", prev.DateBegin, null), this);
                    }
                    else
                    {
                        dlg.CommandManager.Execute(new UIX.Commands.GenericPropertyCommand<PlanStaffHistory, Prikaz>(plStHistory, "Prikaz", NullPrikaz.Instance, null), this);
                        dlg.CommandManager.Execute(new UIX.Commands.GenericPropertyCommand<PlanStaffHistory, FinancingSource>(plStHistory, "FinancingSource", NullFinancingSource.Instance, null), this);
                    }
                    dlg.CommandManager.Execute(new UIX.Commands.GenericPropertyCommand<PlanStaffHistory, PlanStaff>(plStHistory, "PlanStaff", x, null), this);
                };

                dlg.UpdateObjectList = () => 
                {
                    dlg.ObjectList = KadrController.Instance.Model.PlanStaffs;
                };
     
                dlg.ShowDialog();
                LoadPlanStaff();
            }


        }

       private void EditPlanStaffBtn_Click(object sender, EventArgs e)
       {
           LinqActionsController<PlanStaff>.Instance.EditObject(planStaffBindingSource.Current as Kadr.Data.PlanStaff, true);
       }

       private void AddFactStaffBtn_Click(object sender, EventArgs e)
       {
           KadrController.Instance.AddFactStaff(factStaffBindingSource, planStaffBindingSource.Current as PlanStaff);
           LoadFactStaff();
       }

       private void EditFactStaffBtn_Click(object sender, EventArgs e)
       {
           FactStaff currentFactStaff = factStaffBindingSource.Current as Kadr.Data.FactStaff;
           if (currentFactStaff != null)
           {
               if (currentFactStaff.FundingCenter == null)
                    currentFactStaff.FundingCenter = NullFundingCenter.Instance;
               if (currentFactStaff.FactStaffReplacement != null)
                   LinqActionsController<FactStaffReplacement>.Instance.EditObject(
                       currentFactStaff.FactStaffReplacement, true);
               else
                   LinqActionsController<FactStaff>.Instance.EditObject(
                       currentFactStaff, true);
           }
       }



       private void DelPlanStaffBtn_Click(object sender, EventArgs e)
       {
           PlanStaff CurrentPlanStaff = planStaffBindingSource.Current as Kadr.Data.PlanStaff;

           if (CurrentPlanStaff == null)
           {
               MessageBox.Show("Не выбрана удаляемая запись штатного расписания.", "АИС \"Штатное расписание\"");
               return;
           }

           /*//если уже задана история (более одной записи), то нельзя удалить надбавку
           if (CurrentPlanStaff.PlanStaffHistory.Count > 1)
           {
               MessageBox.Show("У заданной записи есть история изменений. При удалении записи она тоже будет удалена.", "АИС \"Штатное расписание\"");
               return;
           }
           */
           if (MessageBox.Show("Удалить запись штатного расписания?", "АИС Штатное расписание", MessageBoxButtons.OKCancel)
               != DialogResult.OK)
           {
               return;
           }

           KadrController.Instance.Model.PlanStaffHistories.DeleteAllOnSubmit(KadrController.Instance.Model.PlanStaffHistories.Where(plStHist => plStHist.PlanStaff == CurrentPlanStaff));

           LinqActionsController<PlanStaff>.Instance.DeleteObject(CurrentPlanStaff,
                KadrController.Instance.Model.PlanStaffs, planStaffBindingSource);
       }

       private void DelFactStaffBtn_Click(object sender, EventArgs e)
       {
           FactStaff CurrentFactStaff = factStaffBindingSource.Current as Kadr.Data.FactStaff;

           if (CurrentFactStaff == null)
           {
               MessageBox.Show("Не выбрана удаляемая запись штатного расписания.", "АИС \"Штатное расписание\"");
               return;
           }

           /*//если уже задана история (более одной записи), то нельзя удалить надбавку
           if (CurrentFactStaff.PlanStaffHistory.Count > 1)
           {
               MessageBox.Show("У заданной записи есть история изменений. При удалении записи она тоже будет удалена.", "АИС \"Штатное расписание\"");
               return;
           }*/

         
           
           if (MessageBox.Show("Удалить сотрудника?", "АИС Штатное расписание", MessageBoxButtons.OKCancel)
               == DialogResult.OK)
           {


               if (CurrentFactStaff.FactStaffReplacements.Count>0)
               {
                   foreach (FactStaffReplacement fcStRepl in CurrentFactStaff.FactStaffReplacements)
                   {
                       KadrController.Instance.Model.FactStaffReplacements.DeleteOnSubmit(fcStRepl);
                   }
                   KadrController.Instance.Model.SubmitChanges();
               }
               LinqActionsController<FactStaff>.Instance.DeleteObject(CurrentFactStaff,
                        KadrController.Instance.Model.FactStaffs, factStaffBindingSource);
           }

       }

       private void TransferFactStaffBtn_Click(object sender, EventArgs e)
       {
           if (dgvFactStaff.SelectedRows.Count < 1)
           {
               MessageBox.Show("Выберите сотрудников для перевода!");
               return;
           }

           //проверяем, чтобы переводимые еще не были уволены
           foreach (DataGridViewRow selectedRow in dgvFactStaff.SelectedRows)
           {
               //в текущей записи выставляем приказ о переводе и дату перевода
               FactStaff currentFactStaff = (selectedRow.DataBoundItem as FactStaff);
               if (currentFactStaff.Prikaz != null)
               {
                   MessageBox.Show("Cотрудник " + currentFactStaff.Employee.ToString() + " уже уволен!");
                   return;
               }
           }

           using (FactStaffTransfer dlg = new FactStaffTransfer())
           {
               dlg.CurentPlanStaff = planStaffBindingSource.Current as Kadr.Data.PlanStaff;
               //dlg.Department = Department;
               dlg.LoadDepartments();
               dlg.Department = Department.FullDepartment;
               dlg.ShowDialog();
               //переводим
                if (dlg.DialogResult == DialogResult.OK)
                {
                    try
                    {
                        try
                        {
                            //переводим по одному с помощью хранимой процедуры
                            foreach (DataGridViewRow selectedRow in dgvFactStaff.SelectedRows)
                            {
                                FactStaff currentFactStaff = (selectedRow.DataBoundItem as FactStaff);
                                KadrController.Instance.Model.TransferFactStaff(currentFactStaff.id, dlg.NewPlanStaff.id,
                                    dlg.TransferPrikaz.id, dlg.TransferData, dlg.TransferWithBonus);
                            }
                        }
                        catch (Exception exp)
                        {
                            MessageBox.Show(exp.Message, "АИС \"Штатное расписание\"");
                        }
                    }
                    finally
                    {
                        KadrController.Instance.DeleteModel();
                        LoadFactStaff();
                    }
                }
           }
       }

       private void dgvPlanStaff_DoubleClick(object sender, EventArgs e)
       {
           EditPlanStaffBtn_Click(sender, e);
       }

       private void dgvFactStaff_DoubleClick(object sender, EventArgs e)
       {
           EditFactStaffBtn_Click(sender, e);

       }

 
       private void btnEditSalary_Click(object sender, EventArgs e)
       {
           PlanStaff CurrentPlanStaff = planStaffBindingSource.Current as Kadr.Data.PlanStaff;
           if (CurrentPlanStaff != null)
           {
               using (Kadr.UI.Forms.PlanStaffSalaryHistoryForm dlg =
                   new Kadr.UI.Forms.PlanStaffSalaryHistoryForm())
               {
                   dlg.SalaryObject = CurrentPlanStaff;
                   dlg.ShowDialog();
                   RefreshFrame();
               }
           }
       }

       private void btnBonus_Click(object sender, EventArgs e)
       {
           using (Kadr.UI.Forms.KadrBonusForm bonFrm =
               new Kadr.UI.Forms.KadrBonusForm())
           {
               bonFrm.BonusObject = planStaffBindingSource.Current as Kadr.Data.PlanStaff;
               ObjectStateController.Instance.GetFilterForObjectState(bonFrm.tsbBonusFilter, BonusFilterSetting);
               bonFrm.ShowDialog();
           }

       }

       private void btnFactStaffBonus_Click(object sender, EventArgs e)
       {
           using (Kadr.UI.Forms.KadrBonusForm bonFrm =
                new Kadr.UI.Forms.KadrBonusForm())
           {
               bonFrm.BonusObject = factStaffBindingSource.Current as Kadr.Data.FactStaff;
               ObjectStateController.Instance.GetFilterForObjectState(bonFrm.tsbBonusFilter, BonusFilterSetting);
               bonFrm.ShowDialog();
           }

       }

       private void AddReplacementBtn_Click(object sender, EventArgs e)
       {
           if (factStaffBindingSource.Current == null)
           {
               MessageBox.Show("Выберите сотрудника, которого нужно заместить.", "АИС Штатное расписание", MessageBoxButtons.OK);
               return;
           }

           if ((factStaffBindingSource.Current as FactStaff).Prikaz!=null)
           {
               MessageBox.Show("Совмещаемый сотрудник уже уволен!", "АИС Штатное расписание", MessageBoxButtons.OK);
               return;
           }

           FactStaff currentFactStaff = factStaffBindingSource.Current as FactStaff;

            using (Kadr.UI.Common.PropertyGridDialogAdding<FactStaffReplacement> dlg =
                new Kadr.UI.Common.PropertyGridDialogAdding<FactStaffReplacement>())
            {
                dlg.ObjectList = KadrController.Instance.Model.FactStaffReplacements;
                dlg.BindingSource = null;
                dlg.UseInternalCommandManager = true;
                dlg.InitializeNewObject = (x) =>
                {
                    FactStaff factStaff = new FactStaff();
                    FactStaffHistory fcStHistory = new FactStaffHistory();
                    dlg.CommandManager.Execute(new UIX.Commands.GenericPropertyCommand<FactStaff, PlanStaff>(factStaff, "PlanStaff", currentFactStaff.PlanStaff, null), this);
                    dlg.CommandManager.Execute(new UIX.Commands.GenericPropertyCommand<FactStaffHistory, WorkType>(fcStHistory, "WorkType", KadrController.Instance.Model.WorkTypes.Where(wtp => wtp.IsReplacement).FirstOrDefault(), null), this);
                    dlg.CommandManager.Execute(new UIX.Commands.GenericPropertyCommand<FactStaff, Employee>(factStaff, "Employee", NullEmployee.Instance, null), this);
                    dlg.CommandManager.Execute(new UIX.Commands.GenericPropertyCommand<FactStaffHistory, Prikaz>(fcStHistory, "Prikaz", NullPrikaz.Instance, null), this);
                    dlg.CommandManager.Execute(new UIX.Commands.GenericPropertyCommand<FactStaff, bool>(factStaff, "IsReplacement", true, null), this);
                    dlg.CommandManager.Execute(new UIX.Commands.GenericPropertyCommand<FactStaffHistory, FactStaff>(fcStHistory, "FactStaff", factStaff, null), this);

                    //вычисляем то кол-во ставок, которое еще не замещено
                    decimal ReplStaffCount = currentFactStaff.StaffCount;
                    foreach (FactStaffReplacement repl in currentFactStaff.FactStaffReplacements)
                    {
                        if (repl.FactStaff1.Prikaz == null)
                            ReplStaffCount -= repl.FactStaff1.StaffCount;
                    }
                    dlg.CommandManager.Execute(new UIX.Commands.GenericPropertyCommand<FactStaffHistory, decimal>(fcStHistory, "StaffCount", ReplStaffCount, null), this);

                    dlg.CommandManager.Execute(new UIX.Commands.GenericPropertyCommand<FactStaffReplacement, FactStaff>(x, "MainFactStaff", factStaff, null), this);
                    dlg.CommandManager.Execute(new UIX.Commands.GenericPropertyCommand<FactStaffReplacement, FactStaff>(x, "ReplacedFactStaff", currentFactStaff, null), this);
                    if ((dlg.SelectedObjects != null) && (dlg.SelectedObjects.Length == 1))
                    {
                        FactStaffReplacement prev = dlg.SelectedObjects[0] as FactStaffReplacement;
                        dlg.CommandManager.Execute(new UIX.Commands.GenericPropertyCommand<FactStaffReplacement, FactStaffReplacementReason>(x, "FactStaffReplacementReason", prev.FactStaffReplacementReason, null), this);
                    }
                    else
                    {
                        dlg.CommandManager.Execute(new UIX.Commands.GenericPropertyCommand<FactStaffReplacement, FactStaffReplacementReason>(x, "FactStaffReplacementReason", NullFactStaffReplacementReason.Instance, null), this);
                    }

                };
                dlg.ShowDialog();
            }
            LoadFactStaff();
       
       }

       private void tcDepartment_SelectedIndexChanged(object sender, EventArgs e)
       {

           if (tcDepartment.SelectedTab == tpDepartments)
           {
               LoadSprav(ObjectStateController.Instance.GetObjectStatesForFilter(tsbDepFilter, null));
           } 
           if (tcDepartment.SelectedTab == tpStaff)
           {
               LoadPlanStaff();
           }

           if (tcDepartment.SelectedTab == tpHourStaff)
           {
               //отображаем отдел в зависисмости от выбранного узла (если корневой, то отображаем)
               dgvHourFactStaff.Columns["Dep"].Visible = Department.ManagerDepartment == null;
               AddHourFactStaffBtn.Enabled = !dgvHourFactStaff.Columns["Dep"].Visible;
               tsbAddFacrStaffContractHour.Enabled = !dgvHourFactStaff.Columns["Dep"].Visible;
               LoadHourFactStaff();
           }

           if (tcDepartment.SelectedTab == tpDepEmplReport)
           {
               depEmplReportFrame1.ReportParam = Department.id;
               //depEmplCountReportFrame1.reportViewer1.RefreshReport();
           }

            if (tcDepartment.SelectedTab == tpTimeSheet)
           {
               LoadTimeSheets();
           }

           if (tcDepartment.SelectedTab == tpTimeNorm)
           {
               LoadTimeNorm();
           }

       }
  
       private void tspPlanStaffFilter_DropDownItemClicked(object sender, ToolStripItemClickedEventArgs e)
       {
           LoadPlanStaff(ObjectStateController.Instance.GetObjectStatesForFilter(tspPlanStaffFilter,e));

       }

       private void tspFactStaffFilter_DropDownItemClicked(object sender, ToolStripItemClickedEventArgs e)
       {
           LoadFactStaff(ObjectStateController.Instance.GetObjectStatesForFilter(tspFactStaffFilter, e));
       }

       private void tsbTimeSheets_Click(object sender, EventArgs e)
       {
           using (Kadr.UI.Forms.TimeSheetsForm timeSheets = new Forms.TimeSheetsForm())
           {
               if (cbTimeSheet.SelectedItem == null)
                   timeSheets.CurrentYear = DateTime.Today.Year;
               else     
                   timeSheets.CurrentYear = (cbTimeSheet.SelectedItem as TimeSheet).TimeSheetYear;
               timeSheets.ShowDialog();
           }
           LoadTimeSheets();
       }

       private void LoadTimeSheetRecords()
       {
           timeSheetFSWorkingDaysBindingSource.DataSource = 
               TimeSheet.DepsTShRecords(KadrController.Instance.Model, Department.id, (cbTimeSheet.SelectedItem as TimeSheet).id).OrderBy(tswd =>
                       tswd.FactStaff.Employee.LastName).ThenBy(tswd => tswd.FactStaff.Employee.FirstName);
       }

       private void cbTimeSheet_SelectedIndexChanged(object sender, EventArgs e)
       {
           LoadTimeSheetRecords();
       }

       private void dgvTimeSheetFS_DoubleClick(object sender, EventArgs e)
       {
           if (timeSheetFSWorkingDaysBindingSource.Current == null)
            {
                MessageBox.Show("Выберите запись для редактирования!");
                return;
            }
           if ((timeSheetFSWorkingDaysBindingSource.Current as TimeSheetFSWorkingDay).TimeSheet.IsClosed == true)
           {
               MessageBox.Show("Табель рабочего времени закрыт для редактирования!");
               return;
           }

           LinqActionsController<TimeSheetFSWorkingDay>.Instance.EditObject(timeSheetFSWorkingDaysBindingSource.Current as Kadr.Data.TimeSheetFSWorkingDay, true);
       }

       private void tsbRefreshTimeSheet_Click(object sender, EventArgs e)
       {
           if (cbTimeSheet.SelectedItem == null)
           {
               MessageBox.Show("Выберите табель!");
               return;
           }

           (cbTimeSheet.SelectedItem as TimeSheet).UpdateDepartmentsTimeSheet(Department);
           LoadTimeSheetRecords();
       }

       private void dgvTimeSheetFS_CellClick(object sender, DataGridViewCellEventArgs e)
       {
           if (timeSheetFSWorkingDaysBindingSource.Current == null)
           {
               return;
           }

           
           //зафиксировано - устанавливаем
           if ((dgvTimeSheetFS.Columns[e.ColumnIndex].DataPropertyName == "IsClosed"))
           {
                if ((timeSheetFSWorkingDaysBindingSource.Current as TimeSheetFSWorkingDay).TimeSheet.IsClosed == true)
               {
                   MessageBox.Show("Табель рабочего времени закрыт для редактирования!");
                   return;
               }
              (timeSheetFSWorkingDaysBindingSource.Current as TimeSheetFSWorkingDay).IsClosed =
                   !(timeSheetFSWorkingDaysBindingSource.Current as TimeSheetFSWorkingDay).IsClosed;
               KadrController.Instance.Model.SubmitChanges();
           }
       }

       private void tsbCheckAll_Click(object sender, EventArgs e)
       {
           
           foreach (TimeSheetFSWorkingDay TSRecord in KadrController.Instance.Model.TimeSheetFSWorkingDays.Where(tswd => 
               (tswd.TimeSheet == (cbTimeSheet.SelectedItem as TimeSheet)) &&
               (tswd.FactStaff.PlanStaff.Dep == Department)))
           {
               TSRecord.IsClosed = true;
           }
           KadrController.Instance.Model.SubmitChanges();    
       }

       /*private void tsbCreateTimeSheet_Click(object sender, EventArgs e)
       {
            if (cbTimeSheet.SelectedItem == null)
            {
                MessageBox.Show("Выберите табель!");
                return;
            }

            if ((cbTimeSheet.SelectedItem as TimeSheet).TimeSheetFSWorkingDays.Where(tsRecord => tsRecord.FactStaff.PlanStaff.Department == Department).Count() > 0)
            {
                if (MessageBox.Show("При пересоздании табеля все ваши изменения будут потеряны. Вы хотите продолжить?", "АИС Штатное расписание", MessageBoxButtons.OKCancel)
                    == DialogResult.Cancel)
                {
                    return; 
                }
            }

            (cbTimeSheet.SelectedItem as TimeSheet).AddDepartmentsTShRecords(Department);
            LoadTimeSheetRecords();
        }*/

       public IEnumerable<Dep> GetDepList(Dep department)
       {
           return KadrController.Instance.Model.Deps.Where(dep => dep == department);
       }

       private void btnDelRecords_Click(object sender, EventArgs e)
       {
           TimeSheet CurrentTimeSheet = cbTimeSheet.SelectedItem as TimeSheet;
           if (CurrentTimeSheet == null)
           {
               MessageBox.Show("Выберите табель!");
               return;
           }

            if (MessageBox.Show("Удалить все записи табеля?", "АИС Штатное расписание", MessageBoxButtons.OKCancel)
                == DialogResult.Cancel)
            {
                return;
            }

            CurrentTimeSheet.DeleteDepsTShRecords(Department);
            KadrController.Instance.Model.SubmitChanges(); 

       }

       

        private void tcAverageStaff_SelectedIndexChanged(object sender, EventArgs e)
       {
           if (tcDepartment.SelectedTab == tpStaffAverage)
           {
               Reports.Frames.ReportBaseFrameForYear CurrentFrame = null;
               if (tcAverageStaff.SelectedTab == tpCategoryAverage)
               {
                   CurrentFrame = depCategoryAverageStaff1;
                   //depCategoryAverageStaff1. .ReportParam = Department.id;
                   //depCategoryAverageStaff1.SelectedYear = Convert.ToInt32(cbYear.SelectedItem);
                   
               }

               if (tcAverageStaff.SelectedTab == tpTypeWorkAverage)
               {
                   CurrentFrame = DepartmentAverageStaff1;
                   //if (DepartmentAverageStaff1.ReportParam != Department.id)
                   //DepartmentAverageStaff1.ReportParam = Department.id;

                   //DepartmentAverageStaff1.WithSubReports = chbWithSubDeps.Checked;
               }

               if (tcAverageStaff.SelectedTab == tpCategoryVPOAverage)
               {
                   CurrentFrame = depCategoryAverageStaff2;
                   //if (depPostAverageStaffFrame1.ReportParam != Department.id)
                   //depPostAverageStaffFrame1.ReportParam = Department.id;

               }

               if ((CurrentFrame != null))
                    CurrentFrame.UpdateReportParams(Convert.ToInt32(cbYear.SelectedItem), Department.id, chbWithSubDeps.Checked);
            }
 
       }

       private void KadrRootFrame_Load(object sender, EventArgs e)
       {
           cbYear.Items.Clear();
           cbYear.Items.AddRange(KadrController.Instance.Model.TimeSheets.Select(ts => ts.TimeSheetYear as Object).Distinct().OrderByDescending(ts => ts as int?).ToArray());
           cbYear.SelectedItem = DateTime.Today.Year;
           if ((cbYear.SelectedItem == null) && (cbYear.Items.Count > 0))
               cbYear.SelectedItem = cbYear.Items[0];
           dtpPeriodBegin.Value = DateTime.Today.AddDays(-DateTime.Today.Day + 1);
           dtpPeriodEnd.Value = DateTime.Today;
           dtpBonRepPeriodBegin.Value = DateTime.Today.AddDays(-DateTime.Today.Day + 1);
           dtpBonRepPeriodEnd.Value = DateTime.Today;
           dtpStChPeriodBegin.Value = DateTime.Today.AddDays(-DateTime.Today.Day + 1);
           dtpStChPeriodEnd.Value = DateTime.Today;
           dtpErrorsPeriodBegin.Value = DateTime.Today.AddDays(-DateTime.Today.Day + 1);
           dtpErrorsPeriodEnd.Value = DateTime.Today;
           tcDepartment_SelectedIndexChanged(null, null);


           depCategoryAverageStaff1.InitializeReport(typeof(Reports.GetAverageNumEmplByCatResult),1);
           depCategoryAverageStaff2.InitializeReport(typeof(Reports.GetAverageNumEmplByCatResult), 2);
           DepartmentAverageStaff1.InitializeReport(typeof(Reports.GetAverageNumEmplResult), 0);
           depCategoryAverageStaff3.InitializeReport(typeof(Reports.GetAverageNumEmplByCatResult), 3);
           depPostAverageStaffFrame1.InitializeReport(typeof(Reports.GetAverageNumEmplResult), 0);
           reportBaseFrameForQuarter1.InitializeReport(typeof(Reports.GetAverageNumEmplResult), 3);
           reportBaseFrameForQuarter2.InitializeReport(typeof(Reports.GetFundingDepAverageNumEmplResult), 1);

           reportBaseFrameForPeriod1.InitializeReport(typeof(Reports.GetDepartmentBonusWithSettingsResult), 3);
           departmentBonusReportFrame1.InitializeReport(typeof(Reports.GetDepartmentBonusWithEmployeesResult), 0);
           depByPostBonusТ3ReportFrame1.InitializeReport(typeof(Reports.GetDepartmentBonusForT3Result), 1);
           depByCategoryBonusТ3ReportFrame1.InitializeReport(typeof(Reports.GetDepartmentBonusForT3Result), 2);
           reportBaseFrameForPeriod2.InitializeReport(typeof(Reports.GetDepartmentBonusWithSettingsResult), 4);

           factStaffChangesFrame1.InitializeReport(typeof(Reports.GetFactStaffChangesByPeriodResult), 0);
           postStaffChangesFrame1.InitializeReport(typeof(Reports.GetPostStaffChangesByPeriodResult), 0);

           minFormMainFrame1.InitializeReport(typeof(Reports.GetDepartmentBonusWithSettingsResult), 1);
           minFormsFrame1.InitializeReport(typeof(Reports.GetDepartmentBonusWithSettingsResult), 2);
           minForm3PPSFrame1.InitializeReport(typeof(Reports.GetPPSDepartmentBonusResult), 1);

           depEmplReportFrame1.InitializeReport(typeof(Reports.GetDepartmentStaffResult), 1);
           depStaffReportFrame1.InitializeReport(typeof(Reports.GetDepartmentStaffResult), 2);



           cbYearOfQr.Items.Clear();
           cbYearOfQr.Items.AddRange(KadrController.Instance.Model.TimeSheets.Select(ts => ts.TimeSheetYear as Object).Distinct().OrderByDescending(ts => ts as int?).ToArray());
           cbYearOfQr.SelectedItem = DateTime.Today.Year;
           if ((cbYearOfQr.SelectedItem == null) && (cbYearOfQr.Items.Count > 0))
               cbYearOfQr.SelectedItem = cbYearOfQr.Items[0];

           int MonthMod3 = 0;
           if (DateTime.Today.Month % 3 > 1)
               MonthMod3 = 1;
           cbQuarter.SelectedItem = cbQuarter.Items[DateTime.Today.Month / 3 + MonthMod3 - 1];
       }

       private void btnReportLoad_Click(object sender, EventArgs e)
       {
           tcAverageStaff_SelectedIndexChanged(null, null);
       }


       private void btnChangePlanStaff_Click(object sender, EventArgs e)
       {
           
           PlanStaff currentPlanStaff = planStaffBindingSource.Current as Kadr.Data.PlanStaff;
           if (currentPlanStaff == null)
           {
               MessageBox.Show("Не выбран редактируемый объект.", "АИС \"Штатное расписание\"");
               return;
           }

           using (Kadr.UI.Common.PropertyGridDialogAdding<PlanStaffHistory> dlg =
                new Kadr.UI.Common.PropertyGridDialogAdding<PlanStaffHistory>())
           {
               dlg.UseInternalCommandManager = true;
               dlg.ObjectList = KadrController.Instance.Model.PlanStaffHistories;
               //dlg.BindingSource = planStaffBindingSource;
               dlg.PrikazButtonVisible = true;
               dlg.oneObjectCreated = true;
               dlg.InitializeNewObject = (x) => 
               {
                   dlg.CommandManager.Execute(new UIX.Commands.GenericPropertyCommand<PlanStaffHistory, FinancingSource>(x, "FinancingSource", currentPlanStaff.FinancingSource, null), this);
                   dlg.CommandManager.Execute(new UIX.Commands.GenericPropertyCommand<PlanStaffHistory, decimal>(x, "StaffCount", currentPlanStaff.StaffCount, null), this);
                   dlg.CommandManager.Execute(new UIX.Commands.GenericPropertyCommand<PlanStaffHistory, Prikaz>(x, "Prikaz", NullPrikaz.Instance, null), this);
                   dlg.CommandManager.Execute(new UIX.Commands.GenericPropertyCommand<PlanStaffHistory, PlanStaff>(x, "PlanStaff", currentPlanStaff, null), this);
               };

               dlg.UpdateObjectList = () =>
               {
                   dlg.ObjectList = KadrController.Instance.Model.PlanStaffHistories;
               };

               dlg.ShowDialog();
               LoadPlanStaff();
           }


       }

       private void btnPlanStaffHistory_Click(object sender, EventArgs e)
       {
           using (Kadr.UI.Forms.PlanStaffHistoryForm HistForm =
               new Kadr.UI.Forms.PlanStaffHistoryForm())
           {
               HistForm.PlanStaff = planStaffBindingSource.Current as Kadr.Data.PlanStaff;
               HistForm.ShowDialog();
           }
       }

       private void btnChangeFactStaff_Click(object sender, EventArgs e)
       {
           FactStaff currentFactStaff = factStaffBindingSource.Current as FactStaff;
           if (currentFactStaff == null)
           {
               MessageBox.Show("Не выбран редактируемый объект.", "АИС \"Штатное расписание\"");
               return;
           }

           KadrController.Instance.AddFactStaffHistory(currentFactStaff);
           LoadPlanStaff();
       }

       private void btnHistoryFactStaff_Click(object sender, EventArgs e)
       {
           FactStaff currentFactStaff = factStaffBindingSource.Current as FactStaff;
           if (currentFactStaff == null)
           {
               MessageBox.Show("Не выбран редактируемый объект.", "АИС \"Штатное расписание\"");
               return;
           }

           using (Kadr.UI.Forms.FactStaffHistoryForm HistForm =
                          new Kadr.UI.Forms.FactStaffHistoryForm())
           {
               HistForm.FactStaff = currentFactStaff;
               HistForm.ShowDialog();
           }
       }

       private void tcForms_SelectedIndexChanged(object sender, EventArgs e)
       {

           if (tcDepartment.SelectedTab == tpMinFormReport)
           {
               Reports.Frames.ReportBaseFrameForPeriod CurrentFrame = null;
               if (tcForms.SelectedTab == tpForm7)
               {
                   CurrentFrame = minFormsFrame1;
               }

               if (tcForms.SelectedTab == tpForm3)
               {
                   CurrentFrame = minForm3PPSFrame1;
               }

               if (tcForms.SelectedTab == tpMainForm)
               {
                   CurrentFrame = minFormMainFrame1;
               }

               if ((CurrentFrame != null))
                   CurrentFrame.UpdateReportParams(dtpPeriodBegin.Value, dtpPeriodEnd.Value, Department.id, chbFormsWithSubDeps.Checked);
           }
       }

       private void btnLoadReport_Click(object sender, EventArgs e)
       {
           tcForms_SelectedIndexChanged(null, null);
       }

       private void tcBonusReports_SelectedIndexChanged(object sender, EventArgs e)
       {
           
       }

       private void btnBonusRepLoad_Click(object sender, EventArgs e)
       {
           if (tcDepartment.SelectedTab == tpDepBonusReport)
           {
               Reports.Frames.ReportBaseFrameForPeriod CurrentFrame = null;
               if (tcBonusReports.SelectedTab == tpEmplBonusReport)
               {
                   CurrentFrame = departmentBonusReportFrame1;
               }

               if (tcBonusReports.SelectedTab == tpT3ByPostReport)
               {
                   CurrentFrame = depByPostBonusТ3ReportFrame1;
               }

               if (tcBonusReports.SelectedTab == tpT3ByCategoryReport)
               {
                   CurrentFrame = depByCategoryBonusТ3ReportFrame1;
               }

               if (tcBonusReports.SelectedTab == tpSmallDelBonusReport)
               {
                   CurrentFrame = reportBaseFrameForPeriod1;
               }

               if (tcBonusReports.SelectedTab == tpBonusByFundSources)
               {
                   CurrentFrame = reportBaseFrameForPeriod2;
               }

               if (CurrentFrame!= null)
                   CurrentFrame.UpdateReportParams(dtpBonRepPeriodBegin.Value, dtpBonRepPeriodEnd.Value, Department.id, cbBonRepWithSubDeps.Checked);
           }
       }

       private void btnTimeSheetToExcel_Click(object sender, EventArgs e)
       {
           Kadr.Controllers.ExcelExportController.Instance.ExportToExcel(dgvTimeSheetFS);
       }

       private void tcStaffChangesReport_SelectedIndexChanged(object sender, EventArgs e)
       {
           if (tcDepartment.SelectedTab == tpFactStaffChanges)
           {
               Reports.Frames.ReportBaseFrameForPeriod CurrentFrame = null;
               if (tcStaffChangesReport.SelectedTab == tpFactStaffChangesReport)
               {
                   CurrentFrame = factStaffChangesFrame1;
               }

               if (tcStaffChangesReport.SelectedTab == tpPostStaffChangesReport)
               {
                   CurrentFrame = postStaffChangesFrame1;
               }

               if ((CurrentFrame != null))
                   CurrentFrame.UpdateReportParams(dtpStChPeriodBegin.Value, dtpStChPeriodEnd.Value, Department.id, chbStChWithSubDeps.Checked);
           }
       }

       private void btnLoadStChReport_Click(object sender, EventArgs e)
       {
           tcStaffChangesReport_SelectedIndexChanged(null, null);
       }


       private void btnAddTimeNorm_Click(object sender, EventArgs e)
       {
           using (Kadr.UI.Common.PropertyGridDialogAdding<DepartmentTimeNorm> dlg =
                new Kadr.UI.Common.PropertyGridDialogAdding<DepartmentTimeNorm>())
           {
               dlg.UseInternalCommandManager = true;
               dlg.ObjectList = KadrController.Instance.Model.DepartmentTimeNorms;
               dlg.BindingSource = departmentTimeNormBindingSource;
               dlg.PrikazButtonVisible = false;
               dlg.InitializeNewObject = (x) =>
                                             {
                                                 dlg.CommandManager.Execute(
                                                     new UIX.Commands.GenericPropertyCommand<DepartmentTimeNorm, Dep>(
                                                         x, "Dep", Department, null), this);
                                                 dlg.CommandManager.Execute(
                                                     new UIX.Commands.GenericPropertyCommand
                                                         <DepartmentTimeNorm, FinancingSource>(x, "FinancingSource", KadrController.Instance.Model.FinancingSources.Where(fs => fs.id == 1).FirstOrDefault()
                                                                                               , null), this);
                                             };
               dlg.UpdateObjectList = () =>
               {
                   dlg.ObjectList = KadrController.Instance.Model.DepartmentTimeNorms;
               };
               dlg.ShowDialog();
               LoadTimeNorm();
           }
       }

       private void btnEditTimeNorm_Click(object sender, EventArgs e)
       {
           LinqActionsController<DepartmentTimeNorm>.Instance.EditObject(departmentTimeNormBindingSource.Current as Kadr.Data.DepartmentTimeNorm, true);
       }

       private void btnDelTimeNorm_Click(object sender, EventArgs e)
       {
           DepartmentTimeNorm CurrentTimeNorm = departmentTimeNormBindingSource.Current as Kadr.Data.DepartmentTimeNorm;

           if (CurrentTimeNorm == null)
           {
               MessageBox.Show("Не выбрана удаляемая запись нормы времени.", "АИС \"Штатное расписание\"");
               return;
           }

           if (MessageBox.Show("Удалить норму времени?", "АИС Штатное расписание", MessageBoxButtons.OKCancel)
               == DialogResult.OK)
           {
               LinqActionsController<DepartmentTimeNorm>.Instance.DeleteObject(CurrentTimeNorm,
                        KadrController.Instance.Model.DepartmentTimeNorms, departmentTimeNormBindingSource);
           }
       }

       private void btnLoadStaffErrors_Click(object sender, EventArgs e)
       {
           getStaffErrorsByPeriodBindingSource.DataSource = KadrController.Instance.Model.GetStaffErrorsByPeriod(Department.id, dtpErrorsPeriodBegin.Value, dtpErrorsPeriodEnd.Value, chbErrorsWithSubDeps.Checked).OrderBy(err => err.DepartmentName).OrderBy(err => err.PostName);
       }

       private void button1_Click(object sender, EventArgs e)
       {
           Kadr.Controllers.ExcelExportController.Instance.ExportToExcel(dgvStaffErrors);
       }

        /// <summary>
        /// Переход на выделенный отдел в дереве
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
       private void dgvDepartments_DoubleClick(object sender, EventArgs e)
       {
           if ((departmentBindingSource.Current as Dep) != null)
           {
               ((this.FrameNodeObject as RootNodeObject).treeView as KadrTreeView.KadrTreeView).FindAndSelectDepartment(
                   (departmentBindingSource.Current as Dep).Department);
           }
       }

       private void tsbDepFundHistory_Click(object sender, EventArgs e)
       {
           if ((departmentBindingSource.Current as Dep) == null)
           {
               MessageBox.Show("Не выбран отдел, для которого запрашивается история бюджета.", "АИС \"Штатное расписание\"");
               return;
           }
           using (Kadr.UI.Forms.DepartmentFundForm dlg = new Forms.DepartmentFundForm())
           {
               dlg.Department = (departmentBindingSource.Current as Dep);
               dlg.ShowDialog();
               LoadSprav(ObjectStateController.Instance.GetObjectStatesForFilter(tsbDepFilter, null));
           }
       }

       private void tsbAddDepFund_Click(object sender, EventArgs e)
       {
           if ((departmentBindingSource.Current as Dep) == null)
           {
               MessageBox.Show("Не выбран отдел, для которого запрашивается история бюджета.", "АИС \"Штатное расписание\"");
               return;
           }
           Dep CurrentDep = (departmentBindingSource.Current as Dep);
           using (Kadr.UI.Common.PropertyGridDialogAdding<DepartmentFund> dlg =
                new Kadr.UI.Common.PropertyGridDialogAdding<DepartmentFund>())
           {
               dlg.ObjectList = KadrController.Instance.Model.DepartmentFunds;
               //dlg.BindingSource = departmentFundBindingSource;
               dlg.UseInternalCommandManager = true;
               dlg.PrikazButtonVisible = false;
               dlg.InitializeNewObject = (x) =>
               {
                   if (CurrentDep.LastFund != null)
                   {
                       dlg.CommandManager.Execute(new UIX.Commands.GenericPropertyCommand<DepartmentFund, decimal>(x, "PlanFundSum", CurrentDep.LastFund.PlanFundSum, null), this);
                       dlg.CommandManager.Execute(new UIX.Commands.GenericPropertyCommand<DepartmentFund, decimal>(x, "FactFundSum", CurrentDep.LastFund.FactFundSum, null), this);
                       dlg.CommandManager.Execute(new UIX.Commands.GenericPropertyCommand<DepartmentFund, decimal>(x, "ExtraordSum", CurrentDep.LastFund.ExtraordSum, null), this);
                   }
                   else
                   {
                       dlg.CommandManager.Execute(new UIX.Commands.GenericPropertyCommand<DepartmentFund, decimal>(x, "PlanFundSum", 0, null), this);
                       dlg.CommandManager.Execute(new UIX.Commands.GenericPropertyCommand<DepartmentFund, decimal>(x, "FactFundSum", 0, null), this);
                       dlg.CommandManager.Execute(new UIX.Commands.GenericPropertyCommand<DepartmentFund, decimal>(x, "ExtraordSum", 0, null), this);
                   }
                   dlg.CommandManager.Execute(new UIX.Commands.GenericPropertyCommand<DepartmentFund, DateTime>(x, "DateBegin", DateTime.Today, null), this);
                   dlg.CommandManager.Execute(new UIX.Commands.GenericPropertyCommand<DepartmentFund, Dep>(x, "Dep", CurrentDep, null), this);
               };

               dlg.ShowDialog();
               LoadSprav(ObjectStateController.Instance.GetObjectStatesForFilter(tsbDepFilter, null));
           }
       }

       private void tsbDepFilter_DropDownItemClicked(object sender, ToolStripItemClickedEventArgs e)
       {
           LoadSprav(ObjectStateController.Instance.GetObjectStatesForFilter(tsbDepFilter, e));
       }

       private void btnAddDep_Click(object sender, EventArgs e)
       {
           using (Kadr.UI.Common.PropertyGridDialogAdding<Dep> dlg =
                new Kadr.UI.Common.PropertyGridDialogAdding<Dep>())
           {
               dlg.UseInternalCommandManager = true;
               dlg.ObjectList = KadrController.Instance.Model.Deps;
               dlg.BindingSource = null; ;
               dlg.InitializeNewObject = (x) =>
               {
                   /*dlg.CommandManager.Execute(new UIX.Commands.GenericPropertyCommand<Dep, Dep>(x, "Department1", (NodeObject as RootNodeObject).Department, null), this);
                   dlg.CommandManager.Execute(new UIX.Commands.GenericPropertyCommand<Department, int>(x, "SeverKoeff", (int)((NodeObject as RootNodeObject).Department.SeverKoeff), null), this);
                   dlg.CommandManager.Execute(new UIX.Commands.GenericPropertyCommand<Department, Int32>(x, "RayonKoeff", (int)((NodeObject as RootNodeObject).Department.RayonKoeff), null), this);
                   */
                   DepartmentHistory depHistory = new DepartmentHistory();
                   dlg.CommandManager.Execute(new UIX.Commands.GenericPropertyCommand<DepartmentHistory, Prikaz>(depHistory, "Prikaz", NullPrikaz.Instance, null), this);
                   dlg.CommandManager.Execute(new UIX.Commands.GenericPropertyCommand<DepartmentHistory, Dep>(depHistory, "Dep", x, null), this);

                   dlg.CommandManager.Execute(new UIX.Commands.GenericPropertyCommand<DepartmentHistory, Dep>(depHistory, "Dep1", Department, null), this);

                   FundingCenter center = Department.FundingCenter;
                   if (center == null)
                       dlg.CommandManager.Execute(new UIX.Commands.GenericPropertyCommand<Dep, FundingCenter>(x, "FundingCenter", NullFundingCenter.Instance, null), this);
                   else
                       dlg.CommandManager.Execute(new UIX.Commands.GenericPropertyCommand<Dep, FundingCenter>(x, "FundingCenter", center, null), this);
               };

               dlg.ShowDialog();
               (this.FrameNodeObject as RootNodeObject).Refresh();
               LoadSprav(ObjectStateController.Instance.GetObjectStatesForFilter(tsbDepFilter, null));
           }
       }

       private void EditPostBtn_Click(object sender, EventArgs e)
       {
           Dep CurrentDep = departmentBindingSource.Current as Dep;
           if (CurrentDep == null)
           {
               MessageBox.Show("Не выбран редактируемый отдел.", "АИС \"Штатное расписание\"");
               return;
           }
           if (CurrentDep.FundingCenter == null)
               CurrentDep.FundingCenter = NullFundingCenter.Instance;
           LinqActionsController<Dep>.Instance.EditObject(CurrentDep, false);
           (this.FrameNodeObject as RootNodeObject).Refresh();
           LoadSprav(ObjectStateController.Instance.GetObjectStatesForFilter(tsbDepFilter, null));
       }

       private void btnDelDep_Click(object sender, EventArgs e)
       {
           Dep CurrentDep = departmentBindingSource.Current as Dep;
           KadrController.Instance.Model.DepartmentHistories.DeleteAllOnSubmit(KadrController.Instance.Model.DepartmentHistories.Where(depHist => depHist.Dep == CurrentDep));

           LinqActionsController<Dep>.Instance.DeleteObject(CurrentDep,
                KadrController.Instance.Model.Deps, departmentBindingSource);
       }

       private void btnDepStaffReportLoad_Click(object sender, EventArgs e)
       {
           if (tcDepartment.SelectedTab == tpDepEmplReport)
           {
               Reports.Frames.ReportBaseFrameForPeriod CurrentFrame = null;
               if (tcDepStaffReport.SelectedTab == tpDepStaffReportWithFinSource)
               {
                   CurrentFrame = depEmplReportFrame1;
               }

               if (tcDepStaffReport.SelectedTab == tpDepStaffReport)
               {
                   CurrentFrame = depStaffReportFrame1;
               }

               if (CurrentFrame != null)
                    CurrentFrame.UpdateReportParams(dtpDepStaffReportDate.Value, dtpDepStaffReportDate.Value, Department.id, cbDepStaffReportWithSubDeps.Checked);
           }
       }

       private void tspHourFactStaffFilter_DropDownItemClicked(object sender, ToolStripItemClickedEventArgs e)
       {
           LoadHourFactStaff(ObjectStateController.Instance.GetObjectStatesForFilter(tspHourFactStaffFilter, e));

       }

       private void dgvHourFactStaff_DoubleClick(object sender, EventArgs e)
       {
           FactStaff currentFactStaff = (hourFactStaffBindingSource.Current as Kadr.Data.FactStaff);
           if (currentFactStaff != null)
           {
               if (currentFactStaff.FundingCenter == null)
                   currentFactStaff.FundingCenter = NullFundingCenter.Instance;
               /*if (currentFactStaff.FactStaffReplacement != null)
                   LinqActionsController<FactStaffReplacement>.Instance.EditObject(
                       currentFactStaff.FactStaffReplacement, true);
               else*/
               if (currentFactStaff.IsContractHourStaff)
                   LinqActionsController<FactStaffHourContract>.Instance.EditObject(
                       currentFactStaff.FactStaffHourContract, true);
               if (currentFactStaff.IsPrikazHourStaff)
                   LinqActionsController<FactStaffHour>.Instance.EditObject(
                       currentFactStaff.FactStaffHour, true);
           }
           LoadHourFactStaff();
       }

       private void AddHourFactStaffBtn_Click(object sender, EventArgs e)
       {
            /*KadrController.Instance.AddFactStaff(hourFactStaffBindingSource, null, Department,
                           Kadr.Data.WorkType.hourWorkType);*/

           using (Kadr.UI.Common.PropertyGridDialogAdding<FactStaffHour> dlg =
                new Kadr.UI.Common.PropertyGridDialogAdding<FactStaffHour>())
           {
               dlg.ObjectList = null;
               dlg.BindingSource = hourFactStaffBindingSource;
               dlg.UseInternalCommandManager = true;
               dlg.PrikazButtonVisible = true;
               dlg.InitializeNewObject = (x) =>
               {
                   
                   FactStaffHistory fcStHistory = new FactStaffHistory();
                    //dlg.CommandManager.Execute(new UIX.Commands.GenericPropertyCommand<FactStaff, Dep>(x, "Dep", (planStaffBindingSource.Current as PlanStaff).Dep, null), this);
                   if ((dlg.SelectedObjects != null) && (dlg.SelectedObjects.Length == 1))
                   {
                       FactStaff prev = (dlg.SelectedObjects[0] as FactStaffHour).FactStaff;
                       //dlg.CommandManager.Execute(new UIX.Commands.GenericPropertyCommand<FactStaffHistory, DateTime?>(fcStHistory, "DateBegin", prev.LastChange.DateBegin, null), this);
                       //dlg.CommandManager.Execute(new UIX.Commands.GenericPropertyCommand<FactStaffHistory, Prikaz>(fcStHistory, "Prikaz", prev.PrikazBegin, null), this);
                       //dlg.CommandManager.Execute(new UIX.Commands.GenericPropertyCommand<FactStaffHistory, WorkType>(fcStHistory, "WorkType", prev.WorkType, null), this);
                       //dlg.CommandManager.Execute(new UIX.Commands.GenericPropertyCommand<FactStaffHistory, decimal>(fcStHistory, "StaffCount", prev.StaffCount, null), this);
                       dlg.CommandManager.Execute(new UIX.Commands.GenericPropertyCommand<FactStaff, DateTime?>(x.FactStaff, "DateBegin", prev.DateBegin, null), this);
                       dlg.CommandManager.Execute(new UIX.Commands.GenericPropertyCommand<FactStaff, Prikaz>(x.FactStaff, "PrikazBegin", prev.PrikazBegin, null), this);
                       dlg.CommandManager.Execute(new UIX.Commands.GenericPropertyCommand<FactStaff, decimal>(x.FactStaff, "StaffCount", prev.StaffCount, null), this);


                   }
                   else
                   {
                       dlg.CommandManager.Execute(new UIX.Commands.GenericPropertyCommand<FactStaffHistory, Prikaz>(fcStHistory, "Prikaz", NullPrikaz.Instance, null), this);
                       //dlg.CommandManager.Execute(new UIX.Commands.GenericPropertyCommand<FactStaff, Prikaz>(x, "PrikazBegin", NullPrikaz.Instance, null), this);
                       //dlg.CommandManager.Execute(new UIX.Commands.GenericPropertyCommand<FactStaff, WorkType>(x, "WorkType", NullWorkType.Instance, null), this);
                    }
                   dlg.CommandManager.Execute(new UIX.Commands.GenericPropertyCommand<FactStaff, bool>(x.FactStaff, "IsReplacement", false, null), this);
                   dlg.CommandManager.Execute(new UIX.Commands.GenericPropertyCommand<FactStaff, Employee>(x.FactStaff, "Employee", NullEmployee.Instance, null), this);
                   dlg.CommandManager.Execute(new UIX.Commands.GenericPropertyCommand<FactStaffHistory, WorkType>(fcStHistory, "WorkType", Kadr.Data.WorkType.hourWorkType, null), this);
                   dlg.CommandManager.Execute(new UIX.Commands.GenericPropertyCommand<FactStaff, Dep>(x.FactStaff, "Dep", Department, null), this);
                   dlg.CommandManager.Execute(new UIX.Commands.GenericPropertyCommand<FactStaff, FundingCenter>(x.FactStaff, "FundingCenter", NullFundingCenter.Instance, null), this);
                   dlg.CommandManager.Execute(new UIX.Commands.GenericPropertyCommand<FactStaff, FinancingSource>(x.FactStaff, "FinancingSource", Kadr.Data.FinancingSource.budgetFinancingSource, null), this);
                   //dlg.CommandManager.Execute(new UIX.Commands.GenericPropertyCommand<FactStaffHistory, decimal>(fcStHistory, "SalaryKoeff", 1, null), this);
                   dlg.CommandManager.Execute(new UIX.Commands.GenericPropertyCommand<FactStaffHistory, FactStaff>(fcStHistory, "FactStaff", x.FactStaff, null), this);

               };

               /*dlg.UpdateObjectList = () =>
               {
                   dlg.ObjectList = KadrController.Instance.Model.FactStaffs;
               };*/
               dlg.ShowDialog();
           }
            LoadHourFactStaff();
            //tcDepartment_SelectedIndexChanged(null, null);
       }

       private void DelHourFactStaffBtn_Click(object sender, EventArgs e)
       {
           FactStaff CurrentFactStaff = hourFactStaffBindingSource.Current as Kadr.Data.FactStaff;

           if (CurrentFactStaff == null)
           {
               MessageBox.Show("Не выбрана удаляемая запись штатного расписания.", "АИС \"Штатное расписание\"");
               return;
           }

           /*//если уже задана история (более одной записи), то нельзя удалить надбавку
           if (CurrentFactStaff.PlanStaffHistory.Count > 1)
           {
               MessageBox.Show("У заданной записи есть история изменений. При удалении записи она тоже будет удалена.", "АИС \"Штатное расписание\"");
               return;
           }*/



           if (MessageBox.Show("Удалить сотрудника?", "АИС Штатное расписание", MessageBoxButtons.OKCancel)
               == DialogResult.OK)
           {


               if (CurrentFactStaff.FactStaffReplacements.Count > 0)
               {
                   foreach (FactStaffReplacement fcStRepl in CurrentFactStaff.FactStaffReplacements)
                   {
                       KadrController.Instance.Model.FactStaffReplacements.DeleteOnSubmit(fcStRepl);
                   }
                   KadrController.Instance.Model.SubmitChanges();
               }
               LinqActionsController<FactStaff>.Instance.DeleteObject(CurrentFactStaff,
                        KadrController.Instance.Model.FactStaffs, hourFactStaffBindingSource);
           }

       }


       private void HistiryHourFactStaffBtn_Click(object sender, EventArgs e)
       {
           using (Kadr.UI.Forms.FactStaffHistoryForm HistForm =
                          new Kadr.UI.Forms.FactStaffHistoryForm())
           {
               HistForm.FactStaff = hourFactStaffBindingSource.Current as Kadr.Data.FactStaff;
               HistForm.ShowDialog();
           }
       }

       private void EditHourFactStaffBtn_Click(object sender, EventArgs e)
       {
           FactStaff currentFactStaff = hourFactStaffBindingSource.Current as FactStaff;
           if (currentFactStaff == null)
           {
               MessageBox.Show("Не выбран редактируемый объект.", "АИС \"Штатное расписание\"");
               return;
           }


           KadrController.Instance.AddFactStaffHistory(currentFactStaff);
           //LoadHourFactStaff();
           tcDepartment_SelectedIndexChanged(null, null);
           
       }

       

       
       private void btnHourStaffToExcel_Click(object sender, EventArgs e)
       {
           Kadr.Controllers.ExcelExportController.Instance.ExportToExcel(dgvHourFactStaff);
       }

       private void DelContractStaffBtn_Click(object sender, EventArgs e)
       {
           FactStaff CurrentFactStaff = ContractStaffBindingSource.Current as Kadr.Data.FactStaff;

           if (CurrentFactStaff == null)
           {
               MessageBox.Show("Не выбрана удаляемая запись штатного расписания.", "АИС \"Штатное расписание\"");
               return;
           }

           /*//если уже задана история (более одной записи), то нельзя удалить надбавку
           if (CurrentFactStaff.PlanStaffHistory.Count > 1)
           {
               MessageBox.Show("У заданной записи есть история изменений. При удалении записи она тоже будет удалена.", "АИС \"Штатное расписание\"");
               return;
           }*/



           if (MessageBox.Show("Удалить сотрудника?", "АИС Штатное расписание", MessageBoxButtons.OKCancel)
               == DialogResult.OK)
           {


               if (CurrentFactStaff.FactStaffReplacements.Count > 0)
               {
                   foreach (FactStaffReplacement fcStRepl in CurrentFactStaff.FactStaffReplacements)
                   {
                       KadrController.Instance.Model.FactStaffReplacements.DeleteOnSubmit(fcStRepl);
                   }
                   KadrController.Instance.Model.SubmitChanges();
               }
               LinqActionsController<FactStaff>.Instance.DeleteObject(CurrentFactStaff,
                        KadrController.Instance.Model.FactStaffs, ContractStaffBindingSource);
           }
       }


       

       private void tsbAddFacrStaffContractHour_Click(object sender, EventArgs e)
       {
           using (Kadr.UI.Common.PropertyGridDialogAdding<FactStaffHourContract> dlg =
                new Kadr.UI.Common.PropertyGridDialogAdding<FactStaffHourContract>())
           {
               dlg.ObjectList = null;
               dlg.BindingSource = hourFactStaffBindingSource;
               dlg.UseInternalCommandManager = true;
               dlg.PrikazButtonVisible = true;
               dlg.InitializeNewObject = (x) =>
               {

                   FactStaffHistory fcStHistory = new FactStaffHistory();
                   //dlg.CommandManager.Execute(new UIX.Commands.GenericPropertyCommand<FactStaff, Dep>(x, "Dep", (planStaffBindingSource.Current as PlanStaff).Dep, null), this);
                   if ((dlg.SelectedObjects != null) && (dlg.SelectedObjects.Length == 1))
                   {
                       FactStaff prev = (dlg.SelectedObjects[0] as FactStaffHourContract).FactStaff;
                       //dlg.CommandManager.Execute(new UIX.Commands.GenericPropertyCommand<FactStaffHistory, DateTime?>(fcStHistory, "DateBegin", prev.LastChange.DateBegin, null), this);
                       //dlg.CommandManager.Execute(new UIX.Commands.GenericPropertyCommand<FactStaffHistory, Prikaz>(fcStHistory, "Prikaz", prev.PrikazBegin, null), this);
                       //dlg.CommandManager.Execute(new UIX.Commands.GenericPropertyCommand<FactStaffHistory, WorkType>(fcStHistory, "WorkType", prev.WorkType, null), this);
                       //dlg.CommandManager.Execute(new UIX.Commands.GenericPropertyCommand<FactStaffHistory, decimal>(fcStHistory, "StaffCount", prev.StaffCount, null), this);
                       dlg.CommandManager.Execute(new UIX.Commands.GenericPropertyCommand<FactStaff, DateTime?>(x.FactStaff, "DateBegin", prev.DateBegin, null), this);
                       dlg.CommandManager.Execute(new UIX.Commands.GenericPropertyCommand<FactStaff, Prikaz>(x.FactStaff, "PrikazBegin", prev.PrikazBegin, null), this);
                       dlg.CommandManager.Execute(new UIX.Commands.GenericPropertyCommand<FactStaff, decimal>(x.FactStaff, "StaffCount", prev.StaffCount, null), this);


                   }
                   else
                   {
                       dlg.CommandManager.Execute(new UIX.Commands.GenericPropertyCommand<FactStaffHistory, Prikaz>(fcStHistory, "Prikaz", NullPrikaz.Instance, null), this);
                       //dlg.CommandManager.Execute(new UIX.Commands.GenericPropertyCommand<FactStaff, Prikaz>(x, "PrikazBegin", NullPrikaz.Instance, null), this);
                       //dlg.CommandManager.Execute(new UIX.Commands.GenericPropertyCommand<FactStaff, WorkType>(x, "WorkType", NullWorkType.Instance, null), this);
                   }
                   dlg.CommandManager.Execute(new UIX.Commands.GenericPropertyCommand<FactStaff, bool>(x.FactStaff, "IsReplacement", false, null), this);
                   dlg.CommandManager.Execute(new UIX.Commands.GenericPropertyCommand<FactStaff, FactStaff>(x.FactStaff, "FactStaff1", NullFactStaff.Instance, null), this);
                   dlg.CommandManager.Execute(new UIX.Commands.GenericPropertyCommand<FactStaffHistory, WorkType>(fcStHistory, "WorkType", Kadr.Data.WorkType.hourWorkType, null), this);
                   dlg.CommandManager.Execute(new UIX.Commands.GenericPropertyCommand<FactStaff, Dep>(x.FactStaff, "Dep", Department, null), this);
                   dlg.CommandManager.Execute(new UIX.Commands.GenericPropertyCommand<FactStaff, FundingCenter>(x.FactStaff, "FundingCenter", NullFundingCenter.Instance, null), this);
                   dlg.CommandManager.Execute(new UIX.Commands.GenericPropertyCommand<FactStaff, FinancingSource>(x.FactStaff, "FinancingSource", Kadr.Data.FinancingSource.extrabudgetFinancingSource, null), this);
                   //dlg.CommandManager.Execute(new UIX.Commands.GenericPropertyCommand<FactStaffHistory, decimal>(fcStHistory, "SalaryKoeff", 1, null), this);
                   dlg.CommandManager.Execute(new UIX.Commands.GenericPropertyCommand<FactStaffHistory, FactStaff>(fcStHistory, "FactStaff", x.FactStaff, null), this);

               };

               /*dlg.UpdateObjectList = () =>
               {
                   dlg.ObjectList = KadrController.Instance.Model.FactStaffs;
               };*/
               dlg.ShowDialog();
           }
           LoadHourFactStaff();
           //tcDepartment_SelectedIndexChanged(null, null);
       }

       private void tsbFactStaffHours_Click(object sender, EventArgs e)
       {
           FactStaff currentFactStaff = hourFactStaffBindingSource.Current as FactStaff;
           using (Kadr.UI.Forms.FactStaffHoursForm dlg = new Forms.FactStaffHoursForm(currentFactStaff))
           {
               dlg.ShowDialog();
           }
       }

       private void button2_Click(object sender, EventArgs e)
       {
           if (tcDepartment.SelectedTab == tpQrStaffAverage)
           {
               Reports.Frames.ReportBaseFrameForQuarter CurrentFrame = null;

               if (tcQrStaffAverage.SelectedTab == tpCategoryZPAverage)
               {
                   CurrentFrame = depCategoryAverageStaff3;
               }


               if (tcQrStaffAverage.SelectedTab == tpDepPostAverage)
               {
                   CurrentFrame = depPostAverageStaffFrame1;
               }

               
               if (tcQrStaffAverage.SelectedTab == tpByOKVED)
               {
                   CurrentFrame = reportBaseFrameForQuarter1;
               }

               if (tcQrStaffAverage.SelectedTab == tpZZFAverage)
               {
                   CurrentFrame = reportBaseFrameForQuarter2;
               }

               if ((CurrentFrame != null) )
                   CurrentFrame.UpdateReportParams(Convert.ToInt32(cbYearOfQr.SelectedItem), Convert.ToInt32(cbQuarter.SelectedIndex), Department.id, chbWithSubDeps.Checked);
           }
 
       }

 
       

       

       

 

       

 
 
 
 
 







    }

}
