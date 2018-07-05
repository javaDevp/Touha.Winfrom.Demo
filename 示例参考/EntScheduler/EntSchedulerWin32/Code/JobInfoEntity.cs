// Copyright (c) 2009 黄桂超 重庆大学计算机学院 硕士研究生
// 更多信息请访问:http://www.cnblogs.com/Doho/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace QuartzExampleWin32
{
    /// <summary>
    /// 扩展任务实体
    /// </summary>
    public class JobInfoEntity
    {
        /// <summary>
        /// 扩展任务实体
        /// </summary>
        /// <param name="AuthorName">作者名</param>
        /// <param name="AuthorUrl">作者Url</param>
        /// <param name="AuthorEmail">作者Email</param>
        /// <param name="JobName">任务名</param>
        /// <param name="JobDescription">任务描述</param>
        /// <param name="Version">版本</param>
        public JobInfoEntity(string AuthorName, string AuthorUrl, string AuthorEmail,
            string JobName, string JobDescription, string Version, Type JobType)
        {
            this.AuthorName = AuthorName;
            this.AuthorUrl = AuthorUrl;
            this.AuthorEmail = AuthorEmail;
            this.JobName = JobName;
            this.JobDescription = JobDescription;
            this.Version = Version;
            this.jobType = JobType;
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

        private Type jobType;

        public Type GetJobType()
        {
            return jobType;
        }
    }
}
