using Globals.Controllers;
using Globals.Models;
using WebApiGetway.Enum;

namespace WebApiGetway.View
{
    public class OrderResponse : IBaseResponse
    {
        public int id { get; set; }

        public int OfferId { get; set; }
        public int ClientId { get; set; }
        public int Guests { get; set; }

        public string Title { get; set; }
        public string Country { get; set; }
        public string City { get; set; }
        public string Address { get; set; }

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


        //  Бесплатная отмена бронирования =====

        public bool FreeCancelEnabled { get; set; }       // Доступна ли бесплатная отмена  

        // Оплата
        public string PaymentStatus { get; set; }
        public string PaymentMethod { get; set; }
        public DateTime? PaidAt { get; set; }

        // Время заезда/выезда
        public TimeSpan? CheckInTime { get; set; }
        public TimeSpan? CheckOutTime { get; set; }

        // Примечание
        public string? ClientNote { get; set; }

        // Статус заказа
        public string? Status { get; set; }

        public DateTime CreatedAt { get; set; }

      
    }
}
