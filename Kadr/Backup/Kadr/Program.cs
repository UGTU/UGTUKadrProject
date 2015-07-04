using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace Kadr
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.ThreadException += new System.Threading.ThreadExceptionEventHandler(Application_ThreadException);
            Application.Run(new Kadr.UI.Forms.KadrBaseForm());
        }

        static void Application_ThreadException(object sender, System.Threading.ThreadExceptionEventArgs e)
        {
            APG.CodeHelper.ExceptionHandler.ExceptionHandler.HandleApplicationException(sender, e.Exception);
        }
    }
}
