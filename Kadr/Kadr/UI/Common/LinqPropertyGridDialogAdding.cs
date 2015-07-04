using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Kadr.Controllers;
using UIX.Actions;
using Kadr.UI.Dialogs;
using Kadr.Data;

namespace Kadr.UI.Common
{
    public partial class PropertyGridDialogAdding<T> : PropertyGridDialog where T : class, new()
    {
        //признак того, что создается один объект
        protected bool OneObjectCreated;

        public bool oneObjectCreated
        {
            get
            {
                return OneObjectCreated;
            }
            set
            {
                OneObjectCreated = value;
                ApplyButtonVisible = !OneObjectCreated;
            }
        }



        //инициализация нового объекта
        public Action<T> InitializeNewObject;

        //создание связанных объектов
        public Action<T> CreateRelatedObject;


        T newObject;    //текущий объект

        public PropertyGridDialogAdding()
        {
            InitializeComponent();
            oneObjectCreated = false;

        }



        //список объектов (записей), в которые производится добавление объектов
        private System.Data.Linq.Table<T> objectList;

        public System.Data.Linq.Table<T> ObjectList
        {
            get
            {
                return objectList;
            }
            set
            {
                objectList = value;
            }
        }


        //bindingSource, в который производится добавление
        private BindingSource bindingSource;

        public BindingSource BindingSource
        {
            get { return bindingSource; }
            set { bindingSource = value; }
        }



        /// <summary>
        /// Создание нового объекта
        /// </summary>
        protected void CreateNewObject()
        {
            newObject = new T();        //новый объект

            if (InitializeNewObject != null)
               InitializeNewObject(newObject);

            SelectedObjects = new object[] { newObject };
            IsModified = true;


        }
        
        protected override void DoApply()
        {
            UIX.Views.IValidatable validatable = (SelectedObjects[0] as UIX.Views.IValidatable);
            if (validatable != null)
                validatable.Validate();


            //добавляем связанные объекты, если необходимо
            if (CreateRelatedObject != null)
                CreateRelatedObject(newObject);

            //сохраняем прежний объект
            if (objectList != null)
            {
                objectList.InsertOnSubmit(newObject);
                if (bindingSource!=null)
                    bindingSource.Add(newObject);
            }
            else
            {
                FactStaff factStaff=null;
                if (newObject is Kadr.Data.FactStaffHour)
                {
                    factStaff = (newObject as Kadr.Data.FactStaffHour).FactStaff;
                }
                if (newObject is Kadr.Data.FactStaffHourContract)
                {
                    factStaff = (newObject as Kadr.Data.FactStaffHourContract).FactStaff;
                }

                if (factStaff != null)
                {
                    KadrController.Instance.Model.FactStaffs.InsertOnSubmit(factStaff);
                    bindingSource.Add(factStaff);
                }
           }


            try
            {
                KadrController.Instance.SubmitChanges();
            }
            catch (Exception exp)
            {
                if (objectList != null)
                {
                    objectList.DeleteOnSubmit(newObject);
                }
                else
                {
                    FactStaff factStaff = null;
                    if (newObject is Kadr.Data.FactStaffHour)
                    {
                        factStaff = (newObject as Kadr.Data.FactStaffHour).FactStaff;
                    }
                    if (newObject is Kadr.Data.FactStaffHourContract)
                    {
                        factStaff = (newObject as Kadr.Data.FactStaffHourContract).FactStaff;
                    }

                    if (factStaff != null)
                    {
                        KadrController.Instance.Model.FactStaffs.DeleteOnSubmit(factStaff);
                    }
                }
                
                throw new Exception(exp.Message);
            }


            base.DoApply();
            if (!OKClicked)
            {
                this.CommandManager.BeginBatchCommand();
                //создаем новый объект
                CreateNewObject();
            }
        }

        protected override void DoCancel()
        {
            base.DoCancel();
        }

        private void PropertyGridDialogAdding_Load(object sender, EventArgs e)
        {
            CreateNewObject();
            oneObjectCreated = OneObjectCreated;

                        
        }

        private void btnPrikaz_Click(object sender, EventArgs e)
        {

            if (UpdateObjectList == null)
            {
                MessageBox.Show("Не заданы все необходимые условия для вызова диалога \"Приказы\".", "АИС \"Штатное расписание\"");
                return;
            }
           
            
            using (PrikazDialog dlg = new PrikazDialog())
             {
                 //сворачиваем все операции с объектом
                if (CommandManager.IsInBatchMode) 
                    CommandManager.EndBatchCommand();

                 try
                 {
                     CommandManager.Unexecute(sender);
                     if (dlg.ShowDialog() == DialogResult.OK)
                     {
                         //заново все операции проводим
                         CommandManager.Redo(sender);
                     }
                     else
                     {
                         //обновляем модель (на случай отмены изменений и уничтожения модели)
                         SelectedObjects = new object[] { };
                         UpdateObjectList();
                         CommandManager.BeginBatchCommand();
                         CreateNewObject();
                     }
                 }
                 finally
                 {
                     if (!CommandManager.IsInBatchMode)
                        CommandManager.BeginBatchCommand();
                 }

             }


        }






    }
}
