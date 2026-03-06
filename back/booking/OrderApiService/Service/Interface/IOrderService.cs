using Globals.Abstractions;
using OrderApiService.Models;
using OrderContracts;
using OrderContracts.Enum;

namespace OrderApiService.Service.Interface
{
    public interface IOrderService : IServiceBaseNew<Order>
    {
        Task<int> AddOrderAsync(Order order);
        Task<int> UpdateOrderStatus(int orderId, OrderStatus orderState);
        Task<List<OrderResponse>> GetOrdersByClientIdAsync(int clientId);

        Task<List<OrderResponse>> GetOrdersByOfferIdAsync(int offerId);
        Task<List<int>> GetPendingOfferIdsAsync(int ownerId);
        Task<bool> HasDateConflict(int orderId, int offerId, DateTime start, DateTime end);
    }
}
