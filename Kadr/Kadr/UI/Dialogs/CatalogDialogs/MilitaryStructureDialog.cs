using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Kadr.Controllers;
using Kadr.UI.Common;

namespace Kadr.UI.Dialogs
{
    public partial class MilitaryStructureDialog : LinqDataGridViewDialog
    {
        public MilitaryStructureDialog()
        {
            InitializeComponent();
        }

        private void MilitaryStructureDialog_Load(object sender, EventArgs e)
        {
            bindingNavigator1.BindingSource = MilitaryStructureBindingSource;
            MilitaryStructureBindingSource.DataSource = KadrController.Instance.Model.MilitaryStructures.OrderBy(x => x.MilitaryStructureName);
        }

        private void dgvMilitaryStructure_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            IsModified = true;
        }
    }
}
