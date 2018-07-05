using Baidu.Lib.Request;
using Baidu.Lib.Response;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Baidu.Lib
{
    /// <summary>
    /// IP定位地址
    /// </summary>
    public class IPConvertService : IBaseService<IPConvertRequest, IPConvertResponse>
    {
        public static readonly string urlPattern = "http://api.map.baidu.com/location/ip?ip={0}&ak={1}&coor={2}";

        public IPConvertResponse Execute(IPConvertRequest request)
        {
            var url = string.Format(urlPattern, request.IP, request.Ak, request.Coor);
            var strResponse = HttpUtil.DoGet(url);
            return JsonConvert.DeserializeObject<IPConvertResponse>(strResponse);
        }
    }
}
