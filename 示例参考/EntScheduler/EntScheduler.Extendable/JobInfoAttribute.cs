using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Doho.EntScheduler.Extendable
{
    [AttributeUsage(AttributeTargets.Class,AllowMultiple = false)]
    public class JobInfoAttribute : Attribute
    {
        /// <summary>
        /// 扩展任务属性
        /// </summary>
        /// <param name="AuthorName">作者名</param>
        /// <param name="AuthorUrl">作者Url</param>
        /// <param name="AuthorEmail">作者Email</param>
        /// <param name="JobName">任务名</param>
        /// <param name="JobDescription">任务描述</param>
        /// <param name="Version">版本</param>
        public JobInfoAttribute(string AuthorName, string AuthorUrl, string AuthorEmail,
            string JobName, string JobDescription, string Version)
        {
            this.AuthorName = AuthorName;
            this.AuthorUrl = AuthorUrl;
            this.AuthorEmail = AuthorEmail;
            this.JobName = JobName;
            this.JobDescription = JobDescription;
            this.Version = Version;
        }

        /// <summary>
        /// 作者名
        /// </summary>
        public string AuthorName { get; set; }

        /// <summary>
        /// 作者Url
        /// </summary>
        public string AuthorUrl { get; set; }

        /// <summary>
        /// 作者Email
        /// </summary>
        public string AuthorEmail { get; set; }

        /// <summary>
        /// 任务名
        /// </summary>
        public string JobName { get; set; }

        /// <summary>
        /// 任务描述
        /// </summary>
        public string JobDescription { get; set; }

        /// <summary>
        /// 版本
        /// </summary>
        public string Version { get; set; }

    }
}
