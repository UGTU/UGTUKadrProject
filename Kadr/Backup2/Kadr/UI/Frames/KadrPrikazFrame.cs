using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Kadr.Controllers;
using Kadr.Data;

namespace Kadr.UI.Frames
{
    public partial class KadrPrikazFrame : KadrBaseFrame
    {
        /// <summary>
        /// Модель
        /// </summary>
        //public Kadr.Data.dckadrDataContext Model
        //{
        //    get
        //    {
        //        return KadrController.Instance.Model;
        //    }
        //}

        public KadrPrikazFrame()
        {
            InitializeComponent();
        }


        public KadrPrikazFrame(object AObject)
        {
            InitializeComponent();
            FrameObject = AObject;
        }


        protected override void DoRefreshFrame()
        {
            prikazDecoratorBindingSource.DataSource = KadrController.Instance.Model.Prikazs;
        }

        private void AddPrikazBtn_Click(object sender, EventArgs e)
        {
            using (Kadr.UI.Common.PropertyGridDialogAdding<Prikaz> dlg =
                        new Kadr.UI.Common.PropertyGridDialogAdding<Prikaz>())
            {
                dlg.UseInternalCommandManager = true;
                dlg.ObjectList = KadrController.Instance.Model.Prikazs;
                dlg.BindingSource = prikazDecoratorBindingSource;
                dlg.InitializeNewObject = (x) =>
                {
                    dlg.CommandManager.Execute(new UIX.Commands.GenericPropertyCommand<Prikaz, string>(x, "PrikazName", "Новый приказ", null), this);
                    if ((dlg.SelectedObjects != null) && (dlg.SelectedObjects.Length == 1))
                    {
                        Prikaz prev = dlg.SelectedObjects[0] as Prikaz;
                        dlg.CommandManager.Execute(new UIX.Commands.GenericPropertyCommand<Prikaz, PrikazType>(x, "PrikazType", prev.PrikazType, null), this);
                        dlg.CommandManager.Execute(new UIX.Commands.GenericPropertyCommand<Prikaz, DateTime?>(x, "DateBegin", prev.DateBegin, null), this);
                        dlg.CommandManager.Execute(new UIX.Commands.GenericPropertyCommand<Prikaz, DateTime?>(x, "DatePrikaz", prev.DatePrikaz, null), this);
                    }
                    else
                    {
                        dlg.CommandManager.Execute(new UIX.Commands.GenericPropertyCommand<Prikaz, PrikazType>(x, "PrikazType", NullPrikazType.Instance, null), this);
                        dlg.CommandManager.Execute(new UIX.Commands.GenericPropertyCommand<Prikaz, DateTime?>(x, "DateBegin", DateTime.Today, null), this);
                        dlg.CommandManager.Execute(new UIX.Commands.GenericPropertyCommand<Prikaz, DateTime?>(x, "DatePrikaz", DateTime.Today, null), this);
                    }
                };

                dlg.ShowDialog();
            }

        }

        private void EditPrikazBtn_Click(object sender, EventArgs e)
        {
            LinqActionsController<Prikaz>.Instance.EditObject(prikazDecoratorBindingSource.Current as Prikaz, false);

        }

        private void DeletePrikazBtn_Click(object sender, EventArgs e)
        {
           if (MessageBox.Show("Удалить приказ?", "АИС Штатное расписание", MessageBoxButtons.OKCancel)
               == DialogResult.OK)
           {
               LinqActionsController<Prikaz>.Instance.DeleteObject(prikazDecoratorBindingSource.Current as Prikaz,
                    KadrController.Instance.Model.Prikazs, prikazDecoratorBindingSource);

           }
        }

        private void dgvPrikaz_DoubleClick(object sender, EventArgs e)
        {
            EditPrikazBtn_Click(sender, e);

        }

    }
}
