// Copyright (c) 黄桂超 重庆大学计算机学院 硕士研究生
// 更多信息请访问:http://www.cnblogs.com/Doho/
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Quartz;

namespace QuartzExampleWin32
{
    public partial class LogWindow : ToolWindow, IUpdateUI
    {
        public TextBox TextBoxLog
        {
            get
            {
                return this.txtLog;
            }
        }

        public LogWindow()
        {
            InitializeComponent();
        }

        #region IUpdateUI Members

        public void UpdateUI()
        {
            
        }

        #endregion
    }
}
