using cn.demo.touha.lib.WCF;
using cn.demo.touha.test;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.ServiceModel.Description;
using System.Text;
using System.Threading.Tasks;

namespace cn.demo.touha.test2
{
    class Program
    {
        static void Main(string[] args)
        {
            //Console.WriteLine(new ServiceReference1.AddClient().Add(3, 4));
            //下面两行效果不同
            //var c1 = ContractDescription.GetContract(typeof(IAdd));
            //var c2 = new ContractDescription("MyAdd") { ContractType = typeof(IAdd) };
            Console.WriteLine(new TestClient(new ServiceEndpoint(ContractDescription.GetContract(typeof(IAdd)), new BasicHttpBinding(), new EndpointAddress("http://127.0.0.1:9999/MyService"))).Add(1, 2));
            //Console.WriteLine(new TestClient(new BasicHttpBinding(), new EndpointAddress("http://127.0.0.1:9999/MyService")).Add(2, 3));
            Console.ReadKey();
        }

        public class TestClient : WcfClient<IAdd>, IAdd
        {
            public TestClient(ServiceEndpoint endpoint)
            :base(endpoint)
            {

            }

            public TestClient(string endpointName)
                :base(endpointName)
            {

            }

            public int Add(int a, int b)
            {
                return base.Channel.Add(a, b);
            }
        }
    }
}
