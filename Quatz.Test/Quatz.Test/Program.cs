using Quartz;
using Quartz.Impl;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quatz.Test
{
    class Program
    {
        static void Main(string[] args)
        {
            //construct a scheduler factory
            ISchedulerFactory schedulerFactory = new StdSchedulerFactory();

            //get a scheduler
            IScheduler scheduler = schedulerFactory.GetScheduler();
            scheduler.Start();

            // define the job and tie it to our HelloJob class
            IJobDetail job = JobBuilder.Create<MyJob>()
                .WithIdentity("myJob", "group1")
                .Build();

            // Trigger the job to run now, and then every 40 seconds
            ITrigger trigger = TriggerBuilder.Create()
              .WithIdentity("myTrigger", "group1")
              .StartNow()
              .WithSimpleSchedule(x => x
                  .WithIntervalInSeconds(10)
                  .RepeatForever())
              .Build();

            scheduler.ScheduleJob(job, trigger);

            Console.ReadKey();
        }
    }
}
