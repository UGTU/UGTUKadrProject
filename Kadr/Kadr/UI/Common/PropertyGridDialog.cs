﻿using System;
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

        protected void TerminateBatchCommand()
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
            SubscribeContainerEvents();
            commandProperyGrid1.SelectedGridItemChanged += CommandProperyGrid1_SelectedGridItemChanged;
            //commandProperyGrid1.LabelColWidth = commandProperyGrid1.Width/4;
        }

        private void CommandProperyGrid1_SelectedGridItemChanged(object sender, SelectedGridItemChangedEventArgs e)
        {
            //
        }

        private void SubscribeContainerEvents()
        {
            SubscribeControlsEvents(commandProperyGrid1);
        }

        private void SubscribeControlsEvents(Control control)
        {
            //control.PreviewKeyDown += Item_PreviewKeyDown;
            control.KeyPress += Control_KeyPress;
            control.TabStop = true;
            foreach (Control item in control.Controls)
            {
                SubscribeControlsEvents(item);
            }
        }

        private void Control_KeyPress(object sender, KeyPressEventArgs e)
        {
            MessageBox.Show(sender.ToString());
        }

        private void Item_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            MessageBox.Show(sender.ToString());
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

            KadrController.Instance.DeleteModel();
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
            commandProperyGrid1.GetNextControl(commandProperyGrid1.ActiveControl,true).Focus();
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
        
        private void commandProperyGrid1_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (commandProperyGrid1.SelectedGridItem.PropertyDescriptor.ComponentType == typeof(DateTime))
            {
                if (commandProperyGrid1.SelectedGridItem.Value.ToString().Length == 2)
                    commandProperyGrid1.SelectedGridItem.PropertyDescriptor.SetValue(commandProperyGrid1.SelectedObject,commandProperyGrid1.SelectedGridItem.Value.ToString() + ".");


            }
        }

        private void PropertyGridDialog_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Tab)
                MessageBox.Show("TAB!");
        }

        private void commandProperyGrid1_PreviewKeyDown_1(object sender, PreviewKeyDownEventArgs e)
        {
            if (e.KeyCode == Keys.Tab)
                MessageBox.Show("TAB!");
        }
        /*
private void commandProperyGrid1_Click(object sender, EventArgs e)
{
MessageBox.Show("!");
}

private void commandProperyGrid1_MouseClick(object sender, MouseEventArgs e)
{
MessageBox.Show("Clicked");
}
*/
    }
}
