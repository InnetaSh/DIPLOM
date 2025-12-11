using Globals.Controllers;
using OfferApiService.View.RentObj;

namespace OfferApiService.Models.View
{
    public class OfferShortResponse : IBaseResponse
    {
        public int id { get; set; }

        public string? Title { get; set; } //название 
        //public string? Description { get; set; }

        public int DistanceToCenter { get; set; } // расстояние до центра

        public int GuestCount { get; set; }
        public int DaysCount { get; set; }
        // Цена


        public decimal PricePerDay { get; set; }
        public decimal? PricePerWeek { get; set; }
        public decimal? PricePerMonth { get; set; }

        public decimal? Tax { get; set; }
        public decimal TaxAmount { get; set; }        // Налог в валюте
        public decimal? OrderPrice { get; set; } // цена для текущего заказа (по количеству дней расчет)
        public decimal? TotalPrice { get; set; }       // Итоговая стоимость

        // Рейтинг
        public double Rating { get; set; }

        // Метки
        public bool? IsRecommended { get; set; }
        public bool? IsTopLocation { get; set; }
        public bool? IsTopCleanliness { get; set; }

        // Основная информация о жилье
        public RentObjShortResponse RentObj { get; set; }



        public static OfferShortResponse MapToShortResponse(Offer model, string baseUrl)
        {
            var firstImage = model.RentObj.Images?.FirstOrDefault();

            return new OfferShortResponse
            {
                id = model.id,
                Tax = model.Tax,
                PricePerDay = model.PricePerDay,
                PricePerWeek = model.PricePerWeek,
                PricePerMonth = model.PricePerMonth,



                //Rating = model.Rating,
                //IsRecommended = model.IsRecommended,
                //IsTopLocation = model.IsTopLocation,
                //IsTopCleanliness = model.IsTopCleanliness,

                RentObj = model.RentObj != null
                    ? RentObjShortResponse.MapToShortResponse(model.RentObj, baseUrl)
                    : null,
            };
        }

    }
}
