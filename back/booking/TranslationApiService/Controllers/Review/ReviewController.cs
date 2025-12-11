using Globals.Abstractions;
using Globals.Controllers;
using TranslationApiService.Models.Offer;
using TranslationApiService.Models.Review;
using TranslationApiService.Service.Review.Interface;
using TranslationApiService.View;


namespace TranslationApiService.Controllers
{


    public class ReviewController : TranslationEntityControllerBase<ReviewTranslation, TranslationResponse, TranslationRequest>
    {
        public ReviewController(IReviewService reviewService, IRabbitMqService mqService)
            : base(reviewService, mqService)
        {
        }



        protected override ReviewTranslation MapToModel(TranslationRequest request)
        {
            return new ReviewTranslation
            {

                id = request.id,
                Comment = request.Title,
                EntityId = request.EntityId,
                Lang = request.Lang
            };

        }

        protected override TranslationResponse MapToResponse(ReviewTranslation model)
        {
            return new TranslationResponse
            {
                id = model.id,
                Title = model.Comment,
                EntityId = model.EntityId,
                Lang = model.Lang

            };
        }
    }
}