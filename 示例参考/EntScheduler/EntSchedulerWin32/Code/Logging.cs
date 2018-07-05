// Copyright (c) 黄桂超 重庆大学计算机学院 硕士研究生
// 更多信息请访问:http://www.cnblogs.com/Doho/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Common.Logging;
using System.Collections;
using System.Collections.Specialized;
using System.Globalization;

namespace QuartzExampleWin32
{
    [Serializable]
    public class QuartzLogger : ILog
    {
        // Fields
        private LogLevel _currentLogLevel = LogLevel.All;
        private string _dateTimeFormat = string.Empty;
        private bool _hasDateTimeFormat = false;
        private string _logName = string.Empty;
        private bool _showDateTime = false;
        private bool _showLogName = false;

        public static LogWindow LogWindow
        {
            get;
            set;
        }

        public static ErrorWindow ErrorWindow
        {
            get;
            set;
        }

        // Methods
        public QuartzLogger(string logName, LogLevel logLevel, bool showDateTime, bool showLogName, string dateTimeFormat)
        {
            this._logName = logName;
            this._currentLogLevel = logLevel;
            this._showDateTime = showDateTime;
            this._showLogName = showLogName;
            this._dateTimeFormat = dateTimeFormat;
            if ((this._dateTimeFormat != null) && (this._dateTimeFormat.Length > 0))
            {
                this._hasDateTimeFormat = true;
            }
        }

        public void Debug(object message)
        {
            this.Debug(message, null);
        }

        public void Debug(object message, Exception e)
        {
            if (this.IsLevelEnabled(LogLevel.Debug))
            {
                this.Write(LogLevel.Debug, message, e);
            }
        }

        public void Error(object message)
        {
            this.Error(message, null);
        }

        public void Error(object message, Exception e)
        {
            if (this.IsLevelEnabled(LogLevel.Error))
            {
                this.Write(LogLevel.Error, message, e);
            }
        }

        public void Fatal(object message)
        {
            this.Fatal(message, null);
        }

        public void Fatal(object message, Exception e)
        {
            if (this.IsLevelEnabled(LogLevel.Fatal))
            {
                this.Write(LogLevel.Fatal, message, e);
            }
        }

        public void Info(object message)
        {
            this.Info(message, null);
        }

        public void Info(object message, Exception e)
        {
            if (this.IsLevelEnabled(LogLevel.Info))
            {
                this.Write(LogLevel.Info, message, e);
            }
        }

        private bool IsLevelEnabled(LogLevel level)
        {
            int num = (int)level;
            int num2 = (int)this._currentLogLevel;
            return (num >= num2);
        }

        public void Trace(object message)
        {
            this.Trace(message, null);
        }

        public void Trace(object message, Exception e)
        {
            if (this.IsLevelEnabled(LogLevel.Trace))
            {
                this.Write(LogLevel.Trace, message, e);
            }
        }

        public void Warn(object message)
        {
            this.Warn(message, null);
        }

        public void Warn(object message, Exception e)
        {
            if (this.IsLevelEnabled(LogLevel.Warn))
            {
                this.Write(LogLevel.Warn, message, e);
            }
        }

        private void Write(LogLevel level, object message, Exception e)
        {
            //关闭
            if (level == LogLevel.Off)
                return;

            if (LogWindow == null)
                throw new Exception("LogWindow 属性为空!");

            StringBuilder builder = new StringBuilder();
            if (this._showDateTime)
            {
                if (this._hasDateTimeFormat)
                {
                    builder.Append(DateTime.Now.ToString(this._dateTimeFormat, CultureInfo.InvariantCulture));
                }
                else
                {
                    builder.Append(DateTime.Now);
                }
                builder.Append(" ");
            }
            builder.Append(("[" + level.ToString().ToUpper() + "]").PadRight(8));
            if (this._showLogName)
            {
                builder.Append(this._logName).Append(" - ");
            }
            builder.Append(message);
            if (e != null)
            {
                builder.Append(Environment.NewLine).Append(e.ToString());
            }

            try
            {
                switch (level)
                {
                    case LogLevel.Error:
                    case LogLevel.Fatal:
                        {
                            ErrorWindow.txtLog.Text += builder.ToString() + Environment.NewLine;
                            ErrorWindow.txtLog.ScrollToCaret();
                        }
                        break;
                    case LogLevel.All:
                    case LogLevel.Info:
                    case LogLevel.Debug:
                    case LogLevel.Trace:
                    case LogLevel.Warn:
                        {
                            LogWindow.txtLog.Text += builder.ToString() + Environment.NewLine;
                            LogWindow.txtLog.ScrollToCaret();
                        }
                        break;
                }
            }
            catch { }
            //object[] args = {builder,System.EventArgs.Empty };
            //LogWindow.txtLog.BeginInvoke(new EventHandler(UpdateTextBox), args);
            
        }

        private void UpdateTextBox(object o, System.EventArgs e)
        {
            StringBuilder builder = (StringBuilder)o;
            LogWindow.txtLog.Text += builder.ToString() + Environment.NewLine;
            LogWindow.txtLog.ScrollToCaret();
        }

        // Properties
        public bool IsDebugEnabled
        {
            get
            {
                return this.IsLevelEnabled(LogLevel.Debug);
            }
        }

        public bool IsErrorEnabled
        {
            get
            {
                return this.IsLevelEnabled(LogLevel.Error);
            }
        }

        public bool IsFatalEnabled
        {
            get
            {
                return this.IsLevelEnabled(LogLevel.Fatal);
            }
        }

        public bool IsInfoEnabled
        {
            get
            {
                return this.IsLevelEnabled(LogLevel.Info);
            }
        }

        public bool IsTraceEnabled
        {
            get
            {
                return this.IsLevelEnabled(LogLevel.Trace);
            }
        }

        public bool IsWarnEnabled
        {
            get
            {
                return this.IsLevelEnabled(LogLevel.Warn);
            }
        }
    }

    public class QuartzLoggerFactoryAdapter : ILoggerFactoryAdapter
    {
        // Fields
        private string _dateTimeFormat;
        private LogLevel _Level;
        private Hashtable _logs;
        private bool _showDateTime;
        private bool _showLogName;

        // Methods
        public QuartzLoggerFactoryAdapter()
        {
            this._logs = new Hashtable();
            this._Level = LogLevel.All;
            this._showDateTime = true;
            this._showLogName = true;
            this._dateTimeFormat = string.Empty;
        }

        public QuartzLoggerFactoryAdapter(NameValueCollection properties)
        {
            this._logs = new Hashtable();
            this._Level = LogLevel.All;
            this._showDateTime = true;
            this._showLogName = true;
            this._dateTimeFormat = string.Empty;
            try
            {
                this._Level = (LogLevel)Enum.Parse(typeof(LogLevel), properties["level"], true);
            }
            catch (Exception)
            {
                this._Level = LogLevel.All;
            }
            try
            {
                this._showDateTime = bool.Parse(properties["showDateTime"]);
            }
            catch (Exception)
            {
                this._showDateTime = true;
            }
            try
            {
                this._showLogName = bool.Parse(properties["showLogName"]);
            }
            catch (Exception)
            {
                this._showLogName = true;
            }
            this._dateTimeFormat = properties["dateTimeFormat"];
        }

        public ILog GetLogger(string name)
        {
            lock (this._logs)
            {
                ILog log = this._logs[name] as ILog;
                if (log == null)
                {
                    log = new QuartzLogger(name, this._Level, this._showDateTime, this._showLogName, this._dateTimeFormat);
                    this._logs.Add(name, log);
                }
                return log;
            }
        }

        public ILog GetLogger(Type type)
        {
            return this.GetLogger(type.FullName);
        }
    }
}
