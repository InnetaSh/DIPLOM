using Globals.Models;
using OrderApiService.Models.Enum;

namespace OrderApiService.Models
{
    public class Order : EntityBase
    {
        public int OfferId { get; set; }
        public int ClientId { get; set; }

        // Количество гостей
        public int TotalPersons { get; set; }

        // Даты проживания
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

        // Снимок цены в момент брони 
       // public decimal OfferPricePerDay { get; set; } //все цены копируются в заказ и больше не зависят от объявления

        // Финансы
        public decimal BasePrice { get; set; }        // Без скидок и налогов
        public decimal DiscountPercent { get; set; }  // %
        public decimal DiscountAmount { get; set; }   // Скидка в валюте
        public decimal? DepositAmount { get; set; }   // Сумма депозита
        public decimal TaxAmount { get; set; }        // Налог в валюте
        public decimal TotalPrice { get; set; }       // Итоговая стоимость

        // Оплата
        public PaymentMethod? PaymentMethod { get; set; }
        public bool IsPaid { get; set; }
        public DateTime? PaidAt { get; set; }

        // Время заезда/выезда (может отличаться от Offer)
        public TimeSpan? CheckInTime { get; set; }
        public TimeSpan? CheckOutTime { get; set; }

        // Примечание клиента
        public string? ClientNote { get; set; }

        // Статус
        public OrderStatus Status { get; set; }

        // Дата создания заказа
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    }
}
