using Globals.Controllers;
using OfferApiService.Models.Enum;
using OfferApiService.Services.Interfaces.RentObj;
using OfferApiService.View;
using OfferApiService.View.RentObj;

namespace OfferApiService.Models.View
{
    public class OfferResponse : IBaseResponse
    {
        public int id { get; set; }

        public string? Title { get; set; }
        public string? Description { get; set; }
        public decimal PricePerDay { get; set; }
        public decimal? PricePerWeek { get; set; }
        public decimal? PricePerMonth { get; set; }

        public string? CountryTitle { get; set; }
        public string? RegionTitle { get; set; }
        public string? CityTitle { get; set; }
        public string? DistrictTitle { get; set; }

        public int DistanceToCenter { get; set; } // расстояние до центра

        public int GuestCount { get; set; }
        public int DaysCount { get; set; }


        public decimal? OrderPrice { get; set; } // цена для текущего заказа (по количеству дней расчет)

        public decimal? DiscountPercent { get; set; } // процент скидки для текущего заказа

        public decimal? DiscountAmount { get; set; } // сумма скидки для текущего заказа

        public decimal? DepositPersent { get; set; } // процент депозита
        public decimal? DepositAmount { get; set; } // сумма депозита для текущего заказа

        public decimal? Tax { get; set; }
        public decimal? TaxAmount { get; set; }        // Налог в валюте
        public decimal? TotalPrice { get; set; }       // Итоговая стоимость

        public string PaymentStatus { get; set; }// статус оплаты(ожидает подтверждения,  подтверждён владельцем и т п )

        public string PaymentMethod { get; set; }  // Предпочтительный способ оплаты

        public int MinRentDays { get; set; }
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
        //public int RentObjId { get; set; }
        public RentObjResponse? RentObj { get; set; }

        public IEnumerable<BookedDateResponse> BookedDates { get; set; } = new List<BookedDateResponse>();



        public double Rating { get; set; }

        public bool? IsRecommended { get; set; }
        public bool? IsTopLocation { get; set; }
        public bool? IsTopCleanliness { get; set; }



        public static OfferResponse MapToResponse( Offer model,string baseUrl)
        {
            if (model == null)
                throw new ArgumentNullException(nameof(model));

            return new OfferResponse
            {
                id = model.id,

                PricePerDay = model.PricePerDay,
                PricePerWeek = model.PricePerWeek,
                PricePerMonth = model.PricePerMonth,

                DepositPersent = model.DepositPersent,
                PaymentStatus = model.PaymentStatus.ToString(),

                Tax = model.Tax,

                MinRentDays = model.MinRentDays,
                AllowPets = model.AllowPets,
                AllowSmoking = model.AllowSmoking,
                AllowChildren = model.AllowChildren,
                AllowParties = model.AllowParties,

                MaxGuests = model.MaxGuests,

                CleaningFee = model.CleaningFee,
                AdditionalGuestFee = model.AdditionalGuestFee,

                FreeCancelEnabled = model.FreeCancelEnabled,
                FreeCancelUntilHours = model.FreeCancelUntilHours,

                PaymentMethod = model.PaymentMethod.ToString(),

                CheckInTime = model.CheckInTime,
                CheckOutTime = model.CheckOutTime,

                OwnerId = model.OwnerId,

                // === Объект недвижимости ===
                RentObj = model.RentObj != null
                    ? RentObjResponse.MapToResponse(model.RentObj, baseUrl)
                    : null,

                // === Забронированные даты ===
                BookedDates = model.BookedDates?
                    .Select(bd => BookedDateResponse.MapToResponse(bd))
                    .ToList()
                    ?? new List<BookedDateResponse>(),


                //Rating = model.Rating,
                //IsRecommended = model.IsRecommended,
                //IsTopLocation = model.IsTopLocation,
                //IsTopCleanliness = model.IsTopCleanliness
            };
        }

    }
}

