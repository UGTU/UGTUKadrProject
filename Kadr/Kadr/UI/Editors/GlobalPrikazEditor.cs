using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing.Design;
using System.ComponentModel;


namespace Kadr.UI.Editors
{
    [System.Security.Permissions.PermissionSet(System.Security.Permissions.SecurityAction.Demand, Name = "FullTrust")]
    public class GlobalPrikazEditor : System.Drawing.Design.UITypeEditor
    {
        public override object EditValue(ITypeDescriptorContext context, IServiceProvider provider, object value)
        {
            using (Common.ListSelectDialog<Kadr.Data.GlobalPrikaz> dlg = new Kadr.UI.Common.ListSelectDialog<Kadr.Data.GlobalPrikaz>())
            {

                dlg.Text = "Приказ министерства";
                dlg.QueryText = "Выберите приказ министерства";
                dlg.DataSource = Kadr.Controllers.KadrController.Instance.Model.GlobalPrikazs.OrderBy(globPrik => globPrik.PrikazNumber);
                dlg.SelectedValue = (Kadr.Data.GlobalPrikaz)value;

                if (dlg.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                    //if (dlg.SelectedValue == null)
                    //    return Kadr.Data.NullPrikaz.Instance;
                    //else
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


