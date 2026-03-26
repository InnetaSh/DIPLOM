using OfferApiService.Models;
using OfferApiService.Models.RentObjModel;
using OfferContracts;
using OfferContracts.RentObj;

namespace OfferApiService.Mappers
{
    public static class OfferMapper
    {
        public static Offer MapToModel( OfferRequest request, string baseUrl)
        {
            if (request.RentObj == null)
                throw new ArgumentException("RentObj is required");

            return new Offer
            {
                PricePerDay = request.PricePerDay,
                PricePerWeek = request.PricePerWeek,
                PricePerMonth = request.PricePerMonth,

                //DepositPersent = request.DepositPersent,
                //DepositStatus = depositStatus,
                Tax = request.Tax,

                MinRentDays = request.MinRentDays,
                AllowPets = request.AllowPets,
                AllowSmoking = request.AllowSmoking,
                AllowChildren = request.AllowChildren,
                AllowParties = request.AllowParties,

                MaxGuests = request.MaxGuests,

                //FreeCancelEnabled = request.FreeCancelEnabled,
                //FreeCancelUntilHours = request.FreeCancelUntilHours,

                //PaymentMethod = paymentMethod,

                CheckInTime = request.CheckInTime,
                CheckOutTime = request.CheckOutTime,

                OwnerId = request.OwnerId,
                RentObj = RentObjMapper.MapToModel(request.RentObj),
            };
        }


        public static OfferResponse MapToResponse( Offer model, string baseUrl)
        {
            if (model == null)
                throw new ArgumentNullException(nameof(model));

            return new OfferResponse
            {
                id = model.id,

                PricePerDay = model.PricePerDay,
                PricePerWeek = model.PricePerWeek,
                PricePerMonth = model.PricePerMonth,

                //DepositPersent = model.DepositPersent,
                //DepositStatus = model.DepositStatus.ToString(),

                Tax = model.Tax,

                MinRentDays = model.MinRentDays,
                AllowPets = model.AllowPets,
                AllowSmoking = model.AllowSmoking,
                AllowChildren = model.AllowChildren,
                AllowParties = model.AllowParties,
                MaxGuests = model.MaxGuests,


                //FreeCancelEnabled = model.FreeCancelEnabled,
                //FreeCancelUntilHours = model.FreeCancelUntilHours,

                //PaymentMethod = model.PaymentMethod.ToString(),

                CheckInTime = model.CheckInTime,
                CheckOutTime = model.CheckOutTime,

                OwnerId = model.OwnerId,

                // === Объект недвижимости ===
                RentObj = model.RentObj != null
                    ? RentObjMapper.MapToResponse(model.RentObj, baseUrl)
                    : null,

                //// === Забронированные даты ===
                //BookedDates = model.BookedDates?
                //    .Select(bd => BookedDateResponse.MapToResponse(bd))
                //    .ToList()
                //    ?? new List<BookedDateResponse>(),



            };
        }

    }
}
