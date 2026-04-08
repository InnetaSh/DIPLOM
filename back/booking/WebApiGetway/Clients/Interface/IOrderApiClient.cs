using LocationContracts;
using OfferContracts;
using OfferContracts.RentObj;
using OrderContracts;
using TranslationContracts;

namespace WebApiGetway.Clients.Interface
{
    public interface IOrderApiClient
    {
        Task<bool> HasDateConflict(int offerId, DateTime startDate, DateTime endDate);
        Task<IEnumerable<int>> HasPendingOrder(int userId);
        //-------------------------------------------------------------------------------------

        Task<OrderResponse> GetOrderByIdAsync(int orderId);
        Task<IEnumerable<OrderResponse>> GetOrdersByUserIdAsync(int userId);
        //-------------------------------------------------------------------------------------
        Task<int> CreateOrder(OrderRequest orderRequest);
        //-------------------------------------------------------------------------------------
        Task<bool> UpdateStateOrder(int orderId, string orderState);
        Task<IEnumerable<OrderResponse>> GetOrdersByOfferId(int offerId);
    }
}
