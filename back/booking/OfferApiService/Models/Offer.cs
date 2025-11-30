using Globals.Models;
using OfferApiService.Models.Enum;

namespace OfferApiService.Models
{
    public class Offer : EntityBase
    {

        public Offer()
        {
            CheckInTime = new TimeSpan(15, 0, 0);  
            CheckOutTime = new TimeSpan(11, 0, 0); 
        }

        public string Title { get; set; }
        public string Description { get; set; }

        // Цены
        public decimal PricePerDay { get; set; }
        public decimal? PricePerWeek { get; set; }
        public decimal? PricePerMonth { get; set; }

        // Депозит
        public decimal? DepositPersent { get; set; }
        public PaymentType PaymentStatus { get; set; } //Возвращаемый / нет

        // Налог (%)
        public decimal? Tax { get; set; } // Процент налога от стоимости аренды


        // Правила аренды
        public int MinRentDays { get; set; } = 1;
        public bool AllowPets { get; set; }
        public bool AllowSmoking { get; set; }
        public bool AllowChildren { get; set; }

        // Владелец и объект
        public int OwnerId { get; set; }
        public int RentObjId { get; set; }
        public RentObject.RentObject RentObj { get; set; }

        // Время заезда / выезда (по умолчанию)
        public TimeSpan? CheckInTime { get; set; }
        public TimeSpan? CheckOutTime { get; set; } 

        // Забронированные даты
        public List<BookedDate> BookedDates { get; set; } = new List<BookedDate>();

        public List<Review> Reviews { get; set; } = new List<Review>();

        // Средний рейтинг
        public double Rating
        {
            get
            {
                if (Reviews == null || Reviews.Count == 0)
                    return 0;

                return Reviews.Average(r => r.Rating);
            }
        }
    }

    
}
