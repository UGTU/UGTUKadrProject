
using System.Linq;
using Kadr.UI.Common;
using Kadr.Controllers;

namespace Kadr.UI.Dialogs
{
    public partial class StandingTypeDialog : LinqDataGridViewDialog
    {
        public StandingTypeDialog()
        {
            InitializeComponent();
        }

        private void dataGridView1_CellBeginEdit(object sender, System.Windows.Forms.DataGridViewCellCancelEventArgs e)
        {
            IsModified = true;
        }

        private void StandingTypeDialog_Load(object sender, System.EventArgs e)
        {
            bindingNavigator1.BindingSource = standingTypeBindingSource;
            standingTypeBindingSource.DataSource = KadrController.Instance.Model.StandingTypes.OrderBy(stT => stT.StandingTypeName);
        }
    }
}
