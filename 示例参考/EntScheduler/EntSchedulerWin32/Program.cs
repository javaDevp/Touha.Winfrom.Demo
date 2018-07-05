using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace QuartzExampleWin32
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
            mainForm form = new mainForm();
            Application.Run(form);

            Application.ThreadException += new System.Threading.ThreadExceptionEventHandler(Application_ThreadException);
        }

        static void Application_ThreadException(object sender, System.Threading.ThreadExceptionEventArgs e)
        {
            string str = "异常信息:" + e.Exception.Message + Environment.NewLine 
                + "堆栈:" + e.Exception.StackTrace;
            MessageBox.Show(str, "应用程序出错");
        }
    }
}
