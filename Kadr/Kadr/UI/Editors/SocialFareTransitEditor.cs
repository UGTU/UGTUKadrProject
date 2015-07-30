using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing.Design;
using System.ComponentModel;


namespace Kadr.UI.Editors
{
    /*[System.Security.Permissions.PermissionSet(System.Security.Permissions.SecurityAction.Demand, Name = "FullTrust")]
    public class SocialFareTransitEditor : System.Drawing.Design.UITypeEditor
    {
        public override object EditValue(ITypeDescriptorContext context, IServiceProvider provider, object value)
        {
            using (Common.ListSelectDialog<Kadr.Data.SocialFareTransit> dlg = new Kadr.UI.Common.ListSelectDialog<Kadr.Data.SocialFareTransit>())
            {

                dlg.Text = "Льготный проезд";
                dlg.QueryText = "Выберите льготный проезд сотрудника";
                dlg.DataSource = Kadr.Controllers.KadrController.Instance.Model.SocialFareTransits.OrderByDescending(sF => sF.DateBegin);
                dlg.SelectedValue = (Kadr.Data.SocialFareTransit)value;

                if (dlg.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                    if (dlg.SelectedValue == null)
                        return Kadr.Data.NullBonusMeasure.Instance;
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
    }*/

}


