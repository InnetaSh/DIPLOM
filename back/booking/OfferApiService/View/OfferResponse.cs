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

        public decimal DiscountAmount { get; set; } // сумма скидки для текущего заказа

        public decimal? DepositPersent { get; set; } // процент депозита
        public decimal? DepositAmount { get; set; } // сумма депозита для текущего заказа

        public decimal? Tax { get; set; }
        public decimal TaxAmount { get; set; }        // Налог в валюте
        public decimal TotalPrice { get; set; }       // Итоговая стоимость

        public PaymentType PaymentStatus { get; set; }
   

        public int MinRentDays { get; set; }
        public bool AllowPets { get; set; }
        public bool AllowSmoking { get; set; }
        public bool AllowChildren { get; set; }
        public bool AllowParties { get; set; }


        public int MaxGuests { get; set; }

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
            return new OfferResponse
            {
                id = model.id,

                PricePerDay = model.PricePerDay,
                PricePerWeek = model.PricePerWeek,
                PricePerMonth = model.PricePerMonth,

                DepositPersent = model.DepositPersent,
                PaymentStatus = model.PaymentStatus,

                Tax = model.Tax,

                MinRentDays = model.MinRentDays,
                AllowPets = model.AllowPets,
                AllowSmoking = model.AllowSmoking,
                AllowChildren = model.AllowChildren,
                AllowParties = model.AllowParties,

                MaxGuests = model.MaxGuests,
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
        public static OfferResponse MapToFullResponse(Offer model, decimal? userDiscountPercent, int rentalDays, string baseUrl)
        {
            var response = MapToResponse(model, baseUrl);

           
            response.OwnerId = model.OwnerId;
            response.PaymentStatus = model.PaymentStatus;
            response.DepositPersent = model.DepositPersent;
            response.Tax = model.Tax;
            response.BookedDates = model.BookedDates?.Select(BookedDateResponse.MapToResponse).ToList()
                                   ?? new List<BookedDateResponse>();
            //response.Rating = model.Rating;
            //response.IsRecommended = model.IsRecommended;
            //response.IsTopLocation = model.IsTopLocation;
            //response.IsTopCleanliness = model.IsTopCleanliness;

            // Расчёт цен
            var orderPrice = response.PricePerDay * rentalDays;
            var discountPercent = userDiscountPercent ?? 0;
            var discountAmount = orderPrice * discountPercent / 100;
            var depositAmount = response.DepositPersent.HasValue ? orderPrice * response.DepositPersent.Value / 100 : 0;
            var taxAmount = response.Tax.HasValue ? (orderPrice - discountAmount) * response.Tax.Value / 100 : 0;
            var totalPrice = orderPrice - discountAmount + depositAmount + taxAmount;

            response.OrderPrice = orderPrice;
            response.DiscountPercent = discountPercent;
            response.DiscountAmount = discountAmount;
            response.DepositAmount = depositAmount;
            response.TaxAmount = taxAmount;
            response.TotalPrice = totalPrice;

            return response;
        }


    }
}

