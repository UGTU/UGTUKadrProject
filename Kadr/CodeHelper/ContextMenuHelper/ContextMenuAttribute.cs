using System;
using System.Collections.Generic;
using System.Text;
using APG.CodeHelper.DBTreeView;

namespace APG.CodeHelper.ContextMenuHelper
{
    [AttributeUsage(AttributeTargets.Method, AllowMultiple = false)]
    public class ActionCaptionAttribute : Attribute 
    {
        public Type ActionCaptionProviderClass { get; internal set; }

        public ActionCaptionAttribute(Type providerClass)
        {
            ActionCaptionProviderClass = providerClass;            
        }
    }

    /// <summary>
    /// ������� ������, ���������� ����� ����������� ����
    /// </summary>
    [AttributeUsage(AttributeTargets.Method, AllowMultiple=false)]
    public class ContextMenuMethodAttribute:Attribute
    {
        /// <summary>
        /// ��������� �������� ������������ ����
        /// </summary>
        public string ItemCaption
        {
            get { return itemCaption; }
            set { itemCaption = value; }
        }
        
        /// <summary>
        /// �������� �������� ������������ ���� ��� ��������
        /// </summary>
        public bool ItemEnabled
        {
            get { return itemEnabled; }
            set { itemEnabled = value; }
        }
        /// <summary>
        /// ����������� �� ������� ����������� ����� �������� ������� ����
        /// </summary>
        public bool InsertSeparator
        {
            get { return insertSeparator; }
            set { insertSeparator = value; }
        }
        /// <summary>
        /// �������� �� ������� ���� ��������� �� ���������
        /// </summary>
        public bool DefaultItem
        {
            get { return defaultItem; }
            set { defaultItem = value; }
        }

        /// <summary>
        ///  ������ ������� ��� �������� ����
        /// </summary>
        public int ItemImageIndex
        {
            get { return itemImageIndex; }
            set { itemImageIndex = value; }
        }
        /// <summary>
        /// �������� ��� ������������� ��������� ����� �������� ����
        /// </summary>
        public bool Visible { get; set; }

        public ContextMenuMethodAttribute(string itemCaption, bool itemEnabled, bool defaultItem, int itemImageIndex, bool insertSeparator)
        {
            InitInstance(itemCaption, itemEnabled, defaultItem, itemImageIndex, insertSeparator);
        }

        /// <summary>
        /// ������ ����� ��������� ContextMenuMethodAttribute
        /// </summary>
        /// <param name="itemCaption">��������� �������� ����</param>
        /// <param name="itemEnabled">������� ���� ��������</param>
        /// <param name="defaultItem">������, ���� ������� ���� �������� ��������� �� ���������</param>
        /// <param name="itemImageIndex">������ ������� ��� �������� ����</param>
        public ContextMenuMethodAttribute(string itemCaption, bool itemEnabled, bool defaultItem, int itemImageIndex)
        {
            InitInstance(itemCaption, itemEnabled, defaultItem, itemImageIndex, false);
        }

        /// <summary>
        /// ������ ����� ��������� ContextMenuMethodAttribute
        /// </summary>
        /// <param name="itemCaption">��������� �������� ����</param>
        public ContextMenuMethodAttribute(string itemCaption)
        {
            InitInstance(itemCaption, true, false, -1, false);
        }

        /// <summary>
        /// ������ ����� ��������� ContextMenuMethodAttribute
        /// </summary>
        /// <param name="itemCaption">��������� �������� ����</param>
        /// <param name="defaultItem">������, ���� ������� ���� �������� ��������� �� ���������</param>
        /// <param name="itemEnabled"></param>
        /// <param name="visible"></param>
        public ContextMenuMethodAttribute(string itemCaption, bool itemEnabled, bool visible=true)
        {
            InitInstance(itemCaption, itemEnabled, false, -1, false, visible);
        }


        private void InitInstance(string itemCaption, bool itemEnabled, bool defaultItem, int itemImageIndex, bool insertSeparator, bool visible = true)
        {
            this.itemCaption = itemCaption;
            this.itemEnabled = itemEnabled;
            this.DefaultItem = defaultItem;
            this.ItemImageIndex = itemImageIndex;
            this.insertSeparator = insertSeparator;
            Visible = visible;
        }


        private int itemImageIndex;
        private string itemCaption;
        private bool itemEnabled;
        private bool defaultItem;
        private bool insertSeparator;



    }
}
