using LocationContracts;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ReviewContracts;
using System.ComponentModel.DataAnnotations;
using WebApiGetway.Helpers;
using WebApiGetway.Service.Interfase;

namespace WebApiGetway.Controllers
{
    [ApiController]
    //[Route("[controller]")]
    [Route("reviews")]
    public class ReviewBffController : ControllerBase
    {
        private readonly IReviewBffService _reviewService;
        public ReviewBffController( 
            IReviewBffService reviewService,
            ILogger<ReviewBffController> logger)
        {
            _reviewService = reviewService;
        }


        //===============================================================================================================
        //      CREATING A REVIEW
        //===============================================================================================================

        [HttpPost]
        [Authorize]
        public async Task<ActionResult<ReviewResponse>> CreateReview(
            [FromBody, Required] ReviewRequest request,
            [FromQuery]  string lang)
        {

            request.UserId = User.GetUserId();  
            var result = await _reviewService.CreateReview(request, lang);
            return Ok(result);
        }


        //===============================================================================================================
        //      	RECEIVING REVIEW BY offerId
        //===============================================================================================================

        [HttpGet("by-offer/{offerId}")]
        public async Task<ActionResult<IEnumerable<ReviewResponse>>> GetReviewByOffer(
         [FromRoute] int offerId,
         [FromQuery] string lang)
        {
            var reviews = await _reviewService.GetReviewByOffer(offerId, lang);
            return Ok(reviews);
        }
        


        //===============================================================================================================
        //          RECEIVING REVIEW BY userId
        //===============================================================================================================

        [HttpGet("by-user/{userId}")]
        public async Task<ActionResult<IEnumerable<ReviewResponse>>> GetReviewByUser(
          [FromRoute] int userId,
          [FromQuery] string lang)
        {
            var reviews = await _reviewService.GetReviewByUser(userId, lang);
            return Ok(reviews);
        }


        //===============================================================================================================
        //        UPDATE REVIEWS 
        //===============================================================================================================

        [HttpPut("me/{reviewId}")]
        [Authorize]
        public async Task<ActionResult<ReviewResponse>> UpdateReviewById(
            [FromBody, Required] ReviewRequest request,
            [FromRoute] int reviewId,
            [FromQuery] string lang)
        {
            request.UserId = User.GetUserId();  
            var result = await _reviewService.UpdateReviewById(request, reviewId, lang);

            return Ok(result);
        }

        //===============================================================================================================
        //      DELETE REVIEW BY reviewId ALL REGIONS WITH TRANSLATION
        //===============================================================================================================

        [HttpDelete("me/{reviewId}")]
        [Authorize]
        public async Task<ActionResult<bool>> DeleteReviewById(
            [FromRoute] int reviewId,
            [FromQuery] int orderId)
        {
            var userId = User.GetUserId();
            var result = await _reviewService.DeleteReviewById(userId, reviewId, orderId);

            return Ok(result);
        }

    }
}
