using cn.touha.tools.lib.winform.contract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace cn.touha.tools.lib.winform
{
    public class ApplicationHelper
    {
        private static IApplicationExceptionHandler exceptionHandler;
        public static void InitExceptionHandler()
        {
            // Set the unhandled exception mode to force all Windows Forms errors to go through our handler.
            Application.SetUnhandledExceptionMode(UnhandledExceptionMode.CatchException);
            if (exceptionHandler == null)
                exceptionHandler = new DefaultApplicationExceptionHandler();
            // Add the event handler for handling UI thread exceptions to the event.
            Application.ThreadException += exceptionHandler.UIThreadExceptionHandler;
            // Add the event handler for handling non-UI thread exceptions to the event. 
            AppDomain.CurrentDomain.UnhandledException += exceptionHandler.NonUIExceptionHandler;
        }
    }
}
