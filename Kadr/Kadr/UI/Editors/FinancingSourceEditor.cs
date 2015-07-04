using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing.Design;
using System.ComponentModel;


namespace Kadr.UI.Editors
{
    [System.Security.Permissions.PermissionSet(System.Security.Permissions.SecurityAction.Demand, Name = "FullTrust")]
    public class FinancingSourceEditor : System.Drawing.Design.UITypeEditor
    {
        public override object EditValue(ITypeDescriptorContext context, IServiceProvider provider, object value)
        {
            using (Common.ListSelectDialog<Kadr.Data.FinancingSource> dlg = new Kadr.UI.Common.ListSelectDialog<Kadr.Data.FinancingSource>())
            {
                
                dlg.Text = "Источник финансирования";
                dlg.QueryText = "Выберите источник финансирования";
                dlg.DataSource =
                    Kadr.Controllers.KadrController.Instance.Model.FinancingSources.Where(fs => fs.id < 3).OrderBy(finSource => finSource.FinancingSourceName);
                dlg.SelectedValue = (Kadr.Data.FinancingSource)value;

                if (dlg.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                    if (dlg.SelectedValue == null)
                        return Kadr.Data.NullFinancingSource.Instance;
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


