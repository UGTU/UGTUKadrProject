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
    public partial class BonusHistoryForm : Form
    {
        private Bonus bonus;

        public Bonus Bonus
        {
            get
            {
                return bonus;
            }
            set
            {
                bonus = value;
            }
        }
        
        public BonusHistoryForm()
        {
            InitializeComponent();
        }

        private void BonusHistoryForm_Load(object sender, EventArgs e)
        {
            if (bonus != null)
            {
                Text = "История "+bonus.ToString();
                bonusHistoryBindingSource.DataSource = KadrController.Instance.Model.BonusHistories.Where(bonHist =>
                    bonHist.Bonus == bonus).OrderByDescending(bonHist => bonHist.DateBegin);
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void EditPStChangeBtn_Click(object sender, EventArgs e)
        {
            if (bonus != null)
            {
                BonusHistory CurrentChange = bonusHistoryBindingSource.Current as BonusHistory;
                if (CurrentChange == null)
                {
                    MessageBox.Show("Не выбрано редактируемое изменение.", "АИС \"Штатное расписание\"");
                    return;
                }
                LinqActionsController<BonusHistory>.Instance.EditObject(CurrentChange, true);
            }
            
        }

        private void DelPStChangeBtn_Click(object sender, EventArgs e)
        {
            BonusHistory CurrentChange = bonusHistoryBindingSource.Current as BonusHistory;
            if (CurrentChange == null)
            {
                MessageBox.Show("Не выбрано удаляемое изменение.", "АИС \"Штатное расписание\"");
                return;
            }

            //Если это последнее изменение истории, то спрашиваем удалить ли надбавку полностью. Иначе откат
            if (Bonus.BonusHistories.Count == 1)
            {
                if (MessageBox.Show("Вы пытаетесь удалить последнее изменение надбавки. Его можно удалить только вместе с надбавкой. Удалить надбавку полностью?", "АИС Штатное расписание", MessageBoxButtons.OKCancel)
                    == DialogResult.OK)
                {
                    BonusController.Instance.DeleteBonus(null, Bonus);
                    Close();
                    return;
                }
            }

            if (MessageBox.Show("Удалить изменение?", "АИС Штатное расписание", MessageBoxButtons.OKCancel)
               == DialogResult.OK)
            {
                LinqActionsController<BonusHistory>.Instance.DeleteObject(CurrentChange,
                     KadrController.Instance.Model.BonusHistories, bonusHistoryBindingSource);

            }
        }
    }
}
