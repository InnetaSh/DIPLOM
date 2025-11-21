using Globals.Controllers;
using Globals.Models;

namespace OrderApiService.View
{
    public class OrderRequest : IBaseRequest
    {
        public int id { get; set; }
        public int OfferId { get; set; }
        public int ClientId { get; set; }

        public int TotalPersons { get; set; }

        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

        // Если не передано — возьмём из Offer
        public TimeSpan? CheckInTime { get; set; }
        public TimeSpan? CheckOutTime { get; set; }

        public string? ClientNote { get; set; }

        public string? PaymentMethod { get; set; }
    }

}
