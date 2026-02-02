using Globals.Controllers;
using Globals.Models;
using WebApiGetway.Enum;

namespace WebApiGetway.View
{
    public class OrderDto : IBaseRequest
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

        //public bool FreeCancelEnabled { get; set; }       // Доступна ли бесплатная отмена
        // ===== Оплата до=====
        //public DateTime? PaidAt { get; set; }            // Дата и время оплаты (если есть)

        // Время заезда/выезда (необязательные, берутся из Offer если null)
        public TimeSpan? CheckInTime { get; set; }
        public TimeSpan? CheckOutTime { get; set; }

        // Примечание клиента
        public string? ClientNote { get; set; }
        // ===== Статус заказа =====
        public OrderStatus Status { get; set; }          // Текущий статус заказа (новый, подтверждён, отменён и т.д.)
        public string PaymentMethod { get; set; }



        public static OrderDto MapToOrderDto(
              CreateOrderRequest request,
              Dictionary<string, object> offer,
              int userId)
        {
            //int freeCancelUntilHours = int.Parse(offer["freeCancelUntilHours"].ToString());
            //var paidAt = request.StartDate.AddHours(-freeCancelUntilHours);

            return new OrderDto
            {
                OfferId = request.OfferId,
                ClientId = userId,
                Guests = request.Guests,
                StartDate = request.StartDate,
                EndDate = request.EndDate,

                OrderPrice = decimal.Parse(offer["orderPrice"].ToString()),
                DiscountPercent = decimal.Parse(offer["discountPercent"].ToString()),
                DiscountAmount = decimal.Parse(offer["discountAmount"].ToString()),
               // DepositAmount = decimal.Parse(offer["depositAmount"].ToString()),
                TaxAmount = decimal.Parse(offer["taxAmount"].ToString()),
                TotalPrice = decimal.Parse(offer["totalPrice"].ToString()),
                //FreeCancelEnabled = bool.Parse(offer["freeCancelEnabled"].ToString()),
               // PaidAt = paidAt,
                CheckInTime = TimeSpan.Parse(offer["checkInTime"].ToString()),
                CheckOutTime = TimeSpan.Parse(offer["checkOutTime"].ToString()),

                ClientNote = request.ClientNote,
                Status = 0,
                //PaymentMethod = offer["paymentMethod"].ToString(),
            };
        }
    }
}
