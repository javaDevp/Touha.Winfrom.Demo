using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 一些测试代码
{
    /// <summary>
    /// 日志打点接口。
    /// </summary>
    public interface ITopLogger
    {
        bool IsDebugEnabled();

        void TraceApiError(string appKey, string apiName, string url, Dictionary<string, string> parameters, double latency, string errorMessage);

        void Error(string message);
        void Error(string format, params object[] args);

        void Warn(string message);
        void Warn(string format, params object[] args);

        void Info(string message);
        void Info(string format, params object[] args);

        void Debug(string message);
        void Debug(string format, params object[] args);
    }
}
