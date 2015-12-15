using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Data.Linq;
using System.Windows.Forms;
using UIX;
using Kadr.Data;
using Kadr.Data.Common;
//using System.Diagnostics.Contracts;
//using Microsoft.VisualStudio.TestTools.UnitTesting;


namespace Kadr.Controllers
{

    public class KadrController: UIX.Controllers.GenericController<Kadr.Data.dckadrDataContext>
    {

        /// <summary>
        /// Текущая версия БД (для проверки соотвествия)
        /// </summary>
        private const string CurrentDBVersion = "1.1";
        
        public event EventHandler<SubmitModelChangesArgs> SubmitingModelChanges;
        public event EventHandler<SubmitModelChangesArgs> SubmitModelChanges;

        //событие при создании модели
        public event EventHandler CreatingModel;

        private static KadrController instance;


        private KadrController() 
        {
        }

        /// <summary>
        /// Проверка соответсвия версии БД
        /// </summary>
        /// <returns></returns>
        public bool CheckDataBaseVersion()
        {
            /*if (Model.AuditKadrVersions.Max(KV => KV.idVersion) != CurrentDBVersion)
            {
                MessageBox.Show("Текущая версия базы данных не соответсвует приложению.", "ИС \"Учет кадров\"");
                return false;
            }*/
            return true;
        }

        protected override void OnModelCreated()
        {
            base.OnModelCreated();
            if (CreatingModel != null)
                CreatingModel(KadrController.Instance, EventArgs.Empty);
            KadrController.Instance.Model.CommandTimeout = 100000;

        }

        public void DeleteModel()
        {
            //Model.Refresh(RefreshMode.OverwriteCurrentValues);
            Model = null;
            //обращаемся к модели, чтобы обновились все представления
            Model.SubmitChanges();

        }

        /// <summary>
        /// Получает единственный экземпляр контроллера
        /// </summary>
        public static KadrController Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new KadrController();
                    instance.CreatingModel += instance_CreatingModel;
                }
                return instance;
            }
        }

        static void instance_CreatingModel(object sender, EventArgs e)
        {
            var controller = sender as KadrController;
            Debug.Assert(controller != null);                        
        }


        /// <summary>
        /// Сохраняет изменения в модели
        /// </summary>
        public void SubmitChanges()
        {
            //Contract.Requires(Model != null);
            //try
            //{
                Model.SubmitChanges();
            //}

            //catch
            //{
            //    if (recreate == SubmitParams.RecreateModel)
            //    {
                    //DeleteModel();
                    //throw new ApplicationException("При сохранении данных возникла ошибка. Изменения будут отменены.");
            //    }

            //}

        }


        public void SubmitChanges(Kadr.Data.dckadrDataContext model)
        {
            //Contract.Requires(model!=null);

            ChangeSet chset = model.GetChangeSet();
            
            SubmitModelChangesArgs args = 
                new SubmitModelChangesArgs(model, 
                    new List<object>(chset.Deletes), 
                    new List<object>(chset.Inserts), 
                    new List<object>(chset.Updates));



            if (SubmitingModelChanges != null)
                SubmitingModelChanges(this, args);

            //Execute(new Commands.SubmitChangesCommand(model));

            
            if (SubmitModelChanges != null)
                SubmitModelChanges(this, args);


        }

        


        private string GetCurrentUser()
        {
            return System.Security.Principal.WindowsIdentity.GetCurrent().Name;
        }        

        internal void BeginBatchCommand(bool isOneWayCommand)
        {
            //Manager.BeginBatchCommand(isOneWayCommand);
        }

        internal void ShowApplicationException(Exception e)
        {
            //Contract.Requires(e != null);
            System.Windows.Forms.MessageBox.Show(e.Message, 
                APG.CodeHelper.UI.ApplicationAboutDialog.AssemblyTitle(GetType().Assembly), System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Information);
        }

        /// <summary>
        /// Возвращиет список отделов, соответсвующих представлению departments
        /// </summary>
        /// <param name="departments"></param>
        /// <returns></returns>
        public IEnumerable<Dep> GetDepsForDepartments(IEnumerable<Department> departments)
        {
            return departments.SelectMany(dep => KadrController.Instance.Model.Deps.Where(departs => departs.id == dep.id));
                
                
                /*.Join(Model.Deps, department => department.id, dep => dep.id,
                    (department, dep) => new Dep
                    {
                        id = dep.id,
                        //idManagerDapartment = subDeps.idManagerDepartment,
                        idManagerPlanStaff = dep.idManagerPlanStaff,
                        idDepartmentType = dep.idDepartmentType,
                        KadrID = dep.KadrID,
                        dateExit = dep.dateExit,
                        idEndPrikaz = dep.idEndPrikaz,
                        SeverKoeff = dep.SeverKoeff,
                        RayonKoeff = dep.RayonKoeff,
                        DepartmentGUID = dep.DepartmentGUID
                    });*/
        }

        /*public void AddFactStaff(System.Windows.Forms.BindingSource factStaffBindingSource, PlanStaff planStaffCurrent, Dep department = null, WorkType workType = null)
        {
            if (workType == null)
                workType = NullWorkType.Instance;

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
                    dlg.CommandManager.Execute(new UIX.Commands.GenericPropertyCommand<FactStaff, PlanStaff>(x, "PlanStaff", planStaffCurrent, null), this);
                    //dlg.CommandManager.Execute(new UIX.Commands.GenericPropertyCommand<FactStaff, Dep>(x, "Dep", (planStaffBindingSource.Current as PlanStaff).Dep, null), this);
                    if ((dlg.SelectedObjects != null) && (dlg.SelectedObjects.Length == 1))
                    {
                        FactStaff prev = dlg.SelectedObjects[0] as FactStaff;
                        //dlg.CommandManager.Execute(new UIX.Commands.GenericPropertyCommand<FactStaffHistory, DateTime?>(fcStHistory, "DateBegin", prev.CurrentChange.DateBegin, null), this);
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
                        dlg.CommandManager.Execute(new UIX.Commands.GenericPropertyCommand<FactStaffHistory, WorkType>(fcStHistory, "WorkType", workType, null), this);
                        //dlg.CommandManager.Execute(new UIX.Commands.GenericPropertyCommand<FactStaff, Prikaz>(x, "PrikazBegin", NullPrikaz.Instance, null), this);
                        //dlg.CommandManager.Execute(new UIX.Commands.GenericPropertyCommand<FactStaff, WorkType>(x, "WorkType", NullWorkType.Instance, null), this);
                        dlg.CommandManager.Execute(new UIX.Commands.GenericPropertyCommand<FactStaff, Employee>(x, "Employee", NullEmployee.Instance, null), this);
                    }
                    dlg.CommandManager.Execute(new UIX.Commands.GenericPropertyCommand<FactStaff, bool>(x, "IsReplacement", false, null), this);
                    dlg.CommandManager.Execute(new UIX.Commands.GenericPropertyCommand<FactStaff, Dep>(x, "Dep", department, null), this);
                    dlg.CommandManager.Execute(new UIX.Commands.GenericPropertyCommand<FactStaff, FundingCenter>(x, "FundingCenter", NullFundingCenter.Instance, null), this);
                    //dlg.CommandManager.Execute(new UIX.Commands.GenericPropertyCommand<FactStaffHistory, decimal>(fcStHistory, "SalaryKoeff", 1, null), this);
                    dlg.CommandManager.Execute(new UIX.Commands.GenericPropertyCommand<FactStaffHistory, FactStaff>(fcStHistory, "FactStaff", x, null), this);
                };

                dlg.UpdateObjectList = () =>
                {
                    dlg.ObjectList = KadrController.Instance.Model.FactStaffs;
                };
                dlg.ShowDialog();
            }
        }*/

        

        public void AddFactStaffMonthHour(FactStaff currentFactStaff)
        {
            using (Kadr.UI.Common.PropertyGridDialogAdding<FactStaffMonthHour> dlg =
                new Kadr.UI.Common.PropertyGridDialogAdding<FactStaffMonthHour>())
            {
                dlg.UseInternalCommandManager = true;
                dlg.ObjectList = KadrController.Instance.Model.FactStaffMonthHours;
                //dlg.BindingSource = planStaffBindingSource;
                dlg.PrikazButtonVisible = false;
                dlg.oneObjectCreated = true;
                dlg.InitializeNewObject = (x) =>
                {
                    //dlg.CommandManager.Execute(new UIX.Commands.GenericPropertyCommand<FactStaffHistory, FactStaffHistory>(x, "FactStaffHistory1", currentFactStaff., null), this);
                    dlg.CommandManager.Execute(new UIX.Commands.GenericPropertyCommand<FactStaffMonthHour, FactStaff>(x, "FactStaff", currentFactStaff, null), this);
                    dlg.CommandManager.Execute(new UIX.Commands.GenericPropertyCommand<FactStaffMonthHour, int>(x, "YearNumber", DateTime.Today.Year, null), this);
                    dlg.CommandManager.Execute(new UIX.Commands.GenericPropertyCommand<FactStaffMonthHour, int>(x, "MonthNumber", DateTime.Today.Month, null), this);
                    dlg.CommandManager.Execute(new UIX.Commands.GenericPropertyCommand<FactStaffMonthHour, decimal>(x, "HourCount", 0, null), this);
                };

                dlg.UpdateObjectList = () =>
                {
                    dlg.ObjectList = KadrController.Instance.Model.FactStaffMonthHours;
                };

                dlg.ShowDialog();
            }
        }

        public IEnumerable<FactStaff> GetHourFactStaff(Dep Department)
        {
            if (Department == null)
                Department = MagicNumberController.UGTUDep;
            return KadrController.Instance.Model.FactStaffs.Where(fS => fS.idMainFactStaff == null).Where(
                        fact => ((fact.Dep == Department) || (Department.ManagerDepartment == null)) && (fact.Dep != null)).OrderBy(
                            fcSt => fcSt.FinancingSource.OrderBy).ThenBy(fcSt => fcSt.Employee.EmployeeName).ToArray().Where(fact =>
                            (fact.WorkType == MagicNumberController.hourWorkType)).ToArray();
        }

        public IEnumerable<BonusType> GetCurrentBonusTypes()
        {
            return Kadr.Controllers.KadrController.Instance.Model.BonusTypes.Where(p => (p.DateEnd > DateTime.Today) || (p.DateEnd == null));
        }

    }


    public class SubmitModelChangesArgs : EventArgs
    {
        public IList<object> Deleted { get; private set; }
        public IList<object> Inserted { get; private set; }
        public IList<object> Updated { get; private set; }
        
        public Kadr.Data.dckadrDataContext Model { get; private set; }

        public SubmitModelChangesArgs(Kadr.Data.dckadrDataContext model, IList<object> deleted, IList<object> inserted, IList<object> updated)
        {
            // Предусловия
            //Contract.Requires(model != null);
            //Contract.Requires(deleted != null);
            //Contract.Requires(inserted != null);
            //Contract.Requires(updated != null);

            this.Model = model;
            this.Deleted = deleted;
            this.Updated = updated;
            this.Inserted = inserted;


            //Инвариант
            //Contract.Invariant

            // Постуслования
            //Contract.Ensures(this.Model != null);
            //Contract.Ensures(this.Deleted != null);
            //Contract.Ensures(this.Updated != null);
            //Contract.Ensures(this.Inserted != null);
        }
    }



            /// <summary>

 
}

