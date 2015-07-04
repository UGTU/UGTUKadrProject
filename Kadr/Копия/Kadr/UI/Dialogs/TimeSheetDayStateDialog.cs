using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Kadr.UI.Common;
using Kadr.Controllers;

namespace Kadr.UI.Dialogs
{
    public partial class TimeSheetDayStateDialog : LinqDataGridViewDialog
    {
        public TimeSheetDayStateDialog()
        {
            InitializeComponent();
        }

        private void TimeSheetDayStateDialog_Load(object sender, EventArgs e)
        {
            bindingNavigator1.BindingSource = timeSheetDayStateBindingSource;
            timeSheetDayStateBindingSource.DataSource = KadrController.Instance.Model.TimeSheetDayStates;

        }

        private void dataGridView2_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            IsModified = true;
        }
    }
}
