using Globals.Controllers;
using ReviewApiService.Models;

namespace ReviewApiService.View
{
    public class RatingResponse : IBaseResponse
    {
        public int id { get; set; }
        public int OfferId { get; set; }
        public double OverallRating { get; set; }

        
    }

}

