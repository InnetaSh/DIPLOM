using Globals.Abstractions;
using Globals.Controllers;
using Microsoft.AspNetCore.Mvc;
using ReviewApiService.Models;
using ReviewApiService.Service;
using ReviewApiService.Service.Interface;
using ReviewApiService.View;


namespace ReviewApiService.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
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


        [HttpGet("get-by-userId/{userId}")]
        public async Task<ActionResult<List<ReviewResponse>>> GetReviewsByUser(
          [FromRoute] int userId)
        {
            if (userId < 0)
                return BadRequest("Review id is required");

            var reviews = await _reviewService.GetReviewsByUserId(userId);
            return Ok(reviews.Select(o => MapToResponse(o)).ToList());
        }


        //===========================================================================================
        //  получение рейтинга для списка популярных обьявлений
        //===========================================================================================

        [HttpGet("search/offers/rating")]
        public async Task<ActionResult<List<RatingResponse>>> GetRatingPopularOffers(
            [FromQuery] List<int> idList)
        {


            var result = new List<RatingResponse>();
            foreach (var offerId in idList)
            {
                var exists = await _reviewService.ExistsEntityAsync(offerId);
                if (!exists)
                    return NotFound(new { message = $"offerId {offerId} not found" });

                var averageRating = await _reviewService.GetRatingByOfferId(offerId);
                var ratingResponse = new RatingResponse
                {
                    OfferId = offerId,
                    OverallRating = averageRating
                };
                result.Add(ratingResponse);
            }

            return Ok(result);
        }

        //===========================================================================================
        //  получение рейтинга для  обьявления по id
        //===========================================================================================

        [HttpGet("search/offers/rating/{offerId}")]
        public async Task<ActionResult<RatingResponse>> GetRatingByIdOffers(
            [FromRoute] int offerId)
        {
                var exists = await _reviewService.ExistsEntityAsync(offerId);
                if (!exists)
                    return NotFound(new { message = $"offerId {offerId} not found" });

                var averageRating = await _reviewService.GetRatingByOfferId(offerId);
                var ratingResponse = new RatingResponse
                {
                    OfferId = offerId,
                    OverallRating = averageRating
                };
              
            return Ok(ratingResponse);
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
