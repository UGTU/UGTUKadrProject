using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Kadr.Controllers;
using Kadr.Data;
using Kadr.Data.Common;

namespace Kadr.UI.Forms
{
    public partial class KadrBonusForm : Form
    {
        object bonusObject;

        public object BonusObject
        {
            get
            {
                return bonusObject;
            }
            set
            {
                bonusObject = value;
            }
        }
        
        public KadrBonusForm()
        {
            InitializeComponent();
        }

        private void LoadBonus()
        {
            tsbBonusFilter_DropDownItemClicked(null, null);
        }

        private void LoadBonus(ArrayList BonusFilters)
        {
            //фильтруем элементы
            //IEnumerable<Bonus> bonus = Kadr.Controllers.BonusController.Instance.GetBonus(bonusObject).Where(bn => BonusFilters.Contains((bn as IObjectState).State()));
            /*ArrayList bon = new ArrayList();
            foreach (Bonus bn in bonus)
                if (BonusFilters.Contains((bn as IObjectState).State()))
                {
                    bon.Add(bn);
                }*/
            bonusBindingSource.DataSource = Kadr.Controllers.BonusController.Instance.GetBonus(bonusObject).Where(bn => BonusFilters.Contains((bn as IObjectState).State()));


            //bonusBindingSource.DataSource = BonusController.Instance.GetBonus((this.FrameNodeObject as KadrEmployeeObject).Employee);
            //AllbonusBindingSource.DataSource = BonusController.Instance.GetAllEmployeeBonus((this.FrameNodeObject as KadrEmployeeObject).Employee);
            //KadrController.Instance.Model.Bonus.Where(bonus => bonus.FactStaff.Employee == Employee);
        }


        private void KadrBonusForm_Load(object sender, EventArgs e)
        {
            Text = "Надбавки " + bonusObject.ToString();
            LoadBonus();
        }

        private void AddBonusBtn_Click(object sender, EventArgs e)
        {
            BonusController.Instance.AddBonus(bonusObject, bonusBindingSource);
        }

        private void EditBonusBtn_Click(object sender, EventArgs e)
        {
            BonusController.Instance.EditBonus(bonusBindingSource.Current as Bonus);
        }

        private void DelBonusBtn_Click(object sender, EventArgs e)
        {
            BonusController.Instance.DeleteBonus(bonusBindingSource);
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void tsbBonusFilter_DropDownItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            LoadBonus(ObjectStateController.Instance.GetObjectStatesForFilter(tsbBonusFilter, e));
        }

        private void btnChangeBonus_Click(object sender, EventArgs e)
        {
            Bonus currentBonus = bonusBindingSource.Current as Bonus;
            BonusController.Instance.CreateBonusChange(currentBonus);
            LoadBonus();
        }

        private void btnHistoryBonus_Click(object sender, EventArgs e)
        {
            Bonus currentBonus = bonusBindingSource.Current as Bonus;
            if (currentBonus == null)
            {
                MessageBox.Show("Не выбрана надбавка для просмотра истории.", "АИС \"Штатное расписание\"");
                return;
            }

            using (Kadr.UI.Forms.BonusHistoryForm HistForm =
                           new Kadr.UI.Forms.BonusHistoryForm())
            {
                HistForm.Bonus = currentBonus;
                HistForm.ShowDialog();
                LoadBonus();
            }
        }

        private void dgvBonusFactStaff_RowPrePaint(object sender, DataGridViewRowPrePaintEventArgs e)
        {
            //dgvBonusFactStaff.Rows[e.RowIndex].DataBoundItem
            if ((dgvBonusFactStaff.Rows[e.RowIndex].DataBoundItem as Bonus).HasHistoryChanges)
            {
                dgvBonusFactStaff.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.Bisque;
                dgvBonusFactStaff.Rows[e.RowIndex].DefaultCellStyle.SelectionBackColor = Color.DarkOrange;
            }
            else
            {
                dgvBonusFactStaff.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.White;
            }
        }



    }
}
