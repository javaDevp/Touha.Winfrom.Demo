// Copyright (c) 黄桂超 重庆大学计算机学院 硕士研究生
// 更多信息请访问:http://www.cnblogs.com/Doho/

using System;
using System.Net.Mail;
using System.Text;
using System.Net;
using Doho.EntScheduler.Extendable;
using Quartz;
using Common.Logging;
using System.Windows.Forms;
using Doho.EntScheduler.ExtendJobs.EmailJob;

namespace Doho.EntScheduler.ExtendJobs.EmailJob
{
	/// <summary>
	/// 定时邮件
	/// </summary>
    [JobInfoAttribute("黄桂超", "http://www.cnblogs.com/Doho", "52doho@sina.com", "定时邮件", "您可以在节假日或者朋友生日等情况下,定时发送邮件.", "V 0.1")]
    public class MailJob : IExtendedJob
	{
        private UserControl configPanel;
        public static readonly string KeySMTP = "SMTP";
        public static readonly string KeyPort = "Port";
        public static readonly string KeyUserName = "UserName";
        public static readonly string KeyPassword = "Password";
        public static readonly string KeyFrom = "From";
        public static readonly string KeyTo = "To";
        public static readonly string KeyTitle = "Title";
        public static readonly string KeyBody = "Body";

        ILog log = LogManager.GetLogger(typeof(MailJob));

        public void Execute(JobExecutionContext context)
        {
            string smtp = context.MergedJobDataMap.Get(KeySMTP).ToString();
            string port = context.MergedJobDataMap.Get(KeyPort).ToString();
            string userName = context.MergedJobDataMap.Get(KeyUserName).ToString();
            string pwd = context.MergedJobDataMap.Get(KeyPassword).ToString();
            string toStr = context.MergedJobDataMap.Get(KeyTo).ToString();
            string fromStr = context.MergedJobDataMap.Get(KeyFrom).ToString();
            string subject = context.MergedJobDataMap.Get(KeyTitle).ToString();
            string message = context.MergedJobDataMap.Get(KeyBody).ToString();

            try
            {
                MailAddress from = new MailAddress(fromStr);
                MailAddress to = new MailAddress(toStr);

                MailMessage em = new MailMessage(from, to);
                em.BodyEncoding = Encoding.UTF8;
                em.Subject = subject;
                em.Body = message;
                em.IsBodyHtml = true;

                SmtpClient client = new SmtpClient(smtp);
                client.Port = int.Parse(port);

                if (userName != null && pwd != null)
                {
                    client.UseDefaultCredentials = false;
                    client.Credentials = new NetworkCredential(userName, pwd);
                }

                client.Send(em);
                log.Info(string.Format("邮件发送成功!标题:{0},发信人:{1},收信人:{2}", subject, fromStr, toStr));
            }
            catch (SmtpException exc)
            {
                log.Error("邮件发送失败:", exc);
            }
        }

        #region IExtendedJob Members

        public UserControl GetConfigPanel()
        {
            if (configPanel == null)
                configPanel = new MailJobConfigPanel();
            return configPanel;
        }

        #endregion
    }
}

