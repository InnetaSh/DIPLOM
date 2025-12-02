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

        public bool AllowParties { get; set; }


        public int MaxGuests { get; set; }

        //public bool? IsRecommended { get; set; }            // Booking recommends
        //public bool? IsTopLocation { get; set; }            // High location rating
        //public bool? IsTopCleanliness { get; set; }         // High cleanliness score

        public decimal? CleaningFee { get; set; }
        public decimal? AdditionalGuestFee { get; set; }

        // Владелец и объект
        public int OwnerId { get; set; }
        public int RentObjId { get; set; }
        public RentObject.RentObject RentObj { get; set; }

        // Время заезда / выезда (по умолчанию)
        public TimeSpan? CheckInTime { get; set; }
        public TimeSpan? CheckOutTime { get; set; } 

        // Забронированные даты
        public List<BookedDate> BookedDates { get; set; } = new List<BookedDate>();

        
    }

    
}
