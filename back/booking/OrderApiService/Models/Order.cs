using Globals.Models;
using OrderApiService.Models.Enum;

namespace OrderApiService.Models
{
    public class Order : EntityBase
    {
        // ===== Связь с предложением и клиентом =====
        public int OfferId { get; set; }          // ID бронируемого объявления
        public int ClientId { get; set; }         // ID клиента, сделавшего заказ

        // ===== Количество гостей =====
        public int TotalPersons { get; set; }     // Общее количество гостей для этого заказа

        // ===== Даты проживания =====
        public DateTime StartDate { get; set; }   // Дата заезда
        public DateTime EndDate { get; set; }     // Дата выезда

        // ===== Финансовая информация =====

        public decimal BasePrice { get; set; }        // Цена без скидок и налогов
        public decimal DiscountPercent { get; set; }  // Процент скидки
        public decimal DiscountAmount { get; set; }   // Сумма скидки в валюте
        public decimal? DepositAmount { get; set; }   // Сумма депозита (если есть)
        public decimal TaxAmount { get; set; }        // Налог в валюте
        public decimal TotalPrice { get; set; }       // Итоговая стоимость с учётом всех скидок и налогов

        // ===== Оплата =====
        public PaymentMethod? PaymentMethod { get; set; } // Способ оплаты (может быть null, если не оплачено)
        public bool IsPaid { get; set; }                  // Оплачено ли
        public DateTime? PaidAt { get; set; }            // Дата и время оплаты (если есть)

        // ===== Время заезда / выезда (может отличаться от Offer) =====
        public TimeSpan? CheckInTime { get; set; }       // Время заезда для конкретного заказа
        public TimeSpan? CheckOutTime { get; set; }      // Время выезда для конкретного заказа

        // ===== Примечания =====
        public string? ClientNote { get; set; }          // Примечание от клиента

        // ===== Статус заказа =====
        public OrderStatus Status { get; set; }          // Текущий статус заказа (новый, подтверждён, отменён и т.д.)

        // ===== Дата создания заказа =====
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow; // Дата создания записи
    }
}
