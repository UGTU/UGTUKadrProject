using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing.Design;
using System.ComponentModel;


namespace Kadr.UI.Editors
{
    [System.Security.Permissions.PermissionSet(System.Security.Permissions.SecurityAction.Demand, Name = "FullTrust")]
    public class BonusSuperTypeEditor : System.Drawing.Design.UITypeEditor
    {
        public override object EditValue(ITypeDescriptorContext context, IServiceProvider provider, object value)
        {
            using (Common.ListSelectDialog<Kadr.Data.BonusSuperType> dlg = new Kadr.UI.Common.ListSelectDialog<Kadr.Data.BonusSuperType>())
            {

                dlg.Text = "Тип надбавки";
                dlg.QueryText = "Выберите тип надбавки";
                dlg.DataSource = Kadr.Controllers.KadrController.Instance.Model.BonusSuperTypes.OrderBy(bonType => bonType.BonusSuperTypeName);
                dlg.SelectedValue = (Kadr.Data.BonusSuperType)value;

                if (dlg.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                    if (dlg.SelectedValue == null)
                        return Kadr.Data.NullBonusSuperType.Instance;
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

