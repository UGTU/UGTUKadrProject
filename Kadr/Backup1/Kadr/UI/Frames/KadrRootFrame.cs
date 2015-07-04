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
using Kadr.KadrTreeView;
using Kadr.UI.Dialogs;
using Kadr.Data.Common;

namespace Kadr.UI.Frames
{
    public partial class KadrRootFrame : KadrBaseFrame
    {
        /// <summary>
        /// Отображаемый отдел
        /// </summary>
        public Kadr.Data.Department Department                    
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
                departmentBindingSource.DataSource = Department.Departments.Where(dep => dep.dateExit == null).OrderBy( dep => dep.DepartmentName);

            }
        }

        private void LoadPlanStaff()
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
                planStaffBindingSource.DataSource = KadrController.Instance.Model.PlanStaffs.Where(planSt => planSt.Department == Department);
               
            }
        }

        private void LoadFactStaff()
        {
            if ((planStaffBindingSource.Current as Kadr.Data.PlanStaff) != null)
                factStaffBindingSource.DataSource =
                    KadrController.Instance.Model.FactStaffs.Where(fact => fact.PlanStaff == (planStaffBindingSource.Current as Kadr.Data.PlanStaff)); 

                    
        }

        #endregion


        protected override void DoRefreshFrame()
        {
            LoadSprav();
            LoadPlanStaff();
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
                    dlg.CommandManager.Execute(new UIX.Commands.GenericPropertyCommand<PlanStaff, Department>(x, "Department", Department, null), this);
                    if ((dlg.SelectedObjects != null) && (dlg.SelectedObjects.Length == 1))
                    {
                        PlanStaff prev = dlg.SelectedObjects[0] as PlanStaff;
                        dlg.CommandManager.Execute(new UIX.Commands.GenericPropertyCommand<PlanStaff, Prikaz>(x, "Prikaz", prev.Prikaz, null), this);
                        dlg.CommandManager.Execute(new UIX.Commands.GenericPropertyCommand<PlanStaff, Prikaz>(x, "Prikaz1", prev.Prikaz1, null), this);
                        dlg.CommandManager.Execute(new UIX.Commands.GenericPropertyCommand<PlanStaff, Category>(x, "Category", prev.Category, null), this);
                        dlg.CommandManager.Execute(new UIX.Commands.GenericPropertyCommand<PlanStaff, decimal>(x, "StaffCount", prev.StaffCount, null), this);
                        dlg.CommandManager.Execute(new UIX.Commands.GenericPropertyCommand<PlanStaff, FinancingSource>(x, "FinancingSource", prev.FinancingSource, null), this);
                        dlg.CommandManager.Execute(new UIX.Commands.GenericPropertyCommand<PlanStaff, Post>(x, "Post", NullPost.Instance, null), this);
                    }
                    else
                    {
                        dlg.CommandManager.Execute(new UIX.Commands.GenericPropertyCommand<PlanStaff, Prikaz>(x, "Prikaz", NullPrikaz.Instance, null), this);
                        dlg.CommandManager.Execute(new UIX.Commands.GenericPropertyCommand<PlanStaff, Post>(x, "Post", NullPost.Instance, null), this);
                        dlg.CommandManager.Execute(new UIX.Commands.GenericPropertyCommand<PlanStaff, Category>(x, "Category", NullCategory.Instance, null), this);
                        dlg.CommandManager.Execute(new UIX.Commands.GenericPropertyCommand<PlanStaff, FinancingSource>(x, "FinancingSource", NullFinancingSource.Instance, null), this);
                    }
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
                   dlg.CommandManager.Execute(new UIX.Commands.GenericPropertyCommand<FactStaff, PlanStaff>(x, "PlanStaff", planStaffBindingSource.Current as PlanStaff, null), this);
                   if ((dlg.SelectedObjects != null) && (dlg.SelectedObjects.Length == 1))
                   {
                       FactStaff prev = dlg.SelectedObjects[0] as FactStaff;
                       dlg.CommandManager.Execute(new UIX.Commands.GenericPropertyCommand<FactStaff, DateTime?>(x, "DateBegin", prev.DateBegin, null), this);
                       dlg.CommandManager.Execute(new UIX.Commands.GenericPropertyCommand<FactStaff, Prikaz>(x, "Prikaz", prev.Prikaz, null), this);
                       dlg.CommandManager.Execute(new UIX.Commands.GenericPropertyCommand<FactStaff, Prikaz>(x, "Prikaz1", prev.Prikaz1, null), this);
                       dlg.CommandManager.Execute(new UIX.Commands.GenericPropertyCommand<FactStaff, WorkType>(x, "WorkType", prev.WorkType, null), this);
                       dlg.CommandManager.Execute(new UIX.Commands.GenericPropertyCommand<FactStaff, decimal>(x, "StaffCount", prev.StaffCount, null), this);
                       dlg.CommandManager.Execute(new UIX.Commands.GenericPropertyCommand<FactStaff, Employee>(x, "Employee", NullEmployee.Instance, null), this);

                   }
                   else
                   {
                       dlg.CommandManager.Execute(new UIX.Commands.GenericPropertyCommand<FactStaff, Prikaz>(x, "Prikaz", NullPrikaz.Instance, null), this);
                       dlg.CommandManager.Execute(new UIX.Commands.GenericPropertyCommand<FactStaff, WorkType>(x, "WorkType", NullWorkType.Instance, null), this);
                       dlg.CommandManager.Execute(new UIX.Commands.GenericPropertyCommand<FactStaff, Employee>(x, "Employee", NullEmployee.Instance, null), this);
                   }
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
           LinqActionsController<FactStaff>.Instance.EditObject(factStaffBindingSource.Current as Kadr.Data.FactStaff, true);
       }



       private void DelPlanStaffBtn_Click(object sender, EventArgs e)
       {
           if (MessageBox.Show("Удалить запись штатного расписания?", "АИС Штатное расписание", MessageBoxButtons.OKCancel)
               == DialogResult.OK)
           {
               LinqActionsController<PlanStaff>.Instance.DeleteObject(planStaffBindingSource.Current as Kadr.Data.PlanStaff,
                    KadrController.Instance.Model.PlanStaffs, planStaffBindingSource);

           }
       }

       private void DelFactStaffBtn_Click(object sender, EventArgs e)
       {
           if (MessageBox.Show("Удалить сотрудника?", "АИС Штатное расписание", MessageBoxButtons.OKCancel)
               == DialogResult.OK)
           {
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
               if (currentFactStaff.Prikaz1 != null)
               {
                   MessageBox.Show("Cотрудник " + currentFactStaff.Employee.ToString() + " уже уволен!");
                   return;
               }
           }

           using (FactStaffTransfer dlg = new FactStaffTransfer())
           {
               dlg.Department = Department;
               dlg.CurentPlanStaff = planStaffBindingSource.Current as Kadr.Data.PlanStaff;
               dlg.ShowDialog();
               //переводим
               try
               {
                   if (dlg.DialogResult == DialogResult.OK)
                   {
                       foreach (DataGridViewRow selectedRow in dgvFactStaff.SelectedRows)
                       {
                           //в текущей записи выставляем приказ о переводе и дату перевода
                           FactStaff currentFactStaff = (selectedRow.DataBoundItem as FactStaff);
                           currentFactStaff.Prikaz1 = dlg.TransferPrikaz;
                           currentFactStaff.DateEnd = dlg.TransferData;

                           //создаем новую запись - с даты перевода и приказом о преводе
                           FactStaff newFactStaff = new FactStaff();
                           newFactStaff.Employee = currentFactStaff.Employee;
                           newFactStaff.WorkType = currentFactStaff.WorkType;
                           newFactStaff.StaffCount = currentFactStaff.StaffCount;
                           newFactStaff.DateBegin = dlg.TransferData;
                           newFactStaff.Prikaz = dlg.TransferPrikaz;
                           newFactStaff.PlanStaff = dlg.NewPlanStaff;

                           //закрепляем, сохраняем новую запись
                           KadrController.Instance.Model.FactStaffs.InsertOnSubmit(newFactStaff);
                           KadrController.Instance.SubmitChanges();

                       }
                   }
               }
               catch (Exception exp)
               {

                   MessageBox.Show(exp.Message, "АИС \"Штатное расписание\"");
                   //KadrController.Instance.DeleteModel();
                   return;
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

       private void btnSalaryAdd_Click(object sender, EventArgs e)
       {
           PlanStaff CurrentPlanStaff = planStaffBindingSource.Current as Kadr.Data.PlanStaff;
           if (CurrentPlanStaff.IsNull())
           {
               MessageBox.Show("Не выбрана запись штатного расписания!", "АИС \"Штатное расписание\"");
               return;
           }

           using (Kadr.UI.Common.PropertyGridDialogAdding<PlanStaffSalary> dlg =
               new Kadr.UI.Common.PropertyGridDialogAdding<PlanStaffSalary>())
           {
               dlg.UseInternalCommandManager = true;
               dlg.ObjectList = KadrController.Instance.Model.PlanStaffSalaries;
               dlg.ApplyButtonVisible = false;
               dlg.InitializeNewObject = (x) =>
               {
                   dlg.CommandManager.Execute(new UIX.Commands.GenericPropertyCommand<PlanStaffSalary, PlanStaff>(x, "PlanStaff", CurrentPlanStaff, null), this);
               };
               dlg.oneObjectCreated = true;

               dlg.ShowDialog();
               RefreshFrame();
           }

       }

       private void btnEditSalary_Click(object sender, EventArgs e)
       {
           PlanStaff CurrentPlanStaff = planStaffBindingSource.Current as Kadr.Data.PlanStaff;
           if (CurrentPlanStaff.HaveIndivSal)
           {
               LinqActionsController<PlanStaffSalary>.Instance.EditObject(CurrentPlanStaff.planStaffSalary, false);
               RefreshFrame();
           }
           else
           {
               MessageBox.Show("Выбранной вами записи штатного расписания еще не назначен оклад.", "АИС Штатное расписание", MessageBoxButtons.OK);

           }

       }








    }

}
