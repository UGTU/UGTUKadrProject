﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Reflection;

namespace UIX.UI
{
    public partial class CommandPropertyGrid : PropertyGrid
    {
        private Commands.ICommandRegister commandRegister;

        new public object SelectedObject
        {
            get
            {
                return base.SelectedObject;
            }
            set
            {
                Views.IDecorable asDecorable = value as Views.IDecorable;
                if (asDecorable != null)
                    base.SelectedObject = asDecorable.GetDecorator();
                else
                    base.SelectedObject = value;
            }
        }

        /// <summary>
        /// Регистратор команд
        /// </summary>
        public Commands.ICommandRegister CommandRegister
        {
            get { return commandRegister; }
            set { commandRegister = value; }
        }
        
        public CommandPropertyGrid()
        {
            InitializeComponent();
        }

        protected override void OnPropertyValueChanged(PropertyValueChangedEventArgs e)
        {
            if (CommandRegister != null)
            {
                RegisterCommand(e);
            }
            base.OnPropertyValueChanged(e);
        }

        private void RegisterCommand(PropertyValueChangedEventArgs e)
        {
            if (SelectedObjects == null)
            {
                CommandRegister.RegisterCommand(new Commands.PropertyCommand(
                    SelectedObject, e.ChangedItem.PropertyDescriptor.Name,
                    e.ChangedItem.Value, e.OldValue, null));
            }
            else
            {
                for (int i = 0; i < SelectedObjects.Length; i++)
                {
                    CommandRegister.RegisterCommand(new Commands.PropertyCommand(
                    SelectedObjects[i], e.ChangedItem.PropertyDescriptor.Name,
                    e.ChangedItem.Value, e.OldValue, null));
                }
            }

            
        }

        public int LabelColumnWidth
        {
            get
            {
                Type type = GetType().BaseType;
                FieldInfo field = type.GetField("gridView",
                BindingFlags.NonPublic | BindingFlags.Instance);

                object valGrid = field.GetValue(this);
                Type gridType = valGrid.GetType();
                return (int)gridType.InvokeMember("GetLabelWidth", BindingFlags.Public | BindingFlags.InvokeMethod | BindingFlags.Instance, null, valGrid, new object[] { });

                
            }
            set
            {
                Type type = GetType().BaseType;
                FieldInfo field = type.GetField("gridView",
                BindingFlags.NonPublic | BindingFlags.Instance);

                object valGrid = field.GetValue(this);
                Type gridType = valGrid.GetType();
                gridType.InvokeMember("MoveSplitterTo", BindingFlags.NonPublic | BindingFlags.InvokeMethod | BindingFlags.Instance, null, valGrid, new object[] { value });
            }
        }
    }
}
