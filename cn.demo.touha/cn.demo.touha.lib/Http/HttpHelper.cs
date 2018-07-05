using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace cn.demo.touha.lib.Http
{
    public class HttpHelper
    {
        private static HttpContentTypeHelper contentTypeHelper = new HttpContentTypeHelper();

        public static string DoPost(HttpContentType contentType, string url, string parameters)
        {
            HttpWebRequest request = WebRequest.Create(url) as HttpWebRequest;
            if(request != null)
            {
                request.ContentType = contentTypeHelper.GetContentTypeString(contentType);
                request.Method = "Post";
                Byte[] bytes = Encoding.UTF8.GetBytes(parameters);
                using (Stream requestStream = request.GetRequestStream())
                {
                    requestStream.Write(bytes, 0, bytes.Length);
                }

                HttpWebResponse response =  request.GetResponse() as HttpWebResponse;
                Encoding encoding = Encoding.GetEncoding(response.CharacterSet);

                using (Stream responseStream = response.GetResponseStream())
                {
                    using (StreamReader sr = new StreamReader(responseStream))
                    {
                        return sr.ReadToEnd();
                    }
                }
            }
            return string.Empty;
        }
    }
}
