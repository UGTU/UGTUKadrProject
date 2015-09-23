using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing.Design;
using System.ComponentModel;
using Kadr.UI.Dialogs;
using Kadr.Data;
using Kadr.Interfaces;

namespace Kadr.UI.Editors
{
    [System.Security.Permissions.PermissionSet(System.Security.Permissions.SecurityAction.Demand, Name = "FullTrust")]
    public class PrikazEditor : System.Drawing.Design.UITypeEditor
    {
        public override object EditValue(ITypeDescriptorContext context, IServiceProvider provider, object value)
        {
            PrikazType pt = null;
            if (context.Instance is IPrikazTypeProvider)
                pt = (context.Instance as IPrikazTypeProvider).PrikazType;

            using (PrikazSelectionDialog dlg = new PrikazSelectionDialog(pt))
            {
                dlg.Text = "Приказ";
                //dlg.QueryText    = "Выберите приказ";
                //dlg.DataSource = Kadr.Controllers.KadrController.Instance.Model.Prikazs.Where(pr => (pr.idPrikazType < 26) || (pr.idPrikazType > 28)).OrderByDescending(prik => prik.DatePrikaz).ThenByDescending(prik => prik.PrikazName);
                //dlg.SelectedValue = (Kadr.Data.Prikaz)value;

                if (dlg.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                    //if (dlg.SelectedValue == null)
                    //    return Kadr.Data.NullPrikaz.Instance;
                    //else
                    return dlg.DialogObject;
                else
                    return value;
            }

            /*using (Common.ListSelectDialog<Kadr.Data.Prikaz> dlg = new Kadr.UI.Common.ListSelectDialog<Kadr.Data.Prikaz>())
            {

                dlg.Text = "Приказ";
                dlg.QueryText = "Выберите приказ";
                dlg.DataSource = Kadr.Controllers.KadrController.Instance.Model.Prikazs.Where(pr => (pr.idPrikazType <26) || (pr.idPrikazType > 28)).OrderByDescending(prik => prik.DatePrikaz).ThenByDescending(prik => prik.PrikazName);
                dlg.SelectedValue = (Kadr.Data.Prikaz)value;
                

                if (dlg.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                    //if (dlg.SelectedValue == null)
                    //    return Kadr.Data.NullPrikaz.Instance;
                    //else
                        return dlg.SelectedValue;
                else
                    return value;
            }*/

        }

        public override UITypeEditorEditStyle GetEditStyle(ITypeDescriptorContext context)
        {
            return UITypeEditorEditStyle.Modal;
        }
    }

}


