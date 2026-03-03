using Globals.Controllers;
using Globals.Models;
using WebApiGetway.Enum;

namespace WebApiGetway.View
{
    public class OrderResponseForAccountCard : IBaseResponse
    {
        public int id { get; set; }

        public int OrderId { get; set; }
        public int OfferId { get; set; }
        public int ClientId { get; set; }

        public int CityId { get; set; }



        public string Title { get; set; }
        //public string Country { get; set; }


        public string StartDate { get; set; }
        public string EndDate { get; set; }

  
        public decimal TotalPrice { get; set; }


        // Оплата
        public string PaymentStatus { get; set; }

        public TimeSpan? CheckInTime { get; set; }
        public TimeSpan? CheckOutTime { get; set; }

        // Примечание
        public string? ClientNote { get; set; }


        public string? PaymentMethod { get; set; }

        // Статус заказа
        public string? Status { get; set; }

        public DateTime CreatedAt { get; set; }

        public string? MainImageUrl { get; set; }

       
    }
}
