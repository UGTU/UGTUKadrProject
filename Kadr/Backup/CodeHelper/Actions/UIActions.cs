namespace APG.CodeHelper.Actions
{
    /// <summary>
    /// Набор базовых операций, которые могут быть 
    /// выполнены над объектом пользовательского интерфейса
    /// </summary>
    public enum UIObjectAction
    {
        taAdd, taDelete, taCopy, taCut, taUpdate, taPaste
    }

    /// <summary>
    /// Определят поведение приложения при выполнении базовых 
    /// операций над объектом пользовательского интерфейса
    /// </summary>
    public abstract class UIAction
    {
        /// <summary>
        /// Число поддерживаемых действий
        /// </summary>
        public static readonly int Count = 6;
        /// <summary>
        /// Переопределите в производных классах для выполнения операции добавления объекта
        /// </summary>
        /// <param name="sender">Определяет объект, пославший сообщение</param>
        protected abstract void AddExecute(object sender);
        /// <summary>
        /// Переопределите в производных классах для выполнения операции удаление объекта
        /// </summary>
        /// <param name="sender">Определяет объект, пославший сообщение</param>
        protected abstract void DeleteExecute(object sender);
        /// <summary>
        /// Переопределите в производных классах для выполнения операции вырезки объекта
        /// </summary>
        /// <param name="sender">Определяет объект, пославший сообщение</param>
        protected abstract void CutExecute(object sender);
        /// <summary>
        /// Переопределите в производных классах для выполнения операции копирования объекта
        /// </summary>
        /// <param name="sender">Определяет объект, пославший сообщение</param>
        protected abstract void CopyExecute(object sender);
        /// <summary>
        /// Переопределите в производных классах для выполнения операции вставки объекта
        /// </summary>
        /// <param name="sender">Определяет объект, пославший сообщение</param>
        protected abstract void PasteExecute(object sender);
        /// <summary>
        /// Переопределите в производных классах для выполнения операции редактирования объекта
        /// </summary>
        /// <param name="sender">Определяет объект, пославший сообщение</param>
        protected abstract void UpdateExecute(object sender);

        /// <summary>
        /// Переопределите в производных классах для определения возможности выполнить
        /// добавление объекта
        /// </summary>
        /// <param name="sender">Определяет объект, пославший сообщение</param>
        /// <returns>true, если опрация допустима, false - в противном случае</returns>
        protected abstract bool CanAdd(object sender);
        /// <summary>
        /// Переопределите в производных классах для определения возможности выполнить
        /// удаление объекта
        /// </summary>
        /// <param name="sender">Определяет объект, пославший сообщение</param>
        /// <returns>true, если опрация допустима, false - в противном случае</returns>
        protected abstract bool CanDelete(object sender);
        /// <summary>
        /// Переопределите в производных классах для определения возможности выполнить
        /// вырезку объекта
        /// </summary>
        /// <param name="sender">Определяет объект, пославший сообщение</param>
        /// <returns>true, если опрация допустима, false - в противном случае</returns>
        protected abstract bool CanCut(object sender);
        /// <summary>
        /// Переопределите в производных классах для определения возможности выполнить
        /// копирование объекта
        /// </summary>
        /// <param name="sender">Определяет объект, пославший сообщение</param>
        /// <returns>true, если опрация допустима, false - в противном случае</returns>
        protected abstract bool CanCopy(object sender);
        /// <summary>
        /// Переопределите в производных классах для определения возможности выполнить
        /// вставку объекта
        /// </summary>
        /// <param name="sender">Определяет объект, пославший сообщение</param>
        /// <returns>true, если опрация допустима, false - в противном случае</returns>
        protected abstract bool CanPaste(object sender);
        /// <summary>
        /// Переопределите в производных классах для определения возможности выполнить
        /// редактирование объекта
        /// </summary>
        /// <param name="sender">Определяет объект, пославший сообщение</param>
        /// <returns>true, если опрация допустима, false - в противном случае</returns>
        protected abstract bool CanUpdate(object sender);
        
        /// <summary>
        /// Переопределите в производных классах для назначения имени базовой операции
        /// </summary>
        /// <param name="index">Тип базовой операции</param>
        /// <param name="val">Имя базовой операции</param>
        protected abstract void SetCaption(UIObjectAction index, string caption);
             
        /// <summary>
        /// Переопределите в производных классах для получения имени базовой операции
        /// </summary>
        /// <param name="index">Тип базовой операции</param>
        /// <returns>Имя базовой операции</returns>
        protected abstract string GetCaption(UIObjectAction index);


        /// <summary>
        /// Выполняет базовую операцию над объектом
        /// </summary>
        /// <param name="sender">Определяет объект, пославший сообщение</param>
        /// <param name="index">Тип базовой операции для выполнения</param>
        public void Execute(object sender, UIObjectAction index)
        {
            switch (index)
            {
                case UIObjectAction.taAdd: AddExecute(sender); break;
                case UIObjectAction.taDelete: DeleteExecute(sender); break;
                case UIObjectAction.taUpdate: UpdateExecute(sender); break;
                case UIObjectAction.taCopy: CopyExecute(sender); break;
                case UIObjectAction.taPaste: PasteExecute(sender); break;
                case UIObjectAction.taCut: CutExecute(sender); break;
            }
        }

        /// <summary>
        /// Проверяет возможность выполнения базовой операции
        /// </summary>
        /// <param name="sender">Определяет объект, пославший сообщение</param>
        /// <param name="index">Тип базовой операции</param>
        /// <returns>true, если операция может быть выполнения, false - в противном случае</returns>
        public bool CanDoThis(object sender, UIObjectAction index)
        {
            switch (index)
            {
                case UIObjectAction.taAdd: return CanAdd(sender);
                case UIObjectAction.taDelete: return CanDelete(sender);
                case UIObjectAction.taUpdate: return CanUpdate(sender);
                case UIObjectAction.taCopy: return CanCopy(sender);
                case UIObjectAction.taPaste: return CanPaste(sender);
                case UIObjectAction.taCut: return CanCut(sender);
                default: return false;
            }
        }

        /// <summary>
        /// Индексатор для имён базовых операций
        /// </summary>
        /// <param name="index">Тип базовой операции</param>
        /// <returns>Имя базовой операции</returns>
        public string this[UIObjectAction index]
        {
            get
            {
                return GetCaption(index);
            }
            set
            {
                SetCaption(index, value);
            }
        }
    }
}