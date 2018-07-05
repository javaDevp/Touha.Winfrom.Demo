// Copyright (c) 黄桂超 重庆大学计算机学院 硕士研究生
// 更多信息请访问:http://www.cnblogs.com/Doho/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;

using Quartz;
using System.IO;
using System.Windows.Forms;
using QuartzExampleWin32.Job;
using Common.Logging;
using Doho.EntScheduler.Extendable;

namespace Doho.QuartzExampleWin32.Job
{
    /// <summary>
    /// 关机任务类型
    /// </summary>
    public enum ShutdownJobType : short
    {
        /// <summary>
        /// 关机
        /// </summary>
        Shutdown,
        /// <summary>
        /// 休眠
        /// </summary>
        Hibernate,
        /// <summary>
        /// 待机
        /// </summary>
        StandBy,
        /// <summary>
        /// 注销
        /// </summary>
        Logoff
    }

    /// <summary>
    /// 关机任务
    /// </summary>
    [JobInfoAttribute("黄桂超", "http://www.cnblogs.com/Doho", "52doho@sina.com", "关机任务", "定时关机,休眠,注销", "V 0.1")]
    public class ShutdownJob : IExtendedJob
    {
        private UserControl configPanel;
        public static readonly string KeyShutdownJobType = "ShutdownJob";
        ILog log = LogManager.GetLogger(typeof(ShutdownJob));

        private ShutdownJobType shutdownJobType;

        public void Execute(JobExecutionContext context)
        {
            shutdownJobType = (ShutdownJobType)context.MergedJobDataMap.Get(KeyShutdownJobType);

            Process proc = new Process();
            switch (shutdownJobType)
            {
                case ShutdownJobType.Shutdown:
                    proc.EnableRaisingEvents = false;
                    proc.StartInfo.FileName = "shutdown";
                    proc.StartInfo.Arguments = "/s /f /t 0";
                    proc.Start();
                    break;
                case ShutdownJobType.Logoff:
                    proc.EnableRaisingEvents = false;
                    proc.StartInfo.FileName = "shutdown";
                    proc.StartInfo.Arguments = "/l";
                    proc.Start();
                    break;
                case ShutdownJobType.Hibernate:
                    if (File.Exists("C:\\hiberfil.sys") == true)
                    {
                        //激活休眼模式
                        Application.SetSuspendState(PowerState.Hibernate, true, true);
                    }
                    break;
                case ShutdownJobType.StandBy:
                    Application.SetSuspendState(PowerState.Suspend, true, true);
                    break;
                default:
                    break;
            }
            log.Info("关机任务已执行");
        }

        public override string ToString()
        {
            return "定时关机";
        }

        public UserControl GetConfigPanel()
        {
            if (configPanel == null)
                configPanel = new ShutdownJobConfigPanel();
            return configPanel;
        }
    }
}
