using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

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
            dialogObject = cbObjectList.SelectedItem;
        }

        private void bAddingMode_Click(object sender, EventArgs e)
        {
            pSelection.Visible = false;
            pAdding.Visible = true;
            this.Height -= pSelection.Height;
            this.Height += pAdding.Height;
            btnClearSelection.Visible = false;
        }
    }
}
