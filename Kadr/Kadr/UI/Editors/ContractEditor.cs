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

            /*if ((currentEmployee == null) || (currentEmployee.IsNull()))
            {
                throw new ArgumentNullException("Cотрудник.");
                return null;
            }*/

            using (ContractSelectionDialog dlg = new ContractSelectionDialog())
            {

                dlg.Text = "Договор";
                dlg.Employee = currentEmployee;
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



