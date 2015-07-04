using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing.Design;
using System.ComponentModel;


namespace Kadr.UI.Editors
{
    [System.Security.Permissions.PermissionSet(System.Security.Permissions.SecurityAction.Demand, Name = "FullTrust")]
    public class BonusTypeEditor : System.Drawing.Design.UITypeEditor
    {
        public override object EditValue(ITypeDescriptorContext context, IServiceProvider provider, object value)
        {
            using (Common.ListSelectDialog<Kadr.Data.BonusType> dlg = new Kadr.UI.Common.ListSelectDialog<Kadr.Data.BonusType>())
            {

                dlg.Text = "Вид надбавки";
                dlg.QueryText = "Выберите вид надбавки";
                dlg.DataSource = Kadr.Controllers.KadrController.Instance.Model.BonusTypes.OrderBy(bonType => bonType.BonusTypeName);
                dlg.SelectedValue = (Kadr.Data.BonusType)value;

                if (dlg.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                    if (dlg.SelectedValue == null)
                        return Kadr.Data.NullBonusType.Instance;
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


