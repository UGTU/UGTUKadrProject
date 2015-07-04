using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing.Design;
using System.ComponentModel;


namespace Kadr.UI.Editors
{
    [System.Security.Permissions.PermissionSet(System.Security.Permissions.SecurityAction.Demand, Name = "FullTrust")]
    public class CategoryZPEditor : System.Drawing.Design.UITypeEditor
    {
        public override object EditValue(ITypeDescriptorContext context, IServiceProvider provider, object value)
        {
            using (Common.ListSelectDialog<Kadr.Data.CategoryZP> dlg = new Kadr.UI.Common.ListSelectDialog<Kadr.Data.CategoryZP>())
            {

                dlg.Text = "Категория для ЗП-образовния";
                dlg.QueryText = "Выберите категорию для ЗП-образовния";
                dlg.DataSource =
                    Kadr.Controllers.KadrController.Instance.Model.CategoryZPs.OrderBy(cat => cat.CategoryZPName);
                dlg.SelectedValue = (Kadr.Data.CategoryZP)value;

                if (dlg.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                    if (dlg.SelectedValue == null)
                        return Kadr.Data.NullCategoryZP.Instance;
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