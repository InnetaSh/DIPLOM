using Globals.Controllers;
using OfferApiService.Models.Enum;
using OfferApiService.Services.Interfaces.RentObject;
using OfferApiService.View;
using OfferApiService.View.RentObject;

namespace OfferApiService.Models.View
{
    public class OfferResponse : IBaseResponse
    {
        public int id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }

        public decimal PricePerDay { get; set; }
        public decimal? PricePerWeek { get; set; }
        public decimal? PricePerMonth { get; set; }


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

        public IEnumerable<ReviewResponse> Reviews { get; set; } = new List<ReviewResponse>();

        public double Rating { get; set; }

        public bool? IsRecommended { get; set; }
        public bool? IsTopLocation { get; set; }
        public bool? IsTopCleanliness { get; set; }



        public static OfferResponse MapToResponse(Offer model, IRentObjParamValueService paramValueService, string baseUrl)
        {
            return new OfferResponse
            {
                id = model.id,
                Title = model.Title,
                Description = model.Description,
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
                RentObj = RentObjResponse.MapToResponse(model.RentObj, paramValueService, baseUrl),
                BookedDates = model.BookedDates?.Select(bd => new BookedDateResponse
                 {
                     id = bd.id,
                     Start = bd.Start,
                     End = bd.End,
                     OfferId = bd.OfferId
                 }).ToList() ?? new List<BookedDateResponse>()
            };
        }
    }
}
