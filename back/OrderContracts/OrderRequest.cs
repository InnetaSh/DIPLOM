using Globals.Controllers;
using OrderContracts.Enum;

namespace OrderContracts
{
    public class OrderRequest : IBaseRequest
    {
        public int OfferId { get; set; }
        public int ClientId { get; set; }
        public int OwnerId { get; set; }

        public string? ClientEmail { get; set; }
        public string? ClientPhoneNumber { get; set; }

        // Количество гостей
        public int Guests { get; set; }

        public int Adults { get; set; }
        public int Children { get; set; }
        public string? MainGuestFirstName { get; set; }
        public string? MainGuestLastName { get; set; }

        // Даты проживания
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

        // ===== Финансовая информация =====

        public decimal OrderPrice { get; set; }        // Цена без скидок и налогов
        public decimal DiscountPercent { get; set; }  // Процент скидки
        public decimal DiscountAmount { get; set; }   // Сумма скидки в валюте
        public decimal TaxAmount { get; set; }        // Налог в валюте
        public decimal TotalPrice { get; set; }       // Итоговая стоимость с учётом всех скидок и налогов

       // public bool FreeCancelEnabled { get; set; }       // Доступна ли бесплатная отмена
        // ===== Оплата до=====
        public DateTime? PaidAt { get; set; }            // Дата и время оплаты (если есть)

        // Время заезда/выезда (необязательные, берутся из Offer если null)
        public TimeSpan? CheckInTime { get; set; }
        public TimeSpan? CheckOutTime { get; set; }

        // Примечание клиента
        public string? ClientNote { get; set; }
        // ===== Статус заказа =====
        public OrderStatus Status { get; set; }          // Текущий статус заказа (новый, подтверждён, отменён и т.д.)
                                                         //public string PaymentMethod { get; set; }


        public bool? isBusinessTrip { get; set; } = false;

        public string? PaymentMethod { get; set; }


    }
}
