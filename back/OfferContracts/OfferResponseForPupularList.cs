using Globals.Controllers;
using OfferContracts.RentObj;

namespace OfferContracts
{
    public class OfferResponseForPupularList : IBaseResponse
    {
        public int id { get; set; }

        public string? Title { get; set; } 
      
        public RentObjShortPopularResponse RentObj { get; set; }
        public double? OverallRating { get; set; }

    }
}
