using Globals.Abstractions;
using Globals.Sevices;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
using OrderApiService.Mappers;
using OrderApiService.Models;
using OrderApiService.Service.Interface;
using OrderContracts;
using OrderContracts.Enum;

namespace OrderApiService.Services
{
    public class OrderService : TableServiceBaseNew<Order, OrderContext>, IOrderService
    {
        public OrderService(OrderContext context, ILogger<OrderService> logger) : base(context, logger)
        {
        }
        //===========================================================================================

        public override async Task<bool> AddEntityAsync(Order order)
        {
            order.TotalPrice = order.OrderPrice + order.TaxAmount;
            order.Status = OrderStatus.Pending;
            order.CreatedAt = DateTime.UtcNow;

            _logger.LogInformation("Adding order for client {ClientId}", order.ClientId);
            var result = await base.AddEntityAsync(order);
            _logger.LogInformation("Order added successfully with id {OrderId}", order.id);

            return result;
        }

        //===========================================================================================

        public async Task<int> AddOrderAsync(Order order)
        {
            order.TotalPrice = order.OrderPrice + order.TaxAmount;
            order.Status = OrderStatus.Pending;
            order.CreatedAt = DateTime.UtcNow;

            _logger.LogInformation("Adding order via AddOrderAsync for client {ClientId}", order.ClientId);

            var res = await _context.Orders.AddAsync(order);
            await _context.SaveChangesAsync();

            _logger.LogInformation("Order created successfully with id {OrderId}", res.Entity.id);
            return res.Entity.id;
        }




        //===========================================================================================
        public async Task<bool> UpdateOrderStatus(int orderId, OrderStatus status)
        {
            var order = await _context.Orders.FindAsync(orderId);

            if (order == null)
            {
                _logger.LogWarning("Order with id {OrderId} not found for status update", orderId);
                return false;
            }

            order.Status = status;
            await _context.SaveChangesAsync();

            _logger.LogInformation("Order {OrderId} status updated to {Status}", orderId, status);
            return true;
        }




        //===========================================================================================

        public async Task<bool> HasDateConflict(DateValidationRequest request)
        {
            var start = DateTime.SpecifyKind(request.Start, DateTimeKind.Utc);
            var end = DateTime.SpecifyKind(request.End, DateTimeKind.Utc);

            _logger.LogInformation(
                "Checking conflict for offer {OfferId} from {Start} to {End}",
                request.OfferId,
                start,
                end
            );

            var conflict = await _context.Orders
                .AsNoTracking()
                .Where(o => o.OfferId == request.OfferId)
                .AnyAsync(o => o.StartDate < end &&
                               o.EndDate > start);

            //var flag = false;
            //foreach (var order in fitOrders)
            //{
            //    if (order.StartDate >= start && order.StartDate < end ) 
            //    {
            //        flag= true;
            //        break;
            //    }
            //    else if(order.EndDate > start && order.EndDate <= end)
            //    {
            //        flag = true;
            //        break;
            //    }
            //}
            if (conflict)
                _logger.LogInformation("Date conflict detected for offer {OfferId}", request.OfferId);
            else
                _logger.LogInformation("No date conflict for offer {OfferId}", request.OfferId);

            return conflict;

            
        }

        //===========================================================================================

        public async Task<List<OrderResponse>> GetOrdersByClientIdAsync(int clientId)
        {
            _logger.LogInformation("Fetching orders for client {ClientId}", clientId);

            var orders = await _context.Orders
                .AsNoTracking()
                .Where(o => o.ClientId == clientId)
                .ToListAsync();

            var orderResponses = orders.Select(o => OrderMapper.MapToResponse(o)).ToList();

            _logger.LogInformation("Found {Count} orders for client {ClientId}", orderResponses.Count, clientId);
            return orderResponses;
        }

        //===========================================================================================

        public async Task<List<OrderResponse>> GetOrdersByOfferIdAsync(int offerId)
        {
            _logger.LogInformation("Fetching orders for offer {OfferId}", offerId);
            var orders = await _context.Orders
                .AsNoTracking()
                .Where(o => o.OfferId == offerId)
                .ToListAsync();
            var orderResponses = orders
                .Select(o => OrderMapper.MapToResponse(o))
                .ToList();
            _logger.LogInformation("Found {Count} orders for offer {OfferId}", orderResponses.Count, offerId);
            return orderResponses;
        }

        //===========================================================================================

        public async Task<List<int>> GetPendingOfferIdsAsync(int ownerId)
        {
            _logger.LogInformation("Fetching pending offers for owner {OwnerId}", ownerId);
            var pendingOfferIds = await _context.Orders
                .AsNoTracking()
                .Where(o => o.OwnerId == ownerId && o.Status == OrderStatus.Pending)
                .Select(o => o.OfferId)
                .Distinct()
                .ToListAsync();

            _logger.LogInformation("Found {Count} pending offers for owner {OwnerId}", pendingOfferIds.Count, ownerId);
            return pendingOfferIds;
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
