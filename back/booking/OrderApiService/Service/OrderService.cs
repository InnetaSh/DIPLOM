using Globals.Abstractions;
using Globals.Sevices;
using Microsoft.EntityFrameworkCore;
using OrderApiService.Models;
using OrderApiService.Models.Enum;
using OrderApiService.Service.Interface;
using OrderApiService.View;
using System.Net.Http.Json;

namespace OrderApiService.Services
{
    public class OrderService : TableServiceBase<Order, OrderContext>, IOrderService
    {

        //===========================================================================================

        public override async Task<bool> AddEntityAsync(Order order)
        {
            try
            {
                order.TotalPrice = order.OrderPrice + order.TaxAmount;
      
                order.Status = OrderStatus.Pending;
                order.CreatedAt = DateTime.UtcNow;
                await base.AddEntityAsync(order);

                return true;
                
            }
            catch (Exception ex) { }
            return false;
        }

        //===========================================================================================

        public async Task<int> AddOrderAsync(Order order)
        {
            try
            {
                order.TotalPrice = order.OrderPrice + order.TaxAmount;

                order.Status = OrderStatus.Pending;
                order.CreatedAt = DateTime.UtcNow;
                await base.AddEntityAsync(order);

                return order.id;

            }
            catch (Exception ex) { }
            return -1;
        }




        //===========================================================================================
        public async Task<int> UpdateOrderStatus(int orderId, OrderStatus status)
        {
            try
            {
                using var db = new OrderContext();

                var order = await db.Orders.FindAsync(orderId);
                if (order == null)
                    return -1;

              

                order.Status = status;

                await db.SaveChangesAsync();
                return order.id;
            }
            catch
            {
                return -1;
            }
        }
     



        //===========================================================================================

        public async Task<bool> HasDateConflict(int orderId, int offerId,  DateTime start, DateTime end)
        {
            using var db = new OrderContext();
            return await db.Orders.AnyAsync(o =>
                o.id == orderId &&
                o.OfferId == offerId &&
                o.Status != OrderStatus.Cancelled &&
                o.StartDate < end &&
                o.EndDate > start
            );
        }

        //===========================================================================================

        public async Task<List<OrderResponse>> GetOrdersByClientIdAsync(int clientId)
        {
            using var db = new OrderContext();
            var orders = await db.Orders
                .Where(o => o.ClientId == clientId)
                .ToListAsync();
            var orderResponses = orders
                .Select(o => OrderResponse.MapToResponse(o))
                .ToList();
            return orderResponses;
        }




        //private async Task<OfferResponse?> GetOfferAsync(int offerId)
        //{
        //    var client = _clientFactory.CreateClient("OfferApiService");
        //    var resp = await client.GetAsync($"/api/offer/{offerId}");
        //    if (!resp.IsSuccessStatusCode) return null;

        //    return await resp.Content.ReadFromJsonAsync<OfferResponse>();
        //}

        //private decimal CalculateBasePrice(OfferResponse offer, decimal days)
        //{
        //    decimal basePrice = 0;

        //    if (days >= 30 && offer.PricePerMonth.HasValue)
        //    {
        //        var months = Math.Floor(days / 30);
        //        basePrice += months * offer.PricePerMonth.Value;
        //        days -= months * 30;
        //    }

        //    if (days >= 7 && offer.PricePerWeek.HasValue)
        //    {
        //        var weeks = Math.Floor(days / 7);
        //        basePrice += weeks * offer.PricePerWeek.Value;
        //        days -= weeks * 7;
        //    }

        //    basePrice += days * offer.PricePerDay;

        //    return basePrice;
        //}

        //private bool HasDateConflict(OfferResponse offer, DateTime start, DateTime end)
        //{
        //    //foreach (var booked in offer.BookedDates)
        //    //{
        //    //    if (start < booked.End && booked.Start < end)
        //    //    {
        //    //        return true; // есть пересечение
        //    //    }
        //    //}
        //    return false; // свободно
        //}




    }
}
