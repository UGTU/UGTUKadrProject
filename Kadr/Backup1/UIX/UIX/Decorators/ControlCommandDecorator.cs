using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.ComponentModel;

namespace UIX.Decorators
{

    class ControlCommandDecorator
    {
        #region Private fields
        private UIX.Commands.ICommandManager commandManager;
        private Control control;
        #endregion

        public ControlCommandDecorator(UIX.Commands.ICommandManager commandManager, Control control)
        {
            this.commandManager = commandManager;
            this.control = control;
        }

        [DisplayName("Цвет фона")]
        [Category("Оформление")]
        public System.Drawing.Color BackColor
        {
            get
            {
                return control.BackColor;
            }
            set
            {
                commandManager.Execute(new UIX.Commands.GenericPropertyCommand<Control, System.Drawing.Color>(control, "BackColor", value, null), this);
            }
        }

        [DisplayName("Рисунок фона")]
        [Category("Оформление")]
        public System.Drawing.Image BackgroundImage
        {
            get
            {
                return control.BackgroundImage;
            }
            set
            {
                commandManager.Execute(new UIX.Commands.GenericPropertyCommand<Control, System.Drawing.Image>(control, "BackgroundImage", value, null), this);
            }
        }

        [DisplayName("Положение рисунка фона")]
        [Category("Оформление")]        
        public ImageLayout BackgroundImageLayout
        {
            get
            {
                return control.BackgroundImageLayout;
            }
            set
            {
                commandManager.Execute(new UIX.Commands.GenericPropertyCommand<Control, ImageLayout>(control, "BackgroundImageLayout", value, null), this);
            }
        }

        [DisplayName("Курсор")]
        [Category("Оформление")]        
        public Cursor Cursor
        {
            get
            {
                return control.Cursor;
            }
            set
            {
                commandManager.Execute(new UIX.Commands.GenericPropertyCommand<Control, Cursor>(control, "Cursor", value, null), this);
            }
        }

        [DisplayName("Шрифт")]
        [Category("Оформление")]        
        public System.Drawing.Font Font
        {
            get
            {
                return control.Font;
            }
            set
            {
                commandManager.Execute(new UIX.Commands.GenericPropertyCommand<Control, System.Drawing.Font>(control, "Font", value, null), this);
            }
        }

        [DisplayName("Цвет текста")]
        [Category("Оформление")]        
        public System.Drawing.Color ForeColor
        {
            get
            {
                return control.ForeColor;
            }
            set
            {
                commandManager.Execute(new UIX.Commands.GenericPropertyCommand<Control, System.Drawing.Color>(control, "ForeColor", value, null), this);
            }
        }
        
       
    }
}
