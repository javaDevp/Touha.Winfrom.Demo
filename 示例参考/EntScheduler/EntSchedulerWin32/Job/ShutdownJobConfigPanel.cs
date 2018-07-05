// Copyright (c) 黄桂超 重庆大学计算机学院 硕士研究生
// 更多信息请访问:http://www.cnblogs.com/Doho/
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Doho.QuartzExampleWin32.Job;
using Quartz;
using Doho.EntScheduler.Extendable;

namespace QuartzExampleWin32.Job
{
    public partial class ShutdownJobConfigPanel : UserControl, IJobConfigPanel
    {
        private ShutdownJobType ShutdownJobType
        {
            get
            {
                switch (cbShutdown.SelectedText)
                {
                    default:
                    case "关机":
                        return ShutdownJobType.Shutdown;
                    case "注销":
                        return ShutdownJobType.Logoff;
                    case "待机":
                        return ShutdownJobType.StandBy;
                    case "休眠":
                        return ShutdownJobType.Hibernate;
                }
            }
        }

        //private JobDetail jobDetail;
        public JobDetail GetJobDetail()
        {
            if (txtJobName.Text == "" || txtJobGroupName.Text == "")
            {
                MessageBox.Show("任务名和任务组名必须填写!");
                return null;
            }

            JobDetail job = new JobDetail(txtJobName.Text, txtJobGroupName.Text, typeof(ShutdownJob), 
                cbVolatile.Checked, cbDurable.Checked, cbRequestsRecovery.Checked);
            job.JobDataMap.Put(ShutdownJob.KeyShutdownJobType, ShutdownJobType);

            return job;
        }

        public ShutdownJobConfigPanel()
        {
            InitializeComponent();

            cbShutdown.SelectedIndex = 0;
        }

        #region IJob Members

        public void Execute(JobExecutionContext context)
        {
            
        }

        #endregion

        //#region IJobConfigPanel Members

        //JobDetail IJobConfigPanel.GetJobDetail()
        //{
        //    throw new NotImplementedException();
        //}

        //#endregion
    }
}
