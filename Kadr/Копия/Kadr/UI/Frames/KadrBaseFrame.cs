using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using UIX.Views;
using Kadr.Controllers;

namespace Kadr.UI.Frames
{
    /// <summary>
    /// Базовый фрейм
    /// </summary>
    public partial class KadrBaseFrame : UserControl, IView
    {
        private bool showTitleBar = true;

        public bool ShowTitleBar
        {
            get { return showTitleBar; }
            set { showTitleBar = value; }
        }
        private bool bchanged = false;
        private string frameName;
        private string caption;
        private object frameGuiObject;
        private APG.CodeHelper.DBTreeView.DBTreeNodeObject frameNodeObject;
        /// <summary>
        /// Графический объект, связанный с кадром. 
        /// </summary>
        [Browsable(false)]
        public object FrameGuiObject
        {
            get { return frameGuiObject; }
            set { frameGuiObject = value; }
        }

        /// <summary>
        /// Объект узла, связанный с кадром. 
        /// </summary>
        [Browsable(false)]
        public APG.CodeHelper.DBTreeView.DBTreeNodeObject FrameNodeObject
        {
            get { return frameNodeObject; }
            set { frameNodeObject = value; }
        }
        [Browsable(false)]
        public APG.CodeHelper.DBTreeView.DBTreeNodeObject SelectedNodeObject
        {
            get
            {
                return frameObject as APG.CodeHelper.DBTreeView.DBTreeNodeObject;
            }
        }
        public event FrameDataChangedDelegate FrameDataChangedEvent;

        // Имя кадра. Используется для его описания
        public string FrameName
        {
            get { return frameName; }
            set { frameName = value; }
        }
        
        //Признак модификации кадра
        [Browsable(false)]
        public bool IsModified
        {
            get { return GetIsModified(); }
            set { SetIsModified(value); }
        }

        protected virtual void SetIsModified(bool value)
        {
            bchanged = value;
        }

        protected virtual bool GetIsModified()
        {
            return bchanged;
        }

        private object frameObject;

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        protected virtual APG.CodeHelper.Actions.UIAction GetActions()
        {
            return null;
        }

        protected KadrBaseFrame()
        {
            InitializeComponent();
            //регистрируем фрейм в качестве представления
            
        }

        public KadrBaseFrame(object AObject)
        {
            frameObject = AObject;
            InitializeComponent();
            //регистрируем фрейм в качестве представления
        }
        
        /// <summary>
        ///  Объект типа APG.CodeHelper.Actions.UIAction для описания действий над кадром
        /// </summary>
        [Browsable(false)]
        public APG.CodeHelper.Actions.UIAction Actions
        {
            get
            {
                return GetActions();
            }
        }
        [Browsable(false)]
        public string Caption
        {
            get
            {
               // return groupBox1.Text;
                return caption;
            }
            set
            {
                //groupBox1.Text = value;
                caption = value;
            }
        }
        [Browsable(false)]
        public object FrameObject
        {
            get
            {
                return frameObject;
            }
            set
            {
                frameObject = value;
                SetFrameObject(value);
            }
        }

        protected virtual void SetFrameObject(object value)
        {
            
        }
        [Browsable(false)]
        public DataRow FrameRow
         {
            get
            {
                return FrameObject as DataRow;
            }
        }

        [Browsable(false)]
        public int FrameObjectID
        {
            get
            {
                int result = -1;

                if (FrameObject is DataRow)
                {
                    DataRow row = FrameObject as DataRow;
                    result = (int)row["ID"];
                }
                return result;
            }
        }
        [Browsable(false)]               
       
        public Guid FrameObjectGUID
        {
            get
            {
                Guid result = Guid.Empty;

                if (FrameObject is DataRow)
                {
                    DataRow row = FrameObject as DataRow;
                    result = (Guid)row["ID"];
                }

                return result;
            }
        }
        
        protected virtual void DoApply()
        {
           
        }
        /// <summary>
        /// Сохранить изменения в кадре
        /// </summary>
        public void Apply()
        {
            DoApply();
         
            if (FrameDataChangedEvent != null)
                FrameDataChangedEvent(this, new FrameDataChangedArgs(this));

            IsModified = false;
          
        }

        protected virtual void DoCancel()
        {

        }

        public void Cancel()
        {
            DoCancel();
        }

        /// <summary>
        /// Обновить содержимое кадра
        /// </summary>
        public void RefreshFrame()
        {
            DoRefreshFrame();
        }

        ///// <summary>
        ///// Распечатать содержимое кадра
        ///// </summary>
        //public void PrintFrame()
        //{
        //    System.Windows.Forms.PrintDialog dlg = new PrintDialog();
        //    if (dlg.ShowDialog() == DialogResult.OK)
        //        DoPrintFrame();
        //}

        ///// <summary>
        ///// Переопределите этот метод для сохранения состояния кадра в словарь store
        ///// </summary>
        ///// <param name="store">Словарь для сохранения состояния кадра</param>
        //protected virtual void SaveState(System.Collections.IDictionary store)
        //{
            
        //}

        ///// <summary>
        ///// Переопределите этот метод для восстановления состояния кадра из словаря store
        ///// </summary>
        ///// <param name="store">Словарь в котором хранится состояние кадра</param>
        //protected virtual void RestoreState(System.Collections.IDictionary store)
        //{

        //}

        ///// <summary>
        ///// Восстанавливает состояние кадра, включая все аггрегированные этим кадром кадры
        ///// </summary>
        ///// <param name="store">Словарь в котором хранится состояние кадра</param>
        //public void RestoreFrameState(System.Collections.IDictionary store)
        //{
        //    RestoreFrameState(this, store);
        //}

        //private void RestoreFrameState(ISGBBaseFrame baseFrame, System.Collections.IDictionary store)
        //{
        //    baseFrame.RestoreState(store);
        //    foreach (Control innerFrame in baseFrame.Controls)
        //    {
        //        if (innerFrame is ISGBBaseFrame)
        //            RestoreFrameState((innerFrame as ISGBBaseFrame), store);
        //    }
        //}

        ///// <summary>
        ///// Сохраняет состояние кадра, включая все аггрегированные этим кадром кадры
        ///// </summary>
        ///// <param name="store">Словарь для сохранения состояния кадра</param>
        //public void SaveFrameState(System.Collections.IDictionary store)
        //{
        //    SaveFrameState(this, store);
        //}

        //private void SaveFrameState(ISGBBaseFrame baseFrame, System.Collections.IDictionary store)
        //{
        //    baseFrame.SaveState(store);
        //    foreach (Control innerFrame in baseFrame.Controls)
        //    {
        //        if (innerFrame is ISGBBaseFrame)
        //            SaveFrameState((innerFrame as ISGBBaseFrame), store);
        //    }
        //}

        //protected virtual void DoPrintFrame()
        //{

        //}

        //public void ExportToFile(string Filter)
        //{
        //    SaveFileDialog dlg = new SaveFileDialog();
        //    dlg.Filter = Filter;
        //    if (dlg.ShowDialog() == DialogResult.OK)
        //    {
        //        DoExportToFile(dlg.FileName);
        //    }
        //}

        //protected virtual void DoExportToFile(string FileName)
        //{
        //    MessageBox.Show("К сожалению, этот кадр не поддерживает сохранение данных в файл.", "Сохранение в файл", MessageBoxButtons.OK, MessageBoxIcon.Information);
        //}

        protected virtual void DoRefreshFrame()
        {
            
        }

        
        
        private void DrawFrameCaptionBar(PaintEventArgs e)
        {
            Rectangle rect;
            rect = groupBox1.Bounds;
            rect.Y = rect.Top - 11;
            rect.Height = 22;
            rect.Width = rect.Width - 8;
            PointF point;
            point = rect.Location;
            point.Y += 8;

            string headerCaption = Caption.Replace(@"\", " > ");

            SizeF headerSize = e.Graphics.MeasureString(headerCaption, Font);

            if (headerSize.Width > rect.Size.Width)
            {
                headerCaption += "...";
                while (headerSize.Width > rect.Size.Width)
                {
                    headerCaption = headerCaption.Remove(headerCaption.Length - 4, 1);
                    headerSize = e.Graphics.MeasureString(headerCaption, Font);
                }
            }

            e.Graphics.FillRectangle(SystemBrushes.GradientActiveCaption, rect);
            e.Graphics.DrawString(headerCaption, Font, Brushes.White, point);
        }


        #region Члены IView

        public void Update(object Sender)
        {
            RefreshFrame();
        }

        #endregion
    }

    /// <summary>
    /// 
    /// </summary>
    public class FrameDataChangedArgs
    {
        private KadrBaseFrame frame;

        public KadrBaseFrame Frame
        {
            get { return frame; }
        }

        public FrameDataChangedArgs(KadrBaseFrame frame)
        {
            this.frame = frame;
        }
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    public delegate void FrameDataChangedDelegate(object sender, FrameDataChangedArgs e);

}

