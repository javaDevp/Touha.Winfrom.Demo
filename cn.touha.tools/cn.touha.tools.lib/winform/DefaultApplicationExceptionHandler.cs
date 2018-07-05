using cn.touha.tools.lib.winform.contract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Windows.Forms;
using System.Diagnostics;

namespace cn.touha.tools.lib.winform
{
    public class DefaultApplicationExceptionHandler : IApplicationExceptionHandler
    {
        public void NonUIExceptionHandler(object sender, UnhandledExceptionEventArgs e)
        {
            try
            {
                Exception ex = e.ExceptionObject as Exception;
                Debug.WriteLine(ex.StackTrace);
            }catch(Exception ex)
            {

            }
        }

        public void UIThreadExceptionHandler(object sender, ThreadExceptionEventArgs e)
        {
            try
            {
                Exception ex = e.Exception;
                Debug.WriteLine(ex.StackTrace);
            }
            catch(Exception ex)
            {

            }
        }
    }
}
