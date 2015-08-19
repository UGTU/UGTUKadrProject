using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Kadr.Controllers
{
    static class SimpleActionsProvider
    {
        public static Kadr.UI.Common.PropertyGridDialogAdding<T> NewSimpleObjectAddingDialog<T>() where T : class, new() 
        {
            Kadr.UI.Common.PropertyGridDialogAdding<T> dlg =
               new Kadr.UI.Common.PropertyGridDialogAdding<T>();

                dlg.ObjectList = KadrController.Instance.Model.GetTable<T>();

                // Do we need that? Why?
                // dlg.BindingSource = employeeStandingBindingSource;

                dlg.UseInternalCommandManager = true;
                dlg.UpdateObjectList = () =>
                {
                    dlg.ObjectList = KadrController.Instance.Model.GetTable<T>();
                };

                return dlg;
            }
        }
    }

