﻿using Kadr.Controllers;
using Kadr.Controllers.CRUDControllers;
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
        public PrikazSelectionDialog(PrikazType pt)
        {
            InitializeComponent();
            ApplyButtonVisible = false;

            cbSuperType.DataSource = KadrController.Instance.Model.PrikazSuperTypes;

            if (pt!= null)
            {
                cbSuperType.SelectedItem = KadrController.Instance.Model.PrikazSuperTypes.FirstOrDefault(x=>x.PrikazTypes.FirstOrDefault(p=>p==pt)!=null);
                cbType.SelectedItem = pt;
            }
            else
            cbSuperType.SelectedItem = KadrController.Instance.Model.PrikazSuperTypes.FirstOrDefault();
        }

        private void cbSuperType_SelectedIndexChanged(object sender, EventArgs e)
        {
            cbType.DataSource = KadrController.Instance.Model.PrikazTypes.Where(pt=>pt.PrikazSuperType == cbSuperType.SelectedItem);
        }

        private void cbType_SelectedIndexChanged(object sender, EventArgs e)
        {
            cbPrikaz.DataSource = KadrController.Instance.Model.Prikazs.Where(p => p.PrikazType == cbType.SelectedItem);
        }

        private void cbPrikaz_SelectedIndexChanged(object sender, EventArgs e)
        {
            dialogObject = cbPrikaz.SelectedItem;
        }

        private void bAddingMode_Click(object sender, EventArgs e)
        {
            pSelection.Visible = false;
            pAdding.Visible = true;
            this.Height -= pSelection.Height;
            this.Height += pAdding.Height;
        }

        private void bAdd_Click(object sender, EventArgs e)
        {
            Prikaz p = CRUDPrikaz.Create(tbName.Text, (PrikazType)cbType.SelectedItem, dtDate.Value, dtBegin.Value, dtEnd.Value);
            cbPrikaz.DataSource = KadrController.Instance.Model.Prikazs.Where(x => x.PrikazType == cbType.SelectedItem);
            cbPrikaz.Text = p.ToString();
            dialogObject = p;
            bCancelAddingMode_Click(sender, e);
        }

        private void bCancelAddingMode_Click(object sender, EventArgs e)
        {
            pSelection.Visible = true;
            pAdding.Visible = false;
            this.Height -= pAdding.Height;
            this.Height += pSelection.Height;
        }
    }
}