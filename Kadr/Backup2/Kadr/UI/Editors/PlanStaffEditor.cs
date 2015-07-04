using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing.Design;
using System.ComponentModel;


namespace Kadr.UI.Editors
{
    [System.Security.Permissions.PermissionSet(System.Security.Permissions.SecurityAction.Demand, Name = "FullTrust")]
    public class PlanStaffEditor : System.Drawing.Design.UITypeEditor
    {
        public override object EditValue(ITypeDescriptorContext context, IServiceProvider provider, object value)
        {
            using (Common.ListSelectDialog<Kadr.Data.PlanStaff> dlg = new Kadr.UI.Common.ListSelectDialog<Kadr.Data.PlanStaff>())
            {
                
                dlg.Text = "Запись штатного расписания";
                dlg.QueryText = "Выберите запись штатного расписания";
                dlg.DataSource = Kadr.Controllers.KadrController.Instance.Model.PlanStaffs;
                dlg.SelectedValue = (Kadr.Data.PlanStaff)value;

                if (dlg.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    if (dlg.SelectedValue == null)
                        return Kadr.Data.NullPlanStaff.Instance;
                    else
                        return dlg.SelectedValue;
                }
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

