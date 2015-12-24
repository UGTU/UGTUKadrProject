using System;
using System.Drawing;
using System.Reflection;
using System.Windows.Forms;
using APG.CodeHelper.DBTreeView;

namespace APG.CodeHelper.ContextMenuHelper
{
    public class ContextMenuBuilder
    {
        /// <summary>
        ///     Создаёт новый экземпляр класса ContextMenuBuilder
        /// </summary>
        /// <param name="contextMenuStrip">Контекстное меню, куда будут добавлены элементы</param>
        /// <param name="receiver">Объект-получатель сообщений выбора элементов меню</param>
        /// <param name="ownerToolStripItem">Родительский элемент меню куда будут добавлены элементы</param>
        public ContextMenuBuilder(ContextMenuStrip contextMenuStrip, object receiver, ToolStripItem ownerToolStripItem)
        {
            InitInstance(contextMenuStrip, receiver, ownerToolStripItem);
        }

        /// <summary>
        ///     Создаёт новый экземпляр класса ContextMenuBuilder
        /// </summary>
        /// <param name="contextMenuStrip">Контекстное меню, куда будут добавлены элементы</param>
        /// <param name="receiver">Объект-получатель сообщений выбора элементов меню</param>
        public ContextMenuBuilder(ContextMenuStrip contextMenuStrip, object receiver)
        {
            InitInstance(contextMenuStrip, receiver, null);
        }

        /// <summary>
        ///     Создаёт новый экземпляр класса ContextMenuBuilder
        /// </summary>
        /// <param name="toolStripItemCollection">Коллекция элементов меню, куда будут добавляться новые элементы</param>
        /// <param name="receiver">Объект-получатель сообщений выбора элементов меню</param>
        public ContextMenuBuilder(ToolStripItemCollection toolStripItemCollection, object receiver)
        {
            ToolStripItemCollection = toolStripItemCollection;
            Receiver = receiver;
        }

        /// <summary>
        ///     Получает или устанавливает пользовательский объект
        /// </summary>
        public object UserData { get; set; }


        /// <summary>
        ///     Получает или устанавливает коллекцию элементов меню, куда будут добавлены новые элементы
        /// </summary>
        public ToolStripItemCollection ToolStripItemCollection { get; set; }

        /// <summary>
        ///     Получает или устанавливает контекстное меню
        /// </summary>
        public ContextMenuStrip ContextMenuStrip { get; set; }

        /// <summary>
        ///     Получает или устанавливает родительский элемент ToolStripItem
        /// </summary>
        public ToolStripItem OwnerToolStripItem { get; set; }

        /// <summary>
        ///     Получает или устанавливает объект класса с методами-обработчиками
        /// </summary>
        public object Receiver { get; set; }

        private void InitInstance(ContextMenuStrip contextMenuStrip, object receiver, ToolStripItem ownerToolStripItem)
        {
            ContextMenuStrip = contextMenuStrip;
            Receiver = receiver;
            OwnerToolStripItem = ownerToolStripItem;
        }

        public void PopupMenu(Control parent, int X, int Y)
        {
            CheckArguments();

            ToolStripItemCollection itemCollection;

            if (OwnerToolStripItem == null)
                itemCollection = ContextMenuStrip.Items;
            else
                itemCollection = ((ToolStripMenuItem)OwnerToolStripItem).DropDownItems;

            if (itemCollection == null)
                throw new NullReferenceException("Коллекция элементов меню не инициализирована.");

            BuildItemCollection(itemCollection);

            ContextMenuStrip.Show(parent, new Point(X, Y));
        }

        /// <summary>
        ///     Заполняет коллекцию доступными действиями
        /// </summary>
        public void BuildToolStripItemCollection()
        {
            BuildItemCollection(ToolStripItemCollection);
        }


        private void BuildItemCollection(ToolStripItemCollection itemCollection)
        {
            ContextMenuMethodAttribute[] menuAttributes;
            ToolStripMenuItem tsmItem;

            if (Receiver == null) return;

            var members = Receiver.GetType()
                .FindMembers(MemberTypes.Method, BindingFlags.Public | BindingFlags.Instance | BindingFlags.NonPublic,
                    MethodFilter, null);

            itemCollection.Clear();

            foreach (MethodInfo methodInfo in members)
            {
                menuAttributes =
                    (ContextMenuMethodAttribute[])
                        methodInfo.GetCustomAttributes(typeof(ContextMenuMethodAttribute), false);

                if (menuAttributes.Length == 1)
                {
                    if (menuAttributes[0].InsertSeparator)
                    {
                        InsertSeparator(itemCollection);
                    }
                    var command = new MenuCommand(Receiver, methodInfo);
                    EventHandler clickHandler = command.Execute;
                    var menuAttrib = menuAttributes[0];
                    if (menuAttrib.Visible)
                    {
                        string caption = null;
                        var captionProvider = methodInfo.GetCustomAttributes(typeof(ActionCaptionAttribute), false);
                        if (captionProvider.Length == 1)
                        {
                            var providerClassAttribute = (captionProvider[0] as ActionCaptionAttribute);
                            var providerClass = providerClassAttribute?.ActionCaptionProviderClass;
                            //var providerClass = (captionProvider[0] as ActionCaptionAttribute)?.ActionCaptionProviderClass;
                            if (providerClass != null)
                            {
                                var providerInstance = Activator.CreateInstance(providerClass) as IActionCaptionProvider;
                                caption = providerInstance?.GetCaption(UserData);
                            }
                        }

                        tsmItem = new ToolStripMenuItem(caption ?? menuAttributes[0].ItemCaption)
                        {
                            Enabled = menuAttributes[0].ItemEnabled,
                            ImageIndex = menuAttributes[0].ItemImageIndex
                        };

                        tsmItem.Click += clickHandler;
                        if (menuAttributes[0].DefaultItem)
                            tsmItem.Font = new Font(tsmItem.Font.FontFamily, tsmItem.Font.SizeInPoints,
                                FontStyle.Bold);

                        itemCollection.Add(tsmItem);
                    }
                }
            }
        }

        private void InsertSeparator(ToolStripItemCollection itemCollection)
        {
            var tss = new ToolStripSeparator();
            itemCollection.Add(tss);
        }

        private void CheckArguments()
        {
            var InvalidParam = "";
            if (ContextMenuStrip == null)
                InvalidParam = "ContextMenuStrip";
            if (Receiver == null)
                InvalidParam += " Receiver";
            if (InvalidParam != "")
                throw new ArgumentNullException(InvalidParam.TrimStart(), "Один несколько параметров не заданы.");
        }

        private bool MethodFilter(MemberInfo member, object criteria)
        {
            var bInclude = false;
            var method = member as MethodInfo;

            if (method != null)
            {
                if (method.ReturnType == typeof(void))
                {
                    var param = method.GetParameters();
                    if (param.Length == 1)
                    {
                        if (param[0].ParameterType == typeof(object))
                        {
                            var attribs = method.GetCustomAttributes(typeof(ContextMenuMethodAttribute), true);
                            bInclude = attribs.Length == 1;
                        }
                    }
                }
            }
            return bInclude;
        }
    }
}