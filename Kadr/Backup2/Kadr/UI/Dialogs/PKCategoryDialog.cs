using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Kadr.UI.Common;
using Kadr.Data;
using Kadr.Controllers;



namespace Kadr.UI.Dialogs
{
    public partial class PKCategoryDialog : LinqDataGridViewDialog
    {
        public PKCategoryDialog()
        {
            InitializeComponent();
        }

        private void PKCategoryDialog_Load(object sender, EventArgs e)
        {
            bindingNavigator1.BindingSource = pKCategoryBindingSource;
            pKGroupDecoratorBindingSource.DataSource = KadrController.Instance.Model.PKGroups;
        }


        private void dataGridView1_RowValidating(object sender, DataGridViewCellCancelEventArgs e)
        {
            //проверяем, чтобы было заполнено название вида надбавки
            if ((pKCategoryBindingSource.Current != null)
                &&((pKCategoryBindingSource.Current as PKCategory).PKCategoryNumber != 0)
                && (cbPKGroup.SelectedItem != null))
                (pKCategoryBindingSource.Current as PKCategory).PKGroup =
                        cbPKGroup.SelectedItem as PKGroup;

        }

        private void btnPKGroup_Click(object sender, EventArgs e)
        {
            using (PKGroupDialog dlg = new PKGroupDialog())
            {
                dlg.ShowDialog();
                //обновляем данные
                PKCategoryDialog_Load(sender, e);
            }

        }

        private void cbPKGroup_SelectedValueChanged(object sender, EventArgs e)
        {
            pKCategoryBindingSource.DataSource = KadrController.Instance.Model.PKCategories.Where(pkCat => pkCat.PKGroup == cbPKGroup.SelectedItem);

        }

        private void dataGridView1_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            IsModified = true;
        }
    }
}
