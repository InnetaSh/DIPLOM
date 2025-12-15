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
        private readonly IReviewService _reviewService;
        public ReviewController(IReviewService reviewService, IRabbitMqService mqService)
            : base(reviewService, mqService) 
        {
            _reviewService = reviewService;
        }


        [HttpGet("get-by-offerId/{offerId}")]
        public async Task<ActionResult<List<ReviewResponse>>> GetReviewsByOffer(
            [FromRoute] int offerId)
        {
            if (offerId < 0)
                return BadRequest("Review id is required");

            var reviews = await _reviewService.GetReviewsByOfferId(offerId);
            return Ok(reviews.Select(o => MapToResponse(o)).ToList());
        }


        protected override Review MapToModel(ReviewRequest request)
        {
            return ReviewRequest.MapToModel(request);
        }


        protected override ReviewResponse MapToResponse(Review model)
        {
            return ReviewResponse.MapToResponse(model);
        }

    }

}
