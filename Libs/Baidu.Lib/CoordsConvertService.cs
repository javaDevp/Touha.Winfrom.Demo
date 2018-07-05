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
    /// 坐标转换
    /// </summary>
    public class CoordsConvertService : IBaseService<CoordsConvertRequest, CoordsConvertResponse>
    {
        public static readonly string urlPattern = "http://api.map.baidu.com/geoconv/v1/?coords={0}&from={1}&to={2}&ak={3}";
        public CoordsConvertResponse Execute(CoordsConvertRequest request)
        {
            var url = string.Format(urlPattern, request.Coords, request.From, request.To, request.Ak);
            var strResponse = HttpUtil.DoGet(url);
            return JsonConvert.DeserializeObject<CoordsConvertResponse>(strResponse);
        }
    }
}
