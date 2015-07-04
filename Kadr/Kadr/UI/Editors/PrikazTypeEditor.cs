using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing.Design;
using System.ComponentModel;


namespace Kadr.UI.Editors
{
    [System.Security.Permissions.PermissionSet(System.Security.Permissions.SecurityAction.Demand, Name = "FullTrust")]
    public class PrikazTypeEditor : System.Drawing.Design.UITypeEditor
    {
        public override object EditValue(ITypeDescriptorContext context, IServiceProvider provider, object value)
        {
            using (Common.ListSelectDialog<Kadr.Data.PrikazType> dlg = new Kadr.UI.Common.ListSelectDialog<Kadr.Data.PrikazType>())
            {

                dlg.Text = "Вид приказа";
                dlg.QueryText = "Выберите вид приказа";
                dlg.DataSource = Kadr.Controllers.KadrController.Instance.Model.PrikazTypes.OrderBy(prikType => prikType.PrikazTypeName);
                dlg.SelectedValue = (Kadr.Data.PrikazType)value;

                if (dlg.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                    if (dlg.SelectedValue == null)
                        return Kadr.Data.NullPrikazType.Instance;
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

