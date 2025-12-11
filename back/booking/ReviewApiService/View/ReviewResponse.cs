using Globals.Controllers;
using ReviewApiService.Models;

namespace ReviewApiService.View
{
    public class ReviewResponse : IBaseResponse
    {
        public int id { get; set; }
        public int OfferId { get; set; }
        public int UserId { get; set; }


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


        public static ReviewResponse MapToResponse(Review model)
        {
            return new ReviewResponse
            {
                id = model.id,
                OfferId = model.OfferId,
                UserId = model.UserId,
                Staff = model.Staff,
                Facilities = model.Facilities,
                Cleanliness = model.Cleanliness,
                Comfort = model.Comfort,
                ValueForMoney = model.ValueForMoney,
                Location = model.Location,
                OverallRating = model.OverallRating,
                CreatedAt = model.CreatedAt,
                UpdatedAt = model.UpdatedAt,
                IsApproved = model.IsApproved
            };
        }
    }

}

