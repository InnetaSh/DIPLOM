using Globals.Controllers;
using Globals.Models;
using OrderApiService.Models.Enum;

namespace OrderApiService.View
{
    public class OrderResponse : IBaseResponse
    {
        public int id { get; set; }
        public int OfferId { get; set; }
        public int ClientId { get; set; }

        public int TotalPersons { get; set; }

        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

        // Snapshot цен
        public decimal OfferPricePerDay { get; set; }
        public decimal BasePrice { get; set; }
        public decimal DiscountPercent { get; set; }
        public decimal DiscountAmount { get; set; }
        public decimal TaxAmount { get; set; }
        public decimal TotalPrice { get; set; }
        public decimal? DepositAmount { get; set; }

        // Оплата
        public bool IsPaid { get; set; }
        public string? PaymentMethod { get; set; }
        public DateTime? PaidAt { get; set; }

        // Время въезда/выезда
        public TimeSpan? CheckInTime { get; set; }
        public TimeSpan? CheckOutTime { get; set; }

        public string? ClientNote { get; set; }

        public OrderStatus Status { get; set; }

        public DateTime CreatedAt { get; set; }
    }

}
