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
        public PaymentType PaymentStatus { get; set; }// статус оплаты(ожидает подтверждения,  подтверждён владельцем и т п )

        public PaymentMethod? PaymentMethod { get; set; }  // Предпочтительный способ оплаты
        public decimal? Tax { get; set; }

        public int MinRentDays { get; set; } = 1;
        public bool AllowPets { get; set; }
        public bool AllowSmoking { get; set; }
        public bool AllowChildren { get; set; }
        public bool AllowParties { get; set; }

        public int MaxGuests { get; set; }

        public decimal? CleaningFee { get; set; }       // Стоимость уборки
        public decimal? AdditionalGuestFee { get; set; } // Доплата за гостя сверх лимита


        // ===== Бесплатная отмена бронирования =====

        public bool FreeCancelEnabled { get; set; }       // Доступна ли бесплатная отмена
        public int? FreeCancelUntilHours { get; set; }    // За сколько часов до заезда можно отменить бесплатно
                                                          // Например: 48 → отмена за 48 часов до даты CheckIn


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
                CleaningFee = request.CleaningFee,
                AdditionalGuestFee = request.AdditionalGuestFee,

                FreeCancelEnabled = request.FreeCancelEnabled,
                FreeCancelUntilHours = request.FreeCancelUntilHours,

                PaymentMethod = request.PaymentMethod,

                CheckInTime = request.CheckInTime,
                CheckOutTime = request.CheckOutTime,

                OwnerId = request.OwnerId,
                RentObjId = request.RentObjId

            };
        }
    }
}
