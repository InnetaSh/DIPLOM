using Globals.Controllers;
using OfferApiService.Models;
using OfferApiService.Models.Dto;
using OfferApiService.Models.Enum;

namespace OfferApiService.Models.Dto
{
    public class OfferRequest : IBaseRequest
    {
        public int id { get; set; }

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
        public bool AllowParties { get; set; }

        public int MaxGuests { get; set; }

        public TimeSpan? CheckInTime { get; set; }
        public TimeSpan? CheckOutTime { get; set; }

        public int OwnerId { get; set; }
        public int RentObjId { get; set; }

        public static Offer MapToModel(OfferRequest request)
        {
            return new Offer
            {
                id = request.id,

                PricePerDay = request.PricePerDay,
                PricePerWeek = request.PricePerWeek,
                PricePerMonth = request.PricePerMonth,

                DepositPersent = request.DepositPersent,
                PaymentStatus = request.PaymentStatus,
                Tax = request.Tax,

                MinRentDays = request.MinRentDays,
                AllowPets = request.AllowPets,
                AllowSmoking = request.AllowSmoking,
                AllowChildren = request.AllowChildren,
                AllowParties = request.AllowParties,

                MaxGuests = request.MaxGuests,

                CheckInTime = request.CheckInTime,
                CheckOutTime = request.CheckOutTime,

                OwnerId = request.OwnerId,
                RentObjId = request.RentObjId

            };
        }
    }
}
