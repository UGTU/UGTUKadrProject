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

        public void ExpandGroup(string groupName)
        {
            GridItem root = SelectedGridItem;
            //Get the parent
            while (root.Parent != null)
                root = root.Parent;

            if (root != null)
            {
                foreach (GridItem g in root.GridItems)
                {
                    if (g.GridItemType == GridItemType.Category && g.Label == groupName)
                    {
                        g.Expanded = false;
                        break;
                    }
                }
            }
        }

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

        protected override void OnMouseClick(MouseEventArgs e)
        {
            base.OnMouseClick(e);
            
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
        protected override void OnClick(EventArgs e)
        {
            base.OnClick(e);
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

        public int LabelColWidth
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
