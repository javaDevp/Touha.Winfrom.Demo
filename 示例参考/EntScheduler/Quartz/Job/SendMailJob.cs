/*
* Copyright 2004-2005 OpenSymphony 
* 
* Licensed under the Apache License, Version 2.0 (the "License"); you may not 
* use this file except in compliance with the License. You may obtain a copy 
* of the License at 
* 
*   http://www.apache.org/licenses/LICENSE-2.0 
*   
* Unless required by applicable law or agreed to in writing, software 
* distributed under the License is distributed on an "AS IS" BASIS, WITHOUT 
* WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied. See the 
* License for the specific language governing permissions and limitations 
* under the License.
* 
*/

/*
* Previously Copyright (c) 2001-2004 James House
*/

using System;
using System.Globalization;

using Common.Logging;

#if NET_20
using System.Net.Mail;
#else
using System.Web.Mail;
#endif

namespace Quartz.Job
{
	/// <summary>
	/// A Job which sends an e-mail with the configured content to the configured
	/// recipient.
	/// </summary>
	/// <author>James House</author>
	/// <author>Marko Lahma (.NET)</author>
	public class SendMailJob : IJob
	{
		private static readonly ILog Log = LogManager.GetLogger(typeof (SendMailJob));

        //stmp 主机
		public const string PropertySmtpHost = "smtp_host";

        //接收者地址
		public const string PropertyRecipient = "recipient";

		//复本，可选
		public const string PropertyCcRecipient = "cc_recipient";

        //发送者地址
		public const string PropertySender = "sender";

		//抄送地址，可选
		public const string PropertyReplyTo = "reply_to";

        //邮件主题
		public const string PropertySubject = "subject";

		//邮件内容
		public const string PropertyMessage = "message";

		/// <summary>
		/// Executes the job.
		/// </summary>
		/// <param name="context">The job execution context.</param>
		public virtual void Execute(JobExecutionContext context)
		{
			JobDataMap data = context.JobDetail.JobDataMap;

			string smtpHost = data.GetString(PropertySmtpHost);
			string to = data.GetString(PropertyRecipient);
			string cc = data.GetString(PropertyCcRecipient);
			string from = data.GetString(PropertySender);
			string replyTo = data.GetString(PropertyReplyTo);
			string subject = data.GetString(PropertySubject);
			string message = data.GetString(PropertyMessage);

			if (smtpHost == null || smtpHost.Trim().Length == 0)
			{
				throw new ArgumentException("PropertySmtpHost not specified.");
			}
			if (to == null || to.Trim().Length == 0)
			{
				throw new ArgumentException("PropertyRecipient not specified.");
			}
			if (from == null || from.Trim().Length == 0)
			{
				throw new ArgumentException("PropertySender not specified.");
			}
			if (subject == null || subject.Trim().Length == 0)
			{
				throw new ArgumentException("PropertySubject not specified.");
			}
			if (message == null || message.Trim().Length == 0)
			{
				throw new ArgumentException("PropertyMessage not specified.");
			}

			if (cc != null && cc.Trim().Length == 0)
			{
				cc = null;
			}

			if (replyTo != null && replyTo.Trim().Length == 0)
			{
				replyTo = null;
			}

			string mailDesc = string.Format(CultureInfo.InvariantCulture, "'{0}' to: {1}", subject, to);

			Log.Info(string.Format(CultureInfo.InvariantCulture, "Sending message {0}", mailDesc));

			try
			{
				SendMail(smtpHost, to, cc, from, replyTo, subject, message);
			}
			catch (Exception ex)
			{
				throw new JobExecutionException(string.Format(CultureInfo.InvariantCulture, "Unable to send mail: {0}", mailDesc), ex, false);
			}
		}


	    private void SendMail(string smtpHost, string to, string cc, string from, string replyTo, string subject,
		                      string message)
		{
            MailMessage mimeMessage = new MailMessage(from, to, subject, message);
	        if (!String.IsNullOrEmpty(cc))
	        {
	            mimeMessage.CC.Add(cc);
	        }
	        if (!String.IsNullOrEmpty(replyTo))
	        {
	            mimeMessage.ReplyTo = new MailAddress(replyTo);
	        }

	        Send(mimeMessage, smtpHost);
        }

	    protected virtual void Send(MailMessage mimeMessage, string smtpHost) 
        {
	        SmtpClient client = new SmtpClient(smtpHost);
	        client.Send(mimeMessage);
	    }
	}
}
