using Globals.Controllers;

namespace ReviewContracts
{
    public class ReviewResponse : IBaseResponse
    {
        public int id { get; set; }
        public int OfferId { get; set; }
        public int UserId { get; set; }
        public int OrderId { get; set; }
        public string? UserName { get; set; }
        public string? UserCountry { get; set; }

        public string? Title { get; set; }
        public string? Description { get; set; }

        public double Staff { get; set; }
        public double Facilities { get; set; }
        public double Cleanliness { get; set; }
        public double Comfort { get; set; }
        public double ValueForMoney { get; set; }
        public double Location { get; set; }

        public double OverallRating { get; set; }

        public DateTime CreatedAt { get; set; }

        public bool IsApproved { get; set; }
    }

}

