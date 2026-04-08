using Globals.Clients;
using LocationContracts;
using Microsoft.AspNetCore.Mvc;
using OfferContracts;
using OfferContracts.RentObj;
using OrderContracts;
using System.Net;
using System.Net.Http.Json;
using TranslationContracts;
using WebApiGetway.Clients.Interface;
using WebApiGetway.Service.Interfase;


namespace WebApiGetway.Clients
{
    public class OrderApiClient : BaseApiClient, IOrderApiClient
    {
       
        public OrderApiClient(HttpClient client, ILogger<OrderApiClient> logger)
       : base(client, logger) { }

        //===============================================================================================================
        //       VALID ORDERS BY OFFER ID AND DATE-TIME
        //===============================================================================================================
        public async Task<bool> HasDateConflict(int offerId, DateTime start, DateTime end)
        {
            var isExist = false;

            var request = new DateValidationRequest
            {
                OfferId = offerId,
                Start = start,
                End = end
            };
            isExist = await PostAsync<bool>(                   //true - есть конфликт, false - нет конфликта
                $"/api/order/{offerId}/valid/date-time",
                request
            );

            return isExist;
        }

        //===============================================================================================================
        // GET METHODS Order by orderId  
        //===============================================================================================================

        public async Task<OrderResponse> GetOrderByIdAsync(int orderId)
        {
            var result = await GetAsync<OrderResponse>(
                $"/api/order/get/{orderId}");

            return result ?? new OrderResponse();
        }

        //===============================================================================================================
        // GET METHODS Order by userId  
        //===============================================================================================================

        public async Task<IEnumerable<OrderResponse>> GetOrdersByUserIdAsync(int userId)
        {
            var result = await GetAsync<IEnumerable<OrderResponse>>(
                $"/api/order/get/ordersByUserId/{userId}");

            return result ?? Enumerable.Empty<OrderResponse>();
        }

        //===============================================================================================================
        // GET METHODS есть ли новые не подтвержденные брони у owner
        //===============================================================================================================


        public async Task<IEnumerable<int>> HasPendingOrder(int userId)
        {
            var result = await GetAsync<IEnumerable<int>>(
                $"/api/Order/has-pending/{userId}");
            return result ?? Enumerable.Empty<int>();
        }
        //============================================================================================================
        //       CREATE ORDER
        //============================================================================================================
        public async Task<int> CreateOrder(OrderRequest orderRequest)
        {
            var result = -1 ;
             result = await PostAsync<int>(
                $"/api/order/order/add", orderRequest);

            return result;
        }

        //===============================================================================================================
        //       UPDATE ORDER STATUS
        //===============================================================================================================

        public async Task<bool> UpdateStateOrder(int orderId, string orderState)
        {
            var result = false;
            result = await PostAsync<bool>(
               $"/api/order/update/status/{orderId}?orderState={orderState}",
               new { });

            return result;
        }
        //===============================================================================================================
        //                 GET LIST OF ORDERS FOR OFFER BY OFFER ID
        //===============================================================================================================
        public async Task<IEnumerable<OrderResponse>> GetOrdersByOfferId(int offerId)
        {
            var result = await GetAsync<IEnumerable<OrderResponse>>(
                $"/api/order/get/byOfferId/{offerId}");
            return result ?? Enumerable.Empty<OrderResponse>();
        }

    }
}
