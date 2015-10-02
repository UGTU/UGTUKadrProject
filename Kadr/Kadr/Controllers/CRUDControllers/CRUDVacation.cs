﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Kadr.UI.Common;
using System.Windows.Forms;
using Kadr.Data;

namespace Kadr.Controllers
{
    public static class CRUDVacation
    {
        public static void Create(FactStaff fs, Employee e,BindingSource oKOtpuskBindingSource, object sender)
        {
            using (PropertyGridDialogAdding<OK_Otpusk> dlg =
               SimpleActionsProvider.NewSimpleObjectAddingDialog<OK_Otpusk>())
            {

                dlg.InitializeNewObject = (x) =>
                {
                    dlg.CommandManager.Execute(new UIX.Commands.GenericPropertyCommand<OK_Otpusk, Event>(x, "Event",
                        new Event(dlg.CommandManager, fs.CurrentChange, MagicNumberController.VacationEventKind,MagicNumberController.BeginEventType, false, NullPrikaz.Instance, DateTime.Today.Date), null), sender);
                    dlg.CommandManager.Execute(new UIX.Commands.GenericPropertyCommand<OK_Otpusk, OK_Otpuskvid>(x, "OK_Otpuskvid", NullOK_Otpuskvid.Instance, null), sender);
                    dlg.CommandManager.Execute(new UIX.Commands.GenericPropertyCommand<OK_Otpusk, DateTime?>(x, "DateBegin", DateTime.Today.Date, null), sender);
                    dlg.CommandManager.Execute(new UIX.Commands.GenericPropertyCommand<OK_Otpusk, DateTime?>(x, "DateEnd", DateTime.Today.Date, null), sender);
                };

                dlg.ShowDialog();
            }
            Read(fs, oKOtpuskBindingSource);
        }

        public static void Read(FactStaff fs, BindingSource oKOtpuskBindingSource)
        {

           if (fs != null)
               oKOtpuskBindingSource.DataSource = KadrController.Instance.Model.OK_Otpusks.Where(otp => otp.Event.FactStaffHistory.FactStaff == fs).Where(
                   otp => otp.Event.DateBegin >= DateTime.Today.AddYears(-1)).OrderByDescending(otp => otp.Event.DateBegin);
           else
               oKOtpuskBindingSource.DataSource = null;
            
        }

        public static void Update(FactStaff fs, Employee e, BindingSource oKOtpuskBindingSource)
        {
            if (oKOtpuskBindingSource.Current != null)
                LinqActionsController<OK_Otpusk>.Instance.EditObject(
                        oKOtpuskBindingSource.Current as OK_Otpusk, true);
            Read(fs, oKOtpuskBindingSource);
        }

        public static void Delete(FactStaff fs, Employee e, BindingSource oKOtpuskBindingSource)
        {
             OK_Otpusk CurrentOtp = oKOtpuskBindingSource.Current as OK_Otpusk;
             Event CurrentPrikaz = CurrentOtp.Event;

            if (CurrentOtp == null)
            {
                MessageBox.Show("Не выбран удаляемый отпуск.", "ИС \"Управление кадрами\"");
                return;
            }

            if (MessageBox.Show("Удалить отпуск?", "ИС \"Управление кадрами\"", MessageBoxButtons.OKCancel)
                != DialogResult.OK)
            {
                return;
            }

            KadrController.Instance.Model.OK_Otpusks.DeleteOnSubmit(CurrentOtp);
            LinqActionsController<Event>.Instance.DeleteObject(CurrentPrikaz, KadrController.Instance.Model.Events, null);

            Read(fs, oKOtpuskBindingSource);
        }
    }
}
