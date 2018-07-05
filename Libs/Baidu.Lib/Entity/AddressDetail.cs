using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Baidu.Lib.Entity
{
    public class AddressDetail
    {
        /// <summary>
        /// 城市
        /// </summary>
        public string City { get; set; }

        /// <summary>
        /// 百度城市代码
        /// </summary>
        public string CityCode { get; set; }

        /// <summary>
        /// 区县。
        /// </summary>
        public string District { get; set; }

        /// <summary>
        /// 省份
        /// </summary>
        public string Province { get; set; }

        /// <summary>
        /// 街道
        /// </summary>
        public string Street { get; set; }

        /// <summary>
        /// 门牌号
        /// </summary>
        public string StreetNumber { get; set; }
    }
}
