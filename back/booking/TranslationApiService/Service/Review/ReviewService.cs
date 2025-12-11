using Globals.Sevices;
using Microsoft.EntityFrameworkCore;
using TranslationApiService.Models;
using TranslationApiService.Models.Review;
using TranslationApiService.Service.Review.Interface;

namespace TranslationApiService.Service.Review
{
   
    public class ReviewService : TranslationServiceBase<ReviewTranslation, TranslationContext>, IReviewService
    {

    }
}
