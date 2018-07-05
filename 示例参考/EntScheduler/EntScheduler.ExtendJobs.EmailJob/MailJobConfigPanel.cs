using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Doho.EntScheduler.Extendable;
using Quartz;

namespace Doho.EntScheduler.ExtendJobs.EmailJob
{
    public partial class MailJobConfigPanel : JobConfigPanel, IJobConfigPanel
    {
        private Editor editor = new Editor();
        public MailJobConfigPanel()
        {
            InitializeComponent();

            pnlEditor.Controls.Add(editor);
            editor.Dock = DockStyle.Fill;

            txtSMTP.Text = EmailJobSettings.Default.SMTP;
            txtPort.Text = EmailJobSettings.Default.Port.ToString();
            txtUserName.Text = EmailJobSettings.Default.UserName;
            txtPwd.Text = EmailJobSettings.Default.Password;
            txtFrom.Text = EmailJobSettings.Default.From;
        }

        #region IJobConfigPanel Members

        public Quartz.JobDetail GetJobDetail()
        {
            if (txtJobName.Text == "" || txtJobGroupName.Text == "")
            {
                MessageBox.Show("任务名和任务组名必须填写!");
                return null;
            }

            JobDetail job = new JobDetail(txtJobName.Text, txtJobGroupName.Text, typeof(MailJob),
                cbVolatile.Checked, cbDurable.Checked, cbRequestsRecovery.Checked);
            job.JobDataMap.Put(MailJob.KeyBody, editor.BodyHtml);
            job.JobDataMap.Put(MailJob.KeyFrom, txtFrom.Text);
            job.JobDataMap.Put(MailJob.KeyPassword, txtPwd.Text);
            job.JobDataMap.Put(MailJob.KeyPort, txtPort.Text);
            job.JobDataMap.Put(MailJob.KeySMTP, txtSMTP.Text);
            job.JobDataMap.Put(MailJob.KeyTitle, txtTitle.Text);
            job.JobDataMap.Put(MailJob.KeyTo, txtTo.Text);
            job.JobDataMap.Put(MailJob.KeyUserName, txtUserName.Text);

            SaveConfig();
            return job;
        }

        private void SaveConfig()
        {
            EmailJobSettings.Default.SMTP = txtSMTP.Text;
            EmailJobSettings.Default.Port = int.Parse(txtPort.Text);
            EmailJobSettings.Default.UserName = txtUserName.Text;
            EmailJobSettings.Default.Password = txtPwd.Text;
            EmailJobSettings.Default.From = txtFrom.Text;

            EmailJobSettings.Default.Save();
        }

        #endregion
    }
}
