using System;
using System.Collections.Generic;
using System.Text;

namespace APG.CodeHelper.ContextMenuHelper
{
    /// <summary>
    /// Атрибут метода, доступного через контекстное меню
    /// </summary>
    [AttributeUsage(AttributeTargets.Method, AllowMultiple=false)]
    public class ContextMenuMethodAttribute:Attribute
    {
        /// <summary>
        /// Заголовок элемента контекстного меню
        /// </summary>
        public string ItemCaption
        {
            get { return itemCaption; }
            set { itemCaption = value; }
        }
        
        /// <summary>
        /// Сотояние элемента контекстного меню при создании
        /// </summary>
        public bool ItemEnabled
        {
            get { return itemEnabled; }
            set { itemEnabled = value; }
        }
        /// <summary>
        /// Производить ли вставку разделителя перед заданным пунктом меню
        /// </summary>
        public bool InsertSeparator
        {
            get { return insertSeparator; }
            set { insertSeparator = value; }
        }
        /// <summary>
        /// Является ли элемент меню элементом по умолчанию
        /// </summary>
        public bool DefaultItem
        {
            get { return defaultItem; }
            set { defaultItem = value; }
        }

        /// <summary>
        ///  Индекс рисунка для элемента меню
        /// </summary>
        public int ItemImageIndex
        {
            get { return itemImageIndex; }
            set { itemImageIndex = value; }
        }
        
        public ContextMenuMethodAttribute(string itemCaption, bool itemEnabled, bool defaultItem, int itemImageIndex, bool insertSeparator)
        {
            InitInstance(itemCaption, itemEnabled, defaultItem, itemImageIndex, insertSeparator);
        }

        /// <summary>
        /// Создаёт новый экземпляр ContextMenuMethodAttribute
        /// </summary>
        /// <param name="itemCaption">Заголовок элемента меню</param>
        /// <param name="itemEnabled">Элемент меню доступен</param>
        /// <param name="defaultItem">Истина, если элемент меню является элементом по умолчанию</param>
        /// <param name="itemImageIndex">Индекс рисунка для элемента меню</param>
        public ContextMenuMethodAttribute(string itemCaption, bool itemEnabled, bool defaultItem, int itemImageIndex)
        {
            InitInstance(itemCaption, itemEnabled, defaultItem, itemImageIndex, false);
        }

        /// <summary>
        /// Создаёт новый экземпляр ContextMenuMethodAttribute
        /// </summary>
        /// <param name="itemCaption">Заголовок элемента меню</param>
        public ContextMenuMethodAttribute(string itemCaption)
        {
            InitInstance(itemCaption, true, false, -1, false);
        }

        /// <summary>
        /// Создаёт новый экземпляр ContextMenuMethodAttribute
        /// </summary>
        /// <param name="itemCaption">Заголовок элемента меню</param>
        /// <param name="defaultItem">Истина, если элемент меню является элементом по умолчанию</param>
        public ContextMenuMethodAttribute(string itemCaption, bool itemEnabled)
        {
            InitInstance(itemCaption, itemEnabled, false, -1, false);
        }


        private void InitInstance(string itemCaption, bool itemEnabled, bool defaultItem, int itemImageIndex, bool insertSeparator)
        {
            this.itemCaption = itemCaption;
            this.itemEnabled = itemEnabled;
            this.DefaultItem = defaultItem;
            this.ItemImageIndex = itemImageIndex;
            this.insertSeparator = insertSeparator;
        }


        private int itemImageIndex;
        private string itemCaption;
        private bool itemEnabled;
        private bool defaultItem;
        private bool insertSeparator;





    }
}
