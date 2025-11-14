using Globals.Models;

namespace OfferApiService.Models
{
    public class Offer : EntityBase
    {
        public string Title { get; set; }
        public string Description { get; set; }


        public decimal PricePerDay { get; set; }
        public decimal? PricePerWeek { get; set; }
        public decimal? PricePerMonth { get; set; }

   
        public decimal? DiscountPercent { get; set; }   
        public decimal? DiscountAmount { get; set; }    

  
        public decimal? Deposit { get; set; }


        public int MinRentDays { get; set; } = 1;
        public bool AllowPets { get; set; }
        public bool AllowSmoking { get; set; }
        public bool AllowChildren { get; set; }

        public int OwnerId { get; set; }      
        public int RentObjId { get; set; }    

        public List<BookedDate> BookedDates { get; set; } = new List<BookedDate>();
    }

    
}
