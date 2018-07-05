using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cn.demo.touha.lib.Http
{
    public enum HttpContentType
    {
        /// <summary>
        /// application/x-www-form-urlencoded
        /// </summary>
        Default,
        /// <summary>
        /// application/json
        /// </summary>
        Json
    }

    public class HttpContentTypeHelper
    {
        public string GetContentTypeString(HttpContentType contentType)
        {
            switch (contentType)
            {
                case HttpContentType.Default:
                    return "application/x-www-form-urlencoded";
                case HttpContentType.Json:
                    return "application/json";
                default:
                    return "";
            }
        }
    }
}
