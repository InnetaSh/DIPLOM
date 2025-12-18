using Globals.Abstractions;
using Microsoft.AspNetCore.Mvc;
using ReviewApiService.Models;
using ReviewApiService.View;

namespace ReviewApiService.Service.Interface
{
    public interface IReviewService : IServiceBase<Review>
    {
        Task<List<Review>> GetReviewsByOfferId(int offerId);
        Task<List<Review>> GetReviewsByUserId(int userId);

        //Task<Dictionary<int, OfferReviewStats>> GetOfferReviewStatsAsync(IEnumerable<int> offerIds);
    }
}
