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
using QuartzExampleWin32.Job;
using QuartzExampleWin32.Triggers;
using QuartzExampleWin32.Panels;
using Doho.EntScheduler.Extendable;

namespace QuartzExampleWin32
{
    public partial class JobWindow : WeifenLuo.WinFormsUI.Docking.DockContent, IUpdateUI
    {
        enum GuideStep
        {
            ChooseJob,
            ConfigJob,
            ConfigTrigger,
            OK
        }

        private GuideStep guideStep = GuideStep.ChooseJob;

        private JobsPanel JobsPanel = new JobsPanel();
        public UserControl JobConfigPanel
        {
            get
            {
                return JobsPanel.SelectedJobConfigPanel;
            }
        }

        private OKPanel oKPanel = new OKPanel();

        private DefaultTriggerPanel defaultTriggerPanel = new DefaultTriggerPanel();

        private Trigger trigger;

        private JobDetail jobDetail;

        public JobWindow()
        {
            InitializeComponent();

            pnlJob.Controls.Add(JobsPanel);
            JobsPanel.Dock = DockStyle.Fill;
        }

        #region IUpdateUI Members

        public void UpdateUI()
        {
            if (SchedulerManager.GetScheduler() != null)
            {
                lbJobRunning.Items.Clear();
                foreach (string group in SchedulerManager.GetScheduler().JobGroupNames)
                {
                    //lbJobRunning.Items.Add(group);

                    foreach (string job in SchedulerManager.GetScheduler().GetJobNames(group))
                    {
                        lbJobRunning.Items.Add("触发器组名:" + group + "\t触发器名:" + SchedulerManager.GetScheduler().GetJobDetail(job, group));
                    }
                }
            }
        }

        #endregion

        private void btnPre_Click(object sender, EventArgs e)
        {
            switch (guideStep)
            {
                case GuideStep.ChooseJob:
                    //btnPre.Enabled = false;
                    //btnNext.Enabled = true;
                    //break;
                case GuideStep.ConfigJob:
                    if (JobsPanel != null)
                    {
                        pnlJob.Controls.SetChildIndex(JobsPanel, 0);
                        guideStep = GuideStep.ChooseJob;

                        btnPre.Enabled = false;
                        btnNext.Enabled = true;
                    }
                    break;
                case GuideStep.ConfigTrigger:
                    if (JobConfigPanel != null)
                    {
                        pnlJob.Controls.SetChildIndex(JobConfigPanel, 0);
                        guideStep = GuideStep.ConfigJob;

                        btnPre.Enabled = true;
                        btnNext.Enabled = true;
                        //btnNext.Text = "下一步(&N)>";
                    }
                    break;
                case GuideStep.OK:
                    if (defaultTriggerPanel != null)
                    {
                        pnlJob.Controls.SetChildIndex(defaultTriggerPanel, 0);
                        guideStep = GuideStep.ConfigTrigger;

                        btnPre.Enabled = true;
                        btnNext.Enabled = true;
                        btnNext.Text = "下一步(&N)>";
                    }
                    break;
            }
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            switch (guideStep)
            {
                case GuideStep.ChooseJob:
                    if (JobConfigPanel != null)
                    {
                        if (!pnlJob.Controls.Contains(JobConfigPanel))
                        {
                            pnlJob.Controls.Add(JobConfigPanel);
                            JobConfigPanel.Dock = DockStyle.Fill;
                        }
                        pnlJob.Controls.SetChildIndex(JobConfigPanel, 0);

                        guideStep = GuideStep.ConfigJob;
                        btnPre.Enabled = true;
                        btnNext.Enabled = true;
                    }
                    break;
                case GuideStep.ConfigJob:
                    if (defaultTriggerPanel != null)
                    {
                        jobDetail = (JobConfigPanel as IJobConfigPanel).GetJobDetail();
                        if (jobDetail == null)
                        {
                            return;
                        }

                        foreach (string jobNames in SchedulerManager.GetScheduler().GetJobNames(jobDetail.Group))
                        {
                            if (jobNames == jobDetail.Name)
                            {

                                MessageBox.Show("任务组名、任务名不能同时重复，请修改");
                                return;
                                    
                            }
                        }

                        if (!pnlJob.Controls.Contains(defaultTriggerPanel))
                        {
                            pnlJob.Controls.Add(defaultTriggerPanel);
                            defaultTriggerPanel.Dock = DockStyle.Fill;
                        }
                        pnlJob.Controls.SetChildIndex(defaultTriggerPanel, 0);

                        guideStep = GuideStep.ConfigTrigger;
                        btnPre.Enabled = true;
                        btnNext.Enabled = true;
                    }
                    break;
                case GuideStep.ConfigTrigger:
                    if (!pnlJob.Controls.Contains(oKPanel))
                    {
                        pnlJob.Controls.Add(oKPanel);
                        oKPanel.Dock = DockStyle.Fill;
                    }
                    pnlJob.Controls.SetChildIndex(oKPanel, 0);

                    defaultTriggerPanel.JobName = jobDetail.Name;
                    defaultTriggerPanel.JobGroupName = jobDetail.Group;
                    trigger = defaultTriggerPanel.GetTrigger();

                    guideStep = GuideStep.OK;
                    btnPre.Enabled = true;
                    btnNext.Enabled = true;
                    btnNext.Text = "完成";
                    break;
                case GuideStep.OK:
                    AddJob();
                    btnPre.Enabled = true;
                    btnNext.Enabled = false;
                    btnAddNew.Visible = true;
                    break;
            }
        }

        private void AddJob()
        {
            if (jobDetail == null)
            {
                MessageBox.Show("任务不能为空!", "出错", MessageBoxButtons.OK);
                return;
            }
            if (trigger == null)
            {
                MessageBox.Show("触发器不能为空!", "出错", MessageBoxButtons.OK);
                return;
            }
            SchedulerManager.GetScheduler().ScheduleJob(jobDetail, trigger);
        }

        private void btnAddNew_Click(object sender, EventArgs e)
        {
            btnPre.Enabled = false;
            btnNext.Enabled = true;
            btnNext.Text = "下一步(&N)>";
            btnAddNew.Visible = false;

            pnlJob.Controls.SetChildIndex(JobsPanel, 0);

            guideStep = GuideStep.ChooseJob;
        }
    }
}
