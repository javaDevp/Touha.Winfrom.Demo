// Copyright (c) �ƹ� �����ѧ�����ѧԺ ˶ʿ�о���
// ������Ϣ�����:http://www.cnblogs.com/Doho/

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
	/// ��ʱ�ʼ�
	/// </summary>
    [JobInfoAttribute("�ƹ�", "http://www.cnblogs.com/Doho", "52doho@sina.com", "��ʱ�ʼ�", "�������ڽڼ��ջ����������յ������,��ʱ�����ʼ�.", "V 0.1")]
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
                log.Info(string.Format("�ʼ����ͳɹ�!����:{0},������:{1},������:{2}", subject, fromStr, toStr));
            }
            catch (SmtpException exc)
            {
                log.Error("�ʼ�����ʧ��:", exc);
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

