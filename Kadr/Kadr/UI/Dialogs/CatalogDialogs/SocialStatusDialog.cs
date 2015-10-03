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
    public partial class SocialStatusDialog : LinqDataGridViewDialog
    {
        public SocialStatusDialog()
        {
            InitializeComponent();
        }
        
        private void SocialStatusDialog_Load(object sender, EventArgs e)
        {
            bindingNavigator1.BindingSource = SocialStatusBindingSource;
            SocialStatusBindingSource.DataSource = KadrController.Instance.Model.OK_SocialStatus.OrderBy(x => x.SocialStatusName);
        }

        private void dgvSocialStatus_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            IsModified = true;
        }
           
    }
}
