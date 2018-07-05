using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.ServiceModel.Description;
using System.Text;
using System.Threading.Tasks;

namespace cn.demo.touha.lib.WCF
{
    /// <summary>
    /// WCF配置类
    /// </summary>
    public class WCFConfiguration
    {
        /// <summary>
        /// 地址
        /// </summary>
        public EndpointAddress EndpointAddress { get; set; }

        /// <summary>
        /// 绑定
        /// </summary>
        public Binding Binding { get; set; }

        /// <summary>
        /// 实现
        /// </summary>
        public Type Service { get; set; }

        public ContractDescription ContractDescription { get; set; }

    }
}
