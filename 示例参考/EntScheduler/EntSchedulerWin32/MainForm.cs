using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using WeifenLuo.WinFormsUI.Docking;
using Quartz.Impl;
using Quartz;

namespace QuartzExampleWin32
{
    public partial class mainForm : Form, IUpdateUI
    {
        private bool m_bSaveLayout = true;
        private LogWindow winLog = new LogWindow();
        private ErrorWindow winError = new ErrorWindow();
        private ScheduleWindow winSchedule = new ScheduleWindow();
        private JobWindow winJob = new JobWindow();

        private Timer updateTimer = new Timer();

        private DeserializeDockContent m_deserializeDockContent;

        //初始化调度器工厂
        private ISchedulerFactory sf;
        private IScheduler scheduler;

        public mainForm()
        {
            InitializeComponent();

            //绑定日志记录源
            QuartzLogger.LogWindow = winLog;
            QuartzLogger.ErrorWindow = winError;

            //
            m_deserializeDockContent = new DeserializeDockContent(GetContentFromPersistString);
            sf = SchedulerManager.GetSchedulerFactory();
            //获取默认调度器
            scheduler = SchedulerManager.GetScheduler();
            //打开
            scheduler.Start();
            //两秒钟更新一次
            updateTimer.Interval = 2000;
            updateTimer.Tick += new EventHandler(updateTimer_Tick);
            updateTimer.Start();
        }

        void updateTimer_Tick(object sender, EventArgs e)
        {
            this.UpdateUI();
            winLog.UpdateUI();
            winError.UpdateUI();
            winJob.UpdateUI();
            winSchedule.UpdateUI();
        }

        private void dockPanel_Paint(object sender, PaintEventArgs e)
        {

        }

        private void mainForm_Load(object sender, EventArgs e)
        {
            string configFile = Path.Combine(Path.GetDirectoryName(Application.ExecutablePath), "DockPanel.config");

            if (File.Exists(configFile))
                dockPanel.LoadFromXml(configFile, m_deserializeDockContent);
        }

        private void mainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            string configFile = Path.Combine(Path.GetDirectoryName(Application.ExecutablePath), "DockPanel.config");
            if (m_bSaveLayout)
                dockPanel.SaveAsXml(configFile);
            else if (File.Exists(configFile))
                File.Delete(configFile);

            //关闭
            updateTimer.Stop();
            SchedulerManager.GetScheduler().Shutdown(false);
            try
            {
                this.Close();
            }
            catch { }
        }

        private IDockContent GetContentFromPersistString(string persistString)
        {
            if (persistString == typeof(LogWindow).ToString())
                return winLog;
            else
            {
                return null;
            }
        }

        private void 调度器面板ToolStrip_Click(object sender, EventArgs e)
        {
            winSchedule.Show(this.dockPanel);
        }

        private void 异常面板ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            winError.Show(this.dockPanel);
        }

        private void 日志面板ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            winLog.Show(this.dockPanel);
        }

        private void 作业面板ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            winJob.Show(this.dockPanel);
        }

        private void toolStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            if (e.ClickedItem == toolStripSchedule)
                调度器面板ToolStrip_Click(null, null);
            else if (e.ClickedItem == toolStripError)
                异常面板ToolStripMenuItem_Click(null, null);
            else if (e.ClickedItem == toolStripLog)
                日志面板ToolStripMenuItem_Click(null, null);
            else if (e.ClickedItem == toolStripJob)
                作业面板ToolStripMenuItem_Click(null, null);
        }

        #region IUpdateUI Members

        public void UpdateUI()
        {
            
        }

        #endregion

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AboutForm about = new AboutForm();
            about.ShowDialog();
        }

        private void exitxToolStripMenuItem_Click(object sender, EventArgs e)
        {
            mainForm_FormClosing(null, null);
        }
    }
}
