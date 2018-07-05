using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace 一些测试代码
{
    public class ExtractData
    {

        public IEnumerable<T> Extract<T>(string url, HtmlConvent<T> conventor)
        {
            using (WebClient wc = new WebClient())
            {
                wc.Encoding = Encoding.UTF8;
                string html = wc.DownloadString(url);
                if (conventor != null)
                {
                    return conventor(html, 1);
                }
                return null;
            }
            
        }

    }


}
