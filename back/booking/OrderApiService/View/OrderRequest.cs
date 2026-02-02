using Globals.Controllers;
using Globals.Models;
using OrderApiService.Models;
using OrderApiService.Models.Enum;

namespace OrderApiService.View
{
    public class OrderRequest : IBaseRequest
    {
        public int OfferId { get; set; }
        public int ClientId { get; set; }

        // Количество гостей
        public int Guests { get; set; }

        // Даты проживания
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

        // ===== Финансовая информация =====

        public decimal OrderPrice { get; set; }        // Цена без скидок и налогов
        public decimal DiscountPercent { get; set; }  // Процент скидки
        public decimal DiscountAmount { get; set; }   // Сумма скидки в валюте
        //public decimal? DepositAmount { get; set; }   // Сумма депозита (если есть)
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




        // ===== Метод для конвертации в модель Order =====
        public static Order MapToModel(OrderRequest request)
        {
            return new Order
            {
                OfferId = request.OfferId,
                ClientId = request.ClientId,
                Guests = request.Guests,

                StartDate = request.StartDate,
                EndDate = request.EndDate,

                // ===== Финансы =====
                OrderPrice = request.OrderPrice,
                DiscountPercent = request.DiscountPercent,
                DiscountAmount = request.DiscountAmount,
               // DepositAmount = request.DepositAmount,
                TaxAmount = request.TaxAmount,
                TotalPrice = request.TotalPrice,

                // ===== Бесплатная отмена / оплата =====
               // FreeCancelEnabled = request.FreeCancelEnabled,
                //PaidAt = request.PaidAt,

                // ===== Время заезда / выезда =====
                CheckInTime = request.CheckInTime,
                CheckOutTime = request.CheckOutTime,

                // ===== Дополнительно =====
                ClientNote = request.ClientNote,

                // ===== Статус =====
                Status = request.Status == 0
                    ? OrderStatus.Pending
                    : request.Status,

               // PaymentMethod = request.PaymentMethod,

                // ===== Системные поля =====
                CreatedAt = DateTime.UtcNow
            };
        }
    }
}
