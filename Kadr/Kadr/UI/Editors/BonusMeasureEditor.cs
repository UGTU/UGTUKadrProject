using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing.Design;
using System.ComponentModel;


namespace Kadr.UI.Editors
{
    [System.Security.Permissions.PermissionSet(System.Security.Permissions.SecurityAction.Demand, Name = "FullTrust")]
    public class BonusMeasureEditor : System.Drawing.Design.UITypeEditor
    {
        public override object EditValue(ITypeDescriptorContext context, IServiceProvider provider, object value)
        {
            using (Common.ListSelectDialog<Kadr.Data.BonusMeasure> dlg = new Kadr.UI.Common.ListSelectDialog<Kadr.Data.BonusMeasure>())
            {

                dlg.Text = "Единица измерения надбавки";
                dlg.QueryText = "Выберите единицу измерения надбавки";
                dlg.DataSource = Kadr.Controllers.KadrController.Instance.Model.BonusMeasures.OrderBy(bonMeas => bonMeas.MeasureName);
                dlg.SelectedValue = (Kadr.Data.BonusMeasure)value;

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
    }

}

