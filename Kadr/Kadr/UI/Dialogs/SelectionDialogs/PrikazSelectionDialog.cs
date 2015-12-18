using Kadr.Controllers;
using Kadr.Data;
using Kadr.UI.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Kadr.UI.Dialogs
{
    public partial class PrikazSelectionDialog : CustomBaseDialog
    {
        static private int lastPrikazId = 0;
        static private bool doFilter = true;

        private bool UserSelected = false;

        private void RefreshPrikazs()
        {
            cbSuperType.Enabled = doFilter;
            cbType.Enabled = doFilter;

            if (doFilter)
                cbPrikaz.DataSource = KadrController.Instance.Model.Prikazs.Where(p => p.PrikazType == cbType.SelectedItem).OrderByDescending(x => x.DatePrikaz);
            else
                cbPrikaz.DataSource = KadrController.Instance.Model.Prikazs.OrderByDescending(x => x.DatePrikaz);

            if ((lastPrikazId > 0)&&(!UserSelected))
                cbPrikaz.SelectedItem = KadrController.Instance.Model.Prikazs.SingleOrDefault(p => p.id == lastPrikazId);

            cbFilter.Checked = doFilter;
            dialogObject = cbPrikaz.SelectedItem;
        }

        public PrikazSelectionDialog(PrikazType pt)
        {
            InitializeComponent();
            ApplyButtonVisible = false;

            cbSuperType.DataSource = KadrController.Instance.Model.PrikazSuperTypes;

            if (pt != null)
            {
                cbSuperType.SelectedItem = KadrController.Instance.Model.PrikazSuperTypes.FirstOrDefault(x => x.PrikazTypes.FirstOrDefault(p => p == pt) != null);
                cbType.SelectedItem = pt;
                doFilter = true;
                cbFilter.Checked = true;
                panel1.Visible = false;
                Height -= panel1.Height;
            }
            else
            {
                cbSuperType.SelectedItem = KadrController.Instance.Model.PrikazSuperTypes.FirstOrDefault();
                panel1.Visible = true;
                
            }
            
            RefreshPrikazs();
        }

        private void cbSuperType_SelectedIndexChanged(object sender, EventArgs e)
        {
            cbType.DataSource = KadrController.Instance.Model.PrikazTypes.Where(pt => pt.PrikazSuperType == cbSuperType.SelectedItem);
        }

        private void cbType_SelectedIndexChanged(object sender, EventArgs e)
        {
           RefreshPrikazs();
        }

        private void cbPrikaz_SelectedIndexChanged(object sender, EventArgs e)
        {
            dialogObject = cbPrikaz.SelectedItem;
        }

        private void bAddingMode_Click(object sender, EventArgs e)
        {
            cbFilter.Visible = false;
            pSelection.Visible = false;
            pAdding.Visible = true;
            this.Height -= pSelection.Height;
            this.Height += pAdding.Height;
            cbSuperType.Enabled = true;
            cbType.Enabled = true;
        }


        private void bCancelAddingMode_Click(object sender, EventArgs e)
        {
            cbFilter.Visible = true;
            pSelection.Visible = true;
            pAdding.Visible = false;
            this.Height -= pAdding.Height;
            this.Height += pSelection.Height;
            cbSuperType.Enabled = cbFilter.Checked;
            cbType.Enabled = cbFilter.Checked;
        }

        private void OKBtn_Click(object sender, EventArgs e)
        {
            if (pAdding.Visible)
            {

                DateTime? d1 = dtDate.Value;
                DateTime? d2 = (dtBegin.Checked) ? dtDate.Value : (DateTime?)null;
                DateTime? d3 = (dtEnd.Checked) ? dtDate.Value : (DateTime?)null;

                Prikaz p = CRUDPrikaz.Create(tbName.Text, (PrikazType)cbType.SelectedItem, d1, d2, d3);

                dialogObject = p;
            }
            if (dialogObject!= null)
            lastPrikazId = (dialogObject as Prikaz).id;
        }

        private void dtDate_ValueChanged(object sender, EventArgs e)
        {
            dtBegin.Value = dtDate.Value;
            dtBegin.Checked = false;
            dtEnd.Value = dtDate.Value;
            dtEnd.Checked = false;

        }

        private void button1_Click(object sender, EventArgs e)
        {
            cbPrikaz.SelectedItem = null;
        }

        private void cbFilter_Click(object sender, EventArgs e)
        {
            doFilter = cbFilter.Checked;
            RefreshPrikazs();
        }

        private void cbPrikaz_Click(object sender, EventArgs e)
        {
            UserSelected = true;
        }
    }
}
