using System;
using System.Linq;
using System.Drawing.Design;
using System.ComponentModel;


namespace Kadr.UI.Editors
{
    [System.Security.Permissions.PermissionSet(System.Security.Permissions.SecurityAction.Demand, Name = "FullTrust")]
    public class RegionTypeEditor : System.Drawing.Design.UITypeEditor
    {
        public override object EditValue(ITypeDescriptorContext context, IServiceProvider provider, object value)
        {
            using (Common.ListSelectDialog<Kadr.Data.RegionType> dlg = new Kadr.UI.Common.ListSelectDialog<Kadr.Data.RegionType>())
            {
                dlg.Text = "Тип региона";
                dlg.QueryText = "Выберите тип региона";
                dlg.DataSource = Kadr.Controllers.KadrController.Instance.Model.RegionTypes.OrderBy(rt => rt.RegionTypeName);
                dlg.SelectedValue = (Kadr.Data.RegionType)value;

                if (dlg.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                    if (dlg.SelectedValue == null)
                        return Kadr.Data.NullRegionType.Instance;
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




