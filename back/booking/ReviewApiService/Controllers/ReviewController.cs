using Globals.Abstractions;
using Globals.Controllers;
using Microsoft.AspNetCore.Mvc;
using ReviewApiService.Models;
using ReviewApiService.Service;
using ReviewApiService.Service.Interface;
using ReviewApiService.View;


namespace ReviewApiService.Controllers
{
    public class ReviewController
        : EntityControllerBase<Review, ReviewResponse, ReviewRequest>
    {
        public ReviewController(IReviewService reviewService, IRabbitMqService mqService)
            : base(reviewService, mqService) 
        { 
        }


        //[HttpGet("get-by-offerId")]
        //public async Task<ActionResult<List<OfferResponse>>> GetMainSearch(
        //    [FromQuery] int id)
        //{
        //    if (id<0))
        //        return BadRequest("Review id is required");

        //    var offers = await reviewService.GetMainAvailableOffers(request);
        //    return Ok(offers.Select(o => MapToResponse(o)).ToList());
        //}


        protected override Review MapToModel(ReviewRequest request)
        {
            return new Review
            {
                OfferId = request.OfferId,
                UserId = request.UserId,
                Comment = request.Comment,
                Staff = request.Staff,
                Facilities = request.Facilities,
                Cleanliness = request.Cleanliness,
                Comfort = request.Comfort,
                ValueForMoney = request.ValueForMoney,
                Location = request.Location
            };
        }


        protected override ReviewResponse MapToResponse(Review model)
        {
            return new ReviewResponse
            {
                id = model.id,
                OfferId = model.OfferId,
                UserId = model.UserId,
                Comment = model.Comment,
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
