using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Linq;
using UIX;
using Kadr.Data;
using Kadr.Data.Common;


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
            System.Windows.Forms.MessageBox.Show(e.Message, 
                APG.CodeHelper.UI.ApplicationAboutDialog.AssemblyTitle(GetType().Assembly), System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Information);
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
            this.Model = model;
            this.Deleted = deleted;
            this.Updated = updated;
            this.Inserted = inserted;
        }
    }


            /// <summary>

 
}

