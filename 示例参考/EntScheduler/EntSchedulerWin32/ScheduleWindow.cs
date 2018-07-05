// Copyright (c) 黄桂超 重庆大学计算机学院 硕士研究生
// 更多信息请访问:http://www.cnblogs.com/Doho/
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Quartz;

namespace QuartzExampleWin32
{
    public partial class ScheduleWindow : ToolWindow, IUpdateUI
    {
        public ScheduleWindow()
        {
            InitializeComponent();
        }

        #region IUpdateUI Members

        public void UpdateUI()
        {
            if (SchedulerManager.GetScheduler() != null)
            {
                this.lblScheduleName.Text = SchedulerManager.GetScheduler().SchedulerName;
                this.lblScheduleID.Text = SchedulerManager.GetScheduler().SchedulerInstanceId;
                if (!SchedulerManager.GetScheduler().IsStarted)
                {
                    this.lblScheduleState.Text = "未启动";
                    this.btnShutDown.Enabled = false;
                    this.btnShutDownAndStopJob.Enabled = false;
                    this.btnStart.Enabled = true;
                }
                else if (!SchedulerManager.GetScheduler().IsShutdown)
                {
                    this.lblScheduleState.Text = "执行中";
                    this.btnShutDown.Enabled = true;
                    this.btnShutDownAndStopJob.Enabled = true;
                    this.btnStart.Enabled = false;
                }
                else
                {
                    this.lblScheduleState.Text = "已关闭";
                    this.btnShutDown.Enabled = false;
                    this.btnShutDownAndStopJob.Enabled = false;
                    this.btnStart.Enabled = true;
                }
            }
        }

        #endregion

        private void btnStart_Click(object sender, EventArgs e)
        {
            if (!SchedulerManager.GetScheduler().IsStarted)
            {
                SchedulerManager.GetScheduler().Start();
            }
        }

        private void btnShutDown_Click(object sender, EventArgs e)
        {
            if (SchedulerManager.GetScheduler().IsStarted)
            {
                SchedulerManager.GetScheduler().Shutdown(false);
            }
        }

        private void btnShutDownAndStopJob_Click(object sender, EventArgs e)
        {
            if (SchedulerManager.GetScheduler().IsStarted)
            {
                SchedulerManager.GetScheduler().Shutdown(true);
            }
        }
    }
}
