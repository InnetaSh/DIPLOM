using Globals.Controllers;
using ReviewApiService.Models;

namespace ReviewApiService.View
{
    public class ReviewRequest : IBaseRequest
    {
        public int OrderId { get; set; }
        public int UserId { get; set; }
        public int OfferId { get; set; }

        // Оценки по категориям (1-10)
        public double Staff { get; set; }
        public double Facilities { get; set; }
        public double Cleanliness { get; set; }
        public double Comfort { get; set; }
        public double ValueForMoney { get; set; }
        public double Location { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        // Опционально: статус модерации
        public bool IsApproved { get; set; } = true;

        public static Review MapToModel(ReviewRequest request)
        {
            return new Review
            {
                OrderId = request.OrderId,
                OfferId = request.OfferId,
                UserId = request.UserId,
                Staff = request.Staff,
                Facilities = request.Facilities,
                Cleanliness = request.Cleanliness,
                Comfort = request.Comfort,
                ValueForMoney = request.ValueForMoney,
                Location = request.Location,
                CreatedAt = DateTime.UtcNow,
                IsApproved = true,
            };
        }
    }
}
