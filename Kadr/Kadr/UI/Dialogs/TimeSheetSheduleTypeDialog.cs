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
    public partial class TimeSheetSheduleTypeDialog : LinqDataGridViewDialog
    {
        public TimeSheetSheduleTypeDialog()
        {
            InitializeComponent();
        }

        private void TimeSheetSheduleTypeDialog_Load(object sender, EventArgs e)
        {
            bindingNavigator1.BindingSource = timeSheetScheduleTypeBindingSource;
            //timeSheetScheduleTypeBindingSource.DataSource = KadrController.Instance.Model.TimeSheetScheduleTypes;

        }

        private void dataGridView1_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            IsModified = true;
        }
    }
}
