using Globals.Abstractions;
using Globals.Sevices;
using Microsoft.AspNetCore.Mvc;
using TranslationApiService.Models.Review;

namespace TranslationApiService.Service.Review.Interface
{
    public interface IReviewService : ITranslationServiceBase<ReviewTranslation>
    {
     
    }
}
