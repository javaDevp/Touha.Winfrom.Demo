/*******************************************************************************
 * Copyright 2009-2017 Amazon Services. All Rights Reserved.
 * Licensed under the Apache License, Version 2.0 (the "License"); 
 *
 * You may not use this file except in compliance with the License. 
 * You may obtain a copy of the License at: http://aws.amazon.com/apache2.0
 * This file is distributed on an "AS IS" BASIS, WITHOUT WARRANTIES OR 
 * CONDITIONS OF ANY KIND, either express or implied. See the License for the 
 * specific language governing permissions and limitations under the License.
 *******************************************************************************
 * Marketplace Web Service Orders
 * API Version: 2013-09-01
 * Library Version: 2017-02-22
 * Generated: Thu Mar 02 12:41:05 UTC 2017
 */

using MarketplaceWebServiceOrders.Model;
using System;
using System.Collections.Generic;

namespace MarketplaceWebServiceOrders {

    /// <summary>
    /// Runnable sample code to demonstrate usage of the C# client.
    ///
    /// To use, import the client source as a console application,
    /// and mark this class as the startup object. Then, replace
    /// parameters below with sensible values and run.
    /// </summary>
    public class MarketplaceWebServiceOrdersSample {

        // Developer AWS access key
        static string accessKey = "AKIAJK2D3J3MFNA7XQTA";

        // Developer AWS secret key
        static string secretKey = "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";

        // The client application name
        static string appName = "CSharpSampleCode";

        // The client application version
        static string appVersion = "1.0";

        // The endpoint for region service and version (see developer guide)
        // ex: https://mws.amazonservices.com
        static string serviceURL = "https://mws.amazonservices.com.cn";

        public static void Main(string[] args)
        {
            // TODO: Set the below configuration variables before attempting to run

            

            // Create a configuration object
            MarketplaceWebServiceOrdersConfig config = new MarketplaceWebServiceOrdersConfig();
            config.ServiceURL = serviceURL;
            // Set other client connection configurations here if needed
            // Create the client itself
            MarketplaceWebServiceOrders client = new MarketplaceWebServiceOrdersClient(accessKey, secretKey, appName, appVersion, config);

            MarketplaceWebServiceOrdersSample sample = new MarketplaceWebServiceOrdersSample(client);

            // Uncomment the operation you'd like to test here
            // TODO: Modify the request created in the Invoke method to be valid

            try 
            {
                IMWSResponse response = null;
                 //response = sample.InvokeGetOrder();
                // response = sample.InvokeGetServiceStatus();
                // response = sample.InvokeListOrderItems();
                // response = sample.InvokeListOrderItemsByNextToken();
                 response = sample.InvokeListOrders();
                // response = sample.InvokeListOrdersByNextToken();
                Console.WriteLine("Response:");
                ResponseHeaderMetadata rhmd = response.ResponseHeaderMetadata;
                // We recommend logging the request id and timestamp of every call.
                Console.WriteLine("RequestId: " + rhmd.RequestId);
                Console.WriteLine("Timestamp: " + rhmd.Timestamp);
                string responseXml = response.ToXML();
                Console.WriteLine(responseXml);
            }
            catch (MarketplaceWebServiceOrdersException ex)
            {
                // Exception properties are important for diagnostics.
                ResponseHeaderMetadata rhmd = ex.ResponseHeaderMetadata;
                Console.WriteLine("Service Exception:");
                if(rhmd != null)
                {
                    Console.WriteLine("RequestId: " + rhmd.RequestId);
                    Console.WriteLine("Timestamp: " + rhmd.Timestamp);
                }
                Console.WriteLine("Message: " + ex.Message);
                Console.WriteLine("StatusCode: " + ex.StatusCode);
                Console.WriteLine("ErrorCode: " + ex.ErrorCode);
                Console.WriteLine("ErrorType: " + ex.ErrorType);
                throw ex;
            }
        }

        private readonly MarketplaceWebServiceOrders client;

        public MarketplaceWebServiceOrdersSample(MarketplaceWebServiceOrders client)
        {
            this.client = client;
        }

        public GetOrderResponse InvokeGetOrder()
        {
            // Create a request.
            GetOrderRequest request = new GetOrderRequest();
            string sellerId = "example";
            request.SellerId = sellerId;
            string mwsAuthToken = "example";
            request.MWSAuthToken = mwsAuthToken;
            List<string> amazonOrderId = new List<string>();
            request.AmazonOrderId = amazonOrderId;
            return this.client.GetOrder(request);
        }

        public GetServiceStatusResponse InvokeGetServiceStatus()
        {
            // Create a request.
            GetServiceStatusRequest request = new GetServiceStatusRequest();
            string sellerId = "example";
            request.SellerId = sellerId;
            string mwsAuthToken = "example";
            request.MWSAuthToken = mwsAuthToken;
            return this.client.GetServiceStatus(request);
        }

        public ListOrderItemsResponse InvokeListOrderItems()
        {
            // Create a request.
            ListOrderItemsRequest request = new ListOrderItemsRequest();
            string sellerId = "example";
            request.SellerId = sellerId;
            string mwsAuthToken = "example";
            request.MWSAuthToken = mwsAuthToken;
            string amazonOrderId = "example";
            request.AmazonOrderId = amazonOrderId;
            return this.client.ListOrderItems(request);
        }

        public ListOrderItemsByNextTokenResponse InvokeListOrderItemsByNextToken()
        {
            // Create a request.
            ListOrderItemsByNextTokenRequest request = new ListOrderItemsByNextTokenRequest();
            string sellerId = "example";
            request.SellerId = sellerId;
            string mwsAuthToken = "example";
            request.MWSAuthToken = mwsAuthToken;
            string nextToken = "example";
            request.NextToken = nextToken;
            return this.client.ListOrderItemsByNextToken(request);
        }

        public ListOrdersResponse InvokeListOrders()
        {
            // Create a request.
            ListOrdersRequest request = new ListOrdersRequest();
            string sellerId = "AP600H71GFSJ9";
            request.SellerId = sellerId;
            request.MWSAuthToken = accessKey;
            DateTime createdAfter = new DateTime(1990, 6, 27);
            request.CreatedAfter = createdAfter;
            //DateTime? createdBefore = null;
            //request.CreatedBefore = createdBefore.GetValueOrDefault();
            //DateTime? lastUpdatedAfter = null;
            //request.LastUpdatedAfter = lastUpdatedAfter.GetValueOrDefault();
            //DateTime? lastUpdatedBefore = null;
            //request.LastUpdatedBefore = lastUpdatedBefore.GetValueOrDefault();
            List<string> orderStatus = new List<string>(); //����״̬
            //���� OrderType = Standard �Ķ�������ʼ�Ķ���״̬�� Pending������ OrderType = Preorder �Ķ������������� JP������ʼ�Ķ���״̬�� PendingAvailability�������븶����Ȩ����ʱ������״̬����Ϊ Pending��
            //�ڴ˰汾�� ������ API������ �У�����ͬʱʹ�� Unshipped �� PartiallyShipped����ʹ������һ��״ֵ̬����᷵�ش���
            orderStatus.Add("PendingAvailability"); //ֻ��Ԥ���������д�״̬
            orderStatus.Add("Pending"); //���������ɣ����Ǹ���δ��Ȩ
            orderStatus.Add("Unshipped"); //�����Ѿ�����Ȩ��������׼���ý��з���������������Ʒ��δ���ˡ�
            orderStatus.Add("PartiallyShipped"); //�����е�һ��������������ȫ������Ʒ�Ѿ�������
            orderStatus.Add("Shipped"); //�����е�������Ʒ���ѷ�����
            orderStatus.Add("InvoiceUnconfirmed"); //�����е�������Ʒ���ѷ������������һ�û��������ѷȷ���Ѿ�����Ҽĳ���Ʊ����ע�⣺�˲������������й�������
            orderStatus.Add("Unfulfillable"); //�����޷��������͡���״̬��������ͨ������ѷ������վ֮��������´ﵫ������ѷ�������͵Ķ�����
            request.OrderStatus = orderStatus;
            List<string> marketplaceId = new List<string>(); //����ѡ������ָ���̳��еĶ�����
            marketplaceId.Add("AAHKV2X7AFYLW");
            request.MarketplaceId = marketplaceId;
            List<string> fulfillmentChannel = new List<string>(); //	ָ���������ͷ�ʽ�Ľṹ���б�
            fulfillmentChannel.Add("AFN"); //����ѷ����
            fulfillmentChannel.Add("MFN"); //������������
            request.FulfillmentChannel = fulfillmentChannel;
            List<string> paymentMethod = new List<string>(); //����ѡ����ָ���Ķ������ʽ��
            //COD �� CVS ֵֻ���ձ���Ч��
            paymentMethod.Add("COD"); //�����ֽ𸶿�
            paymentMethod.Add("CVS"); //�����긶��
            paymentMethod.Add("Other"); //COD �� CVS ֮������⸶�ʽ
            request.PaymentMethod = paymentMethod;
            //string buyerEmail = "example";
            //request.BuyerEmail = buyerEmail;
            //string sellerOrderId = "example";
            //request.SellerOrderId = sellerOrderId;
            decimal maxResultsPerPage = 100;
            request.MaxResultsPerPage = maxResultsPerPage;
            List<string> tfmShipmentStatus = new List<string>();
            request.TFMShipmentStatus = tfmShipmentStatus;
            return this.client.ListOrders(request);
        }

        public ListOrdersByNextTokenResponse InvokeListOrdersByNextToken()
        {
            // Create a request.
            ListOrdersByNextTokenRequest request = new ListOrdersByNextTokenRequest();
            string sellerId = "example";
            request.SellerId = sellerId;
            string mwsAuthToken = "example";
            request.MWSAuthToken = mwsAuthToken;
            string nextToken = "example";
            request.NextToken = nextToken;
            return this.client.ListOrdersByNextToken(request);
        }


    }
}
