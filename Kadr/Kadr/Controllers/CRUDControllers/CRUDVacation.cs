using System;
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
                    dlg.CommandManager.Execute(new UIX.Commands.GenericPropertyCommand<OK_Otpusk, FactStaffPrikaz>(x, "FactStaffPrikaz", 
                        new FactStaffPrikaz(dlg.CommandManager, fs as FactStaff), null), sender);
                    dlg.CommandManager.Execute(new UIX.Commands.GenericPropertyCommand<OK_Otpusk, OK_Otpuskvid>(x, "OK_Otpuskvid", NullOK_Otpuskvid.Instance, null), sender);
                };

                dlg.ShowDialog();
            }
            Read(fs, e, oKOtpuskBindingSource);
        }

        public static void Read(FactStaff fs, Employee e, BindingSource oKOtpuskBindingSource)
        {
           IQueryable<OK_Otpusk> tmp;

            if (fs != null )
                tmp = KadrController.Instance.Model.OK_Otpusks.Where(otp => otp.FactStaffPrikaz.FactStaff == fs);
            else
                tmp = KadrController.Instance.Model.OK_Otpusks.Where(otp => otp.FactStaffPrikaz.FactStaff.Employee == e);
               
                oKOtpuskBindingSource.DataSource =
                    tmp.Where(otp => otp.FactStaffPrikaz.DateBegin >= DateTime.Today.AddYears(-2)).OrderByDescending(otp => otp.FactStaffPrikaz.DateBegin);
            
        }

        public static void Update(FactStaff fs, Employee e, BindingSource oKOtpuskBindingSource)
        {
            if (oKOtpuskBindingSource.Current != null)
                LinqActionsController<OK_Otpusk>.Instance.EditObject(
                        oKOtpuskBindingSource.Current as OK_Otpusk, true);
            Read(fs, e, oKOtpuskBindingSource);
        }

        public static void Delete(FactStaff fs, Employee e, BindingSource oKOtpuskBindingSource)
        {
             OK_Otpusk CurrentOtp = oKOtpuskBindingSource.Current as OK_Otpusk;
            FactStaffPrikaz CurrentPrikaz = CurrentOtp.FactStaffPrikaz;

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
            LinqActionsController<FactStaffPrikaz>.Instance.DeleteObject(CurrentPrikaz, KadrController.Instance.Model.FactStaffPrikazs, null);

            Read(fs, e, oKOtpuskBindingSource);
        }
    }
}
