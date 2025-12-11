using Globals.Controllers;
using Globals.Models;
using OrderApiService.Models;
using OrderApiService.Models.Enum;

namespace OrderApiService.View
{
    public class OrderResponse : IBaseResponse
    {
        public int id { get; set; }

        public int OfferId { get; set; }
        public int ClientId { get; set; }
        public int TotalPersons { get; set; }

        // Даты проживания
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

        // Финансы
        public decimal BasePrice { get; set; }
        public decimal DiscountPercent { get; set; }
        public decimal DiscountAmount { get; set; }
        public decimal? DepositAmount { get; set; }
        public decimal TaxAmount { get; set; }
        public decimal TotalPrice { get; set; }

        // Оплата
        public PaymentMethod? PaymentMethod { get; set; }
        public bool IsPaid { get; set; }
        public DateTime? PaidAt { get; set; }

        // Время заезда/выезда
        public TimeSpan? CheckInTime { get; set; }
        public TimeSpan? CheckOutTime { get; set; }

        // Примечание
        public string? ClientNote { get; set; }

        // Статус заказа
        public OrderStatus Status { get; set; }

        public DateTime CreatedAt { get; set; }

        // ===== Метод маппинга =====
        public static OrderResponse MapToResponse(Order model)
        {
            return new OrderResponse
            {
                id = model.id,
                OfferId = model.OfferId,
                ClientId = model.ClientId,
                TotalPersons = model.TotalPersons,
                StartDate = model.StartDate,
                EndDate = model.EndDate,
                BasePrice = model.BasePrice,
                DiscountPercent = model.DiscountPercent,
                DiscountAmount = model.DiscountAmount,
                DepositAmount = model.DepositAmount,
                TaxAmount = model.TaxAmount,
                TotalPrice = model.TotalPrice,
                PaymentMethod = model.PaymentMethod,
                IsPaid = model.IsPaid,
                PaidAt = model.PaidAt,
                CheckInTime = model.CheckInTime,
                CheckOutTime = model.CheckOutTime,
                ClientNote = model.ClientNote,
                Status = model.Status,
                CreatedAt = model.CreatedAt
            };
        }
    }
}
