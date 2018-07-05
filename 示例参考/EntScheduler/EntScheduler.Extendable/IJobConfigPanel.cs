// Copyright (c) 黄桂超 重庆大学计算机学院 硕士研究生
// 更多信息请访问:http://www.cnblogs.com/Doho/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Quartz;

namespace Doho.EntScheduler.Extendable
{
    /// <summary>
    /// 配置面板继承的接口
    /// </summary>
    public interface IJobConfigPanel 
    {
        /// <summary>
        /// 返回配置的作业信息:JobDetail
        /// </summary>
        /// <returns></returns>
        JobDetail GetJobDetail();
    }
}
