using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing.Design;
using System.ComponentModel;


namespace Kadr.UI.Editors
{
    [System.Security.Permissions.PermissionSet(System.Security.Permissions.SecurityAction.Demand, Name = "FullTrust")]
    public class RankEditor : System.Drawing.Design.UITypeEditor
    {
        public override object EditValue(ITypeDescriptorContext context, IServiceProvider provider, object value)
        {
            using (Common.ListSelectDialog<Kadr.Data.Rank> dlg = new Kadr.UI.Common.ListSelectDialog<Kadr.Data.Rank>())
            {

                dlg.Text = "Ученое звание";
                dlg.QueryText = "Выберите ученое звание";
                dlg.DataSource =
                    Kadr.Controllers.KadrController.Instance.Model.Ranks.OrderBy(rank => rank.RankName);
                dlg.SelectedValue = (Kadr.Data.Rank)value;

                if (dlg.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                    if (dlg.SelectedValue == null)
                        return Kadr.Data.NullRank.Instance;
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


