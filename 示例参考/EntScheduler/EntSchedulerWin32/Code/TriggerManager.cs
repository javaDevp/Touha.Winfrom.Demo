// Copyright (c) 2009 黄桂超 重庆大学计算机学院 硕士研究生
// 更多信息请访问:http://www.cnblogs.com/Doho/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Common.Logging;

namespace QuartzExampleWin32
{
    public class TriggerManager
    {
        private static readonly object lockObj = new object();
        private ILog log = LogManager.GetLogger(typeof(JobManager));
        private static TriggerManager triggerManager;

        private TriggerManager() 
        {

        }

        public static TriggerManager Instance
        {
            get
            {
                if (triggerManager == null)
                {
                    lock (lockObj)
                    {
                        if (triggerManager == null)
                        {
                            triggerManager = new TriggerManager();
                        }
                    }
                }
                return triggerManager;
            }
        }
    }
}
