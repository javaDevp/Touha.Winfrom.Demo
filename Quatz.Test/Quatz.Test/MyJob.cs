using Quartz;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quatz.Test
{
    public class MyJob : IJob
    {
        //private static ILog _log = LogManager.GetLogger(typeof(MyJob));

        public void Execute(IJobExecutionContext context)
        {
            Console.WriteLine(DateTime.Now);
        }
    }
}
