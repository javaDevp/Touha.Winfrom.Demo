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
using Quartz;

namespace QuartzExampleWin32.Triggers
{
    public partial class DefaultTriggerPanel : UserControl, IUpdateUI
    {
        public DefaultTriggerPanel()
        {
            InitializeComponent();

            cbWeekNth.SelectedIndex = 0;
            cbWeekNDay.SelectedIndex = 0;
        }

        public string JobName
        {
            get;
            set;
        }

        public string JobGroupName
        {
            get;
            set;
        }

        private DateTime GetStartDateTime()
        {
            //开始日期
            int iStartYear = dateTimeStartDate.Value.Year;
            int iStartMonth = dateTimeStartDate.Value.Month;
            int iStartDay = dateTimeStartDate.Value.Day;
            int iStartHour = Convert.ToInt32(startHour.Value);
            int iStartMinute = Convert.ToInt32(startMinute.Value);
            int iStartSecond = Convert.ToInt32(startSecond.Value);
            return new DateTime(iStartYear, iStartMonth, iStartDay, iStartHour, iStartMinute, iStartSecond);
        }

        private DateTime? GetEndDateTime()
        {
            //结束日期
            if (cbEndDatetime.Checked)
            {
                int iEndYear = dateTimeEndDate.Value.Year;
                int iEndMonth = dateTimeEndDate.Value.Month;
                int iEndDay = dateTimeEndDate.Value.Day;
                int iEndHour = Convert.ToInt32(startHour.Value);
                int iEndMinute = Convert.ToInt32(startMinute.Value);
                int iEndSecond = Convert.ToInt32(startSecond.Value);
                return new DateTime(iEndYear, iEndMonth, iEndDay, iEndHour, iEndMinute, iEndSecond);
            }
            else
                return null;
        }

        //触发小时
        private string GetTrigHour()
        {
            return dayStartHour.Value.ToString();
        }
        //触发分钟
        private string GetTrigMinute()
        {
            return dayStartMinute.Value.ToString();
        }
        //触发秒
        private string GetTrigSecond()
        {
            return dayStartSecond.Value.ToString();
        }

        public Trigger GetTrigger()
        {
            //TODO:先判断触发器\组名是不是重复
            if (SchedulerManager.GetScheduler() != null)
            {
                foreach (string groupName in SchedulerManager.GetScheduler().TriggerGroupNames)
                {
                    if (groupName == txtTriggerGroup.Text)
                    {
                        foreach (string triggerName in SchedulerManager.GetScheduler().GetTriggerNames(groupName))
                        {
                            if (triggerName == txtTriggerName.Text)
                            {
                                MessageBox.Show("触发器组名、触发器名不能同时重复，请修改");
                                tabControl.SelectedTab = tabPageSelection;
                                return null;
                            }
                        }
                    }
                }
            }

            switch (tabControl.SelectedIndex)
            {
                //现有触发器
                case 1:
                    return GetTriggerAvailable();
                //每天
                default:
                case 2:
                    return GetTriggerEveryDay();
                //每周
                case 3:
                    return GetTriggerEveryWeek();
                //每月
                case 4:
                    return GetTriggerEveryMonth();
                //每年
                case 5:
                    return GetTriggerEveryYear();
                //农历
                case 6:
                    return GetTriggerTraditionalHoliday();
                //国际节假日
                case 7:
                    return GetTriggerInterHoliday();
                //高级
                case 8:
                    return GetTriggerAdvance();
            }
        }

        /// <summary>
        /// 从已有的触发器选择
        /// </summary>
        /// <returns></returns>
        private Trigger GetTriggerAvailable()
        {
            if (lbTriggersAvailable.SelectedIndex > -1)
            {
                TriggerAndGroup triggerAndGroup = lbTriggersAvailable.SelectedItem as TriggerAndGroup;
                return SchedulerManager.GetScheduler().GetTrigger(triggerAndGroup.TriggerName, triggerAndGroup.GroupName);
            }
            else
            {
                MessageBox.Show("请选择现有的触发器,如果没有请添加");
                return null;
            }
        }
        /// <summary>
        /// 按每天
        /// </summary>
        /// <returns></returns>
        private Trigger GetTriggerEveryDay()
        {
            //TODO:检验规则是否合法

            Trigger trigger = new CronTrigger();

            double dblStartNDay = Convert.ToDouble(nDay.Value);

            if (cbEndDatetime.Checked)
            {
                if (rbtEveryDay.Checked)
                {
                    string cronExpression = string.Format("{0} {1} {2} ? * *", GetTrigSecond(), GetTrigMinute(), GetTrigHour());
                    trigger = new CronTrigger(txtTriggerName.Text, txtTriggerGroup.Text, JobName, JobGroupName, GetStartDateTime(), GetEndDateTime(), cronExpression);
                }
                if (rbtEveryWeekDay.Checked)
                {
                    string cronExpression = string.Format("{0} {1} {2} ? * {3}", GetTrigSecond(), GetTrigMinute(), GetTrigHour(), "MON-FRI");
                    trigger = new CronTrigger(txtTriggerName.Text, txtTriggerGroup.Text, JobName, JobGroupName, GetStartDateTime(), GetEndDateTime(), cronExpression);
                }
                if (rbtEveryWeekend.Checked)
                {
                    string cronExpression = string.Format("{0} {1} {2} ? * {3}", GetTrigSecond(), GetTrigMinute(), GetTrigHour(), "SAT-SUN");
                    trigger = new CronTrigger(txtTriggerName.Text, txtTriggerGroup.Text, JobName, JobGroupName, GetStartDateTime(), GetEndDateTime(), cronExpression);
                }
                if (rbtEveryNDay.Checked)
                {
                    //string cronExpression = string.Format("{0} {1} {2} {3} * ?", GetTrigHour(), GetTrigMinute(), GetTrigSecond(), strStartNDay);
                    //trigger = new CronTrigger(txtTriggerName.Text, txtTriggerGroup.Text, JobName, JobGroupName, GetStartDateTime(), GetEndDateTime(), cronExpression);
                    //SimpleTrigger
                    trigger = new SimpleTrigger(txtTriggerName.Text, txtTriggerGroup.Text, JobName, JobGroupName, GetStartDateTime(), GetEndDateTime(), 0, TimeSpan.FromDays(dblStartNDay));
                }
                return trigger;
            }
            else
            {
                if (rbtEveryDay.Checked)
                {
                    string cronExpression = string.Format("{0} {1} {2} ? * *", GetTrigSecond(), GetTrigMinute(), GetTrigHour());
                    trigger = new CronTrigger(txtTriggerName.Text, txtTriggerGroup.Text, JobName, JobGroupName, GetStartDateTime(), null, cronExpression);
                }
                if (rbtEveryWeekDay.Checked)
                {
                    string cronExpression = string.Format("{0} {1} {2} ? * {3}", GetTrigSecond(), GetTrigMinute(), GetTrigHour(), "MON-FRI");
                    trigger = new CronTrigger(txtTriggerName.Text, txtTriggerGroup.Text, JobName, JobGroupName, GetStartDateTime(), null, cronExpression);
                }
                if (rbtEveryWeekend.Checked)
                {
                    string cronExpression = string.Format("{0} {1} {2} ? * {3}", GetTrigSecond(), GetTrigMinute(), GetTrigHour(), "SAT-SUN");
                    trigger = new CronTrigger(txtTriggerName.Text, txtTriggerGroup.Text, JobName, JobGroupName, GetStartDateTime(), null, cronExpression);
                }
                if (rbtEveryNDay.Checked)
                {
                    trigger = new SimpleTrigger(txtTriggerName.Text, txtTriggerGroup.Text, JobName, JobGroupName, GetStartDateTime(), null, 0, TimeSpan.FromDays(dblStartNDay));
                }
                return trigger;
            }
        }
        /// <summary>
        /// 按每周
        /// </summary>
        /// <returns></returns>
        private Trigger GetTriggerEveryWeek()
        {
            string week = "";
            if (cbWeekMon.Checked)
                week += "1,";
            if (cbWeekTue.Checked)
                week += "2,";
            if (cbWeekWen.Checked)
                week += "3,";
            if (cbWeekThu.Checked)
                week += "4,";
            if (cbWeekFri.Checked)
                week += "5,";
            if (cbWeekSat.Checked)
                week += "6,";
            if (cbWeekSun.Checked)
                week += "7";
            week = week.TrimEnd(',');

            string cronExpression = string.Format("{0} {1} {2} ? * {3}", GetTrigSecond(), GetTrigMinute(), GetTrigHour(), week);
            Trigger trigger = new CronTrigger(txtTriggerName.Text, txtTriggerGroup.Text, JobName, JobGroupName, GetStartDateTime(), GetEndDateTime(), cronExpression);
            return trigger;
        }
        /// <summary>
        /// 按每月
        /// </summary>
        /// <returns></returns>
        private Trigger GetTriggerEveryMonth()
        {
            string month = "";
            if (cbMonthJan.Checked)
                month += "1,";
            if (cbMonthFeb.Checked)
                month += "2,";
            if (cbMonthMar.Checked)
                month += "3,";
            if (cbMonthApe.Checked)
                month += "4,";
            if (cbMonthMay.Checked)
                month += "5,";
            if (cbMonthJune.Checked)
                month += "6,";
            if (cbMonthJuly.Checked)
                month += "7,";
            if (cbMonthAug.Checked)
                month += "8,";
            if (cbMonthSep.Checked)
                month += "9,";
            if (cbMonthOte.Checked)
                month += "10,";
            if (cbMonthNov.Checked)
                month += "11,";
            if (cbMonthDec.Checked)
                month += "12";

            if (month == "")
                month = "*";

            if (rbtWeekByWeek.Checked)
            {
                string strNth = "";
                switch (cbWeekNth.SelectedIndex)
                {
                    case 0:
                        strNth = "#1";
                        break;
                    case 1:
                        strNth = "#2";
                        break;
                    case 2:
                        strNth = "#3";
                        break;
                    case 3:
                        strNth = "#4";
                        break;
                    case 4:
                        strNth = "L";
                        break;
                }

                switch (cbWeekNDay.SelectedIndex)
                {
                    case 0:
                        strNth = "2" + strNth;
                        break;
                    case 1:
                        strNth = "3" + strNth;
                        break;
                    case 2:
                        strNth = "4" + strNth;
                        break;
                    case 3:
                        strNth = "5" + strNth;
                        break;
                    case 4:
                        strNth = "6" + strNth;
                        break;
                    case 5:
                        strNth = "7" + strNth;
                        break;
                    case 6:
                        strNth = "1" + strNth;
                        break;
                }

                string cronExpression = string.Format("{0} {1} {2} ? {3} {4}", GetTrigSecond(), GetTrigMinute(), GetTrigHour(), month, strNth);
                Trigger trigger = new CronTrigger(txtTriggerName.Text, txtTriggerGroup.Text, JobName, JobGroupName, GetStartDateTime(), GetEndDateTime(), cronExpression);
                return trigger;
            }
            else
            {
                string strNDay = nWeekDay.Value.ToString();
                string cronExpression = string.Format("{0} {1} {2} {3} {4} ?", GetTrigSecond(), GetTrigMinute(), GetTrigHour(), strNDay, month);
                Trigger trigger = new CronTrigger(txtTriggerName.Text, txtTriggerGroup.Text, JobName, JobGroupName, GetStartDateTime(), GetEndDateTime(), cronExpression);
                return trigger;
            }

        }

        private Trigger GetTriggerEveryYear()
        {
            MessageBox.Show("尚未实现");
            return null;
        }

        private Trigger GetTriggerTraditionalHoliday()
        {
            MessageBox.Show("尚未实现");
            return null;
        }

        private string GetInterHolidayPreCronExpression(out bool hasPre)
        {
            string preCronExpression = "";
            int hour = Convert.ToInt32(nForwardHour.Value);
            int minute = Convert.ToInt32(nForwardMinute.Value);
            int second = Convert.ToInt32(nForwardSecond.Value);

            int c = 24 * 60 * 60 - hour * 60 * 60 - minute * 60 - second;
            second = c % 60;
            minute = (Convert.ToInt32(c / 60)) % 60;
            hour = Convert.ToInt32(c / 3600);

            if (second > 0 || minute > 0 || hour < 24)
                hasPre = true;
            else
                hasPre = false;

            return string.Format("{0} {1} {2} ", second.ToString(), minute.ToString(), hour.ToString());
        }

        /// <summary>
        /// 按国际节日
        /// </summary>
        /// <returns></returns>
        private Trigger GetTriggerInterHoliday()
        {
            //cron表达式
            string cronExpression = "";
            if (rbtInter10M1D.Checked)
            {
                #region
                //使用提前延后
                if (cbUseMin.Checked)
                {
                    //提前
                    if (rbtUseForward.Checked)
                    {
                        bool hasPre;
                        string pre = GetInterHolidayPreCronExpression(out hasPre);
                        if(hasPre)
                            cronExpression = pre + "30 9 ?";
                        else
                            cronExpression = pre + "1 10 ?";
                    }
                    //延后
                    else
                    {
                        cronExpression = string.Format("{0} {1} {2} 1 10 ?", nDelaySecond.Value.ToString(), nDelayMinute.Value.ToString(), nDelayHour.Value.ToString());
                    }
                }
                else
                {
                    //零点整
                    cronExpression = "0 0 0 1 10 ?";
                }
                #endregion
            }
            if (rbtInter11M4thThu.Checked)
            {
                #region
                //使用提前延后
                if (cbUseMin.Checked)
                {
                    //提前
                    if (rbtUseForward.Checked)
                    {
                        bool hasPre;
                        string pre = GetInterHolidayPreCronExpression(out hasPre);
                        if (hasPre)
                            cronExpression = pre + "? 11 3#4";
                        else
                            cronExpression = pre + "? 11 4#4";
                    }
                    //延后
                    else
                    {
                        cronExpression = string.Format("{0} {1} {2} ? 11 4#4", nDelaySecond.Value.ToString(), nDelayMinute.Value.ToString(), nDelayHour.Value.ToString());
                    }
                }
                else
                {
                    //零点整
                    cronExpression = "0 0 0 ? 11 4#4";
                }
                #endregion
            }
            if (rbtInter12M20D.Checked)
            {
                #region
                //使用提前延后
                if (cbUseMin.Checked)
                {
                    //提前
                    if (rbtUseForward.Checked)
                    {
                        bool hasPre;
                        string pre = GetInterHolidayPreCronExpression(out hasPre);
                        if (hasPre)
                            cronExpression = pre + "30 9 ?";
                        else
                            cronExpression = pre + "1 10 ?";
                    }
                    //延后
                    else
                    {
                        cronExpression = string.Format("{0} {1} {2} 1 10 ?", nDelaySecond.Value.ToString(), nDelayMinute.Value.ToString(), nDelayHour.Value.ToString());
                    }
                }
                else
                {
                    //零点整
                    cronExpression = "0 0 0 1 10 ?";
                }
                #endregion
                cronExpression = "20 12 ?";
            }
            if (rbtInter12M24D.Checked)
            {
                #region
                //使用提前延后
                if (cbUseMin.Checked)
                {
                    //提前
                    if (rbtUseForward.Checked)
                    {
                        bool hasPre;
                        string pre = GetInterHolidayPreCronExpression(out hasPre);
                        if (hasPre)
                            cronExpression = pre + "23 12 ?";
                        else
                            cronExpression = pre + "24 12 ?";
                    }
                    //延后
                    else
                    {
                        cronExpression = string.Format("{0} {1} {2} 24 12 ?", nDelaySecond.Value.ToString(), nDelayMinute.Value.ToString(), nDelayHour.Value.ToString());
                    }
                }
                else
                {
                    //零点整
                    cronExpression = "0 0 0 24 12 ?";
                }
                #endregion
            }
            if (rbtInter12M25D.Checked)
            {
                #region
                //使用提前延后
                if (cbUseMin.Checked)
                {
                    //提前
                    if (rbtUseForward.Checked)
                    {
                        bool hasPre;
                        string pre = GetInterHolidayPreCronExpression(out hasPre);
                        if (hasPre)
                            cronExpression = pre + "24 12 ?";
                        else
                            cronExpression = pre + "25 12 ?";
                    }
                    //延后
                    else
                    {
                        cronExpression = string.Format("{0} {1} {2} 25 12 ?", nDelaySecond.Value.ToString(), nDelayMinute.Value.ToString(), nDelayHour.Value.ToString());
                    }
                }
                else
                {
                    //零点整
                    cronExpression = "0 0 0 25 12 ?";
                }
                #endregion
            }
            if (rbtInter1M1D.Checked)
            {
                #region
                //使用提前延后
                if (cbUseMin.Checked)
                {
                    //提前
                    if (rbtUseForward.Checked)
                    {
                        bool hasPre;
                        string pre = GetInterHolidayPreCronExpression(out hasPre);
                        if (hasPre)
                            cronExpression = pre + "31 12 ?";
                        else
                            cronExpression = pre + "1 1 ?";
                    }
                    //延后
                    else
                    {
                        cronExpression = string.Format("{0} {1} {2} 1 1 ?", nDelaySecond.Value.ToString(), nDelayMinute.Value.ToString(), nDelayHour.Value.ToString());
                    }
                }
                else
                {
                    //零点整
                    cronExpression = "0 0 0 1 1 ?";
                }
                #endregion
            }
            if (rbtInter2M14D.Checked)
            {
                #region
                //使用提前延后
                if (cbUseMin.Checked)
                {
                    //提前
                    if (rbtUseForward.Checked)
                    {
                        bool hasPre;
                        string pre = GetInterHolidayPreCronExpression(out hasPre);
                        if (hasPre)
                            cronExpression = pre + "13 2 ?";
                        else
                            cronExpression = pre + "14 2 ?";
                    }
                    //延后
                    else
                    {
                        cronExpression = string.Format("{0} {1} {2} 14 2 ?", nDelaySecond.Value.ToString(), nDelayMinute.Value.ToString(), nDelayHour.Value.ToString());
                    }
                }
                else
                {
                    //零点整
                    cronExpression = "0 0 0 14 2 ?";
                }
                #endregion
            }
            if (rbtInter3M15D.Checked)
            {
                #region
                //使用提前延后
                if (cbUseMin.Checked)
                {
                    //提前
                    if (rbtUseForward.Checked)
                    {
                        bool hasPre;
                        string pre = GetInterHolidayPreCronExpression(out hasPre);
                        if (hasPre)
                            cronExpression = pre + "14 3 ?";
                        else
                            cronExpression = pre + "15 3 ?";
                    }
                    //延后
                    else
                    {
                        cronExpression = string.Format("{0} {1} {2} 15 3 ?", nDelaySecond.Value.ToString(), nDelayMinute.Value.ToString(), nDelayHour.Value.ToString());
                    }
                }
                else
                {
                    //零点整
                    cronExpression = "0 0 0 15 3 ?";
                }
                #endregion
            }
            if (rbtInter3M8D.Checked)
            {
                #region
                //使用提前延后
                if (cbUseMin.Checked)
                {
                    //提前
                    if (rbtUseForward.Checked)
                    {
                        bool hasPre;
                        string pre = GetInterHolidayPreCronExpression(out hasPre);
                        if (hasPre)
                            cronExpression = pre + "7 3 ?";
                        else
                            cronExpression = pre + "8 3 ?";
                    }
                    //延后
                    else
                    {
                        cronExpression = string.Format("{0} {1} {2} 8 3 ?", nDelaySecond.Value.ToString(), nDelayMinute.Value.ToString(), nDelayHour.Value.ToString());
                    }
                }
                else
                {
                    //零点整
                    cronExpression = "0 0 0 8 3 ?";
                }
                #endregion
            }
            if (rbtInter4M1D.Checked)
            {
                #region
                //使用提前延后
                if (cbUseMin.Checked)
                {
                    //提前
                    if (rbtUseForward.Checked)
                    {
                        bool hasPre;
                        string pre = GetInterHolidayPreCronExpression(out hasPre);
                        if (hasPre)
                            cronExpression = pre + "31 3 ?";
                        else
                            cronExpression = pre + "1 4 ?";
                    }
                    //延后
                    else
                    {
                        cronExpression = string.Format("{0} {1} {2} 1 4 ?", nDelaySecond.Value.ToString(), nDelayMinute.Value.ToString(), nDelayHour.Value.ToString());
                    }
                }
                else
                {
                    //零点整
                    cronExpression = "0 0 0 1 4 ?";
                }
                #endregion
            }
            if (rbtInter5M1D.Checked)
            {
                #region
                //使用提前延后
                if (cbUseMin.Checked)
                {
                    //提前
                    if (rbtUseForward.Checked)
                    {
                        bool hasPre;
                        string pre = GetInterHolidayPreCronExpression(out hasPre);
                        if (hasPre)
                            cronExpression = pre + "30 4 ?";
                        else
                            cronExpression = pre + "1 5 ?";
                    }
                    //延后
                    else
                    {
                        cronExpression = string.Format("{0} {1} {2} 1 5 ?", nDelaySecond.Value.ToString(), nDelayMinute.Value.ToString(), nDelayHour.Value.ToString());
                    }
                }
                else
                {
                    //零点整
                    cronExpression = "0 0 0 1 5 ?";
                }
                #endregion
            }
            if (rbtInter5M2ndSun.Checked)
            {
                #region
                //使用提前延后
                if (cbUseMin.Checked)
                {
                    //提前
                    if (rbtUseForward.Checked)
                    {
                        bool hasPre;
                        string pre = GetInterHolidayPreCronExpression(out hasPre);
                        if (hasPre)
                            cronExpression = pre + "? 5 7#2";
                        else
                            cronExpression = pre + "? 5 1#2";
                    }
                    //延后
                    else
                    {
                        cronExpression = string.Format("{0} {1} {2} ? 5 1#2", nDelaySecond.Value.ToString(), nDelayMinute.Value.ToString(), nDelayHour.Value.ToString());
                    }
                }
                else
                {
                    //零点整
                    cronExpression = "0 0 0 ? 5 1#2";
                }
                #endregion
            }
            if (rbtInter5M4D.Checked)
            {
                #region
                //使用提前延后
                if (cbUseMin.Checked)
                {
                    //提前
                    if (rbtUseForward.Checked)
                    {
                        bool hasPre;
                        string pre = GetInterHolidayPreCronExpression(out hasPre);
                        if (hasPre)
                            cronExpression = pre + "3 5 ?";
                        else
                            cronExpression = pre + "4 5 ?";
                    }
                    //延后
                    else
                    {
                        cronExpression = string.Format("{0} {1} {2} 4 5 ?", nDelaySecond.Value.ToString(), nDelayMinute.Value.ToString(), nDelayHour.Value.ToString());
                    }
                }
                else
                {
                    //零点整
                    cronExpression = "0 0 0 4 5 ?";
                }
                #endregion
            }
            if (rbtInter6M1.Checked)
            {
                #region
                //使用提前延后
                if (cbUseMin.Checked)
                {
                    //提前
                    if (rbtUseForward.Checked)
                    {
                        bool hasPre;
                        string pre = GetInterHolidayPreCronExpression(out hasPre);
                        if (hasPre)
                            cronExpression = pre + "31 5 ?";
                        else
                            cronExpression = pre + "1 6 ?";
                    }
                    //延后
                    else
                    {
                        cronExpression = string.Format("{0} {1} {2} 1 6 ?", nDelaySecond.Value.ToString(), nDelayMinute.Value.ToString(), nDelayHour.Value.ToString());
                    }
                }
                else
                {
                    //零点整
                    cronExpression = "0 0 0 1 6 ?";
                }
                #endregion
            }
            if (rbtInter6M3rdSun.Checked)
            {
                #region
                //使用提前延后
                if (cbUseMin.Checked)
                {
                    //提前
                    if (rbtUseForward.Checked)
                    {
                        bool hasPre;
                        string pre = GetInterHolidayPreCronExpression(out hasPre);
                        if (hasPre)
                            cronExpression = pre + "? 6 7#3";
                        else
                            cronExpression = pre + "? 6 1#3";
                    }
                    //延后
                    else
                    {
                        cronExpression = string.Format("{0} {1} {2} ? 6 1#3", nDelaySecond.Value.ToString(), nDelayMinute.Value.ToString(), nDelayHour.Value.ToString());
                    }
                }
                else
                {
                    //零点整
                    cronExpression = "0 0 0 ? 6 1#3";
                }
                #endregion
            }
            if (rbtInter7M1D.Checked)
            {
                #region
                //使用提前延后
                if (cbUseMin.Checked)
                {
                    //提前
                    if (rbtUseForward.Checked)
                    {
                        bool hasPre;
                        string pre = GetInterHolidayPreCronExpression(out hasPre);
                        if (hasPre)
                            cronExpression = pre + "30 6 ?";
                        else
                            cronExpression = pre + "1 7 ?";
                    }
                    //延后
                    else
                    {
                        cronExpression = string.Format("{0} {1} {2} 1 7 ?", nDelaySecond.Value.ToString(), nDelayMinute.Value.ToString(), nDelayHour.Value.ToString());
                    }
                }
                else
                {
                    //零点整
                    cronExpression = "0 0 0 1 7 ?";
                }
                #endregion
            }
            if (rbtInter8M1D.Checked)
            {
                #region
                //使用提前延后
                if (cbUseMin.Checked)
                {
                    //提前
                    if (rbtUseForward.Checked)
                    {
                        bool hasPre;
                        string pre = GetInterHolidayPreCronExpression(out hasPre);
                        if (hasPre)
                            cronExpression = pre + "31 7 ?";
                        else
                            cronExpression = pre + "1 8 ?";
                    }
                    //延后
                    else
                    {
                        cronExpression = string.Format("{0} {1} {2} 1 8 ?", nDelaySecond.Value.ToString(), nDelayMinute.Value.ToString(), nDelayHour.Value.ToString());
                    }
                }
                else
                {
                    //零点整
                    cronExpression = "0 0 0 1 8 ?";
                }
                #endregion
            }
            if (rbtInter9M10D.Checked)
            {
                #region
                //使用提前延后
                if (cbUseMin.Checked)
                {
                    //提前
                    if (rbtUseForward.Checked)
                    {
                        bool hasPre;
                        string pre = GetInterHolidayPreCronExpression(out hasPre);
                        if (hasPre)
                            cronExpression = pre + "9 9 ?";
                        else
                            cronExpression = pre + "10 9 ?";
                    }
                    //延后
                    else
                    {
                        cronExpression = string.Format("{0} {1} {2} 10 9 ?", nDelaySecond.Value.ToString(), nDelayMinute.Value.ToString(), nDelayHour.Value.ToString());
                    }
                }
                else
                {
                    //零点整
                    cronExpression = "0 0 0 10 9 ?";
                }
                #endregion
            }
            return new CronTrigger(txtTriggerName.Text, txtTriggerGroup.Text, JobName, JobGroupName, GetStartDateTime(), GetEndDateTime(), cronExpression);
        }

        private Trigger GetTriggerAdvance()
        {
            try
            {
                return new CronTrigger(txtTriggerName.Text, txtTriggerGroup.Text, JobName, JobGroupName, GetStartDateTime(), GetEndDateTime(), txtAdvCronExpression.Text);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return null;
            }
        }

        #region IUpdateUI Members

        public void UpdateUI()
        {
            lbTriggersAvailable.Items.Clear();
            foreach (string group in SchedulerManager.GetScheduler().TriggerGroupNames)
            {
                foreach (string trigger in SchedulerManager.GetScheduler().GetTriggerNames(group))
                {
                    TriggerAndGroup triggerAndGroup = new TriggerAndGroup(group, trigger);
                    lbTriggersAvailable.Items.Add(triggerAndGroup);
                }
            }
        }

        #endregion

        private void cbEndDatetime_CheckedChanged(object sender, EventArgs e)
        {
            if (cbEndDatetime.Checked)
                pnlEndDatetime.Enabled = true;
            else
                pnlEndDatetime.Enabled = false;
        }

        private void rbtEveryNDay_CheckedChanged(object sender, EventArgs e)
        {
            if (rbtEveryNDay.Checked)
                nDay.Enabled = true;
            else
                nDay.Enabled = false;
        }

        private void btnAdvCheck_Click(object sender, EventArgs e)
        {
            try
            {
                CronExpression exp = new CronExpression(txtAdvCronExpression.Text);
                lblAdvError.Text = "合法";
            }
            catch (ArgumentException arg)
            {
                lblAdvError.Text = arg.Message;
            }
            catch (FormatException fm)
            {
                lblAdvError.Text = fm.Message;
            }
            catch (Exception ex)
            {
                lblAdvError.Text = ex.Message;
            }
        }

        private void rbtWeekByWeek_CheckedChanged(object sender, EventArgs e)
        {
            if (rbtWeekByWeek.Checked)
            {
                nWeekDay.Enabled = false;
                cbWeekNth.Enabled = true;
                cbWeekNDay.Enabled = true;
            }
            else
            {
                nWeekDay.Enabled = true;
                cbWeekNth.Enabled = false;
                cbWeekNDay.Enabled = false;
            }
        }

        private void rbtUseDelay_CheckedChanged(object sender, EventArgs e)
        {
            if (rbtUseDelay.Checked)
            {
                pnlDelay.Enabled = true;
                pnlForward.Enabled = false;
            }
            else
            {
                pnlDelay.Enabled = false;
                pnlForward.Enabled = true;
            }
        }

        private void cbUseMin_CheckedChanged(object sender, EventArgs e)
        {
            if (cbUseMin.Checked)
                pnlUseMin.Enabled = true;
            else
                pnlUseMin.Enabled = false;
        }
    }
}
