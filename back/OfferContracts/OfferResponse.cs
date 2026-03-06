using Globals.Controllers;
using OfferContracts.RentObj;

namespace OfferContracts
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
        public int? Adults { get; set; }
        public int? Children { get; set; }

       
        public int DaysCount { get; set; }

        public string? StartDate { get; set; }
        public string? EndDate { get; set; }


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

        public double Rating { get; set; }

        public bool? IsRecommended { get; set; }
        public bool? IsTopLocation { get; set; }
        public bool? IsTopCleanliness { get; set; }

    }
}

