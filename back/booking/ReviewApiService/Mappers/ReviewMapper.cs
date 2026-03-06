using ReviewApiService.Models;
using ReviewContracts;

namespace ReviewApiService.Mappers
{
    public static class ReviewMapper
    {
        public static Review MapToModel( ReviewRequest request)
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

        public static ReviewResponse MapToResponse( Review model)
        {
            if (model == null)
                throw new ArgumentNullException(nameof(model));
            return new ReviewResponse
            {
                id = model.id,
                OrderId = model.OrderId,
                UserId = model.UserId,
                OfferId = model.OfferId,
                Staff = model.Staff,
                Facilities = model.Facilities,
                Cleanliness = model.Cleanliness,
                Comfort = model.Comfort,
                ValueForMoney = model.ValueForMoney,
                Location = model.Location,
                OverallRating = model.OverallRating,
                CreatedAt = model.CreatedAt,
                IsApproved = model.IsApproved
            };
        }
    }
}
