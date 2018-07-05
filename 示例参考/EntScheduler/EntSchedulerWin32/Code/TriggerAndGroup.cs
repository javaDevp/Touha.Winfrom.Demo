// Copyright (c) 黄桂超 重庆大学计算机学院 硕士研究生
// 更多信息请访问:http://www.cnblogs.com/Doho/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace QuartzExampleWin32
{
    public class TriggerAndGroup
    {
        public TriggerAndGroup(string groupName, string triggerName)
        {
            this.GroupName = groupName;
            this.TriggerName = triggerName;
        }

        public string GroupName
        {
            get;
            set;
        }

        public string TriggerName
        {
            get;
            set;
        }

        public override string ToString()
        {
            return "触发器组名:" + GroupName + "\t" + "触发器名:" + TriggerName;
        }
    }
}
