using Globals.Controllers;
using Globals.Models;
using OrderApiService.Models.Enum;

namespace OrderApiService.View
{
    public class OrderRequest : IBaseRequest
    {
        public int OfferId { get; set; }
        public int ClientId { get; set; }

        // Количество гостей
        public int TotalPersons { get; set; }

        // Даты проживания
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

        // Время заезда/выезда (необязательные, берутся из Offer если null)
        public TimeSpan? CheckInTime { get; set; }
        public TimeSpan? CheckOutTime { get; set; }

        // Примечание клиента
        public string? ClientNote { get; set; }

        // Предпочтительный способ оплаты
        public PaymentMethod? PaymentMethod { get; set; }
    }

}
