// Copyright (c) 2009 黄桂超 重庆大学计算机学院 硕士研究生
// 更多信息请访问:http://www.cnblogs.com/Doho/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;
using System.Xml;
using System.IO;
using System.Windows.Forms;
using Common.Logging;
using Doho.EntScheduler.Extendable;

namespace QuartzExampleWin32
{
    public class JobManager
    {
        private List<JobInfoEntity> jobs = new List<JobInfoEntity>();
        private static JobManager jobManager;
        private static readonly object lockObj = new object();
        private XmlDocument doc;
        private ILog log = LogManager.GetLogger(typeof(JobManager));
        private string configFile = AppDomain.CurrentDomain.BaseDirectory + "EntScheduler.config";

        private JobManager() 
        {
            try
            {
                //载入
                doc = new XmlDocument();
                doc.Load(configFile);

                var jobNodes = doc.SelectNodes("EntScheduler/JobPlugins/Job");
                //读取 JobPlugins
                foreach (XmlNode job in jobNodes)
                {
                    string fileDir = job.Attributes["fileDir"].Value;
                    if (!File.Exists(fileDir))
                    {
                        //log.Error(string.Format("文件:{0} 不存在!",fileDir));
                        break;
                    }

                    //载入程序集
                    Assembly asm = Assembly.LoadFile(fileDir);
                    foreach (Type type in asm.GetTypes())
                    {
                        if (type.GetInterface("Doho.EntScheduler.Extendable.IExtendedJob") != null)
                        {
                            JobInfoEntity entity = new JobInfoEntity(job.Attributes["authorName"].Value, job.Attributes["authorUrl"].Value, 
                                job.Attributes["authorEmail"].Value, job.Attributes["jobName"].Value, job.Attributes["jobDescription"].Value, job.Attributes["version"].Value, type);
                            if (!jobs.Contains(entity))
                            {
                                jobs.Add(entity);
                            }
                        }
                    }
                }
            }
            catch
            {
            }
        }

        public static JobManager Instance
        {
            get
            {
                if (jobManager == null)
                {
                    lock (lockObj)
                    {
                        if (jobManager == null)
                        {
                            jobManager = new JobManager();
                        }
                    }
                }
                return jobManager;
            }
        }

        //public void AddJob(JobInfoEntity job)
        //{
        //    if (!jobs.Contains(job))
        //        jobs.Add(job);
        //}

        public void AddJob(string jobFile)
        {
            if (!File.Exists(jobFile))
            {
                string msg = string.Format("文件:{0} 不存在!", jobFile);
                log.Error(msg);
                MessageBox.Show(msg, "添加任务扩展", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            bool isExtendFromIExtendedJob = false;

            //载入程序集
            Assembly asm = Assembly.LoadFile(jobFile);
            foreach (Type type in asm.GetTypes())
            {
                if (type.GetInterface("Doho.EntScheduler.Extendable.IExtendedJob") != null)
                {
                    isExtendFromIExtendedJob = true;
                    //获取扩展信息
                    foreach (var p in type.GetCustomAttributes(typeof(JobInfoAttribute), false))
                    {
                        JobInfoAttribute att = p as JobInfoAttribute;
                        JobInfoEntity job = new JobInfoEntity(att.AuthorName, att.AuthorUrl, att.AuthorEmail, att.JobName, 
                            att.JobDescription, att.Version, type);
                        
                        if (!jobs.Contains(job))
                        {
                            jobs.Add(job);
                            //保存到配置文件
                            if (doc == null)
                            {
                                doc = new XmlDocument();
                                doc.Load(configFile);
                            }

                            XmlNode jobPluginsRoot = doc.SelectSingleNode("EntScheduler/JobPlugins");
                            XmlElement newJobNode = doc.CreateElement("Job");
                            newJobNode.SetAttribute("fileDir",jobFile);
                            newJobNode.SetAttribute("authorName",att.AuthorName);
                            newJobNode.SetAttribute("authorUrl",att.AuthorUrl);
                            newJobNode.SetAttribute("authorEmail",att.AuthorEmail);
                            newJobNode.SetAttribute("jobName",att.JobName);
                            newJobNode.SetAttribute("jobDescription",att.JobDescription);
                            newJobNode.SetAttribute("version",att.Version);

                            jobPluginsRoot.AppendChild(newJobNode);

                            doc.Save(configFile);
                        }
                    }
                }
            }

            if (!isExtendFromIExtendedJob)
            {
                string msg = string.Format("扩展必须继承:Doho.EntScheduler.Extendable.IExtendedJob", jobFile);
                log.Error(msg);
                MessageBox.Show(msg, "添加任务扩展", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void RemoveJob(JobInfoEntity job)
        {
            if (jobs.Contains(job))
                jobs.Remove(job);
        }

        public List<JobInfoEntity> GetAllJobs()
        {
            return jobs;
        }
    }
}
