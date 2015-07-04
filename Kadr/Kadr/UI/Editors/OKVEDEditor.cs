using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing.Design;
using System.ComponentModel;


namespace Kadr.UI.Editors
{
    [System.Security.Permissions.PermissionSet(System.Security.Permissions.SecurityAction.Demand, Name = "FullTrust")]
    public class OKVEDEditor : System.Drawing.Design.UITypeEditor
    {
        public override object EditValue(ITypeDescriptorContext context, IServiceProvider provider, object value)
        {
            using (Common.ListSelectDialog<Kadr.Data.OKVED> dlg = new Kadr.UI.Common.ListSelectDialog<Kadr.Data.OKVED>())
            {

                dlg.Text = "Kод экономической деятельности";
                dlg.QueryText = "Выберите ОКВЭД";
                dlg.DataSource =
                    Kadr.Controllers.KadrController.Instance.Model.OKVEDs.OrderBy(okv => okv.OKVEDName);
                dlg.SelectedValue = (Kadr.Data.OKVED)value;

                if (dlg.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                    if (dlg.SelectedValue == null)
                        return Kadr.Data.NullOKVED.Instance;
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

