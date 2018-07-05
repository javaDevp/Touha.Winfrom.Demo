using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace cn.touha.tools.lib.winform.contract
{
    interface IApplicationExceptionHandler
    {
        void UIThreadExceptionHandler(object sender, ThreadExceptionEventArgs e);

        void NonUIExceptionHandler(object sender, UnhandledExceptionEventArgs e);
    }
}
