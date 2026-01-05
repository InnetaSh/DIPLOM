using Globals.Abstractions;
using OrderApiService.Models;
using OrderApiService.Models.Enum;
using OrderApiService.View;

namespace OrderApiService.Service.Interface
{
    public interface IOrderService : IServiceBase<Order>
    {
        Task<int> AddOrderAsync(Order order);
        Task<int> UpdateOrderStatus(int orderId, OrderStatus orderState);
        Task<List<OrderResponse>> GetOrdersByClientIdAsync(int clientId);
        Task<bool> HasDateConflict(int orderId, int offerId, DateTime start, DateTime end);
    }
}
