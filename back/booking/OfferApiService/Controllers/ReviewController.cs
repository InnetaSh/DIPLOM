using Globals.Abstractions;
using Globals.Controllers;
using Microsoft.AspNetCore.Mvc;
using OfferApiService.Models;
using OfferApiService.Service.Interface;
using OfferApiService.View;

namespace OfferApiService.Controllers
{
    public class ReviewController
        : EntityControllerBase<Review, ReviewResponse, ReviewRequest>
    {
        public ReviewController(IReviewService reviewService, IRabbitMqService mqService)
            : base(reviewService, mqService) 
        { 
        }

        protected override Review MapToModel(ReviewRequest request)
        {
            return new Review
            {
                Rating = request.Rating,
                Comment = request.Comment,
                OfferId = request.OfferId,
                UserId = request.UserId,
                Photos = request.Photos ?? new List<string>(),
                Cleanliness = request.Cleanliness,
                Comfort = request.Comfort,
                Location = request.Location,
                Service = request.Service,
                ValueForMoney = request.ValueForMoney
                
            };
        }


        protected override ReviewResponse MapToResponse(Review model)
        {
            return new ReviewResponse
            {
                id = model.id,
                Rating = model.Rating,
                Comment = model.Comment,
                OfferId = model.OfferId,
                UserId = model.UserId,
                Response = model.Response,
                CreatedAt = model.CreatedAt,
                IsApproved = model.IsApproved,
                IsAnonymous = model.IsAnonymous,
                Photos = model.Photos ?? new List<string>(),
                Cleanliness = model.Cleanliness,
                Comfort = model.Comfort,
                Location = model.Location,
                Service = model.Service,
                ValueForMoney = model.ValueForMoney
            };
        }

    }

}
