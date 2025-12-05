using Microsoft.AspNetCore.Mvc;
using WebApiGetway.Service.Interfase;
using WebApiGetway.View;

namespace WebApiGetway.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BffController : ControllerBase
    {
        private readonly IGatewayService _gateway;

        public BffController(IGatewayService gateway)
        {
            _gateway = gateway;
        }



        // Карточка отзывы + автор
        [HttpGet("offer-review-card/{id}")]
        public async Task<IActionResult> GetOfferReviewCard(int id)
        {

            var reviewsTask = _gateway.ForwardRequestAsync<List<ReviewDto>>(
                "OfferApiService", $"/api/review/get-by-offerId/{id}", HttpMethod.Get, null);

            await Task.WhenAll(reviewsTask);


            var reviews = (reviewsTask.Result as OkObjectResult)?.Value as List<ReviewDto>;


            if (reviews.Count == 0) return NotFound("Reviews not found");

            var reviewWithUsers = new List<ReviewWithUserDto>();
            foreach (var r in reviews)
            {
                var userResponce = await _gateway.ForwardRequestAsync<UserDto>(
                    "UserApiService", $"/api/user/get/{r.UserId}", HttpMethod.Get, null);
                var user = (userResponce as OkObjectResult)?.Value as UserDto;

                reviewWithUsers.Add(new ReviewWithUserDto
                {
                    Id = r.Id,
                    Comment = r.Comment,
                    OverallRating = r.OverallRating,
                    CreatedAt = r.CreatedAt,
                    UpdatedAt = r.UpdatedAt,
                    User = new UserShortInfo()
                    {
                        Username = user.Username
                    }
                });
            }

            return Ok(reviewWithUsers);
        }
    }
}
