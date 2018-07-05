using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Touha.Tool.UI
{
    static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.ThreadException += ThreadExceptionHandle;
            AppDomain.CurrentDomain.UnhandledException += UnhandledExceptionHandle;
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }

        private static void UnhandledExceptionHandle(object sender, UnhandledExceptionEventArgs e)
        {
            MessageBox.Show("UnhandledExceptionHandle" + e.ToString());
        }

        private static void ThreadExceptionHandle(object sender, ThreadExceptionEventArgs e)
        {
            MessageBox.Show("ThreadExceptionHandle" + e.ToString());
        }
    }
}
