// Copyright (c) 黄桂超 重庆大学计算机学院 硕士研究生
// 更多信息请访问:http://www.cnblogs.com/Doho/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Quartz;

namespace Doho.EntScheduler.Extendable
{
    /// <summary>
    /// 扩展作业继承的接口,该接口继承 Quartz.IJob
    /// </summary>
    public interface IExtendedJob : IJob
    {
        /// <summary>
        /// 返回配置面板实例
        /// </summary>
        /// <returns></returns>
        UserControl GetConfigPanel();
    }
}
