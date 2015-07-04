using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Linq;
using Kadr.Controllers;

namespace Kadr.UI.Common
{
    public partial class PropertyGridDialog : Kadr.UI.Common.CustomBaseDialog
    {

        //обновление списка объектов objectList
        public Action UpdateObjectList;

        private UIX.Commands.ICommandManager commandManager;

        public UIX.Commands.ICommandManager CommandManager
        {
            get
            {
                return commandManager;
            }
            set
            {
                if (value == commandManager) return;

                if (UseInternalCommandManager) 
                    throw new InvalidOperationException("Нельзя указать внешний контроллер команд, при установленном свойстве UseInternalCommandManager.");
                
                TerminateBatchCommand();                
                commandManager = value;                
                SetCommandRegister();
                
            }
        }        

        private void SetCommandRegister()
        {
            if (commandManager != null)
            {
                commandProperyGrid1.CommandRegister = commandManager.GetCommandRegister();
                if (!commandManager.IsInBatchMode)
                    commandManager.BeginBatchCommand();
            }
        }

        private bool useInternalCommandManager;

        private UIX.Commands.ICommandManager internalCommandManager;        
        private UIX.Commands.ICommandManager GetInternalCommandManager()
        {
            if (internalCommandManager == null)
                internalCommandManager = new UIX.Commands.CommandManager();
            return new UIX.Commands.CommandManager();        
        }

        public bool UseInternalCommandManager
        {
            get
            {
                return useInternalCommandManager;
            }
            set
            {
                if (value == useInternalCommandManager) return;
                useInternalCommandManager = value;
                commandManager = useInternalCommandManager ? GetInternalCommandManager() : null;
                SetCommandRegister();
            }                
        }
        // Наличие декоратора (поддержка объектами интерфейса IDecorator) 
        // подменяет объекты декораторами, однако клиент ожидает
        // на выходе иметь тот же набор объектов, что и на входе
        private object[] initialObjects;
        /// <summary>
        /// 
        /// </summary>
        public object[] SelectedObjects
        {
            get
            {
                return initialObjects;
            }
            set
            {
                if (value == null)
                {
                    commandProperyGrid1.SelectedObjects = null;
                    return;
                }

                initialObjects = value;

                UIX.Views.IDecorable[] decorableSet = initialObjects.OfType<UIX.Views.IDecorable>().ToArray();

                if (decorableSet.Length > 0)
                {
                    object[] decoratorSet = decorableSet.Select(ds => ds.GetDecorator()).ToArray();
                    commandProperyGrid1.SelectedObjects = decoratorSet;
                }
                else
                    commandProperyGrid1.SelectedObjects = initialObjects;

                SetupDialogCaption();
               
            }
        }

        private void SetupDialogCaption()
        {
            Text = "Свойства: ";
            if (commandProperyGrid1.SelectedObjects.Length > 0)
                Text += commandProperyGrid1.SelectedObjects[0].ToString();
            for (int i = 1; i < commandProperyGrid1.SelectedObjects.Length; i++)
                Text += ", " + commandProperyGrid1.SelectedObjects[i].ToString();
        }

        private void TerminateBatchCommand()
        {
            if (commandManager != null)
            {
                if (commandManager.IsInBatchMode)
                {
                    commandManager.TerminateBatchCommand();
                }
            }
        }        
        
        public PropertyGridDialog()
        {
            InitializeComponent();
        }
        // см. комментария для initialObjects
        private object initialObject;

        protected override void SetDialogObject(object value)
        {
           initialObject = value;
           commandProperyGrid1.SelectedObject = value;
           //SetupDialogCaption();
        }

        protected override object GetDialogObject()
        {
            return initialObject;         
        }

        protected override void DoApply()
        {            

            if (CommandManager != null)
            {
                if (CommandManager.IsInBatchMode)
                {
                    CommandManager.EndBatchCommand();
                }                
            }
            IsModified = false;
        }

        protected override void DoCancel()
        {
            TerminateBatchCommand();
            IsModified = false;
            
            ////удаляем объект, если он новый
            //if (isNewObject)
            //{
            //    (commandProperyGrid1.SelectedObject as ITableMapping).
            //}
        }

        private void PropertyGridDialog_Load(object sender, EventArgs e)
        {

        }

        private void commandProperyGrid1_PropertyValueChanged(object s, PropertyValueChangedEventArgs e)
        {
            IsModified = true;
        }

        public bool PrikazButtonVisible
        {
            get
            {
                return btnPrikaz.Visible;
            }
            set
            {
                btnPrikaz.Visible = value;

            }
        }

    }
}
