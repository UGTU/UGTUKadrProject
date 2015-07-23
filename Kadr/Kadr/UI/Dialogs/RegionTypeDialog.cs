using System;
using System.Linq;
using System.Windows.Forms;
using Kadr.UI.Common;
using Kadr.Controllers;

namespace Kadr.UI.Dialogs
{
    public partial class RegionTypeDialog : LinqDataGridViewDialog
    {
        public RegionTypeDialog()
        {
            InitializeComponent();
        }

        private void dataGridView1_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            IsModified = true;
        }

        private void RegionTypeDialog_Load(object sender, EventArgs e)
        {
            bindingNavigator1.BindingSource = regionTypeBindingSource;
            regionTypeBindingSource.DataSource = KadrController.Instance.Model.RegionTypes.OrderBy(rT => rT.RegionTypeName);
        }
    }
}
