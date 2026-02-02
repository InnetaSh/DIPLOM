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
        //public decimal? DepositAmount { get; set; }
        public decimal TaxAmount { get; set; }
        public decimal TotalPrice { get; set; }


        //  Бесплатная отмена бронирования =====

       // public bool FreeCancelEnabled { get; set; }       // Доступна ли бесплатная отмена  

        // Оплата
        public string PaymentStatus { get; set; }
        //public string PaymentMethod { get; set; }
       // public DateTime? PaidAt { get; set; }

        // Время заезда/выезда
        public TimeSpan? CheckInTime { get; set; }
        public TimeSpan? CheckOutTime { get; set; }

        // Примечание
        public string? ClientNote { get; set; }

        // Статус заказа
        public string? Status { get; set; }

        public DateTime CreatedAt { get; set; }

        public static OrderResponse MapToOrderResponse(
         CreateOrderRequest request,
         Dictionary<string, object> offer,
         int userId,
         string titleOffer,
         string countryTitle,
         string cityTitle,
         object address)
        {
           // int freeCancelUntilHours = int.Parse(offer["freeCancelUntilHours"].ToString());
           // var paidAt = request.StartDate.AddHours(-freeCancelUntilHours);

            return new OrderResponse
            {
                OfferId = request.OfferId,
                ClientId = userId,
                Guests = request.Guests,
                Title = titleOffer,
                Country = countryTitle,
                City = cityTitle,
                Address = address.ToString(),
                StartDate = request.StartDate,
                EndDate = request.EndDate,

                BasePrice = decimal.Parse(offer["orderPrice"].ToString()),
                DiscountPercent = decimal.Parse(offer["discountPercent"].ToString()),
                DiscountAmount = decimal.Parse(offer["discountAmount"].ToString()),
                //DepositAmount = decimal.Parse(offer["depositAmount"].ToString()),
                TaxAmount = decimal.Parse(offer["taxAmount"].ToString()),
                TotalPrice = decimal.Parse(offer["totalPrice"].ToString()),
                //FreeCancelEnabled = bool.Parse(offer["freeCancelEnabled"].ToString()),
                //PaidAt = paidAt,
                CheckInTime = TimeSpan.Parse(offer["checkInTime"].ToString()),
                CheckOutTime = TimeSpan.Parse(offer["checkOutTime"].ToString()),
                ClientNote = request.ClientNote,
                Status = "Pending",
                //PaymentStatus = offer["paymentStatus"].ToString(),
                //PaymentMethod = offer["paymentMethod"].ToString(),
            };
        }
    }
}
