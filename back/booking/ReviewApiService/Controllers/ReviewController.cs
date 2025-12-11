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
            return ReviewRequest.MapToModel(request);
        }


        protected override ReviewResponse MapToResponse(Review model)
        {
            return ReviewResponse.MapToResponse(model);
        }

    }

}
