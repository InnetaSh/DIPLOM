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
        public int Guests { get; set; }

        // Даты проживания
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

        // Финансы
        public decimal OrderPrice { get; set; }
        public decimal DiscountPercent { get; set; }
        public decimal DiscountAmount { get; set; }
        public decimal? DepositAmount { get; set; }
        public decimal TaxAmount { get; set; }
        public decimal TotalPrice { get; set; }

        public bool FreeCancelEnabled { get; set; }       // Доступна ли бесплатная отмена

 
        public DateTime? PaidAt { get; set; }

        // Время заезда/выезда
        public TimeSpan? CheckInTime { get; set; }
        public TimeSpan? CheckOutTime { get; set; }

        // Примечание
        public string? ClientNote { get; set; }

        // Статус заказа
        public string? Status { get; set; }
        // Оплата
        public string? PaymentMethod { get; set; }
        public DateTime CreatedAt { get; set; }

        // ===== Метод маппинга =====
        public static OrderResponse MapToResponse(Order model)
        {
            if (model == null)
                throw new ArgumentNullException(nameof(model));

            return new OrderResponse
            {
                // ===== Идентификатор =====
                id = model.id,

                // ===== Основные данные =====
                OfferId = model.OfferId,
                ClientId = model.ClientId,
                Guests = model.Guests,

                // ===== Даты проживания =====
                StartDate = model.StartDate,
                EndDate = model.EndDate,

                // ===== Финансы =====
                OrderPrice = model.OrderPrice,
                DiscountPercent = model.DiscountPercent,
                DiscountAmount = model.DiscountAmount,
                DepositAmount = model.DepositAmount,
                TaxAmount = model.TaxAmount,
                TotalPrice = model.TotalPrice,

                // ===== Бесплатная отмена / оплата =====
                FreeCancelEnabled = model.FreeCancelEnabled,
                PaidAt = model.PaidAt,

                // ===== Время заезда / выезда =====
                CheckInTime = model.CheckInTime,
                CheckOutTime = model.CheckOutTime,

                // ===== Примечание =====
                ClientNote = model.ClientNote,

                // ===== Статус и оплата =====
                Status = model.Status.ToString(),
                PaymentMethod = model.PaymentMethod,

                // ===== Системные поля =====
                CreatedAt = model.CreatedAt
            };
        }

    }
}
