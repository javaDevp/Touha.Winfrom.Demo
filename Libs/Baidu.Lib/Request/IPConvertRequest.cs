using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Baidu.Lib.Request
{
    public class IPConvertRequest
    {
        /// <summary>
        /// 用户上网的IP地址，请求中如果不出现、或为空，会针对发来请求的IP进行定位。
        /// </summary>
        public string IP { get; set; }

        /// <summary>
        /// 开发者密钥
        /// </summary>
        public string Ak { get; set; }

        /// <summary>
        /// 设置返回位置信息中，经纬度的坐标类型，分别如下：
        ///coor不出现、或为空：百度墨卡托坐标，即百度米制坐标；
        ///coor = bd09ll：百度经纬度坐标，在国测局坐标基础之上二次加密而来；
        ///coor = gcj02：国测局02坐标，在原始GPS坐标基础上，按照国家测绘行业统一要求，加密后的坐标；
        /// </summary>
        public string Coor { get; set; }

        /// <summary>
        /// 若用户所用AK的校验方式为SN校验时该参数必填（什么是SN校验？）。其他AK校验方式的可不填写。
        /// </summary>
        public string Sn { get; set; }
    }
}
