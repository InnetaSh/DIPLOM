using Globals.Controllers;
using OfferApiService.Models.Enum;

namespace OfferApiService.Models.Dto
{
    public class OfferRequest : IBaseRequest
    {
        public int id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }

        public decimal PricePerDay { get; set; }
        public decimal? PricePerWeek { get; set; }
        public decimal? PricePerMonth { get; set; }

        public decimal? DepositPersent { get; set; }
        public PaymentType PaymentStatus { get; set; }
        public decimal? Tax { get; set; }

        public int MinRentDays { get; set; } = 1;
        public bool AllowPets { get; set; }
        public bool AllowSmoking { get; set; }
        public bool AllowChildren { get; set; }

        public TimeSpan? CheckInTime { get; set; }
        public TimeSpan? CheckOutTime { get; set; }

        public int OwnerId { get; set; }
        public int RentObjId { get; set; }
    }
}
