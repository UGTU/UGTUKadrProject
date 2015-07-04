using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing.Design;
using System.ComponentModel;


namespace Kadr.UI.Editors
{
    [System.Security.Permissions.PermissionSet(System.Security.Permissions.SecurityAction.Demand, Name = "FullTrust")]
    public class PKCategoryEditor : System.Drawing.Design.UITypeEditor
    {
        public override object EditValue(ITypeDescriptorContext context, IServiceProvider provider, object value)
        {
            using (Common.ListSelectDialog<Kadr.Data.PKCategory> dlg = new Kadr.UI.Common.ListSelectDialog<Kadr.Data.PKCategory>())
            {

                dlg.Text = "Профессиональная категория";
                dlg.QueryText = "Выберите категорию";
                dlg.DataSource = Kadr.Controllers.KadrController.Instance.Model.PKCategories.OrderByDescending(pkCat => pkCat.idPKGroup)
                    .ThenByDescending(pkCat => pkCat.PKCategoryNumber).ThenByDescending(pkCat => pkCat.PKSubCategoryNumber).ThenByDescending(pkCat => pkCat.PKSubSubCategoryNumber);
                dlg.SelectedValue = (Kadr.Data.PKCategory)value;

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



