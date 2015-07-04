using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing.Design;
using System.ComponentModel;


namespace Kadr.UI.Editors
{
    [System.Security.Permissions.PermissionSet(System.Security.Permissions.SecurityAction.Demand, Name = "FullTrust")]
    public class CategoryVPOEditor : System.Drawing.Design.UITypeEditor
    {
        public override object EditValue(ITypeDescriptorContext context, IServiceProvider provider, object value)
        {
            using (Common.ListSelectDialog<Kadr.Data.CategoryVPO> dlg = new Kadr.UI.Common.ListSelectDialog<Kadr.Data.CategoryVPO>())
            {

                dlg.Text = "Категория для ВПО-2 должности";
                dlg.QueryText = "Выберите категорию для ВПО-2";
                dlg.DataSource =
                    Kadr.Controllers.KadrController.Instance.Model.CategoryVPOs.OrderBy(cat => cat.CategoryVPOName);
                dlg.SelectedValue = (Kadr.Data.CategoryVPO)value;

                if (dlg.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                    if (dlg.SelectedValue == null)
                        return Kadr.Data.NullCategoryVPO.Instance;
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

