using Globals.Controllers;

namespace ReviewContracts
{
    public class RatingResponse : IBaseResponse
    {
        public int id { get; set; }
        public int OfferId { get; set; }
        public double OverallRating { get; set; }

        
    }

}

