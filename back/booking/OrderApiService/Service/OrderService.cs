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
        private readonly IHttpClientFactory _clientFactory;

        public OrderService(IHttpClientFactory clientFactory, IRabbitMqService mqService)
        {
            _clientFactory = clientFactory;
        }

      
        public async Task<Order> AddEntityAsync(Order order)
        {
       
            var offer = await GetOfferAsync(order.OfferId);
            if (offer == null)
                throw new Exception("Offer not found");

          

            if (HasDateConflict(offer, order.StartDate, order.EndDate))
                throw new Exception("Selected dates are not available");



            // 3. Расчёт BasePrice с учётом day/week/month
            var days = (decimal)(order.EndDate - order.StartDate).TotalDays;
            order.BasePrice = CalculateBasePrice(offer, days);

            // 4. Налог и залог
            order.TaxAmount = offer.Tax.HasValue ? offer.Tax.Value / 100m * order.BasePrice : 0;
            order.TotalPrice = order.BasePrice + order.TaxAmount;
            order.DepositAmount = offer.Deposit;

            // 5. Время заезда/выезда
            order.CheckInTime ??= offer.CheckInTime;
            order.CheckOutTime ??= offer.CheckOutTime;

            // 6. Статус и дата создания
            order.Status = OrderStatus.Pending;
            order.CreatedAt = DateTime.UtcNow;

            // 7. Сохраняем заказ
            await base.AddEntityAsync(order);

          

            return order;
        }

    
        private async Task<bool> HasDateConflict(int offerId, DateTime start, DateTime end)
        {
            using var db = new OrderContext();
            return await db.Orders.AnyAsync(o =>
                o.OfferId == offerId &&
                o.Status != OrderStatus.Cancelled &&
                o.StartDate < end &&
                o.EndDate > start
            );
        }

       
        private async Task<OfferResponse?> GetOfferAsync(int offerId)
        {
            var client = _clientFactory.CreateClient("OfferApiService");
            var resp = await client.GetAsync($"/api/offer/{offerId}");
            if (!resp.IsSuccessStatusCode) return null;

            return await resp.Content.ReadFromJsonAsync<OfferResponse>();
        }

        private decimal CalculateBasePrice(OfferResponse offer, decimal days)
        {
            decimal basePrice = 0;

            if (days >= 30 && offer.PricePerMonth.HasValue)
            {
                var months = Math.Floor(days / 30);
                basePrice += months * offer.PricePerMonth.Value;
                days -= months * 30;
            }

            if (days >= 7 && offer.PricePerWeek.HasValue)
            {
                var weeks = Math.Floor(days / 7);
                basePrice += weeks * offer.PricePerWeek.Value;
                days -= weeks * 7;
            }

            basePrice += days * offer.PricePerDay;

            return basePrice;
        }

        private bool HasDateConflict(OfferResponse offer, DateTime start, DateTime end)
        {
            //foreach (var booked in offer.BookedDates)
            //{
            //    if (start < booked.End && booked.Start < end)
            //    {
            //        return true; // есть пересечение
            //    }
            //}
            return false; // свободно
        }



       
    }
}
