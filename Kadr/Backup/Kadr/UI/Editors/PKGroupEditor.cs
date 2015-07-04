using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing.Design;
using System.ComponentModel;


namespace Kadr.UI.Editors
{
    [System.Security.Permissions.PermissionSet(System.Security.Permissions.SecurityAction.Demand, Name = "FullTrust")]
    public class PKGroupEditor : System.Drawing.Design.UITypeEditor
    {
        public override object EditValue(ITypeDescriptorContext context, IServiceProvider provider, object value)
        {
            using (Common.ListSelectDialog<Kadr.Data.PKGroup> dlg = new Kadr.UI.Common.ListSelectDialog<Kadr.Data.PKGroup>())
            {

                dlg.Text = "Профессиональная группа";
                dlg.QueryText = "Выберите группу";
                dlg.DataSource = Kadr.Controllers.KadrController.Instance.Model.PKGroups.OrderBy(pkGr => pkGr.GroupNumber);
                dlg.SelectedValue = (Kadr.Data.PKGroup)value;

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

