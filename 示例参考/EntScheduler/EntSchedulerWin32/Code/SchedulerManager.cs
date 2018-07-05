// Copyright (c) 黄桂超 重庆大学计算机学院 硕士研究生
// 更多信息请访问:http://www.cnblogs.com/Doho/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Quartz;
using Quartz.Impl;

namespace QuartzExampleWin32
{
    public static class SchedulerManager
    {
        private static IScheduler scheduler;
        private static readonly object lockObj = new object();
        private static readonly object lockObj1 = new object();
        private static ISchedulerFactory sf;

        public static ISchedulerFactory GetSchedulerFactory()
        {
            if (sf == null)
            {
                lock (lockObj1)
                {
                    if (sf == null)
                    {
                        sf = new StdSchedulerFactory();
                    }
                }
            }
            return sf;
        }
        public static IScheduler GetScheduler()
        {
            if (scheduler == null)
            {
                lock (lockObj)
                {
                    if (scheduler == null)
                    { 
                        //获取默认调度器
                        scheduler = GetSchedulerFactory().GetScheduler();
                    }
                }
            }
            return scheduler;
        }
    }
}
