using System;
using System.Linq;
using System.Drawing.Design;
using System.ComponentModel;


namespace Kadr.UI.Editors
{
    [System.Security.Permissions.PermissionSet(System.Security.Permissions.SecurityAction.Demand, Name = "FullTrust")]
    public class OK_OtpuskvidEditor : System.Drawing.Design.UITypeEditor
    {
        public override object EditValue(ITypeDescriptorContext context, IServiceProvider provider, object value)
        {
            using (Common.ListSelectDialog<Kadr.Data.OK_Otpuskvid> dlg = new Kadr.UI.Common.ListSelectDialog<Kadr.Data.OK_Otpuskvid>())
            {

                dlg.Text = "Категория персонала";
                dlg.QueryText = "Выберите категорию";
                dlg.DataSource =
                    Kadr.Controllers.KadrController.Instance.Model.OK_Otpuskvids.OrderBy(OtpV => OtpV.otpuskvidname).ToArray();
                dlg.SelectedValue = (Kadr.Data.OK_Otpuskvid)value;

                if (dlg.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                    if (dlg.SelectedValue == null)
                        return Kadr.Data.NullOK_Otpuskvid.Instance;
                    else
                        return dlg.SelectedValue;
                else
                    return value;
            }

        }

        public override UITypeEditorEditStyle GetEditStyle(ITypeDescriptorContext context)
        {
            return UITypeEditorEditStyle.Modal;
        }
    }

}

