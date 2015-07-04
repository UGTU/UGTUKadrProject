using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Kadr.Data;
using Kadr.Controllers;

namespace Kadr.UI.Forms
{
    public partial class FactStaffHistoryForm : Form
    {
        private FactStaff factStaff;
        public FactStaff FactStaff
        {
            get
            {
                return factStaff;
            }
            set
            {
                factStaff = value;
            }
        }
        
        public FactStaffHistoryForm()
        {
            InitializeComponent();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void FactStaffHistoryForm_Load(object sender, EventArgs e)
        {
            if (FactStaff != null)
            {
                Text = "История " + FactStaff.ToString();
                factStaffHistoryBindingSource.DataSource =
                    Kadr.Controllers.KadrController.Instance.Model.FactStaffHistories.Where(hist =>
                        hist.FactStaff == FactStaff).OrderByDescending(hist => hist.DateBegin);
            }
        }

        private void EditFStChangeBtn_Click(object sender, EventArgs e)
        {
            if (FactStaff != null)
            {
                FactStaffHistory CurrentChange = factStaffHistoryBindingSource.Current as FactStaffHistory;
                if (CurrentChange == null)
                {
                    MessageBox.Show("Не выбрано редактируемое изменение.", "АИС \"Штатное расписание\"");
                    return;
                }
                LinqActionsController<FactStaffHistory>.Instance.EditObject(factStaffHistoryBindingSource.Current as FactStaffHistory, true);
            }
        }

        private void DelFStChangeBtn_Click(object sender, EventArgs e)
        {
            FactStaffHistory CurrentChange = factStaffHistoryBindingSource.Current as FactStaffHistory;
            if (CurrentChange == null)
            {
                MessageBox.Show("Не выбрано удаляемое изменение.", "АИС \"Штатное расписание\"");
                return;
            }
           
            if (MessageBox.Show("Удалить изменение?", "АИС Штатное расписание", MessageBoxButtons.OKCancel)
               == DialogResult.OK)
            {
                
                LinqActionsController<FactStaffHistory>.Instance.DeleteObject(factStaffHistoryBindingSource.Current as FactStaffHistory,
                     KadrController.Instance.Model.FactStaffHistories, factStaffHistoryBindingSource);

            }
        }
    }
}
