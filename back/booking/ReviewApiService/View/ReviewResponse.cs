using Globals.Controllers;

namespace ReviewApiService.View
{
    public class ReviewResponse : IBaseResponse
    {
        public int id { get; set; }
        public int OfferId { get; set; }
        public int UserId { get; set; }
        public string Comment { get; set; }

        public double Staff { get; set; }
        public double Facilities { get; set; }
        public double Cleanliness { get; set; }
        public double Comfort { get; set; }
        public double ValueForMoney { get; set; }
        public double Location { get; set; }

        public double OverallRating { get; set; }

        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }

        public bool IsApproved { get; set; }
    }
}
