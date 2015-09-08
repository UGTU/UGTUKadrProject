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

namespace Kadr.UI.Dialogs
{
    public partial class SalaryDialog : LinqDataGridViewDialog
    {
        public SalaryDialog()
        {
            InitializeComponent();
        }

        private void SalaryDialog_Load(object sender, EventArgs e)
        {
            bindingNavigator1.BindingSource = salaryBindingSource;
            //salaryBindingSource.DataSource = Model.Salaries;
        }
    }
}
