using Globals.Controllers;
using OfferContracts.RentObj;

namespace OfferContracts
{
    public class OfferShortResponse : IBaseResponse
    {
        public int id { get; set; }

        public string? Title { get; set; } //название 
        public string? Description { get; set; }

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

       

        // Метки
        public bool? IsRecommended { get; set; }
        public bool? IsTopLocation { get; set; }
        public bool? IsTopCleanliness { get; set; }
         
        public double OverallRating { get; set; }  // общий рейтинг

        // Основная информация о жилье
        public RentObjShortResponse RentObj { get; set; }
    }
}
