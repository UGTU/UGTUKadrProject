using System.Text;
using System.Windows.Forms;
using Kadr.UI.Common;
using Kadr.Controllers;

namespace Kadr.UI.Dialogs
{
    public partial class FinancingSourceDialog : LinqDataGridViewDialog
    {


        public FinancingSourceDialog()
        {
            InitializeComponent();
        }


        private void FinancingSourceDialog_Load(object sender, System.EventArgs e)
        {
            financingSourceBindingSource.DataSource = KadrController.Instance.Model.FinancingSources;
            bindingNavigator1.BindingSource = financingSourceBindingSource;

        }

        private void dataGridView1_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            IsModified = true;
        }



    }
}
