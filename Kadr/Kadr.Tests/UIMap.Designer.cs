﻿// ------------------------------------------------------------------------------
//  <auto-generated>
//      Этот код был создан построителем кодированных тестов ИП.
//      Версия: 14.0.0.0
//
//      Изменения, внесенные в этот файл, могут привести к неправильной работе кода и будут
//      утрачены при повторном формировании кода.
//  </auto-generated>
// ------------------------------------------------------------------------------

namespace Kadr.Tests
{
    using System;
    using System.CodeDom.Compiler;
    using System.Collections.Generic;
    using System.Drawing;
    using System.Text.RegularExpressions;
    using System.Windows.Input;
    using Microsoft.VisualStudio.TestTools.UITest.Extension;
    using Microsoft.VisualStudio.TestTools.UITesting;
    using Microsoft.VisualStudio.TestTools.UITesting.WinControls;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Keyboard = Microsoft.VisualStudio.TestTools.UITesting.Keyboard;
    using Mouse = Microsoft.VisualStudio.TestTools.UITesting.Mouse;
    using MouseButtons = System.Windows.Forms.MouseButtons;
    
    
    [GeneratedCode("Построитель кодированных тестов ИП", "14.0.23107.0")]
    public partial class UIMap
    {
        
        /// <summary>
        /// Проверка вызова меню настроек
        /// </summary>
        public void RecordedOptionsInvoke()
        {
            #region Variable Declarations
            WinMenuItem uIНастройкиMenuItem = this.UIИСКадрыУГТУ24122015Window.UIMenuStrip1MenuBar.UIСервисMenuItem.UIНастройкиMenuItem;
            WinRow uIПапкадляотчётовRow = this.UIKadrUICommonSettingsWindow.UIPropertyGridViewWindow.UIPropertyGridViewTable.UIПапкадляотчётовRow;
            WinEdit uIПапкадляотчётовEdit = this.UIKadrUICommonSettingsWindow.UIPropertyGridViewWindow.UIPropertyGridViewTable.UIПапкадляотчётовEdit;
            WinButton uIОбзорButton = this.UIKadrUICommonSettingsWindow.UIPropertyGridViewWindow.UIPropertyGridViewTable.UIОбзорButton;
            WinTreeItem uIWEBTreeItem = this.UIОбзорпапокWindow.UIДеревоWindow.UIРабочийстолTreeItem.UIWEBTreeItem;
            WinButton uIОКButton = this.UIОбзорпапокWindow.UIОКWindow.UIОКButton;
            WinButton uIОКButton1 = this.UIОКWindow.UIОКButton;
            WinButton uIOKButton = this.UIKadrUICommonSettingsWindow.UIOKWindow.UIOKButton;
            WinButton uIЗакрытьButton = this.UIИСКадрыУГТУ24122015Window.UIИСКадрыУГТУ24122015TitleBar.UIЗакрытьButton;
            #endregion

            // Щелкните "Сервис" -> "Настройки..." элемент меню
            Mouse.Click(uIНастройкиMenuItem, new Point(48, 13));

            // Щелкните "Папка для отчётов" строка
            Mouse.Click(uIПапкадляотчётовRow, new Point(196, 10));

            // Щелкните "Папка для отчётов" надпись
            Mouse.Click(uIПапкадляотчётовEdit, new Point(330, 6));

            // Щелкните "Обзор..." кнопка
            Mouse.Click(uIОбзорButton, new Point(7, 11));

            // Щелкните "Рабочий стол" -> "WEB" элемент дерева
            Mouse.Click(uIWEBTreeItem, new Point(16, 3));

            // Щелкните "ОК" кнопка
            Mouse.Click(uIОКButton, new Point(38, 12));

            // Щелкните "ОК" кнопка
            Mouse.Click(uIОКButton1, new Point(48, 2));

            // Щелкните "OK" кнопка
            Mouse.Click(uIOKButton, new Point(81, 13));

            // Щелкните "Закрыть" кнопка
            Mouse.Click(uIЗакрытьButton, new Point(18, 11));
        }
        
        #region Properties
        public UIИСКадрыУГТУ24122015Window UIИСКадрыУГТУ24122015Window
        {
            get
            {
                if ((this.mUIИСКадрыУГТУ24122015Window == null))
                {
                    this.mUIИСКадрыУГТУ24122015Window = new UIИСКадрыУГТУ24122015Window();
                }
                return this.mUIИСКадрыУГТУ24122015Window;
            }
        }
        
        public UIKadrUICommonSettingsWindow UIKadrUICommonSettingsWindow
        {
            get
            {
                if ((this.mUIKadrUICommonSettingsWindow == null))
                {
                    this.mUIKadrUICommonSettingsWindow = new UIKadrUICommonSettingsWindow();
                }
                return this.mUIKadrUICommonSettingsWindow;
            }
        }
        
        public UIОбзорпапокWindow UIОбзорпапокWindow
        {
            get
            {
                if ((this.mUIОбзорпапокWindow == null))
                {
                    this.mUIОбзорпапокWindow = new UIОбзорпапокWindow();
                }
                return this.mUIОбзорпапокWindow;
            }
        }
        
        public UIОКWindow1 UIОКWindow
        {
            get
            {
                if ((this.mUIОКWindow == null))
                {
                    this.mUIОКWindow = new UIОКWindow1();
                }
                return this.mUIОКWindow;
            }
        }
        #endregion
        
        #region Fields
        private UIИСКадрыУГТУ24122015Window mUIИСКадрыУГТУ24122015Window;
        
        private UIKadrUICommonSettingsWindow mUIKadrUICommonSettingsWindow;
        
        private UIОбзорпапокWindow mUIОбзорпапокWindow;
        
        private UIОКWindow1 mUIОКWindow;
        #endregion
    }
    
    [GeneratedCode("Построитель кодированных тестов ИП", "14.0.23107.0")]
    public class UIИСКадрыУГТУ24122015Window : WinWindow
    {
        
        public UIИСКадрыУГТУ24122015Window()
        {
            #region Условия поиска
            this.SearchProperties[WinWindow.PropertyNames.Name] = "ИС \"Кадры\" УГТУ (24.12.2015) ";
            this.SearchProperties.Add(new PropertyExpression(WinWindow.PropertyNames.ClassName, "WindowsForms10.Window", PropertyExpressionOperator.Contains));
            this.WindowTitles.Add("ИС \"Кадры\" УГТУ (24.12.2015) ");
            #endregion
        }
        
        #region Properties
        public UIMenuStrip1MenuBar UIMenuStrip1MenuBar
        {
            get
            {
                if ((this.mUIMenuStrip1MenuBar == null))
                {
                    this.mUIMenuStrip1MenuBar = new UIMenuStrip1MenuBar(this);
                }
                return this.mUIMenuStrip1MenuBar;
            }
        }
        
        public UIИСКадрыУГТУ24122015TitleBar UIИСКадрыУГТУ24122015TitleBar
        {
            get
            {
                if ((this.mUIИСКадрыУГТУ24122015TitleBar == null))
                {
                    this.mUIИСКадрыУГТУ24122015TitleBar = new UIИСКадрыУГТУ24122015TitleBar(this);
                }
                return this.mUIИСКадрыУГТУ24122015TitleBar;
            }
        }
        #endregion
        
        #region Fields
        private UIMenuStrip1MenuBar mUIMenuStrip1MenuBar;
        
        private UIИСКадрыУГТУ24122015TitleBar mUIИСКадрыУГТУ24122015TitleBar;
        #endregion
    }
    
    [GeneratedCode("Построитель кодированных тестов ИП", "14.0.23107.0")]
    public class UIMenuStrip1MenuBar : WinMenuBar
    {
        
        public UIMenuStrip1MenuBar(UITestControl searchLimitContainer) : 
                base(searchLimitContainer)
        {
            #region Условия поиска
            this.SearchProperties[WinMenu.PropertyNames.Name] = "menuStrip1";
            this.WindowTitles.Add("ИС \"Кадры\" УГТУ (24.12.2015) ");
            #endregion
        }
        
        #region Properties
        public UIСервисMenuItem UIСервисMenuItem
        {
            get
            {
                if ((this.mUIСервисMenuItem == null))
                {
                    this.mUIСервисMenuItem = new UIСервисMenuItem(this);
                }
                return this.mUIСервисMenuItem;
            }
        }
        #endregion
        
        #region Fields
        private UIСервисMenuItem mUIСервисMenuItem;
        #endregion
    }
    
    [GeneratedCode("Построитель кодированных тестов ИП", "14.0.23107.0")]
    public class UIСервисMenuItem : WinMenuItem
    {
        
        public UIСервисMenuItem(UITestControl searchLimitContainer) : 
                base(searchLimitContainer)
        {
            #region Условия поиска
            this.SearchProperties[WinMenuItem.PropertyNames.Name] = "Сервис";
            this.WindowTitles.Add("ИС \"Кадры\" УГТУ (24.12.2015) ");
            #endregion
        }
        
        #region Properties
        public WinMenuItem UIНастройкиMenuItem
        {
            get
            {
                if ((this.mUIНастройкиMenuItem == null))
                {
                    this.mUIНастройкиMenuItem = new WinMenuItem(this);
                    #region Условия поиска
                    this.mUIНастройкиMenuItem.SearchProperties[WinMenuItem.PropertyNames.Name] = "Настройки...";
                    this.mUIНастройкиMenuItem.SearchConfigurations.Add(SearchConfiguration.ExpandWhileSearching);
                    this.mUIНастройкиMenuItem.WindowTitles.Add("ИС \"Кадры\" УГТУ (24.12.2015) ");
                    #endregion
                }
                return this.mUIНастройкиMenuItem;
            }
        }
        #endregion
        
        #region Fields
        private WinMenuItem mUIНастройкиMenuItem;
        #endregion
    }
    
    [GeneratedCode("Построитель кодированных тестов ИП", "14.0.23107.0")]
    public class UIИСКадрыУГТУ24122015TitleBar : WinTitleBar
    {
        
        public UIИСКадрыУГТУ24122015TitleBar(UITestControl searchLimitContainer) : 
                base(searchLimitContainer)
        {
            #region Условия поиска
            this.WindowTitles.Add("ИС \"Кадры\" УГТУ (24.12.2015) ");
            #endregion
        }
        
        #region Properties
        public WinButton UIЗакрытьButton
        {
            get
            {
                if ((this.mUIЗакрытьButton == null))
                {
                    this.mUIЗакрытьButton = new WinButton(this);
                    #region Условия поиска
                    this.mUIЗакрытьButton.SearchProperties[WinButton.PropertyNames.Name] = "Закрыть";
                    this.mUIЗакрытьButton.WindowTitles.Add("ИС \"Кадры\" УГТУ (24.12.2015) ");
                    #endregion
                }
                return this.mUIЗакрытьButton;
            }
        }
        #endregion
        
        #region Fields
        private WinButton mUIЗакрытьButton;
        #endregion
    }
    
    [GeneratedCode("Построитель кодированных тестов ИП", "14.0.23107.0")]
    public class UIKadrUICommonSettingsWindow : WinWindow
    {
        
        public UIKadrUICommonSettingsWindow()
        {
            #region Условия поиска
            this.SearchProperties[WinWindow.PropertyNames.Name] = "Kadr.UI.Common.SettingsDecorator";
            this.SearchProperties.Add(new PropertyExpression(WinWindow.PropertyNames.ClassName, "WindowsForms10.Window", PropertyExpressionOperator.Contains));
            this.WindowTitles.Add("Kadr.UI.Common.SettingsDecorator");
            #endregion
        }
        
        #region Properties
        public UIPropertyGridViewWindow UIPropertyGridViewWindow
        {
            get
            {
                if ((this.mUIPropertyGridViewWindow == null))
                {
                    this.mUIPropertyGridViewWindow = new UIPropertyGridViewWindow(this);
                }
                return this.mUIPropertyGridViewWindow;
            }
        }
        
        public UIOKWindow UIOKWindow
        {
            get
            {
                if ((this.mUIOKWindow == null))
                {
                    this.mUIOKWindow = new UIOKWindow(this);
                }
                return this.mUIOKWindow;
            }
        }
        #endregion
        
        #region Fields
        private UIPropertyGridViewWindow mUIPropertyGridViewWindow;
        
        private UIOKWindow mUIOKWindow;
        #endregion
    }
    
    [GeneratedCode("Построитель кодированных тестов ИП", "14.0.23107.0")]
    public class UIPropertyGridViewWindow : WinWindow
    {
        
        public UIPropertyGridViewWindow(UITestControl searchLimitContainer) : 
                base(searchLimitContainer)
        {
            #region Условия поиска
            this.SearchProperties[WinWindow.PropertyNames.Name] = "PropertyGridView";
            this.SearchProperties.Add(new PropertyExpression(WinWindow.PropertyNames.ClassName, "WindowsForms10.Window", PropertyExpressionOperator.Contains));
            this.WindowTitles.Add("Kadr.UI.Common.SettingsDecorator");
            #endregion
        }
        
        #region Properties
        public UIPropertyGridViewTable UIPropertyGridViewTable
        {
            get
            {
                if ((this.mUIPropertyGridViewTable == null))
                {
                    this.mUIPropertyGridViewTable = new UIPropertyGridViewTable(this);
                }
                return this.mUIPropertyGridViewTable;
            }
        }
        #endregion
        
        #region Fields
        private UIPropertyGridViewTable mUIPropertyGridViewTable;
        #endregion
    }
    
    [GeneratedCode("Построитель кодированных тестов ИП", "14.0.23107.0")]
    public class UIPropertyGridViewTable : WinTable
    {
        
        public UIPropertyGridViewTable(UITestControl searchLimitContainer) : 
                base(searchLimitContainer)
        {
            #region Условия поиска
            this.SearchProperties[WinTable.PropertyNames.Name] = "Окно свойств";
            this.WindowTitles.Add("Kadr.UI.Common.SettingsDecorator");
            #endregion
        }
        
        #region Properties
        public WinRow UIПапкадляотчётовRow
        {
            get
            {
                if ((this.mUIПапкадляотчётовRow == null))
                {
                    this.mUIПапкадляотчётовRow = new WinRow(this);
                    #region Условия поиска
                    this.mUIПапкадляотчётовRow.SearchProperties[WinRow.PropertyNames.Name] = "Папка для отчётов";
                    this.mUIПапкадляотчётовRow.SearchConfigurations.Add(SearchConfiguration.AlwaysSearch);
                    this.mUIПапкадляотчётовRow.WindowTitles.Add("Kadr.UI.Common.SettingsDecorator");
                    #endregion
                }
                return this.mUIПапкадляотчётовRow;
            }
        }
        
        public WinEdit UIПапкадляотчётовEdit
        {
            get
            {
                if ((this.mUIПапкадляотчётовEdit == null))
                {
                    this.mUIПапкадляотчётовEdit = new WinEdit(this);
                    #region Условия поиска
                    this.mUIПапкадляотчётовEdit.SearchProperties[WinEdit.PropertyNames.Name] = "Папка для отчётов";
                    this.mUIПапкадляотчётовEdit.WindowTitles.Add("Kadr.UI.Common.SettingsDecorator");
                    #endregion
                }
                return this.mUIПапкадляотчётовEdit;
            }
        }
        
        public WinButton UIОбзорButton
        {
            get
            {
                if ((this.mUIОбзорButton == null))
                {
                    this.mUIОбзорButton = new WinButton(this);
                    #region Условия поиска
                    this.mUIОбзорButton.SearchProperties[WinButton.PropertyNames.Name] = "Обзор...";
                    this.mUIОбзорButton.WindowTitles.Add("Kadr.UI.Common.SettingsDecorator");
                    #endregion
                }
                return this.mUIОбзорButton;
            }
        }
        #endregion
        
        #region Fields
        private WinRow mUIПапкадляотчётовRow;
        
        private WinEdit mUIПапкадляотчётовEdit;
        
        private WinButton mUIОбзорButton;
        #endregion
    }
    
    [GeneratedCode("Построитель кодированных тестов ИП", "14.0.23107.0")]
    public class UIOKWindow : WinWindow
    {
        
        public UIOKWindow(UITestControl searchLimitContainer) : 
                base(searchLimitContainer)
        {
            #region Условия поиска
            this.SearchProperties[WinWindow.PropertyNames.ControlName] = "OKBtn";
            this.WindowTitles.Add("Kadr.UI.Common.SettingsDecorator");
            #endregion
        }
        
        #region Properties
        public WinButton UIOKButton
        {
            get
            {
                if ((this.mUIOKButton == null))
                {
                    this.mUIOKButton = new WinButton(this);
                    #region Условия поиска
                    this.mUIOKButton.SearchProperties[WinButton.PropertyNames.Name] = "OK";
                    this.mUIOKButton.WindowTitles.Add("Kadr.UI.Common.SettingsDecorator");
                    #endregion
                }
                return this.mUIOKButton;
            }
        }
        #endregion
        
        #region Fields
        private WinButton mUIOKButton;
        #endregion
    }
    
    [GeneratedCode("Построитель кодированных тестов ИП", "14.0.23107.0")]
    public class UIОбзорпапокWindow : WinWindow
    {
        
        public UIОбзорпапокWindow()
        {
            #region Условия поиска
            this.SearchProperties[WinWindow.PropertyNames.Name] = "Обзор папок";
            this.SearchProperties[WinWindow.PropertyNames.ClassName] = "#32770";
            this.WindowTitles.Add("Обзор папок");
            #endregion
        }
        
        #region Properties
        public UIДеревоWindow UIДеревоWindow
        {
            get
            {
                if ((this.mUIДеревоWindow == null))
                {
                    this.mUIДеревоWindow = new UIДеревоWindow(this);
                }
                return this.mUIДеревоWindow;
            }
        }
        
        public UIОКWindow UIОКWindow
        {
            get
            {
                if ((this.mUIОКWindow == null))
                {
                    this.mUIОКWindow = new UIОКWindow(this);
                }
                return this.mUIОКWindow;
            }
        }
        #endregion
        
        #region Fields
        private UIДеревоWindow mUIДеревоWindow;
        
        private UIОКWindow mUIОКWindow;
        #endregion
    }
    
    [GeneratedCode("Построитель кодированных тестов ИП", "14.0.23107.0")]
    public class UIДеревоWindow : WinWindow
    {
        
        public UIДеревоWindow(UITestControl searchLimitContainer) : 
                base(searchLimitContainer)
        {
            #region Условия поиска
            this.SearchProperties[WinWindow.PropertyNames.ControlId] = "100";
            this.WindowTitles.Add("Обзор папок");
            #endregion
        }
        
        #region Properties
        public UIРабочийстолTreeItem UIРабочийстолTreeItem
        {
            get
            {
                if ((this.mUIРабочийстолTreeItem == null))
                {
                    this.mUIРабочийстолTreeItem = new UIРабочийстолTreeItem(this);
                }
                return this.mUIРабочийстолTreeItem;
            }
        }
        #endregion
        
        #region Fields
        private UIРабочийстолTreeItem mUIРабочийстолTreeItem;
        #endregion
    }
    
    [GeneratedCode("Построитель кодированных тестов ИП", "14.0.23107.0")]
    public class UIРабочийстолTreeItem : WinTreeItem
    {
        
        public UIРабочийстолTreeItem(UITestControl searchLimitContainer) : 
                base(searchLimitContainer)
        {
            #region Условия поиска
            this.SearchProperties[WinTreeItem.PropertyNames.Name] = "Рабочий стол";
            this.SearchProperties["Value"] = "0";
            this.WindowTitles.Add("Обзор папок");
            #endregion
        }
        
        #region Properties
        public WinTreeItem UIWEBTreeItem
        {
            get
            {
                if ((this.mUIWEBTreeItem == null))
                {
                    this.mUIWEBTreeItem = new WinTreeItem(this);
                    #region Условия поиска
                    this.mUIWEBTreeItem.SearchProperties[WinTreeItem.PropertyNames.Name] = "WEB";
                    this.mUIWEBTreeItem.SearchProperties["Value"] = "1";
                    this.mUIWEBTreeItem.SearchConfigurations.Add(SearchConfiguration.ExpandWhileSearching);
                    this.mUIWEBTreeItem.SearchConfigurations.Add(SearchConfiguration.NextSibling);
                    this.mUIWEBTreeItem.WindowTitles.Add("Обзор папок");
                    #endregion
                }
                return this.mUIWEBTreeItem;
            }
        }
        #endregion
        
        #region Fields
        private WinTreeItem mUIWEBTreeItem;
        #endregion
    }
    
    [GeneratedCode("Построитель кодированных тестов ИП", "14.0.23107.0")]
    public class UIОКWindow : WinWindow
    {
        
        public UIОКWindow(UITestControl searchLimitContainer) : 
                base(searchLimitContainer)
        {
            #region Условия поиска
            this.SearchProperties[WinWindow.PropertyNames.ControlId] = "1";
            this.WindowTitles.Add("Обзор папок");
            #endregion
        }
        
        #region Properties
        public WinButton UIОКButton
        {
            get
            {
                if ((this.mUIОКButton == null))
                {
                    this.mUIОКButton = new WinButton(this);
                    #region Условия поиска
                    this.mUIОКButton.SearchProperties[WinButton.PropertyNames.Name] = "ОК";
                    this.mUIОКButton.WindowTitles.Add("Обзор папок");
                    #endregion
                }
                return this.mUIОКButton;
            }
        }
        #endregion
        
        #region Fields
        private WinButton mUIОКButton;
        #endregion
    }
    
    [GeneratedCode("Построитель кодированных тестов ИП", "14.0.23107.0")]
    public class UIОКWindow1 : WinWindow
    {
        
        public UIОКWindow1()
        {
            #region Условия поиска
            this.SearchProperties[WinWindow.PropertyNames.Name] = "ОК";
            this.SearchProperties[WinWindow.PropertyNames.ClassName] = "Button";
            this.WindowTitles.Add("ОК");
            #endregion
        }
        
        #region Properties
        public WinButton UIОКButton
        {
            get
            {
                if ((this.mUIОКButton == null))
                {
                    this.mUIОКButton = new WinButton(this);
                    #region Условия поиска
                    this.mUIОКButton.SearchProperties[WinButton.PropertyNames.Name] = "ОК";
                    this.mUIОКButton.WindowTitles.Add("ОК");
                    #endregion
                }
                return this.mUIОКButton;
            }
        }
        #endregion
        
        #region Fields
        private WinButton mUIОКButton;
        #endregion
    }
}
