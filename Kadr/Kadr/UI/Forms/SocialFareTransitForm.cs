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
    public partial class SocialFareTransitForm : Form
    {
        public Employee Employee
        {
            get;
            set;
        }
        
        public SocialFareTransitForm()
        {
            InitializeComponent();
        }

        private void LoadPeriods()
        {
            socialFareTransitBindingSource.DataSource = KadrController.Instance.Model.SocialFareTransits.Where(sF => sF.Employee == Employee).OrderByDescending(sF => sF.DateBegin).ToArray();
        }

        private void SocialFareTransitForm_Load(object sender, EventArgs e)
        {
            Text = "Периоды льготного проезда " + Employee;
            LoadPeriods();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }


        private void EditPStChangeBtn_Click(object sender, EventArgs e)
        {
            if (socialFareTransitBindingSource.Current != null)
                LinqActionsController<SocialFareTransit>.Instance.EditObject(
                        socialFareTransitBindingSource.Current as SocialFareTransit, true);
            LoadPeriods();
        }

        private void DelPStChangeBtn_Click(object sender, EventArgs e)
        {
            SocialFareTransit CurrentSF = socialFareTransitBindingSource.Current as SocialFareTransit;

            if (CurrentSF == null)
            {
                MessageBox.Show("Не выбран удаляемый льготный период.", "ИС \"Управление кадрами\"");
                return;
            }

            if (MessageBox.Show("Удалить льготный период?", "ИС \"Управление кадрами\"", MessageBoxButtons.OKCancel)
                != DialogResult.OK)
            {
                return;
            }

            Event CurrentPrikaz = CurrentSF.Event;

            if (CurrentPrikaz == null)
                LinqActionsController<SocialFareTransit>.Instance.DeleteObject(CurrentSF, KadrController.Instance.Model.SocialFareTransits, null);
            else
            {
                KadrController.Instance.Model.SocialFareTransits.DeleteOnSubmit(CurrentSF);
                LinqActionsController<Event>.Instance.DeleteObject(CurrentPrikaz, KadrController.Instance.Model.Events, null);
            }

            LoadPeriods();
        }

        private void tsbAddSocFare_Click(object sender, EventArgs e)
        {
            using (Kadr.UI.Common.PropertyGridDialogAdding<SocialFareTransit> dlg =
               new Kadr.UI.Common.PropertyGridDialogAdding<SocialFareTransit>())
            {
                dlg.ObjectList = KadrController.Instance.Model.SocialFareTransits;
                //dlg.BindingSource = employeeStandingBindingSo;
                dlg.UseInternalCommandManager = true;
                dlg.InitializeNewObject = (x) =>
                {
                    dlg.CommandManager.Execute(new UIX.Commands.GenericPropertyCommand<SocialFareTransit, Employee>(x, "Employee", Employee, null), this);
                    dlg.CommandManager.Execute(new UIX.Commands.GenericPropertyCommand<SocialFareTransit, DateTime>(x, "DateBegin", DateTime.Today, null), this);
                    dlg.CommandManager.Execute(new UIX.Commands.GenericPropertyCommand<SocialFareTransit, DateTime>(x, "DateEnd", DateTime.Today.AddYears(2), null), this);
                };

                dlg.UpdateObjectList = () =>
                {
                    dlg.ObjectList = KadrController.Instance.Model.SocialFareTransits;
                };

                dlg.ShowDialog();
            }
            LoadPeriods();
        }
    }
}
