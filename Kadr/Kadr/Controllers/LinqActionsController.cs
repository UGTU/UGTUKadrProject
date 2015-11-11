﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using Kadr.Controllers;
using System.Windows.Forms;
using Kadr.Data;

namespace Kadr.Controllers
{
    /*class WithID
    {
        public int id;
    }

    class GenericMethodsCotroller<T> where T : WithID
    {
        public static T GetCurrentObject(BindingSource bindingSource, System.Data.Linq.Table<T> objectList)  
        {
            T currentObject = bindingSource.Current as T;
            if (currentObject == null)
                return null;
            return objectList.SingleOrDefault(obj => obj.id == currentObject.id);
        }
    }*/

    class LinqActionsController<T> where T : class
    {
        private static LinqActionsController<T> instance;

        private LinqActionsController() 
        {
        }


        /// <summary>
        /// Получает единственный экземпляр контроллера
        /// </summary>
        public static LinqActionsController<T> Instance
        {
            get
            {
                if (instance == null)
                    instance = new LinqActionsController<T>();
                return instance;
            }
        }


        /// <summary>
        /// Модель
        /// </summary>
        public Kadr.Data.dckadrDataContext Model
        {
            get
            {
                return KadrController.Instance.Model;
            }
        }

        /// <summary>
        /// Удаление объекта (записи)
        /// </summary>
        /// <param name="delObject">Удаляемый объект</param>
        /// <param name="objectList">Список объектов, из которого удаляем</param>
        /// <param name="bindingSource"></param>
        public void DeleteObject(T delObject, System.Data.Linq.Table<T> objectList, BindingSource bindingSource)
        {
            if (delObject == null)
            {
                MessageBox.Show("Не выбран удаляемый объект.", "АИС \"Штатное расписание\"");
                return;
            }

            try
            {
                objectList.DeleteOnSubmit(delObject);
                KadrController.Instance.SubmitChanges();
                if (bindingSource != null)
                    bindingSource.Remove(bindingSource.Current);

            }
            catch 
            {
                KadrController.Instance.DeleteModel();
                MessageBox.Show("Удаление невозможно, так как удаляемый объект уже используется.", "АИС \"Штатное расписание\"");
            }
        }



        public void EditObject(T editObject, bool PrikazConnected)
        {
            if (editObject == null)
            {
                MessageBox.Show("Не выбран редактируемый объект.", "ИС \"Управление кадрами\"");
                return;
            }

            using (var dlg = new Kadr.UI.Common.LinqPropertyGridDialogEditing<T>())
            {
                dlg.UseInternalCommandManager = true;
                //dlg.PrikazButtonVisible = false;
                dlg.SelectedObjects = new object[] { editObject };

                /*dlg.UpdateObjectList = () =>
                {
                    dlg.ObjectList = KadrController.Instance.Model.FactStaffs;
                };*/
                dlg.ShowDialog();
            }

        }

        

    }
}
