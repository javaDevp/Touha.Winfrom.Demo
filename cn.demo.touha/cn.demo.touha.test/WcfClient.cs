using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Description;
using System.Text;
using System.Threading.Tasks;

namespace cn.demo.touha.lib.WCF
{
    public class WcfClient<T> : ClientBase<T> where T : class
    {
        public WcfClient()
        {

        }

        public WcfClient(string endpointConfigurationName)
            :base(endpointConfigurationName)
        {

        }

        public WcfClient(string endpointConfigurationName, string remoteAddress)
            :base(endpointConfigurationName, remoteAddress)
        {

        }

        public WcfClient(ServiceEndpoint endpoint)
            :base(endpoint)
        {

        }
    }
}
