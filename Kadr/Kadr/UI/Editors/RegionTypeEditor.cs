using System;
using System.Linq;
using System.Drawing.Design;
using System.ComponentModel;


namespace Kadr.UI.Editors
{
    [System.Security.Permissions.PermissionSet(System.Security.Permissions.SecurityAction.Demand, Name = "FullTrust")]
    public class RegionTypeEditor : UITypeEditor
    {
        public override object EditValue(ITypeDescriptorContext context, IServiceProvider provider, object value)
        {
            using (Common.ListSelectDialog<Data.RegionType> dlg = new Common.ListSelectDialog<Data.RegionType>())
            {

                dlg.Text = "Тип региона";
                dlg.QueryText = "Выберите тип региона";
                dlg.DataSource =
                    Controllers.KadrController.Instance.Model.RegionTypes.OrderBy(rT => rT.RegionTypeName);
                dlg.SelectedValue = (Data.RegionType)value;

                if (dlg.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                    if (dlg.SelectedValue == null)
                        return Data.NullRegionType.Instance;
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
    
