using Baidu.Lib.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Baidu.Lib.Request
{
    public class CoordsConvertRequest
    {
        /// <summary>
        /// 需转换的源坐标，多组坐标以“；”分隔
        ///（经度，纬度）
        /// </summary>
        public Coords Coords { get; set; }

        /// <summary>
        /// 开发者密钥,用户申请注册的key
        /// </summary>
        public string Ak { get; set; }

        /// <summary>
        /// 源坐标类型：
        ///1：GPS设备获取的角度坐标，wgs84坐标;
        ///2：GPS获取的米制坐标、sogou地图所用坐标;
        //3：google地图、soso地图、aliyun地图、mapabc地图和amap地图所用坐标，国测局（gcj02）坐标;
        //4：3中列表地图坐标对应的米制坐标;
        //5：百度地图采用的经纬度坐标;
        //6：百度地图采用的米制坐标;
        //7：mapbar地图坐标;
        //8：51地图坐标
        /// </summary>
        public int From { get; set; }

        /// <summary>
        /// 目标坐标类型：
        ///3：国测局（gcj02）坐标;
        ///4：3中对应的米制坐标;
        ///5：bd09ll(百度经纬度坐标);
        ///6：bd09mc(百度米制经纬度坐标)
        /// </summary>
        public int To { get; set; }

        /// <summary>
        /// 若用户所用ak的校验方式为sn校验时该参数必须
        /// </summary>
        public string Sn { get; set; }
    }
}
