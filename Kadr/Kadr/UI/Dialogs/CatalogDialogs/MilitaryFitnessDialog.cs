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
    public partial class MilitaryFitnessDialog : LinqDataGridViewDialog
    {
        public MilitaryFitnessDialog()
        {
            InitializeComponent();
        }

        private void MilitaryFitnessDialog_Load(object sender, EventArgs e)
        {
            bindingNavigator1.BindingSource = MilitaryFitnessBindingSource;
            MilitaryFitnessBindingSource.DataSource = KadrController.Instance.Model.MilitaryFitnesses.OrderBy(x => x.Letter);
        }

        private void dgvFitnessCategory_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            IsModified = true;
        }
    }
}
