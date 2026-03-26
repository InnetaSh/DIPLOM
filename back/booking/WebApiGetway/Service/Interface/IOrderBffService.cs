using LocationContracts;
using Microsoft.AspNetCore.Mvc;
using OfferContracts.RentObj;
using OrderContracts;
using System.Threading.Tasks;
using TranslationContracts;

namespace WebApiGetway.Service.Interfase
{
    public interface IOrderBffService
    {
        Task<int> CreateOrder(
               CreateOrderRequest request,
               int userId,
               decimal userDiscountPercent,
               string lang);

        //============================================================================================
        Task<bool> UpdateStateOrder(
             int orderId,
             string orderState);
        //============================================================================================

        Task<IEnumerable<OrderResponse>> GetOrdersByOfferId(
           int offerId,
           string lang);
        //============================================================================================
        Task<IEnumerable<OrderResponseForUserCard>> GetOrdersByUserId(int userId, string lang);
    }
}
