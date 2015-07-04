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
//using Reports;
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

        private void LoadSprav()
        {
            if (Department != null)
            {
                departmentBindingSource.DataSource = Department.DepartmentHistories1.Where(dep => dep.Dep.dateExit == null).OrderBy( dep => dep.DepartmentName);


                
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
               /*
                //выбираем тех, кто с индивидуальным окладом
                IEnumerable<PlanStaff> planStaffsWithIndivSalary = KadrController.Instance.Model.PlanStaffs.Where(planSt => planSt.Department == Department).Where(planSt => planSt.PlanStaffSalaries.Where(plStSal => plStSal.DateEnd == null).Count()>0);
                IEnumerable<PlanStaffSalary> IndivSalaries = KadrController.Instance.Model.PlanStaffSalaries.Where(sal => sal.DateEnd == null);

                //выбираем остальных (обычный оклад - по категории)
                IEnumerable<PlanStaff> planStaffsWithCatSalary = KadrController.Instance.Model.PlanStaffs.Where(planSt => planSt.Department == Department).Where(planSt => planSt.PlanStaffSalaries.Where(plStSal => plStSal.DateEnd == null).Count() == 0);
                IEnumerable<PKCategorySalary> CatSalaries = KadrController.Instance.Model.PKCategorySalaries.Where(sal => sal.DateEnd == null);

                planStaffBindingSource.DataSource = planStaffsWithIndivSalary.Join(IndivSalaries, plst => plst.id, sal => sal.idPlanStaff,
                    (plst,sal) => new 
                    {
                        id = plst.id,
                        StaffCount = plst.StaffCount,
                        FinancingSource = plst.FinancingSource,
                        Category = plst.Category,
                        Post = plst.Post,
                        Prikaz = plst.Prikaz,
                        Prikaz1 = plst.Prikaz1,
                        SalarySize = sal.SalarySize,
                        HavIndivSal = true
                    }).Concat(planStaffsWithCatSalary.Join(CatSalaries, plst => plst.Post.PKCategory.id, sal => sal.idPKCategory,
                    (plst, sal) => new
                    {
                        id = plst.id,
                        StaffCount = plst.StaffCount,
                        FinancingSource = plst.FinancingSource,
                        Category = plst.Category,
                        Post = plst.Post,
                        Prikaz = plst.Prikaz,
                        Prikaz1 = plst.Prikaz1,
                        SalarySize = sal.SalarySize,
                        HavIndivSal = false
                    }));
                */

                //фильтруем элементы
                IEnumerable<PlanStaff> planStaff = KadrController.Instance.Model.PlanStaffs.Where(planSt => planSt.Dep == Department).OrderBy(planSt => planSt.PlanStaffHistories.FirstOrDefault().FinancingSource.OrderBy).ThenBy(planSt => planSt.Post.Category.OrderBy).ThenByDescending(planSt => planSt.Post.PKCategory.PKGroup.GroupNumber).ThenByDescending(planSt => planSt.Post.PKCategory.PKCategoryNumber).ThenBy(planSt => planSt.Post.PostName);
                ArrayList plStaff = new ArrayList();
                foreach (PlanStaff plSt in planStaff)
                    if (planStaffFilters.Contains((plSt as IObjectState).State()))
                    {
                        plStaff.Add(plSt);
                    }
                planStaffBindingSource.DataSource = plStaff ;


             }
        }

        private void LoadFactStaff(ArrayList factStaffFilters)
        {
            if ((planStaffBindingSource.Current as Kadr.Data.PlanStaff) != null)
            {

                //фильтруем элементы 
                IEnumerable<FactStaff> factStaff = KadrController.Instance.Model.FactStaffs.Where(fact => ((fact.PlanStaff == (planStaffBindingSource.Current as Kadr.Data.PlanStaff)))).OrderBy(plSt => plSt.DateEnd).ThenBy(plSt => plSt.Employee.LastName).ThenBy(plSt => plSt.Employee.FirstName);
                List<FactStaff> fcStaff = new List<FactStaff>();
                foreach (FactStaff fcSt in factStaff)
                    if (factStaffFilters.Contains((fcSt as IObjectState).State()))
                    {
                        fcStaff.Add(fcSt);
                    }
                factStaffBindingSource.DataSource = fcStaff;// factStaff.Intersect(fcStaff);//fcStaff.AsEnumerable<FactStaff>();
            }                    
        }

        #endregion


        protected override void DoRefreshFrame()
        {
            
            tcDepartment_SelectedIndexChanged(null, null);
            IsModified = false;
        }


        private void btnOk_Click(object sender, EventArgs e)
        {
            DoApply();

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
           using (Kadr.UI.Common.PropertyGridDialogAdding<FactStaff> dlg =
                new Kadr.UI.Common.PropertyGridDialogAdding<FactStaff>())
           {
               dlg.ObjectList = KadrController.Instance.Model.FactStaffs;
               dlg.BindingSource = factStaffBindingSource;
               dlg.UseInternalCommandManager = true;
               dlg.PrikazButtonVisible = true;
               dlg.InitializeNewObject = (x) =>
               {
                   FactStaffHistory fcStHistory = new FactStaffHistory();
                   dlg.CommandManager.Execute(new UIX.Commands.GenericPropertyCommand<FactStaff, PlanStaff>(x, "PlanStaff", planStaffBindingSource.Current as PlanStaff, null), this);
                   if ((dlg.SelectedObjects != null) && (dlg.SelectedObjects.Length == 1))
                   {
                       FactStaff prev = dlg.SelectedObjects[0] as FactStaff;
                       //dlg.CommandManager.Execute(new UIX.Commands.GenericPropertyCommand<FactStaffHistory, DateTime?>(fcStHistory, "DateBegin", prev.LastChange.DateBegin, null), this);
                       //dlg.CommandManager.Execute(new UIX.Commands.GenericPropertyCommand<FactStaffHistory, Prikaz>(fcStHistory, "Prikaz", prev.PrikazBegin, null), this);
                       //dlg.CommandManager.Execute(new UIX.Commands.GenericPropertyCommand<FactStaffHistory, WorkType>(fcStHistory, "WorkType", prev.WorkType, null), this);
                       //dlg.CommandManager.Execute(new UIX.Commands.GenericPropertyCommand<FactStaffHistory, decimal>(fcStHistory, "StaffCount", prev.StaffCount, null), this);
                       dlg.CommandManager.Execute(new UIX.Commands.GenericPropertyCommand<FactStaff, DateTime?>(x, "DateBegin", prev.DateBegin, null), this);
                       dlg.CommandManager.Execute(new UIX.Commands.GenericPropertyCommand<FactStaff, Prikaz>(x, "PrikazBegin", prev.PrikazBegin, null), this);
                       dlg.CommandManager.Execute(new UIX.Commands.GenericPropertyCommand<FactStaff, WorkType>(x, "WorkType", prev.WorkType, null), this);
                       dlg.CommandManager.Execute(new UIX.Commands.GenericPropertyCommand<FactStaff, decimal>(x, "StaffCount", prev.StaffCount, null), this);
                       
                       dlg.CommandManager.Execute(new UIX.Commands.GenericPropertyCommand<FactStaff, Employee>(x, "Employee", NullEmployee.Instance, null), this);

                   }
                   else
                   {
                       dlg.CommandManager.Execute(new UIX.Commands.GenericPropertyCommand<FactStaffHistory, Prikaz>(fcStHistory, "Prikaz", NullPrikaz.Instance, null), this);
                       dlg.CommandManager.Execute(new UIX.Commands.GenericPropertyCommand<FactStaffHistory, WorkType>(fcStHistory, "WorkType", NullWorkType.Instance, null), this);
                       //dlg.CommandManager.Execute(new UIX.Commands.GenericPropertyCommand<FactStaff, Prikaz>(x, "PrikazBegin", NullPrikaz.Instance, null), this);
                       //dlg.CommandManager.Execute(new UIX.Commands.GenericPropertyCommand<FactStaff, WorkType>(x, "WorkType", NullWorkType.Instance, null), this);
                       dlg.CommandManager.Execute(new UIX.Commands.GenericPropertyCommand<FactStaff, Employee>(x, "Employee", NullEmployee.Instance, null), this);
                   }
                   dlg.CommandManager.Execute(new UIX.Commands.GenericPropertyCommand<FactStaff, bool>(x, "IsReplacement", false, null), this);
                   dlg.CommandManager.Execute(new UIX.Commands.GenericPropertyCommand<FactStaffHistory, FactStaff>(fcStHistory, "FactStaff", x, null), this);
               };

               dlg.UpdateObjectList = () =>  
               {
                   dlg.ObjectList = KadrController.Instance.Model.FactStaffs;
               };

               dlg.ShowDialog();
               LoadFactStaff();
           }
       }

       private void EditFactStaffBtn_Click(object sender, EventArgs e)
       {
           if ((factStaffBindingSource.Current as Kadr.Data.FactStaff).isReplacement)
               LinqActionsController<FactStaffReplacement>.Instance.EditObject((factStaffBindingSource.Current as Kadr.Data.FactStaff).FactStaffReplacement, true);
           else
               LinqActionsController<FactStaff>.Instance.EditObject(factStaffBindingSource.Current as Kadr.Data.FactStaff, true);
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
           if (CurrentPlanStaff.PlanStaffHistories.Count > 1)
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
           if (CurrentFactStaff.PlanStaffHistories.Count > 1)
           {
               MessageBox.Show("У заданной записи есть история изменений. При удалении записи она тоже будет удалена.", "АИС \"Штатное расписание\"");
               return;
           }*/

         
           
           if (MessageBox.Show("Удалить сотрудника?", "АИС Штатное расписание", MessageBoxButtons.OKCancel)
               == DialogResult.OK)
           {
               KadrController.Instance.Model.FactStaffHistories.DeleteAllOnSubmit(KadrController.Instance.Model.FactStaffHistories.Where(fcStHist => fcStHist.FactStaff == CurrentFactStaff));


               if ((factStaffBindingSource.Current as Kadr.Data.FactStaff).isReplacement)
               {
                   foreach (FactStaffReplacement fcStRepl in (factStaffBindingSource.Current as Kadr.Data.FactStaff).FactStaffReplacements)
                   {
                       KadrController.Instance.Model.FactStaffReplacements.DeleteOnSubmit(fcStRepl);
                       //LinqActionsController<FactStaffReplacement>.Instance.DeleteObject(fcStRepl,
                        //KadrController.Instance.Model.FactStaffReplacements, null);
                   }
               }
               IEnumerable<TimeSheetFSWorkingDay> tsList = KadrController.Instance.Model.TimeSheetFSWorkingDays.Where(ts => ts.FactStaff == factStaffBindingSource.Current as Kadr.Data.FactStaff);
               //KadrController.Instance.Model.TimeSheetFSWorkingDays.DeleteOnSubmit(tsList);
               KadrController.Instance.Model.TimeSheetFSWorkingDays.DeleteAllOnSubmit(tsList);
               LinqActionsController<FactStaff>.Instance.DeleteObject(factStaffBindingSource.Current as Kadr.Data.FactStaff,
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
               bonFrm.ShowDialog();
           }

       }

       private void btnFactStaffBonus_Click(object sender, EventArgs e)
       {
           using (Kadr.UI.Forms.KadrBonusForm bonFrm =
                new Kadr.UI.Forms.KadrBonusForm())
           {
               bonFrm.BonusObject = factStaffBindingSource.Current as Kadr.Data.FactStaff;
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
 
                    dlg.CommandManager.Execute(new UIX.Commands.GenericPropertyCommand<FactStaffReplacement, FactStaff>(x, "FactStaff1", factStaff, null), this);
                    dlg.CommandManager.Execute(new UIX.Commands.GenericPropertyCommand<FactStaffReplacement, FactStaff>(x, "FactStaff", currentFactStaff, null), this);
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
               LoadSprav();
           } 
           if (tcDepartment.SelectedTab == tpStaff)
           {
               LoadPlanStaff();
           }
           
           if (tcDepartment.SelectedTab == tpPCGEmplCountRep)
           {
               depEmplCountReportFrame1.ReportParam = Department.id;
               //depEmplCountReportFrame1.reportViewer1.RefreshReport();

           }

           if (tcDepartment.SelectedTab == tpDepEmplReport)
           {
               depEmplReportFrame1.ReportParam = Department.id;
               //depEmplCountReportFrame1.reportViewer1.RefreshReport();

           }

           if (tcDepartment.SelectedTab == tpDepBonusReport)
           {
               
               
               tcBonusReports_SelectedIndexChanged(this, null);
               //departmentBonusReportFrame1.ReportParam = Department.id;
 
           }

           if (tcDepartment.SelectedTab == tpTimeSheet)
           {
               LoadTimeSheets();

           }

           if (tcDepartment.SelectedTab == tpFactStaffChanges)
           {
               tcStaffChangesReport_SelectedIndexChanged(this, null);

           }

           if (tcDepartment.SelectedTab == tpMinFormReport)
           {
               tcForms_SelectedIndexChanged(this, null);

           }

           if (tcDepartment.SelectedTab == tpStaffAverage)
           {
               tcAverageStaff_SelectedIndexChanged(this, null);

           }

       }

 
       private void tspPlanStaffFilter_DropDownItemClicked(object sender, ToolStripItemClickedEventArgs e)
       {
           //записываем фильтры
           ArrayList planStaffFilters = new ArrayList();
           for (ObjectState objectState = ObjectState.Current; objectState <= ObjectState.Canceled; objectState++)
           {

               if ((e != null) && (tspPlanStaffFilter.DropDownItems[(int)objectState] == e.ClickedItem))
               {
                   if (!(tspPlanStaffFilter.DropDownItems[(int)objectState] as ToolStripMenuItem).Checked)
                       planStaffFilters.Add(objectState);
               }
               else
               {
                   if ((tspPlanStaffFilter.DropDownItems[(int)objectState] as ToolStripMenuItem).Checked)
                       planStaffFilters.Add(objectState);
               }

           }


           LoadPlanStaff(planStaffFilters);

       }

       private void tspFactStaffFilter_DropDownItemClicked(object sender, ToolStripItemClickedEventArgs e)
       {
           //записываем фильтры
           ArrayList factStaffFilters = new ArrayList();
           for (ObjectState objectState = ObjectState.Current; objectState <= ObjectState.Canceled; objectState++)
           {

               if ((e != null) && (tspFactStaffFilter.DropDownItems[(int)objectState] == e.ClickedItem))
               {
                   if (!(tspFactStaffFilter.DropDownItems[(int)objectState] as ToolStripMenuItem).Checked)
                       factStaffFilters.Add(objectState);
               }
               else
               {
                   if ((tspFactStaffFilter.DropDownItems[(int)objectState] as ToolStripMenuItem).Checked)
                       factStaffFilters.Add(objectState);
               }

           }


           LoadFactStaff(factStaffFilters);
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
               Reports.Frames.DepAverageStaffBaseFrame CurrentFrame = null;
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

               if (tcAverageStaff.SelectedTab == tpDepPostAverage)
               {
                   CurrentFrame = depPostAverageStaffFrame1;
                   //if (depPostAverageStaffFrame1.ReportParam != Department.id)
                       //depPostAverageStaffFrame1.ReportParam = Department.id;
 
               }
               if ((CurrentFrame != null) && ((sender == null) || (CurrentFrame.ReportParam != Department.id)))
                    CurrentFrame.UpdateReportParams(Convert.ToInt32(cbYear.SelectedItem), Department.id, chbWithSubDeps.Checked);
            }
 
       }

       private void KadrRootFrame_Load(object sender, EventArgs e)
       {
           cbYear.Items.Clear();
           cbYear.Items.AddRange(KadrController.Instance.Model.TimeSheets.Select(ts => ts.TimeSheetYear as Object).Distinct().ToArray());
           cbYear.SelectedItem = DateTime.Today.Year;
           dtpPeriodBegin.Value = DateTime.Today.AddDays(-DateTime.Today.Day + 1);
           dtpPeriodEnd.Value = DateTime.Today;
           dtpBonRepPeriodBegin.Value = DateTime.Today.AddDays(-DateTime.Today.Day + 1);
           dtpBonRepPeriodEnd.Value = DateTime.Today;
           dtpStChPeriodBegin.Value = DateTime.Today.AddDays(-DateTime.Today.Day + 1);
           dtpStChPeriodEnd.Value = DateTime.Today;


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

           using (Kadr.UI.Common.PropertyGridDialogAdding<FactStaffHistory> dlg =
                new Kadr.UI.Common.PropertyGridDialogAdding<FactStaffHistory>())
           {
               dlg.UseInternalCommandManager = true;
               dlg.ObjectList = KadrController.Instance.Model.FactStaffHistories;
               //dlg.BindingSource = planStaffBindingSource;
               dlg.PrikazButtonVisible = true;
               dlg.oneObjectCreated = true;
               dlg.InitializeNewObject = (x) =>
               {
                   //dlg.CommandManager.Execute(new UIX.Commands.GenericPropertyCommand<FactStaffHistory, FactStaffHistory>(x, "FactStaffHistory1", currentFactStaff., null), this);
                   dlg.CommandManager.Execute(new UIX.Commands.GenericPropertyCommand<FactStaffHistory, decimal>(x, "StaffCount", currentFactStaff.StaffCount, null), this);
                   dlg.CommandManager.Execute(new UIX.Commands.GenericPropertyCommand<FactStaffHistory, WorkType>(x, "WorkType", currentFactStaff.WorkType, null), this);
                   dlg.CommandManager.Execute(new UIX.Commands.GenericPropertyCommand<FactStaffHistory, Prikaz>(x, "Prikaz", NullPrikaz.Instance, null), this);
                   dlg.CommandManager.Execute(new UIX.Commands.GenericPropertyCommand<FactStaffHistory, FactStaff>(x, "FactStaff", currentFactStaff, null), this);
               };

               dlg.UpdateObjectList = () =>
               {
                   dlg.ObjectList = KadrController.Instance.Model.FactStaffHistories;
               };

               dlg.ShowDialog();
               LoadPlanStaff();
           }
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
               Reports.Frames.DepAverageStaffBaseFrame CurrentFrame = null;
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

               if ((CurrentFrame != null) && ((sender == null) || (CurrentFrame.ReportParam != Department.id)))
                   CurrentFrame.UpdateReportParams(dtpPeriodBegin.Value, dtpPeriodEnd.Value, Department.id, chbFormsWithSubDeps.Checked);
           }
           
       }

       private void btnLoadReport_Click(object sender, EventArgs e)
       {
           tcForms_SelectedIndexChanged(null, null);
       }

       private void tcBonusReports_SelectedIndexChanged(object sender, EventArgs e)
       {
           if (tcDepartment.SelectedTab == tpDepBonusReport)
           {
               Reports.Frames.DepAverageStaffBaseFrame CurrentFrame = null;
               if (tcBonusReports.SelectedTab == tpEmplBonusReport)
               {
                   CurrentFrame = departmentBonusReportFrame1;
                   departmentBonusReportFrame1.ReportType = BonusReportType.DepartmentBonus;
                   //depCategoryAverageStaff1. .ReportParam = Department.id;
                   //depCategoryAverageStaff1.SelectedYear = Convert.ToInt32(cbYear.SelectedItem);

               }

               if (tcBonusReports.SelectedTab == tpPostBonusReport)
               {
                   CurrentFrame = depByPostBonusReportFrame1;
                   //depCategoryAverageStaff1. .ReportParam = Department.id;
                   //depCategoryAverageStaff1.SelectedYear = Convert.ToInt32(cbYear.SelectedItem);

               }

               if ((CurrentFrame != null) && ((sender == null) || (CurrentFrame.ReportParam != Department.id)))
               {

                   CurrentFrame.UpdateReportParams(dtpBonRepPeriodBegin.Value, dtpBonRepPeriodEnd.Value, Department.id, cbBonRepWithSubDeps.Checked);
               }
           }
       }

       private void btnBonusRepLoad_Click(object sender, EventArgs e)
       {
           tcBonusReports_SelectedIndexChanged(null, null);
       }

       private void btnTimeSheetToExcel_Click(object sender, EventArgs e)
       {
           Kadr.Controllers.ExcelExportController.Instance.ExportToExcel(dgvTimeSheetFS);
       }

       private void tcStaffChangesReport_SelectedIndexChanged(object sender, EventArgs e)
       {
           if (tcDepartment.SelectedTab == tpFactStaffChanges)
           {
               Reports.Frames.DepAverageStaffBaseFrame CurrentFrame = null;
               if (tcStaffChangesReport.SelectedTab == tpFactStaffChangesReport)
               {
                   CurrentFrame = factStaffChangesFrame1;
               }

               if (tcStaffChangesReport.SelectedTab == tpPostStaffChangesReport)
               {
                   CurrentFrame = postStaffChangesFrame1;
               }

               if ((CurrentFrame != null) && ((sender == null) || (CurrentFrame.ReportParam != Department.id)))
                   CurrentFrame.UpdateReportParams(dtpStChPeriodBegin.Value, dtpStChPeriodEnd.Value, Department.id, chbStChWithSubDeps.Checked);
           }

       }

       private void btnLoadStChReport_Click(object sender, EventArgs e)
       {
           tcStaffChangesReport_SelectedIndexChanged(null, null);
       }

       private void tsbCreateTimeSheet_Click(object sender, EventArgs e)
       {

       }

       

 
 
 
 
 







    }

}
