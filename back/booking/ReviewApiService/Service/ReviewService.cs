using Globals.Sevices;
using Microsoft.EntityFrameworkCore;
using ReviewApiService.Models;
using ReviewApiService.Service.Interface;
using ReviewApiService.View;

namespace ReviewApiService.Service
{
   
    public class ReviewService : TableServiceBase<Review, ReviewContext>, IReviewService
    {

        public async Task<List<Review>> GetReviewsByOfferId(int offerId)
        {
            using var db = new ReviewContext();
            var fitReviews = await db.Reviews
            .Where(r => r.OfferId == offerId && r.IsApproved)
            .ToListAsync();
            return fitReviews;
        }

        public async Task<List<Review>> GetReviewsByUserId(int userId)
        {
            using var db = new ReviewContext();
            var fitReviews = await db.Reviews
            .Where(r => r.UserId == userId && r.IsApproved)
            .ToListAsync();
            return fitReviews;
        }


        //public async Task<Dictionary<int, OfferReviewStats>> GetOfferReviewStatsAsync(IEnumerable<int> offerIds)
        //{
        //    using var db = new ReviewContext();
        //    var reviews = await db.Reviews
        //        .Where(r => offerIds.Contains(r.OfferId) && r.IsApproved)
        //        .ToListAsync();

        //    var stats = reviews
        //        .GroupBy(r => r.OfferId)
        //        .ToDictionary(
        //            g => g.Key,
        //            g => new OfferReviewStats
        //            {
        //                OfferId = g.Key,
        //                AverageRating = g.Any() ? g.Average(r => r.OverallRating) : 0,
        //                IsRecommended = g.Count() >= 20 && g.Average(r => r.OverallRating) >= 8.5,
        //                IsTopLocation = g.Any(r => r.Location >= 9),
        //                IsTopCleanliness = g.Any(r => r.Cleanliness >= 9)
        //            });

          
        //    foreach (var id in offerIds.Except(stats.Keys))
        //    {
        //        stats[id] = new OfferReviewStats
        //        {
        //            OfferId = id,
        //            AverageRating = 0,
        //            IsRecommended = false,
        //            IsTopLocation = false,
        //            IsTopCleanliness = false
        //        };
        //    }

        //    return stats;
        //}
    }
}
