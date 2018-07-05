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
            List<string> orderStatus = new List<string>(); //订单状态
            //对于 OrderType = Standard 的订单，初始的订单状态是 Pending。对于 OrderType = Preorder 的订单（仅适用于 JP），初始的订单状态是 PendingAvailability，当进入付款授权流程时，订单状态将变为 Pending。
            //在此版本的 “订单 API”部分 中，必须同时使用 Unshipped 和 PartiallyShipped。仅使用其中一个状态值，则会返回错误
            orderStatus.Add("PendingAvailability"); //只有预订订单才有此状态
            orderStatus.Add("Pending"); //订单已生成，但是付款未授权
            orderStatus.Add("Unshipped"); //付款已经过授权，订单已准备好进行发货，但订单中商品尚未发运。
            orderStatus.Add("PartiallyShipped"); //订单中的一个或多个（但并非全部）商品已经发货。
            orderStatus.Add("Shipped"); //订单中的所有商品均已发货。
            orderStatus.Add("InvoiceUnconfirmed"); //订单中的所有商品均已发货。但是卖家还没有向亚马逊确认已经向买家寄出发票。请注意：此参数仅适用于中国地区。
            orderStatus.Add("Unfulfillable"); //订单无法进行配送。该状态仅适用于通过亚马逊零售网站之外的渠道下达但由亚马逊进行配送的订单。
            request.OrderStatus = orderStatus;
            List<string> marketplaceId = new List<string>(); //用来选择您所指定商城中的订单。
            marketplaceId.Add("AAHKV2X7AFYLW");
            request.MarketplaceId = marketplaceId;
            List<string> fulfillmentChannel = new List<string>(); //	指明订单配送方式的结构化列表。
            fulfillmentChannel.Add("AFN"); //亚马逊配送
            fulfillmentChannel.Add("MFN"); //卖家自行配送
            request.FulfillmentChannel = fulfillmentChannel;
            List<string> paymentMethod = new List<string>(); //用来选择您指定的订单付款方式。
            //COD 和 CVS 值只在日本有效。
            paymentMethod.Add("COD"); //货到现金付款
            paymentMethod.Add("CVS"); //便利店付款
            paymentMethod.Add("Other"); //COD 或 CVS 之外的任意付款方式
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
