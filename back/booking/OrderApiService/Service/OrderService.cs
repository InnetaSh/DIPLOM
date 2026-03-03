using Globals.Abstractions;
using Globals.Sevices;
using Microsoft.EntityFrameworkCore;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using OrderApiService.Models;
using OrderApiService.Models.Enum;
using OrderApiService.Service.Interface;
using OrderApiService.View;
using System.Collections.Generic;
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
                await using var db = new OrderContext();

                order.TotalPrice = order.OrderPrice + order.TaxAmount;
                order.Status = OrderStatus.Pending;
                order.CreatedAt = DateTime.UtcNow;

                var res = db.Orders.Add(order);
                await db.SaveChangesAsync();

                return res.Entity.id;
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

        public async Task<bool> HasDateConflict(int orderId, int offerId, DateTime start, DateTime end)
        {
            using var db = new OrderContext();

            var fitOrders = db.Orders.Where(o => o.id == orderId && o.OfferId == offerId).ToList();
            var flag = false;
            foreach (var order in fitOrders)
            {
                if (order.StartDate >= start && order.StartDate < end ) 
                {
                    flag= true;
                    break;
                }
                else if(order.EndDate > start && order.EndDate <= end)
                {
                    flag = true;
                    break;
                }
            }
            return flag;

            //return await db.Orders.AnyAsync(o =>
            //    o.id == orderId &&
            //    o.OfferId == offerId &&
            //    ((o.StartDate >= start && o.StartDate <= end) || (o.EndDate >= start && o.EndDate <= end))
            //);
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

        //===========================================================================================

        public async Task<List<OrderResponse>> GetOrdersByOfferIdAsync(int offerId)
        {
            using var db = new OrderContext();
            var orders = await db.Orders
                .Where(o => o.OfferId == offerId)
                .ToListAsync();
            var orderResponses = orders
                .Select(o => OrderResponse.MapToResponse(o))
                .ToList();
            return orderResponses;
        }

        //===========================================================================================

        public async Task<List<int>> GetPendingOfferIdsAsync(int ownerId)
        {
            using var db = new OrderContext();

            return await db.Orders
                .Where(o => o.OwnerId == ownerId && o.Status == OrderStatus.Pending)
                .Select(o => o.OfferId)
                .Distinct()         
                .ToListAsync();
        }

        //public async Task<bool> HasPendingOrderAsync(int ownerId)
        //{
        //    using var db = new OrderContext();

        //    return await db.Orders
        //        .AnyAsync(o => o.OwnerId == ownerId && o.Status == OrderStatus.Pending);
        //}




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
