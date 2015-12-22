using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing.Design;
using System.ComponentModel;
using Kadr.UI.Dialogs;
using Kadr.Data;
using Kadr.Interfaces;
using Kadr.Data.Common;

namespace Kadr.UI.Editors
{
    [System.Security.Permissions.PermissionSet(System.Security.Permissions.SecurityAction.Demand, Name = "FullTrust")]
    public class ContractEditor : System.Drawing.Design.UITypeEditor
    {

        public override object EditValue(ITypeDescriptorContext context, IServiceProvider provider, object value)
        {
            Employee currentEmployee = null;
            Contract currentContract = null;
            
            if (context.Instance is FactStaffMainBaseDecorator)
            {
                currentEmployee = (context.Instance as FactStaffMainBaseDecorator).Employee;
                currentContract = (context.Instance as FactStaffMainBaseDecorator).CurrentContract;
            }

            if (context.Instance is FactStaffHistoryMinDecorator)
            {
                currentEmployee = (context.Instance as FactStaffHistoryMinDecorator).FactStaff.Employee;
                currentContract = (context.Instance as FactStaffHistoryMinDecorator).CurrentContract;
            }

            using (ContractSelectionDialog dlg = new ContractSelectionDialog())
            {

                dlg.Text = "Договор";
                dlg.Employee = currentEmployee;
                dlg.DialogObject = currentContract.MainContract;

                if (dlg.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                    return dlg.DialogObject;
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



