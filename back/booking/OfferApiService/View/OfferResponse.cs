using Globals.Controllers;
using OfferApiService.Models;
using OfferApiService.View.RentObj;

namespace OfferApiService.View
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

        public decimal? Tax { get; set; }
        public decimal? TaxAmount { get; set; }        // Налог в валюте
        public decimal? TotalPrice { get; set; }       // Итоговая стоимость


  
        public int MinRentDays { get; set; } = 1;       // Минимальное количество дней аренды
        public bool AllowPets { get; set; }             // Можно ли с животными
        public bool AllowSmoking { get; set; }          // Разрешено ли курение
        public bool AllowChildren { get; set; }         // Можно ли с детьми
        public bool AllowParties { get; set; }          // Разрешены ли вечеринки
        public int MaxGuests { get; set; }              // Максимальное количество гостей


        // =====оценка====================
        public double OverallRating { get; set; }  // общий рейтинг


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
                    ? RentObjResponse.MapToResponse(model.RentObj, baseUrl)
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

