using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing.Design;
using System.ComponentModel;
using Kadr.Data;


namespace Kadr.UI.Editors
{
    [System.Security.Permissions.PermissionSet(System.Security.Permissions.SecurityAction.Demand, Name = "FullTrust")]
    public class PlanStaffEditor : System.Drawing.Design.UITypeEditor
    {
        public override object EditValue(ITypeDescriptorContext context, IServiceProvider provider, object value)
        {
            using (Common.ListSelectDialog<Kadr.Data.PlanStaff> dlg = new Kadr.UI.Common.ListSelectDialog<Kadr.Data.PlanStaff>())
            {
                dlg.Width += 400;
                dlg.Text = "Запись штатного расписания";
                dlg.QueryText = "Выберите запись штатного расписания";
                if (context.Instance is FactStaffReplacementDecorator)
                    dlg.DataSource = Kadr.Controllers.KadrController.Instance.Model.PlanStaffs.ToArray();
                else
                    dlg.DataSource = Kadr.Controllers.KadrController.Instance.Model.PlanStaffs.ToArray().Where(x => (x.DateEnd == null) || (x.DateEnd > DateTime.Today))/*.Where(x => (x.StaffCount > x.FactStaffCount))*/.ToArray().OrderBy(x => x.Dep.DepartmentName).ThenBy(x => x.Post.PostName).ToArray();
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

        /*public override System.Drawing.Design.UITypeEditorEditStyle GetEditStyle(System.ComponentModel.ITypeDescriptorContext context)
        {
            return UITypeEditorEditStyle.DropDown;
        }*/

        public override UITypeEditorEditStyle GetEditStyle(ITypeDescriptorContext context)
        {
            return UITypeEditorEditStyle.Modal;
        }
    }

}

