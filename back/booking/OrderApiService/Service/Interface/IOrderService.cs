using Globals.Abstractions;
using OrderApiService.Models;

namespace OrderApiService.Service.Interface
{
    public interface IOrderService : IServiceBase<Order>
    {
        Task<int> AddOrderAsync(Order order);
    }
}
