using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Top.Api;
using Top.Api.Request;
using Top.Api.Response;

namespace TopSdk.Test
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] sessionKeys = new string[] {"6200c1954bacc7e882c219573fceg3bdZZfc213ec647f6f2155633072",
                                                "62026252839797b558d668920792282c0ZZ3a1ZZ9e124d22482927843",
                                                "61014249feb34bf967ecae29db888f3f12ec5hj1a4240861927084836",
                                                "61012088eca4899f1160cZZ1e9a635c5428f421aa6e28b71808940384",
                                                "62014234cd2f0496881e4724d351fd7ZZ86cZZad1e46a48322201563",
                                                "6100e17f453e5e1be8c0773f51559aZZc043ce525c46c9f2863170142",
                                                "6201e09c2fd74ddcace01eZZ454b78a27d9457cc81e44162909301689",
                                                "61011230179903161bb7af2d558482214287ZZ6fc62f2d72831235799",
                                                "62023038019ZZe2chjea12b4378b184c53a2ba1652e60e5757429817",
                                                "61000062ba2b9a1a2c4ZZb27d11d98d3606efb6d1a977141689925874",
                                                "620252835ada286910251b03b05131297fcace894ZZ1ef03039682679",
                                                "62028301b869c1a7401ce84e7b585d393ee3a3ZZc81fha2646266812",
                                                "61000020691b320ZZ5117dbab11b4595827ea7cd4b23e1b256437593"};
            string url = "https://121.41.160.159/";
            string appkey = "21306918";
            string secret = "bac92cb34858358f334652ab4f862f4f";
            ITopClient client = new DefaultTopClient(url, appkey, secret);
            TmallExchangeReceiveGetRequest req = new TmallExchangeReceiveGetRequest();
            req.EndGmtModifedTime = DateTime.Parse("2017-12-01 00:00:00");
            req.StartGmtModifiedTime = DateTime.Parse("2017-12-12 23:59:59");
            //req.LogisticNo = "NO123456789";
            //req.BuyerNick = "卡卡";
            //req.StartCreatedTime = DateTime.Parse("2000-01-01 00:00:00");
            req.Fields = "dispute_id, bizorder_id, num, buyer_nick, status, created, modified, reason, title, buyer_logistic_no, seller_logistic_no, bought_sku, exchange_sku, buyer_address, address, time_out, buyer_phone, buyer_logistic_name, seller_logistic_name";
            req.PageSize = 30L;
            req.DisputeStatusArray = "1,2,3,4";
            //req.EndCreatedTime = DateTime.Parse("2000-01-01 00:00:00");
            //req.BuyerId = 4567890L;
            //req.RefundIdArray = "123456,987654";
            req.PageNo = 1L;
            //req.BizOrderId = 666666666L;
            foreach (var sessionKey in sessionKeys)
            {
                TmallExchangeReceiveGetResponse rsp = client.Execute(req, sessionKey);
                Console.WriteLine(rsp.Body);
               rsp.Results
            }
            Console.ReadKey();
        }
    }
}
