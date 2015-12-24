using System;




namespace Kadr.UI.Common
{
    public partial class BaseSelectionDialog : CustomBaseDialog
    {
        /// <summary>
        /// Обновляет список 
        /// </summary>
        protected virtual void DoRefreshList()
        {

        }

        private void RefreshList()
        {
            DoRefreshList();
        }

        public BaseSelectionDialog()
        {
            InitializeComponent();
            ApplyButtonVisible = false;
        }

        private void BaseSelectionDialog_Load(object sender, EventArgs e)
        {
            RefreshList();
        }

        private void btnClearSelection_Click(object sender, EventArgs e)
        {
            cbObjectList.SelectedItem = null;
        }

        private void cbObjectList_SelectedIndexChanged(object sender, EventArgs e)
        {
            DialogObject = cbObjectList.SelectedItem;
        }

        public void AddingModeOn()
        {
            bAddingMode_Click(null, null);
        }

        /// <summary>
        /// настройка диалога - указывает на то, показывать ли панель добавления объекта при нажатии на соотв кнопку
        /// </summary>
        protected bool ShowAddingPanel = true;

        private void bAddingMode_Click(object sender, EventArgs e)
        {
            if (ShowAddingPanel)
            {
                pSelection.Visible = false;
                pAdding.Visible = true;
                this.Height -= pSelection.Height;
                this.Height += pAdding.Height;
                btnClearSelection.Visible = false;
            }
        }
    }
}
