using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Kadr.Controllers;

namespace Kadr.UI.Common
{
    public partial class LinqDataGridViewDialog : DataGridViewDialog
    {
        public LinqDataGridViewDialog()
        {
            InitializeComponent();
        }



        
        protected override void DoApply()
        {
            if (!IsModified)
                return;

            try
            {
                KadrController.Instance.SubmitChanges();
                IsModified = false;
            }
            catch (Exception e)
            {
                
                KadrController.Instance.DeleteModel();
                MessageBox.Show(e.Message, "АИС \"Штатное расписание\"");

                return;
            }

        }

        protected override void DoCancel()
        {
            KadrController.Instance.DeleteModel();
            IsModified = false;
        }

        private void LinqDataGridViewDialog_Load(object sender, EventArgs e)
        {
            ApplyButtonVisible = true;
        }

    }
}
