using Globals.Abstractions;
using Microsoft.AspNetCore.Mvc;
using ReviewApiService.Models;

namespace ReviewApiService.Service.Interface
{
    public interface IReviewService : IServiceBaseNew<Review>
    {
        Task<List<Review>> GetReviewsByOfferId(int offerId);
        Task<List<Review>> GetReviewsByUserId(int userId);
        Task<double> GetRatingByOfferId(int offerId);
        Task<Dictionary<int, double>> GetRatingsByOfferIds(List<int> offerIds);    

        //Task<Dictionary<int, OfferReviewStats>> GetOfferReviewStatsAsync(IEnumerable<int> offerIds);
    }
}
