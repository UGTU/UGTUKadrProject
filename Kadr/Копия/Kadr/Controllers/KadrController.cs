using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Linq;
using UIX;
using Kadr.Data;
using Kadr.Data.Common;
//using System.Diagnostics.Contracts;
//using Microsoft.VisualStudio.TestTools.UnitTesting;


namespace Kadr.Controllers
{

    class KadrController: UIX.Controllers.GenericController<Kadr.Data.dckadrDataContext>
    {

        
        
        public event EventHandler<SubmitModelChangesArgs> SubmitingModelChanges;
        public event EventHandler<SubmitModelChangesArgs> SubmitModelChanges;

        //событие при создании модели
        public event EventHandler CreatingModel;

        private static KadrController instance;


        private KadrController() 
        {
        }

        protected override void OnModelCreated()
        {
            base.OnModelCreated();
            if (CreatingModel != null)
                CreatingModel(KadrController.Instance, EventArgs.Empty);
            

        }

        public void DeleteModel()
        {
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
                    instance = new KadrController();
                return instance;
            }
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

