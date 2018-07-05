using cn.demo.touha.lib.WCF;
using System.ServiceModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel.Description;
using System.Collections;
using cn.demo.touha.lib.Http;

namespace cn.demo.touha.test
{
    class Program
    {
        static void Main(string[] args)
        {
            //try
            //{
            //    var dic = MyBatisHelper.Instance.QueryForList<Hashtable>("GetSysSequenceNo", null);
            //    //var obj = MyBatisHelper.Instance.QueryForList<SysSequenceNo>("GetSysSequenceNo", null);
            //}catch(Exception ex)
            //{
            //    Console.WriteLine(ex.Message);
            //}
            try
            {
                string parameters = @"params=
{
    'head': {
        'method': 'addOrder',
        'format': 'json',
        'version': '1.0',
        'appCode': 'ec',
        'isSign': '1',
        'signBody': '7A0F546D7424591083ADDB0B61DAEC2A',
        'sendTime': '2017-06-14 17:48:06',
        'serialNo': 'TO1497462486223006585'
    },
    'body': {
        'Orders': [
            {
                'tradeOrder': {
                    'orderNo': '20180207touha02',
                    'buyerNick': 'tom',
                    'orderMon': 199,
                    'feeMon': 10,
                    'realMon': 211,
                    'buyerRemark': '优先给我发货',
                    'paymentSerialNo': '2017010121244401',
                    'orderStatus': '2',
                    'createdDate': '2017-10-01 00:00:00',
                    'updatedDate': '2017-01-01 00:00:01',
                    'PaymentType': '0',
                    'invoiceType': '1',
                    'Invoice': '广州XX公司',
'taxNo': '123456789',
                    'shopId': 'HK003444',
                    'performanceShopId': 'HK003444',
                    'stockId': 'HK000001',
                    'VendCustCode': 'EMS',
                    'onlineType':'0',
                    'Items': [
                        {
                            'orderNo': '20180207touha02',
                            'orderSubNo': '20180207touha02_01',
                            'onlineOrderNo':'t20180207touha02',
                            'barcode': 'x05',
                            'num': 1,
                            'preferentialMon': 5,
                            'itemName': '鞋子-特卖',
                            'salePrice': 199,
                            'totalPrice': 199,
                            'isGifts': 0
                        },
                        {
                            'orderNo': '20180207touha02',
                            'orderSubNo': '20180207touha02_02',
                            'onlineOrderNo':'t20180207touha02',
                            'barcode': 'x06',
                            'num': 1,
                            'preferentialMon': 0,
                            'itemName': '裤子-特卖',
                            'salePrice': 2,
                            'totalPrice': 2,
                            'isGifts': 0
                        }
                    ],
                    'preferentialDesc': '买减',
                    'paymentChannle': 'Alipay'
                },
                'userAddress': {
                    'country': '中国',
                    'city': '广州市',
                    'province': '广东省',
                    'zipCode': '',
                    'addressDetail': '彩频路11号广东软件科学园F301室',
                    'mobile': '13844214754@qq.com',
                    'tel': '13874454214',
                    'contact': '阿汤',
                    'email': '',
                    'district': '萝岗区'
                }
            }
        ]
    }
}
";
                var result = HttpHelper.DoPost(HttpContentType.Default, "http://localhost:3006/api/BSII/business", parameters);
                Console.WriteLine(result);
            }catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            Console.ReadKey();
        }

        private static void WcfTest()
        {
            WCFConfiguration configuration = new WCFConfiguration() { EndpointAddress = new EndpointAddress("http://127.0.0.1:9999/MyService"), Binding = new BasicHttpBinding(), ContractDescription = new ContractDescription("MyAdd") { ContractType = typeof(IAdd) } };
            ServiceHostWrapper wrapper = new ServiceHostWrapper(configuration);
            wrapper.Started += Wrapper_Started;
            wrapper.Stopped += Wrapper_Stopped;
            wrapper.Start(typeof(AddService));
            Console.ReadKey();
            wrapper.Stop();
        }

        private static void Wrapper_Stopped(object sender, EventArgs e)
        {
            Console.WriteLine("服务已关闭");
        }

        private static void Wrapper_Started(object sender, EventArgs e)
        {
            Console.WriteLine("服务已启动");
           // 
            
        }
    }


    [ServiceContract(Name ="MyAdd")]
    public interface IAdd
    {
        [OperationContract]
        int Add(int a, int b);
    }

    public class AddService : IAdd
    {
        public int Add(int a, int b)
        {
            return a + b;
        }
    }
}
