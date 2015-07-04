using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing.Design;
using System.ComponentModel;


namespace Kadr.UI.Editors
{
    [System.Security.Permissions.PermissionSet(System.Security.Permissions.SecurityAction.Demand, Name = "FullTrust")]
    public class PostGroupEditor : System.Drawing.Design.UITypeEditor
    {
        public override object EditValue(ITypeDescriptorContext context, IServiceProvider provider, object value)
        {
            using (Common.ListSelectDialog<Kadr.Data.PostGroup> dlg = new Kadr.UI.Common.ListSelectDialog<Kadr.Data.PostGroup>())
            {

                dlg.Text = "Группа должностей";
                dlg.QueryText = "Выберите группу должностей";
                dlg.DataSource =
                    Kadr.Controllers.KadrController.Instance.Model.PostGroups.OrderBy(pG => pG.GroupName);
                dlg.SelectedValue = (Kadr.Data.PostGroup)value;

                if (dlg.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                    if (dlg.SelectedValue == null)
                        return Kadr.Data.NullCategory.Instance;
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




