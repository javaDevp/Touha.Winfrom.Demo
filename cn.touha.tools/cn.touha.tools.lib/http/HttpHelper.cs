using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace cn.touha.tools.lib.http
{
    public class HttpHelper
    {
        public static void DoPost(string url, string contentType)
        {
            HttpWebRequest wc = (HttpWebRequest)WebRequest.Create(url);
            wc.ContentType = contentType;
            wc.Method = "post";
            wc.
        }
    }
}
